Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmPurchaseOrder

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim clsPurchaseOrder As New clsPurchaseOrder
    Dim PurchaseOrder As New clsPurchaseOrder

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgPO()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)
        btnPrint.Enabled = False

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            pnlBody.Enabled = False

            txtTransNo.Enabled = True
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True
            pnlBody.Enabled = True

            txtTransNo.Enabled = False
        End If
    End Sub

    Private Sub Build_dgPO()
        Dim CboHM As New DataGridViewCheckBoxColumn()

        CboHM.Name = "Checkbox"
        CboHM.HeaderText = "..."
        CboHM.Width = 30

        With dgView.Columns
            .Clear()
            .Add(CboHM)
            .Add("id", "Item No")
            .Add("name", "Item Name")
            .Add("uom", "UOM")
            .Add("qty", "Qty")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("id").Width = 100
            .Columns("name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("uom").Width = 50
            .Columns("qty").Width = 35

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").ReadOnly = True
            .Columns("name").ReadOnly = True
            .Columns("uom").ReadOnly = True
            .Columns("qty").ReadOnly = False

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("uom").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub


    Public Sub setSuppName(ByVal id As String, ByVal name As String)
        txtSupplierNo.Text = id
        txtCompName.Text = name
    End Sub

    Sub FillAllFields(ByVal ID As String)
        dgView.Rows.Clear()

        rs = PurchaseOrder.GetPO(ID)
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = ID
            txtSupplierNo.Text = rs!PO_Header_ID.ToString()
            txtCompName.Text = rs!Supplier_CompName.ToString()
            txtRemarks.Text = rs!PO_Header_Remarks.ToString()
            dtpDate.Text = rs!PO_Header_Date
            lblStatus.Text = rs!PO_Header_Status.ToString()
            txtPostedBy.Text = rs!PO_Header_PostedBy.ToString()
            txtCancelledBy.Text = rs!PO_Header_CancelledBy.ToString()
            txtPreparedby.Text = rs!PO_Header_PreparedBy.ToString()
        End If

        rs = PurchaseOrder.getPOD(ID)
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!Items_ID
                    .Cells("name").Value = rs!Items_Name
                    .Cells("uom").Value = rs!UOM_Name
                    .Cells("qty").Value = rs!PO_Details_Qty
                End With
            Loop
        End If
        ToggleLock(True)
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnAdd.Enabled = False
        btnCancel.Enabled = True
    End Sub


#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
        GenerateID()
        txtPreparedby.Text = My.Settings.Username
        ToggleLock(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        strAddmode = AddMode.Edit
        ToggleLock(False)
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnPost.Enabled = False
    End Sub

    Private Sub GenerateID()
        Dim rs As SqlDataReader
        rs = PurchaseOrder.GetLatestPONo()
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = rs!ID
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'INITIATE VALIDATIONS

        'CONFIRM BEFORE CANCELLING
        If MsgBox("Are you sure you want to cancel current transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        mf.ClearAllFields(pnlMain, True) 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION
        mf.ClearAllFields(pnlBody, True)

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
        PurchaseOrder.DeletePO(txtTransNo.Text)
        PurchaseOrder.DeletePOD(txtTransNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtTransNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtSupplierNo.Text) = "" Then
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

                PurchaseOrder.SavePO(txtTransNo.Text, dtpDate.Value, txtSupplierNo.Text, "Saved as Draft", txtRemarks.Text, My.Settings.ID)

                Dim i As Integer
                For i = 0 To dgView.Rows.Count - 1
                    PurchaseOrder.SavePOD(dgView.Item(1, i).Value.ToString(), Convert.ToInt32(dgView.Item(4, i).Value.ToString()), txtTransNo.Text)
                Next

            Case AddMode.Edit

                'UPDATE PRODUCTS
                'clsPurchaseOrder.deleteItemsByPOID("deleteall", txtTransNo.Text)

                'clsPurchaseOrder.ProcessData("update", txtTransNo.Text, dtpDate.Value, txtSupplierNo.Text, "Saved as Draft", txtRemarks.Text, My.Settings.ID)

                'Dim i As Integer
                'For i = 0 To dgView.Rows.Count - 1
                '    clsPurchaseOrder.dgProcessData("add", dgView.Item(1, i).Value.ToString(), Convert.ToInt32(dgView.Item(3, i).Value.ToString()), txtTransNo.Text)
                'Next
                PurchaseOrder.SavePO(txtTransNo.Text, dtpDate.Value, txtSupplierNo.Text, "Saved as Draft", txtRemarks.Text, My.Settings.ID)

                Dim i As Integer
                For i = 0 To dgView.Rows.Count - 1
                    PurchaseOrder.SavePOD(dgView.Item(1, i).Value.ToString(), Convert.ToInt32(dgView.Item(4, i).Value.ToString()), txtTransNo.Text)
                Next
        End Select

        MsgBox("Transaction " & txtTransNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)
        mf.ClearAllFields(pnlMain)
        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnSearchTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTrans.Click
        Me.Enabled = False
        luPurchaseOrder.LoadData(Me)
    End Sub

#End Region

    Private Sub lblStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStatus.TextChanged
        Select Case lblStatus.Text
            Case "Saved as Draft"
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnPost.Enabled = True
            Case "Posted"
                btnCancelTransaction.Enabled = True
            Case Else
                btnCancelTransaction.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                btnPost.Enabled = False
        End Select
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to post this request? This cannot be undone.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        PurchaseOrder.PostPO(txtTransNo.Text, My.Settings.ID)
        MsgBox("Successfully Posted", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "INFORMATION")
        lblStatus.Text = "Posted"
    End Sub

    Private Sub btnSearchSuppNo_Click(sender As Object, e As EventArgs) Handles btnSearchSuppNo.Click
        Me.Enabled = False
        luSupplier.LoadData(Me)
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Me.Enabled = False
        luItems.LoadData(Me)
    End Sub

    Private Sub btnCancelTransaction_Click(sender As Object, e As EventArgs) Handles btnCancelTransaction.Click
        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to cancel this request? This cannot be undone.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        PurchaseOrder.CancelPO(txtTransNo.Text, My.Settings.ID)
        MsgBox("Successfully Cancelled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "INFORMATION")
        lblStatus.Text = "Cancelled"
    End Sub
End Class