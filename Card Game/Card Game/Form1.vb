Public Class Form1
    '//ADDED FOR TESTING PURPOSES, FEEL FREE TO DELETE: All labels on the form//
    Dim deckInfo1(30) As String
    Dim deckInfo2(30) As String
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Creature)
    Public DireCreatures As New List(Of Creature)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        deckInfo1(0) = "Deck 1"
        deckInfo2(0) = "Deck 2"

        ShuffleCards(deckInfo1)
        ShuffleCards(deckInfo2)
        'Generates a test creature with ID of 1 and on Radiant side
        GenerateCreature(1, True)
        Debug.Print("Power: " & IDTable.IDPower(1))
        Debug.Print("Health: " & IDTable.IDHealth(1))

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
    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'If Radiant played it
        If Radiant Then
            'Adds a new creature to the Radiant's creature list
            'Hover over the word Creature to see what the values represent
            'The I In front represents that the value is an input, and Is only used to set the values in the class correctly
            'View the Creature.vb class for more info, located in CardTypes Folder
            RadiantCreatures.Add(New Creature(1, 1, CreatureID))
            '//TESTING// Sets the labels on the designer to the creatures power and health
            lblTestP.Text = "Health: " & RadiantCreatures(RadiantCreatures.Count - 1).MaxPower
            lblTestT.Text = "Power: " & RadiantCreatures(RadiantCreatures.Count - 1).MaxHealth
            '//TESTING// Shows the number of creatures Radiant has in the bottom label
            lblNumCreatures.Text = RadiantCreatures.Count
        Else
            'Same as above only for the Dire side
            DireCreatures.Add(New Creature(1, 1, CreatureID))
            lblTestP.Text = "Health: " & DireCreatures(DireCreatures.Count - 1).MaxPower
            lblTestT.Text = "Power: " & DireCreatures(DireCreatures.Count - 1).MaxHealth
            lblNumCreatures.Text = DireCreatures.Count
        End If

    End Sub
End Class

