Imports System.IO

Public Class frmFM
   Inherits Form

   Private isShown As Boolean = False
   Private cfg As AppSettings
   Private FM As New FileManager
   Private _busy As Boolean

   Public sourcePath, targetPath As String

   Public ActivePanel As PanelSide


   Private ReadOnly Property CurrentListView As ListView
      Get
         If FM.ActivePanel = PanelSide.Left Then
            Return lvLeft
         Else
            Return lvRight
         End If
      End Get
   End Property

   '-----------------------------------------------------------------------------------------------
   Private Sub LoadSettings()
      cfg = SettingsJSON.Load()
      Me.Location = cfg.appLocation
      Me.Size = cfg.appSize
      FM.LeftPath = cfg.pathLeft
      FM.RightPath = cfg.pathRight
      SplitContainer.SplitterDistance = cfg.splitter
   End Sub

   '-----------------------------------------------------------------------------------------------
   Private Sub SaveSettings()
      cfg.pathLeft = FM.LeftPath
      cfg.pathRight = FM.RightPath
      cfg.appLocation = Me.Location
      cfg.appSize = Me.Size
      cfg.splitter = SplitContainer.SplitterDistance
      SettingsJSON.Save(cfg)
   End Sub

   '-----------------------------------------------------------------------------------------------
   Private Sub InitializeListView(lv As ListView)
      lv.View = View.Details
      lv.FullRowSelect = True
      lv.Columns.Clear()
      lv.Columns.Add("Name", 250)
      lv.Columns.Add("Ext", 50)
      lv.Columns.Add("Size", 100)
   End Sub

   Private Sub AddHandlers()
      AddHandler lvLeft.ItemActivate, AddressOf ListView_ItemActivate
      AddHandler lvRight.ItemActivate, AddressOf ListView_ItemActivate
   End Sub
   '-----------------------------------------------------------------------------------------------
   Private Sub LoadPath(lv As ListView, currentPath As String)
      lv.Items.Clear()
      Try
         If lv Is lvLeft Then
            'Case PanelSide.Left
            cbDrvLeft.SelectedItem = Path.GetPathRoot(currentPath).ToUpper
            lblPathLeft.Text = currentPath
            FM.LeftPath = currentPath
         ElseIf lv Is lvRight Then
            'Case PanelSide.Right
            cbDrvRight.SelectedItem = Path.GetPathRoot(currentPath).ToUpper
            lblPathRight.Text = currentPath
            FM.RightPath = currentPath
            'End Select
         End If

         Dim liCurrent As New ListViewItem(".")
         liCurrent.SubItems.Add("Current")
         liCurrent.Tag = currentPath
         lv.Items.Add(liCurrent)

         ' Add parent directory entry
         Dim parentDir = Directory.GetParent(currentPath)
         If parentDir IsNot Nothing Then
            Dim li As New ListViewItem("..")
            li.SubItems.Add("Parent")
            li.Tag = parentDir.FullName
            lv.Items.Add(li)
         End If

         ' List Directories
         For Each dirItem In Directory.GetDirectories(currentPath)
            Dim di As New DirectoryInfo(dirItem)
            Dim li As New ListViewItem("[" & di.Name & "]")
            li.SubItems.Add("Folder")
            li.Tag = di.FullName
            lv.Items.Add(li)
         Next

         ' List Files
         For Each fileItem In Directory.GetFiles(currentPath)
            Dim fi As New FileInfo(fileItem)
            Dim li As New ListViewItem(fi.Name)
            li.SubItems.Add(fi.Extension)
            li.Tag = fi.FullName
            lv.Items.Add(li)
         Next

      Catch ex As UnauthorizedAccessException
         MessageBox.Show("Access denied: " & currentPath)
      Catch ex As Exception
         MessageBox.Show("Error loading: " & currentPath & vbCrLf & ex.Message)
      End Try
   End Sub

   '=== ComboBox =================================================================================

   '----------------------------------------------------------------------------------------------
   ' cbDrvLeft: SelectedIndexChanged
   Private Sub cbDrvLeft_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDrvLeft.SelectedIndexChanged
      If isShown Then LoadPath(lvLeft, cbDrvLeft.SelectedItem.ToString)
   End Sub

   '----------------------------------------------------------------------------------------------
   ' cbDrvRight: SelectedIndexChanged
   Private Sub cbDrvRight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDrvRight.SelectedIndexChanged
      If isShown Then LoadPath(lvRight, cbDrvRight.SelectedItem.ToString)
   End Sub

   '=== ListView =================================================================================

   '----------------------------------------------------------------------------------------------
   ' ListView: onItemActivate
   Private Sub ListView_ItemActivate(sender As Object, e As EventArgs)
      Select Case DirectCast(sender, ListView).Name
         Case "lvLeft"
            FM.ActivePanel = PanelSide.Left
            ListView_HandleNavigation(lvLeft, FM.LeftPath)
         Case "lvRight"
            FM.ActivePanel = PanelSide.Right
            ListView_HandleNavigation(lvRight, FM.RightPath)
      End Select
   End Sub

   '----------------------------------------------------------------------------------------------
   ' ListView: onItemActivate: Handle Navigation
   Private Sub ListView_HandleNavigation(lv As ListView, currentPath As String)
      If lv.SelectedItems.Count = 0 Then Exit Sub

      Dim item = lv.SelectedItems(0)
      Dim target = CStr(item.Tag)

      Select Case item.Text
         Case "."
            LoadPath(lv, currentPath) ' Refresh current directory

         Case ".."
            LoadPath(lv, target) ' Navigate to parent directory

         Case Else
            If Directory.Exists(target) Then ' if it's a directory, navigate into it
               LoadPath(lv, target)
            ElseIf File.Exists(target) Then ' if it's a file, open it with default application
               Try
                  Process.Start(target)
               Catch ex As Exception
                  MessageBox.Show("Cannot open file: " & ex.Message)
               End Try
            End If
      End Select
   End Sub

   '----------------------------------------------------------------------------------------------
   ' ListView: onKeyDown
   Private Sub ListView_KeyDown(sender As Object, e As KeyEventArgs) Handles lvLeft.KeyDown, lvRight.KeyDown
      ' INS: select files
      If e.KeyCode = Keys.Insert Then
         ToggleMark(CurrentListView, If(FM.ActivePanel = PanelSide.Left, FM.MarkedItemsLeft, FM.MarkedItemsRight))
         tsStatusLabelInfo.Text = If(FM.ActivePanel = PanelSide.Left, FM.MarkedItemsLeft.Count.ToString, FM.MarkedItemsRight.Count.ToString) & " selected files/folders"
         e.Handled = True
      End If
   End Sub

   '----------------------------------------------------------------------------------------------
   ' lvLeft: onEnter
   Private Sub lvLeft_Enter(sender As Object, e As EventArgs) Handles lvLeft.Enter
      FM.ActivePanel = PanelSide.Left
      lvLeft.BorderStyle = BorderStyle.Fixed3D
      lvRight.BorderStyle = BorderStyle.None
   End Sub

   '----------------------------------------------------------------------------------------------
   ' lvRight: onEnter
   Private Sub lvRight_Enter(sender As Object, e As EventArgs) Handles lvRight.Enter
      FM.ActivePanel = PanelSide.Right
      lvLeft.BorderStyle = BorderStyle.None
      lvRight.BorderStyle = BorderStyle.Fixed3D
   End Sub

   '=== Form =====================================================================================

   '-----------------------------------------------------------------------------------------------
   ' frmFM: onClose
   Private Sub frmFM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      SaveSettings()
   End Sub

   '-----------------------------------------------------------------------------------------------
   ' frmFM: onLoad
   Private Sub frmFM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      LoadSettings()

      ' Initialize ListViews
      InitializeListView(lvLeft)
      InitializeListView(lvRight)

      ScanDrives(cbDrvLeft, cbDrvRight)

      ' load initial paths
      FM.ActivePanel = PanelSide.Left
      LoadPath(lvLeft, FM.LeftPath)
      FM.ActivePanel = PanelSide.Right
      LoadPath(lvRight, FM.RightPath)
      FM.ActivePanel = PanelSide.Left

      Me.Text = appTitle
      tsStatusLabelAppInfo.Text = appTitle

      ' Add event handlers for item activation
      AddHandlers()
   End Sub

   Private Sub frmFM_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      isShown = True
   End Sub

   '=============================================================================================

   '----------------------------------------------------------------------------------------------
   ' ProcessCmdKey
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData

         Case Keys.F5
            If Not _busy Then
               _busy = True
               Try
                  _CopyItems()
               Finally
                  _busy = False
               End Try
            End If
            Return True ' handled: don't let WinForms dispatch the key again

         Case Keys.F6         ' Move Files/Folders

         Case Keys.F7
            _CreateFolder()


         Case Keys.F8         ' Delete Files/Folders

         Case Keys.Delete     ' Delete Files/Folders

      End Select
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   '----------------------------------------------------------------------------------------------
   Public Sub _CreateFolder()
      Dim folderName As String = InputBox("Enter folder name:", "Create folder")
      FM.CreateFolder(Path.Combine(FM.CurrentPath, folderName))
      If FM.ActivePanel = PanelSide.Left Then
         LoadPath(lvLeft, FM.CurrentPath)
      Else
         LoadPath(lvRight, FM.CurrentPath)
      End If
   End Sub

   '----------------------------------------------------------------------------------------------
   ' Items to operate on: marked (INS) first, else the selected ones (Ctrl/Shift+click, or the
   ' single current item). "." and ".." are never included.
   Private Function GetItemsToProcess() As List(Of String)
      Dim marked = If(FM.ActivePanel = PanelSide.Left, FM.MarkedItemsLeft, FM.MarkedItemsRight)
      If marked.Count > 0 Then Return New List(Of String)(marked)

      Dim result As New List(Of String)
      For Each li As ListViewItem In CurrentListView.SelectedItems
         If li.Text = "." OrElse li.Text = ".." Then Continue For
         result.Add(CStr(li.Tag))
      Next
      Return result
   End Function

   Public Sub _CopyItems()
      Dim items = GetItemsToProcess()
      If items.Count = 0 Then Exit Sub

      If String.Equals(FM.SourcePath.TrimEnd("\"c), FM.TargetPath.TrimEnd("\"c),
                         StringComparison.OrdinalIgnoreCase) Then
         MessageBox.Show("Source and target folders are the same.")
         Exit Sub
      End If

      Using frm As New frmCopyMove(items, FM.TargetPath)
         frm.ShowDialog(Me)
      End Using

      ' clear marks (they're keyed by path and the panels are rebuilt anyway)
      FM.MarkedItemsLeft.Clear()
      FM.MarkedItemsRight.Clear()
      tsStatusLabelInfo.Text = ""

      LoadPath(lvLeft, FM.LeftPath)
      LoadPath(lvRight, FM.RightPath)
   End Sub

End Class