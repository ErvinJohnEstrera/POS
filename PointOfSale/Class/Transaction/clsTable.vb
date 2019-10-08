Imports System.Data.SqlClient

Public Class clsTable

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spTable"
    Dim MessageBoxCaption As String

    Public Function GetListOftbl() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOftbl")

            Try
                GetListOftbl = .ExecuteReader
            Catch ex As Exception
                GetListOftbl = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function Gettbl(ByVal Table_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "Gettbl")
            .Parameters.AddWithValue("@Table_ID", Table_ID)

            Try
                Gettbl = .ExecuteReader
            Catch ex As Exception
                Gettbl = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatesttblNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatesttblNo")

            Try
                GetLatesttblNo = .ExecuteReader
            Catch ex As Exception
                GetLatesttblNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function CheckIfExistsTbl(ByVal Table_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "CheckIfExistsTbl")
            .Parameters.AddWithValue("@Table_ID", "Table_ID")

            Try
                CheckIfExistsTbl = .ExecuteReader
            Catch ex As Exception
                CheckIfExistsTbl = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function Savetbl(ByVal Table_ID As String, ByVal Table_Details As String, ByVal Table_Status As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Savetbl")
            .Parameters.AddWithValue("@Table_ID", Table_ID)
            .Parameters.AddWithValue("@Table_Details", Table_Details)
            .Parameters.AddWithValue("@Table_Status", Table_Status)

            Try
                .ExecuteNonQuery()
                Savetbl = True
            Catch ex As Exception
                Savetbl = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function Deletetbl(ByVal Table_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Deletetbl")
            .Parameters.AddWithValue("@Table_ID", Table_ID)

            Try
                .ExecuteNonQuery()
                Deletetbl = True
            Catch ex As Exception
                Deletetbl = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Posttbl(ByVal Table_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Posttbl")
            .Parameters.AddWithValue("@Table_ID", Table_ID)

            Try
                .ExecuteNonQuery()
                Posttbl = True
            Catch ex As Exception
                Posttbl = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function Canceltbl(ByVal Table_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "Canceltbl")
            .Parameters.AddWithValue("@Table_ID", Table_ID)

            Try
                .ExecuteNonQuery()
                Canceltbl = True
            Catch ex As Exception
                Canceltbl = False
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