Imports System.Data.SqlClient
Imports System.Text

Public Class ClAluno

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigo As Integer
    Private vNome As String
    Private vEndereco As String
    Private vCidade As String
    Private vBairro As String
    Private vNumero As String
    Private vUF As String
    Private vTelefone As String
    Private vCEP As String
    Private vNaturaliade As String
    Private vEstado As String
    Private vPai As String
    Private vMae As String
    Private vBatizado As Boolean
    Private vDataCadastro As Date
    Private vDataNasc As Date

#End Region


#Region "Propriedades"


    'criando propriedade para encapsular os atributos do classe
    Public Property Codigo() As Integer
        Get
            Return vCodigo
        End Get
        Set(ByVal value As Integer)
            vCodigo = value
        End Set
    End Property


    Public Property Nome() As String
        Get
            Return vNome
        End Get
        Set(ByVal value As String)
            vNome = value
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Return vEndereco
        End Get
        Set(ByVal value As String)
            vEndereco = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return vNumero
        End Get
        Set(ByVal value As String)
            vNumero = value
        End Set
    End Property


    Public Property Cidade() As String
        Get
            Return vCidade
        End Get
        Set(ByVal value As String)
            vCidade = value
        End Set
    End Property

    Public Property Bairro() As String
        Get
            Return vBairro
        End Get
        Set(ByVal value As String)
            vBairro = value
        End Set
    End Property

    Public Property UF() As String
        Get
            Return vUF
        End Get
        Set(ByVal value As String)
            vUF = value
        End Set
    End Property

    Public Property Telefone() As String
        Get
            Return vTelefone
        End Get
        Set(ByVal value As String)
            vTelefone = value
        End Set
    End Property

    Public Property CEP() As String
        Get
            Return vCEP
        End Get
        Set(ByVal value As String)
            vCEP = value
        End Set
    End Property

    Public Property Naturalidade() As String
        Get
            Return vNaturaliade
        End Get
        Set(ByVal value As String)
            vNaturaliade = value
        End Set
    End Property

    Public Property Pai() As String
        Get
            Return vPai
        End Get
        Set(ByVal value As String)
            vPai = value
        End Set
    End Property
    Public Property Mae() As String
        Get
            Return vMae
        End Get
        Set(ByVal value As String)
            vMae = value
        End Set
    End Property

    Public Property DataCad() As Date
        Get
            Return vDataCadastro
        End Get
        Set(ByVal value As Date)
            vDataCadastro = value
        End Set
    End Property

    Public Property DataNasc() As Date
        Get
            Return vDataNasc
        End Get
        Set(ByVal value As Date)
            vDataNasc = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return vEstado
        End Get
        Set(ByVal value As String)
            vEstado = value
        End Set
    End Property

    Public Property Batizado() As Boolean
        Get
            Return vBatizado
        End Get
        Set(ByVal value As Boolean)
            vBatizado = value
        End Set
    End Property
#End Region



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
        sql.AppendLine(" Update ALUNO Set ")
        sql.AppendLine(" nome=@nome, cnpj=@cnpj,Endereco=@endereco,cidade=@cidade, ")
        sql.AppendLine(" bairro=@bairro,uf=@uf,telefone=@telefone,cep=@cep, Estado =@Estado, ")
        sql.AppendLine(" Pai=@Pai, Mae=@Mae, Naturalidade=@Naturalidade, batizado=@batizado, ")
        sql.AppendLine(" datacadastro=@datacastro, datanascimento=@datanascimento ")
        sql.AppendLine(" where id= @id ")
        Return sql.ToString()
    End Function

    Private Shared Function ObterSqlSelectTodosCampo() As String
        Dim sql As New StringBuilder
        sql.AppendLine(" SELECT * From ALUNO ")
        Return sql.ToString()
    End Function

    Private Shared Sub PopularComando(ByRef comando As SqlCommand, ByVal aluno As ClAluno, byval incluindo as Boolean)
        if Not incluindo Then
            comando.Parameters.Add("@id", SqlDbType.VarChar).Value = aluno.vCodigo 
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

    Private Sub PopularObjeto(ByVal reader As IDataRecord)
        vCodigo = reader("id")
        vNome = reader("nome")
        If Not IsDBNull(reader("endereco")) Then vEndereco = (reader("endereco"))
        If Not IsDBNull(reader("cidade")) Then vCidade = reader("cidade")
        If Not IsDBNull(reader("bairro")) Then vBairro = reader("bairro")
        If Not IsDBNull(reader("uf")) Then vUF = reader("UF")
        If Not IsDBNull(reader("telefone")) Then vTelefone = reader("telefone")
        If Not IsDBNull(reader("CEP")) Then vCEP = reader("CEP")
        If Not IsDBNull(reader("Estado")) Then vEstado = reader("estado")
        If Not IsDBNull(reader("Pai")) Then vPai = reader("Pai")
        If Not IsDBNull(reader("mae")) Then vMae = reader("mae")
        If Not IsDBNull(reader("Naturalidade")) Then vNaturaliade = reader("Naturalidade")
        If Not IsDBNull(reader("DataCadastro")) Then vDataCadastro = reader("DataCadastro")
        If Not IsDBNull(reader("DataNascimento")) Then vDataNasc = reader("DataNascimento")
        If Not IsDBNull(reader("Batizado")) Then vBatizado = reader("Batizado")
    End Sub

    'METODO INCLUIR 
    Public Sub Incluir()
        Using conexao As SqlConnection = New CLConexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlInsert(), conexao)
                PopularComando(comando, Me,True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End Sub

    'CONSULTAR 
    Public Function Consultar(ByVal codigolinha As Integer) As Boolean
    Dim dataReader As SqlDataReader

        Using conexao As SqlConnection = New CLConexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql as string
            sql = ObterSqlSelectTodosCampo() & " where id = " & codigolinha    
            Using comando = New SqlCommand(sql, conexao)
                dataReader = comando.ExecuteReader
                If dataReader.HasRows Then
                    PopularObjeto(dataReader)
                    conexao.Close()
                    Return True
                Else
                    conexao.Close() 
                    Return False
                End If
            End Using
        End Using
    End Function

    'ALTERAR  - UPDATE
    Public sub Alterar() 
        Using conexao As SqlConnection = New CLConexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Using comando = New SqlCommand(ObterSqlUpdate(), conexao)
                PopularComando(comando, Me,True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End sub

    'EXCLUIR  - DELETE
    Public sub Excluir(ByVal parmCodigo As Integer)
        Using conexao As SqlConnection = New CLConexao().GetConnection()
            'abrindo conexao 
            conexao.Open()
            Dim sql As String
            sql = "DELETE FROM ALUNO WHERE id = " & parmCodigo
            Using comando = New SqlCommand(sql, conexao)
                PopularComando(comando, Me,True)

                'comando sql
                comando.ExecuteNonQuery()
            End Using
            'fechando a conexao 
            conexao.Close()
        End Using
    End sub
#End Region
End Class
