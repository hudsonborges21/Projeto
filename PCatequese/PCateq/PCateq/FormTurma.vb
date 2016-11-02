Imports System.Data.SqlClient

Public Class FormTurma
    Dim incluindo As Boolean

    Public Sub formatarGrid()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("Codigo", "Código Turma", "80"))
        DataGridView1.Columns.Add(CriarCampo("Nome", "Turma", "230"))
        DataGridView1.Columns.Add(CriarCampo("AnoINI", "Ano Inicio", "80"))
        DataGridView1.Columns.Add(CriarCampo("AnoFim", "Ano Fim", "80"))
        DataGridView1.Columns.Add(CriarCampo("Curso", "Curso", "165"))
    End Sub

    Public Sub formatarGridAula()
        DataGridView2.AutoGenerateColumns = False
        DataGridView2.Columns.Clear()
        'DataGridView2.Columns.Add(CriarCampo("codigoTurma", "Código Turma"))
        DataGridView2.Columns.Add(CriarCampo("codigoAula", "Código Aula", "80"))
        DataGridView2.Columns.Add(CriarCampo("Descricao", "Descrição", "445"))
        DataGridView2.Columns.Add(CriarCampo("DataCad", "Data", "100"))

        QtdeAulas() 'rotina para somar quantidade de aulas da turma
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
        Call Limpar(Me)
        Desabilita()
        incluindo = True
        tcurso.Focus()
    End Sub

    Private Sub FormTurma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = "1"
        Habilita()
        mostarTurmas()
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim codigo As String
        If TabControl1.SelectedIndex = "0" Then
            Dim obj As Turma = New Turma 'cria objeto turma

            codigo = DataGridView1.CurrentRow.Cells(0).Value
            If Not IsDBNull(codigo) Then

                If obj.Consultar(codigo) Then 'consulta dados
                    tCodigo.Text = obj.Codigo
                    TData.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                    tcurso.Text = obj.Curso
                    tAnoFim.Text = obj.AnoFim
                    TAnoINI.Text = obj.AnoIni
                    tDescricao.Text = obj.Nome
                    TCatequistaCodigo.Text = obj.CatequistaCodigo

                    Dim obj2 As Catequista = New Catequista 'cria objeto catquista
                    If obj2.Consultar(obj.CatequistaCodigo) Then 'busca dados do professor catequista
                        TCatequistaNome.Text = obj2.Nome
                    End If
                    Habilita()
                    GridAula(codigo) 'busca aulas da turma
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
                    Dim obj As Turma = New Turma 'cria objeto
                    obj.Codigo = tCodigo.Text
                    obj.Excluir() 'exluir
                    Call Limpar(Me)
                    Habilita()
                    MsgBox("Registro Excluído", MsgBoxStyle.Information, "")

                    mostarTurmas()

                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao Excluir o registro.", MsgBoxStyle.Critical, "")
        End Try
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        Try
            Dim obj As Turma = New Turma
            obj.Nome = tDescricao.Text
            obj.AnoIni = TAnoINI.Text
            obj.AnoFim = tAnoFim.Text
            obj.Curso = tcurso.Text
            obj.DataCad = FormatDateTime(TData.Text, DateFormat.ShortDate)
            obj.CatequistaCodigo = TCatequistaCodigo.Text
            obj.CodigoInst = 1

            If Not incluindo Then
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Codigo = tCodigo.Text
                obj.Alterar()   'alterar dados
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
                incluindo = False
            Else
                'chamando o metodo da classe responsavel por incluir os dados 
                obj.Incluir()   'incluir turma
                obj.UltimoCodigo()
                tCodigo.Text = obj.Codigo
                GridAula(tCodigo.Text)
                MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")

                incluindo = False
            End If

            formatarGrid()
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao salvar, Por favor verificar os dados informado.", MsgBoxStyle.ApplicationModal, "")
        End Try
    End Sub

    Private Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        mostarTurmas() 'dados da turmas
        txtConsulta.Visible = True
        txtConsulta.Text = ""
        txtConsulta.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mostarTurmas()
        tConsultaCodigo.Text = ""
        tConsultaCodigo.Visible = True
        tConsultaCodigo.Focus()
    End Sub

    Private Sub txtConsulta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim obj As New Turma
                obj.Nome = txtConsulta.Text
                DataGridView1.DataSource = obj.ConsultarNome() 'consultar turmas por nome
            Catch ex As Exception
                MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
            End Try
            txtConsulta.Visible = False
        End If
    End Sub

    Private Sub tConsultaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles tConsultaCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim obj As New Turma
                obj.Codigo = tConsultaCodigo.Text
                DataGridView1.DataSource = obj.ConsultarCodigos() 'consultar turmas por codigo
            Catch ex As Exception
                MsgBox("Erro ao realizar consulta", MsgBoxStyle.Critical, "")
            End Try
            tConsultaCodigo.Visible = False
        End If
    End Sub

    Public Sub mostarTurmas()
        Dim obj As New Turma
        DataGridView1.DataSource = obj.Todos()
        formatarGrid()
    End Sub

    Private Sub FormTurma_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            If tCodigo.Text <> "" Or incluindo Then
                Desabilita()
                FormCatequistaConsulta.TPesquisa.Focus()
                FormCatequistaConsulta.ShowDialog() 'chama formu de consulta professor
            End If
            TCatequistaCodigo.Focus()

        End If
        If e.KeyCode = Keys.F2 Then '*******    CADASTRAR AULA
            If tCodigo.Text <> "" Then
                FormAula.tCodigo.Text = tCodigo.Text
                FormAula.tDescricao.Text = tDescricao.Text
                FormAula.TAulaDescricao.Focus()
                FormAula.incluindo = True
                FormAula.ShowDialog() 'chama formulario de aula
                GridAula(tCodigo.Text)
            End If
        End If
        If e.KeyCode = Keys.F3 Then
            If tCodigo.Text <> "" Then
                'Dim codigo As String = DataGridView2.CurrentRow.Cells(2).Value
                Dim codigo As String = DataGridView2.CurrentRow.Cells(0).Value

                FormAula.tCodigo.Text = tCodigo.Text
                FormAula.tDescricao.Text = tDescricao.Text

                Dim obj As New Aula 'CRIA OBJETO DA AULA
                obj.CodigoAula = codigo
                obj.Consultar() 'busca dados

                FormAula.TAulaCodigo.Text = obj.CodigoAula
                FormAula.TAulaDescricao.Text = obj.Descricao
                FormAula.TAulaData.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                FormAula.TAulaDescricao.Focus()
                FormAula.incluindo = False
                FormAula.ShowDialog() 'CHAMA FORMULARIO DE AULA
                GridAula(tCodigo.Text)
            End If
        End If
        If e.KeyCode = Keys.F4 Then '*********** EXCLUIR AULA
            If tCodigo.Text <> "" Then
                If MsgBox("Ao Exluir Aula será exluido as presenças lançadas.  Deseja Realmente Exlcuir o Registro?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim codigo As String = DataGridView2.CurrentRow.Cells(0).Value
                    Dim obj As New Aula

                    obj.CodigoAula = codigo
                    obj.Consultar()

                    'Exlcuindo Frequencia
                    obj.ExcluirFrequencia()

                    'Excluindo AULA
                    obj.Excluir()
                End If
                GridAula(tCodigo.Text)
            End If
        End If
        If e.KeyCode = Keys.F5 Then '******* CHAMA O FORM DE FREQUENCIA
            If tCodigo.Text <> "" Then

                Dim codigo As String = DataGridView2.CurrentRow.Cells(0).Value
                'Dados da turma pelo textbox
                FormFrequencia.tCodigo.Text = tCodigo.Text
                FormFrequencia.tDescricao.Text = tDescricao.Text

                'data da aula pelo objeto
                Dim obj As New Aula
                obj.CodigoAula = codigo
                obj.Consultar()
                FormFrequencia.TAulaCodigo.Text = obj.CodigoAula
                FormFrequencia.TAulaDescricao.Text = obj.Descricao
                FormFrequencia.TAulaData.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
                FormFrequencia.ShowDialog()

            End If
        End If
    End Sub
    Public Sub GridAula(ByVal codTurma As String)
        Try
            Dim obj As New Aula
            obj.CodigoTurma = codTurma
            DataGridView2.DataSource = obj.ConsultarTurmaAula(obj.CodigoTurma)
            formatarGridAula()
        Catch ex As Exception
            MsgBox("Erro ao buscar matricula", MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Dim obj As Turma = New Turma

        obj.Codigo = tCodigo.Text
        If obj.Consultar(obj.Codigo) Then
            tCodigo.Text = obj.Codigo
            tData.Text = FormatDateTime(obj.DataCad, DateFormat.ShortDate)
            tcurso.Text = obj.Curso
            tAnoFim.Text = obj.AnoFim
            TAnoINI.Text = obj.AnoIni
            tDescricao.Text = obj.Nome
            TCatequistaCodigo.Text = obj.CatequistaCodigo

            Dim obj2 As Catequista = New Catequista
            If obj2.Consultar(obj.CatequistaCodigo) Then
                TCatequistaNome.Text = obj2.Nome
            End If
            Habilita()

        End If
    End Sub
    Private Sub QtdeAulas() 'CONTADOR DE AULAS
        Dim qtde As Integer
        qtde = 0
        For i = 0 To DataGridView2.RowCount - 1
            qtde = qtde + 1
        Next
        TQtdeAulas.Text = qtde
    End Sub
End Class