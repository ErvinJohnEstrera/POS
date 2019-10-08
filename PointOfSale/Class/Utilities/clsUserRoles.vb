Imports System.Data.SqlClient

Public Class clsUserRoles

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spUserRoles"
    Dim MessageBoxCaption As String

    Public Function GetListOfUR() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfUR")

            Try
                GetListOfUR = .ExecuteReader
            Catch ex As Exception
                GetListOfUR = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetUR(ByVal UserRole_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetUR")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                GetUR = .ExecuteReader
            Catch ex As Exception
                GetUR = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestURNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestURNo")

            Try
                GetLatestURNo = .ExecuteReader
            Catch ex As Exception
                GetLatestURNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveUR(ByVal UserRole_ID As Integer, ByVal UserRole_Name As String, ByVal UserRole_Description As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveUR")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)
            .Parameters.AddWithValue("@UserRole_Name", UserRole_Name)
            .Parameters.AddWithValue("@UserRole_Description", UserRole_Description)

            Try
                .ExecuteNonQuery()
                SaveUR = True
            Catch ex As Exception
                SaveUR = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteUR(ByVal UserRole_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteUR")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                .ExecuteNonQuery()
                DeleteUR = True
            Catch ex As Exception
                DeleteUR = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfExists(ByVal UserRole_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@UserRole_Name", UserRole_Name)

            Try
                CheckIfExists = .ExecuteReader()
            Catch ex As Exception
                CheckIfExists = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfInUsed(ByVal UserRole_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfInUsed")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                CheckIfInUsed = .ExecuteReader()
            Catch ex As Exception
                CheckIfInUsed = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function


    Public Function PostUR(ByVal UserRole_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostUR")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                .ExecuteNonQuery()
                PostUR = True
            Catch ex As Exception
                PostUR = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelUR(ByVal UserRole_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelUR")
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                .ExecuteNonQuery()
                CancelUR = True
            Catch ex As Exception
                CancelUR = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

#Region "Misc"

    Private Sub ReOpenConnection()
        With connData
            If .State = ConnectionState.Open Then
                .Close()
            End If
            .Open()
        End With
    End Sub

    Sub New()
        connData = New SqlConnection

        With connData
            .ConnectionString = "Data Source=" + My.Settings.AppServer + ";Initial Catalog=" + My.Settings.AppDatabase & vbNewLine &
                                ";User ID=edestrera;Password=pass1word"
            .Open()
        End With
    End Sub

#End Region

End Class
