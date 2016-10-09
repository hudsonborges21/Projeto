Imports System.Data.SqlClient
Imports System.Text

Public Class Aluno

#Region "Atributos"

    'declarando os atributos da classe 
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
    Public Property Naturalidade() As String
        Get
            Return vNaturaliade
        End Get
        Set(ByVal value As String)
            vNaturaliade = value
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
    Public Sub Incluir()
        Call New AlunoDAO().Incluir(Me)
    End Sub

    Public Sub Alterar()
        Call New AlunoDAO().Alterar(Me)
    End Sub
    Public Sub Excluir()
        Call New AlunoDAO().Excluir(Me)
    End Sub

    Public Function Todos() As List(Of Aluno)
        Return New AlunoDAO().Todos()
    End Function
    Public Function TodosNomes() As List(Of Aluno)
        Return New AlunoDAO().TodosNomes(vNome)
    End Function
    Public Function TodosCodigos() As List(Of Aluno)
        Return New AlunoDAO().TodosCodigos(vCodigo)
    End Function
    Public Function Consultar(ByVal pCod As String)
        Return New AlunoDAO().Consultar(pCod, Me)
    End Function
    Public Function UltimoCodigo()
        Return New AlunoDAO().UltimoCodigo(Me)
    End Function

#End Region

End Class