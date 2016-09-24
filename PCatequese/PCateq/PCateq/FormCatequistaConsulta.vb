Public Class FormCatequistaConsulta

    Public Sub formatarGrid()

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigo", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("nome", "Nome", "285"))

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
        formatarGrid()
    End Sub
End Class