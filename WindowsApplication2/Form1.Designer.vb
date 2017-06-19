<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PickDirButton = New System.Windows.Forms.Button()
        Me.PathBox = New System.Windows.Forms.TextBox()
        Me.CreateDiskButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RAMSizeBox = New System.Windows.Forms.TextBox()
        Me.TestComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.RemoveDiskButton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RAMDiskLetter = New System.Windows.Forms.ComboBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.FSCombo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.DontCopyCheck = New System.Windows.Forms.CheckBox()
        Me.DontCopyLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PickDirButton
        '
        Me.PickDirButton.Location = New System.Drawing.Point(12, 41)
        Me.PickDirButton.Name = "PickDirButton"
        Me.PickDirButton.Size = New System.Drawing.Size(33, 23)
        Me.PickDirButton.TabIndex = 0
        Me.PickDirButton.Text = ". . ."
        Me.PickDirButton.UseVisualStyleBackColor = True
        '
        'PathBox
        '
        Me.PathBox.Location = New System.Drawing.Point(51, 43)
        Me.PathBox.Name = "PathBox"
        Me.PathBox.Size = New System.Drawing.Size(405, 20)
        Me.PathBox.TabIndex = 1
        '
        'CreateDiskButton
        '
        Me.CreateDiskButton.Location = New System.Drawing.Point(12, 189)
        Me.CreateDiskButton.Name = "CreateDiskButton"
        Me.CreateDiskButton.Size = New System.Drawing.Size(114, 23)
        Me.CreateDiskButton.TabIndex = 2
        Me.CreateDiskButton.Text = "Create RAM Disk"
        Me.CreateDiskButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Choose the folder of the game to copy to RAM Disk:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "RAM Available:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "0"
        '
        'RAMSizeBox
        '
        Me.RAMSizeBox.Location = New System.Drawing.Point(329, 68)
        Me.RAMSizeBox.Name = "RAMSizeBox"
        Me.RAMSizeBox.ShortcutsEnabled = False
        Me.RAMSizeBox.Size = New System.Drawing.Size(100, 20)
        Me.RAMSizeBox.TabIndex = 6
        '
        'TestComboBox
        '
        Me.TestComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TestComboBox.FormattingEnabled = True
        Me.TestComboBox.Items.AddRange(New Object() {"MB", "GB"})
        Me.TestComboBox.Location = New System.Drawing.Point(333, 190)
        Me.TestComboBox.MaxDropDownItems = 2
        Me.TestComboBox.Name = "TestComboBox"
        Me.TestComboBox.Size = New System.Drawing.Size(44, 21)
        Me.TestComboBox.TabIndex = 7
        Me.TestComboBox.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(242, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "RAM Disk Size:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Folder Size:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(98, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'RemoveDiskButton
        '
        Me.RemoveDiskButton.Location = New System.Drawing.Point(133, 189)
        Me.RemoveDiskButton.Name = "RemoveDiskButton"
        Me.RemoveDiskButton.Size = New System.Drawing.Size(114, 23)
        Me.RemoveDiskButton.TabIndex = 11
        Me.RemoveDiskButton.Text = "Remove RAM Disk"
        Me.RemoveDiskButton.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(290, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "RAM Disk Drive Letter:"
        '
        'RAMDiskLetter
        '
        Me.RAMDiskLetter.FormattingEnabled = True
        Me.RAMDiskLetter.Location = New System.Drawing.Point(412, 92)
        Me.RAMDiskLetter.Name = "RAMDiskLetter"
        Me.RAMDiskLetter.Size = New System.Drawing.Size(44, 21)
        Me.RAMDiskLetter.TabIndex = 13
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 160)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(446, 23)
        Me.ProgressBar1.TabIndex = 14
        '
        'TestButton
        '
        Me.TestButton.Location = New System.Drawing.Point(383, 188)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(75, 23)
        Me.TestButton.TabIndex = 15
        Me.TestButton.Text = "Test Stuff"
        Me.TestButton.UseVisualStyleBackColor = True
        Me.TestButton.Visible = False
        '
        'FSCombo
        '
        Me.FSCombo.FormattingEnabled = True
        Me.FSCombo.Location = New System.Drawing.Point(389, 118)
        Me.FSCombo.Name = "FSCombo"
        Me.FSCombo.Size = New System.Drawing.Size(66, 21)
        Me.FSCombo.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(269, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "RAM Disk File System:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(432, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "MB"
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(383, 8)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(75, 23)
        Me.AboutButton.TabIndex = 19
        Me.AboutButton.Text = "About..."
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'DontCopyCheck
        '
        Me.DontCopyCheck.AutoSize = True
        Me.DontCopyCheck.Location = New System.Drawing.Point(18, 120)
        Me.DontCopyCheck.Name = "DontCopyCheck"
        Me.DontCopyCheck.Size = New System.Drawing.Size(123, 17)
        Me.DontCopyCheck.TabIndex = 20
        Me.DontCopyCheck.Text = "Don't Restore Folder"
        Me.DontCopyCheck.UseVisualStyleBackColor = True
        '
        'DontCopyLabel
        '
        Me.DontCopyLabel.AutoSize = True
        Me.DontCopyLabel.ForeColor = System.Drawing.Color.Red
        Me.DontCopyLabel.Location = New System.Drawing.Point(12, 144)
        Me.DontCopyLabel.Name = "DontCopyLabel"
        Me.DontCopyLabel.Size = New System.Drawing.Size(312, 13)
        Me.DontCopyLabel.TabIndex = 21
        Me.DontCopyLabel.Text = "Warning: Only use this if the data on the RAM disk won't change"
        Me.DontCopyLabel.Visible = False
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 220)
        Me.Controls.Add(Me.DontCopyLabel)
        Me.Controls.Add(Me.DontCopyCheck)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FSCombo)
        Me.Controls.Add(Me.TestButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.RAMDiskLetter)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RemoveDiskButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TestComboBox)
        Me.Controls.Add(Me.RAMSizeBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CreateDiskButton)
        Me.Controls.Add(Me.PathBox)
        Me.Controls.Add(Me.PickDirButton)
        Me.Name = "Form1"
        Me.Text = "RAM Disk Copy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PickDirButton As Button
    Friend WithEvents PathBox As TextBox
    Friend WithEvents CreateDiskButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RAMSizeBox As TextBox
    Friend WithEvents TestComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents RemoveDiskButton As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents RAMDiskLetter As ComboBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TestButton As Button
    Friend WithEvents FSCombo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents AboutButton As Button
    Friend WithEvents DontCopyCheck As CheckBox
    Friend WithEvents DontCopyLabel As Label
End Class
