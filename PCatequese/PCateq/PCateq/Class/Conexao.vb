Imports System.Data.SqlClient

Public Class Conexao

    'criando a string de conexao com o banco de dados
    Public vStrConexao As String

    'criando o construtor
    Public Sub New()
        vStrConexao = "Data Source=DESENV-HUDSON\SQLEXPRESS;Initial Catalog=DBCatequese;Integrated Security=True"
    End Sub


    Public Property StrConexao() As String
        Get
            Return vStrConexao
        End Get
        Set(ByVal value As String)
            vStrConexao = value
        End Set
    End Property

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(vStrConexao)
    End Function

End Class
