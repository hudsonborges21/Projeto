Public Class FormPrincipal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormAluno.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormCatequista.ShowDialog()
    End Sub
End Class
