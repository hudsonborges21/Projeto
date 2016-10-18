Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class FormRelListaAlunos

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'criar instancia de Document
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
        'define um stream
        Dim arquivo As FileStream = New FileStream("C:\Projeto\ListaDeAluno.PDF", FileMode.Create)
        'definir um objeto pdfwriter
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, arquivo)
        doc.Open()

        Dim fonte1 As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, Font.Bold, BaseColor.BLACK)

        Dim tableCab As New PdfPTable(1)

        'pdfTable.DefaultCell.Padding = 3
        'pdfTable.WidthPercentage = 300
        'pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        'pdfTable.DefaultCell.BorderWidth = 1


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

        Dim table As New PdfPTable(4)
        Dim cell = New PdfPCell(New Phrase("Código"))
        cell.Width = 50
        cell.Colspan = 3
        table.AddCell(cell)
        'table.AddCell("Código")
        table.AddCell("Nome")
        table.AddCell("Endereco")
        table.AddCell("Cidade")

        Dim aluno As New Aluno
        For Each al As Aluno In aluno.Todos()
            table.AddCell(al.Codigo)
            table.AddCell(al.Nome)
            table.AddCell(al.Endereco)
            table.AddCell(al.Cidade)
        Next

        doc.Add(table)


        doc.Add(New Paragraph(" "))
        doc.Add(New Paragraph(" "))


        doc.Close()
        arquivo.Close()

        'Process.Start("C:\Projeto\ListaDeAluno.PDF")
    End Sub
End Class

