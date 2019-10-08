Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmCategory

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode

    Dim rs As SqlDataReader

    Dim mf As New modFunctions
    Dim clsCategory As New clsCategory

    Dim id As String
    Dim category_name As String
    Dim category_desc As String

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        Fill_dgLookUp()
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
        'ADD DATAGRID COLUMNS
        With dgView.Columns
            .Clear()
            .Add("id", "id")
            .Add("category", "Category")
            .Add("description", "Description")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("category").Width = 125
            .Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").Visible = False
            .Columns("category").ReadOnly = True
            .Columns("description").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Private Sub Fill_dgLookUp()
        dgView.Rows.Clear()

        rs = clsCategory.GetListOfCat()
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!Category_ID
                    .Cells("category").Value = rs!Category_Name
                    .Cells("description").Value = rs!Category_Description
                End With
            Loop
        End If
    End Sub

    Private Sub GenerateID()
        rs = clsCategory.GetLatestCatNo()
        If rs.HasRows Then
            rs.Read()
            id = rs!ID
        End If
    End Sub

#End Region

#Region "BUTTONS"
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strAddmode = AddMode.Add
        GenerateID()
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
        rs = clsCategory.CheckIfInUsedCat(id)

        'INITIATE VALIDATIONS
        If rs.HasRows Then
            Do While rs.Read()
                If rs!Category_ID = id Then
                    MsgBox(txtCatName.Text & " cannot be deleted. Data is in use.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
                    Exit Sub
                End If
            Loop
        End If


        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS DELETE CODE HERE

        clsCategory.DeleteCat(id)
        MsgBox("Successfully deleted category " & Trim(txtCatName.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        Fill_dgLookUp()
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        rs = clsCategory.CheckIfExistsCat(txtCatName.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtCatName.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        ElseIf (Trim(txtCatName.Text) = category_name And Trim(txtDesc.Text) = category_desc) Then
            MsgBox("No changes were made.")
            Exit Sub
        ElseIf (Trim(txtCatName.Text) = category_name And Not Trim(txtDesc.Text) = category_desc) Then

        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Category_Name = txtCatName.Text Then
                    MsgBox(txtCatName.Text & " already exists. Please try another name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                clsCategory.SaveCat(id, txtCatName.Text, txtDesc.Text)

            Case AddMode.Edit

                'UPDATE PRODUCTS

                clsCategory.SaveCat(id, txtCatName.Text, txtDesc.Text)


        End Select

        MsgBox("Category " & txtCatName.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")


        'FILL ALL FIELDS ON THE FORM
        mf.ClearAllFields(pnlMain)
        Fill_dgLookUp()
        ToggleLock(True)
    End Sub


#End Region


    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        Dim i As Integer
        i = dgView.CurrentRow.Index
        id = Convert.ToInt32(dgView.Item(0, i).Value.ToString())
        txtCatName.Text = dgView.Item(1, i).Value.ToString()
        txtDesc.Text = dgView.Item(2, i).Value.ToString()
        category_name = dgView.Item(1, i).Value.ToString()
        category_desc = dgView.Item(2, i).Value.ToString()
        ToggleLock(True)
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
        btnSave.Enabled = False
    End Sub
End Class