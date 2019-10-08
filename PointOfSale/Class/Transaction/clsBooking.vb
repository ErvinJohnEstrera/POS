Imports System.Data.SqlClient

Public Class clsBooking

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spBooking"
    Dim MessageBoxCaption As String

    Public Function GetListOfBook() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfBook")

            Try
                GetListOfBook = .ExecuteReader
            Catch ex As Exception
                GetListOfBook = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetBook(ByVal Booking_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetBook")
            .Parameters.AddWithValue("@Booking_ID", Booking_ID)

            Try
                GetBook = .ExecuteReader
            Catch ex As Exception
                GetBook = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestBookNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestBookNo")

            Try
                GetLatestBookNo = .ExecuteReader
            Catch ex As Exception
                GetLatestBookNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveBook(ByVal Booking_ID As String, ByVal Booking_Date As Date, ByVal Head_Count As Integer, ByVal Customer_ID As String, ByVal Table_ID As String, ByVal Status As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveBook")
            .Parameters.AddWithValue("@Booking_ID", Booking_ID)
            .Parameters.AddWithValue("@Booking_Date", Booking_Date)
            .Parameters.AddWithValue("@Head_Count", Head_Count)
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)
            .Parameters.AddWithValue("@Table_ID", Table_ID)
            .Parameters.AddWithValue("@Status", Status)

            Try
                .ExecuteNonQuery()
                SaveBook = True
            Catch ex As Exception
                SaveBook = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteBook(ByVal Booking_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteBook")
            .Parameters.AddWithValue("@Booking_ID", Booking_ID)

            Try
                .ExecuteNonQuery()
                DeleteBook = True
            Catch ex As Exception
                DeleteBook = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostBook(ByVal Booking_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostBook")
            .Parameters.AddWithValue("@Booking_ID", Booking_ID)

            Try
                .ExecuteNonQuery()
                PostBook = True
            Catch ex As Exception
                PostBook = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelBook(ByVal Booking_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelBook")
            .Parameters.AddWithValue("@Booking_ID", Booking_ID)
            .Parameters.AddWithValue("@Status", "Cancelled")

            Try
                .ExecuteNonQuery()
                CancelBook = True
            Catch ex As Exception
                CancelBook = False
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