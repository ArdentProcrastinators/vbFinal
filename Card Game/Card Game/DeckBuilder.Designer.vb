﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        'DeckBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 667)
        Me.Controls.Add(Me.sbarCards)
        Me.Name = "DeckBuilder"
        Me.Text = "DeckBuilder"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents sbarCards As HScrollBar
End Class