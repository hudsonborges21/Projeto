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
    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal aula As Aula, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = aula.CodigoAula
        End If
        comando.Parameters.Add("@CodigoTurma", SqlDbType.VarChar).Value = aula.CodigoTurma
        'comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = aula.CodigoAula
        comando.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = aula.Descricao
        comando.Parameters.Add("@Data", SqlDbType.Date).Value = aula.DataCad

    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef aula As Aula)
        'aula.CodigoAula = reader("CodigoAula")
        aula.CodigoTurma = reader("CodigoTurma")
        aula.CodigoAula = reader("CodigoAula")
        If Not IsDBNull(reader("Descricao")) Then aula.Descricao = (reader("Descricao"))
        If Not IsDBNull(reader("Data")) Then aula.DataCad = reader("Data")

    End Sub
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef aula As Aula)
        aula.CodigoAula = reader("CodigoAula")
    End Sub
    'METODO INCLUIR 
    Public Sub Incluir(ByVal aula As Aula) 'Passa objeto da classe "Aula"
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao) 'passa instruçao sql
                PopularComando(comando, aula, True) 'passa os dados pra o comando sql

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Aula) 'retorna uma  lista de objetos do tipo aula
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() 'passa sql
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then 'se encontrou alguma coisa preenche um novo obj e coloca ele na lista
                    While dataReader.Read()
                        Dim aula As New Aula 'cria objeto
                        PopularObjeto(dataReader, aula)
                        lista.Add(aula) ' add o objeto na lista
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
                        Dim aula As New Aula
                        PopularObjeto(dataReader, aula)
                        lista.Add(aula) ' add o objeto
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
    Public Function ConsultarAulasTurma(ByVal codigolinha As Integer) As List(Of Aula) 'retorna uma lista de obj, com as aulas da turma
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula) 'cria uma lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where CodigoTurma = " & codigolinha & " order by Data desc"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim aula As New Aula 'cria um novo objet da classe aula
                        PopularObjeto(dataReader, aula)
                        lista.Add(aula) ' add o objeto na lista
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
    Public Function Consultar(ByVal codigoAula As Integer, ByRef aula As Aula) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where codigoAula = " & codigoAula 'sql
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjeto(dataReader, aula) 'preeenche os dados
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function


    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal aula As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(aula.CodigoAula), conexao)
                PopularComando(comando, aula, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal aula As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Aula WHERE codigoAula=" & aula.CodigoAula
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@codigoAula", SqlDbType.VarChar).Value = aula.CodigoTurma
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub
    Public Function UltimoCodigo(ByVal codigoTurma As String, ByVal aula As Aula) As Boolean
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
                    PopularObjetoUltimoCodigo(dataReader, aula)
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
    '                    Dim aula As New Aula
    '                    PopularObjetoAula(dataReader, aula)
    '                    lista.Add(aula) ' add o objeto
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
    '*********************************************************************************************************************************************************
    '*********************************************************************************************************************************************************
    '
    'METODOS USADOS PARA MANIPULAR A FREQUENCIA
    '
    '*********************************************************************************************************************************************************
    '*********************************************************************************************************************************************************
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
    Private Shared Sub PopularComandoFrequencia(ByRef comando As SqlCommand, ByVal aula As Aula, ByVal incluindo As Boolean)
        'If Not incluindo Then
        '    comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = aula.CodigoAula
        'End If
        comando.Parameters.Add("@CodigoAluno", SqlDbType.VarChar).Value = aula.CodigoAluno
        comando.Parameters.Add("@CodigoAula", SqlDbType.VarChar).Value = aula.CodigoAula
        comando.Parameters.Add("@Presenca", SqlDbType.VarChar).Value = aula.Presenca

    End Sub

   
    Private Shared Sub PopularObjetoFrequencia(ByVal reader As IDataRecord, ByRef aula As Aula)

        'aula.CodigoTurma = reader("CodigoTurma")
        aula.CodigoAluno = reader("CodigoAluno")
        aula.Presenca = reader("Presenca")

        Dim obj As Aluno = New Aluno 'CRIA OBJET ALUNO PARA BUSCAR O NOME DO ALUNO
        obj.Consultar(aula.CodigoAluno) 'CONSULTA DADOS DO ALUNO
        aula.Aluno = obj.Nome

    End Sub
    'METODO INCLUIR 
    Public Sub IncluirFrequencia(ByVal aula As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsertFrequencia(), conexao) 'passa instruçao sql
                PopularComandoFrequencia(comando, aula, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

   
    'ALTERAR  - UPDATE
    Public Sub AlterarFrequencia(ByVal aula As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdateFrequencia(aula.CodigoAula, aula.CodigoAluno), conexao) 'passa instruçao sql
                PopularComandoFrequencia(comando, aula, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function ConsultarPresenca(ByVal codigoAluno As Integer, ByVal codigoAula As Integer, ByRef aula As Aula) As Boolean
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
                    PopularObjetoFrequencia(dataReader, aula) 'preencher dados
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Public Function TodosAlunosTurma(ByVal codigolinha As Integer) As List(Of Aula) 'retorna uma lista de aluno da pertencentees aquela aula
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aula) 'cria uma lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            'sql = ObterSqlSelectFrequencia() & " where CodigoAula = " & codigolinha

            sql = "Select Frequencia.* From Frequencia " & _
            "inner join aluno on aluno.codigo = Frequencia.codigoAluno " & _
            "inner join aula on Aula.CodigoAula = Frequencia.codigoAula " & _
             " where frequencia.codigoAula = " & codigolinha & " order by aluno.Nome"

            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim aula As New Aula
                        PopularObjetoFrequencia(dataReader, aula) 'preenche dados 
                        lista.Add(aula) ' add o objeto
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
    Public Sub ExcluirFrequencia(ByVal aula As Aula)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Frequencia WHERE codigoAula=" & aula.CodigoAula
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@codigoAula", SqlDbType.VarChar).Value = aula.CodigoTurma
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub
#End Region
End Class
