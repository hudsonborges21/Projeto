Module Module1
    Public Sub Limpar(ByVal controlP As Control)

        Dim ctl As Control

        For Each ctl In controlP.Controls

            If TypeOf ctl Is TextBox Then

                DirectCast(ctl, TextBox).Text = String.Empty

            ElseIf ctl.Controls.Count > 0 Then

                Limpar(ctl)

            End If

        Next

    End Sub

    Public Function CriarCampo(ByVal campo As String, ByVal titulo As String, ByVal tamanho As String)
        Dim col1 = New DataGridViewTextBoxColumn()
        col1.Name = campo
        col1.HeaderText = titulo
        col1.DataPropertyName = campo
        col1.ReadOnly = True
        col1.SortMode = DataGridViewColumnSortMode.Automatic
        col1.Width = tamanho

        Return col1
    End Function
    Public Function CriarCampoCheck(ByVal campo As String, ByVal titulo As String, ByVal tamanho As String)
        Dim col1 = New DataGridViewCheckBoxColumn()
        col1.Name = campo
        col1.HeaderText = titulo
        col1.DataPropertyName = campo
        col1.ReadOnly = True
        col1.SortMode = DataGridViewColumnSortMode.Automatic
        col1.Width = tamanho

        Return col1
    End Function

    'Public Function CriarCampo(ByVal campo As String)
    '    Return CriarCampo(campo, campo)
    'End Function
End Module
