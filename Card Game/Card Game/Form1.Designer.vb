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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTestP = New System.Windows.Forms.Label()
        Me.lblTestT = New System.Windows.Forms.Label()
        Me.lblNumCreatures = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblTestP
        '
        Me.lblTestP.AutoSize = True
        Me.lblTestP.Location = New System.Drawing.Point(61, 187)
        Me.lblTestP.Name = "lblTestP"
        Me.lblTestP.Size = New System.Drawing.Size(39, 13)
        Me.lblTestP.TabIndex = 1
        Me.lblTestP.Text = "Label1"
        '
        'lblTestT
        '
        Me.lblTestT.AutoSize = True
        Me.lblTestT.Location = New System.Drawing.Point(167, 199)
        Me.lblTestT.Name = "lblTestT"
        Me.lblTestT.Size = New System.Drawing.Size(39, 13)
        Me.lblTestT.TabIndex = 2
        Me.lblTestT.Text = "Label2"
        '
        'lblNumCreatures
        '
        Me.lblNumCreatures.AutoSize = True
        Me.lblNumCreatures.Location = New System.Drawing.Point(128, 239)
        Me.lblNumCreatures.Name = "lblNumCreatures"
        Me.lblNumCreatures.Size = New System.Drawing.Size(39, 13)
        Me.lblNumCreatures.TabIndex = 3
        Me.lblNumCreatures.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.lblNumCreatures)
        Me.Controls.Add(Me.lblTestT)
        Me.Controls.Add(Me.lblTestP)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTestP As Label
    Friend WithEvents lblTestT As Label
    Friend WithEvents lblNumCreatures As Label
End Class
