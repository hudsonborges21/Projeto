Imports System.Data.SqlClient
Imports System.Text

Public Class AlunoDAO
    #Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Insert Into ALUNO ")
        sql.AppendLine(" ( nome, endereco, cidade, bairro, ")
        sql.AppendLine(" UF, telefone, CEP, Estado, PAI, Mae, ")
        sql.AppendLine(" Naturalidade, DataCadastro, DataNascimento,Batizado) ")
        sql.AppendLine(" values ")
        sql.AppendLine(" @nome, @endereco, @cidade, @bairro, ")
        sql.AppendLine(" @UF, @telefone, @CEP, @Estado, @PAI, @Mae, ")
        sql.AppendLine(" @Naturalidade, @DataCadastro, @DataNascimento,@Batizado) ")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlUpdate() As String
        Dim sql As New StringBuilder
        'sql.AppendLine(" Update ALUNO Set ")
        sql.AppendLine(" Update Catequista Set ")
        sql.AppendLine(" nome=@nome, cnpj=@cnpj,Endereco=@endereco,cidade=@cidade, ")
        sql.AppendLine(" bairro=@bairro,uf=@uf,telefone=@telefone,cep=@cep, Estado =@Estado, ")
        sql.AppendLine(" Pai=@Pai, Mae=@Mae, Naturalidade=@Naturalidade, batizado=@batizado, ")
        sql.AppendLine(" datacadastro=@datacastro, datanascimento=@datanascimento ")
        sql.AppendLine(" where id= @id ")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        'sql.AppendLine(" SELECT * From ALUNO ")
        sql.AppendLine(" SELECT * From Catequista ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal aluno As Aluno, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@id", SqlDbType.VarChar).Value = aluno.Codigo
        End If
        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = aluno.Nome
        comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = aluno.Endereco
        comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = aluno.Cidade
        comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = aluno.Bairro
        comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = aluno.UF
        comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = aluno.Telefone
        comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = aluno.CEP
        comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = aluno.Estado
        comando.Parameters.Add("@Pai", SqlDbType.VarChar).Value = aluno.Pai
        comando.Parameters.Add("@Mae", SqlDbType.VarChar).Value = aluno.Mae
        comando.Parameters.Add("@Naturalizade", SqlDbType.VarChar).Value = aluno.Naturalidade
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = aluno.DataCad
        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = aluno.DataNasc
        comando.Parameters.Add("@Batizado", SqlDbType.Bit).Value = aluno.Batizado
    End Sub

    Private Shared Function PopularObjeto(ByVal reader As IDataRecord) As Aluno
        dim obj = new Aluno()
        obj.Codigo = reader("Codigo")
        obj.Nome = reader("nome")
        If Not IsDBNull(reader("endereco")) Then obj.Endereco = (reader("endereco"))
        If Not IsDBNull(reader("cidade")) Then obj.Cidade = reader("cidade")
        If Not IsDBNull(reader("bairro")) Then obj.Bairro = reader("bairro")
        If Not IsDBNull(reader("uf")) Then obj.UF = reader("UF")
        ' If Not IsDBNull(reader("telefone")) Then vTelefone = reader("telefone")
        If Not IsDBNull(reader("CEP")) Then obj.CEP = reader("CEP")
        'If Not IsDBNull(reader("Estado")) Then vEstado = reader("estado")
        If Not IsDBNull(reader("Pai")) Then obj.Pai = reader("Pai")
        If Not IsDBNull(reader("mae")) Then obj.Mae = reader("mae")
        If Not IsDBNull(reader("Naturalidade")) Then obj.Naturaliade = reader("Naturalidade")
        If Not IsDBNull(reader("DataCadastro")) Then obj.DataCadastro = reader("DataCadastro")
        If Not IsDBNull(reader("DataNascimento")) Then obj.DataNasc = reader("DataNascimento")
        If Not IsDBNull(reader("Batizado")) Then obj.Batizado = reader("Batizado")
        Return obj
    End Function

    'METODO INCLUIR 
    Public Sub Incluir(ByVal aluno As Aluno)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, aluno, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Aluno)
        Dim dataReader As SqlDataReader
        Dim lista = new List(Of Aluno)

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() 
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        lista.Add(PopularObjeto(dataReader))
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
    Public Function Consultar(ByVal codigolinha As Integer) As Aluno
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
                    Dim obj =  PopularObjeto(dataReader)
                    conexao.Close()
                    Return obj
                Else
                    conexao.Close()
                    Return Nothing
                End If
            End Using
        End Using
    End Function

    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal aluno As Aluno)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(), conexao)
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
            sql = "DELETE FROM ALUNO WHERE id = " & aluno.Codigo
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@id", SqlDbType.VarChar).Value = aluno.Codigo
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub
#End Region
End Class
