<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAluno
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
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnExluir = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TDataNasc = New System.Windows.Forms.MaskedTextBox()
        Me.tMae = New System.Windows.Forms.TextBox()
        Me.tPai = New System.Windows.Forms.TextBox()
        Me.tTelefone = New System.Windows.Forms.TextBox()
        Me.tNaturalidade = New System.Windows.Forms.TextBox()
        Me.TDataCad = New System.Windows.Forms.MaskedTextBox()
        Me.tCep = New System.Windows.Forms.TextBox()
        Me.Tcidade = New System.Windows.Forms.TextBox()
        Me.tBairro = New System.Windows.Forms.TextBox()
        Me.TEndereco = New System.Windows.Forms.TextBox()
        Me.TNome = New System.Windows.Forms.TextBox()
        Me.tCodigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(692, 475)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.BtnCancelar)
        Me.TabPage1.Controls.Add(Me.btnConfirmar)
        Me.TabPage1.Controls.Add(Me.btnExluir)
        Me.TabPage1.Controls.Add(Me.btnIncluir)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(684, 449)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastro"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Enabled = False
        Me.BtnCancelar.Location = New System.Drawing.Point(483, 342)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Enabled = False
        Me.btnConfirmar.Location = New System.Drawing.Point(402, 342)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 3
        Me.btnConfirmar.Text = "Confimar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnExluir
        '
        Me.btnExluir.Enabled = False
        Me.btnExluir.Location = New System.Drawing.Point(185, 342)
        Me.btnExluir.Name = "btnExluir"
        Me.btnExluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExluir.TabIndex = 2
        Me.btnExluir.Text = "Excluir"
        Me.btnExluir.UseVisualStyleBackColor = True
        '
        'btnIncluir
        '
        Me.btnIncluir.Enabled = False
        Me.btnIncluir.Location = New System.Drawing.Point(91, 342)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(75, 23)
        Me.btnIncluir.TabIndex = 1
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TDataNasc)
        Me.GroupBox1.Controls.Add(Me.tMae)
        Me.GroupBox1.Controls.Add(Me.tPai)
        Me.GroupBox1.Controls.Add(Me.tTelefone)
        Me.GroupBox1.Controls.Add(Me.tNaturalidade)
        Me.GroupBox1.Controls.Add(Me.TDataCad)
        Me.GroupBox1.Controls.Add(Me.tCep)
        Me.GroupBox1.Controls.Add(Me.Tcidade)
        Me.GroupBox1.Controls.Add(Me.tBairro)
        Me.GroupBox1.Controls.Add(Me.TEndereco)
        Me.GroupBox1.Controls.Add(Me.TNome)
        Me.GroupBox1.Controls.Add(Me.tCodigo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(64, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(531, 284)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TDataNasc
        '
        Me.TDataNasc.Location = New System.Drawing.Point(419, 13)
        Me.TDataNasc.Mask = "00/00/0000"
        Me.TDataNasc.Name = "TDataNasc"
        Me.TDataNasc.Size = New System.Drawing.Size(82, 20)
        Me.TDataNasc.TabIndex = 25
        Me.TDataNasc.ValidatingType = GetType(Date)
        '
        'tMae
        '
        Me.tMae.Location = New System.Drawing.Point(60, 191)
        Me.tMae.Name = "tMae"
        Me.tMae.Size = New System.Drawing.Size(441, 20)
        Me.tMae.TabIndex = 24
        '
        'tPai
        '
        Me.tPai.Location = New System.Drawing.Point(60, 162)
        Me.tPai.Name = "tPai"
        Me.tPai.Size = New System.Drawing.Size(441, 20)
        Me.tPai.TabIndex = 23
        '
        'tTelefone
        '
        Me.tTelefone.Location = New System.Drawing.Point(379, 131)
        Me.tTelefone.Name = "tTelefone"
        Me.tTelefone.Size = New System.Drawing.Size(122, 20)
        Me.tTelefone.TabIndex = 22
        '
        'tNaturalidade
        '
        Me.tNaturalidade.Location = New System.Drawing.Point(84, 131)
        Me.tNaturalidade.Name = "tNaturalidade"
        Me.tNaturalidade.Size = New System.Drawing.Size(234, 20)
        Me.tNaturalidade.TabIndex = 21
        '
        'TDataCad
        '
        Me.TDataCad.Location = New System.Drawing.Point(236, 13)
        Me.TDataCad.Mask = "00/00/0000"
        Me.TDataCad.Name = "TDataCad"
        Me.TDataCad.Size = New System.Drawing.Size(82, 20)
        Me.TDataCad.TabIndex = 19
        Me.TDataCad.ValidatingType = GetType(Date)
        '
        'tCep
        '
        Me.tCep.Location = New System.Drawing.Point(401, 105)
        Me.tCep.Name = "tCep"
        Me.tCep.Size = New System.Drawing.Size(100, 20)
        Me.tCep.TabIndex = 18
        '
        'Tcidade
        '
        Me.Tcidade.Location = New System.Drawing.Point(60, 102)
        Me.Tcidade.Name = "Tcidade"
        Me.Tcidade.Size = New System.Drawing.Size(258, 20)
        Me.Tcidade.TabIndex = 17
        '
        'tBairro
        '
        Me.tBairro.Location = New System.Drawing.Point(364, 76)
        Me.tBairro.Name = "tBairro"
        Me.tBairro.Size = New System.Drawing.Size(137, 20)
        Me.tBairro.TabIndex = 16
        '
        'TEndereco
        '
        Me.TEndereco.Location = New System.Drawing.Point(60, 72)
        Me.TEndereco.Name = "TEndereco"
        Me.TEndereco.Size = New System.Drawing.Size(258, 20)
        Me.TEndereco.TabIndex = 15
        '
        'TNome
        '
        Me.TNome.Location = New System.Drawing.Point(60, 43)
        Me.TNome.Name = "TNome"
        Me.TNome.Size = New System.Drawing.Size(441, 20)
        Me.TNome.TabIndex = 14
        '
        'tCodigo
        '
        Me.tCodigo.Enabled = False
        Me.tCodigo.Location = New System.Drawing.Point(60, 13)
        Me.tCodigo.Name = "tCodigo"
        Me.tCodigo.Size = New System.Drawing.Size(86, 20)
        Me.tCodigo.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Mãe"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Pai"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(60, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 45)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Batizado"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(66, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(45, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Não"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(18, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Sim"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(324, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Telefone"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Naturalidade"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(367, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "CEP"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cidade"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(324, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Bairro"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Endereço"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Data Nascimento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Data Cadastro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
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
        Me.TabPage2.Size = New System.Drawing.Size(684, 449)
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
        Me.GroupBox3.Location = New System.Drawing.Point(8, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(681, 58)
        Me.GroupBox3.TabIndex = 10
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
        Me.DataGridView1.Size = New System.Drawing.Size(681, 376)
        Me.DataGridView1.TabIndex = 0
        '
        'FormAluno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 475)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormAluno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catequista"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
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
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents btnExluir As System.Windows.Forms.Button
    Friend WithEvents btnIncluir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tMae As System.Windows.Forms.TextBox
    Friend WithEvents tPai As System.Windows.Forms.TextBox
    Friend WithEvents tTelefone As System.Windows.Forms.TextBox
    Friend WithEvents tNaturalidade As System.Windows.Forms.TextBox
    Friend WithEvents TDataCad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tCep As System.Windows.Forms.TextBox
    Friend WithEvents Tcidade As System.Windows.Forms.TextBox
    Friend WithEvents tBairro As System.Windows.Forms.TextBox
    Friend WithEvents TEndereco As System.Windows.Forms.TextBox
    Friend WithEvents TNome As System.Windows.Forms.TextBox
    Friend WithEvents tCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TDataNasc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnConsulta As System.Windows.Forms.Button
    Friend WithEvents txtConsulta As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tConsultaCodigo As System.Windows.Forms.TextBox
End Class
