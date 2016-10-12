Imports System.Data.SqlClient
Imports System.Text

Public Class UsuarioDAO
#Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder
        sql.AppendLine("Insert Into Usuario ")
        sql.AppendLine(" ( nome,Data,Senha) ")
        sql.AppendLine("values ( @nome,@Data,@Senha)")
        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdate(ByVal parmCodigo As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Usuario Set ")
        sql.AppendLine(" nome=@nome,data=@data,senha=@senha  ")
        sql.AppendLine(" where Codigo='" & parmCodigo & "'")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From Usuario ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal usuario As Usuario, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = usuario.Codigo
        End If
        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome
        comando.Parameters.Add("@Data", SqlDbType.Date).Value = usuario.DataCad
        comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha

    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef usuario As Usuario)
        usuario.Codigo = reader("Codigo")
        usuario.Nome = reader("nome")
        usuario.DataCad = reader("Data")
        usuario.Senha = reader("senha")

    End Sub

    'METODO INCLUIR 
    Public Sub Incluir(ByVal usuario As Usuario)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, usuario, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Usuario)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Usuario)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo()
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim usuario As New Usuario
                        PopularObjeto(dataReader, usuario)
                        lista.Add(usuario)
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

    Public Function TodosNomes(ByVal nome As String) As List(Of Usuario)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Usuario)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Nome like '%" & nome & "%'"
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim usuario As New Usuario
                        PopularObjeto(dataReader, usuario)
                        lista.Add(usuario)
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
    Public Function TodosCodigos(ByVal Codigo As String) As List(Of Usuario)
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Usuario)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo =" & Codigo
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim usuario As New Usuario
                        PopularObjeto(dataReader, usuario)
                        lista.Add(usuario)
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

    Public Function Consultar(ByVal codigolinha As Integer, ByRef usuario As Usuario) As Boolean
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
                    PopularObjeto(dataReader, usuario)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function

    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal usuario As Usuario)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(usuario.Codigo), conexao)
                PopularComando(comando, usuario, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal usuario As Usuario)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Usuario WHERE codigo = " & usuario.Codigo
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = usuario.Codigo
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function UltimoCodigo(ByVal usuario As Usuario) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "SELECT max(Codigo) as codigo FROM usuario "
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoUltimoCodigo(dataReader, usuario)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef usuario As Usuario)
        usuario.Codigo = reader("Codigo")
    End Sub
#End Region

End Class
