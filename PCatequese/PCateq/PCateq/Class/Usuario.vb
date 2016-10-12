Public Class Usuario

#Region "Atributos"

    Private vCodigo As Integer
    Private vNome As String
    Private vDataCadastro As Date
    Private vSenha As String

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

    Public Property DataCad() As Date
        Get
            Return vDataCadastro
        End Get
        Set(ByVal value As Date)
            vDataCadastro = value
        End Set
    End Property
    Public Property Senha() As String
        Get
            Return vSenha
        End Get
        Set(ByVal value As String)
            vSenha = value
        End Set
    End Property

#End Region


#Region "Metodos"
    Public Sub Incluir()
        Call New UsuarioDAO().Incluir(Me)
    End Sub

    Public Sub Alterar()
        Call New UsuarioDAO().Alterar(Me)
    End Sub
    Public Sub Excluir()
        Call New UsuarioDAO().Excluir(Me)
    End Sub

    Public Function Todos() As List(Of Usuario)
        Return New UsuarioDAO().Todos()
    End Function
    Public Function TodosNomes() As List(Of Usuario)
        Return New UsuarioDAO().TodosNomes(vNome)
    End Function
    Public Function TodosCodigos() As List(Of Usuario)
        Return New UsuarioDAO().TodosCodigos(vCodigo)
    End Function
    Public Function Consultar(ByVal pCod As String)
        Return New UsuarioDAO().Consultar(pCod, Me)
    End Function
    Public Function UltimoCodigo()
        Return New UsuarioDAO().UltimoCodigo(Me)
    End Function

#End Region

End Class
