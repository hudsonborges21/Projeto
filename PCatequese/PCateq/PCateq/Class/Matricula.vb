Public Class Matricula

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigoTurma As Integer
    Private vCodigoAluno As Integer
    Private vStatus As String
    Private vDataCadastro As Date

    'Frequencia de Aulas
    Private vQtdeAula As Integer
    Private vQtdePresenca As Integer
    Private vQtdeFalta As Integer
    Private vMediaPresenca As Double

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

    Public Property Status() As String
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
   
    Public Property QtdeAula() As Integer
        Get
            Return vQtdeAula
        End Get
        Set(value As Integer)
            vQtdeAula = value
        End Set
    End Property
    Public Property QtdePresenca() As Integer
        Get
            Return vQtdePresenca
        End Get
        Set(value As Integer)
            vQtdePresenca = value
        End Set
    End Property
    Public Property Qtdefalta() As Integer
        Get
            Return vQtdeFalta
        End Get
        Set(value As Integer)
            vQtdeFalta = value
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
    Public Function TodosAlunosTurma() As List(Of Matricula)
        Return New MatriculaADO().TodosAlunosTurma(vCodigoTurma)
    End Function

    Public Function ConsultarQtdeAula(ByVal pCod As String)
        Return New MatriculaADO().ConsultarQtdeAula(pCod, Me)
    End Function
    Public Function ConsultarQtdePresenca(ByVal pcodturma As String, ByVal pCodAluno As String)
        Return New MatriculaADO().ConsultarQtdePresenca(pcodturma, pCodAluno, Me)
    End Function
    Public Function ConsultarQtdeFaltas(ByVal pcodturma As String, ByVal pCodAluno As String)
        Return New MatriculaADO().ConsultarQtdeFaltas(pcodturma, pCodAluno, Me)
    End Function
#End Region

End Class
