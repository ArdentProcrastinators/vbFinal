Public Class Form1
    Public RadiantDeckInfo As New List(Of Integer)
    Public DireDeckInfo As New List(Of Integer)
    Public RadiantHandInfo As New List(Of Card)
    Public DireHandInfo As New List(Of Card)
    Public RadiantCardsInHand
    Public DireCardsInHand
    'Not sure what cardInfo does so you will have to change that
    Public cardInfo As New List(Of Integer)
    Public manaPool As New List(Of String)
    Public landInfo As New List(Of Card)
    Public rLandinfo As New List(Of Card)
    Public dLandinfo As New List(Of Card)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Card)
    Public DireCreatures As New List(Of Card)
    Dim cardScale As Decimal = Me.Height / 1024
    Public RadiantHealth As Integer
    Public DireHealth As Integer
    'Public Target As Card
    Public Target As Card
    Public NeedTarget As Boolean
    Public IDSearchingForTarget As Integer
    Public RadiantTurn As Boolean = True

    Public started As Boolean
    Public landPlayed As Integer
    Public landMax As Integer = 1

    Public usedDeck As New List(Of Card)

    Public cardKeeper As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        usedDeck = DeckBuilder.Deck

        For I As Integer = 1 To usedDeck.Count

            cardInfo.Add(usedDeck(I - 1).ID)
            RadiantDeckInfo.Add(1)
            DireDeckInfo.Add(1)

        Next

        ShuffleCards(RadiantDeckInfo)
        ShuffleCards(DireDeckInfo)
        DrawCards(6, RadiantDeckInfo, RadiantHandInfo)
        DrawCards(7, DireDeckInfo, DireHandInfo)
        MoveCards()
        Debug.Print(RadiantCardsInHand)
        Debug.Print(DireCardsInHand)
        GenerateCreature(1, True)

    End Sub

    Public Sub ShuffleCards(deckInfo As List(Of Integer))

        'Referenced variables in some for loops
        Dim cardCount As Integer = deckInfo.Count

        Dim cardsLeft As New List(Of Integer)

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

    End Sub


    Public Sub DrawCards(n As Integer, desDeck As List(Of Integer), desHand As List(Of Card))

        For I As Integer = 1 To n
            Dim nC As New Card(cardInfo(desDeck(0) - 1), RadiantTurn)
            desHand.Add(nC)
            desDeck.Remove(desDeck(0))
        Next

        UpdateHand(RadiantTurn)

    End Sub

    Public Sub UpdateHand(Radiant As Boolean)
        If Radiant Then
            'Disposes old cards
            If RadiantCardsInHand <> 0 Then
                For Each c As Card In RadiantHandInfo

                    If Me.Controls(c.Name) IsNot Nothing And c.Radiant = RadiantTurn Then Me.Controls(c.Name).Dispose()

                Next
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()

            'Resets cards in hand since all cards have been deleted
            RadiantCardsInHand = 0

            'Adds new cards
            For I As Integer = 1 To RadiantHandInfo.Count

                Dim newCard As New Card(RadiantHandInfo(I - 1).ID, RadiantTurn)
                newCard.partOfHand = True
                newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
                newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
                newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
                newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * RadiantCardsInHand + (Me.Width - RadiantHandInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
                newCard.Visible = True
                RadiantHandInfo.Item(I - 1) = newCard
                Me.Controls.Add(RadiantHandInfo(I - 1))

                RadiantCardsInHand += 1

            Next

            RadiantCardsInHand = RadiantHandInfo.Count
        ElseIf Radiant = False Then
            'Disposes old cards
            If DireCardsInHand <> 0 Then
                For Each c As Card In DireHandInfo

                    If Me.Controls(c.Name) IsNot Nothing And c.Radiant = RadiantTurn Then Me.Controls(c.Name).Dispose()

                Next
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()

            'Resets cards in hand since all cards have been deleted
            DireCardsInHand = 0

            'Adds new cards
            For I As Integer = 1 To DireHandInfo.Count

                Dim newCard As New Card(DireHandInfo(I - 1).ID, RadiantTurn)
                newCard.partOfHand = True
                newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
                newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
                newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
                newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * DireCardsInHand + (Me.Width - DireHandInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
                newCard.Visible = True
                DireHandInfo.Item(I - 1) = newCard
                Me.Controls.Add(DireHandInfo(I - 1))

                DireCardsInHand += 1

            Next

            DireCardsInHand = DireHandInfo.Count
        End If


    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged
        'Probably not necessary anymore because form size can't be changed
        'UpdateHand(True)
        'UpdateHand(False)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMulligan_Click(sender As Object, e As EventArgs) Handles btnMulligan.Click
        'Keeps mulligan count to draw the correct amount of cards
        Static mulliganCount As Integer = 1
        If RadiantTurn Then
            If RadiantHandInfo.Count > 1 Then

                RadiantDeckInfo.Clear()
                RadiantHandInfo.Clear()

                For I As Integer = 1 To usedDeck.Count

                    RadiantDeckInfo.Add(1)

                Next

                ShuffleCards(RadiantDeckInfo)
                For Each c As Card In RadiantHandInfo
                    Me.Controls(c.Name).Dispose()
                Next
                DrawCards(7 - mulliganCount, RadiantDeckInfo, RadiantHandInfo)

                mulliganCount += 1

            Else
                btnMulligan.Enabled = False
            End If
        ElseIf RadiantTurn = False Then
            If DireHandInfo.Count > 1 Then

                DireDeckInfo.Clear()
                DireHandInfo.Clear()

                For I As Integer = 1 To usedDeck.Count
                    'adds 60 elements
                    DireDeckInfo.Add(1)
                Next

                ShuffleCards(DireDeckInfo)
                For Each c As Card In DireHandInfo
                    Me.Controls(c.Name).Dispose()
                Next
                DrawCards(7 - mulliganCount, DireDeckInfo, DireHandInfo)

                mulliganCount += 1

            Else
                btnMulligan.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'Confirms hand and disables mulliganning
        btnMulligan.Dispose()
        btnConfirm.Dispose()
        started = True
    End Sub

    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'If Radiant played it
        If Radiant Then
            'Moves current creatures over
            For x = 0 To RadiantCreatures.Count - 1
                RadiantCreatures(x).Left -= Me.Width / 32
            Next
            Dim newCreature As New Card(CreatureID, True)
            newCreature.BackgroundImageLayout = ImageLayout.Zoom
            newCreature.BackgroundImage = IDTable.IDImage(newCreature)
            newCreature.Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            newCreature.Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            newCreature.DefineCreature(newCreature)
            RadiantCreatures.Add(newCreature)
            Me.Controls.Add(newCreature)
            newCreature.Top = Me.Height / 1.75
            newCreature.Left = Me.Width / 2 + (Me.Width / 32 * (RadiantCreatures.Count - 2))
        Else
            'Same as above only for the Dire side
            Dim newCreature As New Card(CreatureID, False)
            newCreature.BackgroundImageLayout = ImageLayout.Zoom
            newCreature.BackgroundImage = IDTable.IDImage(newCreature)
            newCreature.Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            newCreature.Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            newCreature.DefineCreature(newCreature)
            DireCreatures.Add(newCreature)
            Me.Controls.Add(newCreature)
        End If

    End Sub

    Public Sub ManaLabel()

        lblMana.Text = "Mana:" & vbNewLine

        For Each m As String In manaPool
            lblMana.Text &= m & vbNewLine
        Next

    End Sub

    Public Sub AddMana(m As String)

        manaPool.Add(m)
        ManaLabel()

    End Sub

    Public Sub RemMana(m As String)

        manaPool.Remove(m)
        ManaLabel()

    End Sub

    Public Sub TMC(manaCost As List(Of String))

        Dim payed As Boolean

        For x As Integer = 1 To manaCost.Count


            Dim m As Integer = 0
            payed = False

            If manaCost(x - 1) <> "any" Then
                Do Until payed = True

                    If landInfo(m).manaCost(0) = manaCost(x - 1) And landInfo(m).used = True And landInfo(m).tapped = False Then
                        landInfo(m).tapped = True
                        landInfo(m).BackgroundImage = IDTable.IDImage(landInfo(m))
                        payed = True
                    End If
                    m += 1

                Loop
                manaPool.Remove(manaCost(x - 1))
            Else
                Do Until payed = True
                    If m > landInfo.Count - 1 Then MsgBox("error")
                    If landInfo(m).used = True And landInfo(m).tapped = False Then
                        landInfo(m).tapped = True
                        landInfo(m).BackgroundImage = IDTable.IDImage(landInfo(m))
                        payed = True
                    End If
                    m += 1
                Loop
                manaPool.Remove(landInfo(m - 1).manaCost(0))
            End If
        Next
    End Sub

    Public Sub TurnStart()
        'Clears mana
        manaPool.Clear()
        ManaLabel()

        For Each c As Card In landInfo
            'Untaps lands
            c.tapped = False
            c.used = False
            c.BackgroundImage = IDTable.IDImage(c)
        Next

        landPlayed = 0
        landMax = 1

        RadiantTurn = Not (RadiantTurn)
        MoveCards()
        If RadiantTurn Then
            DrawCards(1, RadiantDeckInfo, RadiantHandInfo)
            If RadiantCardsInHand > 7 Then RadiantCardsInHand = 7
        ElseIf RadiantTurn = False
            DrawCards(1, DireDeckInfo, DireHandInfo)
            If DireCardsInHand > 7 Then DireCardsInHand = 7
        End If
        Debug.Print(RadiantCardsInHand)
        Debug.Print(DireCardsInHand)
        Draw(RadiantTurn)                                   'Implement hand limit and discarding cards

    End Sub
    Private Sub MoveCards()
        For Each ThisControl As Control In Me.Controls
            If TypeOf (ThisControl) Is Card Then
                Dim c As Card = ThisControl                 'Casts ThisControl as Card so paramaters like Radiant can be used
                c.Top = Me.Height - (c.Top + c.Height)      'Flips the cards to opposite side of form, top to bottom and bottom to top
                If c.partOfHand = True Then
                    If RadiantTurn = c.Radiant Then         'If card is supposed to be in the hand of the current player's turn
                        'Sets current player's cards in hand's images to the image of the card
                        c.BackgroundImage = IDTable.IDImage(c)
                    Else
                        'Sets other player's cards in hand's image to card back to hide the cards
                        c.BackgroundImage = My.Resources.cardBack
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Draw(RadiantIsDrawing As Boolean)
        If RadiantIsDrawing Then                            'If Radiant is drawing
            DrawCards(1, RadiantDeckInfo, RadiantHandInfo)  'Draws 1 card from the radiant deck to the radiant hand
        ElseIf RadiantIsDrawing = False                     'If Dire is drawing
            DrawCards(1, DireDeckInfo, DireHandInfo)        'Draws 1 card from the dire deck to the dire hand
        End If
        Debug.Print(RadiantCardsInHand)
        Debug.Print(DireCardsInHand)
    End Sub

    Private Sub btnTS_Click(sender As Object, e As EventArgs) Handles btnNextPhase.Click
        TurnStart()

    End Sub

End Class

