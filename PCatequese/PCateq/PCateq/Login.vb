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

            Dim us As New Usuario
            us.Codigo = tusario.Text
            us.Consultar(us.Codigo)

            Dim cifrado As New clsCrypto()
            senhaCrip = cifrado.clsCrypto(tsenha.Text, True)

            If us.Senha = senhaCrip Then
                FormPrincipal.Show()
                Me.Visible = False
            Else
                MsgBox("Senha invalida.", MsgBoxStyle.Critical, "")
                tsenha.Focus()
            End If

        Catch ex As Exception
            MsgBox("Erro ao Consultar Usuario.", MsgBoxStyle.Critical, "")
        End Try
        
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
