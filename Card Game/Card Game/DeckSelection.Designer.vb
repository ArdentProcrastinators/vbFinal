<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeckSelection
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
        Me.lblChooseDeck = New System.Windows.Forms.Label()
        Me.rdbP1S1 = New System.Windows.Forms.RadioButton()
        Me.rdbP1S2 = New System.Windows.Forms.RadioButton()
        Me.grpPlayer1Decks = New System.Windows.Forms.GroupBox()
        Me.rdbP1S6 = New System.Windows.Forms.RadioButton()
        Me.rdbP1S4 = New System.Windows.Forms.RadioButton()
        Me.rdbP1S3 = New System.Windows.Forms.RadioButton()
        Me.rdbP1S5 = New System.Windows.Forms.RadioButton()
        Me.grpPlayer2Decks = New System.Windows.Forms.GroupBox()
        Me.rdbP2S6 = New System.Windows.Forms.RadioButton()
        Me.rdbP2S4 = New System.Windows.Forms.RadioButton()
        Me.rdbP2S3 = New System.Windows.Forms.RadioButton()
        Me.rdbP2S5 = New System.Windows.Forms.RadioButton()
        Me.rdbP2S2 = New System.Windows.Forms.RadioButton()
        Me.rdbP2S1 = New System.Windows.Forms.RadioButton()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.grpPlayer1Decks.SuspendLayout()
        Me.grpPlayer2Decks.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblChooseDeck
        '
        Me.lblChooseDeck.AutoSize = True
        Me.lblChooseDeck.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChooseDeck.Location = New System.Drawing.Point(367, 19)
        Me.lblChooseDeck.Name = "lblChooseDeck"
        Me.lblChooseDeck.Size = New System.Drawing.Size(333, 42)
        Me.lblChooseDeck.TabIndex = 0
        Me.lblChooseDeck.Text = "Choose Your Deck"
        '
        'rdbP1S1
        '
        Me.rdbP1S1.AutoSize = True
        Me.rdbP1S1.Checked = True
        Me.rdbP1S1.Location = New System.Drawing.Point(6, 30)
        Me.rdbP1S1.Name = "rdbP1S1"
        Me.rdbP1S1.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S1.TabIndex = 1
        Me.rdbP1S1.TabStop = True
        Me.rdbP1S1.Text = "Empty Deck Slot"
        Me.rdbP1S1.UseVisualStyleBackColor = True
        '
        'rdbP1S2
        '
        Me.rdbP1S2.AutoSize = True
        Me.rdbP1S2.Location = New System.Drawing.Point(272, 30)
        Me.rdbP1S2.Name = "rdbP1S2"
        Me.rdbP1S2.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S2.TabIndex = 2
        Me.rdbP1S2.TabStop = True
        Me.rdbP1S2.Text = "Empty Deck Slot"
        Me.rdbP1S2.UseVisualStyleBackColor = True
        '
        'grpPlayer1Decks
        '
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S6)
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S4)
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S3)
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S5)
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S2)
        Me.grpPlayer1Decks.Controls.Add(Me.rdbP1S1)
        Me.grpPlayer1Decks.Font = New System.Drawing.Font("Franklin Gothic Medium", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPlayer1Decks.Location = New System.Drawing.Point(567, 228)
        Me.grpPlayer1Decks.Name = "grpPlayer1Decks"
        Me.grpPlayer1Decks.Size = New System.Drawing.Size(540, 157)
        Me.grpPlayer1Decks.TabIndex = 3
        Me.grpPlayer1Decks.TabStop = False
        Me.grpPlayer1Decks.Text = "Player 1's Deck"
        '
        'rdbP1S6
        '
        Me.rdbP1S6.AutoSize = True
        Me.rdbP1S6.Location = New System.Drawing.Point(272, 101)
        Me.rdbP1S6.Name = "rdbP1S6"
        Me.rdbP1S6.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S6.TabIndex = 7
        Me.rdbP1S6.TabStop = True
        Me.rdbP1S6.Text = "Empty Deck Slot"
        Me.rdbP1S6.UseVisualStyleBackColor = True
        '
        'rdbP1S4
        '
        Me.rdbP1S4.AutoSize = True
        Me.rdbP1S4.Location = New System.Drawing.Point(272, 66)
        Me.rdbP1S4.Name = "rdbP1S4"
        Me.rdbP1S4.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S4.TabIndex = 6
        Me.rdbP1S4.TabStop = True
        Me.rdbP1S4.Text = "Empty Deck Slot"
        Me.rdbP1S4.UseVisualStyleBackColor = True
        '
        'rdbP1S3
        '
        Me.rdbP1S3.AutoSize = True
        Me.rdbP1S3.Location = New System.Drawing.Point(6, 66)
        Me.rdbP1S3.Name = "rdbP1S3"
        Me.rdbP1S3.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S3.TabIndex = 4
        Me.rdbP1S3.TabStop = True
        Me.rdbP1S3.Text = "Empty Deck Slot"
        Me.rdbP1S3.UseVisualStyleBackColor = True
        '
        'rdbP1S5
        '
        Me.rdbP1S5.AutoSize = True
        Me.rdbP1S5.Location = New System.Drawing.Point(6, 102)
        Me.rdbP1S5.Name = "rdbP1S5"
        Me.rdbP1S5.Size = New System.Drawing.Size(260, 41)
        Me.rdbP1S5.TabIndex = 5
        Me.rdbP1S5.TabStop = True
        Me.rdbP1S5.Text = "Empty Deck Slot"
        Me.rdbP1S5.UseVisualStyleBackColor = True
        '
        'grpPlayer2Decks
        '
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S6)
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S4)
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S3)
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S5)
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S2)
        Me.grpPlayer2Decks.Controls.Add(Me.rdbP2S1)
        Me.grpPlayer2Decks.Font = New System.Drawing.Font("Franklin Gothic Medium", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPlayer2Decks.Location = New System.Drawing.Point(21, 228)
        Me.grpPlayer2Decks.Name = "grpPlayer2Decks"
        Me.grpPlayer2Decks.Size = New System.Drawing.Size(540, 157)
        Me.grpPlayer2Decks.TabIndex = 4
        Me.grpPlayer2Decks.TabStop = False
        Me.grpPlayer2Decks.Text = "Player 2's Deck"
        '
        'rdbP2S6
        '
        Me.rdbP2S6.AutoSize = True
        Me.rdbP2S6.Location = New System.Drawing.Point(272, 102)
        Me.rdbP2S6.Name = "rdbP2S6"
        Me.rdbP2S6.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S6.TabIndex = 7
        Me.rdbP2S6.TabStop = True
        Me.rdbP2S6.Text = "Empty Deck Slot"
        Me.rdbP2S6.UseVisualStyleBackColor = True
        '
        'rdbP2S4
        '
        Me.rdbP2S4.AutoSize = True
        Me.rdbP2S4.Location = New System.Drawing.Point(272, 66)
        Me.rdbP2S4.Name = "rdbP2S4"
        Me.rdbP2S4.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S4.TabIndex = 6
        Me.rdbP2S4.TabStop = True
        Me.rdbP2S4.Text = "Empty Deck Slot"
        Me.rdbP2S4.UseVisualStyleBackColor = True
        '
        'rdbP2S3
        '
        Me.rdbP2S3.AutoSize = True
        Me.rdbP2S3.Location = New System.Drawing.Point(6, 66)
        Me.rdbP2S3.Name = "rdbP2S3"
        Me.rdbP2S3.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S3.TabIndex = 4
        Me.rdbP2S3.TabStop = True
        Me.rdbP2S3.Text = "Empty Deck Slot"
        Me.rdbP2S3.UseVisualStyleBackColor = True
        '
        'rdbP2S5
        '
        Me.rdbP2S5.AutoSize = True
        Me.rdbP2S5.Location = New System.Drawing.Point(6, 102)
        Me.rdbP2S5.Name = "rdbP2S5"
        Me.rdbP2S5.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S5.TabIndex = 5
        Me.rdbP2S5.TabStop = True
        Me.rdbP2S5.Text = "Empty Deck Slot"
        Me.rdbP2S5.UseVisualStyleBackColor = True
        '
        'rdbP2S2
        '
        Me.rdbP2S2.AutoSize = True
        Me.rdbP2S2.Location = New System.Drawing.Point(272, 30)
        Me.rdbP2S2.Name = "rdbP2S2"
        Me.rdbP2S2.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S2.TabIndex = 2
        Me.rdbP2S2.TabStop = True
        Me.rdbP2S2.Text = "Empty Deck Slot"
        Me.rdbP2S2.UseVisualStyleBackColor = True
        '
        'rdbP2S1
        '
        Me.rdbP2S1.AutoSize = True
        Me.rdbP2S1.Checked = True
        Me.rdbP2S1.Location = New System.Drawing.Point(6, 30)
        Me.rdbP2S1.Name = "rdbP2S1"
        Me.rdbP2S1.Size = New System.Drawing.Size(260, 41)
        Me.rdbP2S1.TabIndex = 1
        Me.rdbP2S1.TabStop = True
        Me.rdbP2S1.Text = "Empty Deck Slot"
        Me.rdbP2S1.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Franklin Gothic Medium", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(635, 45)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(247, 139)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start the Game"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'frmDeckSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 462)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.grpPlayer2Decks)
        Me.Controls.Add(Me.grpPlayer1Decks)
        Me.Controls.Add(Me.lblChooseDeck)
        Me.Name = "frmDeckSelection"
        Me.Text = "DeckSelection"
        Me.grpPlayer1Decks.ResumeLayout(False)
        Me.grpPlayer1Decks.PerformLayout()
        Me.grpPlayer2Decks.ResumeLayout(False)
        Me.grpPlayer2Decks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblChooseDeck As System.Windows.Forms.Label
    Friend WithEvents rdbP1S1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP1S2 As System.Windows.Forms.RadioButton
    Friend WithEvents grpPlayer1Decks As System.Windows.Forms.GroupBox
    Friend WithEvents rdbP1S6 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP1S4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP1S3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP1S5 As System.Windows.Forms.RadioButton
    Friend WithEvents grpPlayer2Decks As System.Windows.Forms.GroupBox
    Friend WithEvents rdbP2S6 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP2S4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP2S3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP2S5 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP2S2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbP2S1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnStart As System.Windows.Forms.Button
End Class
