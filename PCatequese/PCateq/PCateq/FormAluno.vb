Imports System.Data.SqlClient

Public Class FormAluno

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

    Private Sub FormAluno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista", "Catequista")
        'Dim obj As Aluno = New Aluno

        'DataGridView1.DataSource = obj.Todos()
        'formatarGrid()
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
                    TDataCad.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                    TDataNasc.Text = FormatDateTime(obj.DataNasc, DateFormat.ShortDate)
                    If obj.Batizado Then
                        RadioButton1.Checked = True
                    Else
                        RadioButton2.Checked = True
                    End If

                    Habilita()
                End If
            Else
                formatarGrid()
            End If
        End If

    End Sub

    Private Sub Desabilita()
        btnIncluir.Enabled = False
        btnExluir.Enabled = False
        btnConfirmar.Enabled = True
        BtnCancelar.Enabled = True
    End Sub
    Private Sub Habilita()
        btnIncluir.Enabled = True
        btnExluir.Enabled = True
        btnConfirmar.Enabled = False
        BtnCancelar.Enabled = False
    End Sub
    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        'Call Limpar(Me)
        Desabilita()
        incluindo = True
        TDataCad.Text = Date.Today.Date
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'Declarando e instanciando o obj da classe empresa
        Dim obj As Aluno = New Aluno

        Try

            obj.Nome = TNome.Text
            obj.Endereco = TEndereco.Text
            obj.Bairro = tBairro.Text
            obj.Cidade = Tcidade.Text
            obj.Naturalidade = tNaturalidade.Text
            obj.CEP = tCep.Text
            obj.Pai = tPai.Text
            obj.Mae = tMae.Text
            obj.Telefone = tTelefone.Text
            obj.UF = "MG"
            obj.DataCad = FormatDateTime(TDataCad.Text, DateFormat.ShortDate) 'Convert.ToDateTime(TDataCad.Text)
            obj.DataNasc = FormatDateTime(TDataNasc.Text, DateFormat.ShortDate) ' Convert.ToDateTime(TDataNasc.Text)
            If RadioButton1.Checked Then
                obj.Batizado = True
            Else
                obj.Batizado = False
            End If

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
            AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista", "Catequista")
            formatarGrid()
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub

    Private Sub TNome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNome.KeyPress
        Desabilita()
    End Sub

    Private Sub TEndereco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TEndereco.KeyPress
        Desabilita()
    End Sub

    Private Sub tBairro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBairro.KeyPress
        Desabilita()
    End Sub

    Private Sub Tcidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tcidade.KeyPress
        Desabilita()
    End Sub

    Private Sub tCep_TextChanged(sender As Object, e As EventArgs) Handles tCep.TextChanged
        Desabilita()
    End Sub

    Private Sub tNaturalidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tNaturalidade.KeyPress
        Desabilita()
    End Sub

    Private Sub tTelefone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tTelefone.KeyPress
        Desabilita()
    End Sub


    Private Sub tPai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPai.KeyPress
        Desabilita()
    End Sub

    Private Sub tMae_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tMae.KeyPress
        Desabilita()
    End Sub
    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        txtConsulta.Visible = True
        txtConsulta.Text = ""
        AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista", "Catequista")
    End Sub

    Private Sub txtConsulta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista WHERE NOME Like ('%" & txtConsulta.Text & "%') order by Nome,Codigo", "Catequista")
            txtConsulta.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tConsultaCodigo.Text = ""
        tConsultaCodigo.Visible = True
        AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista", "Catequista")
    End Sub

    Private Sub tConsultaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles tConsultaCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            AtulizarGrid("Select codigo,nome,Endereco,cidade From Catequista WHERE Codigo = '" & tConsultaCodigo.Text & "' order by Codigo ", "Catequista")
            tConsultaCodigo.Visible = False
        End If
    End Sub
End Class