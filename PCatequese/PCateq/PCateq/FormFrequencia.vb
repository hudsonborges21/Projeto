Public Class FormFrequencia
    Public Sub formatarGrid()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigoAluno", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("Aluno", "Aluno", "300"))
        'DataGridView1.Columns.Add(CriarCampoCheck("Presenca", "Presenca", "50"))

    End Sub
    Public Sub mostarTodos()
        Dim obj As New Aula
        obj.CodigoTurma = tCodigo.Text
        obj.CodigoAula = TAulaCodigo.Text
        DataGridView1.DataSource = obj.TodosAlunosTurma()
        formatarGrid()
    End Sub

    Private Sub FormFrequencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mostarTodos()
        Catch ex As Exception
            MsgBox("Erro ao carregar Dados", MsgBoxStyle.Critical, "")
        End Try

    End Sub
End Class