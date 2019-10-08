Imports System.Data.SqlClient
Imports CitiFramework
Imports System.Windows.Forms.Button

Public Class frmOrder

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim clsDeliveryReceivingOrder As New clsDeliveryReceivingOrder
    Dim clsOrder As New clsOrder

    Dim dynamicFlowLayout As New FlowLayoutPanel
    Dim colBtnMinus As New DataGridViewButtonColumn
    Dim colBtnAdd As New DataGridViewButtonColumn

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        txtStaffNo.Text = My.Settings.ID
        txtStaffName.Text = My.Settings.Username

        With dynamicFlowLayout
            .Location = New Point(1, 1)
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .FlowDirection = FlowDirection.LeftToRight
            .AutoScroll = True
        End With

        pnlMain.Controls.Add(dynamicFlowLayout)
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False

            txtTransNo.Enabled = True
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True

            txtTransNo.Enabled = False
        End If
    End Sub

    Private Sub Build_dgSampleForm()

        'BUTTON APPEARANCE'
        With colBtnMinus
            .FlatStyle = FlatStyle.Flat
            .Width = 35
        End With


        With colBtnAdd
            .FlatStyle = FlatStyle.Flat
            .Width = 35
        End With
        'BUTTON APPEARANCE'

        With dgView.Columns
            .Clear()
            .Add("Menu_No", "Menu No.")
            .Add("Picture", "Picture")
            .Add("Menu_Name", "Menu Name")
            .Add(colBtnMinus)
            .Add("Qty", "Qty")
            .Add(colBtnAdd)
            .Add("Unit_Price", "Price")
        End With

        With dgView.Rows
            .Add("19-0001", "Picture", "Jeffrey Estrera", "-", "0", "+", "10,000")
            .Add("19-0001", "Picture", "0", "-", "0", "+", "10,000")
            .Add("19-0001", "Picture", "0", "-", "0", "+", "10,000")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Picture").Width = 70
            .Columns("Menu_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Qty").Width = 35
            .Columns("Unit_Price").Width = 80


            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .DefaultCellStyle.SelectionBackColor = Color.White
            .Font = New Font("Calibri", 11, FontStyle.Regular)

            'SET HEIGHT OF EACH ROW
            For i = 0 To .Rows.Count - 1
                .Rows(i).Height = 35
            Next

            .Columns("Menu_No").Visible = False
            .Columns("Picture").Visible = True
            .Columns("Menu_Name").ReadOnly = True
            .Columns("Unit_Price").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Menu_No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Menu_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Unit_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        ' mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Private Sub AddItems(ByVal Order_No As String, ByVal Order_Menu As String, ByRef Order_Qty As String)

        Dim Panel As New Panel()
        Dim PanelUpper As New Panel()
        Dim PanelLower As New Panel()
        Dim lbl_OrderNo As New Label()
        Dim lbl_Orders As New Label()
        Dim BtnServed As New Button()
        Dim BtnReturn As New Button()

        Dim control_panel As Integer = 0

        With Panel
            .BorderStyle = BorderStyle.FixedSingle
            .Height = 250
            .Width = (dynamicFlowLayout.Width - (4 * 11)) / 4
            .Left = (Panel.Width)
            control_panel = control_panel + 1
        End With

        With PanelUpper
            .BorderStyle = BorderStyle.None
            .BackColor = Color.White
            .Height = (Panel.Height / 1.1) - 3
            .Width = Panel.Width
        End With

        With PanelLower
            .BorderStyle = BorderStyle.None
            .BackColor = Color.White
            .Width = Panel.Width
            .Height = Panel.Height - (Panel.Height / 1.1)
            .Top = PanelUpper.Height
        End With

        dynamicFlowLayout.Controls.Add(Panel)

        With lbl_OrderNo
            .Top = 20
            .Left = 10
            .Text = Order_No
        End With

        With lbl_Orders
            .Top = lbl_OrderNo.Top + 20
            .Left = 10
            .Text = Order_Menu & " - " & Order_Qty
            .Width = 170
        End With

        With BtnServed
            .Height = PanelLower.Height
            .Width = (Panel.Width - 3) / 2
            .Text = "Served"
            .FlatStyle = FlatStyle.Flat
        End With

        With BtnReturn
            .Text = "Return"
            .Height = PanelLower.Height
            .Width = (Panel.Width - 3) / 2
            .Left = BtnReturn.Width + 1
            .FlatStyle = FlatStyle.Flat
        End With

        With Panel
            .Controls.Add(PanelUpper)
            .Controls.Add(PanelLower)
        End With

        With PanelUpper
            .Controls.Add(lbl_OrderNo)
            .Controls.Add(lbl_Orders)
        End With

        With PanelLower
            .Controls.Add(BtnServed)
            .Controls.Add(BtnReturn)
        End With
    End Sub

    Sub FillAllFields(ByVal ID As String)
        'FILL ALL FORM FIELDS
    End Sub

    Public Sub Total()
        TotalItems()
        SubTotalPerItem()
        'DiscountPerItem()
        SalesTax()
        payment_due()
        OverAllSubTotal()
        grand_total()
    End Sub

    'Private Sub DiscountPerItem()
    '    For Each row As DataGridViewRow In dgView.Rows
    '        row.Cells("Sub_Total").Value = (Convert.ToDecimal(row.Cells("Sub_Total").Value) - Convert.ToDecimal(row.Cells("Discount").Value)).ToString("#,###.00")
    '    Next
    'End Sub


    Private Sub SubTotalPerItem()
        For Each row As DataGridViewRow In dgView.Rows
            row.Cells("Sub_Total").Value = mf.FormatMoney(CDbl(row.Cells("Qty").Value) * CDbl(row.Cells("Unit_Price").Value))
        Next
    End Sub

    Private Sub TotalItems()
        Dim total_Items As Integer

        For Each row As DataGridViewRow In dgView.Rows
            total_Items += CInt(row.Cells("Qty").Value)
        Next

        txtTotalItems.Text = total_Items
    End Sub

    Private Sub OverAllSubTotal()
        Dim Sub_Total As Decimal

        For Each row As DataGridViewRow In dgView.Rows
            Sub_Total += CDbl(row.Cells("Sub_Total").Value)
        Next

        txtSubTotal.Text = mf.FormatMoney(Sub_Total)
    End Sub

    Private Sub SalesTax()
        Dim tax_value As Integer

        rs = clsDeliveryReceivingOrder.GetTax()
        rs.Read()
        tax_value = rs!Vat_Value

        txtSalesTax.Text = mf.FormatMoney((((tax_value * 0.01) + 1) * txtSubTotal.Text) - txtSubTotal.Text)
    End Sub

    Private Sub payment_due()
        txtPaymentDue.Text = mf.FormatMoney(CDbl(txtAmountDue.Text) - CDbl(txtGrandTotal.Text))
    End Sub

    Private Sub grand_total()
        txtGrandTotal.Text = mf.FormatMoney(CDbl(txtSubTotal.Text) + CDbl(txtSalesTax.Text) - CDbl(txtDiscount.Text))
    End Sub

    Private Sub GenerateID()
        rs = clsOrder.GetLatestorderNo()
        If rs.HasRows Then
            rs.Read()
            txtTransNo.Text = rs!ID
        End If
    End Sub

    Private Sub setNumber()
        txtTotalItems.Text = 0
        txtSubTotal.Text = "0.00"
        txtSalesTax.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtAmountDue.Text = "0.00"
        txtPaymentDue.Text = "0.00"
        txtGrandTotal.Text = "0.00"
    End Sub

