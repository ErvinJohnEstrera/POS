Imports System.Data.SqlClient

Public Class clsOrder

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spOrder"
    Dim MessageBoxCaption As String

    Public Function GetListOforder() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOforder")

            Try
                GetListOforder = .ExecuteReader
            Catch ex As Exception
                GetListOforder = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetListOforderdetails(ByVal Order_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOforderdetails")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                GetListOforderdetails = .ExecuteReader
            Catch ex As Exception
                GetListOforderdetails = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Getorder(ByVal Order_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "Getorder")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                Getorder = .ExecuteReader
            Catch ex As Exception
                Getorder = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestorderNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestorderNo")

            Try
                GetLatestorderNo = .ExecuteReader
            Catch ex As Exception
                GetLatestorderNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function Saveorder(ByVal Order_ID As String, ByVal Order_Date As String, ByVal Customer_ID As String, ByVal Status As String, ByVal Order_No As String, ByVal Total_Items As Integer, ByVal Sub_Total As Decimal, ByVal Sales_Tax As Decimal, ByVal Discount As Decimal, ByVal Amount_Due As Decimal, ByVal Payment_Due As Decimal, ByVal Grand_Total As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Saveorder")
            .Parameters.AddWithValue("@Order_ID", Order_ID)
            .Parameters.AddWithValue("@Order_Date", Order_Date)
            .Parameters.AddWithValue("@Customer_ID", Customer_ID)
            .Parameters.AddWithValue("@Status", Status)
            .Parameters.AddWithValue("@Order_No", Order_No)
            .Parameters.AddWithValue("@Total_Items", Total_Items)
            .Parameters.AddWithValue("@Sub_Total", Sub_Total)
            .Parameters.AddWithValue("@Sales_Tax", Sales_Tax)
            .Parameters.AddWithValue("@Discount", Discount)
            .Parameters.AddWithValue("@Amount_Due", Amount_Due)
            .Parameters.AddWithValue("@Payment_Due", Payment_Due)
            .Parameters.AddWithValue("@Grand_Total", Grand_Total)

            Try
                .ExecuteNonQuery()
                Saveorder = True
            Catch ex As Exception
                Saveorder = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function SaveorderD(ByVal Order_ID As String, ByVal Menu_ID As String, ByVal Unit_Price As Decimal, ByVal Qty As Integer, ByVal Discount As Decimal, ByVal Sub_total As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveorderD")
            .Parameters.AddWithValue("@Order_ID", Order_ID)
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)
            .Parameters.AddWithValue("@Unit_Price", Unit_Price)
            .Parameters.AddWithValue("@Qty", Qty)
            .Parameters.AddWithValue("@Discount", Discount)
            .Parameters.AddWithValue("@Sub_total", Sub_total)

            Try
                .ExecuteNonQuery()
                SaveorderD = True
            Catch ex As Exception
                SaveorderD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Deleteorder(ByVal Order_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Deleteorder")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                .ExecuteNonQuery()
                Deleteorder = True
            Catch ex As Exception
                Deleteorder = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeleteorderPayment(ByVal Order_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteorderPayment")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                .ExecuteNonQuery()
                DeleteorderPayment = True
            Catch ex As Exception
                DeleteorderPayment = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeleteorderDetails(ByVal Order_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteorderD")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                .ExecuteNonQuery()
                DeleteorderDetails = True
            Catch ex As Exception
                DeleteorderDetails = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function Postorder(ByVal Order_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Postorder")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                .ExecuteNonQuery()
                Postorder = True
            Catch ex As Exception
                Postorder = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Cancelorder(ByVal Order_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Cancelorder")
            .Parameters.AddWithValue("@Order_ID", Order_ID)

            Try
                .ExecuteNonQuery()
                Cancelorder = True
            Catch ex As Exception
                Cancelorder = False
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