Imports System.Data.SqlClient

Public Class FormAluno



    Public Sub formatarGrid()

        ' //define e realiza a formatação de cada coluna
        DataGridView1.Columns(0).HeaderText = "Codigo"
        DataGridView1.Columns(1).HeaderText = "Nome"
        DataGridView1.Columns(2).HeaderText = "Endereço"
        DataGridView1.Columns(3).HeaderText = "Cidade"

        DataGridView1.Columns(0).Width = 65
        DataGridView1.Columns(1).Width = 230
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100

        DataGridView1.Columns(0).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView1.Columns(2).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView1.Columns(3).DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


    End Sub


    Public Sub AtulizarGrid(ByVal TextoSql As String, ByVal Tabela As String)
        Dim con As New Conexao
        'criando a conexao com o banco de dados
        Dim conexao As SqlConnection
        conexao = New SqlConnection(con.StrConexao)
        'criando o comando sql
        Dim sql As String
        sql = TextoSql

        Dim comando As SqlCommand
        comando = New SqlCommand(sql, conexao)

        Dim dataadapter As SqlDataAdapter = New SqlDataAdapter(comando)

        'define o dataset
        Dim ds As DataSet = New DataSet()

        Try
            '---abre a conexao---
            conexao.Open()
            '---preenche o dataset---
            dataadapter.Fill(ds, Tabela)
            '---fecha a conexao---
            '---vincula o dataset ao DataGridView---
            DataGridView1.DataSource = ds           'ou ds.tables(0)
            '---define a tabela a ser exibida---
            DataGridView1.DataMember = Tabela

            conexao.Close()
            formatarGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormAluno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista", "Catequista")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim codigo As String
        If TabControl1.SelectedIndex = "0" Then
            Dim obj As Aluno = New Aluno

            codigo = DataGridView1.CurrentRow.Cells(0).Value
            If Not IsDBNull(codigo) Then
                If obj.Consultar(codigo) Then
                    tCodigo.Text = obj.Codigo
                    TNome.Text = obj.Nome
                    TEndereco.Text = obj.Endereco
                    tBairro.Text = obj.Bairro
                    Tcidade.Text = obj.Cidade
                    tNaturalidade.Text = obj.Naturalidade
                    tCep.Text = obj.CEP
                    tPai.Text = obj.Pai
                    tMae.Text = obj.Mae
                    
                End If
            Else
                formatarGrid()

            End If
        End If
        
    End Sub
End Class