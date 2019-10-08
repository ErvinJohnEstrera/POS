Imports System.Data.SqlClient

Public Class clsItems

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spItems"
    Dim MessageBoxCaption As String

    Public Function GetListOfItm() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfItm")

            Try
                GetListOfItm = .ExecuteReader
            Catch ex As Exception
                GetListOfItm = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetItm(ByVal Items_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetItm")
            .Parameters.AddWithValue("@Items_ID", Items_ID)

            Try
                GetItm = .ExecuteReader
            Catch ex As Exception
                GetItm = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestItmNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestItmNo")

            Try
                GetLatestItmNo = .ExecuteReader
            Catch ex As Exception
                GetLatestItmNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function CheckIfExists(ByVal Item_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@Items_Name", Item_Name)

            Try
                CheckIfExists = .ExecuteReader
            Catch ex As Exception
                CheckIfExists = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function CheckIfInUsed(ByVal Item_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfInUsed")
            .Parameters.AddWithValue("@Items_ID", Item_ID)

            Try
                CheckIfInUsed = .ExecuteReader
            Catch ex As Exception
                CheckIfInUsed = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveItm(ByVal Items_ID As String, ByVal Items_Name As String, ByVal Category_ID As Integer, ByVal UOM_ID As Integer, ByVal Items_ReOrderLvl As Integer, ByVal Items_SafetyStock As Integer, ByVal Items_StartQty As Integer, ByVal Items_UnitPrice As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveItm")
            .Parameters.AddWithValue("@Items_ID", Items_ID)
            .Parameters.AddWithValue("@Items_Name", Items_Name)
            .Parameters.AddWithValue("@Category_ID", Category_ID)
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)
            .Parameters.AddWithValue("@Items_ReOrderLvl", Items_ReOrderLvl)
            .Parameters.AddWithValue("@Items_SafetyStock", Items_SafetyStock)
            .Parameters.AddWithValue("@Items_StartQty", Items_StartQty)
            .Parameters.AddWithValue("@Items_UnitPrice", Items_UnitPrice)

            Try
                .ExecuteNonQuery()
                SaveItm = True
            Catch ex As Exception
                SaveItm = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteItm(ByVal Items_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteItm")
            .Parameters.AddWithValue("@Items_ID", Items_ID)

            Try
                .ExecuteNonQuery()
                DeleteItm = True
            Catch ex As Exception
                DeleteItm = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostItm(ByVal Items_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostItm")
            .Parameters.AddWithValue("@Items_ID", Items_ID)

            Try
                .ExecuteNonQuery()
                PostItm = True
            Catch ex As Exception
                PostItm = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelItm(ByVal Items_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelItm")
            .Parameters.AddWithValue("@Items_ID", Items_ID)

            Try
                .ExecuteNonQuery()
                CancelItm = True
            Catch ex As Exception
                CancelItm = False
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