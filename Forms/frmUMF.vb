Public Class frmUMF
   Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
      Dim dlg As New OpenFileDialog With {
       .Title = "Select a file",
       .Filter = "All files (*.*)|*.*",
       .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
       .CheckFileExists = True,
       .CheckPathExists = True
   }

      If dlg.ShowDialog() = DialogResult.OK Then
         txtBoxFromFile.Text = dlg.FileName
         txtBoxInput.Text = System.IO.File.ReadAllText(dlg.FileName)
      End If
   End Sub
End Class
