<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAniversarios
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TTurmaDescricao = New System.Windows.Forms.TextBox()
        Me.TturmaCodigo = New System.Windows.Forms.TextBox()
        Me.TDataI = New System.Windows.Forms.MaskedTextBox()
        Me.TDataF = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(95, 177)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 24)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Confirmar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TTurmaDescricao)
        Me.GroupBox1.Controls.Add(Me.TturmaCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(409, 70)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Turma"
        '
        'TTurmaDescricao
        '
        Me.TTurmaDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTurmaDescricao.Enabled = False
        Me.TTurmaDescricao.Location = New System.Drawing.Point(83, 30)
        Me.TTurmaDescricao.Name = "TTurmaDescricao"
        Me.TTurmaDescricao.Size = New System.Drawing.Size(287, 20)
        Me.TTurmaDescricao.TabIndex = 9
        '
        'TturmaCodigo
        '
        Me.TturmaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TturmaCodigo.Location = New System.Drawing.Point(20, 30)
        Me.TturmaCodigo.Name = "TturmaCodigo"
        Me.TturmaCodigo.Size = New System.Drawing.Size(57, 20)
        Me.TturmaCodigo.TabIndex = 0
        '
        'TDataI
        '
        Me.TDataI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDataI.Location = New System.Drawing.Point(95, 88)
        Me.TDataI.Mask = "00/00/0000"
        Me.TDataI.Name = "TDataI"
        Me.TDataI.Size = New System.Drawing.Size(82, 20)
        Me.TDataI.TabIndex = 1
        Me.TDataI.ValidatingType = GetType(Date)
        '
        'TDataF
        '
        Me.TDataF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDataF.Location = New System.Drawing.Point(95, 114)
        Me.TDataF.Mask = "00/00/0000"
        Me.TDataF.Name = "TDataF"
        Me.TDataF.Size = New System.Drawing.Size(82, 20)
        Me.TDataF.TabIndex = 2
        Me.TDataF.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Data Inicial:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Data Final:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(9, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(420, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "F1 - Turma"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CBStatus
        '
        Me.CBStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBStatus.FormattingEnabled = True
        Me.CBStatus.Items.AddRange(New Object() {"Concluído", "Cursando", "Reprovado", "Todos"})
        Me.CBStatus.Location = New System.Drawing.Point(257, 113)
        Me.CBStatus.Name = "CBStatus"
        Me.CBStatus.Size = New System.Drawing.Size(125, 21)
        Me.CBStatus.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Status"
        '
        'FormAniversarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 213)
        Me.Controls.Add(Me.CBStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TDataF)
        Me.Controls.Add(Me.TDataI)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FormAniversarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatórios de Aniversarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TTurmaDescricao As System.Windows.Forms.TextBox
    Friend WithEvents TturmaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TDataI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TDataF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
