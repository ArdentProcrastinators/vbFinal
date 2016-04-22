Public Class Form1

    Dim deckInfo1(30) As String
    Dim deckInfo2(30) As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        deckInfo1(0) = "Deck 1"
        deckInfo2(0) = "Deck 2"

        ShuffleCards(deckInfo1)
        ShuffleCards(deckInfo2)

    End Sub

    Public Sub ShuffleCards(deckInfo() As String)

        'Note: Ctrl + G to open debug window

        'Referenced variables in some for loops
        Dim cardPos(30) As Integer
        Dim cardIndex(30) As Integer
        Dim cardsLeft As New List(Of Integer)
        Dim posLeft As New List(Of Integer)

        'Sets the 30 cards and adds 30 members to each list
        For V As Integer = 1 To deckInfo.Count - 1
            cardsLeft.Add(V)
            posLeft.Add(V)
            cardPos(V) = V
            cardIndex(V) = V
        Next

        'Shuffles cards
        For I As Integer = 1 To 30

            Randomize()
            Dim x As Integer = Int(cardsLeft.Count() * Rnd() + 1)
            Dim y As Integer = Int(posLeft.Count() * Rnd() + 1)
            cardPos(I) = cardsLeft(x - 1)
            cardIndex(I) = posLeft(y - 1)
            cardsLeft.Remove(cardsLeft(x - 1))
            posLeft.Remove(posLeft(y - 1))

        Next

        'Sorts cardPos and cardIndex into Deckinfo, which stores card indexes based on position. (Example: deckinfo(1) will show the index of the first card in the deck)
        For Z As Integer = 1 To 30

            deckInfo(cardPos(Z)) = cardIndex(Z)

        Next

        'Prints cards in order for current deck
        Debug.Print("Start of " & deckInfo(0) & vbNewLine)
        For B As Integer = 1 To deckInfo.Count - 1

            Debug.Print("Card " & B & ": " & deckInfo(B))

        Next

    End Sub
End Class
