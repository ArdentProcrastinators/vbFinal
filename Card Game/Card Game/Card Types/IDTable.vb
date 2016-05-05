Public Class IDTable
    Public Shared Function IDPower(ID As Integer) As Integer
        'Retuns power of creature from ID
        Select Case ID
            Case 1
                Return 2
            Case 2
                Return 2
            Case 3
                Return 3
            Case 4
                Return 4
            Case 5
                Return 5
            Case Else
                'Error return, returned if ID does not exist
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
            Case 3
                Return 4
            Case 4
                Return 5
            Case 5
                Return 6
            Case Else
                'Error return, returned if ID does not exist
                Return 100
        End Select
    End Function

    Public Shared Function IDAbility(c As Card) As Integer
        Select Case c.ID
            Case Is = 1
                If Form1.NeedTarget = True Then
                    'Confirms this is target of ability
                    If MsgBox("Would you like to give this creature -1/-0?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Applies debuff and stops ability process
                        Form1.Target.Buff(-1, 0)
                        Form1.NeedTarget = False
                    End If
                ElseIf MsgBox("Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
                    If MsgBox("Would you like to [list ability]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'Ability code
                        'Disables target search
                        Form1.NeedTarget = False
                    End If
                    'If no target is needed currently
                ElseIf MsgBox("Would you like to use this card's ability?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Says a target is needed if ability is used, starts search for target
                    Form1.NeedTarget = True
                    Form1.IDSearchingForTarget = c.ID
                End If
            Case Is = 3
                '//LAND TEMPLATE//
                'Ez
                If c.used = False Then
                    c.used = True
                    Form1.manaPool.Add("blue")
                    c.BackgroundImage = My.Resources.islandt
                Else
                    c.used = False
                    Form1.manaPool.Remove("blue")
                    c.BackgroundImage = My.Resources.island
                End If
                Form1.ManaLabel()
            Case 4
                Return 0
            Case 5
                Return 0
        End Select
        Return 0
    End Function

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

    Public Shared Function IDImage(C As Card) As Image
        'Sets the new Card's Image to the card played
        Select Case C.ID
            Case 1
                Return My.Resources.NoobMemer
            Case 2
                Return My.Resources.Ardent_Procrastinor
            Case 3
                Return My.Resources.island
            Case 4

            Case 5

            Case 31

        End Select
    End Function

    Public Shared Sub PlayCard(c As Card)

        Select Case c.ID
            Case 1
                If PayMana(c) Then

                End If
            Case 2

            Case 3

                Form1.handInfo.RemoveAt(Form1.handInfo.IndexOf(c))
                Form1.landInfo.Add(c)
                c.partOfHand = False
                Form1.UpdateHand()
                c.Name = "land" & Form1.landInfo.Count
                Form1.Controls(c.Name).Top = -50 * Form1.landInfo.Count + Form1.Height / 4
                Form1.Controls(c.Name).Left = 100

        End Select

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

                    If iC.manaCost(I) = testList(counter) Or iC.manaCost(I) = "any" Then

                        testList.Remove(testList(counter))
                        result = 1

                    ElseIf counter = testList.Count - 1
                        result = 2
                    End If

                    counter += 1

                Loop

                If result = 2 Then Return False

            Next

            For x As Integer = 1 To Form1.manaPool.Count
                Form1.manaPool.Remove(testList(x - 1))
            Next

            Return True

        End If

    End Function

    Public Shared Sub SetMana(c As Card)

        Select Case c.ID
            Case 1
                c.manaCost.Add("green")
                c.manaCost.Add("any")
            Case 2

        End Select

    End Sub

End Class
