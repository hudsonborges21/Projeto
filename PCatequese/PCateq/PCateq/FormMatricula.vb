Public Class FormMatricula
    Public incluindo As Boolean
    Public codturmaCarregado As String
    
    Private Sub FormMatricula_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
            FormTurmaConsulta.TPesquisa.Focus()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        tCodigo.Text = ""
        tNome.Text = ""
        TturmaCodigo.Text = ""
        TTurmaDescricao.Text = ""
        Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        Try
            Dim obj As Matricula = New Matricula
            obj.CodigoAluno = tCodigo.Text
            obj.CodigoTurma = TturmaCodigo.Text
            obj.DataCad = FormatDateTime(TDataCad.Text, DateFormat.ShortDate)
            'obj.Stautus = ""

            If Not incluindo Then
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Alterar(codturmaCarregado) ' nao passa o codigo atual , vai passar o codigo ta turma que sera alterado
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
                incluindo = False
            Else

                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Incluir()
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If

        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub
End Class