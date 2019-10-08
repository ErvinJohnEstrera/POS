<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchaseOrder))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTransNo = New System.Windows.Forms.TextBox()
        Me.btnSearchTrans = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnCancelTransaction = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.panelGrid = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.dgView = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearchSuppNo = New System.Windows.Forms.Button()
        Me.txtCompName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSupplierNo = New System.Windows.Forms.TextBox()
        Me.txtCancelledBy = New System.Windows.Forms.TextBox()
        Me.lblCancelledBy = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtPostedBy = New System.Windows.Forms.TextBox()
        Me.LblPostedBy = New System.Windows.Forms.Label()
        Me.txtPreparedby = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.panelGrid.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.dtpDate)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.txtTransNo)
        Me.pnlMain.Controls.Add(Me.btnSearchTrans)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.Label25)
        Me.pnlMain.Controls.Add(Me.lblStatus)
        Me.pnlMain.Controls.Add(Me.Label10)
        Me.pnlMain.Location = New System.Drawing.Point(3, 74)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(667, 61)
        Me.pnlMain.TabIndex = 34
        '
        'dtpDate
        '
        Me.dtpDate.Enabled = False
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(326, 25)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(139, 22)
        Me.dtpDate.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(274, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Date :"
        '
        'txtTransNo
        '
        Me.txtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransNo.Location = New System.Drawing.Point(115, 28)
        Me.txtTransNo.MaxLength = 10
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.ReadOnly = True
        Me.txtTransNo.Size = New System.Drawing.Size(101, 22)
        Me.txtTransNo.TabIndex = 25
        '
        'btnSearchTrans
        '
        Me.btnSearchTrans.FlatAppearance.BorderSize = 0
        Me.btnSearchTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchTrans.Image = CType(resources.GetObject("btnSearchTrans.Image"), System.Drawing.Image)
        Me.btnSearchTrans.Location = New System.Drawing.Point(222, 26)
        Me.btnSearchTrans.Name = "btnSearchTrans"
        Me.btnSearchTrans.Size = New System.Drawing.Size(23, 25)
        Me.btnSearchTrans.TabIndex = 29
        Me.btnSearchTrans.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Transaction No. :"
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label25.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(658, 14)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Header Informations"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(531, 28)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(131, 15)
        Me.lblStatus.TabIndex = 21
        Me.lblStatus.Text = " -- --"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 14)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Status :"
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
        Me.Panel4.Size = New System.Drawing.Size(674, 70)
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
        Me.Label28.Size = New System.Drawing.Size(260, 29)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "Purchase Order (Type)"
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
        'btnPrint
        '
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(500, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(55, 71)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPost.FlatAppearance.BorderSize = 0
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPost.Image = CType(resources.GetObject("btnPost.Image"), System.Drawing.Image)
        Me.btnPost.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPost.Location = New System.Drawing.Point(555, 0)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(55, 71)
        Me.btnPost.TabIndex = 11
        Me.btnPost.Text = "Post"
        Me.btnPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnCancelTransaction
        '
        Me.btnCancelTransaction.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelTransaction.FlatAppearance.BorderSize = 0
        Me.btnCancelTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelTransaction.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelTransaction.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelTransaction.Image = CType(resources.GetObject("btnCancelTransaction.Image"), System.Drawing.Image)
        Me.btnCancelTransaction.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelTransaction.Location = New System.Drawing.Point(610, 0)
        Me.btnCancelTransaction.Name = "btnCancelTransaction"
        Me.btnCancelTransaction.Size = New System.Drawing.Size(55, 71)
        Me.btnCancelTransaction.TabIndex = 10
        Me.btnCancelTransaction.Text = "Cancel"
        Me.btnCancelTransaction.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancelTransaction.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.btnPrint)
        Me.pnlButtons.Controls.Add(Me.btnPost)
        Me.pnlButtons.Controls.Add(Me.btnCancelTransaction)
        Me.pnlButtons.Controls.Add(Me.btnAdd)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Location = New System.Drawing.Point(3, 519)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(667, 73)
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
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(233, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 69)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlBody
        '
        Me.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBody.Controls.Add(Me.panelGrid)
        Me.pnlBody.Controls.Add(Me.Label2)
        Me.pnlBody.Controls.Add(Me.btnSearchSuppNo)
        Me.pnlBody.Controls.Add(Me.txtCompName)
        Me.pnlBody.Controls.Add(Me.Label1)
        Me.pnlBody.Controls.Add(Me.txtSupplierNo)
        Me.pnlBody.Controls.Add(Me.txtCancelledBy)
        Me.pnlBody.Controls.Add(Me.lblCancelledBy)
        Me.pnlBody.Controls.Add(Me.txtRemarks)
        Me.pnlBody.Controls.Add(Me.txtPostedBy)
        Me.pnlBody.Controls.Add(Me.LblPostedBy)
        Me.pnlBody.Controls.Add(Me.txtPreparedby)
        Me.pnlBody.Controls.Add(Me.Label9)
        Me.pnlBody.Controls.Add(Me.Label8)
        Me.pnlBody.Location = New System.Drawing.Point(3, 141)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(667, 374)
        Me.pnlBody.TabIndex = 36
        '
        'panelGrid
        '
        Me.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelGrid.Controls.Add(Me.Button1)
        Me.panelGrid.Controls.Add(Me.btnAddProduct)
        Me.panelGrid.Controls.Add(Me.dgView)
        Me.panelGrid.Controls.Add(Me.Label3)
        Me.panelGrid.Location = New System.Drawing.Point(3, 134)
        Me.panelGrid.Name = "panelGrid"
        Me.panelGrid.Size = New System.Drawing.Size(659, 206)
        Me.panelGrid.TabIndex = 57
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(78, 179)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Remove Product"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Location = New System.Drawing.Point(2, 179)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(75, 23)
        Me.btnAddProduct.TabIndex = 24
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.AllowUserToDeleteRows = False
        Me.dgView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Location = New System.Drawing.Point(3, 20)
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgView.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgView.Size = New System.Drawing.Size(651, 157)
        Me.dgView.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(650, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "List of Products"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 14)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Company Name* :"
        '
        'btnSearchSuppNo
        '
        Me.btnSearchSuppNo.FlatAppearance.BorderSize = 0
        Me.btnSearchSuppNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSuppNo.Image = CType(resources.GetObject("btnSearchSuppNo.Image"), System.Drawing.Image)
        Me.btnSearchSuppNo.Location = New System.Drawing.Point(244, 8)
        Me.btnSearchSuppNo.Name = "btnSearchSuppNo"
        Me.btnSearchSuppNo.Size = New System.Drawing.Size(21, 22)
        Me.btnSearchSuppNo.TabIndex = 55
        Me.btnSearchSuppNo.UseVisualStyleBackColor = True
        '
        'txtCompName
        '
        Me.txtCompName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompName.Location = New System.Drawing.Point(115, 36)
        Me.txtCompName.MaxLength = 10
        Me.txtCompName.Name = "txtCompName"
        Me.txtCompName.ReadOnly = True
        Me.txtCompName.Size = New System.Drawing.Size(219, 22)
        Me.txtCompName.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 14)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Supplier No.* :"
        '
        'txtSupplierNo
        '
        Me.txtSupplierNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSupplierNo.Location = New System.Drawing.Point(115, 8)
        Me.txtSupplierNo.MaxLength = 10
        Me.txtSupplierNo.Name = "txtSupplierNo"
        Me.txtSupplierNo.ReadOnly = True
        Me.txtSupplierNo.Size = New System.Drawing.Size(123, 22)
        Me.txtSupplierNo.TabIndex = 52
        '
        'txtCancelledBy
        '
        Me.txtCancelledBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCancelledBy.Location = New System.Drawing.Point(529, 347)
        Me.txtCancelledBy.Name = "txtCancelledBy"
        Me.txtCancelledBy.ReadOnly = True
        Me.txtCancelledBy.Size = New System.Drawing.Size(133, 22)
        Me.txtCancelledBy.TabIndex = 50
        '
        'lblCancelledBy
        '
        Me.lblCancelledBy.AutoSize = True
        Me.lblCancelledBy.Location = New System.Drawing.Point(453, 350)
        Me.lblCancelledBy.Name = "lblCancelledBy"
        Me.lblCancelledBy.Size = New System.Drawing.Size(76, 14)
        Me.lblCancelledBy.TabIndex = 51
        Me.lblCancelledBy.Text = "Cancelled By :"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(115, 64)
        Me.txtRemarks.MaxLength = 1000
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(547, 64)
        Me.txtRemarks.TabIndex = 48
        '
        'txtPostedBy
        '
        Me.txtPostedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPostedBy.Location = New System.Drawing.Point(297, 347)
        Me.txtPostedBy.Name = "txtPostedBy"
        Me.txtPostedBy.ReadOnly = True
        Me.txtPostedBy.Size = New System.Drawing.Size(133, 22)
        Me.txtPostedBy.TabIndex = 46
        '
        'LblPostedBy
        '
        Me.LblPostedBy.AutoSize = True
        Me.LblPostedBy.Location = New System.Drawing.Point(234, 350)
        Me.LblPostedBy.Name = "LblPostedBy"
        Me.LblPostedBy.Size = New System.Drawing.Size(62, 14)
        Me.LblPostedBy.TabIndex = 49
        Me.LblPostedBy.Text = "Posted By :"
        '
        'txtPreparedby
        '
        Me.txtPreparedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPreparedby.Location = New System.Drawing.Point(77, 346)
        Me.txtPreparedby.Name = "txtPreparedby"
        Me.txtPreparedby.ReadOnly = True
        Me.txtPreparedby.Size = New System.Drawing.Size(133, 22)
        Me.txtPreparedby.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 349)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 14)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Prepared by :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 14)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Remarks :"
        '
        'frmPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 594)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        Me.panelGrid.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnSearchTrans As System.Windows.Forms.Button
    Friend WithEvents txtTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnCancelTransaction As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents panelGrid As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents dgView As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSearchSuppNo As Button
    Friend WithEvents txtCompName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSupplierNo As TextBox
    Friend WithEvents txtCancelledBy As TextBox
    Friend WithEvents lblCancelledBy As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents txtPostedBy As TextBox
    Friend WithEvents LblPostedBy As Label
    Friend WithEvents txtPreparedby As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
End Class
