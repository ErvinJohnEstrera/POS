Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmUserRole

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsUserRole As New clsUserRoles
    Dim rs As SqlDataReader
    Dim MDIMotherForm As Form

    Dim id As String

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        fillDg()
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
        'ADD DATAGRID COLUMNS
        With dgView.Columns
            .Clear()
            .Add("id", "id")
            .Add("userrole", "User Role")
            .Add("description", "Description")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("userrole").Width = 125
            .Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").Visible = False
            .Columns("userrole").ReadOnly = True
            .Columns("description").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("userrole").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub fillDg()
        'FILL ALL FORM FIELDS
        dgView.Rows.Clear()

        rs = clsUserRole.GetListOfUR()
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!UserRole_ID
                    .Cells("userrole").Value = rs!UserRole_Name
                    .Cells("description").Value = rs!UserRole_Description
                End With
            Loop
        End If
    End Sub

    Public Sub GenerateID()
        rs = clsUserRole.GetLatestURNo()
        If rs.HasRows Then
            rs.Read()
            id = rs!ID
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

    Sub LoadData(ByVal MotherForm As Form)
        MDIMotherForm = MotherForm

        Me.Show()
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
        rs = clsUserRole.CheckIfInUsed(id)

        If rs.HasRows Then
            Do While rs.Read()
                If rs!UserRole_ID = id Then
                    MsgBox(txtURName.Text & " cannot be deleted. Data is in use.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
                    Exit Sub
                End If
            Loop
        End If

        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS DELETE CODE HERE
        clsUserRole.DeleteUR(id)
        MsgBox("Successfully deleted transaction " & Trim(txtURName.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        fillDg()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        rs = clsUserRole.CheckIfExists(txtURName.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtURName.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!UserRole_Name = txtURName.Text Then
                    MsgBox(txtURName.Text & " already exists.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                clsUserRole.SaveUR(id, txtURName.Text, txtDesc.Text)

            Case AddMode.Edit

                'UPDATE PRODUCTS
                clsUserRole.SaveUR(id, txtURName.Text, txtDesc.Text)

        End Select

        MsgBox("Transaction " & txtURName.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        'FILL ALL FIELDS ON THE FORM
        mf.ClearAllFields(pnlMain)
        fillDg()
        ToggleLock(True)
    End Sub


#End Region


    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        Dim i As Integer
        i = dgView.CurrentRow.Index
        id = dgView.Item(0, i).Value.ToString()
        txtURName.Text = dgView.Item(1, i).Value.ToString()
        txtDesc.Text = dgView.Item(2, i).Value.ToString()
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub frmUserRole_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MDIMotherForm Is "" Then
            Exit Sub
        ElseIf MDIMotherForm Is frmEmployee Then
            frmEmployee.FillComboUserRole()
            frmEmployee.Enabled = True
            frmEmployee.Focus()
        End If
    End Sub
End Class