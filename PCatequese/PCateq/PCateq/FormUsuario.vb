Imports System.Text
Imports System.Security.Cryptography

Public Class FormUsuario
    Dim incluindo As Boolean
    Dim ultCodigo As String
    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        ultCodigo = tCodigo.Text
        Call Limpar(Me)
        Desabilita()
        incluindo = True
        TDataCad.Text = Date.Today.Date
    End Sub

    Private Sub btnExluir_Click(sender As Object, e As EventArgs) Handles btnExluir.Click
        Try
            If Not incluindo Then
                If Not IsDBNull(tCodigo.Text) Then
                    Dim obj As Usuario = New Usuario 'cria objeto
                    obj.Codigo = tCodigo.Text
                    obj.Excluir()   'exluir
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

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        'Declarando e instanciando o obj da classe empresa
        Dim obj As Usuario = New Usuario 'cria objeto

        Try

            obj.Nome = TNome.Text

            Dim cifrado As New clsCrypto() 'usa esta classe, para criar a criptografia da senha
            obj.Senha = cifrado.clsCrypto(tsenha.Text, True) 'criptografa senha

            If Not IsDBNull(TDataCad.Text) And TDataCad.Mask <> "00/00/0000" Then obj.DataCad = Convert.ToDateTime(TDataCad.Text)

            If Not incluindo Then
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Codigo = tCodigo.Text
                obj.Alterar()
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
                incluindo = False
            Else

                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Incluir()
                obj.UltimoCodigo()
                tCodigo.Text = obj.Codigo

                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If

            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            Dim obj As Usuario = New Usuario 'cria objeto

            If incluindo Then tCodigo.Text = ultCodigo

            obj.Consultar(tCodigo.Text) 'consulta os dados do usuario
            tCodigo.Text = obj.Codigo
            TNome.Text = obj.Nome
            TDataCad.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
            Habilita()

        Catch ex As Exception
            MsgBox("Erro ao Cancelar Operação", MsgBoxStyle.Critical, "Cancelando")
        End Try
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
            Dim obj As Usuario = New Usuario    'cria objeto

            codigo = DataGridView1.CurrentRow.Cells(0).Value 'pega codigo da gridview
            If Not IsDBNull(codigo) Then

                If obj.Consultar(codigo) Then 'consulta dados
                    tCodigo.Text = obj.Codigo
                    TNome.Text = obj.Nome
                    tsenha.Text = obj.Senha
                    TDataCad.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                    Habilita()
                End If
            Else
                formatarGrid()
            End If
        Else
            mostarTodos()
        End If
    End Sub
    Public Sub mostarTodos()
        Dim obj As New Usuario
        DataGridView1.DataSource = obj.Todos()
        formatarGrid()
    End Sub
    Public Sub formatarGrid()

        'pega o Atributo emcapsulado... e jogo na grid
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigo", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("nome", "Nome", "500"))

    End Sub

    Private Sub FormUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = "1"
        mostarTodos()
        Habilita()
    End Sub

    Private Sub tCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCodigo.KeyPress
        Desabilita()
    End Sub

    Private Sub TDataCad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TDataCad.KeyPress
        Desabilita()
    End Sub

    Private Sub TNome_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNome.KeyPress
        Desabilita()
    End Sub

    Private Sub tsenha_KeyPress(sender As Object, e As KeyPressEventArgs)
        Desabilita()
    End Sub
    Private Sub tsenha_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles tsenha.KeyPress
        Desabilita()
    End Sub
End Class