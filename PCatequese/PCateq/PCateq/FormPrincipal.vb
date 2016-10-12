Public Class FormPrincipal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormAluno.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormCatequista.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormTurma.ShowDialog()

    End Sub

    Private Sub AlunoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlunoToolStripMenuItem.Click
        FormAluno.ShowDialog()
    End Sub

    Private Sub CatequistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatequistaToolStripMenuItem.Click
        FormCatequista.ShowDialog()
    End Sub

    Private Sub TurmasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TurmasToolStripMenuItem.Click
        FormTurma.ShowDialog()
    End Sub

    Private Sub UsuáriosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuáriosToolStripMenuItem.Click
        FormUsuario.ShowDialog()
    End Sub

    Private Sub FormPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Login.Close() 'fecha o formulario de login que fica oculto
    End Sub
End Class
