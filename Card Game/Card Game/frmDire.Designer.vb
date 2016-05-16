<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDire
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
        Me.tmrUpdater = New System.Windows.Forms.Timer(Me.components)
        Me.btnTS = New System.Windows.Forms.Button()
        Me.lblManaStatus = New System.Windows.Forms.Label()
        Me.lblMana = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnMulligan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tmrUpdater
        '
        Me.tmrUpdater.Enabled = True
        Me.tmrUpdater.Interval = 10
        '
        'btnTS
        '
        Me.btnTS.Location = New System.Drawing.Point(143, 226)
        Me.btnTS.Name = "btnTS"
        Me.btnTS.Size = New System.Drawing.Size(75, 23)
        Me.btnTS.TabIndex = 17
        Me.btnTS.Text = "turn start"
        Me.btnTS.UseVisualStyleBackColor = True
        '
        'lblManaStatus
        '
        Me.lblManaStatus.AutoSize = True
        Me.lblManaStatus.Location = New System.Drawing.Point(181, 314)
        Me.lblManaStatus.Name = "lblManaStatus"
        Me.lblManaStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblManaStatus.TabIndex = 16
        '
        'lblMana
        '
        Me.lblMana.AutoSize = True
        Me.lblMana.Location = New System.Drawing.Point(790, 248)
        Me.lblMana.Name = "lblMana"
        Me.lblMana.Size = New System.Drawing.Size(37, 13)
        Me.lblMana.TabIndex = 15
        Me.lblMana.Text = "Mana:"
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(336, 226)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 14
        Me.btnConfirm.Text = "Confirm Hand"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnMulligan
        '
        Me.btnMulligan.Location = New System.Drawing.Point(224, 227)
        Me.btnMulligan.Name = "btnMulligan"
        Me.btnMulligan.Size = New System.Drawing.Size(75, 23)
        Me.btnMulligan.TabIndex = 13
        Me.btnMulligan.Text = "Mulligan"
        Me.btnMulligan.UseVisualStyleBackColor = True
        '
        'frmDire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 553)
        Me.Controls.Add(Me.btnTS)
        Me.Controls.Add(Me.lblManaStatus)
        Me.Controls.Add(Me.lblMana)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnMulligan)
        Me.Name = "frmDire"
        Me.Text = "Dire Turn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrUpdater As Timer
    Friend WithEvents btnTS As Button
    Friend WithEvents lblManaStatus As Label
    Friend WithEvents lblMana As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnMulligan As Button
End Class
