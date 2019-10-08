Imports System.Data.SqlClient

Public Class clsPurchaseOrder

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spPurchaseOrder"
    Dim MessageBoxCaption As String

    Public Function GetListOfPO() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfPO")

            Try
                GetListOfPO = .ExecuteReader
            Catch ex As Exception
                GetListOfPO = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetPO(ByVal PO_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetPO")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                GetPO = .ExecuteReader
            Catch ex As Exception
                GetPO = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetPOD(ByVal PO_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetPOD")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                GetPOD = .ExecuteReader
            Catch ex As Exception
                GetPOD = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestPONo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestPONo")

            Try
                GetLatestPONo = .ExecuteReader
            Catch ex As Exception
                GetLatestPONo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SavePO(ByVal PO_Header_ID As String, ByVal PO_Header_Date As Date, ByVal Supplier_ID As String, ByVal PO_Header_Status As String, ByVal PO_Header_Remarks As String, ByVal PO_Header_PreparedBy As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SavePO")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)
            .Parameters.AddWithValue("@PO_Header_Date", PO_Header_Date)
            .Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            .Parameters.AddWithValue("@PO_Header_Status", PO_Header_Status)
            .Parameters.AddWithValue("@PO_Header_Remarks", PO_Header_Remarks)
            .Parameters.AddWithValue("@PO_Header_PreparedBy", PO_Header_PreparedBy)

            Try
                .ExecuteNonQuery()
                SavePO = True
            Catch ex As Exception
                SavePO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function SavePOD(ByVal Items_ID As String, ByVal PO_Details_Qty As Integer, ByVal PO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SavePOD")
            .Parameters.AddWithValue("@Items_ID", Items_ID)
            .Parameters.AddWithValue("@PO_Details_Qty", PO_Details_Qty)
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                .ExecuteNonQuery()
                SavePOD = True
            Catch ex As Exception
                SavePOD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function


    Public Function DeletePO(ByVal PO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeletePO")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                .ExecuteNonQuery()
                DeletePO = True
            Catch ex As Exception
                DeletePO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeletePOD(ByVal PO_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeletePOD")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)

            Try
                .ExecuteNonQuery()
                DeletePOD = True
            Catch ex As Exception
                DeletePOD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostPO(ByVal PO_Header_ID As String, ByVal PO_Header_PostedBy As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostPO")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)
            .Parameters.AddWithValue("@PO_Header_PostedBy", PO_Header_PostedBy)
            .Parameters.AddWithValue("@PO_Header_PostedDate", Date.Now)

            Try
                .ExecuteNonQuery()
                PostPO = True
            Catch ex As Exception
                PostPO = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelPO(ByVal PO_Header_ID As String, ByVal PO_Header_CancelledBy As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelPO")
            .Parameters.AddWithValue("@PO_Header_ID", PO_Header_ID)
            .Parameters.AddWithValue("@PO_Header_CancelledBy", PO_Header_CancelledBy)
            .Parameters.AddWithValue("@PO_Header_CancelDate", Date.Now)

            Try
                .ExecuteNonQuery()
                CancelPO = True
            Catch ex As Exception
                CancelPO = False
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