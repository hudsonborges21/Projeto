Imports System.Data.SqlClient
Imports System.Text

Public Class CatequistaDAO
#Region "Metodos"

    Private Shared Function ObterSqlInsert() As String
        Dim sql As New StringBuilder
        'sql.AppendLine(" Insert Into ALUNO ")
        'sql.AppendLine(" Insert Into Catequista ")
        'sql.AppendLine(" ( nome, endereco, cidade, bairro, ")
        'sql.AppendLine(" UF, telefone, CEP, PAI, Mae, ")
        'sql.AppendLine(" Naturalidade, DataCadastro, DataNascimento,Batizado) ")
        'sql.AppendLine(" values ")
        'sql.AppendLine(" @nome, @endereco, @cidade, @bairro, ")
        'sql.AppendLine(" @UF, @telefone, @CEP, @PAI, @Mae, ")
        'sql.AppendLine(" @Naturalidade, @DataCadastro, @DataNascimento,@Batizado) ")
        sql.AppendLine("Insert Into Professor ")
        sql.AppendLine(" ( nome, endereco, cidade, bairro, UF, telefone, CEP, PAI, Mae, Naturalidade, DataCadastro, DataNascimento,Batizado) ")
        sql.AppendLine("values ( @nome, @endereco, @cidade, @bairro, @UF, @telefone, @CEP,  @PAI, @Mae, @Naturalidade, @DataCadastro, @DataNascimento,@Batizado)")

        'MsgBox(sql.ToString())
        Return sql.ToString()

    End Function

    Private Shared Function ObterSqlUpdate(ByVal parmCodigo As Integer) As String
        Dim sql As New StringBuilder
        sql.AppendLine(" Update Professor Set ")
        sql.AppendLine(" nome=@nome, Endereco=@endereco,cidade=@cidade, ")
        sql.AppendLine(" bairro=@bairro,uf=@uf,telefone=@telefone,cep=@cep, ")
        sql.AppendLine(" Pai=@Pai, Mae=@Mae, Naturalidade=@Naturalidade, batizado=@batizado, ")
        sql.AppendLine(" DataCadastro=@DataCadastro, datanascimento=@datanascimento ")
        sql.AppendLine(" where Codigo='" & parmCodigo & "'")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        'sql.AppendLine(" SELECT * From ALUNO ")
        sql.AppendLine(" SELECT * From Professor ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal catequista As Catequista, ByVal incluindo As Boolean)
        If Not incluindo Then
            comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = catequista.Codigo
        End If
        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = catequista.Nome
        comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = catequista.Endereco
        comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = catequista.Cidade
        comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = catequista.Bairro
        comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = catequista.UF
        comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = catequista.Telefone
        comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = catequista.CEP
        comando.Parameters.Add("@Pai", SqlDbType.VarChar).Value = catequista.Pai
        comando.Parameters.Add("@Mae", SqlDbType.VarChar).Value = catequista.Mae
        comando.Parameters.Add("@Naturalidade", SqlDbType.VarChar).Value = catequista.Naturalidade
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = catequista.DataCad
        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = catequista.DataNasc
        comando.Parameters.Add("@Batizado", SqlDbType.Bit).Value = catequista.Batizado
    End Sub

    Private Shared Sub PopularObjeto(ByVal reader As IDataRecord, ByRef catequista As Catequista)
        catequista.Codigo = reader("Codigo")
        catequista.Nome = reader("nome")
        If Not IsDBNull(reader("endereco")) Then catequista.Endereco = (reader("endereco"))
        If Not IsDBNull(reader("cidade")) Then catequista.Cidade = reader("cidade")
        If Not IsDBNull(reader("bairro")) Then catequista.Bairro = reader("bairro")
        If Not IsDBNull(reader("uf")) Then catequista.UF = reader("UF")
        If Not IsDBNull(reader("telefone")) Then catequista.Telefone = reader("telefone")
        If Not IsDBNull(reader("CEP")) Then catequista.CEP = reader("CEP")
        If Not IsDBNull(reader("Pai")) Then catequista.Pai = reader("Pai")
        If Not IsDBNull(reader("mae")) Then catequista.Mae = reader("mae")
        If Not IsDBNull(reader("Naturalidade")) Then catequista.Naturalidade = reader("Naturalidade")
        If Not IsDBNull(reader("DataCadastro")) Then catequista.DataCad = reader("DataCadastro")
        If Not IsDBNull(reader("DataNascimento")) Then catequista.DataNasc = reader("DataNascimento")
        If Not IsDBNull(reader("Batizado")) Then catequista.Batizado = reader("Batizado")
    End Sub

    'METODO INCLUIR 
    Public Sub Incluir(ByVal catequista As Catequista)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, catequista, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function Todos() As List(Of Catequista) 'retorna lista de catequista
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Catequista) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo()
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim catequista As New Catequista 'cria objeto
                        PopularObjeto(dataReader, catequista) 'preenche os dados
                        lista.Add(catequista) 'add obj na lista
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
    Public Function TodosNomes(ByVal nome As String) As List(Of Catequista) 'retorna uma lista de objeto catequista pesquisado por nome
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Catequista) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Nome like '%" & nome & "%'" 'passa sql
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim catequista As New Catequista 'cria objt
                        PopularObjeto(dataReader, catequista) 'preenche os dados
                        lista.Add(catequista) 'add objt na lista
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
    Public Function TodosCodigos(ByVal Codigo As String) As List(Of Catequista) 'retorna uma lista de catequista
        Dim dataReader As SqlDataReader
        Dim lista = New List(Of Catequista) 'cria lista

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo =" & Codigo 'sql
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim catequista As New Catequista 'cria um objeto 
                        PopularObjeto(dataReader, catequista) 'prenche os daos
                        lista.Add(catequista) 'add objeto na lista
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
    Public Function Consultar(ByVal codigolinha As Integer, ByRef catequista As Catequista) As Boolean 'retorna dados do catequista
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = ObterSqlSelectTodosCampo() & " where Codigo = " & codigolinha 'sql
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjeto(dataReader, catequista) 'preeche os dados
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function

    'ALTERAR  - UPDATE
    Public Sub Alterar(ByVal catequista As Catequista)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(catequista.Codigo), conexao)
                PopularComando(comando, catequista, True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'EXCLUIR  - DELETE
    Public Sub Excluir(ByVal catequista As Catequista)
        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM Professor WHERE codigo = " & catequista.Codigo
            Using comando = New SqlCommand(sql, conexao)
                comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = catequista.Codigo
                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    Public Function UltimoCodigo(ByVal catequista As Catequista) As Boolean
        Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New Conexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "SELECT max(Codigo) as codigo FROM Catequista "
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    dataReader.Read()
                    PopularObjetoUltimoCodigo(dataReader, catequista)
                    conexao.Close()
                    Return True
                End If
            End Using
        End Using
        Return True
    End Function
    Private Shared Sub PopularObjetoUltimoCodigo(ByVal reader As IDataRecord, ByRef catequista As Catequista)
        catequista.Codigo = reader("Codigo")
    End Sub
#End Region
End Class
