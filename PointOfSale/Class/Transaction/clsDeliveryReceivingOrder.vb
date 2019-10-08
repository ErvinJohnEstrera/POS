Imports System.Data.SqlClient

Public Class clsDeliveryReceivingOrder

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spDeliveryReceivingOrder"
    Dim MessageBoxCaption As String

    Public Function GetListOfDRO() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfDRO")

            Try
                GetListOfDRO = .ExecuteReader
            Catch ex As Exception
                GetListOfDRO = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetDRO(ByVal DRO_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetDRO")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)

            Try
                GetDRO = .ExecuteReader
            Catch ex As Exception
                GetDRO = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetDROD(ByVal DRO_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetDROD")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)

            Try
                GetDROD = .ExecuteReader
            Catch ex As Exception
                GetDROD = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestDRONo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestDRONo")

            Try
                GetLatestDRONo = .ExecuteReader
            Catch ex As Exception
                GetLatestDRONo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveDRO(ByVal DRO_Header_ID As String, ByVal DRO_Header_Date As Date, ByVal Supplier_ID As String, ByVal Employee_ID As String, ByVal DRO_Header_TotalItems As Integer, ByVal DRO_Header_SubTotal As Decimal, ByVal DRO_Header_SalesTax As Decimal, ByVal DRO_Header_GrandTotal As Decimal, ByVal PO_Header_ID As String, ByVal DRO_Header_PaymentDue As Decimal, ByVal Amount_Due As String, ByVal DRO_Header_Remarks As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveDRO")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)
            .Parameters.AddWithValue("@DRO_Header_Date", DRO_Header_Date)
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)
            .Parameters.AddWithValue("@DRO_Header_TotalItems", DRO_Header_TotalItems)
            .Parameters.AddWithValue("@DRO_Header_SubTotal", DRO_Header_SubTotal)
            .Parameters.AddWithValue("@DRO_Header_SalesTax", DRO_Header_SalesTax)
            .Parameters.AddWithValue("@DRO_Header_GrandTotal", DRO_Header_GrandTotal)
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)
            .Parameters.AddWithValue("@DRO_Header_PaymentDue", DRO_Header_PaymentDue)
            .Parameters.AddWithValue("@Amount_Due", Amount_Due)
            .Parameters.AddWithValue("@DRO_Header_Remarks", DRO_Header_Remarks)

            Try
                .ExecuteNonQuery()
                SaveDRO = True
            Catch ex As Exception
                SaveDRO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function SaveDROD(ByVal Items_ID As String, ByVal DRO_Details_UnitPrice As Decimal, ByVal DRO_Details_Qty As Integer, ByVal DRO_Details_BadQty As Integer, ByVal DRO_Details_BackQty As Integer, ByVal PO_Header_ID As String, ByVal DRO_Details_SubTotal As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveDROD")
            .Parameters.AddWithValue("@Items_ID", Items_ID)
            .Parameters.AddWithValue("@DRO_Details_UnitPrice", DRO_Details_UnitPrice)
            .Parameters.AddWithValue("@DRO_Details_Qty", DRO_Details_Qty)
            .Parameters.AddWithValue("@DRO_Details_BadQty", DRO_Details_BadQty)
            .Parameters.AddWithValue("@DRO_Details_BackQty", DRO_Details_BackQty)
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)
            .Parameters.AddWithValue("@DRO_Details_SubTotal", DRO_Details_SubTotal)

            Try
                .ExecuteNonQuery()
                SaveDROD = True
            Catch ex As Exception
                SaveDROD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeleteDRO(ByVal DRO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteDRO")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)

            Try
                .ExecuteNonQuery()
                DeleteDRO = True
            Catch ex As Exception
                DeleteDRO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function
    Public Function DeleteDROD(ByVal PO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteDROD")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                .ExecuteNonQuery()
                DeleteDROD = True
            Catch ex As Exception
                DeleteDROD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function
    Public Function GetTax() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "GetTax")

            Try

                GetTax = .ExecuteReader()
            Catch ex As Exception
                GetTax = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostDRO(ByVal DRO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostDRO")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)

            Try
                .ExecuteNonQuery()
                PostDRO = True
            Catch ex As Exception
                PostDRO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelDRO(ByVal DRO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelDRO")
            .Parameters.AddWithValue("@DRO_Header_ID", DRO_Header_ID)

            Try
                .ExecuteNonQuery()
                CancelDRO = True
            Catch ex As Exception
                CancelDRO = False
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