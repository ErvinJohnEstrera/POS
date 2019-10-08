Imports MySql.Data.MySqlClient

Public Class clsLogin
    Dim Con As New MySqlConnection

    Public Function ProcessData(ByVal mode As String, ByVal username As String, ByVal password As String) As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0

            If mode = "login" Then
                .CommandText = "SELECT ID, user, pass FROM `mf_emp` WHERE `user`=@user AND `pass`=@pass"
                .Parameters.AddWithValue("@user", username)
                .Parameters.AddWithValue("@pass", password)
            End If

            Try
                ProcessData = .ExecuteReader()
            Catch ex As Exception
                ProcessData = Nothing
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Sub ReOpenConnection()
        With Con
            If .State = ConnectionState.Open Then
                .Close()
            End If

            SQLConnect()
        End With
    End Sub

    Sub SQLConnect()
        Con = New MySqlConnection

        With Con
            .ConnectionString = "Server=127.0.0.1; Database=pos; Uid=root; Pwd=jeffreyestrera011897@@;"
            .Open()
        End With
    End Sub

    Sub New()
        SQLConnect()
    End Sub
End Class
