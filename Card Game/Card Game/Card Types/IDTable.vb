Public Class IDTable
    Public Shared Function IDPower(ID As Integer) As Integer
        'Retuns power of creature from ID
        Select Case ID
            Case Is = 1
                Return 1
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
End Class
