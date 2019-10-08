Imports System.Data.SqlClient

Public Class clsEmployee

    Dim connData As SqlConnection
    Dim StoredProcedure As String = "spEmployee"
    Dim MessageBoxCaption As String

    Public Function GetListOfEmp() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetListOfEmp")

            Try
                GetListOfEmp = .ExecuteReader
            Catch ex As Exception
                GetListOfEmp = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetEmp(ByVal Employee_ID As String) As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetEmp")
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)

            Try
                GetEmp = .ExecuteReader
            Catch ex As Exception
                GetEmp = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function GetLatestEmpNo() As SqlDataReader
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure

            .Parameters.AddWithValue("@Mode", "GetLatestEmpNo")

            Try
                GetLatestEmpNo = .ExecuteReader
            Catch ex As Exception
                GetLatestEmpNo = Nothing
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            .Dispose()
        End With
    End Function

    Public Function SaveEmp(ByVal Employee_ID As String, ByVal Employee_FirstName As String, ByVal Employee_MiddleName As String, ByVal Employee_LastName As String, ByVal Employee_Email As String, ByVal Employee_PhoneNo As String, ByVal Employee_Address As String, ByVal Employee_Username As String, ByVal Employee_Password As String, ByVal UserRole_ID As Integer) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "SaveEmp")
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)
            .Parameters.AddWithValue("@Employee_FirstName", Employee_FirstName)
            .Parameters.AddWithValue("@Employee_MiddleName", Employee_MiddleName)
            .Parameters.AddWithValue("@Employee_LastName", Employee_LastName)
            .Parameters.AddWithValue("@Employee_Email", Employee_Email)
            .Parameters.AddWithValue("@Employee_PhoneNo", Employee_PhoneNo)
            .Parameters.AddWithValue("@Employee_Address", Employee_Address)
            .Parameters.AddWithValue("@Employee_Username", Employee_Username)
            .Parameters.AddWithValue("@Employee_Password", Employee_Password)
            .Parameters.AddWithValue("@UserRole_ID", UserRole_ID)

            Try
                .ExecuteNonQuery()
                SaveEmp = True
            Catch ex As Exception
                SaveEmp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function



    Public Function DeleteEmp(ByVal Employee_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "DeleteEmp")
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)

            Try
                .ExecuteNonQuery()
                DeleteEmp = True
            Catch ex As Exception
                DeleteEmp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function PostEmp(ByVal Employee_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "PostEmp")
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)

            Try
                .ExecuteNonQuery()
                PostEmp = True
            Catch ex As Exception
                PostEmp = False
                MessageBox.Show(ex.Message, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
            .Dispose()
        End With
    End Function

    Public Function CancelEmp(ByVal Employee_ID As String) As Boolean
        Dim cmdData As New SqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = connData
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 0
            .CommandText = StoredProcedure
            .Parameters.AddWithValue("@Mode", "CancelEmp")
            .Parameters.AddWithValue("@Employee_ID", Employee_ID)

            Try
                .ExecuteNonQuery()
                CancelEmp = True
            Catch ex As Exception
                CancelEmp = False
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