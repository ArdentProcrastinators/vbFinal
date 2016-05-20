<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeckBuilder
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
        Me.sbarCards = New System.Windows.Forms.HScrollBar()
        Me.txtCards = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'sbarCards
        '
        Me.sbarCards.LargeChange = 1
        Me.sbarCards.Location = New System.Drawing.Point(18, 0)
        Me.sbarCards.Maximum = 7
        Me.sbarCards.Name = "sbarCards"
        Me.sbarCards.Size = New System.Drawing.Size(1099, 11)
        Me.sbarCards.TabIndex = 0
        '
        'txtCards
        '
        Me.txtCards.Location = New System.Drawing.Point(-1, 420)
        Me.txtCards.Multiline = True
        Me.txtCards.Name = "txtCards"
        Me.txtCards.ReadOnly = True
        Me.txtCards.Size = New System.Drawing.Size(1140, 248)
        Me.txtCards.TabIndex = 1
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(1000, 648)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(139, 20)
        Me.txtTotal.TabIndex = 2
        Me.txtTotal.Text = "Total: 0"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(12, 391)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Enabled = False
        Me.btnCreate.Location = New System.Drawing.Point(1052, 391)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 4
        Me.btnCreate.Text = "Create Deck"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'DeckBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 667)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtCards)
        Me.Controls.Add(Me.sbarCards)
        Me.Name = "DeckBuilder"
        Me.Text = "DeckBuilder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sbarCards As HScrollBar
    Friend WithEvents txtCards As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCreate As Button
End Class
