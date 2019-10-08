Imports System.Data.SqlClient

Public Class clsCustomer

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spCustomer"
    Dim MessageBoxCaption As String

    Public Function GetListOfCust() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfCust")

            Try
                GetListOfCust = .ExecuteReader
            Catch ex As Exception
                GetListOfCust = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetCust(ByVal Customer_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetCust")
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)

            Try
                GetCust = .ExecuteReader
            Catch ex As Exception
                GetCust = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestCustNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestCustNo")

            Try
                GetLatestCustNo = .ExecuteReader
            Catch ex As Exception
                GetLatestCustNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveCust(ByVal Customer_ID As String, ByVal Customer_FirstName As String, ByVal Customer_MiddleName As String, ByVal Customer_LastName As String, ByVal Customer_Email As String, ByVal Customer_PhoneNo As String, ByVal Customer_TelephoneNo As String, ByVal Customer_Address As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveCust")
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)
            .Parameters.AddWithValue("@Customer_FirstName", Customer_FirstName)
            .Parameters.AddWithValue("@Customer_MiddleName", Customer_MiddleName)
            .Parameters.AddWithValue("@Customer_LastName", Customer_LastName)
            .Parameters.AddWithValue("@Customer_Email", Customer_Email)
            .Parameters.AddWithValue("@Customer_PhoneNo", Customer_PhoneNo)
            .Parameters.AddWithValue("@Customer_TelephoneNo", Customer_TelephoneNo)
            .Parameters.AddWithValue("@Customer_Address", Customer_Address)

            Try
                .ExecuteNonQuery()
                SaveCust = True
            Catch ex As Exception
                SaveCust = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteCust(ByVal Customer_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteCust")
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)

            Try
                .ExecuteNonQuery()
                DeleteCust = True
            Catch ex As Exception
                DeleteCust = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostCust(ByVal Customer_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostCust")
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)

            Try
                .ExecuteNonQuery()
                PostCust = True
            Catch ex As Exception
                PostCust = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelCust(ByVal Customer_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelCust")
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)

            Try
                .ExecuteNonQuery()
                CancelCust = True
            Catch ex As Exception
                CancelCust = False
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