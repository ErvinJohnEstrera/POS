Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmBooking

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim clsBooking As New clsBooking

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        FillDgView()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)
        btnCancelTransaction.Enabled = False
        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False

            pnlMain.Enabled = False
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True

            pnlMain.Enabled = True
        End If
    End Sub

    Private Sub Build_dgSampleForm()
        'Dim CboHM As New DataGridViewCheckBoxColumn()

        'CboHM.Name = "Checkbox"
        'CboHM.HeaderText = "..."

        With dgView.Columns
            .Clear()
            '.Add(CboHM)
            .Add("Booking_ID", "Booking No")
            .Add("Booking_Date", "Date")
            .Add("Head_Count", "Head Count")
            .Add("Customer_No", "asd")
            .Add("Customer_Name", "Customer Name")
            .Add("Table_ID", "Table")
            .Add("status", "Status")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Booking_ID").Width = 70
            .Columns("Booking_Date").Width = 70
            .Columns("Head_Count").Width = 70
            .Columns("Customer_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Table_ID").Width = 70
            .Columns("status").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Booking_ID").ReadOnly = True
            .Columns("Booking_Date").ReadOnly = True
            .Columns("Head_Count").ReadOnly = True
            .Columns("Customer_Name").ReadOnly = True
            .Columns("Table_ID").ReadOnly = True
            .Columns("status").ReadOnly = True
            .Columns("Customer_No").Visible = False

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING

            .Columns("Booking_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Booking_Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Head_Count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Customer_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Table_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillDgView()
        dgView.Rows.Clear()

        rs = clsBooking.GetListOfBook()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Booking_ID").Value = rs!Booking_ID
                    .Cells("Booking_Date").Value = rs!Booking_Date
                    .Cells("Head_Count").Value = rs!Head_Count
                    .Cells("Customer_No").Value = rs!Customer_ID
                    .Cells("Customer_Name").Value = rs!Customer_LastName + ", " + rs!Customer_FirstName + " " + rs!Customer_MiddleName
                    .Cells("Table_ID").Value = rs!Table_ID
                    .Cells("status").Value = rs!status
                End With
            Loop
        End If
    End Sub

    Private Sub GenerateID()
        rs = clsBooking.GetLatestBookNo()
        If rs.HasRows Then
            rs.Read()
            txtBookNo.Text = rs!ID
        End If
    End Sub


#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
        GenerateID()
        ToggleLock(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        strAddmode = AddMode.Edit
        ToggleLock(False)
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE CANCELLING
        If MsgBox("Are you sure you want to cancel current transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        mf.ClearAllFields(pnlMain, True) 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION

        If strAddmode = AddMode.Edit Then
            'IF IN EDIT MODE, 'FILL ALL FIELDS ON THE FORM
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS EDIT CODE HERE
        clsBooking.DeleteBook(txtBookNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtBookNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        FillDgView()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtBookNo.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to save this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS
        Select Case strAddmode
            Case AddMode.Add
                'GET LATEST PRODUCTS NUMBER

                'SAVE PRODUCTS
                clsBooking.SaveBook(txtBookNo.Text, dtpDate.Value, txtHeadCount.Value, txtCustNo.Text, txtTable.Text, "Pending")

            Case AddMode.Edit

                'UPDATE PRODUCTS
                clsBooking.SaveBook(txtBookNo.Text, dtpDate.Value, txtHeadCount.Value, txtCustNo.Text, txtTable.Text, "Pending")

        End Select

        MsgBox("Transaction " & txtBookNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        FillDgView()
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnSearchCust_Click(sender As Object, e As EventArgs) Handles btnSearchCust.Click
        Me.Enabled = False
        luCustomer.LoadData(Me)
    End Sub

    Private Sub btnSearchTable_Click(sender As Object, e As EventArgs) Handles btnSearchTable.Click
        Me.Enabled = False
        luTable.LoadData(Me)
    End Sub

    Private Sub btnCancelTransaction_Click(sender As Object, e As EventArgs) Handles btnCancelTransaction.Click
        If MsgBox("Are you sure you want to cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        clsBooking.CancelBook(txtBookNo.Text)
        MsgBox("Book " & txtBookNo.Text & " has been cancelled successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        FillDgView()
    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick

        txtBookNo.Text = dgView.CurrentRow.Cells("Booking_ID").Value
        dtpDate.Value = dgView.CurrentRow.Cells("Booking_Date").Value
        txtHeadCount.Value = dgView.CurrentRow.Cells("Head_Count").Value
        txtCustNo.Text = dgView.CurrentRow.Cells("Customer_No").Value
        txtCustFullName.Text = dgView.CurrentRow.Cells("Customer_Name").Value
        txtTable.Text = dgView.CurrentRow.Cells("Table_ID").Value

        If (dgView.CurrentRow.Cells("status").Value = "Cancelled") Then
            ToggleLock(True)
            btnAdd.Enabled = False
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnCancel.Enabled = True
            btnSave.Enabled = False
            btnCancelTransaction.Enabled = False
        Else
            ToggleLock(True)
            btnAdd.Enabled = False
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnCancel.Enabled = True
            btnSave.Enabled = False
            btnCancelTransaction.Enabled = True
        End If



    End Sub


#End Region


End Class