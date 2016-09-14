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
        TPesquisa.Focus()
        'formatarGrid()
    End Sub

    Private Sub TPesquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPesquisa.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 Then
                If Asc(e.KeyChar) > 65 Or Asc(e.KeyChar) < 90 Or Asc(e.KeyChar) > 96 Or Asc(e.KeyChar) < 122 Then
                    'e.Handled = True
                    Dim obj As New Turma
                    obj.Nome = TPesquisa.Text + e.KeyChar
                    DataGridView1.DataSource = obj.ConsultarNome()
                    DataGridView1.Refresh()
                End If
            End If

            If Asc(e.KeyChar) = 13 Then
                DataGridView1.Focus()
            End If
            If Asc(e.KeyChar) = 27 Then
                TPesquisa.Text = ""
                Me.Close()
            End If



        Catch ex As Exception
            MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub

    Private Sub TPesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles TPesquisa.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    DataGridView1.Focus()
        'End If
        'If e.KeyCode = Keys.Escape Then
        '    TPesquisa.Text = ""
        '    TPesquisa.Focus()
        'End If
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            FormMatricula.TturmaCodigo.Text = DataGridView1.CurrentRow.Cells(0).Value
            FormMatricula.TTurmaDescricao.Text = DataGridView1.CurrentRow.Cells(2).Value
            TPesquisa.Text = ""
            Me.Close()
        End If
    End Sub
End Class