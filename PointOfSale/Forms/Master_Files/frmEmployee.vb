Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmEmployee

    Dim rs As SqlDataReader
    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode

    Dim mf As New modFunctions
    Dim clsEmployee As New clsEmployee
    Dim Employee As New clsEmployee
    Dim clsUserRoles As New clsUserRoles
    Dim id As Integer

    Private Sub FormWithNoGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        FillComboUserRole()
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

            txtCode.Enabled = True

            pnlBody.Enabled = False
        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True
            btnSearchTransNo.Enabled = False

            txtCode.Enabled = False

            pnlBody.Enabled = True
        End If
    End Sub

    Sub FillComboUserRole()
        Dim rs As SqlDataReader
        Dim dt As New DataTable

        rs = clsUserRoles.GetListOfUR()
        dt.Load(rs)

        cbxUR.DataSource = dt
        cbxUR.DisplayMember = "UserRole_Name"
        cbxUR.ValueMember = "UserRole_ID"
    End Sub

    Sub FillAllFields(ByVal ID As String)
        Dim rs As SqlDataReader

        rs = Employee.GetEmp(ID)

        If rs.HasRows Then
            rs.Read()
            txtCode.Text = ID
            txtFName.Text = rs!Employee_FirstName
            txtMName.Text = rs!Employee_MiddleName
            txtLName.Text = rs!Employee_LastName
            txtAdd.Text = rs!Employee_Address
            txtContNo.Text = rs!Employee_PhoneNo
            txtEmail.Text = rs!Employee_Email
            txtUser.Text = rs!Employee_Username
            txtPass.Text = rs!Employee_Password
            txtCPass.Text = rs!Employee_Password
            cbxUR.Text = rs!UserRole_Name

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

        rs = Employee.GetLatestEmpNo()
        If rs.HasRows Then
            rs.Read()
            txtCode.Text = rs!ID
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

        Dim TransNo As String = txtCode.Text

        ToggleLock(True) 'LOCK THE FORM AFTER CANCELLATION
        mf.ClearAllFields(pnlMain, True) 'CLEAR ALL FIELDS IN THE FORM USING MOTHER PANEL WITH RECUSSION

        If strAddmode = AddMode.Edit Then
            'IF IN EDIT MODE, 'FILL ALL FIELDS ON THE FORM
            '  FillAllFields("1")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS EDIT CODE HERE

        Employee.DeleteEmp(txtCode.Text)

        MsgBox("Successfully deleted employee " & Trim(txtCode.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtLName.Text) = "" Or
           Trim(txtFName.Text) = "" Or
           Trim(txtAdd.Text) = "" Or
           Trim(txtContNo.Text) = "" Or
           Trim(cbxUR.Text) = "" Or
           Trim(txtUser.Text) = "" Or
           Trim(txtPass.Text) = "" Or
           Trim(txtCPass.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        ElseIf Not txtPass.Text = txtCPass.Text Then
            MsgBox("You entered different password. Please try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                Employee.SaveEmp(txtCode.Text, txtFName.Text, txtMName.Text, txtLName.Text, txtEmail.Text, txtContNo.Text, txtAdd.Text, txtUser.Text, txtPass.Text, Convert.ToInt32(cbxUR.SelectedValue))

            Case AddMode.Edit

                'UPDATE PRODUCTS
                Employee.SaveEmp(txtCode.Text, txtFName.Text, txtMName.Text, txtLName.Text, txtEmail.Text, txtContNo.Text, txtAdd.Text, txtUser.Text, txtPass.Text, Convert.ToInt32(cbxUR.SelectedValue))


        End Select

        MsgBox("Employee " & txtLName.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")


        'FILL ALL FIELDS ON THE FORM
        mf.ClearAllFields(pnlBody)
        ToggleLock(True)
    End Sub

    Private Sub btnSearchTransNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTransNo.Click
        Me.Enabled = False
        luEmployee.MdiParent = mdiMain
        luEmployee.LoadData(Me)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtCode.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtCode.Text)
    End Sub

    Private Sub btnCancelTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        'IF THERE'S ANY

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to 'POST' this request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS CODE HERE


        MsgBox("Transaction " & txtCode.Text & " has been posted successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        FillAllFields(txtCode.Text)
    End Sub

#End Region



    Private Sub txtTransNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.Validated
        If btnAdd.Enabled And Trim(txtCode.Text) <> "" Then
            FillAllFields(txtCode.Text)
        End If
    End Sub

    Private Sub txtContNo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtContNo.KeyUp
        mf.NumericOnly(txtContNo, True, False, False)
    End Sub

    Private Sub btnSearchUserRole_Click(sender As Object, e As EventArgs) Handles btnSearchUserRole.Click
        Me.Enabled = False
        frmUserRole.MdiParent = mdiMain
        frmUserRole.LoadData(Me)
    End Sub

End Class