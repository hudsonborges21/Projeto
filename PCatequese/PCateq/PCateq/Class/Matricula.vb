Public Class Matricula

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigoTurma As Integer
    Private vCodigoAluno As Integer
    Private vStatus As String
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
    Public Property CodigoAluno() As Integer
        Get
            Return vCodigoAluno
        End Get
        Set(ByVal value As Integer)
            vCodigoAluno = value
        End Set
    End Property

    Public Property Stautus() As String
        Get
            Return vStatus
        End Get
        Set(ByVal value As String)
            vStatus = (value)
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
        Call New MatriculaADO().Incluir(Me)
    End Sub

    Public Sub Alterar(ByVal codigoturma As String)
        Call New MatriculaADO().Alterar(codigoturma, Me)
    End Sub
    Public Sub Excluir()
        Call New MatriculaADO().Excluir(Me)
    End Sub

    Public Function Todos() As List(Of Matricula)
        Return New MatriculaADO().Todos()
    End Function
    Public Function Consultar(ByVal pCod As String, ByVal pcodAluno As String)
        Return New MatriculaADO().Consultar(pCod, pcodAluno, Me)
    End Function
    Public Function Consultar(ByVal pCod As String) As List(Of Matricula)
        Return New MatriculaADO().Consultar(pCod)
    End Function
#End Region

End Class
