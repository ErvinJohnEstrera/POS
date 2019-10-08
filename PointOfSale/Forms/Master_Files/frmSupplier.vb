Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmSupplier

    Dim rs As SqlDataReader
    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode

    Dim mf As New modFunctions
    Dim clsSupplier As New clsSupplier
    Dim id As Integer

    Private Sub FormWithNoGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
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

            txtSuppNo.Enabled = True

            pnlBody.Enabled = False
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True
            btnSearchTransNo.Enabled = False

            txtSuppNo.Enabled = False

            pnlBody.Enabled = True
        End If
    End Sub

    Sub FillAllFields(ByVal ID As String)
        Dim rs As SqlDataReader

        rs = clsSupplier.GetSupp(ID)

        If rs.HasRows Then
            rs.Read()

            txtSuppNo.Text = ID
            txtCompName.Text = rs!Supplier_CompName
            txtCompCont.Text = rs!Supplier_CompContactNo
            txtCompEmail.Text = rs!Supplier_CompEmail
            txtCompAdd.Text = rs!Supplier_CompAddress
            txtPicFName.Text = rs!Supplier_PicName
            txtPicCont.Text = rs!Supplier_PicContactNo
            txtPicAdd.Text = rs!Supplier_PicAddress
            txtLeadtime.Text = rs!Supplier_LeadTime
            txtOrderCost.Text = rs!Supplier_OrderCost

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
        rs = clsSupplier.GetLatestSuppNo()
        If rs.HasRows Then
            rs.Read()
            txtSuppNo.Text = rs!ID
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

        Dim TransNo As String = txtSuppNo.Text

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        mf.ClearAllFields(pnlMain, True) 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION

        If strAddmode = AddMode.Edit Then
            'IF IN EDIT MODE, 'FILL ALL FIELDS ON THE FORM
            FillAllFields(txtSuppNo.Text)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this supplier?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS EDIT CODE HERE
        clsSupplier.DeleteSupp(txtSuppNo.Text)

        MsgBox("Successfully deleted supplier " & Trim(txtSuppNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        rs = clsSupplier.CheckIfExists(txtCompName.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtCompName.Text) = "" Or
           Trim(txtCompCont.Text) = "" Or
           Trim(txtCompAdd.Text) = "" Or
           Trim(txtLeadtime.Text) = "" Or
           Trim(txtOrderCost.Text) = "" Or
           Trim(txtPicFName.Text) = "" Or
           Trim(txtPicCont.Text) = "" Or
           Trim(txtPicAdd.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Supplier_CompName = txtCompName.Text Then
                    MsgBox(txtCompName.Text & " already exists. Please try another name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                clsSupplier.SaveSupp(txtSuppNo.Text,
                                  txtCompName.Text,
                                  txtCompAdd.Text,
                                  txtCompCont.Text,
                                  txtPicAdd.Text,
                                  txtCompEmail.Text,
                                  txtPicFName.Text,
                                  txtPicCont.Text,
                                  Convert.ToInt32(txtLeadtime.Text),
                                  Convert.ToDecimal(txtOrderCost.Text))

            Case AddMode.Edit

                'UPDATE PRODUCTS
                clsSupplier.SaveSupp(txtSuppNo.Text,
                                  txtCompName.Text,
                                  txtCompAdd.Text,
                                  txtCompCont.Text,
                                  txtPicAdd.Text,
                                  txtCompEmail.Text,
                                  txtPicFName.Text,
                                  txtPicCont.Text,
                                  Convert.ToInt32(txtLeadtime.Text),
                                  Convert.ToDecimal(txtOrderCost.Text))


        End Select

        MsgBox("Supplier " & txtCompName.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")


        'FILL ALL FIELDS ON THE FORM
        mf.ClearAllFields(pnlBody)
        ToggleLock(True)
    End Sub

    Private Sub btnSearchTransNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTransNo.Click
        Me.Enabled = False
        luSupplier.MdiParent = mdiMain
        luSupplier.LoadData(Me)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtSuppNo.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtSuppNo.Text)
    End Sub

    Private Sub btnCancelTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtSuppNo.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtSuppNo.Text)
    End Sub

#End Region



    Private Sub txtTransNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuppNo.Validated
        If btnAdd.Enabled And Trim(txtSuppNo.Text) <> "" Then
            FillAllFields(txtSuppNo.Text)
        End If
    End Sub

    Private Sub txtPicCont_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPicCont.KeyUp
        mf.NumericOnly(txtPicCont, False, False, False)
    End Sub

    Private Sub txtOrderCost_KeyUp(sender As Object, e As KeyEventArgs) Handles txtOrderCost.KeyUp
        mf.NumericOnly(txtOrderCost, True, True, True)
    End Sub

    Private Sub txtLeadtime_KeyUp(sender As Object, e As KeyEventArgs) Handles txtLeadtime.KeyUp
        mf.NumericOnly(txtPicCont, False, False, False)
    End Sub

    Private Sub txtCompCont_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCompCont.KeyUp
        mf.NumericOnly(txtPicCont, False, False, False)
    End Sub
End Class