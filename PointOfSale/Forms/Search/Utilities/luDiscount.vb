Imports System.Data.SqlClient
Imports CitiFramework

Public Class frmLookUpGeneral

    Dim MDIMotherForm As Form
    Dim cls As New clsDiscount
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
        'Dim CboHM As New DataGridViewCheckBoxColumn()

        'CboHM.Name = "Checkbox"
        'CboHM.HeaderText = "..."

        With dgView.Columns
            .Clear()
            '.Add(CboHM)
            .Add("Discount_ID", "Promo No")
            .Add("Discount_Amount", "Amount")
            .Add("Discount_Desc", "Description")
            .Add("Discount_BeginDate", "Begin Date")
            .Add("Discount_EndDate", "End Date")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("Discount_ID").Width = 125
            .Columns("Discount_Amount").Width = 125
            .Columns("Discount_Desc").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Discount_BeginDate").Width = 125
            .Columns("Discount_EndDate").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("Discount_ID").ReadOnly = True
            .Columns("Discount_Amount").ReadOnly = True
            .Columns("Discount_Desc").ReadOnly = True
            .Columns("Discount_BeginDate").ReadOnly = True
            .Columns("Discount_EndDate").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("Discount_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Discount_Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Discount_Desc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Discount_BeginDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Discount_EndDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
        mf.ReadOnlyBackColor(dgView) 'SET BACK COLOR FOR READONLY COLUMNS
    End Sub

    Private Sub Fill_dgLookUp()
        dgView.Rows.Clear()

        rs = cls.GetListOfDisc()
        If rs.HasRows Then
            Do While rs.Read()
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("Discount_ID").Value = rs!Discount_ID
                    .Cells("Discount_Amount").Value = rs!Discount_Amount
                    .Cells("Discount_Desc").Value = rs!Discount_Desc
                    .Cells("Discount_BeginDate").Value = rs!Discount_BeginDate
                    .Cells("Discount_EndDate").Value = rs!Discount_EndDate
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmOrder Then
                    frmOrder.txtDiscount.Text = .Cells("Discount_Amount").Value
                    frmOrder.Total()
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

End Class