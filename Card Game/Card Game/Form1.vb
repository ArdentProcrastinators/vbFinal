Public Class Form1
    Public deckInfo As New List(Of Integer)
    Public handInfo As New List(Of Card)
    Public cardInfo As New List(Of Integer)
    Public manaPool As New List(Of String)
    Public landInfo As New List(Of Card)
    'List for each player's creatures
    Public RadiantCreatures As New List(Of Card)
    Public DireCreatures As New List(Of Card)
    Dim cardScale As Decimal = Me.Height / 1024
    Public RadinatHealth As Integer
    Public DireHealth As Integer
    'Public Target As Card
    Public Target As Card
    Public NeedTarget As Boolean
    Public IDSearchingForTarget As Integer

    Public cardsInHand
    Public started As Boolean
    Public landPlayed As Integer
    Public landMax As Integer = 1

    Public usedDeck As New List(Of Card)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        For I As Integer = 1 To 60

            'adds 60 elements
            Randomize()
            cardInfo.Add(Int(8 * Rnd() + 1))
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


    Public Sub DrawCards(n As Integer, desDeck As List(Of Integer), desHand As List(Of Card))

        For I As Integer = 1 To n
            Dim nC As New Card(cardInfo(desDeck(0) - 1))
            nC.Name = "card" & I
            desHand.Add(nC)
            desDeck.Remove(desDeck(0))
        Next

        UpdateHand()

    End Sub

    Public Sub UpdateHand()

        'Disposes old cards
        If cardsInHand <> 0 Then
            For Each c As Card In handInfo

                If Me.Controls(c.Name) IsNot Nothing Then Me.Controls(c.Name).Dispose()

            Next
        End If

        GC.Collect()
        GC.WaitForPendingFinalizers()

        'Resets cards in hand since all cards have been deleted
        cardsInHand = 0

        'Adds new cards
        For I As Integer = 1 To handInfo.Count

            Dim newCard As New Card(handInfo(I - 1).ID)
            newCard.partOfHand = True
            newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width 'Sets width accordingly with cardscale
            newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height 'Sets height accordingly with cardscale
            newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
            newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * cardsInHand + (Me.Width - handInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
            newCard.Visible = True
            newCard.Name = "card" & I
            handInfo.Item(I - 1) = newCard
            Me.Controls.Add(handInfo(I - 1))

            cardsInHand += 1

        Next

        cardsInHand = handInfo.Count

    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged

        UpdateHand()
        Me.WindowState = FormWindowState.Maximized
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
            Me.Controls("card" & 8 - mulliganCount).Dispose()
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
            Dim newCreature As New Card(CreatureID)
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
            Dim newCreature As New Card(CreatureID)
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

        DrawCards(1, deckInfo, handInfo)

    End Sub

    Private Sub btnTS_Click(sender As Object, e As EventArgs) Handles btnTS.Click
        TurnStart()

    End Sub

    Private Sub btnSpawn_Click(sender As Object, e As EventArgs) Handles btnSpawn.Click
        GenerateCreature(1, True)
    End Sub
End Class

