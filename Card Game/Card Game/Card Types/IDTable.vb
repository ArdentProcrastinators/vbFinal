Public Class IDTable
    Public Shared Function IDPower(ID As Integer) As Integer
        'Retuns power of creature from ID
        Select Case ID
            Case Is = 1
                Return 2
            Case Is = 2
                Return 2
            Case Is = 3
                Return 3
            Case Is = 4
                Return 4
            Case Is = 5
                Return 5
            Case Else
                'Error return, returned if ID does not exist
                Return 100
        End Select
    End Function

    Public Shared Function IDHealth(ID As Integer) As Integer
        'Retuns Health of creature from ID
        Select Case ID
            Case Is = 1
                Return 2
            Case Is = 2
                Return 3
            Case Is = 3
                Return 4
            Case Is = 4
                Return 5
            Case Is = 5
                Return 6
            Case Else
                'Error return, returned if ID does not exist
                Return 100
        End Select
    End Function

    Public Shared Function IDAbility(ID As Integer) As String
        Select Case ID
            Case Is = 1
                Return ""
            Case Is = 2
                Return 3
            Case Is = 3
                Return 4
            Case Is = 4
                Return 5
            Case Is = 5
                Return 6
        End Select
        Return 0
    End Function

    Public Shared Function IDImage(C As Card) As Image
        'Sets the new Card's Image to the card played
        'Return for this function is not required and is for troubleshooting
        Select Case C.ID
            Case Is = 1
                '//USED TO SET IMAGE OF CARD WHEN IT IS PLAYED, UNCOMMENT AND ADD IMAGE WHEN CARD IMAGES EXIST//
                Return My.Resources.NoobMemer
            Case Is = 2

            Case Is = 3

            Case Is = 4

            Case Is = 5

        End Select
    End Function

End Class
