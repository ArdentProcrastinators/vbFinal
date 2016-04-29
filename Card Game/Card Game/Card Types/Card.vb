Public Class Card

    Inherits Button
    Public ID As Integer


    Public Sub MeClick() Handles Me.Click
        MsgBox("")
    End Sub

    Public Sub New(iID As Integer)
        ID = iID
    End Sub

End Class
