Public Class Form1
    Dim deckInfo As New List(Of Integer)
    Dim handInfo As New List(Of Integer)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Card)
    Dim cardScale As Decimal = 0.3

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

        'Referenced variables in some for loops
        Dim cardCount As Integer = deckInfo.Count

        Dim cardsLeft As New List(Of Integer)

        'Sets the 30 cards and adds 30 members to each list
        For V As Integer = 1 To cardCount
            cardsLeft.Add(V)
        Next

        'Shuffles cards
        For I As Integer = 0 To cardCount - 1

            Randomize()
            Dim x As Integer = Int(cardsLeft.Count() * Rnd())
            deckInfo.Item(I) = cardsLeft(x)
            cardsLeft.Remove(cardsLeft(x))

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

    Public Sub UpdateHand()

        'Cardcount is updated after new cards are made so that indexes will not be outside the bound of the array
        Static cardsInHand As Integer
        Static cardCount As Integer = 7

        'Disposes old cards
        If cardsInHand <> 0 Then
            For I As Integer = 1 To cardCount

                Me.Controls("card" & I).Dispose()

            Next
        End If

        'Resets cards in hand since all cards have been deleted
        cardsInHand = 0

        'Adds new cards
        For I As Integer = 1 To handInfo.Count

            Dim newCard As New Card(1)
            newCard.BackgroundImageLayout = BackgroundImageLayout.Zoom
            newCard.BackgroundImage = IDTable.IDImage(newCard)
            newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
            newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
            newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
            newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * cardsInHand + (Me.Width - handInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
            newCard.Visible = True
            newCard.Name = "card" & I
            Me.Controls.Add(newCard)

            cardsInHand += 1

        Next

        cardCount = handInfo.Count

    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged

        UpdateHand()

    End Sub

    Private Sub btnMulligan_Click(sender As Object, e As EventArgs) Handles btnMulligan.Click

        'Keeps mulligan count to draw the correct amount of cards
        Static mulliganCount As Integer = 1
        If handInfo.Count > 1 Then

            deckInfo.Clear()
            handInfo.Clear()

            For I As Integer = 1 To 60
                'adds 60 elements
                deckInfo.Add(1)
            Next

            ShuffleCards(deckInfo)
            DrawCards(7 - mulliganCount, deckInfo, handInfo)

            mulliganCount += 1

        Else
            btnMulligan.Enabled = False
        End If

    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'Confirms hand and disables mulliganning
        btnMulligan.Dispose()
        btnConfirm.Dispose()
    End Sub

    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'If Radiant played it
        If Radiant Then

            RadiantCreatures.Add(New Card(1))

            RadiantCreatures(RadiantCreatures.Count - 1).Image = IDTable.IDImage(RadiantCreatures(RadiantCreatures.Count - 1))
            RadiantCreatures(RadiantCreatures.Count - 1).Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            RadiantCreatures(RadiantCreatures.Count - 1).Width = My.Resources.Ardent_Procrastinor.Width * cardScale

            Me.Controls.Add(RadiantCreatures(RadiantCreatures.Count - 1))

            Debug.Print(RadiantCreatures(RadiantCreatures.Count - 1).Left)
        Else
            'Same as above only for the Dire side
        End If

    End Sub

End Class

