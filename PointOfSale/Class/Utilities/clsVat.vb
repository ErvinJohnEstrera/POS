Imports MySql.Data.MySqlClient

Public Class ClsVat

    Dim Con As New MySqlConnection
    Dim ClsLogs As New ClsLogs

    Public Function getVatValue() As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT id,value FROM util_vat"

            Try
                getVatValue = .ExecuteReader
            Catch ex As Exception
                getVatValue = Nothing
                ClsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "UTILITIES/VAT/getVatValue", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Sub Process(ByVal mode As String, ByVal id As Integer, ByVal value As Integer)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "update" Then
                .CommandText = "UPDATE `util_vat` SET `value`=@value WHERE `id`=@id"
                .Parameters.AddWithValue("@id", id)
                .Parameters.AddWithValue("@value", value)
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
