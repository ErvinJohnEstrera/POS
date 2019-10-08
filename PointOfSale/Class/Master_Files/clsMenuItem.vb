Imports System.Data.SqlClient

Public Class clsMenuItem

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spMenuItem"
    Dim MessageBoxCaption As String

    Public Function GetListOfmenuItem() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfmenuItem")

            Try
                GetListOfmenuItem = .ExecuteReader
            Catch ex As Exception
                GetListOfmenuItem = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetmenuItem(ByVal Menu_Item_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetmenuItem")
            .Parameters.AddWithValue("@Menu_Item_ID", Menu_Item_ID)

            Try
                GetmenuItem = .ExecuteReader
            Catch ex As Exception
                GetmenuItem = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestmenuItemNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestmenuItemNo")

            Try
                GetLatestmenuItemNo = .ExecuteReader
            Catch ex As Exception
                GetLatestmenuItemNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SavemenuItem(ByVal Menu_Item_ID As String, ByVal Menu_Item_Name As String, ByVal Menu_Item_Price As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SavemenuItem")
            .Parameters.AddWithValue("@Menu_Item_ID", Menu_Item_ID)
            .Parameters.AddWithValue("@Menu_Item_Name", Menu_Item_Name)
            .Parameters.AddWithValue("@Menu_Item_Price", Menu_Item_Price)

            Try
                .ExecuteNonQuery()
                SavemenuItem = True
            Catch ex As Exception
                SavemenuItem = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeletemenuItem(ByVal Menu_Item_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeletemenuItem")
            .Parameters.AddWithValue("@Menu_Item_ID", Menu_Item_ID)

            Try
                .ExecuteNonQuery()
                DeletemenuItem = True
            Catch ex As Exception
                DeletemenuItem = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfExists(ByVal Menu_Item_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@Menu_Item_Name", Menu_Item_Name)

            Try
                CheckIfExists = .ExecuteReader
            Catch ex As Exception
                CheckIfExists = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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