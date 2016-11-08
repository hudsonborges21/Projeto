Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormFrequencia
    Public Sub formatarGrid()

        'define e realiza a formatação de cada coluna
        'Pegar os campos da classe (atributos), limpa a grid e na deixa ela gerar as colunas automatica
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(CriarCampo("codigoAluno", "Código", "50"))
        DataGridView1.Columns.Add(CriarCampo("Aluno", "Aluno", "400"))
        DataGridView1.Columns.Add(CriarCampoCheck("Presenca", "Presença", "90"))

    End Sub
    Public Sub mostarTodos()
        Dim obj As New Aula
        obj.CodigoTurma = tCodigo.Text
        obj.CodigoAula = TAulaCodigo.Text
        DataGridView1.DataSource = obj.TodosAlunosTurma()
        formatarGrid()
    End Sub

    Private Sub FormFrequencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mostarTodos()
        Catch ex As Exception
            MsgBox("Erro ao carregar Dados", MsgBoxStyle.Critical, "")
        End Try

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim obj As Aula = New Aula
            Dim codAluno As Integer
            Dim presenca As Boolean

            For i = 0 To DataGridView1.Rows.Count - 1
                'MsgBox(DataGridView1.Rows.Item(i).Cells(2).Value)
                codAluno = DataGridView1.Rows.Item(i).Cells(0).Value
                presenca = DataGridView1.Rows.Item(i).Cells(2).Value
                obj.CodigoAula = TAulaCodigo.Text
                obj.CodigoAluno = codAluno
                obj.Presenca = presenca
                obj.AlterarFrequencia()
            Next
            MsgBox("Registro salvo com sucesso.", MsgBoxStyle.Information, "")
            Habilita()
        Catch ex As Exception
            MsgBox("Erro ao gravar Dados", MsgBoxStyle.Critical, "")
        End Try

    End Sub
    Private Sub Desabilita()
        btnConfirmar.Enabled = True
        BtnCancelar.Enabled = True
    End Sub
    Private Sub Habilita()
        btnConfirmar.Enabled = False
        BtnCancelar.Enabled = False
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Desabilita()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' carrega o relatorio desejado
            Dim strReportName As String

            strReportName = "TurmaAulaPresenca.rpt"

            '
            'define o caminho e nome do relatorio
            Dim strReportPath As String = "C:\PROJETO\PCatequese\PCateq\PCateq\Relatórios\" & strReportName
            '
            'verifiqa se o arquivo existe
            'If Not io.File.Exists(strReportPath) Then
            '    Throw (New Exception("Relatorio nao localizado :" & vbCrLf & strReportPath))
            'End If
            '
            'instancia o relaorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            CR.SetDatabaseLogon("sa", "123") '* Passando Usuario,senha para nao pedir no relatorio, usando assim provisoro
            ' atribui os parametros declarados aos objetos relacionados
            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues
            '
            ' Pega a coleção de parametros do relatorio
            crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
            '
            ' define o primeiro parametro
            ' - pega o parametro e diz a ela para usar os valores atuais
            ' - define o valor do parametro
            ' - inclui e aplica o valor
            ' - repete para cada parametro se for o caso (não é o caso deste exemplo)
            ' Vamos usar o parametro 'cidade'
            crParameterFieldLocation = crParameterFieldDefinitions.Item("PTurma")
            crParameterFieldLocation = crParameterFieldDefinitions.Item("PAula")

            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            'obtem o valor da caixa de texto
            crParameterDiscreteValue.Value = tCodigo.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = TAulaCodigo.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
            FormMostarRelatorio.Show()
        Catch ex As Exception
            MsgBox("Erro ao gerar relatório", MsgBoxStyle.Critical, "")
        End Try
    End Sub
End Class