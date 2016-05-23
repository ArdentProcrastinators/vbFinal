Public Class IDTable

    Public Shared deck1 As New List(Of Card)
    Public Shared deck2 As New List(Of Card)
    Public Shared deck3 As New List(Of Card)
    Public Shared deck4 As New List(Of Card)
    Public Shared deck5 As New List(Of Card)
    Public Shared deck6 As New List(Of Card)

    Public Shared Function SetName(ID As Integer) As String

        Select Case ID
            Case 1
                Return "Noob Memer"
            Case 2
                Return "Ardent Procrastinator"
            Case 3
                Return "Island"
            Case 4
                Return "Swamp"
            Case 5
                Return "Forest"
            Case 6
                Return "Mountain"
            Case 7
                Return "Plains"
            Case 8
                Return "Levent's Bearded Dragon"
            Case 9
                Return "Dr Kirby"
            Case 10
                Return "Kevin the Lovemaker"
            Case 11
                Return "King of all Memes"
            Case 12
                Return "The Mad-Dabber"
            Case 13
                Return "League Scrub"
        End Select

    End Function

    Public Shared Function IDPower(ID As Integer) As Integer
        'Retuns power of creature from ID
        Select Case ID
            Case 1
                Return 2
            Case 2
                Return 2
            Case 8
                Return 3
            Case 9
                Return 5
            Case 10
                Return 3
            Case 11
                Return 7
            Case 12
                Return 4
            Case 13
                Return 3
            Case Else

                Return 100
        End Select
    End Function

    Public Shared Function IDHealth(ID As Integer) As Integer
        'Retuns Health of creature from ID
        Select Case ID
            Case 1
                Return 2
            Case 2
                Return 2
            Case 8
                Return 2
            Case 9
                Return 5
            Case 10
                Return 2
            Case 11
                Return 6
            Case 12
                Return 2
            Case 13
                Return 2
            Case Else
                'Error return, returned if ID does not exist
                Return 100
        End Select
    End Function

    Public Shared Sub SetMana(c As Card)

        Select Case c.ID
            Case 1
                'Add anys last
                c.manaCost.Add("green")
                c.manaCost.Add("any")
            Case 2
                c.manaCost.Add("black")
                c.manaCost.Add("black")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
            Case 3
                'Cost on lands is what they give
                c.manaCost.Add("blue")
            Case 4
                c.manaCost.Add("black")
            Case 5
                c.manaCost.Add("green")
            Case 6
                c.manaCost.Add("red")
            Case 7
                c.manaCost.Add("plains")
            Case 8
                c.manaCost.Add("red")
                c.manaCost.Add("green")
                c.manaCost.Add("any")
            Case 9
                c.manaCost.Add("white")
                c.manaCost.Add("white")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
            Case 10
                c.manaCost.Add("red")
                c.manaCost.Add("green")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
            Case 11
                c.manaCost.Add("green")
                c.manaCost.Add("green")
                c.manaCost.Add("green")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
            Case 12
                c.manaCost.Add("blue")
                c.manaCost.Add("green")
                c.manaCost.Add("any")
                c.manaCost.Add("any")
            Case 13
                c.manaCost.Add("red")
        End Select

    End Sub

    Public Shared Function IDImage(C As Card) As Image
        'Sets the new Card's Image to the card played
        Select Case C.ID
            Case 1
                Return My.Resources.NoobMemer
            Case 2
                Return My.Resources.Ardent_Procrastinor
            Case 3
                'Island
                If C.tapped = False Then
                    Return My.Resources.island
                Else
                    Return My.Resources.islandtu
                End If

            Case 4
                'Swamp
                If C.tapped = False Then
                    Return My.Resources.swamp
                Else
                    Return My.Resources.swamptu
                End If

            Case 5
                'Forest
                If C.tapped = False Then
                    Return My.Resources.forest
                Else
                    Return My.Resources.foresttu
                End If
            Case 6
                'Mountain
                If C.tapped = False Then
                    Return My.Resources.mountain
                Else
                    Return My.Resources.mountaintu
                End If
            Case 7
                'Plains
                If C.tapped = False Then
                    Return My.Resources.plains
                Else
                    Return My.Resources.plainstu
                End If
            Case 8
                Return My.Resources.Levents_Bearded_Dragon
            Case 9
                Return My.Resources.Dr_Kirby
            Case 10
                Return My.Resources.Kevin_the_lovemaker
            Case 11
                Return My.Resources.The_King_of_all_Memes
            Case 12
                Return My.Resources.The_Mad_Dabber
            Case 13
                Return My.Resources.LeagueScrub
        End Select
    End Function

    ''
    'END OF DEFAULT STUFF TO SET
    ''

    Public Shared Function IDAbility(c As Card) As Integer
        Select Case c.ID
            Case Is = 1
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you Like to give this creature -1/-0?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Applies debuff and stops ability process
                        Form1.Target.Buff(-1, 0)
                        Form1.NeedTarget = False
                    End If
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you Like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
                Return 1
            Case Is = 2
                '//ABILITY TEMPLATE//
                'If a target is being searched for
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case Is = 3
                '//LAND TEMPLATE//
                'Ez
                landUse(c)
            Case 4
                landUse(c)
            Case 5
                landUse(c)
            Case 6
                landUse(c)
            Case 7
                landUse(c)
            Case 8
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case 9
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case 10
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case 11
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case 12
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("This Creature's stats are " & c.MaxPower & "/" & c.CurrentHealth & ". Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
        End Select
        Return 0
    End Function

    Public Shared Sub landUse(c As Card)
        If c.used = False Then
            If c.tapped = False Then
                c.used = True
                Form1.AddMana(c.manaCost(0))
                c.BackgroundImage = TapImage(c)
            End If
        Else
            If c.tapped = False Then
                c.used = False
                Form1.RemMana(c.manaCost(0))
                c.BackgroundImage = IDImage(c)
            End If
        End If
    End Sub

    Public Shared Sub IDUseAbility(ID As Integer)
        Select Case ID
            Case 1
                Form1.Target.Buff(-1, 0)
            Case 2

            Case 3

            Case Is = 4

            Case Is = 5

        End Select

    End Sub

    Public Shared Function TapImage(c As Card)

        Select Case c.ID
            Case 3
                Return My.Resources.islandt
            Case 4
                Return My.Resources.swampu
            Case 5
                Return My.Resources.forestu
            Case 6
                Return My.Resources.mountainu
            Case 7
                Return My.Resources.plainsu
        End Select


    End Function



    Public Shared Sub PlayCard(c As Card)

        Select Case c.ID
            Case 1
                PlayCreature(c)
            Case 2
                PlayCreature(c)
            Case 3
                playLand(c)
            Case 4
                playLand(c)
            Case 5
                playLand(c)
            Case 6
                playLand(c)
            Case 7
                playLand(c)
            Case 8
                If PayMana(c) Then
                    If Form1.RadiantTurn Then
                        Form1.GenerateCreature(c.ID, True)
                        Form1.RadiantHandInfo.Remove(c)
                        c.Dispose()
                        Form1.UpdateHand(Form1.RadiantTurn)
                    Else
                        Form1.GenerateCreature(c.ID, True)
                        Form1.DireHandInfo.Remove(c)
                        c.Dispose()
                        Form1.UpdateHand(Form1.RadiantTurn)
                    End If
                End If
<<<<<<< HEAD
            Case 13
=======
            Case 9
                PlayCreature(c)
            Case 10
                PlayCreature(c)
            Case 11
                PlayCreature(c)
            Case 12
>>>>>>> origin/master
                PlayCreature(c)
        End Select

    End Sub

    Public Shared Sub PlayCreature(c As Card)
        If PayMana(c) Then
            If Form1.RadiantTurn Then
                Form1.GenerateCreature(c.ID, True)
                Form1.RadiantHandInfo.Remove(c)
                c.Dispose()
                Form1.UpdateHand(Form1.RadiantTurn)
            Else
                Form1.GenerateCreature(c.ID, True)
                Form1.DireHandInfo.Remove(c)
                c.Dispose()
                Form1.UpdateHand(Form1.RadiantTurn)
            End If
        End If
    End Sub


    Public Shared Sub playLand(c As Card)
        If Form1.landPlayed < Form1.landMax Then
            If Form1.RadiantTurn Then
                Form1.RadiantHandInfo.RemoveAt(Form1.RadiantHandInfo.IndexOf(c))
                Form1.landInfo.Add(c)
                Form1.rLandinfo.Add(c)
                c.partOfHand = False
                Form1.UpdateHand(Form1.RadiantTurn)
                Form1.Controls(c.Name).Top = Form1.Height - 500
                Form1.Controls(c.Name).Left = (c.Width * Form1.rLandinfo.Count) + 200
                Form1.landPlayed += 1
                c.Radiant = True
            Else
                Form1.DireHandInfo.RemoveAt(Form1.DireHandInfo.IndexOf(c))
                Form1.landInfo.Add(c)
                Form1.dLandinfo.Add(c)
                c.partOfHand = False
                Form1.UpdateHand(Form1.RadiantTurn)
                Form1.Controls(c.Name).Top = Form1.Height - 500
                Form1.Controls(c.Name).Left = (c.Width * Form1.dLandinfo.Count) + 200
                Form1.landPlayed += 1
                c.Radiant = False
            End If
        End If
    End Sub

    Public Shared Function PayMana(iC As Card) As Boolean

        'Ill comment this eventually
        If Form1.manaPool.Count <> 0 Then

            Dim testList As New List(Of String)
            Static counter As Integer

            For x As Integer = 1 To Form1.manaPool.Count
                testList.Add(Form1.manaPool(x - 1))
            Next


            For I As Integer = 0 To iC.manaCost.Count - 1

                counter = 0
                Dim result As Integer = 0

                Do Until result <> 0

                    If testList.Count = 0 Then Return False

                    If iC.manaCost(I) = testList(counter) Or iC.manaCost(I) = "any" Then

                        testList.Remove(testList(counter))
                        result = 1

                    ElseIf counter = testList.Count - 1
                        Return False
                    End If

                    counter += 1

                Loop

            Next

            Form1.TMC(iC)
            Form1.ManaLabel()
            Return True

        End If

    End Function



End Class
