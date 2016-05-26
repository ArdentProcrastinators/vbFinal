Public Class Form1
    'Info of the decks
    Public RadiantDeckInfo As New List(Of Integer)
    Public DireDeckInfo As New List(Of Integer)
    Public RadiantHandInfo As New List(Of Card)
    Public DireHandInfo As New List(Of Card)
    Public RadiantCardsInHand
    Public DireCardsInHand
    'Somewhat redundant list of card ids
    Public RadiantCardInfo As New List(Of Integer)
    Public DireCardInfo As New List(Of Integer)
    Public manaPool As New List(Of String)
    Public landInfo As New List(Of Card)
    Public rLandinfo As New List(Of Card)
    Public dLandinfo As New List(Of Card)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Card)
    Public DireCreatures As New List(Of Card)
    Dim cardScale As Decimal = 0.25
    Public RadiantHealth As Integer = 20
    Public DireHealth As Integer = 20
    'Public Target As Card
    Public Target As Card
    Public NeedTarget As Boolean
    Public IDSearchingForTarget As Integer
    Public RadiantTurn As Boolean = True
    'Parts of turn, 0 is main phase, 1 is attacking
    Public Phase As Integer
    Public started As Boolean
    Public landPlayed As Integer
    Public landMax As Integer = 1
    'Decks being used
    Public RadiantUsedDeck As New List(Of Card)
    Public DireUsedDeck As New List(Of Card)

    Public cardKeeper As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        'Sets each player's deck to their chosen deck
        SetDecks()
        'Sets the health labels
        lblBottomHealth.Text = RadiantHealth
        lblTopHealth.Text = DireHealth
        'Places the health and turn labels in their correct places
        lblTopHealth.Top = Me.Height / 2 - lblTopHealth.Height * 2 - 40
        lblTopHealth.Left = Me.Width - lblTopHealth.Width - 125
        lblBottomHealth.Top = Me.Height / 2 + lblBottomHealth.Height * 2 - 10
        lblBottomHealth.Left = Me.Width - lblBottomHealth.Width - 125
        lblTurn.Top = Me.Height / 2 - 20
        lblTurn.Left = Me.Width - 150
        lblPhase.Top = Me.Height / 2
        lblPhase.Left = Me.Width - 150
        For I As Integer = 1 To RadiantUsedDeck.Count
            'Adds the cards to Radiant's deck list
            RadiantCardInfo.Add(RadiantUsedDeck(I - 1).ID)
            RadiantDeckInfo.Add(1) 'Adds the proper amount of items to radiant deck info so it can be set without erroring
        Next
        'Adds the cards to Dire's deck
        For I As Integer = 1 To DireUsedDeck.Count
            'Adds the cards to Dire's deck list
            DireCardInfo.Add(DireUsedDeck(I - 1).ID)
            DireDeckInfo.Add(1) 'Adds the proper amount of items to Dire deck info so it can be set without erroring

        Next

        'Shuffles
        ShuffleCards(RadiantDeckInfo)
        ShuffleCards(DireDeckInfo)

        'Draws
        DrawCards(7, RadiantDeckInfo, RadiantHandInfo, RadiantCardInfo)
        DrawCards(7, DireDeckInfo, DireHandInfo, DireCardInfo)
        MoveCards()

    End Sub

    Private Sub SetDecks()
        'Sets the deckInfo for the player to the chosen deck
        'Can't use select case because each if statement refrences a different object
        If frmDeckSelection.rdbP1S1.Checked = True Then
            RadiantUsedDeck = IDTable.deck1
        ElseIf frmDeckSelection.rdbP1S2.Checked = True Then
            RadiantUsedDeck = IDTable.deck2
        ElseIf frmDeckSelection.rdbP1S3.Checked = True Then
            RadiantUsedDeck = IDTable.deck3
        ElseIf frmDeckSelection.rdbP1S4.Checked = True Then
            RadiantUsedDeck = IDTable.deck4
        ElseIf frmDeckSelection.rdbP1S5.Checked = True Then
            RadiantUsedDeck = IDTable.deck5
        ElseIf frmDeckSelection.rdbP1S6.Checked = True Then
            RadiantUsedDeck = IDTable.deck6
        End If

        If frmDeckSelection.rdbP2S1.Checked = True Then
            DireUsedDeck = IDTable.deck1
        ElseIf frmDeckSelection.rdbP2S2.Checked = True Then
            DireUsedDeck = IDTable.deck2
        ElseIf frmDeckSelection.rdbP2S3.Checked = True Then
            DireUsedDeck = IDTable.deck3
        ElseIf frmDeckSelection.rdbP2S4.Checked = True Then
            DireUsedDeck = IDTable.deck4
        ElseIf frmDeckSelection.rdbP2S5.Checked = True Then
            DireUsedDeck = IDTable.deck5
        ElseIf frmDeckSelection.rdbP2S6.Checked = True Then
            DireUsedDeck = IDTable.deck6
        End If
    End Sub


    Public Sub ShuffleCards(deckInfo As List(Of Integer))

        'Referenced variables in some for loops
        Dim cardCount As Integer = deckInfo.Count
        'Keeps track what indexes are left
        Dim cardsLeft As New List(Of Integer)

        For V As Integer = 1 To cardCount
            cardsLeft.Add(V) 'Adds proper items to the list
        Next

        'Shuffles cards
        For I As Integer = 0 To cardCount - 1

            Randomize()
            Dim x As Integer = Int(cardsLeft.Count() * Rnd()) 'Chooses a random item in the list
            deckInfo.Item(I) = cardsLeft(x) 'Sets deckinfo's item to that value
            cardsLeft.Remove(cardsLeft(x)) 'Removes that value from the list so that it cannot be picked again

        Next

    End Sub


    Public Sub DrawCards(n As Integer, desDeck As List(Of Integer), desHand As List(Of Card), desCardInfo As List(Of Integer))
        'Draws n cards
        For I As Integer = 1 To n
            Dim nC As New Card(desCardInfo(desDeck(0) - 1), RadiantTurn) ' makes new card
            desHand.Add(nC) ' adds it to hand
            desDeck.Remove(desDeck(0)) ' removes from deck
        Next

        UpdateHand(RadiantTurn)

    End Sub

    Public Sub UpdateHand(Radiant As Boolean)
        'If Radiant hand is updating
        If Radiant Then
            'Disposes old cards
            If RadiantCardsInHand <> 0 Then
                For Each c As Card In RadiantHandInfo

                    If Me.Controls(c.Name) IsNot Nothing And c.Radiant = RadiantTurn Then Me.Controls(c.Name).Dispose()

                Next
            End If

            'I don't know if this is even important
            GC.Collect()
            GC.WaitForPendingFinalizers()

            'Resets cards in hand since all cards have been deleted
            RadiantCardsInHand = 0

            'Adds new cards
            For I As Integer = 1 To RadiantHandInfo.Count

                'Makes a new card with correct ID
                Dim newCard As New Card(RadiantHandInfo(I - 1).ID, RadiantTurn)
                newCard.partOfHand = True
                newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
                newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
                newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50 'Sets position of card
                newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * RadiantCardsInHand + (Me.Width - RadiantHandInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
                newCard.Visible = True
                RadiantHandInfo.Item(I - 1) = newCard
                Me.Controls.Add(RadiantHandInfo(I - 1))

                RadiantCardsInHand += 1

            Next
            'Resets cardsInHand
            RadiantCardsInHand = RadiantHandInfo.Count
            'If dire hand is updating
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

                'Makes new card
                Dim newCard As New Card(DireHandInfo(I - 1).ID, RadiantTurn)
                newCard.partOfHand = True
                newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
                newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
                newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50 'SEts card's position
                newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * DireCardsInHand + (Me.Width - DireHandInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
                newCard.Visible = True
                DireHandInfo.Item(I - 1) = newCard
                Me.Controls.Add(DireHandInfo(I - 1))

                DireCardsInHand += 1

            Next
            'Resets cards in hand
            DireCardsInHand = DireHandInfo.Count
        End If


    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged
        'If they change the form's size remaximizes it, doesn't let them resize form
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMulligan_Click(sender As Object, e As EventArgs) Handles btnMulligan.Click
        'Keeps mulligan count to draw the correct amount of cards
        Static mulliganCount As Integer = 1
        'If radiant is mulliganing
        'Will always be true, only radiant has the option to mulligan
        If RadiantTurn Then
            'If they have more than 1 card (They can't mulligan with just one card)
            If RadiantHandInfo.Count > 1 Then

                For Each c As Card In RadiantHandInfo
                    'Deletes cards
                    If Me.Controls(c.Name) IsNot Nothing And c.Radiant = RadiantTurn Then Me.Controls(c.Name).Dispose()

                Next
                'Clears the hand and deck
                RadiantDeckInfo.Clear()
                RadiantHandInfo.Clear()

                For I As Integer = 1 To RadiantUsedDeck.Count
                    'Adds proper amount of elements
                    RadiantDeckInfo.Add(1)

                Next
                'Shuffles cards
                ShuffleCards(RadiantDeckInfo)
                'Clears the hand
                For Each c As Card In RadiantHandInfo
                    Me.Controls(c.Name).Dispose()
                Next
                'Draws the correct number of cards
                DrawCards(7 - mulliganCount, RadiantDeckInfo, RadiantHandInfo, RadiantCardInfo)
                mulliganCount += 1
                'Else if they only have 1 card in their hand
            Else
                'Doesn't let them mulligan because they don't have enough cards
                btnMulligan.Enabled = False
            End If
            'Won't ever be run, Dire can't mulligan
        ElseIf RadiantTurn = False Then
            'If they have more than 1 card (They can't mulligan with just one card)
            If DireHandInfo.Count > 1 Then

                For Each c As Card In DireHandInfo
                    'Deletes cards
                    If Me.Controls(c.Name) IsNot Nothing And c.Radiant = RadiantTurn Then Me.Controls(c.Name).Dispose()

                Next
                'Clears the hand and deck
                DireDeckInfo.Clear()
                DireHandInfo.Clear()

                For I As Integer = 1 To DireUsedDeck.Count
                    'adds proper amount of elements
                    DireDeckInfo.Add(1)
                Next
                'Shuflles cards then clears hand
                ShuffleCards(DireDeckInfo)
                For Each c As Card In DireHandInfo
                    Me.Controls(c.Name).Dispose()
                Next
                'Draws the correct number of cards
                DrawCards(7 - mulliganCount, DireDeckInfo, DireHandInfo, DireDeckInfo)

                mulliganCount += 1
                'Else if they only have 1 card in their hand
            Else
                'Doesn't let them mulligan because they don't have enough cards
                btnMulligan.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'Confirms hand and disables mulliganing
        btnMulligan.Dispose()
        btnConfirm.Dispose()
        started = True
        btnNextPhase.Enabled = True
    End Sub

    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'If Radiant played it
        If Radiant Then
            'Moves current creatures over
            For x = 0 To RadiantCreatures.Count - 1
                RadiantCreatures(x).Left -= Me.Width / 32
            Next
            'Makes new Card object
            Dim newCreature As New Card(CreatureID, True)
            'Sets image
            newCreature.BackgroundImageLayout = ImageLayout.Zoom
            newCreature.BackgroundImage = IDTable.IDImage(newCreature)
            'Sets size
            newCreature.Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            newCreature.Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            'Sets stats
            newCreature.DefineCreature(newCreature)
            'Adds it to the creatures list
            RadiantCreatures.Add(newCreature)
            'Adds the card to the controls list, required for making new control
            Me.Controls.Add(newCreature)
            'Sets the card's position
            newCreature.Top = Me.Height / 2
            newCreature.Left = Me.Width / 2 + (Me.Width / 32 * (RadiantCreatures.Count - 2))
        Else
            'Same as above only for the Dire side
            For x = 0 To DireCreatures.Count - 1
                DireCreatures(x).Left -= Me.Width / 32
            Next
            Dim newCreature As New Card(CreatureID, False)
            newCreature.BackgroundImageLayout = ImageLayout.Zoom
            newCreature.BackgroundImage = IDTable.IDImage(newCreature)
            newCreature.Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            newCreature.Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            newCreature.DefineCreature(newCreature)
            DireCreatures.Add(newCreature)
            Me.Controls.Add(newCreature)
            newCreature.Top = Me.Height / 2
            newCreature.Left = Me.Width / 2 + (Me.Width / 32 * (RadiantCreatures.Count - 2))

        End If

    End Sub

    Public Sub ManaLabel()
        'Resets mana label
        lblMana.Text = "Mana:" & vbNewLine
        'Adds the current mana to the label
        For Each m As String In manaPool
            lblMana.Text &= m & vbNewLine
        Next

    End Sub

    Public Sub AddMana(m As String)

        'Adds mana to manapool
        manaPool.Add(m)
        ManaLabel()

    End Sub

    Public Sub RemMana(m As String)
        'Clears manaPool list and the label
        manaPool.Remove(m)
        ManaLabel()

    End Sub

    'Transfers mana cost(removes mana and taps land)
    Public Sub TMC(c As Card)

        Dim payed As Boolean

        For x As Integer = 1 To c.manaCost.Count


            Dim m As Integer = 0
            payed = False

            'Checks whether mana is specified
            If c.manaCost(x - 1) <> "any" Then
                Do Until payed = True

                    'Checks whether the land is of the desired mana
                    If landInfo(m).manaCost(0) = c.manaCost(x - 1) And landInfo(m).used = True And landInfo(m).tapped = False Then
                        landInfo(m).tapped = True 'taps land
                        landInfo(m).BackgroundImage = IDTable.IDImage(landInfo(m)) 'sets image
                        payed = True
                    End If
                    m += 1

                Loop
                manaPool.Remove(c.manaCost(x - 1))
            Else
                Do Until payed = True

                    'Checks whether the land is of the desired mana
                    If m > landInfo.Count - 1 Then MsgBox("error")
                    If landInfo(m).used = True And landInfo(m).tapped = False Then
                        landInfo(m).tapped = True
                        landInfo(m).BackgroundImage = IDTable.IDImage(landInfo(m))
                        payed = True
                    End If
                    m += 1
                Loop
                manaPool.Remove(landInfo(m - 1).manaCost(0))                 'Removes mana uses from mana pool
            End If
        Next
    End Sub

    Public Sub TurnStart()
        'Clears mana
        manaPool.Clear()
        ManaLabel()

        For Each c As Card In landInfo
            c.tapped = False
            c.used = False
            c.BackgroundImage = IDTable.IDImage(c)                           'Untaps lands
        Next
        landPlayed = 0                                                       'Resets lands playable
        landMax = 1
        MsgBox("Please switch seats with the other player", MsgBoxStyle.OkOnly) 'Tells the players to switch
        RadiantTurn = Not (RadiantTurn)                                      'Switches RadiantTurn's value
        MoveCards()                                                          'Moves cards to the opposite side of the field and changes their image
        If RadiantTurn Then                                                  'Switches the health labels and changes the turn label
            lblBottomHealth.Text = RadiantHealth
            lblTopHealth.Text = DireHealth
            lblTurn.Text = "Radiant's Turn"
        ElseIf RadiantTurn = False Then
            lblBottomHealth.Text = DireHealth
            lblTopHealth.Text = RadiantHealth
            lblTurn.Text = "Dire's Turn"
        End If
        Draw(RadiantTurn)                                                    'Draws a card for whoever's turn it is

    End Sub
    Private Sub MoveCards()
        For Each ThisControl As Control In Me.Controls
            If TypeOf (ThisControl) Is Card Then
                Dim c As Card = ThisControl                                  'Casts ThisControl as Card so paramaters like Radiant can be used
                c.Top = Me.Height - (c.Top + c.Height)                       'Flips the cards to opposite side of form, top to bottom and bottom to top
                If c.partOfHand = True Then
                    If RadiantTurn = c.Radiant Then                          'If card is supposed to be in the hand of the current player's turn
                        c.BackgroundImage = IDTable.IDImage(c)               'Sets current player's cards in hand's images to the image of the card
                    Else
                        c.BackgroundImage = My.Resources.cardBack            'Sets other player's cards in hand's image to card back to hide the cards
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Draw(RadiantIsDrawing As Boolean)
        If RadiantIsDrawing Then                                             'If Radiant is drawing
            DrawCards(1, RadiantDeckInfo, RadiantHandInfo, RadiantCardInfo)  'Draws 1 card from the radiant deck to the radiant hand
        ElseIf RadiantIsDrawing = False Then                                 'If Dire is drawing
            DrawCards(1, DireDeckInfo, DireHandInfo, DireCardInfo)           'Draws 1 card from the dire deck to the dire hand
        End If
        Debug.Print(RadiantCardsInHand)
        Debug.Print(DireCardsInHand)
    End Sub

    Private Sub btnTS_Click(sender As Object, e As EventArgs) Handles btnNextPhase.Click

        If Phase = 0 Then                                                    'Changes the phase and ends the turn if needed
            Phase = 1
            lblPhase.Text = "Combat Phase"
        ElseIf Phase = 1 Then
            Phase = 0
            lblPhase.Text = "Main Phase"
            TurnStart()
        End If
    End Sub

End Class

