Public Class FormAula
    Public incluindo As Boolean
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        limpar()
        Close()
    End Sub
    Public Sub limpar()
        tCodigo.Text = ""
        tDescricao.Text = ""
        TAulaCodigo.Text = ""
        TAulaData.Text = ""
        TAulaDescricao.Text = ""
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try

            Dim obj As Aula = New Aula
            obj.CodigoTurma = tCodigo.Text
            obj.DataCad = FormatDateTime(TAulaData.Text, DateFormat.ShortDate)
            obj.Descricao = TAulaDescricao.Text

            If Not incluindo Then
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.CodigoAula = TAulaCodigo.Text
                obj.Alterar() ' nao passa o codigo atual , vai passar o codigo ta turma que sera alterado
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
                incluindo = False
            Else

                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Incluir()
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If
            Close()
            limpar()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub
End Class