<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeliveryReceivingOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeliveryReceivingOrder))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSearchTrans = New System.Windows.Forms.Button()
        Me.dtpRO = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTransNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnReceiveOrder = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPaymentInfo = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAmountDue = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSalesTax = New System.Windows.Forms.TextBox()
        Me.txtPaymentDue = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.dgView = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnlPOH = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSuppNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSuppName = New System.Windows.Forms.TextBox()
        Me.txtPOPreparedBy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpExpectedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSearchPO = New System.Windows.Forms.Button()
        Me.dtpPostedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPaymentInfo.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPOH.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtRemarks)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.txtReceivedBy)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.btnSearchTrans)
        Me.pnlMain.Controls.Add(Me.dtpRO)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.txtTransNo)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.Label25)
        Me.pnlMain.Location = New System.Drawing.Point(3, 74)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(486, 196)
        Me.pnlMain.TabIndex = 34
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(120, 111)
        Me.txtRemarks.MaxLength = 1000
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(188, 71)
        Me.txtRemarks.TabIndex = 44
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 14)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Remarks :"
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceivedBy.Location = New System.Drawing.Point(120, 83)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.ReadOnly = True
        Me.txtReceivedBy.Size = New System.Drawing.Size(133, 22)
        Me.txtReceivedBy.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 14)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Received by :"
        '
        'btnSearchTrans
        '
        Me.btnSearchTrans.FlatAppearance.BorderSize = 0
        Me.btnSearchTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchTrans.Image = CType(resources.GetObject("btnSearchTrans.Image"), System.Drawing.Image)
        Me.btnSearchTrans.Location = New System.Drawing.Point(265, 27)
        Me.btnSearchTrans.Name = "btnSearchTrans"
        Me.btnSearchTrans.Size = New System.Drawing.Size(23, 25)
        Me.btnSearchTrans.TabIndex = 29
        Me.btnSearchTrans.UseVisualStyleBackColor = True
        '
        'dtpRO
        '
        Me.dtpRO.Enabled = False
        Me.dtpRO.Location = New System.Drawing.Point(120, 55)
        Me.dtpRO.Name = "dtpRO"
        Me.dtpRO.Size = New System.Drawing.Size(201, 22)
        Me.dtpRO.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Date :"
        '
        'txtTransNo
        '
        Me.txtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransNo.Location = New System.Drawing.Point(120, 27)
        Me.txtTransNo.MaxLength = 10
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.ReadOnly = True
        Me.txtTransNo.Size = New System.Drawing.Size(141, 22)
        Me.txtTransNo.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Receive Order No. :"
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label25.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(477, 14)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Header Informations"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(996, 70)
        Me.Panel4.TabIndex = 33
        Me.Panel4.Tag = "-10, 0"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Silver
        Me.Label27.Location = New System.Drawing.Point(90, 44)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(347, 13)
        Me.Label27.TabIndex = 17
        Me.Label27.Text = "This form caters all the ammendments occuring in posted Purchase Orders."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.LightGray
        Me.Label28.Location = New System.Drawing.Point(93, 9)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(242, 29)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "Module Name (Type)"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.LightGray
        Me.Label29.Location = New System.Drawing.Point(78, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(532, 41)
        Me.Label29.TabIndex = 16
        Me.Label29.Text = "____________________________________________________________________________"
        '
        'btnReceiveOrder
        '
        Me.btnReceiveOrder.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnReceiveOrder.FlatAppearance.BorderSize = 0
        Me.btnReceiveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceiveOrder.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiveOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnReceiveOrder.Image = CType(resources.GetObject("btnReceiveOrder.Image"), System.Drawing.Image)
        Me.btnReceiveOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReceiveOrder.Location = New System.Drawing.Point(853, -1)
        Me.btnReceiveOrder.Name = "btnReceiveOrder"
        Me.btnReceiveOrder.Size = New System.Drawing.Size(77, 69)
        Me.btnReceiveOrder.TabIndex = 11
        Me.btnReceiveOrder.Text = "Receive Order"
        Me.btnReceiveOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReceiveOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnReceiveOrder.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.btnPrint)
        Me.pnlButtons.Controls.Add(Me.btnReceiveOrder)
        Me.pnlButtons.Controls.Add(Me.btnAdd)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Location = New System.Drawing.Point(3, 489)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(989, 70)
        Me.pnlButtons.TabIndex = 35
        '
        'btnAdd
        '
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnAdd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(1, 1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(55, 69)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnDelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(175, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(55, 69)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(59, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(55, 69)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(117, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(55, 69)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pnlPaymentInfo)
        Me.Panel1.Controls.Add(Me.pnlGrid)
        Me.Panel1.Location = New System.Drawing.Point(3, 273)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 214)
        Me.Panel1.TabIndex = 36
        '
        'pnlPaymentInfo
        '
        Me.pnlPaymentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPaymentInfo.Controls.Add(Me.Label19)
        Me.pnlPaymentInfo.Controls.Add(Me.txtTotalItems)
        Me.pnlPaymentInfo.Controls.Add(Me.Label18)
        Me.pnlPaymentInfo.Controls.Add(Me.Label17)
        Me.pnlPaymentInfo.Controls.Add(Me.txtAmountDue)
        Me.pnlPaymentInfo.Controls.Add(Me.Label16)
        Me.pnlPaymentInfo.Controls.Add(Me.txtSubTotal)
        Me.pnlPaymentInfo.Controls.Add(Me.Label15)
        Me.pnlPaymentInfo.Controls.Add(Me.txtSalesTax)
        Me.pnlPaymentInfo.Controls.Add(Me.txtPaymentDue)
        Me.pnlPaymentInfo.Controls.Add(Me.Label14)
        Me.pnlPaymentInfo.Controls.Add(Me.Label13)
        Me.pnlPaymentInfo.Controls.Add(Me.txtGrandTotal)
        Me.pnlPaymentInfo.Location = New System.Drawing.Point(743, 3)
        Me.pnlPaymentInfo.Name = "pnlPaymentInfo"
        Me.pnlPaymentInfo.Size = New System.Drawing.Size(241, 206)
        Me.pnlPaymentInfo.TabIndex = 45
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(239, 14)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Payment Information"
        '
        'txtTotalItems
        '
        Me.txtTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalItems.Location = New System.Drawing.Point(103, 25)
        Me.txtTotalItems.MaxLength = 10
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.ReadOnly = True
        Me.txtTotalItems.Size = New System.Drawing.Size(133, 22)
        Me.txtTotalItems.TabIndex = 54
        Me.txtTotalItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 14)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Total Items :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 14)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Amount Due :"
        '
        'txtAmountDue
        '
        Me.txtAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmountDue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmountDue.Location = New System.Drawing.Point(103, 109)
        Me.txtAmountDue.MaxLength = 10
        Me.txtAmountDue.Name = "txtAmountDue"
        Me.txtAmountDue.Size = New System.Drawing.Size(133, 22)
        Me.txtAmountDue.TabIndex = 51
        Me.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 14)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Sub-Total :"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubTotal.Location = New System.Drawing.Point(103, 53)
        Me.txtSubTotal.MaxLength = 10
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(133, 22)
        Me.txtSubTotal.TabIndex = 49
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 14)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Sales Tax :"
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTax.Location = New System.Drawing.Point(103, 81)
        Me.txtSalesTax.MaxLength = 10
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.ReadOnly = True
        Me.txtSalesTax.Size = New System.Drawing.Size(133, 22)
        Me.txtSalesTax.TabIndex = 47
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaymentDue
        '
        Me.txtPaymentDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentDue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentDue.Location = New System.Drawing.Point(95, 137)
        Me.txtPaymentDue.MaxLength = 10
        Me.txtPaymentDue.Name = "txtPaymentDue"
        Me.txtPaymentDue.ReadOnly = True
        Me.txtPaymentDue.Size = New System.Drawing.Size(141, 22)
        Me.txtPaymentDue.TabIndex = 45
        Me.txtPaymentDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 14)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Payment Due : "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 170)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Grand Total :"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotal.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(95, 165)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(141, 26)
        Me.txtGrandTotal.TabIndex = 44
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlGrid
        '
        Me.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGrid.Controls.Add(Me.dgView)
        Me.pnlGrid.Controls.Add(Me.Label5)
        Me.pnlGrid.Location = New System.Drawing.Point(3, 3)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(737, 206)
        Me.pnlGrid.TabIndex = 38
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.AllowUserToDeleteRows = False
        Me.dgView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Location = New System.Drawing.Point(3, 20)
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgView.Size = New System.Drawing.Size(729, 181)
        Me.dgView.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label5.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(728, 14)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "List of Purchase Items"
        '
        'PnlPOH
        '
        Me.PnlPOH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlPOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPOH.Controls.Add(Me.Label12)
        Me.PnlPOH.Controls.Add(Me.txtSuppNo)
        Me.PnlPOH.Controls.Add(Me.Label11)
        Me.PnlPOH.Controls.Add(Me.txtSuppName)
        Me.PnlPOH.Controls.Add(Me.txtPOPreparedBy)
        Me.PnlPOH.Controls.Add(Me.Label1)
        Me.PnlPOH.Controls.Add(Me.dtpExpectedDate)
        Me.PnlPOH.Controls.Add(Me.Label10)
        Me.PnlPOH.Controls.Add(Me.btnSearchPO)
        Me.PnlPOH.Controls.Add(Me.dtpPostedDate)
        Me.PnlPOH.Controls.Add(Me.Label2)
        Me.PnlPOH.Controls.Add(Me.txtPONo)
        Me.PnlPOH.Controls.Add(Me.Label3)
        Me.PnlPOH.Controls.Add(Me.Label4)
        Me.PnlPOH.Location = New System.Drawing.Point(495, 74)
        Me.PnlPOH.Name = "PnlPOH"
        Me.PnlPOH.Size = New System.Drawing.Size(497, 196)
        Me.PnlPOH.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Supplier No :"
        '
        'txtSuppNo
        '
        Me.txtSuppNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuppNo.Location = New System.Drawing.Point(149, 111)
        Me.txtSuppNo.Name = "txtSuppNo"
        Me.txtSuppNo.ReadOnly = True
        Me.txtSuppNo.Size = New System.Drawing.Size(125, 22)
        Me.txtSuppNo.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 14)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Company Name :"
        '
        'txtSuppName
        '
        Me.txtSuppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuppName.Location = New System.Drawing.Point(149, 139)
        Me.txtSuppName.Name = "txtSuppName"
        Me.txtSuppName.ReadOnly = True
        Me.txtSuppName.Size = New System.Drawing.Size(181, 22)
        Me.txtSuppName.TabIndex = 45
        '
        'txtPOPreparedBy
        '
        Me.txtPOPreparedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOPreparedBy.Location = New System.Drawing.Point(149, 167)
        Me.txtPOPreparedBy.Name = "txtPOPreparedBy"
        Me.txtPOPreparedBy.ReadOnly = True
        Me.txtPOPreparedBy.Size = New System.Drawing.Size(181, 22)
        Me.txtPOPreparedBy.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 14)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Prepared by :"
        '
        'dtpExpectedDate
        '
        Me.dtpExpectedDate.Enabled = False
        Me.dtpExpectedDate.Location = New System.Drawing.Point(149, 83)
        Me.dtpExpectedDate.Name = "dtpExpectedDate"
        Me.dtpExpectedDate.Size = New System.Drawing.Size(201, 22)
        Me.dtpExpectedDate.TabIndex = 36
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 14)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Expected Arrival Date :"
        '
        'btnSearchPO
        '
        Me.btnSearchPO.FlatAppearance.BorderSize = 0
        Me.btnSearchPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchPO.Image = CType(resources.GetObject("btnSearchPO.Image"), System.Drawing.Image)
        Me.btnSearchPO.Location = New System.Drawing.Point(294, 27)
        Me.btnSearchPO.Name = "btnSearchPO"
        Me.btnSearchPO.Size = New System.Drawing.Size(23, 25)
        Me.btnSearchPO.TabIndex = 29
        Me.btnSearchPO.UseVisualStyleBackColor = True
        '
        'dtpPostedDate
        '
        Me.dtpPostedDate.Enabled = False
        Me.dtpPostedDate.Location = New System.Drawing.Point(149, 55)
        Me.dtpPostedDate.Name = "dtpPostedDate"
        Me.dtpPostedDate.Size = New System.Drawing.Size(201, 22)
        Me.dtpPostedDate.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Posted Date :"
        '
        'txtPONo
        '
        Me.txtPONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPONo.Location = New System.Drawing.Point(149, 27)
        Me.txtPONo.MaxLength = 10
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(141, 22)
        Me.txtPONo.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 14)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Purchase Order No. :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(488, 14)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Purchaser Order Header Informations"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(933, -1)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(55, 69)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmDeliveryReceivingOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 561)
        Me.Controls.Add(Me.PnlPOH)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmDeliveryReceivingOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Receiving Order"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlPaymentInfo.ResumeLayout(False)
        Me.pnlPaymentInfo.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPOH.ResumeLayout(False)
        Me.PnlPOH.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnSearchTrans As System.Windows.Forms.Button
    Friend WithEvents dtpRO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnReceiveOrder As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlGrid As Panel
    Friend WithEvents dgView As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlPaymentInfo As Panel
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PnlPOH As Panel
    Friend WithEvents btnSearchPO As Button
    Friend WithEvents dtpPostedDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPONo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPaymentDue As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtAmountDue As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtSalesTax As TextBox
    Friend WithEvents txtTotalItems As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtReceivedBy As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpExpectedDate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPOPreparedBy As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSuppName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSuppNo As TextBox
    Friend WithEvents btnPrint As Button
End Class
