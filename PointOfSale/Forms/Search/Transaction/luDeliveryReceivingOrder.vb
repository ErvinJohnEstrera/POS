Imports System.Data.SqlClient
Imports CitiFramework

Public Class luDeliveryReceivingOrder

    Dim MDIMotherForm As Form
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim clsDeliveryReceivingOrder As New clsDeliveryReceivingOrder

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

        For Each col As DataGridViewColumn In dgLookUp.Columns
            cboSearchType.Items.Add(col.HeaderText)
        Next
    End Sub

    Private Sub Build_dgLookUp()
        'ADD DATAGRID COLUMNS
        With dgLookUp.Columns
            .Clear()
            .Add("droid", "DRO No.")
            .Add("date", "Received Date")
            .Add("supp", "Supplier")
            .Add("grand_tot", "Grand Total")
            .Add("received_by", "Received By")
            .Add("poh_no", "poh_no")
        End With

        With dgLookUp
            'SET SIZES OF COLUMNS
            .Columns("droid").Width = 125
            .Columns("date").Width = 125
            .Columns("supp").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("grand_tot").Width = 125
            .Columns("received_by").Width = 125
            .Columns("poh_no").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("droid").ReadOnly = True
            .Columns("date").ReadOnly = True
            .Columns("supp").ReadOnly = True
            .Columns("grand_tot").ReadOnly = True
            .Columns("received_by").ReadOnly = True
            .Columns("poh_no").Visible = False

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("droid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("supp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("grand_tot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("received_by").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgLookUp) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        rs = clsDeliveryReceivingOrder.GetListOfDRO()
        If rs.HasRows Then
            Do While rs.Read()
                With dgLookUp.Rows(dgLookUp.Rows.Add)
                    .Cells("droid").Value = rs!DRO_Header_ID
                    .Cells("date").Value = rs!DRO_Header_Date
                    .Cells("supp").Value = rs!Supplier_CompName
                    .Cells("grand_tot").Value = rs!DRO_Header_GrandTotal
                    .Cells("received_by").Value = rs!Employee_ID
                    .Cells("poh_no").Value = rs!PO_Header_ID
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgLookUp.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgLookUp.CurrentRow
                If MDIMotherForm Is frmDeliveryReceivingOrder Then
                    frmDeliveryReceivingOrder.FillAllFieldsDRO(.Cells("droid").Value, .Cells("poh_no").Value)
                End If
            End With
            Me.Close()
        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        'THIS SEARCH ALGO IS ONLY ADVISABLE FOR ROWS NOT MORE THAN 2000
        For Each row As DataGridViewRow In dgLookUp.Rows
            Dim str As String = UCase(row.Cells(cboSearchType.SelectedIndex).Value)

            If str.Contains(UCase(txtSearch.Text)) Then
                row.Visible = True
            Else
                row.Visible = False
            End If

            dgLookUp.PerformLayout()
        Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class