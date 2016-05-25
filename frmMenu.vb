Public Class frmMenu

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'Declares default Deck1
        For cards As Integer = 0 To 16
            Dim NoobMemer As Card = New Card(1, True)
            Me.Controls.Add(NoobMemer)
            NoobMemer.Visible = False
            IDTable.deck1.Add(NoobMemer)
            Dim Forest As Card = New Card(5, True)
            Me.Controls.Add(Forest)
            Forest.Visible = False
            IDTable.deck1.Add(Forest)
        Next
    End Sub
    'Locks form in fullscreen
    Private Sub formSizeChanged() Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Maximized
    End Sub
    'When the mouse enters a button makes the font italic
    Private Sub StartOn() Handles btnStart.MouseEnter
        btnStart.Font = New Drawing.Font("Franklin Gothic", 16, FontStyle.Bold Or FontStyle.Italic)
    End Sub
    'Unitalicizes text when the mouse leaves
    Private Sub StartOff() Handles btnStart.MouseLeave
        btnStart.Font = New Drawing.Font("Franklin Gothic", 16)
    End Sub

    Private Sub DeckOn() Handles btnDeck.MouseEnter
        btnDeck.Font = New Drawing.Font("Franklin Gothic", 16, FontStyle.Bold Or FontStyle.Italic)
    End Sub

    Private Sub DeckOff() Handles btnDeck.MouseLeave
        btnDeck.Font = New Drawing.Font("Franklin Gothic", 16)
    End Sub

    Private Sub ExitOn() Handles btnExit.MouseEnter
        btnExit.Font = New Drawing.Font("Franklin Gothic", 16, FontStyle.Bold Or FontStyle.Italic)
    End Sub

    Private Sub ExitOff() Handles btnExit.MouseLeave
        btnExit.Font = New Drawing.Font("Franklin Gothic", 16)
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        frmDeckSelection.Show()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnDeck_Click(sender As Object, e As EventArgs) Handles btnDeck.Click
        DeckBuilder.Show()
    End Sub
End Class