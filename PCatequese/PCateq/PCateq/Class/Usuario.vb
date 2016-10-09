Public Class Usuario

#Region "Atributos"

    Private vCodigo As Integer
    Private vNome As String

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
