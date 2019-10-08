Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmDiscount

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim cls As New clsDiscount
    Dim rs As SqlDataReader
    Dim mf As New modFunctions

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        FillDgView()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

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
            .Add("Discount_ID", "Promo No")
            .Add("Discount_Amount", "Amount")
            .Add("Discount_Desc", "Description")
            .Add("Discount_BeginDate", "Begin Date")
            .Add("Discount_EndDate", "End Date")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Discount_ID").Width = 125
            .Columns("Discount_Amount").Width = 125
            .Columns("Discount_Desc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Discount_BeginDate").Width = 125
            .Columns("Discount_EndDate").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Discount_ID").ReadOnly = True
            .Columns("Discount_Amount").ReadOnly = True
            .Columns("Discount_Desc").ReadOnly = True
            .Columns("Discount_BeginDate").ReadOnly = True
            .Columns("Discount_EndDate").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Discount_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Discount_Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Discount_Desc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Discount_BeginDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Discount_EndDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillDgView()
        dgView.Rows.Clear()

        rs = cls.GetListOfDisc()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Discount_ID").Value = rs!Discount_ID
                    .Cells("Discount_Amount").Value = rs!Discount_Amount
                    .Cells("Discount_Desc").Value = rs!Discount_Desc
                    .Cells("Discount_BeginDate").Value = rs!Discount_BeginDate
                    .Cells("Discount_EndDate").Value = rs!Discount_EndDate
                End With
            Loop
        End If
    End Sub

    Private Sub Generate_ID()
        rs = cls.GetLatestDiscNo()
        If rs.HasRows Then
            rs.Read()
            txtPromoNo.Text = rs!ID
        End If
    End Sub


#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
        ToggleLock(False)
        Generate_ID()
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
        cls.DeleteDisc(txtPromoNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtPromoNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        FillDgView()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtDescription.Text) = "" Then
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
                cls.SaveDisc(txtPromoNo.Text, txtDescription.Text, Convert.ToDecimal(txtDiscountAmount.Text), dtpBeginDate.Value, dtpEndDate.Value)

            Case AddMode.Edit

                'UPDATE PRODUCTS
                cls.SaveDisc(txtPromoNo.Text, txtDescription.Text, Convert.ToDecimal(txtDiscountAmount.Text), dtpBeginDate.Value, dtpEndDate.Value)

        End Select

        MsgBox("Transaction " & txtPromoNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)
        FillDgView()
        mf.ClearAllFields(pnlMain)
    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        Dim i As Integer
        i = dgView.CurrentRow.Index
        txtPromoNo.Text = dgView.Item(0, i).Value.ToString()
        txtDiscountAmount.Text = dgView.Item(1, i).Value.ToString()
        txtDescription.Text = dgView.Item(2, i).Value.ToString()
        dtpBeginDate.Value = dgView.Item(3, i).Value.ToString()
        dtpEndDate.Value = dgView.Item(4, i).Value.ToString()
        ToggleLock(True)
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
        btnSave.Enabled = False
    End Sub

#End Region

End Class