Imports MySql.Data.MySqlClient

Public Class login

    Dim clsLogin As New clsLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim rs As MySqlDataReader

        If txtUsername.Text = "" Then
            MessageBox.Show("Please enter your username.", "VALIDATION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Please enter your password.", "VALIDATION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If

        rs = clsLogin.ProcessData("login", txtUsername.Text, txtPassword.Text)
        If rs.HasRows Then
            rs.Read()
            If rs!user = txtUsername.Text And rs!pass = txtPassword.Text Then
                My.Settings.ID = rs!ID
                mdiMain.Show()
                Me.Close()
                Exit Sub
            End If
        End If

        MessageBox.Show("Invalid username and password. Please try again.", "VALIDATION", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
