<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItems))
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.btnSearchTransNo = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.txtItemsNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStartQty = New System.Windows.Forms.TextBox()
        Me.cbxUOM = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSafetyStock = New System.Windows.Forms.TextBox()
        Me.txtReOrderLvl = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxCat = New System.Windows.Forms.ComboBox()
        Me.Lbl = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblHeader
        '
        Me.LblHeader.AutoSize = True
        Me.LblHeader.BackColor = System.Drawing.Color.Transparent
        Me.LblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.LightGray
        Me.LblHeader.Location = New System.Drawing.Point(97, 7)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(150, 29)
        Me.LblHeader.TabIndex = 15
        Me.LblHeader.Text = "Items (Form)"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Silver
        Me.Label47.Location = New System.Drawing.Point(92, 41)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(124, 13)
        Me.Label47.TabIndex = 18
        Me.Label47.Text = "Description of the module"
        '
        'btnSearchTransNo
        '
        Me.btnSearchTransNo.FlatAppearance.BorderSize = 0
        Me.btnSearchTransNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchTransNo.Image = CType(resources.GetObject("btnSearchTransNo.Image"), System.Drawing.Image)
        Me.btnSearchTransNo.Location = New System.Drawing.Point(187, 24)
        Me.btnSearchTransNo.Name = "btnSearchTransNo"
        Me.btnSearchTransNo.Size = New System.Drawing.Size(23, 23)
        Me.btnSearchTransNo.TabIndex = 2
        Me.btnSearchTransNo.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Silver
        Me.Label37.Location = New System.Drawing.Point(88, 40)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(0, 13)
        Me.Label37.TabIndex = 17
        Me.Label37.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.Label37)
        Me.Panel2.Controls.Add(Me.LblHeader)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(682, 65)
        Me.Panel2.TabIndex = 77
        Me.Panel2.Tag = "-10, 0"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.LightGray
        Me.Label39.Location = New System.Drawing.Point(77, 15)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(578, 38)
        Me.Label39.TabIndex = 16
        Me.Label39.Text = "____________________________________________________________________________"
        '
        'Label36
        '
        Me.Label36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label36.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(3, 2)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(660, 14)
        Me.Label36.TabIndex = 59
        Me.Label36.Text = "Header Information"
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.btnSearchTransNo)
        Me.pnlHeader.Controls.Add(Me.Label36)
        Me.pnlHeader.Controls.Add(Me.txtItemsNo)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(668, 57)
        Me.pnlHeader.TabIndex = 9
        '
        'txtItemsNo
        '
        Me.txtItemsNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemsNo.Location = New System.Drawing.Point(68, 25)
        Me.txtItemsNo.MaxLength = 13
        Me.txtItemsNo.Name = "txtItemsNo"
        Me.txtItemsNo.Size = New System.Drawing.Size(118, 22)
        Me.txtItemsNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item No. :"
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.btnAdd)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Location = New System.Drawing.Point(3, 356)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(676, 71)
        Me.pnlButtons.TabIndex = 79
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
        Me.btnAdd.Size = New System.Drawing.Size(55, 68)
        Me.btnAdd.TabIndex = 11
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
        Me.btnDelete.Size = New System.Drawing.Size(55, 68)
        Me.btnDelete.TabIndex = 14
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
        Me.btnEdit.Size = New System.Drawing.Size(55, 68)
        Me.btnEdit.TabIndex = 12
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
        Me.btnCancel.Size = New System.Drawing.Size(55, 68)
        Me.btnCancel.TabIndex = 13
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
        Me.btnSave.Size = New System.Drawing.Size(55, 68)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(660, 14)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Request Information"
        '
        'pnlBody
        '
        Me.pnlBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBody.Controls.Add(Me.Label11)
        Me.pnlBody.Controls.Add(Me.Label10)
        Me.pnlBody.Controls.Add(Me.txtStartQty)
        Me.pnlBody.Controls.Add(Me.cbxUOM)
        Me.pnlBody.Controls.Add(Me.Label9)
        Me.pnlBody.Controls.Add(Me.txtSafetyStock)
        Me.pnlBody.Controls.Add(Me.txtReOrderLvl)
        Me.pnlBody.Controls.Add(Me.Label8)
        Me.pnlBody.Controls.Add(Me.txtUnitPrice)
        Me.pnlBody.Controls.Add(Me.Label5)
        Me.pnlBody.Controls.Add(Me.Label4)
        Me.pnlBody.Controls.Add(Me.Label2)
        Me.pnlBody.Controls.Add(Me.cbxCat)
        Me.pnlBody.Controls.Add(Me.Label7)
        Me.pnlBody.Controls.Add(Me.Lbl)
        Me.pnlBody.Controls.Add(Me.txtItemName)
        Me.pnlBody.Location = New System.Drawing.Point(3, 66)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(668, 213)
        Me.pnlBody.TabIndex = 73
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(547, 193)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 14)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "(*) Indicates Required"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(34, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 14)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Starting Qty* :"
        '
        'txtStartQty
        '
        Me.txtStartQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStartQty.Location = New System.Drawing.Point(37, 166)
        Me.txtStartQty.MaxLength = 10
        Me.txtStartQty.Name = "txtStartQty"
        Me.txtStartQty.Size = New System.Drawing.Size(264, 22)
        Me.txtStartQty.TabIndex = 6
        '
        'cbxUOM
        '
        Me.cbxUOM.FormattingEnabled = True
        Me.cbxUOM.Location = New System.Drawing.Point(37, 124)
        Me.cbxUOM.Name = "cbxUOM"
        Me.cbxUOM.Size = New System.Drawing.Size(264, 22)
        Me.cbxUOM.TabIndex = 5
        Me.cbxUOM.Text = "Select Unit of Measurement"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(344, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 14)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Safety Stock* :"
        '
        'txtSafetyStock
        '
        Me.txtSafetyStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSafetyStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSafetyStock.Location = New System.Drawing.Point(347, 82)
        Me.txtSafetyStock.MaxLength = 10
        Me.txtSafetyStock.Name = "txtSafetyStock"
        Me.txtSafetyStock.Size = New System.Drawing.Size(264, 22)
        Me.txtSafetyStock.TabIndex = 9
        '
        'txtReOrderLvl
        '
        Me.txtReOrderLvl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReOrderLvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReOrderLvl.Location = New System.Drawing.Point(347, 124)
        Me.txtReOrderLvl.MaxLength = 10
        Me.txtReOrderLvl.Name = "txtReOrderLvl"
        Me.txtReOrderLvl.Size = New System.Drawing.Size(264, 22)
        Me.txtReOrderLvl.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(344, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 14)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Re-Order Level* :"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitPrice.Location = New System.Drawing.Point(347, 39)
        Me.txtUnitPrice.MaxLength = 10
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(264, 22)
        Me.txtUnitPrice.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(344, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Unit Price* :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 14)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Unit of Measurement* :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Category* :"
        '
        'cbxCat
        '
        Me.cbxCat.FormattingEnabled = True
        Me.cbxCat.Location = New System.Drawing.Point(37, 82)
        Me.cbxCat.Name = "cbxCat"
        Me.cbxCat.Size = New System.Drawing.Size(264, 22)
        Me.cbxCat.TabIndex = 4
        Me.cbxCat.Text = "Select Category"
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Location = New System.Drawing.Point(34, 22)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(75, 14)
        Me.Lbl.TabIndex = 69
        Me.Lbl.Text = "Item Name* :"
        '
        'txtItemName
        '
        Me.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(37, 40)
        Me.txtItemName.MaxLength = 45
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(264, 22)
        Me.txtItemName.TabIndex = 3
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.pnlBody)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Location = New System.Drawing.Point(3, 69)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(676, 284)
        Me.pnlMain.TabIndex = 78
        '
        'frmItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 430)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Items"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblHeader As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents btnSearchTransNo As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents txtItemsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents Lbl As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Private WithEvents Label9 As Label
    Friend WithEvents txtSafetyStock As TextBox
    Friend WithEvents txtReOrderLvl As TextBox
    Private WithEvents Label8 As Label
    Friend WithEvents txtUnitPrice As TextBox
    Private WithEvents Label5 As Label
    Private WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxCat As ComboBox
    Friend WithEvents cbxUOM As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtStartQty As TextBox
    Friend WithEvents Label11 As Label
End Class
