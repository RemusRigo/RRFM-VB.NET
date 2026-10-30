<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyMove
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
      pnlBorder = New Panel()
      btnPause = New Button()
      btnCancel = New Button()
      Panel1 = New Panel()
      pnlSize = New Panel()
      lblTotalSize = New Label()
      lblTotalItems = New Label()
      pnlItems = New Panel()
      pnlBorder.SuspendLayout()
      Panel1.SuspendLayout()
      SuspendLayout()
      ' 
      ' pnlBorder
      ' 
      pnlBorder.BorderStyle = BorderStyle.FixedSingle
      pnlBorder.Controls.Add(btnPause)
      pnlBorder.Controls.Add(btnCancel)
      pnlBorder.Controls.Add(Panel1)
      pnlBorder.Dock = DockStyle.Fill
      pnlBorder.Location = New Point(0, 0)
      pnlBorder.Name = "pnlBorder"
      pnlBorder.Size = New Size(784, 159)
      pnlBorder.TabIndex = 0
      ' 
      ' btnPause
      ' 
      btnPause.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnPause.Location = New Point(633, 131)
      btnPause.Name = "btnPause"
      btnPause.Size = New Size(70, 23)
      btnPause.TabIndex = 8
      btnPause.Text = "&Pause"
      btnPause.UseVisualStyleBackColor = True
      ' 
      ' btnCancel
      ' 
      btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
      btnCancel.Location = New Point(709, 131)
      btnCancel.Name = "btnCancel"
      btnCancel.Size = New Size(70, 23)
      btnCancel.TabIndex = 7
      btnCancel.Text = "&Cancel"
      btnCancel.UseVisualStyleBackColor = True
      ' 
      ' Panel1
      ' 
      Panel1.Controls.Add(pnlSize)
      Panel1.Controls.Add(lblTotalSize)
      Panel1.Controls.Add(lblTotalItems)
      Panel1.Controls.Add(pnlItems)
      Panel1.Location = New Point(3, 3)
      Panel1.Name = "Panel1"
      Panel1.Size = New Size(776, 120)
      Panel1.TabIndex = 6
      ' 
      ' pnlSize
      ' 
      pnlSize.BorderStyle = BorderStyle.FixedSingle
      pnlSize.Location = New Point(3, 3)
      pnlSize.Name = "pnlSize"
      pnlSize.Size = New Size(770, 30)
      pnlSize.TabIndex = 7
      ' 
      ' lblTotalSize
      ' 
      lblTotalSize.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lblTotalSize.BorderStyle = BorderStyle.FixedSingle
      lblTotalSize.Location = New Point(4, 36)
      lblTotalSize.Name = "lblTotalSize"
      lblTotalSize.Size = New Size(770, 20)
      lblTotalSize.TabIndex = 5
      lblTotalSize.Text = "Total Size"
      ' 
      ' lblTotalItems
      ' 
      lblTotalItems.BorderStyle = BorderStyle.FixedSingle
      lblTotalItems.Location = New Point(4, 94)
      lblTotalItems.Name = "lblTotalItems"
      lblTotalItems.Size = New Size(770, 20)
      lblTotalItems.TabIndex = 6
      lblTotalItems.Text = "Total Files"
      ' 
      ' pnlItems
      ' 
      pnlItems.BorderStyle = BorderStyle.FixedSingle
      pnlItems.Location = New Point(4, 60)
      pnlItems.Name = "pnlItems"
      pnlItems.Size = New Size(770, 30)
      pnlItems.TabIndex = 8
      ' 
      ' frmCopyMove
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(784, 159)
      ControlBox = False
      Controls.Add(pnlBorder)
      Name = "frmCopyMove"
      StartPosition = FormStartPosition.CenterParent
      Text = "Copy/Move"
      pnlBorder.ResumeLayout(False)
      Panel1.ResumeLayout(False)
      ResumeLayout(False)
   End Sub

   Friend WithEvents pnlBorder As Panel
   Friend WithEvents pnlItems As Panel
   Friend WithEvents lblTotalSize As Label
   Friend WithEvents pnlSize As Panel
   Friend WithEvents lblTotalItems As Label
   Friend WithEvents Panel1 As Panel
   Friend WithEvents btnCancel As Button
   Friend WithEvents btnPause As Button
End Class
