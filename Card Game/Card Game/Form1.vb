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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        For I As Integer = 1 To 60

            'adds 60 elements
            Randomize()
            'Not Sure if this is correct, might be tho
            RadiantCardInfo.Add(Int(8 * Rnd() + 1))
            RadiantDeckInfo.Add(1)
            Randomize()
            DireCardInfo.Add(Int(8 * Rnd() + 1))
            DireDeckInfo.Add(1)
        Next

        ShuffleCards(RadiantDeckInfo)
        ShuffleCards(DireDeckInfo)
        'Need to understand cardInfo
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


    Public Sub DrawCards(n As Integer, desDeck As List(Of Integer), desHand As List(Of Card))

        For I As Integer = 1 To n
            Dim nC As New Card(cardInfo(desDeck(0) - 1), RadiantTurn)
            nC.Name = "card" & I
            desHand.Add(nC)
            desDeck.Remove(desDeck(0))
        Next

        UpdateHand()

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
                newCard.Name = "card" & I
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
                newCard.Name = "card" & I
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

                For I As Integer = 1 To 60
                    'adds 60 elements
                    RadiantDeckInfo.Add(1)
                Next

                ShuffleCards(RadiantDeckInfo)
                Me.Controls("card" & 8 - mulliganCount).Dispose()
                DrawCards(7 - mulliganCount, RadiantDeckInfo, RadiantHandInfo)

                mulliganCount += 1

            Else
                btnMulligan.Enabled = False
            End If
        ElseIf RadiantTurn = False Then
            If DireHandInfo.Count > 1 Then

                DireDeckInfo.Clear()
                DireHandInfo.Clear()

                For I As Integer = 1 To 60
                    'adds 60 elements
                    DireDeckInfo.Add(1)
                Next

                ShuffleCards(DireDeckInfo)
                Me.Controls("card" & 8 - mulliganCount).Dispose()
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
            Debug.Print(RadiantCreatures.Count)
            newCreature.Top = Me.Height / 2
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

    Public Sub TMC(c As Card)

        Dim payed As Boolean

        For x As Integer = 1 To c.manaCost.Count


            Dim m As Integer = 0
            payed = False

            If c.manaCost(x - 1) <> "any" Then
                Do Until payed = True

                    If landInfo(m).manaCost(0) = c.manaCost(x - 1) And landInfo(m).used = True And landInfo(m).tapped = False Then
                        landInfo(m).tapped = True
                        landInfo(m).BackgroundImage = IDTable.IDImage(landInfo(m))
                        payed = True
                    End If
                    m += 1

                Loop
                manaPool.Remove(c.manaCost(x - 1))
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

        manaPool.Clear()
        ManaLabel()

        For Each c As Card In landInfo
            c.tapped = False
            c.used = False
            c.BackgroundImage = IDTable.IDImage(c)
        Next

        landPlayed = 0
        landMax = 1

        RadiantTurn = Not (RadiantTurn)
        For Each x As Control In Me.Controls
            If TypeOf (x) Is Card Then
                Dim c As Card = x
                If x.Top < Me.Height Then
                    x.Top = Me.Height - x.Top - x.Height
                ElseIf x.Top > Me.Height Then
                    x.Top = -(x.Top - Me.Height)
                End If
                If c.partOfHand = True Then
                    If RadiantTurn = True And c.Radiant = True Then
                        c.BackgroundImage = IDTable.IDImage(c)
                    ElseIf RadiantTurn = False And c.Radiant = False Then
                        c.BackgroundImage = IDTable.IDImage(c)
                    Else
                        c.BackgroundImage = My.Resources.cardBack
                    End If
                End If
            End If
        Next

        DrawCards(1, deckInfo, handInfo)

    End Sub

    Private Sub btnTS_Click(sender As Object, e As EventArgs) Handles btnNextPhase.Click
        TurnStart()

    End Sub

    Private Sub btnSpawn_Click(sender As Object, e As EventArgs) Handles btnSpawn.Click
        GenerateCreature(1, True)
    End Sub
End Class

