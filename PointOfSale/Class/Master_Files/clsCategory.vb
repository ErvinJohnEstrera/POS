Imports System.Data.SqlClient

Public Class clsCategory

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spCategory"
    Dim MessageBoxCaption As String
    Public Function GetListOfCat() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfCat")

            Try
                GetListOfCat = .ExecuteReader
            Catch ex As Exception
                GetListOfCat = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetCat(ByVal Category_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetCat")
            .Parameters.AddWithValue("@Category_ID", Category_ID)

            Try
                GetCat = .ExecuteReader
            Catch ex As Exception
                GetCat = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestCatNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestCatNo")

            Try
                GetLatestCatNo = .ExecuteReader
            Catch ex As Exception
                GetLatestCatNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveCat(ByVal Category_ID As Integer, ByVal Category_Name As String, ByVal Category_Description As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveCat")
            .Parameters.AddWithValue("@Category_ID", Category_ID)
            .Parameters.AddWithValue("@Category_Name", Category_Name)
            .Parameters.AddWithValue("@Category_Description", Category_Description)

            Try
                .ExecuteNonQuery()
                SaveCat = True
            Catch ex As Exception
                SaveCat = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteCat(ByVal Category_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteCat")
            .Parameters.AddWithValue("@Category_ID", Category_ID)

            Try
                .ExecuteNonQuery()
                DeleteCat = True
            Catch ex As Exception
                DeleteCat = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostCat(ByVal Category_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostCat")
            .Parameters.AddWithValue("@Category_ID", Category_ID)

            Try
                .ExecuteNonQuery()
                PostCat = True
            Catch ex As Exception
                PostCat = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelCat(ByVal Category_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelCat")
            .Parameters.AddWithValue("@Category_ID", Category_ID)

            Try
                .ExecuteNonQuery()
                CancelCat = True
            Catch ex As Exception
                CancelCat = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfExistsCat(ByVal Category_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExistsCat")
            .Parameters.AddWithValue("@Category_Name", Category_Name)

            Try
                CheckIfExistsCat = .ExecuteReader
            Catch ex As Exception
                CheckIfExistsCat = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfInUsedCat(ByVal Category_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfInUsedCat")
            .Parameters.AddWithValue("@Category_Name", Category_Name)

            Try
                CheckIfInUsedCat = .ExecuteReader
            Catch ex As Exception
                CheckIfInUsedCat = Nothing
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