Imports MySql.Data.MySqlClient

Public Class ClsLogs

    Dim Con As New MySqlConnection

    Public Function getListLogTrail() As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT * FROM util_logtrail"

            Try
                getListLogTrail = .ExecuteReader
            Catch ex As Exception
                getListLogTrail = Nothing
                ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/LOGTRAIL/FillDataGrid", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Sub ProcessDataLogTrail(ByVal mode As String, ByVal emp_no As String, ByVal activity As String, ByVal errMessage As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "logtrail" Then
                .CommandText = "INSERT INTO `util_logtrail` (`emp_no`,`activity`,`errMessage`,`date`) VALUES (@emp_no,@activity,@errMessage,@date)"
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@activity", activity)
                .Parameters.AddWithValue("@errMessage", errMessage)
                .Parameters.AddWithValue("@date", DateTime.Now)
            ElseIf mode = "logout" Then
                .CommandText = "UPDATE `util_logtrail` SET `name`=@name, `activity`=@activity WHERE `id`=@id"
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@activity", activity)
                .Parameters.AddWithValue("@errMessage", errMessage)
                .Parameters.AddWithValue("@date", DateTime.Now)
            ElseIf mode = "delete" Then
                .CommandText = "UPDATE `util_logtrail` SET `name`=@name, `activity`=@activity WHERE `id`=@id"
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@activity", activity)
                .Parameters.AddWithValue("@errMessage", errMessage)
                .Parameters.AddWithValue("@date", DateTime.Now)
            ElseIf mode = "deleteall" Then
                .CommandText = "DELETE FROM mf_cat WHERE `id`=@id"
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@activity", activity)
                .Parameters.AddWithValue("@errMessage", errMessage)
                .Parameters.AddWithValue("@date", DateTime.Now)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/LOGTRAIL/AddDelete", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try

        End With
    End Sub

    Public Function getListLogInOut() As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT * FROM mf_cat"

            Try
                getListLogInOut = .ExecuteReader
            Catch ex As Exception
                getListLogInOut = Nothing
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Sub ProcessDataLogInOut(ByVal mode As String, ByVal id As Integer, ByVal name As String, ByVal desc As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "login" Then
                .CommandText = "INSERT INTO `util_logtrail` (`emp_no`,`in`,`date`) values (@name, @description)"
                .Parameters.AddWithValue("@name", name)
                .Parameters.AddWithValue("@description", desc)
            ElseIf mode = "logout" Then
                .CommandText = "UPDATE `mf_cat` SET `name`=@name, `desc`=@description WHERE `id`=@id"
                .Parameters.AddWithValue("@id", id)
                .Parameters.AddWithValue("@name", name)
                .Parameters.AddWithValue("@description", desc)
            ElseIf mode = "delete" Then
                .CommandText = "UPDATE `mf_cat` SET `name`=@name, `desc`=@description WHERE `id`=@id"
                .Parameters.AddWithValue("@id", id)
                .Parameters.AddWithValue("@name", name)
                .Parameters.AddWithValue("@description", desc)
            ElseIf mode = "deleteall" Then
                .CommandText = "DELETE FROM mf_cat WHERE `id`=@id"
                .Parameters.AddWithValue("@id", id)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try

        End With
    End Sub

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
