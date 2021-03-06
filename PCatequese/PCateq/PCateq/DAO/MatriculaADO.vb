﻿Imports System.Text
Imports System.Data.SqlClient

Public Class MatriculaADO
#Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder
        sql.AppendLine("Insert Into MATRICULA ")
        sql.AppendLine(" ( CodigoTurma, CodigoAluno,data, status) ")
        sql.AppendLine("values (@CodigoTurma, @CodigoAluno, @data, @status )")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlUpdate(ByVal pCodTurma As Integer, ByVal pCodAluno As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Matricula Set ")
        sql.AppendLine(" CodigoTurma=@CodigoTurma, CodigoAluno=@CodigoAluno,data=@data, ")
        sql.AppendLine(" status=@status ")
        sql.AppendLine(" where CodigoTurma='" & pCodTurma & "' and codigoAluno ='" & pCodAluno & "'")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From Matricula  ")
        Return sql.ToString()
    End Function
    
    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal turma As Matricula, ByVal incluindo As Boolean)
        'If Not incluindo Then
        '    comando.Parameters.Add("@CodigoTurma", SqlDbType.VarChar).Value = turma.CodigoTurma
        'End If
        comando.Parameters.Add("@CodigoTurma", SqlDbType.VarChar).Value = turma.CodigoTurma
        comando.Parameters.Add("@CodigoAluno", SqlDbType.VarChar).Value = turma.CodigoAluno
        comando.Parameters.Add("@Status", SqlDbType.VarChar).Value = turma.Status
        comando.Parameters.Add("@Data", SqlDbType.Date).Value = turma.DataCad

    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef turma As Matricula)
        turma.CodigoTurma = reader("CodigoTurma")
        turma.CodigoAluno = reader("CodigoAluno")
        If Not IsDBNull(reader("Status")) Then turma.Status = (reader("Status"))
        If Not IsDBNull(reader("Data")) Then turma.DataCad = reader("Data")

        turma.ConsultarQtdeAula(turma.CodigoTurma)
        turma.ConsultarQtdePresenca(turma.CodigoTurma, turma.CodigoAluno)
        turma.ConsultarQtdeFaltas(turma.CodigoTurma, turma.CodigoAluno)

        turma.MediaFrequencia = Format((turma.QtdePresenca / turma.QtdeAula) * 100, "0.00")

    End Sub
    Private Shared Sub PopularObjetoAula(ByVal reader As IDataRecord, ByRef turma As Matricula)
        turma.QtdeAula = reader("QtdeAula")
    End Sub
    Private Shared Sub PopularObjetoPresenca(ByVal reader As IDataRecord, ByRef turma As Matricula)
        turma.QtdePresenca = reader("QtdePresenca")
    End Sub
    Private Shared Sub PopularObjetoFalta(ByVal reader As IDataRecord, ByRef turma As Matricula)
        turma.Qtdefalta = reader("QtdeFaltas")
    End Sub
    'METODO INCLUIR 
    Public Sub Incluir(ByVal turma As Matricula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, turma, True)
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Matricula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Matricula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo()
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Matricula
                        PopularObjeto(dataReader, turma)
                        lista.Add(turma) ' add o objeto
                    End While
                    conexao.Close()
                    Return lista
                Else
                    conexao.Close()
                    Return Nothing
                End If
            End Using
        End Using
    End Function
    Public Function Consultar(ByVal codigolinha As Integer) As List(Of Matricula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Matricula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where CodigoAluno = " & codigolinha & "Order By codigoTurma desc"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Matricula
                        PopularObjeto(dataReader, turma)
                        lista.Add(turma) ' add o objeto
                    End While
                    conexao.Close()
                    Return lista
                Else
                    conexao.Close()
                    Return Nothing
                End If
            End Using
        End Using
    End Function
    Public Function TodosAlunosTurma(ByVal codigolinha As Integer) As List(Of Matricula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Matricula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigoturma = " & codigolinha
            'sql = "Select Matricula.codigoTurma,Matricula.CodigoAluno, Matricula.Data, Matricula.Status " & _
            '        " From Matricula inner join Aluno on Aluno.codigo = Matricula.codigoAluno where Codigoturma = " & codigolinha & " Order by Aluno.nome"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Matricula
                        PopularObjeto(dataReader, turma)
                        lista.Add(turma) ' add o objeto
                    End While
                    conexao.Close()
                    Return lista
                Else
                    conexao.Close()
                    Return Nothing
                End If
            End Using
        End Using
    End Function
    'CONSULTAR 
    Public Function Consultar(ByVal codigolinha As Integer, ByVal codigoAluno As Integer, ByRef turma As Matricula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where CodigoTurma = " & codigolinha & " and codigoAluno = " & codigoAluno
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjeto(dataReader, turma)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
   
    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal pcod As String, ByVal turma As Matricula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(pcod, turma.CodigoAluno), conexao)
                PopularComando(comando, turma, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal turma As Matricula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM MATRICULA WHERE codigoTurma = " & turma.CodigoTurma & " and codigoAluno=" & turma.CodigoAluno
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@CodigoTurma", SqlDbType.VarChar).Value = turma.CodigoTurma
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub


    Public Function ConsultarQtdeAula(ByVal codigoTurma As Integer, ByVal turma As Matricula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String

            '**** tabela AULA
            'Conta as aulas lanças na tabela Aula referente a turma
            'sql = "select count(codigoAula) as qtdeAula from aula where CodigoTurma=" & codigoTurma

            '**** tabela FREQUENCIA
            'Conta as aulas lanças na tabela Frequencia
            sql = "select COUNT( distinct Frequencia.codigoAula) as qtdeAula from Frequencia " & _
            "inner join Aula on Aula.CodigoAula = Frequencia.codigoAula " & _
            "inner join turma on Aula.CodigoTurma =  Turma.Codigo  " & _
            " where turma.Codigo = " & codigoTurma & " And Aula.CodigoTurma = " & codigoTurma

            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoAula(dataReader, turma) 'popular o obj como aula
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function

    Public Function ConsultarQtdePresenca(ByVal codigoTurma As Integer, ByVal codigoAluno As Integer, ByVal turma As Matricula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            'sql = "select count(codigoAula) as qtdeAula from aula where CodigoTurma=" & codigoTurma
            sql = "select count(*) as QtdePresenca from Frequencia " & _
            "inner join Aula on Aula.CodigoAula = Frequencia.codigoAula " & _
            " inner join turma on Aula.CodigoTurma =  Turma.Codigo " & _
            " where turma.Codigo = " & codigoTurma & " And codigoAluno = " & codigoAluno & " And Presenca = 1" '1-> true, verdadeiro 

            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoPresenca(dataReader, turma) 'popular o objeto com soma das presenças
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Public Function ConsultarQtdeFaltas(ByVal codigoTurma As Integer, ByVal codigoAluno As Integer, ByVal turma As Matricula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String

            sql = "select count(*) as QtdeFaltas from Frequencia " & _
            "inner join Aula on Aula.CodigoAula = Frequencia.codigoAula " & _
            " inner join turma on Aula.CodigoTurma =  Turma.Codigo " & _
            " where turma.Codigo = " & codigoTurma & " And codigoAluno = " & codigoAluno & " And Presenca = 0" '0-> false, falso 

            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoFalta(dataReader, turma) 'popular o objeto com soma das faltas
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
#End Region
End Class
