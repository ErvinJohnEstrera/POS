Imports System.Data.SqlClient

Public Class clsDiscount

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spDiscount"
    Dim MessageBoxCaption As String

    Public Function GetListOfDisc() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfDisc")

            Try
                GetListOfDisc = .ExecuteReader
            Catch ex As Exception
                GetListOfDisc = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetDisc(ByVal Discount_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetDisc")
            .Parameters.AddWithValue("@Discount_ID", Discount_ID)

            Try
                GetDisc = .ExecuteReader
            Catch ex As Exception
                GetDisc = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestDiscNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestDiscNo")

            Try
                GetLatestDiscNo = .ExecuteReader
            Catch ex As Exception
                GetLatestDiscNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveDisc(ByVal Discount_ID As String, ByVal Discount_Desc As String, ByVal Discount_Amount As Decimal, ByVal Discount_BeginDate As Date, ByVal Discount_EndDate As Date) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveDisc")
            .Parameters.AddWithValue("@Discount_ID", Discount_ID)
            .Parameters.AddWithValue("@Discount_Desc", Discount_Desc)
            .Parameters.AddWithValue("@Discount_Amount", Discount_Amount)
            .Parameters.AddWithValue("@Discount_BeginDate", Discount_BeginDate)
            .Parameters.AddWithValue("@Discount_EndDate", Discount_EndDate)

            Try
                .ExecuteNonQuery()
                SaveDisc = True
            Catch ex As Exception
                SaveDisc = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteDisc(ByVal Discount_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteDisc")
            .Parameters.AddWithValue("@Discount_ID", Discount_ID)

            Try
                .ExecuteNonQuery()
                DeleteDisc = True
            Catch ex As Exception
                DeleteDisc = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostDisc(ByVal Discount_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostDisc")
            .Parameters.AddWithValue("@Discount_ID", Discount_ID)

            Try
                .ExecuteNonQuery()
                PostDisc = True
            Catch ex As Exception
                PostDisc = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelDisc(ByVal Discount_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelDisc")
            .Parameters.AddWithValue("@Discount_ID", Discount_ID)

            Try
                .ExecuteNonQuery()
                CancelDisc = True
            Catch ex As Exception
                CancelDisc = False
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