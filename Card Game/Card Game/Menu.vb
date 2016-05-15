Public Class Menu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub formSizeChanged() Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Maximized
    End Sub

End Class