Imports System.IO

Public Enum PanelSide
    Left
    Right
End Enum

Public Class FileManager

    Public Property ActivePanel As PanelSide

    Public Property LeftPath As String
    Public Property RightPath As String
    Public Property MarkedItemsLeft As New HashSet(Of String)
    Public Property MarkedItemsRight As New HashSet(Of String)

    Public ReadOnly Property CurrentPath As String
        Get
            If ActivePanel = PanelSide.Left Then
                Return LeftPath
            Else
                Return RightPath
            End If
        End Get
    End Property

    Public ReadOnly Property SourcePath As String
        Get
            If ActivePanel = PanelSide.Left Then
                Return LeftPath
            Else
                Return RightPath
            End If
        End Get
    End Property

    Public ReadOnly Property TargetPath As String
        Get
            If ActivePanel = PanelSide.Left Then
                Return RightPath
            Else
                Return LeftPath
            End If
        End Get
    End Property

    '----------------------------------------------------------------------------------------------
    ' Create Folder
    Public Function CreateFolder(newPath As String) As Boolean
        If String.IsNullOrWhiteSpace(newPath) Then
            MessageBox.Show("Folder path cannot be empty.")
            Return False
        End If

        If Directory.Exists(newPath) Then
            MessageBox.Show("Folder already exists.")
            Return True
        End If

        Try
            Directory.CreateDirectory(newPath)
            Return True
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Access denied.")
        Catch ex As PathTooLongException
            MessageBox.Show("Path is too long.")
        Catch ex As ArgumentException
            MessageBox.Show("Invalid folder name.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return False ' If code reaches here, an exception happened
    End Function

End Class
