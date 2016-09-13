<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatricula
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TStatus = New System.Windows.Forms.TextBox()
        Me.TDataCad = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TTurmaDescricao = New System.Windows.Forms.TextBox()
        Me.TturmaCodigo = New System.Windows.Forms.TextBox()
        Me.tNome = New System.Windows.Forms.TextBox()
        Me.tCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmatricula = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TStatus)
        Me.GroupBox3.Controls.Add(Me.TDataCad)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TTurmaDescricao)
        Me.GroupBox3.Controls.Add(Me.TturmaCodigo)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(388, 121)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Turma"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Status"
        '
        'TStatus
        '
        Me.TStatus.Location = New System.Drawing.Point(97, 78)
        Me.TStatus.Name = "TStatus"
        Me.TStatus.Size = New System.Drawing.Size(131, 20)
        Me.TStatus.TabIndex = 22
        '
        'TDataCad
        '
        Me.TDataCad.Location = New System.Drawing.Point(97, 52)
        Me.TDataCad.Mask = "00/00/0000"
        Me.TDataCad.Name = "TDataCad"
        Me.TDataCad.Size = New System.Drawing.Size(82, 20)
        Me.TDataCad.TabIndex = 21
        Me.TDataCad.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Data Matrícula"
        '
        'TTurmaDescricao
        '
        Me.TTurmaDescricao.Location = New System.Drawing.Point(72, 17)
        Me.TTurmaDescricao.Name = "TTurmaDescricao"
        Me.TTurmaDescricao.Size = New System.Drawing.Size(287, 20)
        Me.TTurmaDescricao.TabIndex = 4
        '
        'TturmaCodigo
        '
        Me.TturmaCodigo.Location = New System.Drawing.Point(9, 17)
        Me.TturmaCodigo.Name = "TturmaCodigo"
        Me.TturmaCodigo.Size = New System.Drawing.Size(57, 20)
        Me.TturmaCodigo.TabIndex = 3
        '
        'tNome
        '
        Me.tNome.Location = New System.Drawing.Point(72, 17)
        Me.tNome.Name = "tNome"
        Me.tNome.Size = New System.Drawing.Size(287, 20)
        Me.tNome.TabIndex = 4
        '
        'tCodigo
        '
        Me.tCodigo.Location = New System.Drawing.Point(9, 17)
        Me.tCodigo.Name = "tCodigo"
        Me.tCodigo.Size = New System.Drawing.Size(57, 20)
        Me.tCodigo.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Info
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.tmatricula)
        Me.GroupBox4.Controls.Add(Me.tNome)
        Me.GroupBox4.Controls.Add(Me.tCodigo)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(388, 86)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Aluno"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nº Matrícula:"
        '
        'tmatricula
        '
        Me.tmatricula.Location = New System.Drawing.Point(88, 56)
        Me.tmatricula.Name = "tmatricula"
        Me.tmatricula.Size = New System.Drawing.Size(131, 20)
        Me.tmatricula.TabIndex = 5
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Enabled = False
        Me.BtnCancelar.Location = New System.Drawing.Point(290, 231)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Enabled = False
        Me.btnConfirmar.Location = New System.Drawing.Point(209, 231)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 5
        Me.btnConfirmar.Text = "Confimar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'FormMatricula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 266)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FormMatricula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Matricula"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TTurmaDescricao As System.Windows.Forms.TextBox
    Friend WithEvents TturmaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents tNome As System.Windows.Forms.TextBox
    Friend WithEvents tCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmatricula As System.Windows.Forms.TextBox
    Friend WithEvents TDataCad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TStatus As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
End Class
