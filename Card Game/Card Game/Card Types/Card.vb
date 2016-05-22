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

    Public manaCost As New List(Of String)

    Public tapped As Boolean
    Public used As Boolean 'Just for land

    'true = added and false = removed
    Public DBinfo As Boolean
    Public cardname As String

    Public partOfHand As Boolean = False
    Public Radiant As Boolean
    Public partOfDB As Boolean = False

    Public Sub MeClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If partOfDB = False Then
            If Radiant = Form1.RadiantTurn Then

                If Form1.started = True Then
                    Form1.Target = Me
                    'If in combat phase
                    If Form1.Phase = 1 Then
                        'Deals damage to the opponents health
                        If Radiant Then
                            Form1.DireHealth -= Me.MaxPower
                            Form1.lblTopHealth.Text = Form1.DireHealth
                        ElseIf Radiant = False
                            Form1.RadiantHealth -= Me.MaxPower
                            Form1.lblTopHealth.Text = Form1.RadiantHealth
                        End If
                    ElseIf partOfHand = False Then
                        IDTable.IDAbility(Me)
                    ElseIf partOfHand = True
                        IDTable.PlayCard(Me)
                    End If
                End If
            End If
        ElseIf partOfDB = True

            If e.Button = MouseButtons.Left Then
                DBinfo = True
            Else
                DBinfo = False
            End If

            DeckBuilder.UpdateInfo(Me)


        End If
    End Sub

    Public Sub New(IID As Integer, RadiantTurn As Boolean)
        ID = IID
        IDTable.SetMana(Me)
        Me.BackgroundImage = IDTable.IDImage(Me)
        Me.BackgroundImageLayout = ImageLayout.Zoom
        Me.cardname = IDTable.SetName(Me.ID)
        Radiant = RadiantTurn
        Form1.cardKeeper += 1
        Me.Name = "card" & Form1.cardKeeper
    End Sub

    Public Sub mouseOn() Handles Me.MouseEnter

        If partOfDB = False And (Me.Radiant = Form1.RadiantTurn) Or (Me.partOfHand = False And Me.Radiant <> Form1.RadiantTurn) Then

            Me.Width *= 1.85
            Me.Height *= 1.85
            Me.Top -= Me.Height / 2

        ElseIf partOfDB = True
            Me.Width *= 1.5
            Me.Height *= 1.5
        End If

    End Sub

    Public Sub MouseExit() Handles Me.MouseLeave

        If partOfDB = False And (Me.Radiant = Form1.RadiantTurn) Or (Me.partOfHand = False And Me.Radiant <> Form1.RadiantTurn) Then

            Me.Top += Me.Height / 2
            Me.Width /= 1.85
            Me.Height /= 1.85


        ElseIf partOfDB = True
            Me.Width /= 1.5
            Me.Height /= 1.5
        End If

        Form1.lblManaStatus.Text = ""
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
        MaxPower = BasePower + BuffPower
        MaxHealth = BaseHealth + BuffHealth
    End Sub
End Class
