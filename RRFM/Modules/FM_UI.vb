Imports System.IO

Module FM_UI

    Public Sub ScanDrives(cbLeft As ComboBox, cbRight As ComboBox)
        cbLeft.Items.Clear()
        cbRight.Items.Clear()
        For Each drv In DriveInfo.GetDrives()
            cbLeft.Items.Add(drv.Name.ToUpper)
            cbRight.Items.Add(drv.Name.ToUpper)
        Next
    End Sub

    '----------------------------------------------------------------------------------------------
    ' ToggleMark: Mark a file as selected/deselected
    Public Sub ToggleMark(lv As ListView, marked As HashSet(Of String))
        If lv.SelectedItems.Count = 0 Then Exit Sub
        Dim item As ListViewItem = lv.SelectedItems(0)
        Dim fileName As String = item.Tag.ToString()
        If marked.Contains(fileName) Then
            marked.Remove(fileName)
            item.ForeColor = lv.ForeColor
        Else
            marked.Add(fileName)
            item.ForeColor = Color.Red
        End If
        MoveSelectionDown(lv)
        'MessageBox.Show(marked.Count.ToString)
    End Sub

    '----------------------------------------------------------------------------------------------
    ' MoveSelectionDown: Move down after file selected/deselected
    Public Sub MoveSelectionDown(lv As ListView)
        If lv.SelectedIndices.Count = 0 Then Exit Sub

        Dim index As Integer = lv.SelectedIndices(0)
        If index < lv.Items.Count - 1 Then
            lv.Items(index).Selected = False
            lv.Items(index + 1).Selected = True
            lv.Items(index + 1).Focused = True
            lv.Items(index + 1).EnsureVisible()
        End If
    End Sub

End Module
