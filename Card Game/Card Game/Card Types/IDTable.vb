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

    Public Shared Function IDAbilityTargeted(ID As Integer) As Integer
        'Returns true if ability needs a target, false if it does not
        Select Case ID
            Case Is = 1
                'RETURN ENDS THE SUB! MAKE ALL DECLARATIONS BEFORE IT! - Levent
                Form1.IDSearchingForTarget = 1
                Return 1
            Case 2
                Return 0
            Case 3
                Return 0
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
        'Return for this function is not required and is for troubleshooting
        Select Case C.ID
            Case 1
                Return My.Resources.NoobMemer
            Case 2
                Return My.Resources.Ardent_Procrastinor
            Case 3

            Case 4

            Case 5

            Case 31
                Return My.Resources.island
        End Select
    End Function

End Class
