Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmRequestRawMaterial

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsRequestRawMaterial As New clsRequestRawMaterial
    Dim RequestedRawMaterial As New RequestedRawMaterial
    Dim rs As SqlDataReader

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnSearchTrans.Enabled = True
            pnlMain.Enabled = False

            txtTransNo.Enabled = True
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True
            btnSearchTrans.Enabled = False
            pnlMain.Enabled = True

            txtTransNo.Enabled = False
        End If
    End Sub

    Private Sub Build_dgSampleForm()
        'Dim CboHM As New DataGridViewCheckBoxColumn()

        'CboHM.Name = "Checkbox"
        'CboHM.HeaderText = "..."

        With dgView.Columns
            .Clear()
            '.Add(CboHM)
            .Add("item_no", "Item No")
            .Add("item_name", "Item Name")
            .Add("uom_no", "uom_no")
            .Add("uom_name", "Unit of Measurement")
            .Add("qty", "Requested Qty")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            '.Columns("").Width = 10
            .Columns("item_no").Width = 125
            .Columns("item_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("uom_name").Width = 125
            .Columns("qty").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("item_no").ReadOnly = True
            .Columns("item_name").ReadOnly = True
            .Columns("uom_name").ReadOnly = True
            .Columns("qty").ReadOnly = False
            .Columns("uom_no").Visible = False


            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("item_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("item_name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("uom_name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillAllFields(ByVal ID As String)
        dgView.Rows.Clear()

        rs = RequestedRawMaterial.GetRRM(ID)

        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = rs!RRM_Header_ID
            dtpDate.Value = rs!RRM_Header_Date
            txtEmpNo.Text = rs!Employee_ID
            txtEmpName.Text = rs!Employee_LastName & ", " & rs!Employee_FirstName & " " & rs!Employee_MiddleName
            txtPreparedby.Text = rs!Employee_ID
            txtRemarks.Text = rs!RRM_Header_Remarks.ToString()
        End If

        rs = RequestedRawMaterial.GetRRMD(ID)

        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("item_no").Value = rs!Items_ID
                    .Cells("item_name").Value = rs!Items_Name
                    .Cells("uom_no").Value = rs!UOM_ID
                    .Cells("uom_name").Value = rs!UOM_Name
                    .Cells("qty").Value = rs!RRM_Details_Qty
                End With
            Loop
        End If
        btnAdd.Enabled = False
        btnCancel.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
    End Sub

    Sub FillEmpName(ByVal ID As String, ByVal f_name As String)
        txtEmpNo.Text = ID
        txtEmpName.Text = f_name
    End Sub

    Private Sub generateID()
        rs = RequestedRawMaterial.GetLatestRRMNo()
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = rs!ID
        End If
    End Sub

#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
        generateID()
        txtPreparedby.Text = My.Settings.Username
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
        RequestedRawMaterial.DeleteRRM(txtTransNo.Text)
        RequestedRawMaterial.DeleteRRMD(txtTransNo.Text)


        MsgBox("Successfully deleted transaction " & Trim(txtTransNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'If Trim(txtRemarks.Text) = "" Then
        '    MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
        '    Exit Sub
        'End If

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to save this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS
        Select Case strAddmode
            Case AddMode.Add

                'GET LATEST PRODUCTS NUMBER

                'SAVE PRODUCTS
                RequestedRawMaterial.SaveRRM(txtTransNo.Text, dtpDate.Value, txtEmpNo.Text, txtPreparedby.Text, txtRemarks.Text)

                For i = 0 To dgView.Rows.Count - 1
                    RequestedRawMaterial.SaveRRMD(dgView.Item(0, i).Value.ToString(), Convert.ToInt32(dgView.Item(4, i).Value.ToString()), txtTransNo.Text)
                Next

            Case AddMode.Edit

                'UPDATE PRODUCTS
                RequestedRawMaterial.SaveRRM(txtTransNo.Text, dtpDate.Value, txtEmpNo.Text, txtPreparedby.Text, txtRemarks.Text)

                RequestedRawMaterial.DeleteRRMD(txtTransNo.Text)

                For i = 0 To dgView.Rows.Count - 1
                    RequestedRawMaterial.SaveRRMD(dgView.Item(0, i).Value.ToString(), Convert.ToInt32(dgView.Item(4, i).Value.ToString()), txtTransNo.Text)
                Next

        End Select

        MsgBox("Transaction " & txtTransNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnSearchTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTrans.Click
        Me.Enabled = False
        luRequestRawMaterial.LoadData(Me)
    End Sub

#End Region


    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSearchEmployee_Click(sender As Object, e As EventArgs) Handles btnSearchEmployee.Click
        Me.Enabled = False
        luEmployee.LoadData(Me)
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Me.Enabled = False
        luItems.LoadData(Me)
    End Sub

    Private Sub dgView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellValidated
        Dim i As Integer
        Dim stock As Integer
        i = dgView.CurrentRow.Index
        rs = RequestedRawMaterial.GetItmStock(dgView.Item(0, i).Value)

        If rs.HasRows Then
            rs.Read()
            stock = mf.FormatMoney(rs!Remaining_Qty)
        End If

        If (Convert.ToInt32(dgView.Item(4, i).Value) > stock) Then
            MsgBox("Insufficient Stock.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
            dgView.Item(4, i).Value = stock
        End If

    End Sub
End Class