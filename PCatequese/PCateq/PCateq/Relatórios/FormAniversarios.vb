Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormAniversarios

    Private Sub FormAniversarios_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
            FormTurmaConsulta.TPesquisa.Focus()

            TturmaCodigo.Text = FormTurmaConsulta.codigo
            TTurmaDescricao.Text = FormTurmaConsulta.Nome

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim status As String
            ' carrega o relatorio desejado
            Dim strReportName As String
            If TturmaCodigo.Text <> "" Then
                strReportName = "AniversariosPorTurma.rpt"
            Else
                strReportName = "Aniversarios.rpt"
            End If
            '
            'define o caminho e nome do relatorio
            Dim strReportPath As String = "C:\PROJETO\PCatequese\PCateq\PCateq\Relatórios\" & strReportName
            '
           
            'instancia o relaorio e carrega
            Dim CR As New ReportDocument
            CR.Load(strReportPath)
            '
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
            'crParameterFieldLocation = crParameterFieldDefinitions.Item("DataI")
            ' crParameterFieldLocation = crParameterFieldDefinitions.Item("DataF")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            'obtem o valor da caixa de texto
            crParameterDiscreteValue.Value = TturmaCodigo.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("DataI")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            crParameterDiscreteValue.Value = FormatDateTime(TDataI.Text, DateFormat.ShortDate) 'TDataI.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("DataF")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            crParameterDiscreteValue.Value = FormatDateTime(TDataF.Text, DateFormat.ShortDate) 'TDataF.Text
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            If CBStatus.SelectedItem = Nothing Then
                status = ""
            ElseIf CBStatus.SelectedItem = "Todos" Then
                status = ""
            Else
                status = CBStatus.SelectedItem
            End If
            crParameterFieldLocation = crParameterFieldDefinitions.Item("Status")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

            crParameterDiscreteValue.Value = status
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
            FormMostarRelatorio.Show()

        Catch ex As Exception
            MsgBox("Erro ao gerar relatório", MsgBoxStyle.Critical, "")
        End Try
       
    End Sub

    Private Sub TturmaCodigo_Leave(sender As Object, e As EventArgs) Handles TturmaCodigo.Leave
        If TturmaCodigo.Text = "" Then TTurmaDescricao.Text = ""
    End Sub
End Class