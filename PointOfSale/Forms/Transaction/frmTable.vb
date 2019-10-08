Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmTable

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim cls As New clsTable

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        FillAllDgView()
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
            ' .Add(CboHM)
            .Add("Table_No", "Table No")
            .Add("Table_Details", "Table Details")
            .Add("Table_Status", "Status")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Table_No").Width = 125
            .Columns("Table_Details").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Table_Status").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Table_No").ReadOnly = True
            .Columns("Table_Details").ReadOnly = True
            .Columns("Table_Status").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Table_No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Table_Details").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Table_Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillAllDgView()
        dgView.Rows.Clear()

        rs = cls.GetListOftbl()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Table_No").Value = rs!Table_ID
                    .Cells("Table_Details").Value = rs!Table_Details
                    .Cells("Table_Status").Value = rs!Table_Status
                End With
            Loop
        End If
    End Sub


#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        mf.ClearAllFields(pnlMain)
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
        cls.Deletetbl(txtTableNo.Text)


        MsgBox("Successfully deleted transaction " & Trim(txtTableNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        FillAllDgView()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        rs = cls.CheckIfExistsTbl(txtTableNo.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtTableNo.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Table_ID = txtTableNo.Text Then
                    MsgBox(txtTableNo.Text & " already exists. Please try another name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                cls.Savetbl(txtTableNo.Text, txtTableDetails.Text, "Available")

            Case AddMode.Edit

                'UPDATE PRODUCTS
                cls.Savetbl(txtTableNo.Text, txtTableDetails.Text, "Available")

        End Select

        MsgBox("Transaction " & txtTableNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)
        mf.ClearAllFields(pnlMain)
        FillAllDgView()
        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        Dim i As Integer
        i = dgView.CurrentRow.Index
        txtTableNo.Text = dgView.Item(0, i).Value.ToString()
        txtTableDetails.Text = dgView.Item(1, i).Value.ToString()
        ToggleLock(True)
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
        btnSave.Enabled = False
    End Sub

#End Region


End Class