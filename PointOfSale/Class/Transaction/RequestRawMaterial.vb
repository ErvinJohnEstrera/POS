Imports System.Data.SqlClient

Public Class RequestedRawMaterial

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spRequestedRawMaterial"
    Dim MessageBoxCaption As String

    Public Function GetListOfRRM() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfRRM")

            Try
                GetListOfRRM = .ExecuteReader
            Catch ex As Exception
                GetListOfRRM = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetRRM(ByVal RRM_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetRRM")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                GetRRM = .ExecuteReader
            Catch ex As Exception
                GetRRM = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetRRMD(ByVal RRM_Header_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetRRMD")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                GetRRMD = .ExecuteReader
            Catch ex As Exception
                GetRRMD = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestRRMNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestRRMNo")

            Try
                GetLatestRRMNo = .ExecuteReader
            Catch ex As Exception
                GetLatestRRMNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetItmStock(ByVal Items_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = "spItems"
            .Parameters.AddWithValue("@Mode", "GetItmStock")
            .Parameters.AddWithValue("@Items_ID", Items_ID)

            Try
                GetItmStock = .ExecuteReader
            Catch ex As Exception
                GetItmStock = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveRRM(ByVal RRM_Header_ID As String, ByVal RRM_Header_Date As Date, ByVal Employee_ID As String, ByVal RRM_Header_PreparedBy As String, ByVal RRM_Header_Remarks As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveRRM")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)
            .Parameters.AddWithValue("@RRM_Header_Date", RRM_Header_Date)
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)
            .Parameters.AddWithValue("@RRM_Header_PreparedBy", RRM_Header_PreparedBy)
            .Parameters.AddWithValue("@RRM_Header_Remarks", RRM_Header_Remarks)

            Try
                .ExecuteNonQuery()
                SaveRRM = True
            Catch ex As Exception
                SaveRRM = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function SaveRRMD(ByVal Items_ID As String, ByVal RRM_Details_Qty As Integer, ByVal RRM_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveRRMD")
            .Parameters.AddWithValue("@Items_ID", Items_ID)
            .Parameters.AddWithValue("@RRM_Details_Qty", RRM_Details_Qty)
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                .ExecuteNonQuery()
                SaveRRMD = True
            Catch ex As Exception
                SaveRRMD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeleteRRM(ByVal RRM_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteRRM")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                .ExecuteNonQuery()
                DeleteRRM = True
            Catch ex As Exception
                DeleteRRM = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeleteRRMD(ByVal RRM_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteRRMD")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                .ExecuteNonQuery()
                DeleteRRMD = True
            Catch ex As Exception
                DeleteRRMD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostRRM(ByVal RRM_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostRRM")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                .ExecuteNonQuery()
                PostRRM = True
            Catch ex As Exception
                PostRRM = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelRRM(ByVal RRM_Header_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelRRM")
            .Parameters.AddWithValue("@RRM_Header_ID", RRM_Header_ID)

            Try
                .ExecuteNonQuery()
                CancelRRM = True
            Catch ex As Exception
                CancelRRM = False
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