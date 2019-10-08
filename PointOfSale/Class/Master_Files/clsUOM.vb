Imports System.Data.SqlClient

Public Class clsUOM

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spUOM"
    Dim MessageBoxCaption As String

    Public Function GetListOfUom() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfUom")

            Try
                GetListOfUom = .ExecuteReader
            Catch ex As Exception
                GetListOfUom = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetUom(ByVal UOM_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetUom")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)

            Try
                GetUom = .ExecuteReader
            Catch ex As Exception
                GetUom = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestUomNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestUomNo")

            Try
                GetLatestUomNo = .ExecuteReader
            Catch ex As Exception
                GetLatestUomNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveUom(ByVal UOM_ID As Integer, ByVal UOM_Name As String, ByVal UOM_Description As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveUom")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)
            .Parameters.AddWithValue("@UOM_Name", UOM_Name)
            .Parameters.AddWithValue("@UOM_Description", UOM_Description)

            Try
                .ExecuteNonQuery()
                SaveUom = True
            Catch ex As Exception
                SaveUom = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteUom(ByVal UOM_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteUom")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)

            Try
                .ExecuteNonQuery()
                DeleteUom = True
            Catch ex As Exception
                DeleteUom = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfExists(ByVal UOM_Name As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@UOM_Name", UOM_Name)

            Try
                .ExecuteNonQuery()
                CheckIfExists = .ExecuteReader
            Catch ex As Exception
                CheckIfExists = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CheckIfInUsed(ByVal UOM_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CheckIfExists")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)

            Try
                .ExecuteNonQuery()
                CheckIfInUsed = .ExecuteReader
            Catch ex As Exception
                CheckIfInUsed = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostUom(ByVal UOM_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostUom")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)

            Try
                .ExecuteNonQuery()
                PostUom = True
            Catch ex As Exception
                PostUom = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelUom(ByVal UOM_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelUom")
            .Parameters.AddWithValue("@UOM_ID", UOM_ID)

            Try
                .ExecuteNonQuery()
                CancelUom = True
            Catch ex As Exception
                CancelUom = False
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