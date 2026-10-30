<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFM
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFM))
      SplitContainer = New SplitContainer()
      lblPathLeft = New Label()
      cbDrvLeft = New ComboBox()
      lvLeft = New ListView()
      lblPathRight = New Label()
      cbDrvRight = New ComboBox()
      lvRight = New ListView()
      mnuFM = New MenuStrip()
      mnuFM_File = New ToolStripMenuItem()
      mnuFM_File_Exit = New ToolStripMenuItem()
      MnuFM_Tools = New ToolStripMenuItem()
      mnuFM_Settings = New ToolStripMenuItem()
      mnuFM_About = New ToolStripMenuItem()
      ToolStrip = New ToolStrip()
      ToolStripButton1 = New ToolStripButton()
      StatusStrip = New StatusStrip()
      tsStatusLabelInfo = New ToolStripStatusLabel()
      tsStatusLabelAppInfo = New ToolStripStatusLabel()
      CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
      SplitContainer.Panel1.SuspendLayout()
      SplitContainer.Panel2.SuspendLayout()
      SplitContainer.SuspendLayout()
      mnuFM.SuspendLayout()
      ToolStrip.SuspendLayout()
      StatusStrip.SuspendLayout()
      SuspendLayout()
      ' 
      ' SplitContainer
      ' 
      SplitContainer.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      SplitContainer.Location = New Point(0, 52)
      SplitContainer.Name = "SplitContainer"
      ' 
      ' SplitContainer.Panel1
      ' 
      SplitContainer.Panel1.Controls.Add(lblPathLeft)
      SplitContainer.Panel1.Controls.Add(cbDrvLeft)
      SplitContainer.Panel1.Controls.Add(lvLeft)
      ' 
      ' SplitContainer.Panel2
      ' 
      SplitContainer.Panel2.Controls.Add(lblPathRight)
      SplitContainer.Panel2.Controls.Add(cbDrvRight)
      SplitContainer.Panel2.Controls.Add(lvRight)
      SplitContainer.Size = New Size(1008, 524)
      SplitContainer.SplitterDistance = 492
      SplitContainer.TabIndex = 0
      ' 
      ' lblPathLeft
      ' 
      lblPathLeft.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lblPathLeft.Location = New Point(60, 2)
      lblPathLeft.Name = "lblPathLeft"
      lblPathLeft.Size = New Size(430, 23)
      lblPathLeft.TabIndex = 2
      lblPathLeft.TextAlign = ContentAlignment.MiddleLeft
      ' 
      ' cbDrvLeft
      ' 
      cbDrvLeft.FormattingEnabled = True
      cbDrvLeft.Location = New Point(2, 2)
      cbDrvLeft.Name = "cbDrvLeft"
      cbDrvLeft.Size = New Size(53, 23)
      cbDrvLeft.TabIndex = 1
      ' 
      ' lvLeft
      ' 
      lvLeft.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvLeft.FullRowSelect = True
      lvLeft.Location = New Point(0, 30)
      lvLeft.Name = "lvLeft"
      lvLeft.Size = New Size(492, 491)
      lvLeft.TabIndex = 0
      lvLeft.UseCompatibleStateImageBehavior = False
      lvLeft.View = View.Details
      ' 
      ' lblPathRight
      ' 
      lblPathRight.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      lblPathRight.Location = New Point(63, 3)
      lblPathRight.Name = "lblPathRight"
      lblPathRight.Size = New Size(430, 23)
      lblPathRight.TabIndex = 4
      lblPathRight.TextAlign = ContentAlignment.MiddleLeft
      ' 
      ' cbDrvRight
      ' 
      cbDrvRight.FormattingEnabled = True
      cbDrvRight.Location = New Point(5, 3)
      cbDrvRight.Name = "cbDrvRight"
      cbDrvRight.Size = New Size(53, 23)
      cbDrvRight.TabIndex = 3
      ' 
      ' lvRight
      ' 
      lvRight.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvRight.FullRowSelect = True
      lvRight.Location = New Point(0, 30)
      lvRight.Name = "lvRight"
      lvRight.Size = New Size(512, 491)
      lvRight.TabIndex = 1
      lvRight.UseCompatibleStateImageBehavior = False
      lvRight.View = View.Details
      ' 
      ' mnuFM
      ' 
      mnuFM.Items.AddRange(New ToolStripItem() {mnuFM_File, MnuFM_Tools, mnuFM_Settings, mnuFM_About})
      mnuFM.Location = New Point(0, 0)
      mnuFM.Name = "mnuFM"
      mnuFM.Size = New Size(1008, 24)
      mnuFM.TabIndex = 1
      mnuFM.Text = "MenuStrip1"
      ' 
      ' mnuFM_File
      ' 
      mnuFM_File.DropDownItems.AddRange(New ToolStripItem() {mnuFM_File_Exit})
      mnuFM_File.Name = "mnuFM_File"
      mnuFM_File.Size = New Size(37, 20)
      mnuFM_File.Text = "&File"
      ' 
      ' mnuFM_File_Exit
      ' 
      mnuFM_File_Exit.Name = "mnuFM_File_Exit"
      mnuFM_File_Exit.Size = New Size(92, 22)
      mnuFM_File_Exit.Text = "E&xit"
      ' 
      ' MnuFM_Tools
      ' 
      MnuFM_Tools.Name = "MnuFM_Tools"
      MnuFM_Tools.Size = New Size(47, 20)
      MnuFM_Tools.Text = "&Tools"
      ' 
      ' mnuFM_Settings
      ' 
      mnuFM_Settings.Name = "mnuFM_Settings"
      mnuFM_Settings.Size = New Size(61, 20)
      mnuFM_Settings.Text = "&Settings"
      ' 
      ' mnuFM_About
      ' 
      mnuFM_About.Name = "mnuFM_About"
      mnuFM_About.Size = New Size(52, 20)
      mnuFM_About.Text = "&About"
      ' 
      ' ToolStrip
      ' 
      ToolStrip.Items.AddRange(New ToolStripItem() {ToolStripButton1})
      ToolStrip.Location = New Point(0, 24)
      ToolStrip.Name = "ToolStrip"
      ToolStrip.Size = New Size(1008, 25)
      ToolStrip.TabIndex = 2
      ToolStrip.Text = "ToolStrip1"
      ' 
      ' ToolStripButton1
      ' 
      ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
      ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
      ToolStripButton1.ImageTransparentColor = Color.Magenta
      ToolStripButton1.Name = "ToolStripButton1"
      ToolStripButton1.Size = New Size(23, 22)
      ToolStripButton1.Text = "ToolStripButton1"
      ' 
      ' StatusStrip
      ' 
      StatusStrip.Items.AddRange(New ToolStripItem() {tsStatusLabelInfo, tsStatusLabelAppInfo})
      StatusStrip.Location = New Point(0, 579)
      StatusStrip.Name = "StatusStrip"
      StatusStrip.Size = New Size(1008, 22)
      StatusStrip.TabIndex = 3
      StatusStrip.Text = "StatusStrip1"
      ' 
      ' tsStatusLabelInfo
      ' 
      tsStatusLabelInfo.AccessibleRole = AccessibleRole.None
      tsStatusLabelInfo.Name = "tsStatusLabelInfo"
      tsStatusLabelInfo.Size = New Size(12, 17)
      tsStatusLabelInfo.Text = "x"
      ' 
      ' tsStatusLabelAppInfo
      ' 
      tsStatusLabelAppInfo.Name = "tsStatusLabelAppInfo"
      tsStatusLabelAppInfo.Size = New Size(0, 17)
      ' 
      ' frmFM
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(1008, 601)
      Controls.Add(StatusStrip)
      Controls.Add(ToolStrip)
      Controls.Add(SplitContainer)
      Controls.Add(mnuFM)
      MainMenuStrip = mnuFM
      Name = "frmFM"
      StartPosition = FormStartPosition.Manual
      Text = "FileManagerForm"
      SplitContainer.Panel1.ResumeLayout(False)
      SplitContainer.Panel2.ResumeLayout(False)
      CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
      SplitContainer.ResumeLayout(False)
      mnuFM.ResumeLayout(False)
      mnuFM.PerformLayout()
      ToolStrip.ResumeLayout(False)
      ToolStrip.PerformLayout()
      StatusStrip.ResumeLayout(False)
      StatusStrip.PerformLayout()
      ResumeLayout(False)
      PerformLayout()
   End Sub

   Friend WithEvents SplitContainer As SplitContainer
   Friend WithEvents lvLeft As ListView
   Friend WithEvents lvRight As ListView
   Friend WithEvents cbDrvLeft As ComboBox
   Friend WithEvents mnuFM As MenuStrip
   Friend WithEvents mnuFM_File As ToolStripMenuItem
   Friend WithEvents mnuFM_File_Exit As ToolStripMenuItem
   Friend WithEvents mnuFM_Settings As ToolStripMenuItem
   Friend WithEvents mnuFM_About As ToolStripMenuItem
   Friend WithEvents MnuFM_Tools As ToolStripMenuItem
   Friend WithEvents ToolStrip As ToolStrip
   Friend WithEvents ToolStripButton1 As ToolStripButton
   Friend WithEvents lblPathLeft As Label
   Friend WithEvents StatusStrip As StatusStrip
   Friend WithEvents tsStatusLabelInfo As ToolStripStatusLabel
    Friend WithEvents lblPathRight As Label
    Friend WithEvents cbDrvRight As ComboBox
    Friend WithEvents tsStatusLabelAppInfo As ToolStripStatusLabel
End Class
