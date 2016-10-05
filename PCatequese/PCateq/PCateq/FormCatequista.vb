Imports System.Data.SqlClient

Public Class FormCatequista
    Dim incluindo As Boolean
    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        Call Limpar(Me)
        Desabilita()
        incluindo = True
        TDataCad.Text = Date.Today.Date
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
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim codigo As String
        If TabControl1.SelectedIndex = "0" Then
            Dim obj As Catequista = New Catequista

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


    Public Sub formatarGrid()

        'Pegar os campos da classe (no dataReader), limpa a grid e na deixa ela gerar as colunas automotica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigo", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("nome", "Nome", "300"))
        DataGridView1.Columns.Add(CriarCampo("endereco", "Endereço", "185"))
        DataGridView1.Columns.Add(CriarCampo("telefone", "Telefone", "100"))


    End Sub


    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'Declarando e instanciando o obj da classe empresa
        Dim obj As Catequista = New Catequista

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

            If Not IsDBNull(TDataCad.Text) And TDataCad.Mask <> "00/00/0000" Then obj.DataCad = Convert.ToDateTime(TDataCad.Text)
            If Not IsDBNull(TDataNasc.Text) And TDataNasc.Mask <> "00/00/0000" Then obj.DataNasc = Convert.ToDateTime(TDataNasc.Text)
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
            
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub

    Private Sub FormCatequista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = "1"
        mostarTodos()
        Habilita()
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
        mostarTodos()
    End Sub

    Private Sub txtConsulta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim obj As New Catequista
                obj.Nome = txtConsulta.Text
                DataGridView1.DataSource = obj.TodosNomes()
            Catch ex As Exception
                MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
            End Try
            txtConsulta.Visible = False
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tConsultaCodigo.Text = ""
        tConsultaCodigo.Visible = True
        mostarTodos()
    End Sub

    Private Sub tConsultaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles tConsultaCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim obj As New Catequista
                obj.Codigo = tConsultaCodigo.Text
                DataGridView1.DataSource = obj.TodosCodigos()
            Catch ex As Exception
                MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
            End Try
            tConsultaCodigo.Visible = False
        End If
    End Sub

    
    Private Sub btnExluir_Click(sender As Object, e As EventArgs) Handles btnExluir.Click
        Try
            If Not incluindo Then
                If Not IsDBNull(tCodigo.Text) Then
                    Dim obj As Catequista = New Catequista
                    obj.Codigo = tCodigo.Text
                    obj.Excluir()
                    Call Limpar(Me)
                    Habilita()
                    MsgBox("Registro Excluído", MsgBoxStyle.Information, "")

                    mostarTodos()

                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao Excluir o registro.", MsgBoxStyle.Critical, "")
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            Dim obj As Catequista = New Catequista

            obj.Consultar(tCodigo.Text)
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

        Catch ex As Exception
            MsgBox("Erro ao Cancelar Operação", MsgBoxStyle.Critical, "Cancelando")
        End Try
    End Sub

    Private Sub TDataCad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TDataCad.KeyPress
        Desabilita()
    End Sub

    Private Sub TDataNasc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TDataNasc.KeyPress
        Desabilita()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        Desabilita()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        Desabilita()
    End Sub
   
    Public Sub mostarTodos()
        Dim obj As New Catequista
        DataGridView1.DataSource = obj.Todos()
        formatarGrid()
    End Sub

    
End Class