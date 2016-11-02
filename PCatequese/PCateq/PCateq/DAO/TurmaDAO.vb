Imports System.Text
Imports System.Data.SqlClient

Public Class TurmaDAO
#Region "Metodos"

    'Private Codigo 
    'Private Nome 
    'Private Curso
    'Private AnoIni
    'Private AnoFim
    'Private CatequistaCodigo
    'Private DataCadastro

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder
        
        sql.AppendLine("Insert Into Turma ")
        sql.AppendLine(" ( nome, Curso, AnoIni, AnoFim, CatequistaCodigo, DataCadastro,InstituicaoCodigo) ")
        sql.AppendLine("values (@nome, @Curso, @AnoIni, @AnoFim, @CatequistaCodigo, @DataCadastro,@InstituicaoCodigo )")

        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdate(ByVal parmCodigo As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Turma Set ")
        sql.AppendLine(" nome=@nome, Curso=@Curso,AnoIni=@AnoIni, ")
        sql.AppendLine(" AnoFim=@AnoFim,CatequistaCodigo=@CatequistaCodigo,InstituicaoCodigo=@InstituicaoCodigo,DataCadastro=@DataCadastro ")
        sql.AppendLine(" where Codigo='" & parmCodigo & "'")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        'sql.AppendLine(" SELECT * From Turma  ")
        sql.AppendLine(" SELECT Codigo,Nome, InstituicaoCodigo, Curso, AnoINI, AnoFim, CatequistaCodigo, DataCadastro From Turma  ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal turma As Turma, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = turma.Codigo
        End If
        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = turma.Nome
        comando.Parameters.Add("@InstituicaoCodigo", SqlDbType.VarChar).Value = turma.CodigoInst
        comando.Parameters.Add("@Curso", SqlDbType.VarChar).Value = turma.Curso
        comando.Parameters.Add("@AnoINI", SqlDbType.VarChar).Value = turma.AnoIni
        comando.Parameters.Add("@AnoFim", SqlDbType.VarChar).Value = turma.AnoFim
        comando.Parameters.Add("@CatequistaCodigo", SqlDbType.VarChar).Value = turma.CatequistaCodigo
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = turma.DataCad


    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef turma As Turma)
        turma.Codigo = reader("Codigo")
        turma.Nome = reader("nome")
        If Not IsDBNull(reader("InstituicaoCodigo")) Then turma.CatequistaCodigo = reader("InstituicaoCodigo")
        If Not IsDBNull(reader("Curso")) Then turma.Curso = (reader("Curso"))
        If Not IsDBNull(reader("AnoINI")) Then turma.AnoIni = reader("AnoINI")
        If Not IsDBNull(reader("AnoFIM")) Then turma.AnoFim = reader("AnoFIM")
        If Not IsDBNull(reader("CatequistaCodigo")) Then turma.CatequistaCodigo = reader("CatequistaCodigo")
        If Not IsDBNull(reader("DataCadastro")) Then turma.DataCad = reader("DataCadastro")

    End Sub
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef turma As Turma)
        turma.Codigo = reader("CodigoTurma")
    
    End Sub
    'METODO INCLUIR 
    Public Sub Incluir(ByVal turma As Turma) 'passa o objet da classe Turma.vb como referencia
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao) 'passa comando sql
                PopularComando(comando, turma, True) 'prenche o comando

                'comando sql
                comando.ExecuteNonQuery() 'executa
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Turma) 'retorna uma lista de turmas por order Desc de codigo
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Turma)  'cria lista 

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & "Order by Codigo desc"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Turma 'cria objeto
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

    Public Function ConsultarNome(ByVal Nome As String) As List(Of Turma)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Turma) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Nome like '%" & Nome & "%'"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Turma 'cria objeto
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
    Public Function ConsultarCodigos(ByVal Codigo As String) As List(Of Turma) 'retorna lista de turma
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Turma) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo = " & Codigo
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim turma As New Turma 'cria obj
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

    Public Function Consultar(ByVal codigolinha As Integer, ByRef turma As Turma) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo = " & codigolinha
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjeto(dataReader, turma) 'preenche os dados
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function

    'Public Function ConsultarNome(ByVal Nome As String, ByRef turma As Turma) As Boolean
    '    Dim dataReader As SqlDataReader

    '    Using conexao As SqlConnection = New Conexao().GetConnection()
    '        'abrindo conexao 
    '        conexao.Open()
    '        Dim sql As String
    '        sql = ObterSqlSelectTodosCampo() & " where Nome like '%" & Nome & "%'"
    '        Using comando = New SqlCommand(sql, conexao)
    '            dataReader = comando.ExecuteReader
    '            If dataReader.HasRows Then
    '                dataReader.Read()
    '                PopularObjeto(dataReader, turma)
    '                conexao.Close()
    '                Return True
    '            End If
    '        End Using
    '    End Using
    'End Function

    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal turma As Turma)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(turma.Codigo), conexao) 'passa o sql
                PopularComando(comando, turma, True) 'preeche os commandos

                'comando sql
                comando.ExecuteNonQuery()   'executa
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal turma As Turma)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Turma WHERE codigo = " & turma.Codigo
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = turma.Codigo
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function UltimoCodigo(ByVal turma As Turma) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "SELECT max(Codigo) as codigoTurma FROM Turma "
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
#End Region
End Class
