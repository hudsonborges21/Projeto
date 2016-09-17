Public Class FormCatequistaConsulta

    Public Sub formatarGrid()

        ' //define e realiza a formatação de cada coluna
        DataGridView1.Columns(0).HeaderText = "Codigo"
        DataGridView1.Columns(1).HeaderText = "Nome"


        DataGridView1.Columns(0).Width = 65
        DataGridView1.Columns(1).Width = 230


        DataGridView1.Columns(0).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft



    End Sub


   
    Private Sub TPesquisa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPesquisa.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 Then
                If Asc(e.KeyChar) > 65 Or Asc(e.KeyChar) < 90 Or Asc(e.KeyChar) > 96 Or Asc(e.KeyChar) < 122 Then
                    'e.Handled = True
                    Dim obj As New Catequista
                    obj.Nome = TPesquisa.Text + e.KeyChar
                    DataGridView1.DataSource = obj.TodosNomes()
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

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            FormTurma.TCatequistaCodigo.Text = DataGridView1.CurrentRow.Cells(0).Value
            FormTurma.TCatequistaNome.Text = DataGridView1.CurrentRow.Cells(1).Value
            TPesquisa.Text = ""
            FormTurma.TCatequistaCodigo.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub FormCatequistaConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Catequista
        DataGridView1.DataSource = obj.Todos
    End Sub
End Class