Imports MySql.Data.MySqlClient

Public Class frmVat

    'Declare Variables

    Dim rs As MySqlDataReader
    Dim clsVat As New ClsVat
    Dim id As Integer

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        id = 1
        clsVat.Process("update", id, Convert.ToInt32(txtValue.Text))
        MessageBox.Show("Value Changed")
    End Sub

    Private Sub frmVat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData()
        rs = ClsVat.getVatValue()
        If rs.HasRows Then
            rs.Read()
            txtValue.Text = rs!value
        End If
    End Sub
End Class