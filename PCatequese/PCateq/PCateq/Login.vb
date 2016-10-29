Public Class Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Dim senhaCrip As String

            '***** USUARIO PADRAO PARA COMEÇAR A COFIGURAR O SISTEMA
            '***** USUARIO USANDO QUANDO NAO HA CADASTRO DO BANCO DE DADOS
            If tusario.Text = "99" And tsenha.Text = "99" Then
                FormPrincipal.Show()
                Me.Visible = False

            Else
                'CRIAR O OBJE E INSTANCIA DA CLASSE USUARIO
                'PEGA DADO SO USUARIO
                Dim us As New Usuario
                us.Codigo = tusario.Text
                us.Consultar(us.Codigo)

                'CRIPTOGRA A SENHA
                Dim cifrado As New clsCrypto()
                senhaCrip = cifrado.clsCrypto(tsenha.Text, True)

                'VERIFIA SE A CRIPTOGRAFIA É IGUAL A SENHA( JÁ CRIPTOGRAFADA NO BANCO)
                'OU SEJA PEGAS A SENHA DIGITA CRIPTOGRAFA
                ' E COMPRA ELA COM A SENHA NO CAMPO, SE FOR IGUAL É A MESMA SENHA, SENAO ESTA ERRADA
                If us.Senha = senhaCrip Then
                    FormPrincipal.Show()
                    Me.Visible = False
                Else
                    MsgBox("Senha invalida.", MsgBoxStyle.Critical, "")
                    tsenha.Focus()
                End If

            End If

      
        Catch ex As Exception
            MsgBox("Erro ao Consultar Usuario.", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