#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
        setNumber()
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

        'PROCESS DELETE CODE HERE

        clsOrder.Deleteorder(txtTransNo.Text)
        clsOrder.DeleteorderDetails(txtTransNo.Text)
        clsOrder.DeleteorderPayment(txtTransNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtTransNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'If Trim(txtDescription1.Text) = "" Then
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

                'clsOrder.Saveorder(txtTransNo.Text, dtpDate.Value, txtCustNo.Text, "Pending", txtOrderNo.Text, txtTotalItems.Text, txtSubTotal.Text, txtSalesTax.Text, txtDiscount.Text, txtAmountDue.Text, txtPaymentDue.Text, txtGrandTotal.Text)
                'For Each row As DataGridViewRow In dgView.Rows
                '    clsOrder.SaveorderD(txtTransNo.Text, row.Cells("Menu_No").Value, row.Cells("Unit_Price").Value, row.Cells("Qty").Value, row.Cells("Discount").Value, row.Cells("Sub_Total").Value)
                'Next

            Case AddMode.Edit

                'UPDATE PRODUCTS
                'clsOrder.DeleteorderDetails(txtTransNo.Text)
                'clsOrder.Saveorder(txtTransNo.Text, dtpDate.Value, txtCustNo.Text, "Pending", txtOrderNo.Text, txtTotalItems.Text, txtSubTotal.Text, txtSalesTax.Text, txtDiscount.Text, txtAmountDue.Text, txtPaymentDue.Text, txtGrandTotal.Text)
                'For Each row As DataGridViewRow In dgView.Rows
                '    clsOrder.SaveorderD(txtTransNo.Text, row.Cells("Menu_No").Value, row.Cells("Unit_Price").Value, row.Cells("Qty").Value, row.Cells("Discount").Value, row.Cells("Sub_Total").Value)
                'Next

        End Select

        MsgBox("Transaction " & txtTransNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnSearchTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        'frmLookUpGeneral.LoadData(Me)
    End Sub

#End Region

    Private Sub lblStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case lblStatus.Text
            Case "Saved as Draft"
                btnEdit.Enabled = True
                btnDelete.Enabled = True
            Case "Posted"
            Case Else
                btnEdit.Enabled = False
                btnDelete.Enabled = False
        End Select
    End Sub


    Private Sub btnSearchTable_Click(sender As Object, e As EventArgs)
        Me.Enabled = False
        luTable.LoadData(Me)
    End Sub

    Private Sub btnSearchCust_Click(sender As Object, e As EventArgs)
        Me.Enabled = False
        luCustomer.LoadData(Me)
    End Sub


    Private Sub dgView_CellValidated(sender As Object, e As DataGridViewCellEventArgs)
        Total()
    End Sub

    Private Sub txtAmountDue_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAmountDue.KeyUp
        mf.NumericOnly(txtAmountDue, True, True, False)
        Total()
    End Sub

    Private Sub dgView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        Total()
    End Sub

    Private Sub txtAmountDue_TextChanged(sender As Object, e As EventArgs) Handles txtAmountDue.TextChanged

    End Sub

    Private Sub btnSearchDiscount_Click(sender As Object, e As MouseEventArgs) Handles txtDiscount.MouseClick
        Me.Enabled = False
        frmLookUpGeneral.LoadData(Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddItems("Order No 1:", "Comuasddsaads B1", "11")
    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        If e.ColumnIndex = 5 Then
            IncreaseQty(e.RowIndex)
        ElseIf e.ColumnIndex = 3 Then
            DecreaseQty(e.RowIndex)
        End If
    End Sub

    Private Sub IncreaseQty(ByVal e As Integer)
        dgView.Item(4, e).Value += 1
    End Sub

    Private Sub DecreaseQty(ByVal e As Integer)
        dgView.Item(4, e).Value -= 1
    End Sub


    'Dim _IsMouseDown As Boolean
    'Dim _LastMouseMove As Double = 0

    'Private Function GetMousePosition() As Point
    '    Return (Me.PointToScreen(System.Windows.Forms.Control.MousePosition))
    'End Function

    'Private Sub pnlMain_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlMain.MouseDown

    '    If Not _IsMouseDown Then

    '        'set the mouse to down (Main panel)
    '        _IsMouseDown = True
    '        'Record the position of the mouse down
    '        _LastMouseMove = GetMousePosition()

    '    End If

    'End Sub

    'Private Sub pnlMain_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlMain.MouseUp

    '    If _IsMouseDown Then
    '        _IsMouseDown = False
    '    End If

    'End Sub

    'Private Sub pnlMain_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlMain.MouseMove

    '    If _IsMouseDown Then
    '        Dim currentMouse As Point = GetMousePosition()
    '        If Not _LastMouseMove = currentMouse Then
    '            If pnlMain.Location.Y + (currentMouse.Y - _LastMouseMove) > 0 Then
    '                pnlMain.Top = 0
    '            End If
    '        End If
    '        End If

    'End Sub

End Class