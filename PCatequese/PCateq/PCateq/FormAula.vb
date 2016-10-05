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
                LancarAlunosAula() 'lançamento de alunos na tabela frequencia
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If
            Close()
            limpar()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub

    Private Sub LancarAlunosAula()
        'cria obj da classe aula e usa metodo para pegar o último codigo do banco de dados
        Dim obj As Aula = New Aula
        obj.CodigoTurma = tCodigo.Text
        obj.UltimoCodigo() 'pega ultimo codigo

        TAulaCodigo.Text = obj.CodigoAula 'coloca valor do textbox

        Dim mat As Matricula = New Matricula ' cria objt mat da classe matricula, pegar os alunos matriculados da turma, add eles na lista
        mat.CodigoTurma = tCodigo.Text
        For Each matr As Matricula In mat.TodosAlunosTurma() 'metodo TodosAlunosTurma() é uma lista de objetos 

            'pega os objetos da classe Matricula, e passa os valores para classe Aula
            obj.CodigoAluno = matr.CodigoAluno
            obj.Presenca = False
            obj.IncluirFrequencia() 'metodo da classe Aula, responsavel por incluir alunos da tabela frequencia no banco de dados.
        Next


    End Sub
End Class