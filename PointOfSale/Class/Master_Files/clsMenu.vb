Imports System.Data.SqlClient

Public Class clsMenu

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spMenu"
    Dim MessageBoxCaption As String

    Public Function GetListOfmenu() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfmenu")

            Try
                GetListOfmenu = .ExecuteReader
            Catch ex As Exception
                GetListOfmenu = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function Getmenu(ByVal Menu_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "Getmenu")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                Getmenu = .ExecuteReader
            Catch ex As Exception
                Getmenu = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetmenuDetails(ByVal Menu_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "GetmenuDetails")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                GetmenuDetails = .ExecuteReader
            Catch ex As Exception
                GetmenuDetails = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestmenuNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestmenuNo")

            Try
                GetLatestmenuNo = .ExecuteReader
            Catch ex As Exception
                GetLatestmenuNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function Savemenu(ByVal Menu_ID As String, ByVal Menu_Name As String, ByVal Menu_Description As String, ByVal Menu_Price As Decimal) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Savemenu")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)
            .Parameters.AddWithValue("@Menu_Name", Menu_Name)
            .Parameters.AddWithValue("@Menu_Description", Menu_Description)
            .Parameters.AddWithValue("@Menu_Price", Menu_Price)

            Try
                .ExecuteNonQuery()
                Savemenu = True
            Catch ex As Exception
                Savemenu = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function SavemenuD(ByVal Menu_ID As String, ByVal Menu_Item_ID As String, ByVal Details_Qty As Integer) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SavemenuD")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)
            .Parameters.AddWithValue("@Menu_Item_ID", Menu_Item_ID)
            .Parameters.AddWithValue("@Details_Qty", Details_Qty)

            Try
                .ExecuteNonQuery()
                SavemenuD = True
            Catch ex As Exception
                SavemenuD = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function DeletemenuDetails(ByVal Menu_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeletemenuDetails")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                .ExecuteNonQuery()
                DeletemenuDetails = True
            Catch ex As Exception
                DeletemenuDetails = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Deletemenu(ByVal Menu_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Deletemenu")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                .ExecuteNonQuery()
                Deletemenu = True
            Catch ex As Exception
                Deletemenu = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Postmenu(ByVal Menu_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Postmenu")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                .ExecuteNonQuery()
                Postmenu = True
            Catch ex As Exception
                Postmenu = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Cancelmenu(ByVal Menu_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Cancelmenu")
            .Parameters.AddWithValue("@Menu_ID", Menu_ID)

            Try
                .ExecuteNonQuery()
                Cancelmenu = True
            Catch ex As Exception
                Cancelmenu = False
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