Imports CitiFramework
Imports System.Data.SqlClient

Public Class luItems

    Dim MDIMotherForm As Form
    Dim mf As New modFunctions
    Dim clsItems As New clsItems
    Dim rs As SqlDataReader

    Private Sub frmLookUpGeneral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'CHECK WHAT MODULE IS USING THIS LOOK UP FORM
        MDIMotherForm.Enabled = True
        MDIMotherForm.Focus()
    End Sub

    Private Sub frmLookUpGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Build_dgLookUp() 'BUILD DATAGRID
        LoadComboboxColumns() 'LOAD DATAGRID COLUMNS IN COMBOBOX FOR SEARCHING PURPOSES
        cboSearchType.SelectedIndex = 0

        Fill_dgLookUp()
    End Sub

    Sub LoadData(ByVal MotherForm As Form)
        MDIMotherForm = MotherForm

        Me.Show()
    End Sub

    Private Sub LoadComboboxColumns()
        cboSearchType.Items.Clear()

        For Each col As DataGridViewColumn In dgView.Columns
            cboSearchType.Items.Add(col.HeaderText)
        Next
    End Sub

    Private Sub Build_dgLookUp()
        'ADD DATAGRID COLUMNS
        With dgView.Columns
            .Clear()
            .Add("ID", "ID")
            .Add("name", "Item Name")
            .Add("cat_no", "Category No")
            .Add("cat_name", "Category Name")
            .Add("UOMNo", "UOMNo")
            .Add("UOMName", "UOM")
            .Add("reorder_lvl", "Re-Order Level")
            .Add("safety_stock", "Safety Stock")
            .Add("start_qty", "Starting Qty")
            .Add("stocks", "Stocks")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("ID").Width = 125
            .Columns("name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("cat_no").Width = 100
            .Columns("cat_name").Width = 100
            .Columns("UOMNo").Width = 100
            .Columns("UOMName").Width = 100
            .Columns("reorder_lvl").Width = 100
            .Columns("safety_stock").Width = 100
            .Columns("start_qty").Width = 100
            .Columns("stocks").Width = 70

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("ID").ReadOnly = True
            .Columns("name").ReadOnly = True
            .Columns("cat_no").ReadOnly = True
            .Columns("cat_name").ReadOnly = True
            .Columns("UOMNo").ReadOnly = True
            .Columns("UOMName").ReadOnly = True
            .Columns("reorder_lvl").ReadOnly = True
            .Columns("safety_stock").ReadOnly = True
            .Columns("start_qty").ReadOnly = True
            .Columns("stocks").Width = 70

            .Columns("cat_no").Visible = False
            .Columns("UOMNo").Visible = False

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("cat_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("cat_name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("UOMNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("UOMName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("reorder_lvl").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("safety_stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("start_qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("stocks").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        dgView.Rows.Clear()

        rs = clsItems.GetListOfItm()
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("ID").Value = rs!Items_ID
                    .Cells("name").Value = rs!Items_Name
                    .Cells("cat_no").Value = rs!Category_ID
                    .Cells("cat_name").Value = rs!Category_Name
                    .Cells("UOMNo").Value = rs!UOM_ID
                    .Cells("UOMName").Value = rs!UOM_Name
                    .Cells("reorder_lvl").Value = rs!Items_ReOrderLvl
                    .Cells("safety_stock").Value = rs!Items_SafetyStock
                    .Cells("start_qty").Value = rs!Items_StartQty
                    .Cells("stocks").Value = rs!Remaining_Qty
                End With
            Loop
        End If

    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmItems Then
                    frmItems.FillAllFields(.Cells("ID").Value)
                ElseIf MDIMotherForm Is frmPurchaseOrder Then
                    With frmPurchaseOrder.dgView.Rows(frmPurchaseOrder.dgView.Rows.Add)
                        .Cells("id").Value = dgView.CurrentRow.Cells("ID").Value
                        .Cells("name").Value = dgView.CurrentRow.Cells("name").Value
                        .Cells("uom").Value = dgView.CurrentRow.Cells("UOMName").Value
                        .Cells("qty").Value = 1
                    End With
                ElseIf MDIMotherForm Is frmRequestRawMaterial Then
                    With frmRequestRawMaterial.dgView.Rows(frmRequestRawMaterial.dgView.Rows.Add)
                        .Cells("item_no").Value = dgView.CurrentRow.Cells("ID").Value
                        .Cells("item_name").Value = dgView.CurrentRow.Cells("name").Value
                        .Cells("uom_no").Value = dgView.CurrentRow.Cells("UOMNo").Value
                        .Cells("uom_name").Value = dgView.CurrentRow.Cells("UOMName").Value
                        .Cells("qty").Value = 1
                    End With
                End If
            End With
            Me.Close()
        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        'THIS SEARCH ALGO IS ONLY ADVISABLE FOR ROWS NOT MORE THAN 2000
        For Each row As DataGridViewRow In dgView.Rows
            Dim str As String = UCase(row.Cells(cboSearchType.SelectedIndex).Value)

            If str.Contains(UCase(txtSearch.Text)) Then
                row.Visible = True
            Else
                row.Visible = False
            End If

            dgView.PerformLayout()
        Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class