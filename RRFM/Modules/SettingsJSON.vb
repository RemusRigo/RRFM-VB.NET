'--------------------------------------------------------------------------------------------------
' RRFM: Remus Rigo File Manager
'    © 2026 Remus Rigo
'       v1.0 2026-05-05
'--------------------------------------------------------------------------------------------------

Imports System.Text.Json
Imports System.IO

Module SettingsJSON

    Public Class AppSettings
        Public Property appLocation As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width \ 2 - 400, Screen.PrimaryScreen.WorkingArea.Height \ 2 - 300)
        Public Property appSize As Size = New Size(1024, 640)
        Public Property splitter As Integer = appSize.Width \ 2
        Public Property pathLeft As String = Environment.ExpandEnvironmentVariables("%USERPROFILE%")
        Public Property pathRight As String = Environment.ExpandEnvironmentVariables("%TEMP%")
    End Class

    Private ReadOnly SettingsPath As String = Path.Combine(Application.StartupPath, "RRFM.json")

   Function Load() As AppSettings
      Try
         If Not File.Exists(SettingsPath) Then Return New AppSettings()

         Dim json As String = File.ReadAllText(SettingsPath)

         Return JsonSerializer.Deserialize(Of AppSettings)(json)
      Catch
         Return New AppSettings()   ' fall back to defaults on corrupt file
      End Try
   End Function

   Sub Save(settings As AppSettings)
      Dim options As New JsonSerializerOptions With {.WriteIndented = True}
      File.WriteAllText(SettingsPath, JsonSerializer.Serialize(settings, options))
   End Sub

End Module
