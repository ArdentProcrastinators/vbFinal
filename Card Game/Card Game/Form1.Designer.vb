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
        Me.tmrUpdater = New System.Windows.Forms.Timer(Me.components)
        Me.btnMulligan = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblMana = New System.Windows.Forms.Label()
        Me.lblManaStatus = New System.Windows.Forms.Label()
        Me.btnNextPhase = New System.Windows.Forms.Button()
        Me.lblTopHealth = New System.Windows.Forms.Label()
        Me.lblBottomHealth = New System.Windows.Forms.Label()
        Me.lblPhase = New System.Windows.Forms.Label()
        Me.lblTurn = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        'btnNextPhase
        '
        Me.btnNextPhase.Enabled = False
        Me.btnNextPhase.Location = New System.Drawing.Point(486, 20)
        Me.btnNextPhase.Name = "btnNextPhase"
        Me.btnNextPhase.Size = New System.Drawing.Size(75, 23)
        Me.btnNextPhase.TabIndex = 11
        Me.btnNextPhase.Text = "Next Phase"
        Me.btnNextPhase.UseVisualStyleBackColor = True
        '
        'lblTopHealth
        '
        Me.lblTopHealth.AutoSize = True
        Me.lblTopHealth.Font = New System.Drawing.Font("Impact", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopHealth.Location = New System.Drawing.Point(1161, 257)
        Me.lblTopHealth.Name = "lblTopHealth"
        Me.lblTopHealth.Size = New System.Drawing.Size(90, 34)
        Me.lblTopHealth.TabIndex = 12
        Me.lblTopHealth.Text = "Label1"
        '
        'lblBottomHealth
        '
        Me.lblBottomHealth.AutoSize = True
        Me.lblBottomHealth.Font = New System.Drawing.Font("Impact", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomHealth.Location = New System.Drawing.Point(1157, 362)
        Me.lblBottomHealth.Name = "lblBottomHealth"
        Me.lblBottomHealth.Size = New System.Drawing.Size(94, 34)
        Me.lblBottomHealth.TabIndex = 13
        Me.lblBottomHealth.Text = "Label2"
        '
        'lblPhase
        '
        Me.lblPhase.AutoSize = True
        Me.lblPhase.Location = New System.Drawing.Point(819, 350)
        Me.lblPhase.Name = "lblPhase"
        Me.lblPhase.Size = New System.Drawing.Size(63, 13)
        Me.lblPhase.TabIndex = 14
        Me.lblPhase.Text = "Main Phase"
        '
        'lblTurn
        '
        Me.lblTurn.AutoSize = True
        Me.lblTurn.Location = New System.Drawing.Point(1049, 451)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Size = New System.Drawing.Size(76, 13)
        Me.lblTurn.TabIndex = 15
        Me.lblTurn.Text = "Radiant's Turn"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Untitled_drawing
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1297, 639)
        Me.Controls.Add(Me.lblTurn)
        Me.Controls.Add(Me.lblPhase)
        Me.Controls.Add(Me.lblBottomHealth)
        Me.Controls.Add(Me.lblTopHealth)
        Me.Controls.Add(Me.btnNextPhase)
        Me.Controls.Add(Me.lblManaStatus)
        Me.Controls.Add(Me.lblMana)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnMulligan)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrUpdater As Timer
    Friend WithEvents btnMulligan As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents lblMana As Label
    Friend WithEvents lblManaStatus As Label
    Friend WithEvents btnNextPhase As Button
    Friend WithEvents lblTopHealth As Label
    Friend WithEvents lblBottomHealth As Label
    Friend WithEvents lblPhase As Label
    Friend WithEvents lblTurn As Label
End Class
