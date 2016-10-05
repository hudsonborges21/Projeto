Imports System.Text
Imports System.Data.SqlClient

Public Class AulaDAO
#Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder

        sql.AppendLine("Insert Into Aula ")
        sql.AppendLine(" ( CodigoTurma, data, Descricao) ")
        sql.AppendLine("values (@CodigoTurma, @data, @Descricao )")

        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdate(ByVal pCodAula As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Aula Set ")
        sql.AppendLine(" CodigoTurma=@CodigoTurma, data=@data, ")
        sql.AppendLine(" Descricao=@Descricao ")
        sql.AppendLine(" where CodigoAula = " & pCodAula)
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From Aula  ")
        Return sql.ToString()
    End Function
    Private Shared Function ObterSqlSelectMatricula() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From Matricula ")
        Return sql.ToString()
    End Function
    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal turma As Aula, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = turma.CodigoAula
        End If
        comando.Parameters.Add("@CodigoTurma", SqlDbType.VarChar).Value = turma.CodigoTurma
        'comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = turma.CodigoAula
        comando.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = turma.Descricao
        comando.Parameters.Add("@Data", SqlDbType.Date).Value = turma.DataCad

    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef turma As Aula)
        'turma.CodigoAula = reader("CodigoAula")
        turma.CodigoTurma = reader("CodigoTurma")
        turma.CodigoAula = reader("CodigoAula")
        If Not IsDBNull(reader("Descricao")) Then turma.Descricao = (reader("Descricao"))
        If Not IsDBNull(reader("Data")) Then turma.DataCad = reader("Data")

    End Sub
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef turma As Aula)
        turma.CodigoAula = reader("CodigoAula")
     End Sub
    'METODO INCLUIR 
    Public Sub Incluir(ByVal turma As Aula)
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

    Public Function Todos() As List(Of Aula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo()
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Aula
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
    Public Function Consultarx(ByVal codigolinha As Integer) As List(Of Aula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where CodigoAula = " & codigolinha
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Aula
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
    Public Function ConsultarAulasTurma(ByVal codigolinha As Integer) As List(Of Aula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where CodigoTurma = " & codigolinha & " order by codigoAula desc"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Aula
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
    Public Function Consultar(ByVal codigoAula As Integer, ByRef turma As Aula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where codigoAula = " & codigoAula
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
    Public Sub Alterar(ByVal turma As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(turma.CodigoAula), conexao)
                PopularComando(comando, turma, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal turma As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Aula WHERE codigoAula=" & turma.CodigoAula
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@codigoAula", SqlDbType.VarChar).Value = turma.CodigoTurma
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub
    Public Function UltimoCodigo(ByVal codigoTurma As String, ByVal turma As Aula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "SELECT max(CodigoAula) as codigoAula  FROM Aula where codigoTurma = " & codigoTurma
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoUltimoCodigo(dataReader, turma)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    'Public Function TodosAlunosTurma(ByVal codigolinha As Integer) As List(Of Aula)
    '    Dim dataReader As SqlDataReader
    '    Dim lista = New List(Of Aula)

    '    Using conexao As SqlConnection = New Conexao().GetConnection()
    '        'abrindo conexao 
    '        conexao.Open()
    '        Dim sql As String
    '        sql = ObterSqlSelectMatricula() & " where CodigoTurma = " & codigolinha
    '        ' sql = ObterSqlSelectTodosCampo() & " inner join alunos on alunos.codigo = Matricula.codigoAluno where CodigoTurma = " & codigolinha
    '        Using comando = New SqlCommand(sql, conexao)
    '            dataReader = comando.ExecuteReader
    '            If dataReader.HasRows Then
    '                While dataReader.Read()
    '                    Dim turma As New Aula
    '                    PopularObjetoAula(dataReader, turma)
    '                    lista.Add(turma) ' add o objeto
    '                End While
    '                conexao.Close()
    '                Return lista
    '            Else
    '                conexao.Close()
    '                Return Nothing
    '            End If
    '        End Using
    '    End Using
    'End Function
    
   
#End Region
#Region "Metodos Frequencia"

    Private Shared Function ObterSqlInsertFrequencia() As String
        Dim sql As New StringBuilder

        sql.AppendLine("Insert Into Frequencia ")
        sql.AppendLine(" ( CodigoAula, CodigoAluno, Presenca) ")
        sql.AppendLine("values (@CodigoAula, @CodigoAluno, @Presenca )")

        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdateFrequencia(ByVal pCodAula As Integer, ByVal pCodAluno As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Frequencia Set ")
        sql.AppendLine(" CodigoAula=@CodigoAula,CodigoAluno=@CodigoAluno, ")
        sql.AppendLine(" Presenca=@Presenca ")
        sql.AppendLine(" where CodigoAula = " & pCodAula & " and CodigoAluno = " & pCodAluno)
        Return sql.ToString()
    End Function

    
    Private Shared Function ObterSqlSelectFrequencia() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From Frequencia ")
        Return sql.ToString()
    End Function
    Private Shared Sub PopularComandoFrequencia(ByRef comando As SqlCommand, ByVal turma As Aula, ByVal incluindo As Boolean)
        'If Not incluindo Then
        '    comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = turma.CodigoAula
        'End If
        comando.Parameters.Add("@CodigoAluno", SqlDbType.VarChar).Value = turma.CodigoAluno
        comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = turma.CodigoAula
        comando.Parameters.Add("@Presenca", SqlDbType.VarChar).Value = turma.Presenca

    End Sub

   
    Private Shared Sub PopularObjetoFrequencia(ByVal reader As IDataRecord, ByRef turma As Aula)

        'turma.CodigoTurma = reader("CodigoTurma")
        turma.CodigoAluno = reader("CodigoAluno")
        turma.Presenca = reader("Presenca")

        Dim obj As Aluno = New Aluno
        obj.Consultar(turma.CodigoAluno)
        turma.Aluno = obj.Nome

    End Sub
    'METODO INCLUIR 
    Public Sub IncluirFrequencia(ByVal turma As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsertFrequencia(), conexao)
                PopularComandoFrequencia(comando, turma, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

   
    'ALTERAR  - UPDATE
    Public Sub AlterarFrequencia(ByVal turma As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdateFrequencia(turma.CodigoAula, turma.CodigoAluno), conexao)
                PopularComandoFrequencia(comando, turma, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function ConsultarPresenca(ByVal codigoAluno As Integer, ByVal codigoAula As Integer, ByRef turma As Aula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "select * from Frequencia where codigoAula = " & codigoAula & " and codigoAluno = " & codigoAluno
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoFrequencia(dataReader, turma)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Public Function TodosAlunosTurma(ByVal codigolinha As Integer) As List(Of Aula)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectFrequencia() & " where CodigoAula = " & codigolinha
            'sql = ObterSqlSelectTodosCampo() & " inner join alunos on alunos.codigo = Aula.codigoAluno where CodigoTurma = " & codigolinha & "Order by Nome"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Aula
                        PopularObjetoFrequencia(dataReader, turma)
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
    'EXCLUIR  - DELETE
    Public Sub ExcluirFrequencia(ByVal turma As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Frequencia WHERE codigoAula=" & turma.CodigoAula
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@codigoAula", SqlDbType.VarChar).Value = turma.CodigoTurma
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub
#End Region
End Class
