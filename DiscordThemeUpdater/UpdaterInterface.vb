Public Class UpdaterInterface

    Private Sub UpdaterInterface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
        Timer1.Start()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Application.Exit()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/0mniscient/Discord-Themes/master/Themes/Discord%20Reborn.theme.css", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BetterDiscord\drbupdate\Discord_Reborn.theme.css", "", "", False, 72000, True)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If BackgroundWorker1.IsBusy = False Then
            Label1.Text = "The updater is installing the update..."
            Label1.Refresh()
            My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BetterDiscord\themes\Discord_Reborn.theme.css", My.Computer.FileSystem.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BetterDiscord\drbupdate\Discord_Reborn.theme.css").Replace("https://imgur.com/RG03PyX.png", My.Settings.bg), False)
            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\BetterDiscord\drbupdate\Discord_Reborn.theme.css")
            Application.Exit()
        End If
    End Sub
End Class
