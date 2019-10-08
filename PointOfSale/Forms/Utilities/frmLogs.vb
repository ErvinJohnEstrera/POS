Imports MySql.Data.MySqlClient
Imports CitiFramework

Public Class frmLogs

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As modFunctions
    Dim clsLogs As New ClsLogs
    Dim rs As MySqlDataReader

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Build_dgSampleForm()
        FillDataGrid()
    End Sub

#Region "CUSTOM SUBS AND PROCS"


    Private Sub Build_dgSampleForm()

        With dgView.Columns
            .Clear()
            .Add("id", "id")
            .Add("emp_no", "Employee No")
            .Add("date", "Date")
            .Add("activity", "Activity")
        End With

        With dgView
            'SET SIZES OF COLUMNS
            .Columns("id").Width = 125
            .Columns("emp_no").Width = 125
            .Columns("date").Width = 125
            .Columns("activity").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'SET DATAGRID ATTRIBUTES
            .ReadOnly = False
            .RowHeadersVisible = False
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns("id").Visible = False
            .Columns("emp_no").Visible = False
            .Columns("date").ReadOnly = True
            .Columns("activity").ReadOnly = True

            'SET COLUMNS ALIGNMENT FOR BETTER USER VIEWING
            .Columns("emp_no").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("activity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

    End Sub

    Sub FillDataGrid()
        dgView.Rows.Clear()

        rs = clsLogs.getListLogTrail()

        If rs.HasRows Then
            Do While rs.Read
                With dgView.Rows(dgView.Rows.Add)
                    .Cells("id").Value = rs!id
                    .Cells("emp_no").Value = rs!emp_no
                    .Cells("date").Value = rs!date
                    .Cells("activity").Value = rs!activity & ":-- " & rs!errMessage
                End With
            Loop
        End If

    End Sub

    Sub FillAllFields(ByVal ID As String)
        'FILL ALL FORM FIELDS

    End Sub


#End Region

#Region "BUTTONS"

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'INITIATE VALIDATIONS


        'CONFIRM BEFORE SAVING
        If MsgBox("Are you sure you want to delete this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMATION") = MsgBoxResult.No Then
            Exit Sub
        End If

        'PROCESS EDIT CODE HERE

        MsgBox("Successfully deleted transaction ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
    End Sub

    Private Sub dgView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        Dim i As Integer
        i = dgView.CurrentRow.Index

        MsgBox("Audit By: " + dgView.Item(1, i).Value.ToString() + " " + dgView.Item(2, i).Value.ToString() + " " + dgView.Item(3, i).Value.ToString(), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMATION")
    End Sub


#End Region


End Class