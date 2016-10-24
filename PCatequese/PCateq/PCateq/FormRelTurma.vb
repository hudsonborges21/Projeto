Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormRelTurma

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' carrega o relatorio desejado
        Dim strReportName As String
        strReportName = "ListadeTurma.rpt"

        'define o caminho e nome do relatorio
        Dim strReportPath As String = "C:\PROJETO\PCatequese\PCateq\PCateq\Relatórios\" & strReportName

        'verifiqa se o arquivo existe
        'If Not io.File.Exists(strReportPath) Then
        '    Throw (New Exception("Relatorio nao localizado :" & vbCrLf & strReportPath))
        'End If
        '
        'instancia o relaorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)
        '
        ' atribui os parametros declarados aos objetos relacionados
        'Dim crParameterDiscreteValue As ParameterDiscreteValue
        'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        'Dim crParameterFieldLocation As ParameterFieldDefinition
        'Dim crParameterValues As ParameterValues
        ''
        '' Pega a coleção de parametros do relatorio
        'crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
        ''
        '' define o primeiro parametro
        '' - pega o parametro e diz a ela para usar os valores atuais
        '' - define o valor do parametro
        '' - inclui e aplica o valor
        '' - repete para cada parametro se for o caso (não é o caso deste exemplo)
        '' Vamos usar o parametro 'cidade'
        'crParameterFieldLocation = crParameterFieldDefinitions.Item("PTurma")

        'crParameterValues = crParameterFieldLocation.CurrentValues
        'crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

        ''obtem o valor da caixa de texto
        'crParameterDiscreteValue.Value = TturmaCodigo.Text
        'crParameterValues.Add(crParameterDiscreteValue)
        'crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
        '
        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        'CrystalReportViewer1.ReportSource = CR

        FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
        FormMostarRelatorio.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' carrega o relatorio desejado
            Dim strReportName As String
            strReportName = "ListaDeAulasPorTurma.rpt"

            '
            'define o caminho e nome do relatorio
            Dim strReportPath As String = "C:\PROJETO\PCatequese\PCateq\PCateq\Relatórios\" & strReportName

           
            'instancia o relaorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)

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

            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            'obtem o valor da caixa de texto
            crParameterDiscreteValue.Value = TturmaCodigo.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
            FormMostarRelatorio.Show()

        Catch ex As Exception
            MsgBox("Erro ao gerar relatório", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnListaPresenca.Click
        Try
            ' carrega o relatorio desejado
            Dim strReportName As String

            If TturmaCodigo.Text <> "" Then
                strReportName = "AlunoPresenca.rpt"
            Else
                strReportName = "AlunoPresencaTodos.rpt"
            End If
            'define o caminho e nome do relatorio
            Dim strReportPath As String = "C:\PROJETO\PCatequese\PCateq\PCateq\Relatórios\" & strReportName


            'instancia o relaorio e carrega
            Dim CR As New ReportDocument

            CR.Load(strReportPath)

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

            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            'obtem o valor da caixa de texto
            crParameterDiscreteValue.Value = TturmaCodigo.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
            FormMostarRelatorio.Show()

        Catch ex As Exception
            MsgBox("Erro ao gerar relatório", MsgBoxStyle.Critical, "")
        End Try
    End Sub

    Private Sub FormRelTurma_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
            FormTurmaConsulta.TPesquisa.Focus()

            TturmaCodigo.Text = FormTurmaConsulta.codigo
            TTurmaDescricao.Text = FormTurmaConsulta.Nome

        End If
    End Sub
End Class