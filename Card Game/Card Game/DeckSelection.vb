Public Class frmDeckSelection

    Public Shared selectedDeck As List(Of Card)

    Private Sub DeckSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        grpPlayer1Decks.Top = Me.Height / 2 - grpPlayer1Decks.Height
        grpPlayer1Decks.Left = 12
        grpPlayer2Decks.Top = Me.Height / 2 - grpPlayer2Decks.Height
        grpPlayer2Decks.Left = Me.Width - (12 + grpPlayer2Decks.Width)
        lblChooseDeck.Left = Me.Width / 2 - lblChooseDeck.Width / 2
        btnStart.Top = Me.Height - btnStart.Height * 1.5
        btnStart.Left = Me.Width / 2 - btnStart.Width / 2


    End Sub

    Private Sub formSizeChanged() Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub StartOn() Handles btnStart.MouseEnter
        btnStart.Font = New Drawing.Font("Franklin Gothic", 26, FontStyle.Bold Or FontStyle.Italic)
    End Sub

    Private Sub StartOff() Handles btnStart.MouseLeave
        btnStart.Font = New Drawing.Font("Franklin Gothic", 26)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Form1.Show()
        Form1.usedDeck = selectedDeck
        Me.Close()
    End Sub

    Private Sub rdbP2S1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbP2S1.CheckedChanged
        If rdbP2S1.Checked = True Then
            selectedDeck = IDTable.deck1
        End If
    End Sub

    Private Sub rdbP1S1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbP1S1.CheckedChanged
        If rdbP1S1.Checked = True Then
            selectedDeck = IDTable.deck1
        Else

        End If
    End Sub
End Class