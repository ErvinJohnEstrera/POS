Imports System.Data.SqlClient
Imports CitiFramework

Public Class luRequestRawMaterial

    Dim MDIMotherForm As Form
    Dim mf As New modFunctions
    Dim rs As SqlDataReader
    Dim RequestedRawMaterial As New RequestedRawMaterial

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
            .Add("id", "ID")
            .Add("date", "Date")
            .Add("requested_by_no", "requested_by_no")
            .Add("requested_by", "Requested By")
            .Add("prepared_by_no", "prepared_by_no")
            .Add("prepared_by", "Prepared By")
            .Add("remarks", "Remarks")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("id").Width = 125
            .Columns("date").Width = 125
            .Columns("requested_by_no").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("requested_by").Width = 125
            .Columns("prepared_by_no").Width = 125
            .Columns("prepared_by").Width = 125
            .Columns("remarks").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").ReadOnly = True
            .Columns("date").ReadOnly = True
            .Columns("requested_by_no").ReadOnly = True
            .Columns("requested_by").ReadOnly = True
            .Columns("prepared_by_no").ReadOnly = True
            .Columns("prepared_by").ReadOnly = True
            .Columns("remarks").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("requested_by_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("requested_by").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("prepared_by_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("prepared_by").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("remarks").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        rs = RequestedRawMaterial.GetListOfRRM()
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!RRM_Header_ID
                    .Cells("date").Value = rs!RRM_Header_Date
                    .Cells("requested_by_no").Value = rs!Employee_ID
                    .Cells("requested_by").Value = rs!Employee_LastName & ", " & rs!Employee_FirstName & " " & rs!Employee_MiddleName
                    .Cells("prepared_by_no").Value = rs!Employee_ID
                    .Cells("prepared_by").Value = rs!Employee_LastName & ", " & rs!Employee_FirstName & " " & rs!Employee_MiddleName
                    .Cells("remarks").Value = rs!RRM_Header_Remarks
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmRequestRawMaterial Then
                    frmRequestRawMaterial.FillAllFields(.Cells("id").Value)
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