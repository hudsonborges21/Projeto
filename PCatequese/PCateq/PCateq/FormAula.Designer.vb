<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAula
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tDescricao = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TAulaDescricao = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TAulaCodigo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TAulaData = New System.Windows.Forms.MaskedTextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.tDescricao)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tCodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(523, 86)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Turma"
        '
        'tDescricao
        '
        Me.tDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescricao.Enabled = False
        Me.tDescricao.Location = New System.Drawing.Point(100, 54)
        Me.tDescricao.Name = "tDescricao"
        Me.tDescricao.Size = New System.Drawing.Size(408, 20)
        Me.tDescricao.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Descrição"
        '
        'tCodigo
        '
        Me.tCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCodigo.Enabled = False
        Me.tCodigo.Location = New System.Drawing.Point(100, 25)
        Me.tCodigo.Name = "tCodigo"
        Me.tCodigo.Size = New System.Drawing.Size(86, 20)
        Me.tCodigo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TAulaData)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TAulaDescricao)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TAulaCodigo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(523, 123)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Aula"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Data"
        '
        'TAulaDescricao
        '
        Me.TAulaDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAulaDescricao.Location = New System.Drawing.Point(100, 54)
        Me.TAulaDescricao.Name = "TAulaDescricao"
        Me.TAulaDescricao.Size = New System.Drawing.Size(408, 20)
        Me.TAulaDescricao.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Descrição"
        '
        'TAulaCodigo
        '
        Me.TAulaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAulaCodigo.Enabled = False
        Me.TAulaCodigo.Location = New System.Drawing.Point(100, 25)
        Me.TAulaCodigo.Name = "TAulaCodigo"
        Me.TAulaCodigo.Size = New System.Drawing.Size(86, 20)
        Me.TAulaCodigo.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(54, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Código"
        '
        'TAulaData
        '
        Me.TAulaData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAulaData.Location = New System.Drawing.Point(100, 84)
        Me.TAulaData.Mask = "00/00/0000"
        Me.TAulaData.Name = "TAulaData"
        Me.TAulaData.Size = New System.Drawing.Size(82, 20)
        Me.TAulaData.TabIndex = 23
        Me.TAulaData.ValidatingType = GetType(Date)
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(424, 233)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(332, 233)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 5
        Me.btnConfirmar.Text = "Confimar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'FormAula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 265)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FormAula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cadastrar Aula"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TAulaDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TAulaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TAulaData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
End Class
