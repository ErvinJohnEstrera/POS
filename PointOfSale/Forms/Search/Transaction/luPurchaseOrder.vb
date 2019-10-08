Imports System.Data.SqlClient
Imports CitiFramework

Public Class luPurchaseOrder

    Dim MDIMotherForm As Form
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim clsPurchaseOrder As New clsPurchaseOrder
    Dim PurchaseOrder As New clsPurchaseOrder

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
            .Add("id", "Purchase No")
            .Add("date", "Date")
            .Add("supp", "Supplier")
            .Add("status", "Status")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("id").Width = 125
            .Columns("date").Width = 125
            .Columns("supp").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("status").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").ReadOnly = True
            .Columns("date").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("supp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        dgView.Rows.Clear()

        rs = PurchaseOrder.GetListOfPO()
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!PO_Header_ID
                    .Cells("date").Value = rs!PO_Header_Date
                    .Cells("supp").Value = rs!Supplier_CompName
                    .Cells("status").Value = rs!PO_Header_Status
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmPurchaseOrder Then
                    frmPurchaseOrder.FillAllFields(.Cells("id").Value)
                ElseIf MDIMotherForm Is frmDeliveryReceivingOrder Then
                    frmDeliveryReceivingOrder.FillAllFields(.Cells("id").Value)
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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class