Public Class Form1
    Public deckInfo As New List(Of Integer)
    Public handInfo As New List(Of Integer)
    Public cardInfo As New List(Of Integer)
    Public manaPool As New List(Of String)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Card)
    Dim cardScale As Decimal = 0.3
    'Public Target As Card
    Public Target As Card
    Public NeedTarget As Boolean
    Public IDSearchingForTarget As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        For I As Integer = 1 To 60

            'adds 60 elements
            Randomize()
            cardInfo.Add(Int(2 * Rnd() + 1))
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

            Dim newCard As New Card(cardInfo(handInfo(I - 1) - 1))
            newCard.partOfHand = True
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

            Dim newCreature As New Card(1)
            newCreature.BackgroundImageLayout = ImageLayout.Zoom
            newCreature.BackgroundImage = IDTable.IDImage(newCreature)
            newCreature.Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            newCreature.Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            newCreature.DefineCreature(newCreature)
            RadiantCreatures.Add(newCreature)
            Me.Controls.Add(newCreature)

            Debug.Print(RadiantCreatures(RadiantCreatures.Count - 1).Left)
        Else
            'Same as above only for the Dire side
        End If

    End Sub

    Public Sub TargetFound(ID As Integer)
        NeedTarget = False
        IDTable.IDUseAbility(ID)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.Print(RadiantCreatures(RadiantCreatures.Count - 1).BasePower + RadiantCreatures(RadiantCreatures.Count - 1).BuffPower)
    End Sub

    Public Sub AddMana(M As String)

        manaPool.Add(M)

    End Sub
End Class

