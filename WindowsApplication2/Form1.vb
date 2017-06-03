Public Class Form1
    Private Delegate Function CopyProgressRoutine(ByVal totalFileSize As Int64, ByVal totalBytesTransferred As Int64, ByVal streamSize As Int64, ByVal streamBytesTransferred As Int64, ByVal dwStreamNumber As Int32, ByVal dwCallbackReason As Int32, ByVal hSourceFile As Int32, ByVal hDestinationFile As Int32, ByVal lpData As Int32) As Int32

    Private Declare Auto Function CopyFileEx Lib "kernel32.dll" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal lpProgressRoutine As CopyProgressRoutine, ByVal lpData As Int32, ByVal lpBool As Int32, ByVal dwCopyFlags As Int32) As Int32
    Dim fsString As String = "/ fs: ntfs / q / y"
    Dim ImDiskStart As String
    '    Dim Looping As Boolean = 1
    Dim ComboSize As String
    Dim PathToOld As String
    Private _totalFileSize As Long = 0
    Private _totalBytesCopied As Long = 0
    Private _copyProgressRoutine As CopyProgressRoutine
    Dim ROOTFOLDER As String
    Dim DESTFOLDER As String
    Dim folderNameVar As String
    Dim formatArgs As String
    Dim process As New Process()
    Dim formatProcess As New Process()
    Dim JuncProcess As New Process()
    Dim JunctionProcess As New Process()
    Dim thereIsDisk As Int16 = 0
    Dim CopyCompleted As Boolean = True
    Public Function GetAvailableDriveLetters() As List(Of String)
        Dim letters As New List(Of String)()
        For i As Integer = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c) - 1
            letters.Add(New String(New Char() {ChrW(i)}))
        Next
        For Each drive As String In Directory.GetLogicalDrives()
            letters.Remove(drive.Substring(0, 1))
        Next
        Return letters
    End Function
    Private Sub GetRAMUsage()
        Dim info = New Devices.ComputerInfo()
        Label3.Text = Math.Round(info.AvailablePhysicalMemory / 1024 / 1024) & " MB"
    End Sub
    Private Sub PickDirButton_Click(sender As Object, e As EventArgs) Handles PickDirButton.Click
        Try
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                Dim dInfo As New DirectoryInfo(FolderBrowserDialog1.SelectedPath)
                Dim sizeOfDir As Long = DirectorySize(dInfo, True)
                Label6.Text = Math.Round(sizeOfDir / 1024 / 1024) & " MB"
            End If
        Catch ex As Exception
        End Try
        PathBox.Text = FolderBrowserDialog1.SelectedPath
    End Sub
    Private Sub RAMSizeBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RAMSizeBox.KeyPress
        If Char.IsNumber(e.KeyChar) = True Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) = True Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists("C:\Windows\System32\imdisk.cpl") Then
            MsgBox("This program requires ImDisk to function properly. Please download at https://sourceforge.net/projects/imdisk-toolkit/", MsgBoxStyle.OkOnly, "")
        End If
        Timer1.Start()
        TestComboBox.SelectedIndex = 0
        RAMDiskLetter.Items.AddRange(GetAvailableDriveLetters.ToArray)
        RAMDiskLetter.SelectedIndex = (GetAvailableDriveLetters.Count - 1)
        FSCombo.Items.Add("FAT32")
        FSCombo.Items.Add("NTFS")
        FSCombo.SelectedIndex = 0
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetRAMUsage()
    End Sub
    Private Function DirectorySize(ByVal dInfo As DirectoryInfo, ByVal includeSubDir As Boolean) As Long
        Dim totalSize As Long = dInfo.EnumerateFiles().Sum(Function(file) file.Length)
        If includeSubDir Then totalSize += dInfo.EnumerateDirectories().Sum(Function(dir) DirectorySize(dir, True))
        Return totalSize
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CreateDiskButton.Click
        Dim folderSize As Int64 = Label6.Text.Substring(0, Label6.Text.Length - 3)
        Dim diskSize As Int64 = RAMSizeBox.Text
        Dim RAMSize As Int64 = Label3.Text.Substring(0, Label3.Text.Length - 3)
        If PathBox.Text.Contains("windows") Then
            MsgBox("Do not use your Windows folder; if your username contains Windows in the name, please move your file to another location (i.e., C:\MyFolder)", MsgBoxStyle.OkOnly, "")
        Else
            If RAMSizeBox.Text = "" Then
                MsgBox("Enter how large you want the RAM disk to be", MsgBoxStyle.OkOnly, "")
            Else
                If thereIsDisk = 1 Then
                    MsgBox("There is already a RAM disk, please remove the RAM disk before creating a new one", MsgBoxStyle.OkOnly, "")
                Else
                    If folderSize > (diskSize * 0.95) Then
                        MsgBox("The folder is larger than the RAM disk, please increase the size of the disk", MsgBoxStyle.OkOnly, "")
                    Else
                        If diskSize > RAMSize Then
                            MsgBox("The RAM disk is larger than the available amount of RAM, please decrease the size of the disk", MsgBoxStyle.OkOnly, "")
                        Else
                            thereIsDisk = 1
                            PickDirButton.Enabled = False
                            PathBox.Enabled = False
                            RAMDiskLetter.Enabled = False
                            DontCopyCheck.Enabled = False
                            folderNameVar = Replace(PathBox.Text, Path.GetDirectoryName(PathBox.Text), "")
                            folderNameVar = Replace(folderNameVar, "\", "")
                            ComboSize = TestComboBox.Text.Replace("B", "")
                            PathToOld = (PathBox.Text & ".old")
                            ImDiskStart = (" -a -s " & RAMSizeBox.Text & ComboSize & " -m " & RAMDiskLetter.Text & ": -p """ & fsString & """ -o rem")
                            CreateRAMDisk()
                            Do Until process.HasExited
                                Application.DoEvents()
                            Loop
                            Do Until formatProcess.HasExited
                                Application.DoEvents()
                            Loop
                            CopyCompleted = False
                            ROOTFOLDER = PathBox.Text
                            DESTFOLDER = RAMDiskLetter.Text & ":\" & folderNameVar
                            GetTotalFileSize(New DirectoryInfo(ROOTFOLDER))
                            _copyProgressRoutine = New CopyProgressRoutine(AddressOf CopyProgress)
                            CopyFiles(New DirectoryInfo(ROOTFOLDER), DESTFOLDER)
                            My.Computer.FileSystem.RenameDirectory(ROOTFOLDER, folderNameVar & ".old")
                            While CopyCompleted = False
                                Application.DoEvents()
                            End While
                            CreateJunction()
                            ProgressBar1.Value = 0
                            MsgBox("RAM disk ready")
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Function IsProcessRunning(ByVal name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub CreateRAMDisk()

        process.StartInfo.FileName = "imdisk.exe"
        process.StartInfo.Verb = "runas"
        process.StartInfo.Arguments = ImDiskStart
        process.StartInfo.UseShellExecute = True
        process.StartInfo.CreateNoWindow = True
        process.Start()
        Do Until process.HasExited
            Application.DoEvents()
        Loop
        Dim RAMDiskDeci As Decimal
        Decimal.TryParse(RAMSizeBox.Text, RAMDiskDeci)
        If RAMDiskDeci > 32000 Then
            formatArgs = RAMDiskLetter.Text & ": /FS:exFAT /v: /q /y"
        Else
            formatArgs = RAMDiskLetter.Text & ": /FS:" & FSCombo.Text & " /v: /q /y"
        End If
        formatProcess.StartInfo.FileName = "format.com"
        formatProcess.StartInfo.Arguments = formatArgs
        formatProcess.StartInfo.UseShellExecute = True
        formatProcess.Start()
        While IsProcessRunning("format") = True
            Application.DoEvents()
        End While
    End Sub
    Private Sub RemoveRAMDisk()
        Dim ImDiskEnd = (" -D -m " & RAMDiskLetter.Text & ":")
        process.StartInfo.FileName = "imdisk.exe"
        process.StartInfo.Verb = "runas"
        process.StartInfo.Arguments = ImDiskEnd
        process.StartInfo.UseShellExecute = True
        process.Start()
    End Sub
    Private Sub CreateJunction()
        Dim JuncArgs As String = " /c mklink /J """ & ROOTFOLDER & """ """ & DESTFOLDER & """"
        JuncProcess.StartInfo.FileName = "cmd.exe"
        JuncProcess.StartInfo.Arguments = JuncArgs
        JuncProcess.Start()
    End Sub
    Private Sub RemoveDiskButton_Click(sender As Object, e As EventArgs) Handles RemoveDiskButton.Click
        If thereIsDisk = 0 Then
            MsgBox("There is no RAM disk to remove", MsgBoxStyle.OkOnly, "")
        Else
            Dim JunctionArgs As String = " /c rmdir """ & PathBox.Text & """"
            JunctionProcess.StartInfo.FileName = "cmd.exe"
            JunctionProcess.StartInfo.Arguments = JunctionArgs
            JunctionProcess.StartInfo.UseShellExecute = True
            JunctionProcess.Start()
            Do Until JunctionProcess.HasExited
                Application.DoEvents()
            Loop
            If DontCopyCheck.Checked = False Then
                ROOTFOLDER = RAMDiskLetter.Text & ":\" & folderNameVar
                DESTFOLDER = PathBox.Text
                GetTotalFileSize(New DirectoryInfo(ROOTFOLDER))
                _copyProgressRoutine = New CopyProgressRoutine(AddressOf CopyProgress)
                CopyFiles(New DirectoryInfo(ROOTFOLDER), DESTFOLDER)
                While CopyCompleted = False
                    Application.DoEvents()
                End While
            End If
            RemoveRAMDisk()
            If DontCopyCheck.Checked = False Then
                Dim deletePath As String = PathBox.Text & ".old"
                Directory.Delete(deletePath, True)
            Else
                My.Computer.FileSystem.RenameDirectory(PathBox.Text & ".old", folderNameVar)
            End If
            While IsProcessRunning("imdisk")
                    Application.DoEvents()
                End While
                ProgressBar1.Value = 0
                thereIsDisk = 0
                PickDirButton.Enabled = True
                PathBox.Enabled = True
            RAMDiskLetter.Enabled = True
            DontCopyCheck.Enabled = True
            MsgBox("RAM disk removed")
            End If
    End Sub
    Private Sub CopyFiles(ByVal folder As DirectoryInfo, ByVal destinationFolder As String)
        CopyCompleted = False
        If Not Directory.Exists(destinationFolder) Then
            Directory.CreateDirectory(destinationFolder)
        End If
        For Each fi As FileInfo In folder.GetFiles
            CopyFileEx(fi.FullName, destinationFolder & "\" & fi.Name, _copyProgressRoutine, 0, 0, 0)
            _totalBytesCopied += fi.Length
        Next
        For Each di As DirectoryInfo In folder.GetDirectories
            CopyFiles(di, di.FullName.Replace(ROOTFOLDER, DESTFOLDER))
        Next
        CopyCompleted = True
    End Sub
    Private Sub GetTotalFileSize(ByVal folder As DirectoryInfo)
        For Each fi As FileInfo In folder.GetFiles
            _totalFileSize += fi.Length
        Next
        For Each di As DirectoryInfo In folder.GetDirectories
            GetTotalFileSize(di)
        Next
    End Sub
    Private Function CopyProgress(ByVal totalFileSize As Int64, ByVal totalBytesTransferred As Int64, ByVal streamSize As Int64, ByVal streamBytesTransferred As Int64, ByVal dwStreamNumber As Int32, ByVal dwCallbackReason As Int32, ByVal hSourceFile As Int32, ByVal hDestinationFile As Int32, ByVal lpData As Int32) As Int32
        ProgressBar1.Value = Convert.ToInt32((_totalBytesCopied + totalBytesTransferred) / _totalFileSize * 100)
        Application.DoEvents()
    End Function

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        MsgBox("RAMDiskCopy Alpha Version 0.3.1 created by Haven Van Heusen 2017", MsgBoxStyle.OkOnly, "")
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If thereIsDisk = 1 Then
            Dim result As MsgBoxResult = MsgBox("There is still a RAM disk mounted. Are you sure you want to exit?", MsgBoxStyle.YesNo, "Do you want to quit?")
            If result = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DontCopyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles DontCopyCheck.CheckedChanged
        If DontCopyCheck.Checked = True Then
            DontCopyLabel.Visible = True
        End If
        If DontCopyCheck.Checked = False Then
            DontCopyLabel.Visible = False
        End If
    End Sub
End Class