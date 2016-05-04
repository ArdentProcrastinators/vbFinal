Public Class Card

    Inherits Button
    'The cards ID
    Public ID As Integer
    'The base power and health of the creature, what the stats are on the card
    Public BasePower As Integer
    Public BaseHealth As Integer
    'The power and health of the creature after all buffs are applied
    Public MaxPower As Integer
    Public MaxHealth As Integer
    'The creatures current health
    Public CurrentHealth As Integer
    'The amount of increases in power and health from buffs lasting until end of turn
    Public BuffPower As Integer
    Public BuffHealth As Integer

    Public tapped As Boolean

    Public partOfHand As Boolean = False

    Public Sub MeClick() Handles Me.Click

        If partOfHand = False Then
                IDTable.IDAbility(Form1.IDSearchingForTarget)
            ElseIf partOfHand = True
                'Playing card code here
            End If

    End Sub

    Public Sub New(IID As Integer)
        ID = IID
        Me.BackgroundImageLayout = ImageLayout.Zoom
    End Sub

    Public Sub mouseOn() Handles Me.MouseEnter

        Me.Top -= Me.Height
        Me.Width *= 2
        Me.Height *= 2
        Dim right As Boolean
        Dim rightChanged As Integer
        Dim cumulativeCardLen As Decimal

        If partOfHand = True And Form1.handInfo.Count <> 1 Then
            For I As Integer = 1 To Form1.handInfo.Count

                If Form1.Controls("card" & I) IsNot Me And right = True Then

                    Form1.Controls("card" & I).Left += Me.Width / 2
                    rightChanged += 1

                ElseIf Form1.Controls("card" & I) Is Me
                    right = True
                End If

                cumulativeCardLen += Form1.Controls("card" & I).Width

            Next
            'Yo... I don't even know what I made, but it works...
            Dim leftLevel = (Form1.Controls("card1").Left - ((Form1.Width - Form1.Controls("card1").Left) - cumulativeCardLen)) / (Form1.handInfo.Count * 2)

            For x As Integer = 1 To Form1.handInfo.Count

                Form1.Controls("card" & x).Left -= leftLevel

            Next
        End If
    End Sub

    Public Sub MouseExit() Handles Me.MouseLeave

        Me.Width *= 1 / 2
        Me.Height *= 1 / 2
        Me.Top += Me.Height
        Dim right As Boolean

        If partOfHand = True And Form1.handInfo.Count <> 1 Then
            For I As Integer = 1 To Form1.handInfo.Count

                If Form1.Controls("card" & I) IsNot Me And right = True Then

                    Form1.Controls("card" & I).Left -= Me.Width

                ElseIf Form1.Controls("card" & I) Is Me
                    right = True
                End If

            Next
        End If
    End Sub


    'The input variables have an I in front to signify they should only be used to set the variables in this form.
    Public Sub DefineCreature(C As Card)
        'Sets BasePower, BaseHealth, and CreatureID. After this point the I variables should not be used again.
        BasePower = IDTable.IDPower(C.ID)
        BaseHealth = IDTable.IDHealth(C.ID)
        'The MaxPower and MaxHealth are set, this is done now incase the creature enters with any buffs, but could still be done again later.
        MaxPower = BasePower + BuffPower
        MaxHealth = BaseHealth + BuffHealth
        'Sets current health incase creature blocks immediately.
        CurrentHealth = MaxHealth
    End Sub

    Public Sub Buff(ByVal IBuffPower As Integer, ByVal IBuffHealth As Integer)
        BuffPower += IBuffPower
        BuffHealth += IBuffHealth
        CurrentHealth += IBuffHealth
    End Sub
End Class
