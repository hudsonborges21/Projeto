Public Class FormMatricula

    
    Private Sub FormMatricula_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
        End If
    End Sub
End Class