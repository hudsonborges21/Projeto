<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTurma
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.btnExluir = New System.Windows.Forms.Button()
        Me.BtNIncluir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TCatequistaCodigo = New System.Windows.Forms.TextBox()
        Me.TCatequistaNome = New System.Windows.Forms.TextBox()
        Me.tAnoFim = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TAnoINI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tDescricao = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tcurso = New System.Windows.Forms.TextBox()
        Me.tCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tConsultaCodigo = New System.Windows.Forms.TextBox()
        Me.BtnConsulta = New System.Windows.Forms.Button()
        Me.txtConsulta = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TData = New System.Windows.Forms.MaskedTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(708, 511)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.BtnCancelar)
        Me.TabPage1.Controls.Add(Me.BtnConfirmar)
        Me.TabPage1.Controls.Add(Me.btnExluir)
        Me.TabPage1.Controls.Add(Me.BtNIncluir)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(700, 485)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridView2)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(6, 232)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(680, 200)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Aulas"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(2, 19)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(672, 175)
        Me.DataGridView2.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Orange
        Me.Label13.Location = New System.Drawing.Point(9, 429)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(669, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "F1 - Catequista     |   F2 - Aula Incluir   |     F3 - Aula Editar   |    F4 - Au" & _
    "la Excluir   |     F5 - Frequência"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(474, 454)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.Location = New System.Drawing.Point(393, 454)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.BtnConfirmar.TabIndex = 9
        Me.BtnConfirmar.Text = "Confirmar"
        Me.BtnConfirmar.UseVisualStyleBackColor = True
        '
        'btnExluir
        '
        Me.btnExluir.Location = New System.Drawing.Point(176, 454)
        Me.btnExluir.Name = "btnExluir"
        Me.btnExluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExluir.TabIndex = 8
        Me.btnExluir.Text = "Excluir"
        Me.btnExluir.UseVisualStyleBackColor = True
        '
        'BtNIncluir
        '
        Me.BtNIncluir.Location = New System.Drawing.Point(82, 454)
        Me.BtNIncluir.Name = "BtNIncluir"
        Me.BtNIncluir.Size = New System.Drawing.Size(75, 23)
        Me.BtNIncluir.TabIndex = 7
        Me.BtNIncluir.Text = "Incluir"
        Me.BtNIncluir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TData)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tAnoFim)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TAnoINI)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tDescricao)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tcurso)
        Me.GroupBox1.Controls.Add(Me.tCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(684, 220)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TCatequistaCodigo)
        Me.GroupBox2.Controls.Add(Me.TCatequistaNome)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 161)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 51)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Catequista"
        '
        'TCatequistaCodigo
        '
        Me.TCatequistaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCatequistaCodigo.Location = New System.Drawing.Point(73, 19)
        Me.TCatequistaCodigo.Name = "TCatequistaCodigo"
        Me.TCatequistaCodigo.Size = New System.Drawing.Size(88, 20)
        Me.TCatequistaCodigo.TabIndex = 6
        '
        'TCatequistaNome
        '
        Me.TCatequistaNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCatequistaNome.Enabled = False
        Me.TCatequistaNome.Location = New System.Drawing.Point(167, 19)
        Me.TCatequistaNome.Name = "TCatequistaNome"
        Me.TCatequistaNome.Size = New System.Drawing.Size(366, 20)
        Me.TCatequistaNome.TabIndex = 22
        '
        'tAnoFim
        '
        Me.tAnoFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tAnoFim.Location = New System.Drawing.Point(327, 99)
        Me.tAnoFim.Name = "tAnoFim"
        Me.tAnoFim.Size = New System.Drawing.Size(86, 20)
        Me.tAnoFim.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(266, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Ano / Fim"
        '
        'TAnoINI
        '
        Me.TAnoINI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TAnoINI.Location = New System.Drawing.Point(118, 99)
        Me.TAnoINI.Name = "TAnoINI"
        Me.TAnoINI.Size = New System.Drawing.Size(86, 20)
        Me.TAnoINI.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Ano / Inicio"
        '
        'tDescricao
        '
        Me.tDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tDescricao.Location = New System.Drawing.Point(118, 73)
        Me.tDescricao.Name = "tDescricao"
        Me.tDescricao.Size = New System.Drawing.Size(408, 20)
        Me.tDescricao.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Descrição"
        '
        'tcurso
        '
        Me.tcurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tcurso.Location = New System.Drawing.Point(118, 43)
        Me.tcurso.Name = "tcurso"
        Me.tcurso.Size = New System.Drawing.Size(408, 20)
        Me.tcurso.TabIndex = 2
        '
        'tCodigo
        '
        Me.tCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCodigo.Location = New System.Drawing.Point(118, 13)
        Me.tCodigo.Name = "tCodigo"
        Me.tCodigo.Size = New System.Drawing.Size(86, 20)
        Me.tCodigo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(246, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Data Cadastro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Curso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(700, 485)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pesquisa"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.tConsultaCodigo)
        Me.GroupBox3.Controls.Add(Me.BtnConsulta)
        Me.GroupBox3.Controls.Add(Me.txtConsulta)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 419)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(681, 58)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pesquisar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(491, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Código"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tConsultaCodigo
        '
        Me.tConsultaCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tConsultaCodigo.Location = New System.Drawing.Point(383, 32)
        Me.tConsultaCodigo.Name = "tConsultaCodigo"
        Me.tConsultaCodigo.Size = New System.Drawing.Size(102, 20)
        Me.tConsultaCodigo.TabIndex = 4
        Me.tConsultaCodigo.Visible = False
        '
        'BtnConsulta
        '
        Me.BtnConsulta.Location = New System.Drawing.Point(252, 29)
        Me.BtnConsulta.Name = "BtnConsulta"
        Me.BtnConsulta.Size = New System.Drawing.Size(75, 23)
        Me.BtnConsulta.TabIndex = 1
        Me.BtnConsulta.Text = "Nome"
        Me.BtnConsulta.UseVisualStyleBackColor = True
        '
        'txtConsulta
        '
        Me.txtConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsulta.Location = New System.Drawing.Point(6, 32)
        Me.txtConsulta.Name = "txtConsulta"
        Me.txtConsulta.Size = New System.Drawing.Size(240, 20)
        Me.txtConsulta.TabIndex = 0
        Me.txtConsulta.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(681, 410)
        Me.DataGridView1.TabIndex = 0
        '
        'TData
        '
        Me.TData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TData.Location = New System.Drawing.Point(327, 13)
        Me.TData.Mask = "00/00/0000"
        Me.TData.Name = "TData"
        Me.TData.Size = New System.Drawing.Size(82, 20)
        Me.TData.TabIndex = 27
        Me.TData.ValidatingType = GetType(Date)
        '
        'FormTurma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(708, 511)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FormTurma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Turma"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
    Friend WithEvents btnExluir As System.Windows.Forms.Button
    Friend WithEvents BtNIncluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TCatequistaNome As System.Windows.Forms.TextBox
    Friend WithEvents tAnoFim As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TAnoINI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tDescricao As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tcurso As System.Windows.Forms.TextBox
    Friend WithEvents tCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tConsultaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents BtnConsulta As System.Windows.Forms.Button
    Friend WithEvents txtConsulta As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TCatequistaCodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TData As System.Windows.Forms.MaskedTextBox
End Class
