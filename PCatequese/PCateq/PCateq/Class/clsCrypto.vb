Public Class clsCrypto
    '**** site
    'http://www.macoratti.net/vbn_secu.htm
    'VB .NET - Criando código mais seguro

    Dim myKey As String
    Dim des As New Security.Cryptography.TripleDESCryptoServiceProvider()
    Dim hashmd5 As New Security.Cryptography.MD5CryptoServiceProvider()

    Public Sub New()
        'Inserir o codigo de configuração da classe
        myKey = "Macoratti"
    End Sub

    Public Function clsCrypto(ByVal texto As String, ByVal Operacao As Boolean) As String
        If Operacao Then
            clsCrypto = Cifra(texto)
        Else
            clsCrypto = DeCifra(texto)
        End If
    End Function

    Private Function DeCifra(ByVal texto As String) As String

        DES.Key = hashmd5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(myKey))
        DES.Mode = Security.Cryptography.CipherMode.ECB
        Dim desdencrypt As Security.Cryptography.ICryptoTransform = DES.CreateDecryptor()
        Dim buff() As Byte = Convert.FromBase64String(texto)
        DeCifra = System.Text.ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))

    End Function

    Private Function Cifra(ByVal texto As String) As String
        des.Key = hashmd5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(myKey))
        des.Mode = Security.Cryptography.CipherMode.ECB
        Dim desdencrypt As Security.Cryptography.ICryptoTransform = des.CreateEncryptor()
        Dim MyASCIIEncoding = New System.Text.ASCIIEncoding()
        Dim buff() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(texto)
        Cifra = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))
    End Function
End Class
