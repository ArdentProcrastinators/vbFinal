Public Class Form1

    Dim deckInfo As New List(Of Integer)
    Dim handInfo As New List(Of Integer)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For I As Integer = 1 To 60
            'adds 60 elements
            deckInfo.Add(1)
        Next

        ShuffleCards(deckInfo)
        DrawCards(7, deckInfo, handInfo)

    End Sub

    Public Sub ShuffleCards(deckInfo As List(Of Integer))

        'Note: Ctrl + G to open debug window

        'Referenced variables in some for loops
        Dim cardCount As Integer = deckInfo.Count


        Dim cardPos(cardCount) As Integer
            Dim cardIndex(cardCount) As Integer
            Dim cardsLeft As New List(Of Integer)
            Dim posLeft As New List(Of Integer)


            'Sets the 30 cards and adds 30 members to each list
            For V As Integer = 1 To cardCount
                cardsLeft.Add(V)
                posLeft.Add(V)

                cardPos(V) = V
                cardIndex(V) = V
            Next

            'Shuffles cards
            For I As Integer = 1 To cardCount

                Randomize()
                Dim x As Integer = Int(cardsLeft.Count() * Rnd() + 1)
                Dim y As Integer = Int(posLeft.Count() * Rnd() + 1)
                cardPos(I) = cardsLeft(x - 1)
                cardIndex(I) = posLeft(y - 1)
                cardsLeft.Remove(cardsLeft(x - 1))
                posLeft.Remove(posLeft(y - 1))

            Next

            'Sorts cardPos and cardIndex into Deckinfo, which stores card indexes based on position. (Example: deckinfo(1) will show the index of the first card in the deck)
            For Z As Integer = 1 To cardCount

                deckInfo.Item(cardPos(Z) - 1) = cardIndex(Z)

            Next

            'Prints cards in order for current deck
            Debug.Print("Start of new deck" & vbNewLine)
            For B As Integer = 0 To cardCount - 1

            Debug.Print("Card " & B + 1 & ": " & deckInfo(B))

            Next

    End Sub


    Public Sub DrawCards(n As Integer, desDeck As List(Of Integer), desHand As List(Of Integer))

        For I As Integer = 1 To n
            desHand.Add(desDeck(0))
            desDeck.Remove(desDeck(0))
        Next

    End Sub

    Private Sub hand_Click(sender As Object, e As EventArgs) Handles btnViewHand.Click

        Debug.Print("Hand:")

        For I As Integer = 0 To handInfo.Count - 1

            Debug.Print("Card " & I + 1 & ": " & handInfo(I))

        Next

    End Sub
End Class
