Public Class Form1
    '//ADDED FOR TESTING PURPOSES, FEEL FREE TO DELETE: All labels on the form// My spooky inteface//
    Dim deckInfo As New List(Of Integer)
    Dim handInfo As New List(Of Integer)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Creature)
    Public DireCreatures As New List(Of Creature)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        For I As Integer = 1 To 60
            'adds 60 elements
            deckInfo.Add(1)
        Next

        ShuffleCards(deckInfo)
        DrawCards(7, deckInfo, handInfo)

        GenerateCreature(1, True)

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

        UpdateHand()

    End Sub

    Private Sub hand_Click(sender As Object, e As EventArgs) Handles btnViewHand.Click

        Debug.Print("Hand:")

        For I As Integer = 0 To handInfo.Count - 1

            Debug.Print("Card " & I + 1 & ": " & handInfo(I))

        Next
    End Sub
    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'Fetches the creatures Power and Health from their IDs
        Dim CreaturePower As Integer = IDTable.IDPower(CreatureID)
        Dim CreatureHealth As Integer = IDTable.IDHealth(CreatureID)
        'If Radiant played it
        If Radiant Then
            'Adds a new creature to the Radiant's creature list
            'Hover over the word Creature to see what the values represent
            'The I In front represents that the value is an input, and Is only used to set the values in the class correctly
            'View the Creature.vb class for more info, located in CardTypes Folder
            RadiantCreatures.Add(New Creature(CreaturePower, CreatureHealth, CreatureID))
            '//TESTING// Sets the labels on the designer to the creatures power and health
            lblTestP.Text = "Health: " & RadiantCreatures(RadiantCreatures.Count - 1).MaxPower
            lblTestT.Text = "Power: " & RadiantCreatures(RadiantCreatures.Count - 1).MaxHealth
            '//TESTING// Shows the number of creatures Radiant has in the bottom label
            lblNumCreatures.Text = RadiantCreatures.Count
        Else
            'Same as above only for the Dire side
            DireCreatures.Add(New Creature(CreaturePower, CreatureHealth, CreatureID))
            lblTestP.Text = "Health: " & DireCreatures(DireCreatures.Count - 1).MaxPower
            lblTestT.Text = "Power: " & DireCreatures(DireCreatures.Count - 1).MaxHealth
            lblNumCreatures.Text = DireCreatures.Count
        End If

    End Sub

    Public Sub UpdateHand()

        Static cardsInHand As Integer
        Dim cardScale As Decimal = 0.3
        Dim handGroup As New GroupBox
        handGroup.Name = "grpHand"

        For I As Integer = 1 To handInfo.Count

            grpHand.Dispose()
            Me.Controls.Add(handGroup)

            Dim newCard As New Card
            newCard.Image = My.Resources.Ardent_Procrastinor
            newCard.SizeMode = PictureBoxSizeMode.Zoom
            newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width
            newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height
            newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
            newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * cardsInHand + (Me.Width - handInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
<<<<<<< HEAD
            handGroup.Controls.Add(newCard)
            handGroup.Left = 0
            handGroup.Top = 400
=======
>>>>>>> origin/master

            Me.Controls.Add(newCard)
            cardsInHand += 1

        Next

    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged
        UpdateHand()
    End Sub
End Class

