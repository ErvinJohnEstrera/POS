Imports CitiFramework
Imports System.Data.SqlClient

Public Class frmOrderLists

    'Declare Variables

    Enum AddMode
        Add
        Edit
    End Enum

    Dim strAddmode As AddMode
    Dim mf As New modFunctions
    Dim clsOrder As New clsOrder
    Dim rs As SqlDataReader


    Dim dynamicFlowLayout As New FlowLayoutPanel

    Private Sub FormWithDataGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Build_dgSampleForm()
        FillAllFields()

        With dynamicFlowLayout
            .Location = New Point(1, 1)
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .FlowDirection = FlowDirection.LeftToRight
            .AutoScroll = True
        End With

        pnlGrid.Controls.Add(dynamicFlowLayout)

    End Sub

#Region "CUSTOM SUBS AND PROCS"


    Sub FillAllFields()

        'Dim rss As SqlDataReader
        'rs = clsOrder.GetListOforder()
        'Dim orderlists As String = ""

        'If rs.HasRows Then
        '    Do While rs.Read()
        '        With dgView.Rows(dgView.Rows.Add)
        '            .Cells("number").Value = rs!Order_ID
        '        End With
        '    Loop
        'End If

        'For Each row As DataGridViewRow In dgView.Rows
        '    orderlists = ""
        '    rss = clsOrder.GetListOforderdetails(row.Cells("number").Value)

        '    If rss.HasRows Then
        '        Do While rss.Read()
        '            orderlists += rss!Menu_Name & " - " & rss!Qty & vbNewLine
        '        Loop
        '    End If

        '    row.Cells("orders").Value = orderlists
        'Next

    End Sub

    Dim cRight As Integer = 1
    Dim control_panel As Integer = 0

    Private Sub Order_Lists()
        rs = clsOrder.GetListOforder()

    End Sub

    Public Sub AddOrders(ByVal Order_No As String, ByVal Order_Menu As String, ByRef Order_Qty As String)

        Dim Panel As New Panel()
        Dim PanelUpper As New Panel()
        Dim PanelLower As New Panel()
        Dim lbl_OrderNo As New Label()
        Dim lbl_Orders As New Label()
        Dim BtnServed As New Button()
        Dim BtnReturn As New Button()

        With Panel
            .BorderStyle = BorderStyle.FixedSingle
            .Height = 300
            .Width = (dynamicFlowLayout.Width - (7 * 10)) / 7
            .Left = (Panel.Width)
            control_panel = control_panel + 1
        End With

        With PanelUpper
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Aqua
            .Height = (Panel.Height / 1.1) - 3
            .Width = Panel.Width
        End With

        With PanelLower
            .BackColor = Color.BurlyWood
            .Width = Panel.Width
            .Height = Panel.Height - (Panel.Height / 1.1)
            .Top = PanelUpper.Height
        End With

        dynamicFlowLayout.Controls.Add(Panel)

        With lbl_OrderNo
            .Top = 20
            .Left = 10
            .Text = Order_No
        End With

        With lbl_Orders
            .Top = lbl_OrderNo.Top + 20
            .Left = 10
            .Text = Order_Menu & " - " & Order_Qty
            .Width = 170
        End With

        With BtnServed
            .Height = PanelLower.Height
            .Width = (Panel.Width - 3) / 2
            .Text = "Served"
        End With

        With BtnReturn
            .Text = "Return"
            .Height = PanelLower.Height
            .Width = (Panel.Width - 3) / 2
            .Left = BtnReturn.Width + 1
        End With

        With Panel
            .Controls.Add(PanelUpper)
            .Controls.Add(PanelLower)
        End With

        With PanelUpper
            .Controls.Add(lbl_OrderNo)
            .Controls.Add(lbl_Orders)
        End With

        With PanelLower
            .Controls.Add(BtnServed)
            .Controls.Add(BtnReturn)
        End With

    End Sub

    Public Sub AddMenu()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
        AddOrders("Order No 1:", "Comuasddsaads B1", "11")
    End Sub



#End Region

End Class