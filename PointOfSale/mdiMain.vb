Imports System.Windows.Forms

Public Class mdiMain


    Private Sub mnuFormWithDataGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormWithDataGrid.Click
        frmUserRole.MdiParent = Me
        frmUserRole.Show()
    End Sub

    Private Sub mnuFormWithNoDataGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCustomer.MdiParent = Me
        frmCustomer.Show()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.MdiParent = Me
        frmCategory.Show()
    End Sub

    Private Sub UnitOfMeasurementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnitOfMeasurementToolStripMenuItem.Click
        frmUOM.MdiParent = Me
        frmUOM.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        frmCustomer.MdiParent = Me
        frmCustomer.Show()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        frmEmployee.MdiParent = Me
        frmEmployee.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        frmSupplier.MdiParent = Me
        frmSupplier.Show()
    End Sub

    Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsToolStripMenuItem.Click
        frmItems.MdiParent = Me
        frmItems.Show()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.MdiParent = Me
        frmLogs.Show()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem.Click
        frmPurchaseOrder.MdiParent = Me
        frmPurchaseOrder.Show()
    End Sub

    Private Sub DeliveryReceiveingOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveryReceiveingOrderToolStripMenuItem.Click
        frmDeliveryReceivingOrder.MdiParent = Me
        frmDeliveryReceivingOrder.Show()
    End Sub

    Private Sub RequestRawMaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestRawMaterialToolStripMenuItem.Click
        frmRequestRawMaterial.MdiParent = Me
        frmRequestRawMaterial.Show()
    End Sub

    Private Sub ValueAddedTaxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValueAddedTaxToolStripMenuItem.Click
        frmVat.MdiParent = Me
        frmVat.Show()
    End Sub

    Private Sub mdiMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemsToolStripMenuItem.Click
        frmMenuItems.MdiParent = Me
        frmMenuItems.Show()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        frmMenu.MdiParent = Me
        frmMenu.Show()
    End Sub

    Private Sub TableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem.Click
        frmTable.MdiParent = Me
        frmTable.Show()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        'frmOrder.MdiParent = Me
        frmOrder.Show()
    End Sub

    Private Sub DiscountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscountToolStripMenuItem.Click
        frmDiscount.MdiParent = Me
        frmDiscount.Show()
    End Sub

    Private Sub BookingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookingToolStripMenuItem.Click
        frmBooking.MdiParent = Me
        frmBooking.Show()
    End Sub

    Private Sub ListsOfOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListsOfOrdersToolStripMenuItem.Click
        frmOrderLists.Show()
    End Sub

    Private Sub TestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestingToolStripMenuItem.Click
        Form1.Show()
    End Sub
End Class
