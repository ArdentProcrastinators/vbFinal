﻿Public Class Form1
    Dim deckInfo As New List(Of Integer)
    Dim handInfo As New List(Of Integer)
    'List for each player's creatures
    Public RadiantCreatureInfo As New List(Of Creature)
    Public RadiantPlayedCreatures As New List(Of Card)
    Public DireCreatureInfo As New List(Of Creature)
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

        Static cardsInHand As Integer

        If cardsInHand <> 0 Then
            For I As Integer = 1 To handInfo.Count

                Me.Controls("card" & I).Dispose()

            Next
        End If

        cardsInHand = 0


        For I As Integer = 1 To handInfo.Count

            Dim newCard As New Card
            newCard.Image = My.Resources.Ardent_Procrastinor
            newCard.SizeMode = PictureBoxSizeMode.Zoom
            newCard.Width = cardScale * My.Resources.Ardent_Procrastinor.Width
            newCard.Height = cardScale * My.Resources.Ardent_Procrastinor.Height
            newCard.Top = Me.Height - cardScale * My.Resources.Ardent_Procrastinor.Height - 50
            newCard.Left = cardScale * My.Resources.Ardent_Procrastinor.Width * cardsInHand + (Me.Width - handInfo.Count * cardScale * My.Resources.Ardent_Procrastinor.Width) / 2
            newCard.Visible = True
            newCard.Name = "card" & I
            Me.Controls.Add(newCard)

            cardsInHand += 1

        Next


    End Sub

    Private Sub formSizeChange() Handles Me.SizeChanged
        UpdateHand()
    End Sub

    'Sub is called when a creature is played
    Public Sub GenerateCreature(CreatureID As Integer, Radiant As Boolean)
        'If Radiant played it
        If Radiant Then
            'Adds a new creature to the Radiant's creature list
            'The I In front represents that the value is an input, and Is only used to set the values in the class correctly
            'View the Creature.vb class for more info, located in CardTypes Folder
            RadiantCreatureInfo.Add(New Creature(1, 1, CreatureID))

            RadiantPlayedCreatures.Add(New Card)
            IDTable.IDImage(CreatureID, RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1))
            RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1).Height = My.Resources.Ardent_Procrastinor.Height * cardScale
            RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1).Width = My.Resources.Ardent_Procrastinor.Width * cardScale
            'RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1).Visible = True

            Me.Controls.Add(RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1))

            Debug.Print(RadiantPlayedCreatures(RadiantPlayedCreatures.Count - 1).Left)
        Else
            'Same as above only for the Dire side
            DireCreatureInfo.Add(New Creature(1, 1, CreatureID))
            lblTestP.Text = "Health: " & DireCreatureInfo(DireCreatureInfo.Count - 1).MaxPower
            lblTestT.Text = "Power: " & DireCreatureInfo(DireCreatureInfo.Count - 1).MaxHealth
            lblNumCreatures.Text = DireCreatureInfo.Count
        End If

    End Sub

End Class

