Imports CitiFramework
Imports System.Data.SqlClient

Public Class luEmployee

    Dim rs As SqlDataReader
    Dim Con As New SqlConnection
    Dim clas As New clsEmployee
    Dim cust As New frmEmployee
    Dim mf As New modFunctions

    Dim id As Integer

    Dim MDIMotherForm As Form

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
            .Add("id", "Employee Code")
            .Add("f_name", "Full Name")
            .Add("add", "Address")
            .Add("contact", "Contact No")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("id").Width = 125
            .Columns("f_name").Width = 180
            .Columns("add").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("contact").Width = 125

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").ReadOnly = True
            .Columns("f_name").ReadOnly = True
            .Columns("add").ReadOnly = True
            .Columns("contact").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("contact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        mf.NotSortable(dgView) 'SET COLUMN HEADER AS NON CLICKABLE / NON SORTABLE
    End Sub

    Private Sub Fill_dgLookUp()
        dgView.Rows.Clear()

        rs = clas.GetListOfEmp
        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!Employee_ID
                    .Cells("f_name").Value = rs!Employee_LastName & ", " & rs!Employee_FirstName & " " & rs!Employee_MiddleName
                    .Cells("add").Value = rs!Employee_Address
                    .Cells("contact").Value = rs!Employee_PhoneNo
                End With
            Loop
        End If
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dgView.Rows.Count > 0 Then
            'PROCESS SELECTION DEPENDS ON MOTHERFORM
            With dgView.CurrentRow
                If MDIMotherForm Is frmEmployee Then
                    frmEmployee.FillAllFields(.Cells("id").Value)
                ElseIf MDIMotherForm Is frmRequestRawMaterial Then
                    frmRequestRawMaterial.FillEmpName(.Cells("id").Value, .Cells("f_name").Value)
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