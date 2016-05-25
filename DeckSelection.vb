Public Class frmDeckSelection

    Private Sub DeckSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sets control positions
        Me.WindowState = FormWindowState.Maximized
        grpPlayer1Decks.Top = Me.Height / 2 - grpPlayer1Decks.Height
        grpPlayer1Decks.Left = 12
        grpPlayer2Decks.Top = Me.Height / 2 - grpPlayer2Decks.Height
        grpPlayer2Decks.Left = Me.Width - (12 + grpPlayer2Decks.Width)
        lblChooseDeck.Left = Me.Width / 2 - lblChooseDeck.Width / 2
        btnStart.Top = Me.Height - btnStart.Height * 1.5
        btnStart.Left = Me.Width / 2 - btnStart.Width / 2


    End Sub
    'Locks form in fullscreen
    Private Sub formSizeChanged() Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Maximized
    End Sub
    'Italicizes and bolds font when mouse enters
    Private Sub StartOn() Handles btnStart.MouseEnter
        btnStart.Font = New Drawing.Font("Franklin Gothic", 26, FontStyle.Bold Or FontStyle.Italic)
    End Sub
    'Resets font when mouse leaves
    Private Sub StartOff() Handles btnStart.MouseLeave
        btnStart.Font = New Drawing.Font("Franklin Gothic", 26)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class