Public Class Form1

    Dim _IsMouseDown As Boolean
    Dim _LastMouseMove As Point
    Dim _IsMouseVDown As Boolean

    Private Function GetMousePosition() As Point
        Return (Me.PointToScreen(System.Windows.Forms.Control.MousePosition))
    End Function

    Private Sub ScrollPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles ScrollPanel.MouseDown
        'if the mouse is not already pressed
        If Not _IsMouseDown Then
            'set the mouse to down (Main panel)
            _IsMouseDown = True
            'Record the position of the mouse down
            _LastMouseMove = GetMousePosition()
        End If
    End Sub

    Private Sub ScrollPanel_MouseUp(sender As Object, e As MouseEventArgs) Handles ScrollPanel.MouseUp
        If _IsMouseDown Then
            'finished scrolling
            _IsMouseDown = False
        End If
    End Sub

    Private Sub ScrollPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles ScrollPanel.MouseMove
        'if the mouse is down, aka we're scrolling
        If _IsMouseDown Then
            'grab the current mouse position and see if it has moved
            Dim currentlMouse = GetMousePosition()
            If Not _LastMouseMove = currentlMouse Then
                'check if it would be going over the top of the panel
                If ScrollPanel.Location.Y + (currentlMouse.Y - _LastMouseMove.Y) > 0 Then
                    'if it is, set it to the top
                    ScrollPanel.Top = 0
                Else
                    'check if it would be going past the bottom of the panel
                    If (ScrollPanel.Location.Y + (currentlMouse.Y - _LastMouseMove.Y)) < (ScrollPanel.Height - Me.Height) * -1 Then
                        'if it Is, set it to the bottom
                        ScrollPanel.Location = New Point(ScrollPanel.Location.X, (ScrollPanel.Height - Me.Height) * 1)
                    Else
                        'other wise move it based off the change in mouse positon
                        ScrollPanel.Location = New Point(ScrollPanel.Location.X,
                        ScrollPanel.Location.Y + (currentlMouse.Y - _LastMouseMove.Y))
                    End If
                End If
            End If
            'record the current mouse as the last mouse
            _LastMouseMove = GetMousePosition()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class