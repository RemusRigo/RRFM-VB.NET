Imports System.IO

Public Class frmFM
    Inherits Form


    Private FM As New FileManager

    Private cfg As AppSettings

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

    '=============================================================================================

    '----------------------------------------------------------------------------------------------
    ' ProcessCmdKey
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        Select Case keyData

            Case Keys.F5
                _CopyItems()

            Case Keys.F6
                MessageBox.Show("Move")

            Case Keys.F7
                _CreateFolder()


            Case Keys.F8
                MessageBox.Show("Delete")

            Case Keys.Delete
                MessageBox.Show("Delete")

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
    Public Sub _CopyItems()
        Dim itemsToCopy As New List(Of String)
        If FM.ActivePanel = PanelSide.Left Then
            itemsToCopy.AddRange(FM.MarkedItemsLeft)
        Else
            itemsToCopy.AddRange(FM.MarkedItemsRight)
        End If

        ' No marked items -> copy current item
        If itemsToCopy.Count = 0 Then
            If CurrentListView.SelectedItems.Count = 0 Then Exit Sub

            itemsToCopy.Add(CurrentListView.SelectedItems(0).Tag.ToString())
        End If
        FM.CopyItems(itemsToCopy, FM.TargetPath)
        LoadPath(lvLeft, FM.LeftPath)
        LoadPath(lvRight, FM.RightPath)
    End Sub

End Class