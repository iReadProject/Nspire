Imports System.Drawing.Imaging
Imports System.IO
#Const DEBUG_iLua = False

Public Class Frm_Main
    Public Const Image_Width As Integer = 320
    Public Const Image_Height As Integer = 240
    Public Const Text_Default_Width As Int32 = 305
    Public Const Text_Default_Height As Int32 = 184
    Public Const Text_Default_Width_3_1 As Int32 = 300
    Public Const Text_Default_Height_3_1 As Int32 = 175
    Public Const Text_Default_EnglishWidth As Int32 = 285
    Public Const UTF8_FAULT As Int32 = -1
    Public BatchLogPath As String = Application.StartupPath + "\Batch.log"
    Public If_TextError As Boolean = False

    Private Sub Btn_Exit_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exit.Click
        Application.Exit()
    End Sub

    Private Sub Btn_About_Click(sender As System.Object, e As System.EventArgs) Handles Btn_About.Click
        Frm_About.Show()
    End Sub

    Private Sub Chk_ChooseColor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_ChooseColor.CheckedChanged
        Btn_ChooseForeColor.Enabled = Chk_ChooseColor.Checked
        Btn_ChooseBackColor.Enabled = Chk_ChooseColor.Checked
        Chk_ChooseColor_FirstLoad.Enabled = Chk_ChooseColor.Checked
    End Sub

    Private Sub Chk_Image_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Image.CheckedChanged
        Btn_OpenImage.Enabled = Chk_Image.Checked
        Txt_Image.Enabled = Chk_Image.Checked
    End Sub

    Private Sub Chk_Divide_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Divide.CheckedChanged
        Chk_OS3_1.Enabled = Chk_Divide.Checked
    End Sub

    Private Sub Chk_Size_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Size.CheckedChanged
        Txt_Width.Enabled = Chk_Size.Checked
        Txt_Height.Enabled = Chk_Size.Checked
    End Sub

    Private Sub Chk_OutSourcePath_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_OutSourcePath.CheckedChanged
        Txt_OutputFile.Enabled = Not Chk_OutSourcePath.Checked
        Btn_SaveTNS.Enabled = Txt_OutputFile.Enabled
    End Sub

    Private Sub Chk_Batch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Batch.CheckedChanged
        If Chk_Batch.Checked Then
            Lbl_Open.Text = "txt文件目录："
            Lbl_Save.Text = "目标tns文件目录："
        Else
            Lbl_Open.Text = "txt文件路径："
            Lbl_Save.Text = "目标tns文件路径："
        End If
        Txt_InputFile.Text = ""
        Txt_OutputFile.Text = ""
    End Sub

    Private Sub Btn_ChooseForeColor_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ChooseForeColor.Click
        Dim fore As Color = Color_ForeColor.Color
        If Color_ForeColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fore = Color_ForeColor.Color
        End If
        Lbl_ForeColor.Text = "前景色" & vbCrLf &
                             "R:" & fore.R & vbCrLf &
                             "G:" & fore.G & vbCrLf &
                             "B:" & fore.B
        My.Settings.Text_Color_ForeColor = fore
    End Sub

    Private Sub Btn_ChooseBackColor_Click(sender As System.Object, e As System.EventArgs) Handles Btn_ChooseBackColor.Click
        Dim back As Color = Color_BackColor.Color
        If Color_BackColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            back = Color_BackColor.Color
        End If
        Lbl_BackColor.Text = "背景色" & vbCrLf &
                             "R:" & back.R & vbCrLf &
                             "G:" & back.G & vbCrLf &
                             "B:" & back.B
        My.Settings.Text_Color_BackColor = back
    End Sub

    Private Sub Chk_Interval_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_Interval.CheckedChanged
        Txt_Interval.Enabled = Chk_Interval.Checked
    End Sub

    Private Sub Chk_ProfessionalMode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Chk_ProfessionalMode.CheckedChanged
        Group_Advanced.Visible = Chk_ProfessionalMode.Checked
        Group_TextSetting.Visible = Chk_ProfessionalMode.Checked
    End Sub
    Private Sub CheckPath(ByVal path As String)
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath + path) Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + path)
        Else
            FileSystem.FileOpen(1, Application.StartupPath + path + "\test.txt", OpenMode.Output)
            FileSystem.FileClose(1)
            Kill(Application.StartupPath + path + "\*.*")
        End If
    End Sub

    Private Sub CleanTmp()
        CheckPath("\tmp")
        CheckPath("\tmp\src")
        CheckPath("\tmp\data")
        CheckPath("\tmp\iLua_tmp")
    End Sub
    Private Sub Frm_Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\Bmp2Lua_Kernel.exe") Then
            ShowBox("Bmp2Lua_Kernel.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\DeComment.exe") Then
            ShowBox("DeComment.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\FileAppender.exe") Then
            ShowBox("FileAppender.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\libeay32.dll") Then
            ShowBox("libeay32.dll")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\luna_0.31.exe") Then
            ShowBox("luna_0.31.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\Spliter.exe") Then
            ShowBox("Spliter.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\VarIncluder.exe") Then
            ShowBox("VarIncluder.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\bin\iRead_Conver.exe") Then
            ShowBox("iRead_Conver.exe")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\src\main.lua") Then
            ShowBox("main.lua")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\src\menu.lua") Then
            ShowBox("menu.lua")
        End If

        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "\src\text_deal.lua") Then
            ShowBox("text_deal.lua")
        End If
        CleanTmp()

        Chk_OS3_1.Enabled = Chk_Divide.Checked
        If Chk_OS3_1.Enabled = False Then
            Chk_OS3_1.Checked = False
        End If
        Dim fore As Color = Color_ForeColor.Color
        Dim back As Color = Color_BackColor.Color
        Lbl_ForeColor.Text = "前景色" & vbCrLf &
                            "R:" & fore.R & vbCrLf &
                            "G:" & fore.G & vbCrLf &
                            "B:" & fore.B
        Lbl_BackColor.Text = "背景色" & vbCrLf &
                             "R:" & back.R & vbCrLf &
                             "G:" & back.G & vbCrLf &
                             "B:" & back.B
    End Sub

    Private Sub ShowBox(ByVal FileName As String)
        MsgBox("找不到" + FileName + "请重新安装以解决这一问题！", vbOKOnly + vbCritical + vbApplicationModal, "错误")
        End
    End Sub

    Private Sub Btn_OpenTxt_Click(sender As System.Object, e As System.EventArgs) Handles Btn_OpenTxt.Click
        If Chk_Batch.Checked = False Then
            If Open_Txt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Txt_InputFile.Text = Open_Txt.FileName
            Else
                Txt_InputFile.Text = ""
            End If
        Else
            If Open_Folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Txt_InputFile.Text = Open_Folder.SelectedPath
            Else
                Txt_InputFile.Text = ""
            End If
        End If

    End Sub

    Private Sub Btn_SaveTNS_Click(sender As System.Object, e As System.EventArgs) Handles Btn_SaveTNS.Click
        If Chk_Batch.Checked = False Then
            If Save_Tns.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Txt_OutputFile.Text = Save_Tns.FileName
            Else
                Txt_OutputFile.Text = ""
            End If
        Else
            If Save_Folder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Txt_OutputFile.Text = Save_Folder.SelectedPath
            Else
                Txt_OutputFile.Text = ""
            End If
        End If
    End Sub

    Private Sub Btn_OpenImage_Click(sender As System.Object, e As System.EventArgs) Handles Btn_OpenImage.Click
        If Open_Image.ShowDialog = Windows.Forms.DialogResult.OK Then
            Txt_Image.Text = Open_Image.FileName
        Else
            Txt_Image.Text = ""
        End If
    End Sub

    Private Sub CreateMakeFile()
        Dim MakeFIlePath As String = Application.StartupPath & "\tmp\make.lua"

        WriteFileANSI(MakeFIlePath, "--[[" & vbCrLf, False)
        WriteFileANSI(MakeFIlePath, "    #Varinclude <src\menu.lua> for menu as Menu" & vbCrLf)
        If Chk_Image.Checked Then
            WriteFileANSI(MakeFIlePath, "    #VarInclude <data\back_image.lua> for __BackBoradImage as Image" & vbCrLf)
        End If
        WriteFileANSI(MakeFIlePath, "    #VarInclude <data\data.txt> for Unicode as Normal" & vbCrLf)
        If Chk_Divide.Checked Then
            WriteFileANSI(MakeFIlePath, "    #VarInclude <data\line.txt> for Line as Normal" & vbCrLf)
            WriteFileANSI(MakeFIlePath, "    #VarInclude <data\page.txt> for Page as Normal" & vbCrLf)
        End If

        WriteFileANSI(MakeFIlePath, "    #FreInclude <src\text_deal.lua>" & vbCrLf)
        WriteFileANSI(MakeFIlePath, "    #FreInclude <src\draw.lua>" & vbCrLf)
        WriteFileANSI(MakeFIlePath, "    #FreInclude <src\main.lua>" & vbCrLf)

        WriteFileANSI(MakeFIlePath, "]]--" & vbCrLf)
    End Sub

    Private Sub CreateDrawFile()
        Dim DrawFilePath As String = Application.StartupPath & "\tmp\src\draw.lua"

        WriteFileANSI(DrawFilePath, "function __Draw()" & vbCrLf, False)
        WriteFileANSI(DrawFilePath, "    toolpalette.enable(""自动翻页"", ""停止"", false)" & vbCrLf)
        WriteFileANSI(DrawFilePath, "    iRead:OSChecker()" & vbCrLf)
        WriteFileANSI(DrawFilePath, "    iRead:SelfAdapt()" & vbCrLf)

        If Chk_OS3_1.Checked Then

            If Chk_EnglishBreakingLine.Checked Then
                WriteFileANSI(DrawFilePath, "    iRead.MaxTextWidth = " & Text_Default_EnglishWidth & vbCrLf)
            Else
                WriteFileANSI(DrawFilePath, "    iRead.MaxTextWidth = " & Text_Default_Width_3_1 & vbCrLf)
            End If
            WriteFileANSI(DrawFilePath, "    iRead.MaxTextHeight = " & Text_Default_Height_3_1 & vbCrLf)

        ElseIf Chk_Size.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.MaxTextWidth = " & CInt(Val(Txt_Width.Text)) & vbCrLf)
            WriteFileANSI(DrawFilePath, "    iRead.MaxTextHeight = " & CInt(Val(Txt_Height.Text)) & vbCrLf)
        ElseIf Chk_EnglishBreakingLine.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.MaxTextWidth = " & Text_Default_EnglishWidth & vbCrLf)
        End If

        If Chk_EnglishBreakingLine.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.IfBreakingLine = true" & vbCrLf)
        End If

        If Chk_Image.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.BackBoradImage = __BackBoradImage" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    __BackBoradImage = nil" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    collectgarbage()" & vbCrLf)
        End If

        If Chk_Interval.Checked Then
            WriteFileANSI(DrawFilePath, "    var.store(""iread_interval"", " & Val(Txt_Interval.Text) & ")" & vbCrLf)
        Else
            WriteFileANSI(DrawFilePath, "    var.store(""iread_interval"", 15)" & vbCrLf)
        End If

        If Chk_ChooseColor.Checked Then
            Dim fore As Color = Color_ForeColor.Color
            Dim back As Color = Color_BackColor.Color

            WriteFileANSI(DrawFilePath,
                          "    var.store(""iread_color_f"", {" &
                          fore.R & ", " &
                          fore.G & ", " &
                          fore.B & "," &
                          "})" & vbCrLf)
            WriteFileANSI(DrawFilePath,
                          "    var.store(""iread_color_b"", {" &
                          back.R & ", " &
                          back.G & ", " &
                          back.B & "," &
                          "})" & vbCrLf)
        Else
            WriteFileANSI(DrawFilePath, "    var.store(""iread_color_f"", {0, 0, 0})" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    var.store(""iread_color_b"", {255, 255, 255})" & vbCrLf)
        End If

        WriteFileANSI(DrawFilePath, "    iRead.TextData = Unicode" & vbCrLf)
        WriteFileANSI(DrawFilePath, "    Unicode = nil" & vbCrLf)
        WriteFileANSI(DrawFilePath, "    collectgarbage()" & vbCrLf)

        If Chk_Divide.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.Line = Line" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    Line = nil" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    iRead.Page = Page" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    Page = nil" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    collectgarbage()" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    iRead.MaxPage = #iRead.Page" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    iRead.IfDivided = true" & vbCrLf)
        Else
            WriteFileANSI(DrawFilePath, "    iRead:DividePage(iRead.DefaultDividePageNumber)" & vbCrLf)
        End If

        If Chk_NonClip.Checked Then
            WriteFileANSI(DrawFilePath, "    iRead.SaveToClipboard = false" & vbCrLf)
        End If

        If Chk_ChooseColor_FirstLoad.Checked Then
            WriteFileANSI(DrawFilePath, "    if iRead.IfColor == true then" & vbCrLf)
            WriteFileANSI(DrawFilePath, "       iRead:LoadColorCustomize()" & vbCrLf)
            WriteFileANSI(DrawFilePath, "    end" & vbCrLf)
        End If
        WriteFileANSI(DrawFilePath, "    iRead:ReloadMarker()" & vbCrLf)
        WriteFileANSI(DrawFilePath, "    iRead.IfDraw = false" & vbCrLf)
        WriteFileANSI(DrawFilePath, "end" & vbCrLf)
    End Sub

    Private Sub WriteFileANSI(ByVal Path As String, ByVal Data As String, Optional ByVal Append As Boolean = True)
        My.Computer.FileSystem.WriteAllText(Path, Data, Append, System.Text.Encoding.GetEncoding("gb2312"))
    End Sub

    Private Sub WriteBatchLog(ByVal Data As String, Optional NewLine As Boolean = True)
        If NewLine Then
            Data += vbCrLf
        End If
        WriteFileANSI(BatchLogPath, Data)
    End Sub

    Private Sub WriteBatchLogBegin()
        WriteBatchLog("")
        WriteBatchLog("***********************************")
        WriteBatchLog("转换开始于:" + Microsoft.VisualBasic.DateAndTime.Now)
        WriteBatchLog("")
    End Sub

    Private Sub WriteBatchLogEnd()
        WriteBatchLog("")
        WriteBatchLog("转换结束于:" + Microsoft.VisualBasic.DateAndTime.Now)
        WriteBatchLog("***********************************")
        WriteBatchLog("")
    End Sub
    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo
    Private Sub ConverImage()
        If Not Chk_Image.Checked Then
            Exit Sub
        End If

        Dim Pic_Conver As Image = Image.FromFile(Txt_Image.Text)

        Dim Pic_ImageCodecInfo As Imaging.ImageCodecInfo
        Dim Pic_Encoder As Imaging.Encoder
        Dim Pic_EncoderParameter As Imaging.EncoderParameter
        Dim Pic_EncoderParameters As Imaging.EncoderParameters

        Pic_ImageCodecInfo = GetEncoderInfo("image/bmp")
        Pic_Encoder = Encoder.ColorDepth
        Pic_EncoderParameters = New EncoderParameters(1)
        Pic_EncoderParameter = New EncoderParameter(Pic_Encoder, CType(24L, Int32))
        Pic_EncoderParameters.Param(0) = Pic_EncoderParameter

        Dim Pic_ReSize As New System.Drawing.Bitmap(Pic_Conver, Image_Width, Image_Height)
        Dim Pic_Resize_S As New System.Drawing.Bitmap(Image_Width, Image_Height, PixelFormat.Format24bppRgb)
        Dim Rect As New Rectangle(0, 0, Image_Width, Image_Height)
        Pic_Resize_S = Pic_ReSize.Clone(Rect, PixelFormat.Format24bppRgb)
        Pic_Resize_S.Save(Application.StartupPath & "\tmp\data\temp.bmp", Pic_ImageCodecInfo, Pic_EncoderParameters)

        Dim List As String

        List = " " & """" & Application.StartupPath & "\tmp\data\temp.bmp" & """" _
                 & " " & """" & Application.StartupPath & "\tmp\data\back_image.lua" & """" & " /o"

        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath & "\bin"

        Dim Process As New Diagnostics.Process()
        Dim Pro_Info As New Diagnostics.ProcessStartInfo()

        Pro_Info.Arguments = List
        Pro_Info.FileName = """Bmp2Lua_Kernel.exe"""
        Pro_Info.WorkingDirectory = Application.StartupPath + "\bin"
        Pro_Info.UseShellExecute = False
        Pro_Info.RedirectStandardOutput = True
        Pro_Info.CreateNoWindow = True

        Process.StartInfo = Pro_Info
        Process.Start()
        Me.Refresh()
        Process.WaitForExit()

    End Sub

    Private Sub CopySourceFiles()
        Dim App_Path As String = Application.StartupPath
        Dim LuaFile As String
        For Each LuaFile In My.Computer.FileSystem.GetFiles(App_Path + "\src", FileIO.SearchOption.SearchTopLevelOnly,
                                                            "*.lua")
            My.Computer.FileSystem.CopyFile(LuaFile, App_Path + "\tmp\src\" + My.Computer.FileSystem.GetName(LuaFile), True)
        Next

    End Sub

    Private Sub MakeTxtData(ByVal FileName As String)
        Dim App_Path As String = Application.StartupPath
        If Not My.Computer.FileSystem.FileExists(FileName) Then
            If_TextError = True
            Exit Sub
        End If
        My.Computer.FileSystem.CopyFile(FileName, App_Path + "\tmp\data\temp.txt", True)

        Dim List As String = " " + """" + App_Path + "\tmp\data\temp.txt" + """" +
                             " " + """" + App_Path + "\tmp\data\data.txt" + """"
        If Chk_Divide.Checked Then
            List += " /o " + """" + App_Path + "\tmp\data\line.txt" + """" +
                    " " + """" + App_Path + "\tmp\data\page.txt" + """"
        End If

        Dim Text_Height, Text_Width As Int32
        Text_Height = Text_Default_Height
        Text_Width = Text_Default_Width

        If Chk_OS3_1.Checked Then
            Text_Height = Text_Default_Height_3_1
            Text_Width = Text_Default_Width_3_1
        ElseIf Chk_Size.Checked Then
            Text_Height = Val(Txt_Height.Text)
            Text_Width = Val(Txt_Width.Text)
        End If

        List += " /size " +
                " " + Str(Text_Width) + " " +
                " " + Str(Text_Height) + " "

        If Chk_EnglishBreakingLine.Checked Then
            List += " /e "
        End If

        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath & "\bin"

        Dim Process As New Diagnostics.Process()
        Dim Pro_Info As New Diagnostics.ProcessStartInfo()

        Pro_Info.Arguments = List
        Pro_Info.FileName = """iRead_Conver.exe"""
        Pro_Info.WorkingDirectory = Application.StartupPath + "\bin"
        Pro_Info.UseShellExecute = False
        Pro_Info.RedirectStandardOutput = True
        Pro_Info.CreateNoWindow = True

        Process.StartInfo = Pro_Info
        Process.Start()
        Me.Refresh()
        Process.WaitForExit()

        If Not Process.ExitCode = 0 Then
            If_TextError = True
        End If

    End Sub

    Private Sub MakeTNS()
        Dim App_Path As String = Application.StartupPath
        Dim List As String = """" + App_Path + "\tmp\make.lua" + """" + " " +
                             " 0.31 " +
                             " " + """" + App_Path + "\tmp\iRead.tns" + """" + " " +
                             " " + """" + App_Path + "\tmp\iLua_tmp" + """" + " " +
                             " /d /a1 "
#If DEBUG_iLua Then
        List += " /p "
#End If
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath & "\bin"

        Dim Process As New Diagnostics.Process()
        Dim Pro_Info As New Diagnostics.ProcessStartInfo()

        Pro_Info.Arguments = List
        Pro_Info.FileName = """Central Kernel.exe"""
        Pro_Info.WorkingDirectory = Application.StartupPath + "\bin"
        If Chk_ShowCompiler.Checked = False Then
            ' Pro_Info.UseShellExecute = False
            ' Pro_Info.CreateNoWindow = True
            Pro_Info.WindowStyle = ProcessWindowStyle.Hidden
        End If
        Process.StartInfo = Pro_Info
        Process.Start()
        Me.Refresh()
        Process.WaitForExit()
    End Sub

    Friend Sub Disp(ByVal DispText As String)
        With Txt_Status
            .Focus()
            .appendtext(vbCrLf + DispText)
            .Select(.Text.Length, .TextLength)
        End With           '状态输出函数
    End Sub
    Private Sub DispNL(ByVal DispText As String)
        With Txt_Status
            .Focus()
            .AppendText(DispText)
            .Select(.Text.Length, .TextLength)
        End With
    End Sub

    Private Sub ChangeEnabled()
        If Chk_OutSourcePath.Checked = False Then
            Txt_OutputFile.Enabled = Not Txt_OutputFile.Enabled
            Btn_SaveTNS.Enabled = Txt_OutputFile.Enabled
        End If
        If Chk_Image.Checked Then
            Txt_Image.Enabled = Not Txt_Image.Enabled
            Btn_OpenImage.Enabled = Txt_Image.Enabled
        End If
        Txt_InputFile.Enabled = Not Txt_InputFile.Enabled
        Group_Advanced.Enabled = Not Group_Advanced.Enabled
        Group_TextSetting.Enabled = Group_Advanced.Enabled

        Me.Refresh()
    End Sub

    Private Sub Make_Batch()
        Dim FileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim ErrorFileList As New System.Collections.ArrayList
        Dim BatchLogPath As String = Application.StartupPath + "\Batch.log"
        
        Txt_Status.Text = ""

        WriteBatchLogBegin()
        ChangeEnabled()

        WriteBatchLog("开始读取文件列表......", False)
        Try
            FileList = My.Computer.FileSystem.GetFiles(Txt_InputFile.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
        Catch ex As DirectoryNotFoundException
            Disp("源文件目录不存在，终止")
            WriteBatchLog("源文件目录不存在,终止")
            WriteBatchLogEnd()
            ChangeEnabled()
            Exit Sub
        Catch ex As ArgumentException
            Disp("无效的源目录，终止")
            WriteBatchLog("无效的源目录，终止")
            WriteBatchLogEnd()
            ChangeEnabled()
            Exit Sub
        End Try

        If FileList.Any = False Then
            Disp("找不到文本文档，终止")
            WriteBatchLog("找不到文本文档，终止")
            WriteBatchLogEnd()
            ChangeEnabled()
            Exit Sub
        End If
        WriteBatchLog("OK")
        WriteBatchLog("共   " & FileList.Count & "   个文件")

        If Not Chk_OutSourcePath.Checked Then
            If Not My.Computer.FileSystem.DirectoryExists(Txt_OutputFile.Text) Then
                Disp("目标目录不存在,终止")
                WriteBatchLog("目标目录不存在,终止")
                WriteBatchLogEnd()
                ChangeEnabled()
                Exit Sub
            End If
        End If

        Disp("生成初始化代码......")
        CreateDrawFile()
        Me.Refresh()
        DispNL("OK")
        WriteBatchLog("已生成draw.lua")

        Disp("生成MakeFile......")
        CreateMakeFile()
        Me.Refresh()
        DispNL("OK")
        WriteBatchLog("已生成make.lua")

        If Chk_Image.Checked Then
            Disp("开始转换图片......")
            WriteBatchLog("开始转换图片......", False)
            If Not My.Computer.FileSystem.FileExists(Txt_Image.Text) Then
                DispNL("Fail")
                Disp("找不到图片文件")
                WriteBatchLog("找不到图片文件")
                WriteBatchLogEnd()
                ChangeEnabled()
                Exit Sub
            End If
            ConverImage()
            DispNL("OK")
            WriteBatchLog("OK")
        End If

        Disp("正在复制核心代码到临时目录......")
        CopySourceFiles()
        Me.Refresh()
        DispNL("OK")
        WriteBatchLog("已复制核心代码")
        WriteBatchLog("批量转换准备完成")

        Disp("")
        Disp("批量转换开始")
        WriteBatchLog("")
        WriteBatchLog("文本批量转换及生成tns文件开始")

        Dim FileNum As Int32 = 0
        PB_Batch.Visible = True
        Lbl_BatchProgress.Visible = True
        Lbl_BatchProgress.Text = "0 / " & FileList.Count

        Dim FileName As String
        For Each FileName In FileList
            FileNum += 1
            Disp("开始转换：   " + FileName)
            WriteBatchLog(FileNum & ":   " & FileName & "    .....................", False)
            Lbl_BatchProgress.Text = FileNum & " / " & FileList.Count
            PB_Batch.Value = CInt(FileNum * 1.0 / FileList.Count * 100)

            Disp("清理临时文件中......")

            CheckPath("\tmp\iLua_tmp")
            Try
                Kill(Application.StartupPath + "\tmp\data\*.txt")
            Catch ex As FileNotFoundException
            End Try
            PB_Status.Value = 35
            DispNL("OK")

            Disp("转换文本文档......")
            MakeTxtData(FileName)
            PB_Status.Value = 65
            Me.Refresh()
            If If_TextError Then
                If_TextError = False
                DispNL("Fail")
                Disp("文本文档转换失败，请确保文本文档是ANSI编码并且没有被占用或本程序具有足够的权限进行访问。")
                WriteBatchLog("Fail:Encoding Error or NO Access Right")
                ErrorFileList.Add(FileName)
                Continue For
            End If
            DispNL("OK")
            Disp("开始生成tns文件:")
            Disp("等待编译器退出......")
            MakeTNS()
            PB_Status.Value = 90
            DispNL("OK")
            Disp("检测tns是否生成成功")
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "\tmp\iRead.tns") Then
                Disp("生成成功，写入目标路径......")
                Dim target_path = Path.GetDirectoryName(FileName)
                Dim target_name = Path.GetFileNameWithoutExtension(FileName) + ".tns"
                If Chk_OutSourcePath.Checked Then
                    Dim target = Path.Combine(target_path, target_name)
                    My.Computer.FileSystem.CopyFile(Application.StartupPath + "\tmp\iRead.tns", target, True)
                Else
                    My.Computer.FileSystem.CopyFile(Application.StartupPath + "\tmp\iRead.tns", Txt_OutputFile.Text + "\" + target_name, True)
                End If

                PB_Status.Value = 100
                DispNL("OK")
            Else
                Disp("生成失败")
                WriteBatchLog("Fail:Compile Error")
                ErrorFileList.Add(FileName)
                Continue For
            End If
            Disp("转换完成")
            WriteBatchLog("Success")
            Disp("")
        Next
        WriteBatchLog("文本批量转换及生成tns文件结束")
        If ErrorFileList.Count > 0 Then
            Disp("有" & ErrorFileList.Count & "个文件转换失败，详情请参考本程序目录下的Batch.log文件")
            WriteBatchLog("")
            WriteBatchLog("失败文件列表:")
            For Each FileName In ErrorFileList
                WriteBatchLog(FileName)
            Next
        End If
        Disp("")
        Disp("批量转换完成")

        WriteBatchLogEnd()
        ChangeEnabled()
    End Sub
    Private Sub Make_Simple()
        ChangeEnabled()

        PB_Status.Value = 0
        Txt_Status.Text = ""

        Disp("清理临时文件中......")
        CleanTmp()
        DispNL("OK")

        Disp("生成初始化代码......")
        CreateDrawFile()
        PB_Status.Value = 15
        Me.Refresh()
        DispNL("OK")

        Disp("生成MakeFile......")
        CreateMakeFile()
        PB_Status.Value = 30
        Me.Refresh()
        DispNL("OK")

        Disp("正在复制核心代码到临时目录......")
        CopySourceFiles()
        PB_Status.Value = 35
        Me.Refresh()
        DispNL("OK")

        If Chk_Image.Checked Then
            Disp("开始转换图片......")
            If Not My.Computer.FileSystem.FileExists(Txt_Image.Text) Then
                DispNL("Fail")
                Disp("找不到图片文件")
                ChangeEnabled()
                Exit Sub
            End If
            ConverImage()
            DispNL("OK")
        End If



        Disp("转换文本文档......")
        MakeTxtData(Txt_InputFile.Text)
        PB_Status.Value = 45
        Me.Refresh()
        If If_TextError Then
            If_TextError = False
            DispNL("Fail")
            Disp("文本文档转换失败，请确保文本文档是ANSI编码并且没有被占用或本程序具有足够的权限进行访问。")
            ChangeEnabled()
            Exit Sub
        End If
        DispNL("OK")

        PB_Status.Value = 75
        

        Disp("开始生成tns文件:")
        Disp("等待编译器退出......")
        MakeTNS()
        PB_Status.Value = 90
        DispNL("OK")
        Disp("检测tns是否生成成功")

        If My.Computer.FileSystem.FileExists(Application.StartupPath + "\tmp\iRead.tns") Then
            Disp("生成成功，写入目标路径......")
            If Chk_OutSourcePath.Checked Then
                Dim target_path = Path.GetDirectoryName(Txt_InputFile.Text)
                Dim target_name = Path.GetFileNameWithoutExtension(Txt_InputFile.Text) + ".tns"
                Dim target = Path.Combine(target_path, target_name)
                Try
                    My.Computer.FileSystem.CopyFile(Application.StartupPath + "\tmp\iRead.tns", target, FileIO.UIOption.AllDialogs)
                Catch ex As System.OperationCanceledException
                    DispNL("Fail")
                    Disp("用户取消")
                    ChangeEnabled()
                    Exit Sub
                End Try
            Else
                Dim checkpath As String = ""
                Try
                    checkpath = Path.GetDirectoryName(Txt_OutputFile.Text)
                Catch ex As ArgumentException
                    DispNL("Fail")
                    Disp("目标路径不存在，文件已输出至\tmp\iRead.tns，本程序下次启动时将会予以清理")
                    ChangeEnabled()
                    Exit Sub
                End Try

                If (checkpath <> Nothing) AndAlso (Not My.Computer.FileSystem.DirectoryExists(Path.GetDirectoryName(Txt_OutputFile.Text))) Then
                    DispNL("Fail")
                    Disp("目标路径不存在，文件已输出至\tmp\iRead.tns，本程序下次启动时将会予以清理")
                    ChangeEnabled()
                    Exit Sub
                End If

                My.Computer.FileSystem.CopyFile(Application.StartupPath + "\tmp\iRead.tns", Txt_OutputFile.Text, True)
            End If

            PB_Status.Value = 100
            DispNL("OK")
        Else
            Disp("生成失败")
        End If
        ChangeEnabled()
    End Sub

    Private Sub Btn_Make_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Make.Click

        Dim TimeStart As Double = Microsoft.VisualBasic.DateAndTime.Timer

        PB_Batch.Visible = False
        Lbl_BatchProgress.Visible = False
        If Chk_Batch.Checked Then
            Make_Batch()
        Else
            Make_Simple()
        End If
        Dim TimeTotal As Double = Microsoft.VisualBasic.DateAndTime.Timer - TimeStart
        Disp("共用时:" & TimeTotal.ToString(("F")) & "s")
    End Sub
End Class
