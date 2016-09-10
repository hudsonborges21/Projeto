Public Class Turma

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigo As Integer
    Private vNome As String
    Private vCurso As String
    Private vAnoIni As String
    Private vAnoFim As String
    Private vCatequistaCodigo As String
    Private vDataCadastro As Date

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

    Public Property Curso() As String
        Get
            Return vCurso
        End Get
        Set(ByVal value As String)
            vCurso = value
        End Set
    End Property


    Public Property AnoFim() As String
        Get
            Return vAnoFim
        End Get
        Set(ByVal value As String)
            vAnoFim = value
        End Set
    End Property

    Public Property AnoIni() As String
        Get
            Return vAnoIni
        End Get
        Set(ByVal value As String)
            vAnoIni = value
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
    Public Property CatequistaCodigo() As String
        Get
            Return vCatequistaCodigo
        End Get
        Set(ByVal value As String)
            vCatequistaCodigo = value
        End Set
    End Property

   
#End Region



#Region "Metodos"
    Public Sub Incluir()
        Call New TurmaDAO().Incluir(Me)
    End Sub

    Public Sub Alterar()
        Call New TurmaDAO().Alterar(Me)
    End Sub
    Public Sub Excluir()
        Call New TurmaDAO().Excluir(Me)
    End Sub

    Public Function Todos() As List(Of Turma)
        Return New TurmaDAO().Todos()
    End Function
    Public Function Consultar(ByVal pCod As String)
        Return New TurmaDAO().Consultar(pCod, Me)
    End Function
#End Region

End Class
