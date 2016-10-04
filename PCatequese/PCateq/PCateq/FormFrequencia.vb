Public Class FormFrequencia
    Public Sub formatarGrid()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigoAluno", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("Aluno", "Aluno", "400"))
        DataGridView1.Columns.Add(CriarCampoCheck("Presenca", "Presença", "90"))

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

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim obj As Aula = New Aula
            Dim codAluno As Integer
            Dim presenca As Boolean

            For i = 0 To DataGridView1.Rows.Count - 1
                'MsgBox(DataGridView1.Rows.Item(i).Cells(2).Value)
                codAluno = DataGridView1.Rows.Item(i).Cells(0).Value
                presenca = DataGridView1.Rows.Item(i).Cells(2).Value
                obj.CodigoAula = TAulaCodigo.Text
                obj.CodigoAluno = codAluno
                obj.Presenca = presenca
                obj.AlterarFrequencia()
            Next
            MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao gravar Dados", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub
    Private Sub Desabilita()
        btnConfirmar.Enabled = True
        BtnCancelar.Enabled = True
    End Sub
    Private Sub Habilita()
        btnConfirmar.Enabled = False
        BtnCancelar.Enabled = False
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Desabilita()
    End Sub
End Class