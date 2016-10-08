Imports System.Data.SqlClient

Public Class FormAluno

    Dim incluindo As Boolean

    Public Sub formatarGrid()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigo", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("nome", "Nome", "300"))
        DataGridView1.Columns.Add(CriarCampo("endereco", "Endereço", "185"))
        DataGridView1.Columns.Add(CriarCampo("telefone", "Telefone", "100"))

    End Sub
    Public Sub formatarGridTurma()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView2.AutoGenerateColumns = False
        DataGridView2.Columns.Clear()
        DataGridView2.Columns.Add(CriarCampo("codigoTurma", "Código Turma", "50"))
        'DataGridView2.Columns.Add(CriarCampo("codigoAluno", "Código aluno", "80"))
        DataGridView2.Columns.Add(CriarCampo("dataCad", "data", "100"))
        DataGridView2.Columns.Add(CriarCampo("Status", "Status", "120"))

        DataGridView2.Columns.Add(CriarCampo("QtdeAula", "Qtde Aulas", "50"))
        DataGridView2.Columns.Add(CriarCampo("QtdePresenca", "Presenças", "60"))
        DataGridView2.Columns.Add(CriarCampo("QtdeFalta", "Faltas", "50"))

    End Sub
    Public Sub mostarTodos()
        Dim obj As New Aluno
        DataGridView1.DataSource = obj.Todos()
        formatarGrid()
    End Sub
    Public Sub GridMatricula(ByVal codAluno As String)
        Try
            formatarGridTurma()

            Dim obj As New Matricula
            obj.CodigoAluno = codAluno

            DataGridView2.DataSource = obj.Consultar(obj.CodigoAluno)

        Catch ex As Exception
            MsgBox("Erro ao buscar matricula", MsgBoxStyle.Critical)
        End Try


    End Sub
    Private Sub FormAluno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = "1"
        mostarTodos()
        If tCodigo.Text <> "" Then
            BtnMatricula.Enabled = True
        End If
        Habilita()
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
                    RadioButton1.Checked = obj.Batizado
                    RadioButton2.Checked = Not obj.Batizado

                    Habilita()
                    BtnMatricula.Enabled = True
                    GridMatricula(codigo)
                End If
            Else
                'mostarTodos()
            End If
        Else
            'mostarTodos()
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
            obj.Batizado = RadioButton1.Checked

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
                Dim obj As New Aluno
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
                Dim obj As New Aluno
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
                    Dim obj As Aluno = New Aluno
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
            Dim obj As Aluno = New Aluno
           
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

    Private Sub BtnMatricula_Click(sender As Object, e As EventArgs) Handles BtnMatricula.Click
        If tCodigo.Text <> "" Then
            FormMatricula.tCodigo.Text = tCodigo.Text
            FormMatricula.tNome.Text = TNome.Text
            FormMatricula.ShowDialog()
        Else
            MsgBox("Incluir o Aluno antes de Matricular", MsgBoxStyle.Critical, "")
        End If
    End Sub
    

    Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView2.KeyDown
        Try
            Dim codigo As String = DataGridView2.CurrentRow.Cells(0).Value
            If e.KeyCode = Keys.F2 Then

                If codigo <> "" Then
                    Dim obj As Turma = New Turma
                    obj.Consultar(codigo)
                    FormMatricula.TturmaCodigo.Text = obj.Codigo
                    FormMatricula.TTurmaDescricao.Text = obj.Nome

                    Dim obj2 As Matricula = New Matricula
                    obj2.Consultar(codigo, tCodigo.Text)
                    'FormMatricula.TStatus.Text = obj2.Status

                    If obj2.Status = "Concluído" Then
                        FormMatricula.CBStatus.SelectedIndex = 0
                    ElseIf obj2.Status = "Cursando" Then
                        FormMatricula.CBStatus.SelectedIndex = 1
                    Else
                        FormMatricula.CBStatus.SelectedIndex = 2
                    End If

                    FormMatricula.TDataCad.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                    FormMatricula.tCodigo.Text = tCodigo.Text
                    FormMatricula.tNome.Text = TNome.Text
                    FormMatricula.incluindo = False
                    FormMatricula.codturmaCarregado = obj.Codigo
                    FormMatricula.ShowDialog()
                    GridMatricula(tCodigo.Text)
                End If
            End If
            If e.KeyCode = Keys.F5 Then
                If MsgBox("Deseja Excluir o Registro?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                    Dim obj As Matricula = New Matricula
                    obj.CodigoTurma = codigo
                    obj.CodigoAluno = tCodigo.Text
                    obj.Excluir()
                    GridMatricula(tCodigo.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao buscar matricula", MsgBoxStyle.Critical)
        End Try
        
    End Sub

    Private Sub FormAluno_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If tCodigo.Text <> "" Then
                If e.KeyCode = Keys.F1 Then

                    FormMatricula.tCodigo.Text = tCodigo.Text
                    FormMatricula.tNome.Text = TNome.Text
                    FormMatricula.CBStatus.SelectedIndex = 1
                    FormMatricula.TDataCad.Text = ""
                    FormMatricula.incluindo = True
                    FormMatricula.ShowDialog()

                    GridMatricula(tCodigo.Text)
                End If
            End If
            
           
        Catch ex As Exception
            MsgBox("Erro ao buscar matricula", MsgBoxStyle.Critical)
        End Try
    End Sub

    
End Class