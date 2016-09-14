Public Class FormMatricula

    
    Private Sub FormMatricula_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        tCodigo.Text = ""
        tNome.Text = ""
        TturmaCodigo.Text = ""
        TTurmaDescricao.Text = ""
        Close()
    End Sub
End Class