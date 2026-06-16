<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUMF
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(disposing As Boolean)
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      components = New ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUMF))
      SplitContainer = New SplitContainer()
      btnOpenFile = New Button()
      imgListButtons = New ImageList(components)
      txtBoxInput = New TextBox()
      txtBoxFromFile = New TextBox()
      rbtnFromText = New RadioButton()
      rbtnFromFile = New RadioButton()
      grpBoxFiles = New GroupBox()
      grpBoxSearch = New GroupBox()
      lblPath = New Label()
      lblFile = New Label()
      TextBox2 = New TextBox()
      TextBox1 = New TextBox()
      Button1 = New Button()
      btnSearch = New Button()
      chkBoxRecursive = New CheckBox()
      CType(SplitContainer, ComponentModel.ISupportInitialize).BeginInit()
      SplitContainer.Panel1.SuspendLayout()
      SplitContainer.Panel2.SuspendLayout()
      SplitContainer.SuspendLayout()
      grpBoxSearch.SuspendLayout()
      SuspendLayout()
      ' 
      ' SplitContainer
      ' 
      SplitContainer.Dock = DockStyle.Fill
      SplitContainer.Location = New Point(0, 0)
      SplitContainer.Name = "SplitContainer"
      ' 
      ' SplitContainer.Panel1
      ' 
      SplitContainer.Panel1.Controls.Add(btnOpenFile)
      SplitContainer.Panel1.Controls.Add(txtBoxInput)
      SplitContainer.Panel1.Controls.Add(txtBoxFromFile)
      SplitContainer.Panel1.Controls.Add(rbtnFromText)
      SplitContainer.Panel1.Controls.Add(rbtnFromFile)
      ' 
      ' SplitContainer.Panel2
      ' 
      SplitContainer.Panel2.Controls.Add(grpBoxFiles)
      SplitContainer.Panel2.Controls.Add(grpBoxSearch)
      SplitContainer.Size = New Size(894, 487)
      SplitContainer.SplitterDistance = 434
      SplitContainer.TabIndex = 0
      ' 
      ' btnOpenFile
      ' 
      btnOpenFile.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      btnOpenFile.AutoSize = True
      btnOpenFile.ImageIndex = 0
      btnOpenFile.ImageList = imgListButtons
      btnOpenFile.Location = New Point(406, 3)
      btnOpenFile.Name = "btnOpenFile"
      btnOpenFile.Size = New Size(25, 23)
      btnOpenFile.TabIndex = 4
      btnOpenFile.UseVisualStyleBackColor = True
      ' 
      ' imgListButtons
      ' 
      imgListButtons.ColorDepth = ColorDepth.Depth32Bit
      imgListButtons.ImageStream = CType(resources.GetObject("imgListButtons.ImageStream"), ImageListStreamer)
      imgListButtons.TransparentColor = Color.Transparent
      imgListButtons.Images.SetKeyName(0, "Folder.ico")
      imgListButtons.Images.SetKeyName(1, "Search.ico")
      ' 
      ' txtBoxInput
      ' 
      txtBoxInput.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      txtBoxInput.Location = New Point(3, 53)
      txtBoxInput.Multiline = True
      txtBoxInput.Name = "txtBoxInput"
      txtBoxInput.Size = New Size(428, 431)
      txtBoxInput.TabIndex = 3
      ' 
      ' txtBoxFromFile
      ' 
      txtBoxFromFile.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      txtBoxFromFile.Location = New Point(84, 3)
      txtBoxFromFile.Name = "txtBoxFromFile"
      txtBoxFromFile.Size = New Size(316, 23)
      txtBoxFromFile.TabIndex = 2
      ' 
      ' rbtnFromText
      ' 
      rbtnFromText.AutoSize = True
      rbtnFromText.Location = New Point(3, 28)
      rbtnFromText.Name = "rbtnFromText"
      rbtnFromText.Size = New Size(78, 19)
      rbtnFromText.TabIndex = 1
      rbtnFromText.Text = "From text:"
      rbtnFromText.UseVisualStyleBackColor = True
      ' 
      ' rbtnFromFile
      ' 
      rbtnFromFile.AutoSize = True
      rbtnFromFile.Checked = True
      rbtnFromFile.Location = New Point(3, 3)
      rbtnFromFile.Name = "rbtnFromFile"
      rbtnFromFile.Size = New Size(75, 19)
      rbtnFromFile.TabIndex = 0
      rbtnFromFile.TabStop = True
      rbtnFromFile.Text = "From file:"
      rbtnFromFile.UseVisualStyleBackColor = True
      ' 
      ' grpBoxFiles
      ' 
      grpBoxFiles.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      grpBoxFiles.Location = New Point(3, 135)
      grpBoxFiles.Name = "grpBoxFiles"
      grpBoxFiles.Size = New Size(453, 349)
      grpBoxFiles.TabIndex = 2
      grpBoxFiles.TabStop = False
      grpBoxFiles.Text = "Result"
      ' 
      ' grpBoxSearch
      ' 
      grpBoxSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      grpBoxSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink
      grpBoxSearch.Controls.Add(lblPath)
      grpBoxSearch.Controls.Add(lblFile)
      grpBoxSearch.Controls.Add(TextBox2)
      grpBoxSearch.Controls.Add(TextBox1)
      grpBoxSearch.Controls.Add(Button1)
      grpBoxSearch.Controls.Add(btnSearch)
      grpBoxSearch.Controls.Add(chkBoxRecursive)
      grpBoxSearch.Location = New Point(3, 3)
      grpBoxSearch.Name = "grpBoxSearch"
      grpBoxSearch.Size = New Size(450, 126)
      grpBoxSearch.TabIndex = 1
      grpBoxSearch.TabStop = False
      grpBoxSearch.Text = "Search Options"
      ' 
      ' lblPath
      ' 
      lblPath.AutoSize = True
      lblPath.Location = New Point(3, 47)
      lblPath.Name = "lblPath"
      lblPath.Size = New Size(34, 15)
      lblPath.TabIndex = 10
      lblPath.Text = "Path:"
      ' 
      ' lblFile
      ' 
      lblFile.AutoSize = True
      lblFile.Location = New Point(3, 18)
      lblFile.Name = "lblFile"
      lblFile.Size = New Size(28, 15)
      lblFile.TabIndex = 9
      lblFile.Text = "File:"
      ' 
      ' TextBox2
      ' 
      TextBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      TextBox2.Location = New Point(64, 44)
      TextBox2.Name = "TextBox2"
      TextBox2.Size = New Size(346, 23)
      TextBox2.TabIndex = 8
      ' 
      ' TextBox1
      ' 
      TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
      TextBox1.Location = New Point(64, 15)
      TextBox1.Name = "TextBox1"
      TextBox1.Size = New Size(346, 23)
      TextBox1.TabIndex = 7
      ' 
      ' Button1
      ' 
      Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      Button1.AutoSize = True
      Button1.ImageIndex = 0
      Button1.ImageList = imgListButtons
      Button1.Location = New Point(419, 43)
      Button1.Name = "Button1"
      Button1.Size = New Size(25, 24)
      Button1.TabIndex = 6
      Button1.UseVisualStyleBackColor = True
      ' 
      ' btnSearch
      ' 
      btnSearch.AutoSize = True
      btnSearch.ImageIndex = 1
      btnSearch.ImageList = imgListButtons
      btnSearch.Location = New Point(9, 96)
      btnSearch.Name = "btnSearch"
      btnSearch.Size = New Size(22, 24)
      btnSearch.TabIndex = 5
      btnSearch.UseVisualStyleBackColor = True
      ' 
      ' chkBoxRecursive
      ' 
      chkBoxRecursive.AutoSize = True
      chkBoxRecursive.Location = New Point(64, 73)
      chkBoxRecursive.Name = "chkBoxRecursive"
      chkBoxRecursive.Size = New Size(76, 19)
      chkBoxRecursive.TabIndex = 1
      chkBoxRecursive.Text = "Recursive"
      chkBoxRecursive.UseVisualStyleBackColor = True
      ' 
      ' frmUMF
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(894, 487)
      Controls.Add(SplitContainer)
      Name = "frmUMF"
      StartPosition = FormStartPosition.CenterScreen
      Text = "RRFM Update My File"
      SplitContainer.Panel1.ResumeLayout(False)
      SplitContainer.Panel1.PerformLayout()
      SplitContainer.Panel2.ResumeLayout(False)
      CType(SplitContainer, ComponentModel.ISupportInitialize).EndInit()
      SplitContainer.ResumeLayout(False)
      grpBoxSearch.ResumeLayout(False)
      grpBoxSearch.PerformLayout()
      ResumeLayout(False)
   End Sub

   Friend WithEvents SplitContainer As SplitContainer
   Friend WithEvents txtBoxInput As TextBox
   Friend WithEvents txtBoxFromFile As TextBox
   Friend WithEvents rbtnFromText As RadioButton
   Friend WithEvents rbtnFromFile As RadioButton
   Friend WithEvents grpBoxFiles As GroupBox
   Friend WithEvents grpBoxSearch As GroupBox
   Friend WithEvents chkBoxRecursive As CheckBox
   Friend WithEvents imgListButtons As ImageList
   Friend WithEvents btnOpenFile As Button
   Friend WithEvents btnSearch As Button
   Friend WithEvents TextBox1 As TextBox
   Friend WithEvents Button1 As Button
   Friend WithEvents TextBox2 As TextBox
   Friend WithEvents lblPath As Label
   Friend WithEvents lblFile As Label

End Class
