Public Class FormTurmaConsulta

    Public Sub formatarGrid()

        ' //define e realiza a formatação de cada coluna
        DataGridView1.Columns(0).HeaderText = "Codigo"
        DataGridView1.Columns(1).HeaderText = "Nome"
        

        DataGridView1.Columns(0).Width = 65
        DataGridView1.Columns(1).Width = 230
       

        DataGridView1.Columns(0).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        


    End Sub


    Public Sub AtulizarGrid(ByVal TextoSql As String, ByVal Tabela As String)
        
    End Sub

    Private Sub FormTurmaConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Turma
        DataGridView1.DataSource = obj.Todos
        'formatarGrid()
    End Sub

    Private Sub TPesquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPesquisa.KeyPress
        Try
            Dim obj As New Turma
            obj.Nome = TPesquisa.Text + e.KeyChar
            DataGridView1.DataSource = obj.ConsultarNome()

            DataGridView1.Refresh()
        Catch ex As Exception
            MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub
End Class