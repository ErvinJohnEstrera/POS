Imports CitiFramework
Imports System.Data.SqlClient
Imports System.IO

Public Class frmMenu

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsMenu As New clsMenu
    Dim rs As SqlDataReader

    Dim ImagePath As String = ""

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToggleLock(True)
        Build_dgSampleForm()
    End Sub

#Region "CUSTOM SUBS AND PROCS"

    Private Sub ToggleLock(ByVal Locked As Boolean)

        If Locked Then
            btnAdd.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False

            pnlDetails.Enabled = False
            pnlGrid.Enabled = False


        Else
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = True

            pnlDetails.Enabled = True
            pnlGrid.Enabled = True
        End If
    End Sub

    Private Sub Build_dgSampleForm()
        With dgView.Columns
            .Clear()
            .Add("Menu_Item_ID", "Menu ID")
            .Add("Menu_Item_Name", "Menu Item Name")
            .Add("Menu_Item_Qty", "Qty")
            .Add("Menu_Item_Price", "Price")

        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Menu_Item_ID").Width = 125
            .Columns("Menu_Item_Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Menu_Item_Qty").Width = 125
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
            .Columns("Menu_Item_Qty").ReadOnly = False
            .Columns("Menu_Item_Price").ReadOnly = True


            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Menu_Item_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Menu_Item_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Menu_Item_Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Menu_Item_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Sub FillAllFields(ByVal ID As String)
        dgView.Rows.Clear()

        rs = clsMenu.Getmenu(ID)
        If rs.HasRows Then
            rs.Read()
            txtMenuNo.Text = ID
            txtMenuName.Text = rs!Menu_Name
            txtDesc.Text = rs!Menu_Description
            txtPrice.Text = rs!Menu_Price
        End If

        Dim rss As SqlDataReader

        rss = clsMenu.GetmenuDetails(ID)
        If rss.HasRows Then
            Do While rss.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Menu_Item_ID").Value = rss!Menu_Item_ID
                    .Cells("Menu_Item_Name").Value = rss!Menu_Item_Name
                    .Cells("Menu_Item_Qty").Value = rss!Details_Qty
                    .Cells("Menu_Item_Price").Value = rss!Menu_Item_Price
                End With
            Loop
        End If

        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnCancel.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = False
    End Sub

    Private Sub GenerateID()
        rs = clsMenu.GetLatestmenuNo()
        If rs.HasRows Then
            rs.Read()
            txtMenuNo.Text = rs!ID
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
        clsMenu.Deletemenu(txtMenuNo.Text)

        clsMenu.DeletemenuDetails(txtMenuNo.Text)

        MsgBox("Successfully deleted transaction " & Trim(txtMenuName.Text) & ".", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        mf.ClearAllFields(pnlMain)
        mf.ClearAllFields(pnlGrid)
        ToggleLock(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'INITIATE SOME VALIDATIONS FOR REQUIRED FIELDS BEFORE SAVING
        If Trim(txtMenuName.Text) = "" Then
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
                clsMenu.Savemenu(txtMenuNo.Text, txtMenuName.Text, txtDesc.Text, Convert.ToDecimal(txtPrice.Text))

                For Each row As DataGridViewRow In dgView.Rows
                    clsMenu.SavemenuD(txtMenuNo.Text, row.Cells("Menu_Item_ID").Value, CInt(row.Cells("Menu_Item_Qty").Value))
                Next

            Case AddMode.Edit

                'UPDATE PRODUCTS
                clsMenu.Savemenu(txtMenuNo.Text, txtMenuName.Text, txtDesc.Text, Convert.ToDecimal(txtPrice.Text))

                clsMenu.DeletemenuDetails(txtMenuNo.Text)

                For Each row As DataGridViewRow In dgView.Rows
                    clsMenu.SavemenuD(txtMenuNo.Text, row.Cells("Menu_Item_ID").Value, CInt(row.Cells("Menu_Item_Qty").Value))
                Next

        End Select

        MsgBox("Transaction " & txtMenuName.Text & " has been saved successfully!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
        ToggleLock(True)
        mf.ClearAllFields(pnlDetails)
        mf.ClearAllFields(pnlGrid)
        'FILL ALL FIELDS ON THE FORM
    End Sub

    Private Sub btnAddMenuItem_Click(sender As Object, e As EventArgs) Handles btnAddMenuItem.Click
        Me.Enabled = False
        luMenuItem.LoadData(Me)
    End Sub

    Private Sub btnSearchTransNo_Click(sender As Object, e As EventArgs) Handles btnSearchTransNo.Click
        Me.Enabled = False
        luMenu.LoadData(Me)
    End Sub

    Private Sub pbImage_Click(sender As Object, e As EventArgs) Handles pbImage.Click
        SelectImage()
    End Sub

    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        SelectImage()
    End Sub

    Dim pathhhh As String = ""

    Private Sub SelectImage()
        Dim file As DialogResult = OpenFileDialog1.ShowDialog()

        If file = Windows.Forms.DialogResult.OK Then
            ImagePath = OpenFileDialog1.FileName
        End If

        pbImage.ImageLocation = ImagePath
        pbImage.SizeMode = PictureBoxSizeMode.StretchImage
        MessageBox.Show(Application.CommonAppDataPath)
    End Sub

#End Region

End Class