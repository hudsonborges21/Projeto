Public Class FormFrequencia
    Public Sub formatarGrid()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigo", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("nome", "Nome", "300"))
        DataGridView1.Columns.Add(CriarCampo("endereco", "Endereço", "185"))
        DataGridView1.Columns.Add(CriarCampo("telefone", "Telefone", "100"))

    End Sub
    Public Sub mostarTodos()
        Dim obj As New Matricula
        obj.CodigoTurma = tCodigo.Text
        DataGridView1.DataSource = obj.TodosAlunosTurma()
        formatarGrid()
    End Sub

    Private Sub FormFrequencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostarTodos()
    End Sub
End Class