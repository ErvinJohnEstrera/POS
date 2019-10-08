Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmDeliveryReceivingOrder

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsPurchaseOrder As New clsPurchaseOrder
    Dim rs As SqlDataReader
    Dim clsDeliveryReceivingOrder As New clsDeliveryReceivingOrder

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)
        btnPrint.Enabled = False
        btnReceiveOrder.Enabled = False

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSearchTrans.Enabled = True
            pnlMain.Enabled = True
            PnlPOH.Enabled = False
            pnlGrid.Enabled = False

            txtTransNo.Enabled = True
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSearchTrans.Enabled = False
            pnlMain.Enabled = False
            PnlPOH.Enabled = True
            pnlGrid.Enabled = False

            txtTransNo.Enabled = False
        End If
    End Sub

    Private Sub Build_dgSampleForm()

        With dgView.Columns
            .Clear()
            .Add("item_no", "Item No.")
            .Add("item_name", "Item Name")
            .Add("unit_price", "Unit Price")
            .Add("qty", "Ordered Qty")
            .Add("bad_qty", "Bad Qty")
            .Add("back_qty", "Back Qty")
            .Add("sub_total", "Sub Total")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("item_no").Width = 90
            .Columns("item_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("unit_price").Width = 90
            .Columns("qty").Width = 75
            .Columns("bad_qty").Width = 75
            .Columns("back_qty").Width = 75
            .Columns("sub_total").Width = 90

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("item_no").ReadOnly = True
            .Columns("item_name").ReadOnly = True
            .Columns("unit_price").ReadOnly = False
            .Columns("qty").ReadOnly = False
            .Columns("bad_qty").ReadOnly = False
            .Columns("back_qty").ReadOnly = False
            .Columns("sub_total").ReadOnly = False

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("item_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("item_name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("unit_price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("bad_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("back_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("sub_total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillAllFieldsDRO(ByVal dro_no As String, ByVal po_no As String)
        dgView.Rows.Clear()
        rs = clsDeliveryReceivingOrder.GetDRO(dro_no)
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = dro_no
            dtpRO.Text = rs!DRO_Header_Date.ToString()
            txtReceivedBy.Text = rs!Employee_ID.ToString()
            txtRemarks.Text = rs!DRO_Header_Remarks.ToString()
            txtPONo.Text = rs!PO_Header_ID.ToString()
            dtpPostedDate.Text = rs!PO_Header_PostedDate.ToString()
            dtpExpectedDate.Text = rs!Expected_Arrival_Date.ToString()
            txtSuppNo.Text = rs!Supplier_ID.ToString()
            txtSuppName.Text = rs!Supplier_CompName.ToString()
            txtPOPreparedBy.Text = rs!Employee_ID.ToString()
            txtTotalItems.Text = rs!DRO_Header_TotalItems.ToString()
            txtSubTotal.Text = rs!DRO_Header_SubTotal.ToString()
            txtSalesTax.Text = rs!DRO_Header_SalesTax.ToString()
            txtAmountDue.Text = rs!Amount_Due.ToString()
            txtPaymentDue.Text = rs!DRO_Header_PaymentDue.ToString()
            txtGrandTotal.Text = rs!DRO_Header_GrandTotal.ToString()
        End If

        rs = clsDeliveryReceivingOrder.GetDROD(po_no)
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("item_no").Value = rs!Items_ID.ToString()
                    .Cells("item_name").Value = rs!Items_Name.ToString()
                    .Cells("unit_price").Value = rs!DRO_Details_UnitPrice.ToString("#,###.00")
                    .Cells("qty").Value = rs!DRO_Details_Qty.ToString()
                    .Cells("bad_qty").Value = rs!DRO_Details_BadQty.ToString()
                    .Cells("back_qty").Value = rs!DRO_Details_BackQty.ToString()
                    .Cells("sub_total").Value = rs!DRO_Details_SubTotal.ToString("#,###.00")
                End With
            Loop
        End If

        btnAdd.Enabled = False
        btnCancel.Enabled = True
        btnDelete.Enabled = True
        btnEdit.Enabled -= True
    End Sub

    Sub FillAllFields(ByVal ID As String)
        'FILL ALL FORM FIELDS
        dgView.Rows.Clear()
        rs = clsPurchaseOrder.GetPO(ID)
        If rs.HasRows Then
            rs.Read()
            txtPONo.Text = ID
            txtSuppNo.Text = rs!Supplier_ID.ToString()
            txtSuppName.Text = rs!Supplier_CompName.ToString()
            dtpPostedDate.Text = rs!PO_Header_PostedDate.ToString()
            txtPOPreparedBy.Text = rs!PO_Header_PostedBy.ToString()
            dtpExpectedDate.Text = rs!Expected_Arrival_Date.ToString()
        End If


        rs = clsPurchaseOrder.getPOD(ID)
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("item_no").Value = rs!Items_ID.ToString()
                    .Cells("item_name").Value = rs!Items_Name
                    .Cells("unit_price").Value = rs!Items_UnitPrice
                    .Cells("qty").Value = rs!PO_Details_Qty
                    .Cells("bad_qty").Value = 0
                    .Cells("back_qty").Value = 0
                End With
            Loop
        End If
        txtAmountDue.Text = 0
        total()
    End Sub

    Private Sub total()
        total_quantity()
        dgSub_total_per_Row()
        sub_total()
        vat()
        grand_total()
        payment_due()
    End Sub

    Private Sub total_quantity()
        Dim total_qty As Integer

        For Each row As DataGridViewRow In dgView.Rows
            total_qty += Convert.ToInt32(row.Cells("qty").Value).ToString()
        Next
        txtTotalItems.Text = total_qty.ToString("#,###")
    End Sub

    Private Sub dgSub_total_per_Row()
        For Each row As DataGridViewRow In dgView.Rows
            row.Cells("sub_total").Value = Convert.ToDecimal(row.Cells("unit_price").Value * row.Cells("qty").Value).ToString("#,###.00")
        Next
    End Sub

    Private Sub sub_total()
        Dim sub_total As Decimal

        For Each row As DataGridViewRow In dgView.Rows
            sub_total += Convert.ToDecimal(row.Cells("sub_total").Value).ToString("#,###.00")
        Next
        txtSubTotal.Text = sub_total.ToString("#,###.00")
    End Sub
    Private Sub vat()

        Dim tax_value As Integer

        rs = clsDeliveryReceivingOrder.GetTax()
        rs.Read()
        tax_value = rs!Vat_Value

        txtSalesTax.Text = Convert.ToDecimal((((tax_value * 0.01) + 1) * txtSubTotal.Text) - txtSubTotal.Text).ToString("#,###.00")
    End Sub

    Private Sub payment_due()
        txtPaymentDue.Text = (Convert.ToDecimal(txtAmountDue.Text) - Convert.ToDecimal(txtGrandTotal.Text).ToString()).ToString("#,###.00")
    End Sub

    Private Sub grand_total()
        txtGrandTotal.Text = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtSalesTax.Text)).ToString("#,###.00")
    End Sub

    Private Sub GenerateID()
        Dim rs As SqlDataReader
        rs = clsDeliveryReceivingOrder.GetLatestDRONo()
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = rs!ID
        End If
    End Sub

    Private Sub ClearAllFields()
        mf.ClearAllFields(pnlMain)
        mf.ClearAllFields(pnlGrid)
        mf.ClearAllFields(PnlPOH)
        txtTotalItems.Text = 0
        txtSubTotal.Text = 0.00
        txtSalesTax.Text = 0.00
        txtAmountDue.Text = 0.00
        txtPaymentDue.Text = 0.00
        txtGrandTotal.Text = 0.00
    End Sub

#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        ClearAllFields()
        GenerateID()
        txtReceivedBy.Text = My.Settings.ID
        ToggleLock(False)
        btnReceiveOrder.Enabled = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        strAddmode = AddMode.Edit
        ToggleLock(False)
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnReceiveOrder.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE CANCELLING
        If MsgBox("Are you sure you want to cancel current transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        ClearAllFields() 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION

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
        clsDeliveryReceivingOrder.DeleteDRO(txtTransNo.Text)
        clsDeliveryReceivingOrder.DeleteDROD(txtPONo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtTransNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ClearAllFields()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtTransNo.Text) = "" Then
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



            Case AddMode.Edit

                'UPDATE PRODUCTS

        End Select

        MsgBox("Transaction " & txtTransNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnSearchTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTrans.Click
        Me.Enabled = False
        luDeliveryReceivingOrder.LoadData(Me)
    End Sub

#End Region



    Private Sub btnSearchPO_Click(sender As Object, e As EventArgs) Handles btnSearchPO.Click
        Me.Enabled = False
        luPurchaseOrder.MdiParent = mdiMain
        luPurchaseOrder.LoadData(Me)
    End Sub



    Private Sub dgView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellValidated
        total()
    End Sub


    Private Sub btnReceiveOrder_Click(sender As Object, e As EventArgs) Handles btnReceiveOrder.Click
        If MsgBox("Are you sure you want to save this request? This cannot be undone.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        clsDeliveryReceivingOrder.SaveDRO(txtTransNo.Text, dtpRO.Value, txtSuppNo.Text, txtReceivedBy.Text, Convert.ToInt32(txtTotalItems.Text), Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(txtSalesTax.Text), Convert.ToDecimal(txtGrandTotal.Text), txtPONo.Text, Convert.ToDecimal(txtPaymentDue.Text), Convert.ToDecimal(txtAmountDue.Text), txtRemarks.Text)

        For i = 0 To dgView.Rows.Count - 1
            clsDeliveryReceivingOrder.SaveDROD(dgView.Item(0, i).Value.ToString(), Convert.ToDecimal(dgView.Item(2, i).Value.ToString()), Convert.ToInt32(dgView.Item(3, i).Value.ToString()), Convert.ToInt32(dgView.Item(4, i).Value.ToString()), Convert.ToInt32(dgView.Item(5, i).Value.ToString()), txtPONo.Text, Convert.ToDecimal(dgView.Item(6, i).Value.ToString()))
        Next

        MsgBox("Transaction " & txtTransNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")

    End Sub

    Private Sub txtAmountDue_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAmountDue.KeyUp
        total()
    End Sub
End Class