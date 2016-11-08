Imports CrystalDecisions.Shared

Public Class FormMostarRelatorio

    Private Sub FormMostarRelatorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionInfo As New ConnectionInfo()
        connectionInfo.ServerName = "DESENV-HUDSON\SQLEXPRESS"
        connectionInfo.DatabaseName = "DBCatequese"
        connectionInfo.UserID = "sa"
        connectionInfo.Password = "123"
    End Sub
End Class