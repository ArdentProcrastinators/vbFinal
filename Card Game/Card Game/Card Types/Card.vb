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
    'The amount of increases in power and health from buffs (This is added to the base to get the max)
    Dim BuffPower As Integer
    Dim BuffHealth As Integer


    Public Sub MeClick() Handles Me.Click
        MsgBox("")
    End Sub

    Public Sub New(IID As Integer)
        ID = IID
        Me.BackgroundImageLayout = ImageLayout.Zoom
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
