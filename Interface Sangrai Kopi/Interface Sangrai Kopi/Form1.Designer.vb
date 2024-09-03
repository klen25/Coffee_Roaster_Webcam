<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnstart = New System.Windows.Forms.Button()
        Me.btnstop = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btncapture = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.comboport = New System.Windows.Forms.ComboBox()
        Me.btnconnect = New System.Windows.Forms.Button()
        Me.lightroasts = New System.Windows.Forms.RadioButton()
        Me.mediumroast = New System.Windows.Forms.RadioButton()
        Me.meddarkroasts = New System.Windows.Forms.RadioButton()
        Me.darkroasts = New System.Windows.Forms.RadioButton()
        Me.grupdefinisi = New System.Windows.Forms.GroupBox()
        Me.lbljudul = New System.Windows.Forms.Label()
        Me.lbldefinisi = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupdefinisi.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(211, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(520, 400)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnstart
        '
        Me.btnstart.Location = New System.Drawing.Point(12, 164)
        Me.btnstart.Name = "btnstart"
        Me.btnstart.Size = New System.Drawing.Size(75, 23)
        Me.btnstart.TabIndex = 1
        Me.btnstart.Text = "Start"
        Me.btnstart.UseVisualStyleBackColor = True
        '
        'btnstop
        '
        Me.btnstop.Location = New System.Drawing.Point(12, 193)
        Me.btnstop.Name = "btnstop"
        Me.btnstop.Size = New System.Drawing.Size(75, 23)
        Me.btnstop.TabIndex = 2
        Me.btnstop.Text = "Stop"
        Me.btnstop.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 107)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(193, 43)
        Me.ListBox1.TabIndex = 3
        '
        'btncapture
        '
        Me.btncapture.Location = New System.Drawing.Point(130, 164)
        Me.btncapture.Name = "btncapture"
        Me.btncapture.Size = New System.Drawing.Size(75, 23)
        Me.btncapture.TabIndex = 4
        Me.btncapture.Text = "Capture"
        Me.btncapture.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(130, 193)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(746, 260)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(494, 316)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(130, 41)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 8
        Me.btnrefresh.Text = "REFRESH"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'comboport
        '
        Me.comboport.FormattingEnabled = True
        Me.comboport.Location = New System.Drawing.Point(12, 41)
        Me.comboport.Name = "comboport"
        Me.comboport.Size = New System.Drawing.Size(112, 21)
        Me.comboport.TabIndex = 9
        '
        'btnconnect
        '
        Me.btnconnect.Location = New System.Drawing.Point(12, 68)
        Me.btnconnect.Name = "btnconnect"
        Me.btnconnect.Size = New System.Drawing.Size(75, 23)
        Me.btnconnect.TabIndex = 10
        Me.btnconnect.Text = "CONNECT"
        Me.btnconnect.UseVisualStyleBackColor = True
        '
        'lightroasts
        '
        Me.lightroasts.AutoSize = True
        Me.lightroasts.Location = New System.Drawing.Point(12, 222)
        Me.lightroasts.Name = "lightroasts"
        Me.lightroasts.Size = New System.Drawing.Size(84, 17)
        Me.lightroasts.TabIndex = 11
        Me.lightroasts.TabStop = True
        Me.lightroasts.Text = "Light Roasts"
        Me.lightroasts.UseVisualStyleBackColor = True
        '
        'mediumroast
        '
        Me.mediumroast.AutoSize = True
        Me.mediumroast.Location = New System.Drawing.Point(12, 252)
        Me.mediumroast.Name = "mediumroast"
        Me.mediumroast.Size = New System.Drawing.Size(98, 17)
        Me.mediumroast.TabIndex = 12
        Me.mediumroast.TabStop = True
        Me.mediumroast.Text = "Medium Roasts"
        Me.mediumroast.UseVisualStyleBackColor = True
        '
        'meddarkroasts
        '
        Me.meddarkroasts.AutoSize = True
        Me.meddarkroasts.Location = New System.Drawing.Point(12, 285)
        Me.meddarkroasts.Name = "meddarkroasts"
        Me.meddarkroasts.Size = New System.Drawing.Size(124, 17)
        Me.meddarkroasts.TabIndex = 13
        Me.meddarkroasts.TabStop = True
        Me.meddarkroasts.Text = "Medium-Dark Roasts"
        Me.meddarkroasts.UseVisualStyleBackColor = True
        '
        'darkroasts
        '
        Me.darkroasts.AutoSize = True
        Me.darkroasts.Location = New System.Drawing.Point(12, 322)
        Me.darkroasts.Name = "darkroasts"
        Me.darkroasts.Size = New System.Drawing.Size(84, 17)
        Me.darkroasts.TabIndex = 14
        Me.darkroasts.TabStop = True
        Me.darkroasts.Text = "Dark Roasts"
        Me.darkroasts.UseVisualStyleBackColor = True
        '
        'grupdefinisi
        '
        Me.grupdefinisi.Controls.Add(Me.lbljudul)
        Me.grupdefinisi.Controls.Add(Me.lbldefinisi)
        Me.grupdefinisi.Controls.Add(Me.PictureBox3)
        Me.grupdefinisi.Location = New System.Drawing.Point(737, 12)
        Me.grupdefinisi.Name = "grupdefinisi"
        Me.grupdefinisi.Size = New System.Drawing.Size(429, 299)
        Me.grupdefinisi.TabIndex = 15
        Me.grupdefinisi.TabStop = False
        '
        'lbljudul
        '
        Me.lbljudul.Location = New System.Drawing.Point(116, 16)
        Me.lbljudul.Name = "lbljudul"
        Me.lbljudul.Size = New System.Drawing.Size(196, 23)
        Me.lbljudul.TabIndex = 2
        '
        'lbldefinisi
        '
        Me.lbldefinisi.Location = New System.Drawing.Point(283, 56)
        Me.lbldefinisi.Name = "lbldefinisi"
        Me.lbldefinisi.Size = New System.Drawing.Size(140, 232)
        Me.lbldefinisi.TabIndex = 1
        Me.lbldefinisi.Text = "Definisi"
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(11, 56)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(217, 232)
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(130, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Deteksi Tepi"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 579)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grupdefinisi)
        Me.Controls.Add(Me.darkroasts)
        Me.Controls.Add(Me.meddarkroasts)
        Me.Controls.Add(Me.mediumroast)
        Me.Controls.Add(Me.lightroasts)
        Me.Controls.Add(Me.btnconnect)
        Me.Controls.Add(Me.comboport)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncapture)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnstop)
        Me.Controls.Add(Me.btnstart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupdefinisi.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnstart As System.Windows.Forms.Button
    Friend WithEvents btnstop As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btncapture As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents comboport As System.Windows.Forms.ComboBox
    Friend WithEvents btnconnect As System.Windows.Forms.Button
    Friend WithEvents lightroasts As System.Windows.Forms.RadioButton
    Friend WithEvents mediumroast As System.Windows.Forms.RadioButton
    Friend WithEvents meddarkroasts As System.Windows.Forms.RadioButton
    Friend WithEvents darkroasts As System.Windows.Forms.RadioButton
    Friend WithEvents grupdefinisi As System.Windows.Forms.GroupBox
    Friend WithEvents lbldefinisi As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lbljudul As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
