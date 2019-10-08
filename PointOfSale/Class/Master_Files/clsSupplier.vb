Imports System.Data.SqlClient

Public Class clsSupplier

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spSupplier"
    Dim MessageBoxCaption As String

    Public Function GetListOfSupp() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfSupp")

            Try
                GetListOfSupp = .ExecuteReader
            Catch ex As Exception
                GetListOfSupp = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetSupp(ByVal Supplier_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetSupp")
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)

            Try
                GetSupp = .ExecuteReader
            Catch ex As Exception
                GetSupp = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestSuppNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestSuppNo")

            Try
                GetLatestSuppNo = .ExecuteReader
            Catch ex As Exception
                GetLatestSuppNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveSupp(ByVal Supplier_ID As String, ByVal Supplier_CompName As String, ByVal Supplier_CompAddress As String, ByVal Supplier_CompContactNo As String, ByVal Supplier_PicAddress As String, ByVal Supplier_CompEmail As String, ByVal Supplier_PicName As String, ByVal Supplier_PicContactNo As String, ByVal Supplier_LeadTime As Integer, ByVal Supplier_OrderCost As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveSupp")
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            .Parameters.AddWithValue("@Supplier_CompName", Supplier_CompName)
            .Parameters.AddWithValue("@Supplier_CompAddress", Supplier_CompAddress)
            .Parameters.AddWithValue("@Supplier_CompContactNo", Supplier_CompContactNo)
            .Parameters.AddWithValue("@Supplier_CompEmail", Supplier_CompEmail)
            .Parameters.AddWithValue("@Supplier_PicName", Supplier_PicName)
            .Parameters.AddWithValue("@Supplier_PicContactNo", Supplier_PicContactNo)
            .Parameters.AddWithValue("@Supplier_PicAddress", Supplier_PicAddress)
            .Parameters.AddWithValue("@Supplier_LeadTime", Supplier_LeadTime)
            .Parameters.AddWithValue("@Supplier_OrderCost", Supplier_OrderCost)

            Try
                .ExecuteNonQuery()
                SaveSupp = True
            Catch ex As Exception
                SaveSupp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteSupp(ByVal Supplier_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteSupp")
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)

            Try
                .ExecuteNonQuery()
                DeleteSupp = True
            Catch ex As Exception
                DeleteSupp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostSupp(ByVal Supplier_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostSupp")
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)

            Try
                .ExecuteNonQuery()
                PostSupp = True
            Catch ex As Exception
                PostSupp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelSupp(ByVal Supplier_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelSupp")
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)

            Try
                .ExecuteNonQuery()
                CancelSupp = True
            Catch ex As Exception
                CancelSupp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfExists(ByVal Supplier_CompName As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@Supplier_CompName", Supplier_CompName)

            Try
                CheckIfExists = .ExecuteReader()
            Catch ex As Exception
                CheckIfExists = Nothing
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
