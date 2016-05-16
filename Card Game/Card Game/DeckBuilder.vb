Public Class DeckBuilder

    Dim CardList As New List(Of Card)

    Private Sub DeckBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For I As Integer = 1 To 8
            Dim newC As New Card(I)
            newC.Top = 20
            newC.Left = (0.5 * My.Resources.Ardent_Procrastinor.Width + 25) * (I - 1)
            newC.Width = 0.5 * My.Resources.Ardent_Procrastinor.Width
            newC.Height = 0.5 * My.Resources.Ardent_Procrastinor.Height
            newC.partOfDB = True
            Me.Controls.Add(newC)
            CardList.Add(newC)
        Next

        sbarCards.Maximum = CardList.Count - 1

    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles sbarCards.Scroll

        Static lastVal As Integer = 0

        For Each c As Card In CardList
            c.Left += (0.5 * My.Resources.Ardent_Procrastinor.Width + 25) * (lastVal - sbarCards.Value)
        Next

        lastVal = sbarCards.Value

    End Sub
End Class