Imports System.Data.SqlClient

Public Class Catequista


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
    Private vEstado As String
    Private vDataCadastro As Date
    Private vDataNasc As Date


    'criando a string de conexao com o banco de dados
    Private vStrConexao As String

    'objeto da classe conexao
    Dim CON As New Conexao

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

#End Region



#Region "Metodos"


    'criando o construtor
    Public Sub New()
        vStrConexao = CON.StrConexao
    End Sub

    'METODO INCLUIR 
    Public Sub Incluir()


        Dim Conexao As SqlConnection

        Conexao = New SqlConnection(vStrConexao)

        'abrindo conexao 
        Conexao.Open()

        'dados em na forma de string da sql
        Dim Sql As String
        Sql = "Insert Into CATEQUISTA " & _
            " ( nome, endereco, cidade, bairro, UF, telefone, CEP, Estado, DataCadastro, DataNascimento) " & _
            "values ( @nome, @endereco, @cidade, @bairro, @UF, @telefone, @CEP, @Estado, @DataCadastro, @DataNascimento)"

        Dim comando As SqlCommand
        comando = New SqlCommand(Sql, Conexao)

        'parametro recebe  valores 


        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = Nome
        comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = Endereco
        comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = Cidade
        comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = Bairro
        comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = UF
        comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = Telefone
        comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = CEP
        comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = DataCad
        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = DataNasc


        'comando sql
        comando.ExecuteNonQuery()

        'fechando a conexao 
        Conexao.Close()

    End Sub

    'CONSULTAR 
    Public Function Consultar(ByVal codigolinha As Integer) As Boolean

        'criando a conexao com o banco de dados
        Dim conexao As SqlConnection
        conexao = New SqlConnection(vStrConexao)

        'abrindo a conexao com o banco
        conexao.Open()

        'criando o comando sql
        Dim sql As String
        sql = "SELECT * " & _
              "FROM CATEQUISTA where id = " & codigolinha


        Dim comando As SqlCommand
        comando = New SqlCommand(sql, conexao)

        Dim dataReader As SqlDataReader
        dataReader = comando.ExecuteReader

        'dataReader buscar uma linha 
        If dataReader.HasRows Then

            dataReader.Read()

            vCodigo = dataReader("id")
            vNome = dataReader("nome")
            If Not IsDBNull(dataReader("endereco")) Then vEndereco = (dataReader("endereco"))
            If Not IsDBNull(dataReader("cidade")) Then vCidade = dataReader("cidade")
            If Not IsDBNull(dataReader("bairro")) Then vBairro = dataReader("bairro")
            If Not IsDBNull(dataReader("uf")) Then vUF = dataReader("UF")
            If Not IsDBNull(dataReader("telefone")) Then vTelefone = dataReader("telefone")
            If Not IsDBNull(dataReader("CEP")) Then vCEP = dataReader("CEP")
            If Not IsDBNull(dataReader("Estado")) Then vEstado = dataReader("estado")
            If Not IsDBNull(dataReader("DataCadastro")) Then vDataCadastro = dataReader("DataCadastro")
            If Not IsDBNull(dataReader("DataNascimento")) Then vDataNasc = dataReader("DataNascimento")


            Return True


        Else
            Return False
        End If

        'fechando o conexao 
        conexao.Close()

    End Function


    'ALTERAR  - UPDATE
    Public Function Alterar(ByVal parmCodigo As Integer) 'As Boolean


        'criando a conexao com o banco de dados
        Dim conexao As SqlConnection
        conexao = New SqlConnection(vStrConexao)

        'abrindo a conexao 
        conexao.Open()

        'criando o comando sql
        Dim sql As String

        sql = "Update CATEQUISTA set nome=@nome, cnpj=@cnpj,Endereco=@endereco,cidade=@cidade, bairro=@bairro,uf=@uf,telefone=@telefone,cep=@cep, Estado =@Estado, '" & _
              "'  datacadastro=@datacastro, datanascimento=@datanascimento where id='" & parmCodigo & "'"

        Dim comando As SqlCommand
        comando = New SqlCommand(sql, conexao)


        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = Nome
        comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = Endereco
        comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = Cidade
        comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = Bairro
        comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = UF
        comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = Telefone
        comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = CEP
        comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        comando.Parameters.Add("@DataCadastro", SqlDbType.Date).Value = DataCad
        comando.Parameters.Add("@DataNascimento", SqlDbType.Date).Value = DataNasc



        comando.ExecuteNonQuery()

        'fechando a conexao com o banco
        conexao.Close()



        Return False




    End Function


    'EXCLUIR  - DELETE
    Public Function Excluir(ByVal parmCodigo As Integer) As Boolean

        'criando a conexao com o banco de dados
        Dim conexao As SqlConnection
        conexao = New SqlConnection(vStrConexao)

        'abrindo a conexao com o banco
        conexao.Open()

        'criando o comando sql
        Dim sql As String
        sql = "DELETE FROM CATEQUISTA WHERE id = " & parmCodigo


        Dim comando As SqlCommand
        comando = New SqlCommand(sql, conexao)

        comando.ExecuteNonQuery()

        'fechando 
        conexao.Close()

        Return True
    End Function

    Public Function Ultimo() As String
        Dim resp As String
        resp = ""
        'criando a conexao com o banco de dados
        Dim conexao As SqlConnection
        conexao = New SqlConnection(vStrConexao)
        'abrindo a conexao com o banco
        conexao.Open()
        'criando o comando sql
        Dim sql As String
        sql = "SELECT max(id) as ultimo FROM CATEQUISTA"
        Dim comando As SqlCommand
        comando = New SqlCommand(sql, conexao)
        Dim dataReader As SqlDataReader
        dataReader = comando.ExecuteReader
        'dataReader buscar uma linha 
        If dataReader.HasRows Then
            dataReader.Read()
            If Not IsDBNull(dataReader("ultimo")) Then
                resp = dataReader("ultimo") + 1
            Else
                resp = 1
            End If

            Return resp
        Else
            Return resp
        End If

        'fechando o conexao 
        conexao.Close()

    End Function

#End Region

End Class
