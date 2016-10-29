Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormRelListaAlunos

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        'criar instancia de Document
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
        'define um stream
        Dim arquivo As FileStream = New FileStream("C:\Projeto\ListaDeAluno.PDF", FileMode.Create)
        'definir um objeto pdfwriter
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, arquivo)
        doc.Open()

        Dim fonte1 As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, Font.Bold, BaseColor.BLACK)

        'criar um paragrafor
        Dim para1 As New Paragraph("L I S T A   D E     A L U N O S", fonte1)
        para1.Alignment = Element.ALIGN_CENTER
        doc.Add(para1)

        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(" "))

        Dim para2 As New Paragraph(Now.Day.ToString() & " / " & Now.Month.ToString() & "/ " & Now.Year.ToString())
        para2.Alignment = Element.ALIGN_LEFT
        doc.Add(para2)

        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph("Alunos"))
        'Dim frase As New Phrase("Código         Nome                        Endereco            Telefone")
        'doc.Add(frase)
        doc.Add(New Paragraph("Código         Nome                        Endereco            Telefone"))

        Dim aluno As New Aluno
        For Each al As Aluno In aluno.Todos()
            doc.Add(New Paragraph(al.Codigo & "             " & al.Nome & "                   " & al.Endereco & "                  " & al.Telefone))
        Next

        doc.Add(New Paragraph(" "))


        doc.Close()
        arquivo.Close()

        Process.Start("C:\Projeto\ListaDeAluno.PDF")
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'criar instancia de Document
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
        'define um stream
        Dim arquivo As FileStream = New FileStream("C:\Projeto\ListaDeAluno.PDF", FileMode.Create)
        'definir um objeto pdfwriter
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, arquivo)
        doc.Open()

        Dim fonte1 As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, Font.Bold, BaseColor.BLACK)

        Dim tableCab As New PdfPTable(1)

        Dim header As New PdfPCell(New Phrase("L I S T A     D E     A L U N O S"))
        header.Colspan = 4
        header.HorizontalAlignment = Element.ALIGN_CENTER
        tableCab.AddCell(header)

        Dim header2 As New PdfPCell(New Phrase("Data em: " + Now.Day.ToString() & " / " & Now.Month.ToString() & "/ " & Now.Year.ToString()))
        header2.Colspan = 4
        header2.HorizontalAlignment = Element.ALIGN_LEFT
        tableCab.AddCell(header2)
        doc.Add(tableCab)

        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(" "))

        Dim table As New PdfPTable(3)
        Dim intTblWidth() As Integer = {15, 50, 50}

        table.SetWidths(intTblWidth)
        table.AddCell("Codigo")
        table.AddCell("Nome")
        table.AddCell("Endereço")

        Dim aluno As New Aluno
        For Each al As Aluno In aluno.Todos()
            table.AddCell(al.Codigo)
            table.AddCell(al.Nome)
            table.AddCell(al.Endereco)
            'table.AddCell(al.Cidade)
        Next

        doc.Add(table)

        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(" "))

        doc.Close()
        arquivo.Close()

        Process.Start("C:\Projeto\ListaDeAluno.PDF")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'criar instancia de Document
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
        'define um stream
        Dim arquivo As FileStream = New FileStream("C:\Projeto\AlunosTurma.PDF", FileMode.Create)
        'definir um objeto pdfwriter
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, arquivo)
        doc.Open()

        Dim fonte1 As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, Font.Bold, BaseColor.BLACK)

        Dim tableCab As New PdfPTable(1)

        Dim header As New PdfPCell(New Phrase("L I S T A     D E     A L U N O S"))
        header.Colspan = 4
        header.HorizontalAlignment = Element.ALIGN_CENTER
        tableCab.AddCell(header)

        header = New PdfPCell(New Phrase("AGRUPADO POR TURMAS"))
        header.Colspan = 4
        header.HorizontalAlignment = Element.ALIGN_CENTER
        tableCab.AddCell(header)

        Dim header2 As New PdfPCell(New Phrase("Data em: " + Now.Day.ToString() & " / " & Now.Month.ToString() & "/ " & Now.Year.ToString()))
        header2.Colspan = 4
        header2.HorizontalAlignment = Element.ALIGN_LEFT
        tableCab.AddCell(header2)
        doc.Add(tableCab)

        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(" "))

        Dim tableTurma As New PdfPTable(2)
        Dim TurmaintTblWidth() As Integer = {15, 50}
        tableTurma.SetWidths(TurmaintTblWidth)

        Dim tableTurma2 As New PdfPTable(2)
        Dim TurmaintTblWidth2() As Integer = {15, 50}
        tableTurma2.SetWidths(TurmaintTblWidth2)

        Dim turma As New Turma
        For Each tm As Turma In turma.Todos()
            Dim mat As Matricula = New Matricula ' cria objt mat da classe matricula, pegar os alunos matriculados da turma, add eles na lista


            tableTurma.AddCell("Codigo")
            tableTurma.AddCell("Turma")
            doc.Add(tableTurma)
            doc.Add(New Paragraph(" "))


            tableTurma2.AddCell(tm.Codigo)
            tableTurma2.AddCell(tm.Nome)
            doc.Add(tableTurma2)
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph(" "))

            mat.CodigoTurma = tm.Codigo

            'For Each matr As Matricula In mat.TodosAlunosTurma() 'metodo TodosAlunosTurma() é uma lista de objetos 
            '    Dim table As New PdfPTable(3)
            '    Dim intTblWidth() As Integer = {15, 50, 50}
            '    table.SetWidths(intTblWidth)
            '    table.AddCell("Codigo")
            '    table.AddCell("Nome")
            '    table.AddCell("Endereço")

            '    Dim aluno As New Aluno
            '    aluno.Codigo = matr.CodigoAluno
            '    aluno.Consultar(aluno.Codigo)

            '    table.AddCell(aluno.Codigo)
            '    table.AddCell(aluno.Nome)
            '    table.AddCell(aluno.Endereco)
            '    doc.Add(table)
            'Next

        Next




        doc.Add(New Paragraph(" "))

        doc.Close()
        arquivo.Close()

        Process.Start("C:\Projeto\AlunosTurma.PDF")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' carrega o relatorio desejado
        Dim strReportName As String
        If TturmaCodigo.Text <> "" Then
            strReportName = "TurmaAluno.rpt"
        Else
            strReportName = "TurmaAlunoTodos.rpt"
        End If
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

        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

        'obtem o valor da caixa de texto
        crParameterDiscreteValue.Value = TturmaCodigo.Text
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
        '
        ' Define a fonte do controle Crystal Report Viewer como sendo o relatorio definido acima
        'CrystalReportViewer1.ReportSource = CR

        FormMostarRelatorio.CrystalReportViewer1.ReportSource = CR
        FormMostarRelatorio.Show()
    End Sub

    Private Sub FormRelListaAlunos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormTurmaConsulta.ShowDialog()
            FormTurmaConsulta.TPesquisa.Focus()

            TturmaCodigo.Text = FormTurmaConsulta.codigo
            TTurmaDescricao.Text = FormTurmaConsulta.Nome

        End If
    End Sub

    Private Sub TturmaCodigo_Leave(sender As Object, e As EventArgs) Handles TturmaCodigo.Leave
        If TturmaCodigo.Text = "" Then TTurmaDescricao.Text = ""
    End Sub
End Class

