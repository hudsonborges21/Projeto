<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelTurma
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnListaPresenca = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(33, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 24)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Lista de Turma"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TTurmaDescricao)
        Me.GroupBox1.Controls.Add(Me.TturmaCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 60)
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
        Me.TTurmaDescricao.Size = New System.Drawing.Size(323, 20)
        Me.TTurmaDescricao.TabIndex = 9
        '
        'TturmaCodigo
        '
        Me.TturmaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TturmaCodigo.Location = New System.Drawing.Point(20, 30)
        Me.TturmaCodigo.Name = "TturmaCodigo"
        Me.TturmaCodigo.Size = New System.Drawing.Size(57, 20)
        Me.TturmaCodigo.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(154, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 24)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Lista de Aulas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnListaPresenca
        '
        Me.btnListaPresenca.Location = New System.Drawing.Point(275, 108)
        Me.btnListaPresenca.Name = "btnListaPresenca"
        Me.btnListaPresenca.Size = New System.Drawing.Size(115, 24)
        Me.btnListaPresenca.TabIndex = 9
        Me.btnListaPresenca.Text = "Lista de Presença"
        Me.btnListaPresenca.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(9, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(440, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "F1 - Turma"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormRelTurma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 141)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnListaPresenca)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FormRelTurma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatórios Turma"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TTurmaDescricao As System.Windows.Forms.TextBox
    Friend WithEvents TturmaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnListaPresenca As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
