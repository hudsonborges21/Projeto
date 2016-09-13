Imports System.Data.SqlClient

Public Class FormTurma
    Dim incluindo As Boolean

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
    Private Sub Desabilita()
        BtNIncluir.Enabled = False
        btnExluir.Enabled = False
        BtnConfirmar.Enabled = True
        BtnCancelar.Enabled = True
    End Sub
    Private Sub Habilita()
        BtNIncluir.Enabled = True
        btnExluir.Enabled = True
        BtnConfirmar.Enabled = False
        BtnCancelar.Enabled = False
    End Sub


    Private Sub BtNIncluir_Click(sender As Object, e As EventArgs) Handles BtNIncluir.Click
        'Call Limpar(Me)
        Desabilita()
        incluindo = True
    End Sub

    Private Sub FormTurma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AtulizarGrid("Select codigo,nome,anoini,anofim From Turma", "Turma")
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim codigo As String
        If TabControl1.SelectedIndex = "0" Then
            Dim obj As Turma = New Turma

            codigo = DataGridView1.CurrentRow.Cells(0).Value
            If Not IsDBNull(codigo) Then

                If obj.Consultar(codigo) Then
                    tCodigo.Text = obj.Codigo
                    tData.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                    tcurso.Text = obj.Curso
                    tAnoFim.Text = obj.AnoFim
                    TAnoINI.Text = obj.AnoIni
                    tDescricao.Text = obj.Nome

                    Dim obj2 As Catequista = New Catequista
                    If obj2.Consultar(obj.CatequistaCodigo) Then
                        TCatequistaNome.Text = obj2.Nome
                    End If
                    Habilita()
                End If
            Else
                formatarGrid()
            End If
        End If

    End Sub

    Private Sub btnExluir_Click(sender As Object, e As EventArgs) Handles btnExluir.Click
        Try
            If Not incluindo Then
                If Not IsDBNull(tCodigo.Text) Then
                    Dim obj As Turma = New Turma
                    obj.Codigo = tCodigo.Text
                    obj.Excluir()
                    Call Limpar(Me)
                    Habilita()
                    MsgBox("Registro Excluído", MsgBoxStyle.Information, "")

                    AtulizarGrid("Select codigo,nome,anoini,anofim From Turma", "Turma")

                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao Excluir o registro.", MsgBoxStyle.Critical, "")
        End Try
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        'Declarando e instanciando o obj da classe empresa
        Dim obj As Turma = New Turma

        Try

            obj.Nome = tDescricao.Text
            obj.AnoIni = TAnoINI.Text
            obj.AnoFim = tAnoFim.Text
            obj.Curso = tcurso.Text
            obj.DataCad = FormatDateTime(tData.Text, DateFormat.ShortDate)


            If Not incluindo Then
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Codigo = tCodigo.Text
                obj.Alterar()
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
                incluindo = False
            Else

                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Incluir()
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If
            AtulizarGrid("Select codigo,nome,anoini,anofim From Turma", "Turma")
            formatarGrid()
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub
End Class