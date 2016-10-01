Public Class Aula

#Region "Atributos"

    'declarando os atributos da classe produto
    Private vCodigoTurma As Integer
    Private vCodigoAula As Integer
    Private vDescricao As String
    Private vDataCadastro As Date

    'Dados aluno turma
    Private vcodigoAluno As Integer
    Private vAlunoNome As String
    Private vPresenca As String


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

    Public Property CodigoAluno() As Integer
        Get
            Return vcodigoAluno
        End Get
        Set(value As Integer)
            vcodigoAluno = value
        End Set
    End Property
    Public Property Aluno() As String
        Get
            Return vAlunoNome
        End Get
        Set(ByVal value As String)
            vAlunoNome = (value)
        End Set
    End Property
    Public Property Presenca() As Boolean
        Get
            Return vPresenca
        End Get
        Set(ByVal value As Boolean)
            vPresenca = (value)
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
    Public Function TodosAlunosTurma()
        Return New AulaDAO().TodosAlunosTurma(vCodigoAula)
    End Function
    Public Function ConsultarAlunoPresenca()
        Return New AulaDAO().ConsultarPresenca(vcodigoAluno, vCodigoAula, Me)
    End Function
#End Region
#Region "Metodos Frequencia"
    Public Sub IncluirFrequencia()
        Call New AulaDAO().IncluirFrequencia(Me)
    End Sub

    Public Sub AlterarFrequencia()
        Call New AulaDAO().AlterarFrequencia(Me)
    End Sub
 
#End Region
End Class
