Imports System.Data.SqlClient
Imports CitiFramework

Public Class luMenu

    Dim MDIMotherForm As Form
    Dim clsMenu As New clsMenu
    Dim mf As New modFunctions
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
            .Add("Menu_ID", "Menu No")
            .Add("Menu_Name", "Menu Name")
            .Add("Menu_Description", "Description")
            .Add("Menu_Price", "Price")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Menu_ID").Width = 125
            .Columns("Menu_Name").Width = 125
            .Columns("Menu_Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Menu_Price").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Menu_ID").ReadOnly = True
            .Columns("Menu_Name").ReadOnly = True
            .Columns("Menu_Description").ReadOnly = True
            .Columns("Menu_Price").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Menu_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Menu_Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Menu_Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Menu_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        rs = clsMenu.GetListOfmenu()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Menu_ID").Value = rs!Menu_ID
                    .Cells("Menu_Name").Value = rs!Menu_Name
                    .Cells("Menu_Description").Value = rs!Menu_Description
                    .Cells("Menu_Price").Value = rs!Menu_Price
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmMenu Then
                    frmMenu.FillAllFields(.Cells("Menu_ID").Value)
                ElseIf MDIMotherForm Is frmOrder Then
                    With frmOrder.dgView.Rows(frmOrder.dgView.Rows.Add)
                        .Cells("Menu_No").Value = dgView.CurrentRow.Cells("Menu_ID").Value
                        .Cells("Menu_Name").Value = dgView.CurrentRow.Cells("Menu_Name").Value
                        .Cells("Unit_Price").Value = dgView.CurrentRow.Cells("Menu_Price").Value
                        .Cells("Qty").Value = 1
                        .Cells("Discount").Value = 0.00
                        .Cells("Sub_Total").Value = 0.00
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