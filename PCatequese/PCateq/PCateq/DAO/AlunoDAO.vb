﻿Imports System.Data.SqlClient
Imports System.Text

Public Class AlunoDAO
#Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        'DEFINIR SQL PARA INCLUIR
        Dim sql As New StringBuilder
        sql.AppendLine("Insert Into ALUNO ")
        sql.AppendLine(" ( nome, endereco, cidade, bairro, UF, telefone, CEP, PAI, Mae, Naturalidade, DataCadastro, DataNascimento,Batizado) ")
        sql.AppendLine("values ( @nome, @endereco, @cidade, @bairro, @UF, @telefone, @CEP,  @PAI, @Mae, @Naturalidade, @DataCadastro, @DataNascimento,@Batizado)")

        'MsgBox(sql.ToString())
        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdate(ByVal parmCodigo As Integer) As String
        'DEFINIR SQL APARA UPDATE
        Dim sql As New StringBuilder
        sql.AppendLine(" Update ALUNO Set ")
        sql.AppendLine(" nome=@nome, Endereco=@endereco,cidade=@cidade, ")
        sql.AppendLine(" bairro=@bairro,uf=@uf,telefone=@telefone,cep=@cep, ")
        sql.AppendLine(" Pai=@Pai, Mae=@Mae, Naturalidade=@Naturalidade, batizado=@batizado, ")
        sql.AppendLine(" DataCadastro=@DataCadastro, datanascimento=@datanascimento ")
        sql.AppendLine(" where Codigo='" & parmCodigo & "'")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From ALUNO ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal aluno As Aluno, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = aluno.Codigo
        End If
        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = aluno.Nome
        comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = aluno.Endereco
        comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = aluno.Cidade
        comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = aluno.Bairro
        comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = aluno.UF
        comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = aluno.Telefone
        comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = aluno.CEP
        comando.Parameters.Add("@Pai", SqlDbType.VarChar).Value = aluno.Pai
        comando.Parameters.Add("@Mae", SqlDbType.VarChar).Value = aluno.Mae
        comando.Parameters.Add("@Naturalidade", SqlDbType.VarChar).Value = aluno.Naturalidade
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = aluno.DataCad
        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = aluno.DataNasc
        comando.Parameters.Add("@Batizado", SqlDbType.Bit).Value = aluno.Batizado
    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef aluno As Aluno)
        aluno.Codigo = reader("Codigo")
        aluno.Nome = reader("nome")
        If Not IsDBNull(reader("endereco")) Then aluno.Endereco = (reader("endereco"))
        If Not IsDBNull(reader("cidade")) Then aluno.Cidade = reader("cidade")
        If Not IsDBNull(reader("bairro")) Then aluno.Bairro = reader("bairro")
        If Not IsDBNull(reader("uf")) Then aluno.UF = reader("UF")
        If Not IsDBNull(reader("telefone")) Then aluno.Telefone = reader("telefone")
        If Not IsDBNull(reader("CEP")) Then aluno.CEP = reader("CEP")
        If Not IsDBNull(reader("Pai")) Then aluno.Pai = reader("Pai")
        If Not IsDBNull(reader("mae")) Then aluno.Mae = reader("mae")
        If Not IsDBNull(reader("Naturalidade")) Then aluno.Naturalidade = reader("Naturalidade")
        If Not IsDBNull(reader("DataCadastro")) Then aluno.DataCad = reader("DataCadastro")
        If Not IsDBNull(reader("DataNascimento")) Then aluno.DataNasc = reader("DataNascimento")
        If Not IsDBNull(reader("Batizado")) Then aluno.Batizado = reader("Batizado")
    End Sub

    'METODO INCLUIR 
    Public Sub Incluir(ByVal aluno As Aluno) 'Passa obj da classe "ALUNO.vb" como referencia
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, aluno, True) 'chama funçao para popular comando e passa o obj ALUNO

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Aluno) 'cria uma lista de objeto do tipo "Aluno"
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aluno)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() 'sql para pegar todos os registros exemplo->. select * from
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then 'se reader tiver linhas(rows), cria um novo objeto aluno
                    While dataReader.Read()
                        Dim aluno As New Aluno 'cria um novo objeto aqui
                        PopularObjeto(dataReader, aluno) 'passa os dados para esse novo objeto
                        lista.Add(aluno)    'adiciona esse objeto na lista objeto aluno
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

    Public Function TodosNomes(ByVal nome As String) As List(Of Aluno)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aluno)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Nome like '%" & nome & "%'"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim aluno As New Aluno
                        PopularObjeto(dataReader, aluno)
                        lista.Add(aluno)
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
    Public Function TodosCodigos(ByVal Codigo As String) As List(Of Aluno)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Aluno)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo =" & Codigo
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim aluno As New Aluno
                        PopularObjeto(dataReader, aluno)
                        lista.Add(aluno)
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

    Public Function Consultar(ByVal codigolinha As Integer, ByRef aluno As Aluno) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo = " & codigolinha 'define a sql de consulta
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjeto(dataReader, aluno) 'passa os dados para o objeto aluno
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function

    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal aluno As Aluno)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(aluno.Codigo), conexao)
                PopularComando(comando, aluno, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal aluno As Aluno)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM ALUNO WHERE codigo = " & aluno.Codigo
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = aluno.Codigo
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function UltimoCodigo(ByVal aluno As Aluno) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "SELECT max(Codigo) as codigo FROM Aluno "
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoUltimoCodigo(dataReader, aluno)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef aluno As Aluno)
        aluno.Codigo = reader("Codigo")
    End Sub
#End Region
End Class
