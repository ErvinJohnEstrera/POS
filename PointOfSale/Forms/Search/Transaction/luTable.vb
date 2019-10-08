Imports System.Data.SqlClient
Imports CitiFramework

Public Class luTable

    Dim MDIMotherForm As Form
    Dim rs As SqlDataReader
    Dim mf As New modFunctions
    Dim cls As New clsTable

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

    Private Sub Fill_dgLookUp()
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


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmBooking Then
                    frmBooking.txtTable.Text = .Cells("Table_No").Value
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