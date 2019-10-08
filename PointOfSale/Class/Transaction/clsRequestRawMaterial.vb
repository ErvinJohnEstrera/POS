Imports MySql.Data.MySqlClient

Public Class clsRequestRawMaterial

    Dim Con As New MySqlConnection
    Dim clsLogs As New ClsLogs

    Public Function getListRRM() As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT a.*, concat(b.f_name, '" & " " & "' ,b.l_name) AS emp_name, b.f_name, b.l_name
                            FROM trans_requested_rawmaterialheader AS a
                            LEFT JOIN mf_emp AS b ON b.id = a.emp_no"

            Try
                getListRRM = .ExecuteReader
            Catch ex As Exception
                getListRRM = Nothing
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/getListRRM", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function
    Public Function checkrow() As MySqlDataReader
        Dim cmdData As New MySqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT COUNT(ID) AS allrow FROM trans_requested_rawmaterialheader;"

            Try
                checkrow = .ExecuteReader
            Catch ex As Exception
                checkrow = Nothing
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/getRRMLatestNo", ex.Message)
            End Try

        End With
    End Function

    Public Function getRRMLatestNo() As MySqlDataReader
        Dim cmdData As New MySqlCommand
        ReOpenConnection()

        With cmdData
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT LPAD(SUBSTRING(max(ID),5)+1,9,'0') AS ID FROM trans_requested_rawmaterialheader;"

            Try
                getRRMLatestNo = .ExecuteReader
            Catch ex As Exception
                getRRMLatestNo = Nothing
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/getRRMLatestNo", ex.Message)
            End Try

        End With
    End Function

    Public Function getSpecRRMH(ByVal id As String) As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT a.id, a.date, a.emp_no, b.f_name, b.l_name, a.prepared_by, a.remarks
                            FROM trans_requested_rawmaterialheader AS a
                            LEFT JOIN mf_emp AS b ON b.id = a.emp_no
                            WHERE a.id = @id"
            .Parameters.AddWithValue("@id", id)

            Try
                getSpecRRMH = .ExecuteReader
            Catch ex As Exception
                getSpecRRMH = Nothing
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/getSpecificPurchaseOrderHeader", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function
    Public Function getSpecRRMD(ByVal id As String) As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT a.*, b.name, b.UOMno, c.name as UOMName
                            FROM trans_requested_rawmaterialdetails AS a
                            LEFT JOIN mf_items AS b ON b.id = a.item_no
                            LEFT JOIN mf_uom AS c ON c.id = b.UOMno
                            WHERE rrmh_no = @id"
            .Parameters.AddWithValue("@id", id)

            Try
                getSpecRRMD = .ExecuteReader
            Catch ex As Exception
                getSpecRRMD = Nothing
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/getSpecRRMD", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function


    Public Function check_duplicate(ByVal name As String) As MySqlDataReader
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT name FROM mf_cat WHERE name = @name"
            .Parameters.AddWithValue("@name", name)

            Try
                check_duplicate = .ExecuteReader
            Catch ex As Exception
                check_duplicate = Nothing
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/CheckDuplicate", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Function check_inuse(ByVal id As Integer)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            .CommandText = "SELECT cat_no FROM mf_items WHERE cat_no = @id"
            .Parameters.AddWithValue("@id", id)

            Try
                check_inuse = .ExecuteReader
            Catch ex As Exception
                check_inuse = Nothing
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/CheckIfDataIsInUse", ex.Message)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Function

    Public Sub ProcessData(ByVal mode As String, ByVal ID As String, ByVal datetime As DateTime, ByVal emp_no As String, ByVal prepared_by As String, ByVal remarks As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "add" Then
                .CommandText = "INSERT INTO `trans_requested_rawmaterialheader` (`ID`,`date`,`emp_no`,`prepared_by`,`remarks`) values (@ID,@date,@emp_no,@prepared_by,@remarks)"
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@date", datetime)
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@prepared_by", prepared_by)
                .Parameters.AddWithValue("@remarks", remarks)
            ElseIf mode = "update" Then
                .CommandText = "UPDATE `trans_requested_rawmaterialheader` SET `date`=@date,`emp_no`=@emp_no,`prepared_by`=@prepared_by,`remarks`=@remarks WHERE `ID`=@ID"
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@date", datetime)
                .Parameters.AddWithValue("@emp_no", emp_no)
                .Parameters.AddWithValue("@prepared_by", prepared_by)
                .Parameters.AddWithValue("@remarks", remarks)
            ElseIf mode = "delete" Then
                .CommandText = "DELETE FROM trans_po_header WHERE `id`=@id"
                .Parameters.AddWithValue("@id", ID)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/RequestRawMaterial/AddEditDelete", ex.Message)
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try

        End With
    End Sub



    Public Sub dgProcessData(ByVal mode As String, ByVal item_no As String, ByVal qty As Integer, ByVal rrmh_no As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "add" Then
                .CommandText = "INSERT INTO `trans_requested_rawmaterialdetails` (`item_no`,`qty`,`rrmh_no`) values (@item_no,@qty,@rrmh_no)"
                .Parameters.AddWithValue("@item_no", item_no)
                .Parameters.AddWithValue("@qty", qty)
                .Parameters.AddWithValue("@rrmh_no", rrmh_no)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/PURCHASEORDER/dgProcessData", ex.Message)
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Sub

    Public Sub deleteItemsByPOID(ByVal mode As String, ByVal poh_id As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "deleteall" Then
                .CommandText = "DELETE FROM `trans_po_details` WHERE `poh_id`=@poh_id"
                .Parameters.AddWithValue("@poh_id", poh_id)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/PURCHASEORDER/deleteItemsByPOID", ex.Message)
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Sub

    Public Sub updateStatus(ByVal mode As String, ByVal poh_id As String, ByVal emp_no As String)
        Dim cmd As New MySqlCommand
        ReOpenConnection()

        With cmd
            .Connection = Con
            .CommandType = CommandType.Text
            .CommandTimeout = 0
            If mode = "post" Then
                .CommandText = "UPDATE `trans_po_header` SET `status`='Posted', `posted_by`=@posted_by, `posted_date`=@posted_date WHERE `id`=@poh_id"
                .Parameters.AddWithValue("@poh_id", poh_id)
                .Parameters.AddWithValue("@posted_by", emp_no)
                .Parameters.AddWithValue("@posted_date", DateTime.Now)
            ElseIf mode = "cancel" Then
                .CommandText = "UPDATE `trans_po_header` SET `status`='Cancelled', `cancelled_by`=@posted_by, `cancel_date`=@posted_date WHERE `id`=@poh_id"
                .Parameters.AddWithValue("@poh_id", poh_id)
                .Parameters.AddWithValue("@posted_by", emp_no)
                .Parameters.AddWithValue("@posted_date", DateTime.Now)
            End If

            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                clsLogs.ProcessDataLogTrail("logtrail", My.Settings.ID, "MSTRFILE/PURCHASEORDER/updateStatus", ex.Message)
                MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End With
    End Sub

    Public Sub ReOpenConnection()
        With Con
            If .State = ConnectionState.Open Then
                .Close()
            End If

            SQLConnect()
        End With
    End Sub

    Sub SQLConnect()
        Con = New MySqlConnection

        With Con
            .ConnectionString = "Server=127.0.0.1; Database=pos; Uid=root; Pwd=jeffreyestrera011897@@;"
            .Open()
        End With
    End Sub

    Sub New()
        SQLConnect()
    End Sub
End Class
