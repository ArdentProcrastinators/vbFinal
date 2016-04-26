Imports Microsoft.VisualBasic
Public Class Creature
    'The base power and health of the creature, what the stats are on the card
    Public BasePower As Integer
    Public BaseHealth As Integer
    'The power and health of the creature after all buffs are applied
    Public MaxPower As Integer
    Public MaxHealth As Integer
    'The creatures current health
    Public CurrentHealth As Integer
    'The creatures ID, stored so abilities can be activated more than once
    Public CreatureID As Integer
    'The amount of increases in power and health from buffs (This is added to the base to get the max)
    Dim BuffPower As Integer
    Dim BuffHealth As Integer

    'Sub called when something is set to New Creature(IBasePower, IBaseHealth, ICreatureID)
    '//NOTE: SUB HAS TO BE NAMED New//
    'IThe input variables have an I in front to signify they should only be used to set the variables in this form.
    'The variables In this form exist so If a creatures stats are changed it doesn't have to be remade.
    Public Sub New(ByVal IBasePower As Integer, ByVal IBaseHealth As Integer, ByVal ICreatureID As Integer)
        'Sets BasePower, BaseHealth, and CreatureID. After this point the I variables should not be used again.
        BasePower = IBasePower
        BaseHealth = IBaseHealth
        CreatureID = ICreatureID
        'The MaxPower and MaxHealth are set, this is done now incase the creature enters with any buffs, but could still be done again later.
        MaxPower = BasePower + BuffPower
        MaxHealth = BaseHealth + BuffHealth
        'Sets current health incase creature blocks immediately.
        CurrentHealth = MaxHealth
    End Sub
End Class
