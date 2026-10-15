Imports System.IO

Public Class FileManagerForm
   Inherits Form

   Private cfg As AppSettings
   Private pathLeft As String
   Private pathRight As String

   '-----------------------------------------------------------------------------------------------
   Private Sub LoadSettings()
      cfg = SettingsJSON.Load()
      Me.Location = cfg.appLocation
      Me.Size = cfg.appSize
      pathLeft = cfg.pathLeft
      pathRight = cfg.pathRight
      SplitContainer.SplitterDistance = cfg.splitter
   End Sub

   '-----------------------------------------------------------------------------------------------
   Private Sub SaveSettings()
      cfg.pathLeft = pathLeft
      cfg.pathRight = pathRight
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

   '-----------------------------------------------------------------------------------------------
   Private Sub LoadPath(lv As ListView, currentPath As String)
      lv.Items.Clear()

      Try

         ' Add current directory entry
         Dim currentDir = Directory.GetParent(currentPath)
         If currentDir IsNot Nothing Then
            Dim li As New ListViewItem(".")
            li.SubItems.Add("Current")
            li.Tag = currentDir.FullName
            lv.Items.Add(li)
         End If

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

   '-----------------------------------------------------------------------------------------------
   Private Sub lvLeft_ItemActivate(sender As Object, e As EventArgs)
      HandleNavigation(lvLeft, pathLeft)
   End Sub

   '-----------------------------------------------------------------------------------------------
   Private Sub lvRight_ItemActivate(sender As Object, e As EventArgs)
      HandleNavigation(lvRight, pathRight)
   End Sub

   '-----------------------------------------------------------------------------------------------
   Private Sub HandleNavigation(lv As ListView, ByRef currentPath As String)
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
               currentPath = target ' Update current path (pathLeft / pathRight)
               LoadPath(lv, currentPath)
            ElseIf File.Exists(target) Then ' if it's a file, open it with default application
               Try
                  Process.Start(target)
               Catch ex As Exception
                  MessageBox.Show("Cannot open file: " & ex.Message)
               End Try
            End If
      End Select

   End Sub

   '-----------------------------------------------------------------------------------------------

   Private Sub FileManagerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      LoadSettings()

      ' Initialize ListViews
      InitializeListView(lvLeft)
      InitializeListView(lvRight)

      ' load initial paths
      LoadPath(lvLeft, pathLeft)
      LoadPath(lvRight, pathRight)

      ' Add event handlers for item activation
      AddHandler lvLeft.ItemActivate, AddressOf lvLeft_ItemActivate
      AddHandler lvRight.ItemActivate, AddressOf lvRight_ItemActivate
   End Sub

   '-----------------------------------------------------------------------------------------------

   Private Sub FileManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      SaveSettings()
   End Sub

End Class