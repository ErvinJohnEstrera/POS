Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmItems

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim Items As New clsItems
    Dim rs As SqlDataReader

    Private Sub FormWithNoGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        LoadComboUOM()
        LoadComboCat()
    End Sub


    Private Sub LoadComboCat()
        Dim rs As SqlDataReader
        Dim clsCategory As New clsCategory
        Dim dt As New DataTable

        rs = clsCategory.GetListOfCat()

        dt.Load(rs)
        With cbxCat
            .DataSource = dt
            .DisplayMember = "Category_Name"
            .ValueMember = "Category_ID"
        End With
    End Sub

    Private Sub LoadComboUOM()
        Dim rs As SqlDataReader
        Dim clsUOM As New clsUOM
        Dim dt As New DataTable

        rs = clsUOM.GetListOfUom()

        dt.Load(rs)
        With cbxUOM
            .DataSource = dt
            .DisplayMember = "UOM_Name"
            .ValueMember = "UOM_ID"
        End With
    End Sub



#Region "PRIVATE SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnSearchTransNo.Enabled = True

            txtItemsNo.Enabled = True

            pnlBody.Enabled = False
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True
            btnSearchTransNo.Enabled = False

            txtItemsNo.Enabled = False

            pnlBody.Enabled = True
        End If
    End Sub

    Sub FillAllFields(ByVal ID As String)
        Dim rs As SqlDataReader

        rs = Items.GetItm(ID)

        If rs.HasRows Then
            rs.Read()
            txtItemsNo.Text = ID
            txtItemName.Text = rs!Items_Name
            cbxCat.Text = rs!Category_Name
            cbxUOM.Text = rs!UOM_Name
            txtReOrderLvl.Text = rs!Items_ReOrderLvl
            txtSafetyStock.Text = rs!Items_SafetyStock
            txtStartQty.Text = rs!Items_StartQty
            txtUnitPrice.Text = rs!Items_UnitPrice

            btnAdd.Enabled = False
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnCancel.Enabled = True
        Else
            MsgBox("Please provide a valid/existing transaction number.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "VALIDATION")
            mf.ClearAllFields(pnlBody)
            ToggleLock(True)
            Exit Sub
        End If
    End Sub

#End Region

    Sub GenerateID()
        Dim rs As SqlDataReader

        rs = Items.GetLatestItmNo()
        If rs.HasRows Then
            rs.Read()
            txtItemsNo.Text = rs!ID
        End If
    End Sub

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

        Dim TransNo As String = txtItemsNo.Text

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        mf.ClearAllFields(pnlMain, True) 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        rs = Items.CheckIfInUsed(txtItemsNo.Text)

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Items_ID = txtItemsNo.Text Then
                    MsgBox(txtItemName.Text & " cannot be deleted. Data is in use.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
                    Exit Sub
                End If
            Loop
        End If

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If



        'PROCESS EDIT CODE HERE
        Items.DeleteItm(txtItemsNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtItemsNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        rs = Items.CheckIfExists(txtItemName.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtItemName.Text) = "" Or
           Trim(cbxCat.Text) = "Select Category" Or
           Trim(cbxUOM.Text) = "Select Unit of Measurement" Or
           Trim(txtStartQty.Text) = "" Or
           Trim(txtUnitPrice.Text) = "" Or
           Trim(txtSafetyStock.Text) = "" Or
           Trim(txtReOrderLvl.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Items_Name = txtItemName.Text Then
                    MsgBox(txtItemName.Text & " already exists.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
                    Exit Sub
                End If
            Loop
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
                Items.SaveItm(txtItemsNo.Text, txtItemName.Text, Convert.ToInt32(cbxCat.SelectedValue), Convert.ToInt32(cbxUOM.SelectedValue), Convert.ToInt32(txtReOrderLvl.Text), Convert.ToInt32(txtSafetyStock.Text), Convert.ToInt32(txtStartQty.Text), Convert.ToDecimal(txtUnitPrice.Text))

            Case AddMode.Edit

                'UPDATE PRODUCTS

                Items.SaveItm(txtItemsNo.Text, txtItemName.Text, Convert.ToInt32(cbxCat.SelectedValue), Convert.ToInt32(cbxUOM.SelectedValue), Convert.ToInt32(txtReOrderLvl.Text), Convert.ToInt32(txtSafetyStock.Text), Convert.ToInt32(txtStartQty.Text), Convert.ToDecimal(txtUnitPrice.Text))

        End Select

        MsgBox("Transaction " & txtItemsNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)



        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtItemsNo.Text)
    End Sub

    Private Sub btnSearchTransNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTransNo.Click
        Me.Enabled = False
        luItems.MdiParent = mdiMain
        luItems.LoadData(Me)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtItemsNo.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtItemsNo.Text)
    End Sub

    Private Sub btnCancelTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtItemsNo.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtItemsNo.Text)
    End Sub

#End Region


    Private Sub txtTransNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemsNo.Validated
        If btnAdd.Enabled And Trim(txtItemsNo.Text) <> "" Then
            FillAllFields(txtItemsNo.Text)
        End If
    End Sub

    Private Sub txtStartQty_KeyUp(sender As Object, e As KeyEventArgs) Handles txtStartQty.KeyUp
        mf.NumericOnly(txtStartQty, True, False, False)
    End Sub

    Private Sub txtSafetyStock_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSafetyStock.KeyUp
        mf.NumericOnly(txtSafetyStock, True, False, False)
    End Sub

    Private Sub txtReOrderLvl_KeyUp(sender As Object, e As KeyEventArgs) Handles txtReOrderLvl.KeyUp
        mf.NumericOnly(txtReOrderLvl, True, False, False)
    End Sub

End Class