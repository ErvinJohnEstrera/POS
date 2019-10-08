<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ScrollContainer = New System.Windows.Forms.Panel()
        Me.ScrollPanel = New System.Windows.Forms.Panel()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ScrollAt = New System.Windows.Forms.Panel()
        Me.ScrollContainer.SuspendLayout()
        Me.ScrollPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ScrollContainer
        '
        Me.ScrollContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ScrollContainer.Controls.Add(Me.ScrollPanel)
        Me.ScrollContainer.Controls.Add(Me.ScrollAt)
        Me.ScrollContainer.Location = New System.Drawing.Point(153, 52)
        Me.ScrollContainer.Name = "ScrollContainer"
        Me.ScrollContainer.Size = New System.Drawing.Size(352, 329)
        Me.ScrollContainer.TabIndex = 0
        '
        'ScrollPanel
        '
        Me.ScrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ScrollPanel.Controls.Add(Me.ComboBox4)
        Me.ScrollPanel.Controls.Add(Me.ComboBox3)
        Me.ScrollPanel.Controls.Add(Me.ComboBox2)
        Me.ScrollPanel.Controls.Add(Me.ComboBox1)
        Me.ScrollPanel.Location = New System.Drawing.Point(3, 3)
        Me.ScrollPanel.Name = "ScrollPanel"
        Me.ScrollPanel.Size = New System.Drawing.Size(325, 582)
        Me.ScrollPanel.TabIndex = 2
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(171, 197)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox4.TabIndex = 3
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(120, 249)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 2
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(54, 186)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(78, 135)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'ScrollAt
        '
        Me.ScrollAt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ScrollAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ScrollAt.Location = New System.Drawing.Point(339, 3)
        Me.ScrollAt.Name = "ScrollAt"
        Me.ScrollAt.Size = New System.Drawing.Size(10, 33)
        Me.ScrollAt.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 602)
        Me.Controls.Add(Me.ScrollContainer)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ScrollContainer.ResumeLayout(False)
        Me.ScrollPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ScrollContainer As Panel
    Friend WithEvents ScrollPanel As Panel
    Friend WithEvents ScrollAt As Panel
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
End Class
