Imports System.IO
Imports System.Threading

Public Class frmCopyMove

   Private pbSize As ctrlProgressBarPercentage
   Private pbItems As ctrlProgressBarPercentage

   '-------------------------------------------------------------------------------------------
   Private Class CopyEntry
      Public Source As String
      Public Dest As String
      Public IsDir As Boolean
      Public Size As Long
   End Class

   Private Structure CopyProgress
      Public DoneBytes, TotalBytes As Long
      Public DoneFiles, TotalFiles As Integer
      Public Current As String
   End Structure

   Private Const BufferSize As Integer = 1024 * 1024

   Private ReadOnly _items As List(Of String)
   Private ReadOnly _targetDir As String
   Private ReadOnly _plan As New List(Of CopyEntry)
   Private ReadOnly _cts As New CancellationTokenSource()

   Private _totalBytes As Long
   Private _totalFiles As Integer
   Private _doneBytes As Long
   Private _doneFiles As Integer
   Private _running As Boolean = True
   Private _succeeded As Boolean

   '-------------------------------------------------------------------------------------------
   Public Sub New(items As IEnumerable(Of String), targetDir As String)
      InitializeComponent()
      _items = New List(Of String)(items)
      _targetDir = targetDir
   End Sub

   Private Sub Initialize()
      pbSize = New ctrlProgressBarPercentage()
      pbSize.Dock = DockStyle.Fill
      pbSize.Maximum = 1000
      pnlSize.Controls.Add(pbSize)

      pbItems = New ctrlProgressBarPercentage()
      pbItems.Dock = DockStyle.Fill
      pnlItems.Controls.Add(pbItems)
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmCopyMove: Load
   Private Sub frmCopyMove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Initialize()
      Me.Text = "[Copy] : Scanning..."
      lblTotalSize.Text = "Total size: 0 B of 0 B"
      lblTotalItems.Text = "Total items: 0 of 0"
   End Sub

   '-------------------------------------------------------------------------------------------
   ' frmCopyMove: Shown
   ' Start the copy/move once the dialog is visible
   Private Async Sub frmCopyMove_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Dim progress As New Progress(Of CopyProgress)(AddressOf OnProgress)

      Try
         _succeeded = Await Task.Run(Function() RunCopy(progress, _cts.Token))
      Catch ex As OperationCanceledException
         ' cancelled by the user
      Catch ex As Exception
         MessageBox.Show(Me, ex.Message, "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      _running = False
      Me.DialogResult = If(_succeeded, DialogResult.OK, DialogResult.Cancel) ' closes the dialog
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmCopyMove: FormClosing
   Private Sub frmCopyMove_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If _running Then
         e.Cancel = True      ' wait for the worker to stop, it closes the form itself
         _cts.Cancel()
      End If
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' btnCancel: Click
   Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
      _cts.Cancel()
      btnCancel.Enabled = False
   End Sub



   '=== UI update (runs on the UI thread) ======================================================
   Private Sub OnProgress(p As CopyProgress)
      Dim permille As Integer
      If p.TotalBytes > 0 Then
         permille = CInt(p.DoneBytes * 1000L \ p.TotalBytes)
      Else
         permille = If(p.DoneFiles >= p.TotalFiles, 1000, 0)
      End If
      pbSize.Value = permille

      pbItems.Maximum = Math.Max(1, p.TotalFiles)
      pbItems.Value = p.DoneFiles

      lblTotalSize.Text = "Total size: " & FormatSize(p.DoneBytes) & " of " & FormatSize(p.TotalBytes)
      lblTotalItems.Text = "Total items: " & p.DoneFiles & " of " & p.TotalFiles
      Me.Text = "[Copy] : " & p.Current
   End Sub

   Private Shared Function FormatSize(bytes As Long) As String
      Dim units() As String = {"B", "KB", "MB", "GB", "TB"}
      Dim v As Double = bytes
      Dim i As Integer = 0
      While v >= 1024 AndAlso i < units.Length - 1
         v /= 1024
         i += 1
      End While
      Return If(i = 0, v.ToString("0") & " B", v.ToString("0.##") & " " & units(i))
   End Function

   '=== Worker (runs on a background thread) ===================================================
   'Private Sub RunCopy(progress As IProgress(Of CopyProgress), token As CancellationToken)
   Private Function RunCopy(progress As IProgress(Of CopyProgress), token As CancellationToken) As Boolean
      BuildPlan(token)
      If token.IsCancellationRequested Then Return False
      Report(progress, "")

      Dim sw = Stopwatch.StartNew()

      For Each entry In _plan
         If token.IsCancellationRequested Then Return False

         If entry.IsDir Then
            Directory.CreateDirectory(entry.Dest)
            Continue For
         End If

         If File.Exists(entry.Dest) Then
            Select Case AskOverwrite(entry.Dest)
               Case DialogResult.Cancel
                  Return False
               Case DialogResult.No
                  _doneBytes += entry.Size      ' skipped: count it as done
                  _doneFiles += 1
                  Report(progress, entry.Source)
                  Continue For
            End Select
         End If

         If Not CopyFile(entry, progress, token, sw) Then Return False
         _doneFiles += 1
         Report(progress, entry.Source)
      Next
      Return True
   End Function

   Private Sub BuildPlan(token As CancellationToken)
      For Each item In _items
         If token.IsCancellationRequested Then Return
         Dim name As String = Path.GetFileName(item.TrimEnd("\"c))
         Dim dest As String = Path.Combine(_targetDir, name)

         If File.Exists(item) Then
            AddFile(item, dest)
         ElseIf Directory.Exists(item) Then
            Dim src As String = item.TrimEnd("\"c)
            If _targetDir.TrimEnd("\"c).Equals(src, StringComparison.OrdinalIgnoreCase) OrElse
               _targetDir.StartsWith(src & "\", StringComparison.OrdinalIgnoreCase) Then
               Throw New InvalidOperationException("Cannot copy a folder into itself: " & src)
            End If
            AddDirectory(src, dest, token)
         End If
      Next
   End Sub

   Private Sub AddFile(src As String, dest As String)
      Dim size As Long = New FileInfo(src).Length
      _plan.Add(New CopyEntry With {.Source = src, .Dest = dest, .IsDir = False, .Size = size})
      _totalBytes += size
      _totalFiles += 1
   End Sub

   Private Sub AddDirectory(srcDir As String, destDir As String, token As CancellationToken)
      If token.IsCancellationRequested Then Return
      _plan.Add(New CopyEntry With {.Source = srcDir, .Dest = destDir, .IsDir = True})  ' keeps empty folders

      For Each f In Directory.GetFiles(srcDir)
         AddFile(f, Path.Combine(destDir, Path.GetFileName(f)))
      Next
      For Each d In Directory.GetDirectories(srcDir)
         AddDirectory(d, Path.Combine(destDir, Path.GetFileName(d)), token)
      Next
   End Sub

   'Private Sub CopyFile(entry As CopyEntry, progress As IProgress(Of CopyProgress), token As CancellationToken, sw As Stopwatch)
   Private Function CopyFile(entry As CopyEntry, progress As IProgress(Of CopyProgress), token As CancellationToken, sw As Stopwatch) As Boolean
      Dim buffer(BufferSize - 1) As Byte
      Dim lastReport As Long = 0
      Dim cancelled As Boolean = False

      Try
         Using fin As New FileStream(entry.Source, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize)
            Using fout As New FileStream(entry.Dest, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize)
               Do
                  Dim n As Integer = fin.Read(buffer, 0, buffer.Length)
                  If n = 0 Then Exit Do
                  fout.Write(buffer, 0, n)
                  _doneBytes += n

                  If token.IsCancellationRequested Then
                     cancelled = True
                     Exit Do
                  End If

                  If sw.ElapsedMilliseconds - lastReport >= 50 Then   ' throttle UI updates
                     lastReport = sw.ElapsedMilliseconds
                     Report(progress, entry.Source)
                  End If
               Loop
            End Using
         End Using

         If cancelled Then
            File.Delete(entry.Dest)        ' streams are closed now: remove the partial file
            Return False
         End If

         File.SetLastWriteTime(entry.Dest, File.GetLastWriteTime(entry.Source))
         Return True

      Catch
         ' failed: don't leave a half-written file behind
         Try
            If File.Exists(entry.Dest) Then File.Delete(entry.Dest)
         Catch
         End Try
         Throw
      End Try
   End Function

   Private Sub Report(progress As IProgress(Of CopyProgress), current As String)
      progress.Report(New CopyProgress With {
         .DoneBytes = _doneBytes, .TotalBytes = _totalBytes,
         .DoneFiles = _doneFiles, .TotalFiles = _totalFiles,
         .Current = current})
   End Sub

   Private Function AskOverwrite(destFile As String) As DialogResult
      Dim fi As New FileInfo(destFile)
      Return CType(Me.Invoke(Function() MessageBox.Show(Me,
            "File already exists:" & vbCrLf & destFile & vbCrLf &
            FormatSize(fi.Length) & ", modified " & fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") &
            vbCrLf & vbCrLf & "Overwrite?",
            "Confirm overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)), DialogResult)
   End Function

End Class