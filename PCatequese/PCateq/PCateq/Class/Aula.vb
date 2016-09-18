Public Class Aula

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigoTurma As Integer
    Private vCodigoAula As Integer
    Private vDescricao As String
    Private vDataCadastro As Date


#End Region


#Region "Propriedades"


    'criando propriedade para encapsular os atributos do classe
    Public Property CodigoTurma() As Integer
        Get
            Return vCodigoTurma
        End Get
        Set(ByVal value As Integer)
            vCodigoTurma = value
        End Set
    End Property
    Public Property CodigoAula() As Integer
        Get
            Return vCodigoAula
        End Get
        Set(ByVal value As Integer)
            vCodigoAula = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return vDescricao
        End Get
        Set(ByVal value As String)
            vDescricao = (value)
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



#End Region

#Region "Metodos"
    Public Sub Incluir()
        Call New AulaDAO().Incluir(Me)
    End Sub

    Public Sub Alterar()
        Call New AulaDAO().Alterar(Me)
    End Sub
    Public Sub Excluir()
        Call New AulaDAO().Excluir(Me)
    End Sub

    Public Function Todos() As List(Of Aula)
        Return New AulaDAO().Todos()
    End Function
    Public Function Consultar()
        Return New AulaDAO().Consultar(vCodigoAula, Me)
    End Function
    Public Function ConsultarTurmaAula(ByVal pCod As String) As List(Of Aula)
        Return New AulaDAO().ConsultarAulasTurma(pCod)
    End Function
#End Region
End Class
