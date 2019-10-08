Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmMenuItems

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsMenuItem As New clsMenuItem
    Dim rs As SqlDataReader

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
        FillAllFields()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False

            txtMenuItemsNo.Enabled = True
            pnlMain.Enabled = False

        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True

            txtMenuItemsNo.Enabled = False
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
            .Add("Menu_Item_ID", "Menu Item ID")
            .Add("Menu_Item_Name", "Menu Item Name")
            .Add("Menu_Item_Price", "Item Price")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Menu_Item_ID").Width = 125
            .Columns("Menu_Item_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Menu_Item_Price").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Menu_Item_ID").ReadOnly = True
            .Columns("Menu_Item_Name").ReadOnly = True
            .Columns("Menu_Item_Price").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Menu_Item_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Menu_Item_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Menu_Item_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillAllFields()
        dgView.Rows.Clear()

        'FILL ALL FORM FIELDS
        rs = clsMenuItem.GetListOfmenuItem()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Menu_Item_ID").Value = rs!Menu_Item_ID
                    .Cells("Menu_Item_Name").Value = rs!Menu_Item_Name
                    .Cells("Menu_Item_Price").Value = rs!Menu_Item_Price
                End With
            Loop
        End If
    End Sub

    Public Sub GenerateID()
        rs = clsMenuItem.GetLatestmenuItemNo()
        If rs.HasRows Then
            rs.Read()
            txtMenuItemsNo.Text = rs!ID
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
        clsMenuItem.DeletemenuItem(txtMenuItemsNo.Text)

        FillAllFields()
        MsgBox("Successfully deleted transaction " & Trim(txtMenuItemsNo.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        rs = clsMenuItem.CheckIfExists(txtItemsName.Text)

        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtItemsName.Text) = "" Then
            MsgBox("Please provide a valid justification.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
            Exit Sub
        End If

        If rs.HasRows Then
            Do While rs.Read()
                If rs!Menu_Item_Name = txtItemsName.Text Then
                    MsgBox(txtItemsName.Text & " already exists. Please try another name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "VALIDATION")
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
                clsMenuItem.SavemenuItem(txtMenuItemsNo.Text, txtItemsName.Text, Convert.ToDecimal(txtPrice.Text))

            Case AddMode.Edit

                'UPDATE PRODUCTS
                clsMenuItem.SavemenuItem(txtMenuItemsNo.Text, txtItemsName.Text, Convert.ToDecimal(txtPrice.Text))
        End Select

        MsgBox("Transaction " & txtMenuItemsNo.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)

        FillAllFields()
        mf.ClearAllFields(pnlMain)
        'FILL ALL FIELDS ON THE FORM
    End Sub


#End Region


    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellClick
        Dim i As Integer
        i = dgView.CurrentRow.Index
        txtMenuItemsNo.Text = dgView.Item(0, i).Value.ToString()
        txtItemsName.Text = dgView.Item(1, i).Value.ToString()
        txtPrice.Text = dgView.Item(2, i).Value.ToString()
        ToggleLock(True)
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
        btnSave.Enabled = False
    End Sub
End Class