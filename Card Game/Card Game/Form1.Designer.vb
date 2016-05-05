<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTestP = New System.Windows.Forms.Label()
        Me.lblTestT = New System.Windows.Forms.Label()
        Me.lblNumCreatures = New System.Windows.Forms.Label()
        Me.btnViewHand = New System.Windows.Forms.Button()
        Me.tmrUpdater = New System.Windows.Forms.Timer(Me.components)
        Me.btnMulligan = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblMana = New System.Windows.Forms.Label()
        Me.lblManaStatus = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnTS = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTestP
        '
        Me.lblTestP.AutoSize = True
        Me.lblTestP.Location = New System.Drawing.Point(332, 9)
        Me.lblTestP.Name = "lblTestP"
        Me.lblTestP.Size = New System.Drawing.Size(39, 13)
        Me.lblTestP.TabIndex = 1
        Me.lblTestP.Text = "Label1"
        '
        'lblTestT
        '
        Me.lblTestT.AutoSize = True
        Me.lblTestT.Location = New System.Drawing.Point(438, 21)
        Me.lblTestT.Name = "lblTestT"
        Me.lblTestT.Size = New System.Drawing.Size(39, 13)
        Me.lblTestT.TabIndex = 2
        Me.lblTestT.Text = "Label2"
        '
        'lblNumCreatures
        '
        Me.lblNumCreatures.AutoSize = True
        Me.lblNumCreatures.Location = New System.Drawing.Point(399, 61)
        Me.lblNumCreatures.Name = "lblNumCreatures"
        Me.lblNumCreatures.Size = New System.Drawing.Size(39, 13)
        Me.lblNumCreatures.TabIndex = 3
        Me.lblNumCreatures.Text = "Label1"
        '
        'btnViewHand
        '
        Me.btnViewHand.Location = New System.Drawing.Point(211, 21)
        Me.btnViewHand.Name = "btnViewHand"
        Me.btnViewHand.Size = New System.Drawing.Size(75, 23)
        Me.btnViewHand.TabIndex = 4
        Me.btnViewHand.Text = "View hand"
        Me.btnViewHand.UseVisualStyleBackColor = True
        '
        'tmrUpdater
        '
        Me.tmrUpdater.Enabled = True
        Me.tmrUpdater.Interval = 10
        '
        'btnMulligan
        '
        Me.btnMulligan.Location = New System.Drawing.Point(567, 21)
        Me.btnMulligan.Name = "btnMulligan"
        Me.btnMulligan.Size = New System.Drawing.Size(75, 23)
        Me.btnMulligan.TabIndex = 5
        Me.btnMulligan.Text = "Mulligan"
        Me.btnMulligan.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(679, 20)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 6
        Me.btnConfirm.Text = "Confirm Hand"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblMana
        '
        Me.lblMana.AutoSize = True
        Me.lblMana.Location = New System.Drawing.Point(1133, 42)
        Me.lblMana.Name = "lblMana"
        Me.lblMana.Size = New System.Drawing.Size(37, 13)
        Me.lblMana.TabIndex = 9
        Me.lblMana.Text = "Mana:"
        '
        'lblManaStatus
        '
        Me.lblManaStatus.AutoSize = True
        Me.lblManaStatus.Location = New System.Drawing.Point(524, 108)
        Me.lblManaStatus.Name = "lblManaStatus"
        Me.lblManaStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblManaStatus.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.islandtu
        Me.PictureBox1.Location = New System.Drawing.Point(796, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(225, 312)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'btnTS
        '
        Me.btnTS.Location = New System.Drawing.Point(557, 98)
        Me.btnTS.Name = "btnTS"
        Me.btnTS.Size = New System.Drawing.Size(75, 23)
        Me.btnTS.TabIndex = 11
        Me.btnTS.Text = "turn start"
        Me.btnTS.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1297, 639)
        Me.Controls.Add(Me.btnTS)
        Me.Controls.Add(Me.lblManaStatus)
        Me.Controls.Add(Me.lblMana)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnMulligan)
        Me.Controls.Add(Me.btnViewHand)
        Me.Controls.Add(Me.lblNumCreatures)
        Me.Controls.Add(Me.lblTestT)
        Me.Controls.Add(Me.lblTestP)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTestP As Label
    Friend WithEvents lblTestT As Label
    Friend WithEvents lblNumCreatures As Label
    Friend WithEvents btnViewHand As Button
    Friend WithEvents tmrUpdater As Timer
    Friend WithEvents btnMulligan As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblMana As Label
    Friend WithEvents lblManaStatus As Label
    Friend WithEvents btnTS As Button
End Class
