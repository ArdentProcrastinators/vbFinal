Public Class DeckBuilder

    Public cardsCount(8) As Integer
    Public Deck As New List(Of Card)
    Dim CardList As New List(Of Card)
    Dim total As Integer
    Dim defCard As New Card(0, True)

    Private Sub DeckBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For I As Integer = 1 To 12
            Dim newC As New Card(I, True)
            newC.Top = 20
            newC.Left = (0.5 * My.Resources.Ardent_Procrastinor.Width + 25) * (I - 1)
            newC.Width = 0.5 * My.Resources.Ardent_Procrastinor.Width
            newC.Height = 0.5 * My.Resources.Ardent_Procrastinor.Height
            newC.partOfDB = True
            Me.Controls.Add(newC)
            CardList.Add(newC)
        Next

        sbarCards.Maximum = CardList.Count - 5

    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles sbarCards.Scroll

        Static lastVal As Integer = 0

        For Each c As Card In CardList
            c.Left += (0.5 * My.Resources.Ardent_Procrastinor.Width + 25) * (lastVal - sbarCards.Value)
        Next

        lastVal = sbarCards.Value

    End Sub

    Public Sub UpdateInfo(c As Card)

        If (total > 0 And c.DBinfo = False And cardsCount(c.ID) > 0) Or c.ID = 0 Or (c.DBinfo = True And cardsCount(c.ID) < 8) Or (c.DBinfo = True And c.cardname = "Island" Or c.cardname = "Forest" Or c.cardname = "Plains" Or c.cardname = "Mountain" Or c.cardname = "Swamp") Then

            If c.ID > 0 Then
                If c.DBinfo = True Then
                    Deck.Add(c)
                    cardsCount(c.ID) += 1
                    total += 1
                Else
                    Deck.Remove(c)
                    cardsCount(c.ID) -= 1
                    total -= 1
                End If
            End If

            txtCards.Text = ""

            For I As Integer = 1 To 12

                If cardsCount(I) > 0 Then txtCards.Text &= cardsCount(I) & " X " & IDTable.SetName(I) & "        "
                txtTotal.Text = "Total: " & total

            Next

            If total >= 32 Then
                btnCreate.Enabled = True
            Else
                btnCreate.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For I As Integer = 1 To 12
            cardsCount(I) = 0
        Next

        total = 0

        UpdateInfo(New Card(0, True))

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        MsgBox("This is deck one")
        Form1.Show()
        Form1.usedDeck = Deck
    End Sub

End Class