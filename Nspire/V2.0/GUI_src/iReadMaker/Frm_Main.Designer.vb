<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Main))
        Me.Btn_Make = New System.Windows.Forms.Button()
        Me.Txt_Status = New System.Windows.Forms.TextBox()
        Me.Txt_InputFile = New System.Windows.Forms.TextBox()
        Me.Txt_OutputFile = New System.Windows.Forms.TextBox()
        Me.Lbl_Open = New System.Windows.Forms.Label()
        Me.Lbl_Save = New System.Windows.Forms.Label()
        Me.PB_Status = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Image = New System.Windows.Forms.TextBox()
        Me.Btn_OpenTxt = New System.Windows.Forms.Button()
        Me.Btn_SaveTNS = New System.Windows.Forms.Button()
        Me.Btn_OpenImage = New System.Windows.Forms.Button()
        Me.Btn_ChooseForeColor = New System.Windows.Forms.Button()
        Me.Btn_ChooseBackColor = New System.Windows.Forms.Button()
        Me.Group_TextSetting = New System.Windows.Forms.GroupBox()
        Me.Txt_Height = New System.Windows.Forms.TextBox()
        Me.Chk_ChooseColor_FirstLoad = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Width = New System.Windows.Forms.TextBox()
        Me.Lbl_BackColor = New System.Windows.Forms.Label()
        Me.Lbl_ForeColor = New System.Windows.Forms.Label()
        Me.Chk_Size = New System.Windows.Forms.CheckBox()
        Me.Chk_ChooseColor = New System.Windows.Forms.CheckBox()
        Me.Group_Advanced = New System.Windows.Forms.GroupBox()
        Me.Chk_NonClip = New System.Windows.Forms.CheckBox()
        Me.Chk_ShowCompiler = New System.Windows.Forms.CheckBox()
        Me.Chk_OutSourcePath = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Interval = New System.Windows.Forms.TextBox()
        Me.Chk_Interval = New System.Windows.Forms.CheckBox()
        Me.Chk_EnglishBreakingLine = New System.Windows.Forms.CheckBox()
        Me.Chk_Divide = New System.Windows.Forms.CheckBox()
        Me.Chk_OS3_1 = New System.Windows.Forms.CheckBox()
        Me.Chk_Image = New System.Windows.Forms.CheckBox()
        Me.Btn_About = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.Open_Txt = New System.Windows.Forms.OpenFileDialog()
        Me.Open_Image = New System.Windows.Forms.OpenFileDialog()
        Me.Save_Tns = New System.Windows.Forms.SaveFileDialog()
        Me.Open_Folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.Save_Folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.PB_Batch = New System.Windows.Forms.ProgressBar()
        Me.Lbl_BatchProgress = New System.Windows.Forms.Label()
        Me.Chk_ProfessionalMode = New System.Windows.Forms.CheckBox()
        Me.Chk_Batch = New System.Windows.Forms.CheckBox()
        Me.Color_ForeColor = New System.Windows.Forms.ColorDialog()
        Me.Color_BackColor = New System.Windows.Forms.ColorDialog()
        Me.Group_TextSetting.SuspendLayout()
        Me.Group_Advanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Make
        '
        Me.Btn_Make.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_Make.Location = New System.Drawing.Point(915, 33)
        Me.Btn_Make.Name = "Btn_Make"
        Me.Btn_Make.Size = New System.Drawing.Size(121, 157)
        Me.Btn_Make.TabIndex = 0
        Me.Btn_Make.Text = "Make！"
        Me.Btn_Make.UseVisualStyleBackColor = True
        '
        'Txt_Status
        '
        Me.Txt_Status.BackColor = System.Drawing.Color.Black
        Me.Txt_Status.ForeColor = System.Drawing.Color.Lime
        Me.Txt_Status.Location = New System.Drawing.Point(17, 324)
        Me.Txt_Status.Multiline = True
        Me.Txt_Status.Name = "Txt_Status"
        Me.Txt_Status.ReadOnly = True
        Me.Txt_Status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Status.Size = New System.Drawing.Size(441, 261)
        Me.Txt_Status.TabIndex = 14
        '
        'Txt_InputFile
        '
        Me.Txt_InputFile.Location = New System.Drawing.Point(241, 33)
        Me.Txt_InputFile.Multiline = True
        Me.Txt_InputFile.Name = "Txt_InputFile"
        Me.Txt_InputFile.Size = New System.Drawing.Size(557, 43)
        Me.Txt_InputFile.TabIndex = 15
        '
        'Txt_OutputFile
        '
        Me.Txt_OutputFile.Location = New System.Drawing.Point(241, 94)
        Me.Txt_OutputFile.Multiline = True
        Me.Txt_OutputFile.Name = "Txt_OutputFile"
        Me.Txt_OutputFile.Size = New System.Drawing.Size(557, 41)
        Me.Txt_OutputFile.TabIndex = 16
        '
        'Lbl_Open
        '
        Me.Lbl_Open.AutoSize = True
        Me.Lbl_Open.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_Open.Location = New System.Drawing.Point(85, 33)
        Me.Lbl_Open.Name = "Lbl_Open"
        Me.Lbl_Open.Size = New System.Drawing.Size(136, 27)
        Me.Lbl_Open.TabIndex = 17
        Me.Lbl_Open.Text = "txt文件路径："
        '
        'Lbl_Save
        '
        Me.Lbl_Save.AutoSize = True
        Me.Lbl_Save.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_Save.Location = New System.Drawing.Point(41, 89)
        Me.Lbl_Save.Name = "Lbl_Save"
        Me.Lbl_Save.Size = New System.Drawing.Size(180, 27)
        Me.Lbl_Save.TabIndex = 18
        Me.Lbl_Save.Text = "目标tns文件路径："
        '
        'PB_Status
        '
        Me.PB_Status.Cursor = System.Windows.Forms.Cursors.Default
        Me.PB_Status.Location = New System.Drawing.Point(15, 274)
        Me.PB_Status.Name = "PB_Status"
        Me.PB_Status.Size = New System.Drawing.Size(441, 35)
        Me.PB_Status.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 27)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "背景图片路径："
        '
        'Txt_Image
        '
        Me.Txt_Image.Enabled = False
        Me.Txt_Image.Location = New System.Drawing.Point(241, 149)
        Me.Txt_Image.Multiline = True
        Me.Txt_Image.Name = "Txt_Image"
        Me.Txt_Image.Size = New System.Drawing.Size(557, 41)
        Me.Txt_Image.TabIndex = 23
        '
        'Btn_OpenTxt
        '
        Me.Btn_OpenTxt.Location = New System.Drawing.Point(822, 33)
        Me.Btn_OpenTxt.Name = "Btn_OpenTxt"
        Me.Btn_OpenTxt.Size = New System.Drawing.Size(75, 43)
        Me.Btn_OpenTxt.TabIndex = 26
        Me.Btn_OpenTxt.Text = "..."
        Me.Btn_OpenTxt.UseVisualStyleBackColor = True
        '
        'Btn_SaveTNS
        '
        Me.Btn_SaveTNS.Location = New System.Drawing.Point(822, 94)
        Me.Btn_SaveTNS.Name = "Btn_SaveTNS"
        Me.Btn_SaveTNS.Size = New System.Drawing.Size(75, 42)
        Me.Btn_SaveTNS.TabIndex = 27
        Me.Btn_SaveTNS.Text = "..."
        Me.Btn_SaveTNS.UseVisualStyleBackColor = True
        '
        'Btn_OpenImage
        '
        Me.Btn_OpenImage.Enabled = False
        Me.Btn_OpenImage.Location = New System.Drawing.Point(822, 149)
        Me.Btn_OpenImage.Name = "Btn_OpenImage"
        Me.Btn_OpenImage.Size = New System.Drawing.Size(75, 42)
        Me.Btn_OpenImage.TabIndex = 28
        Me.Btn_OpenImage.Text = "..."
        Me.Btn_OpenImage.UseVisualStyleBackColor = True
        '
        'Btn_ChooseForeColor
        '
        Me.Btn_ChooseForeColor.Enabled = False
        Me.Btn_ChooseForeColor.Location = New System.Drawing.Point(12, 59)
        Me.Btn_ChooseForeColor.Name = "Btn_ChooseForeColor"
        Me.Btn_ChooseForeColor.Size = New System.Drawing.Size(123, 40)
        Me.Btn_ChooseForeColor.TabIndex = 30
        Me.Btn_ChooseForeColor.Text = "选择前景色"
        Me.Btn_ChooseForeColor.UseVisualStyleBackColor = True
        '
        'Btn_ChooseBackColor
        '
        Me.Btn_ChooseBackColor.Enabled = False
        Me.Btn_ChooseBackColor.Location = New System.Drawing.Point(154, 59)
        Me.Btn_ChooseBackColor.Name = "Btn_ChooseBackColor"
        Me.Btn_ChooseBackColor.Size = New System.Drawing.Size(123, 40)
        Me.Btn_ChooseBackColor.TabIndex = 32
        Me.Btn_ChooseBackColor.Text = "选择背景色"
        Me.Btn_ChooseBackColor.UseVisualStyleBackColor = True
        '
        'Group_TextSetting
        '
        Me.Group_TextSetting.Controls.Add(Me.Txt_Height)
        Me.Group_TextSetting.Controls.Add(Me.Chk_ChooseColor_FirstLoad)
        Me.Group_TextSetting.Controls.Add(Me.Label5)
        Me.Group_TextSetting.Controls.Add(Me.Label4)
        Me.Group_TextSetting.Controls.Add(Me.Txt_Width)
        Me.Group_TextSetting.Controls.Add(Me.Lbl_BackColor)
        Me.Group_TextSetting.Controls.Add(Me.Lbl_ForeColor)
        Me.Group_TextSetting.Controls.Add(Me.Btn_ChooseBackColor)
        Me.Group_TextSetting.Controls.Add(Me.Chk_Size)
        Me.Group_TextSetting.Controls.Add(Me.Chk_ChooseColor)
        Me.Group_TextSetting.Controls.Add(Me.Btn_ChooseForeColor)
        Me.Group_TextSetting.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Group_TextSetting.Location = New System.Drawing.Point(750, 265)
        Me.Group_TextSetting.Name = "Group_TextSetting"
        Me.Group_TextSetting.Size = New System.Drawing.Size(283, 327)
        Me.Group_TextSetting.TabIndex = 33
        Me.Group_TextSetting.TabStop = False
        Me.Group_TextSetting.Text = "文本配色及尺寸"
        Me.Group_TextSetting.Visible = False
        '
        'Txt_Height
        '
        Me.Txt_Height.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.iRead.My.MySettings.Default, "Text_Txt_Height", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Txt_Height.Enabled = False
        Me.Txt_Height.Location = New System.Drawing.Point(197, 250)
        Me.Txt_Height.Name = "Txt_Height"
        Me.Txt_Height.Size = New System.Drawing.Size(67, 31)
        Me.Txt_Height.TabIndex = 38
        Me.Txt_Height.Text = Global.iRead.My.MySettings.Default.Text_Txt_Height
        '
        'Chk_ChooseColor_FirstLoad
        '
        Me.Chk_ChooseColor_FirstLoad.AutoSize = True
        Me.Chk_ChooseColor_FirstLoad.Checked = Global.iRead.My.MySettings.Default.Text_Chk_ChooseColor_FirstLoad
        Me.Chk_ChooseColor_FirstLoad.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Text_Chk_ChooseColor_FirstLoad", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_ChooseColor_FirstLoad.Enabled = False
        Me.Chk_ChooseColor_FirstLoad.Location = New System.Drawing.Point(12, 287)
        Me.Chk_ChooseColor_FirstLoad.Name = "Chk_ChooseColor_FirstLoad"
        Me.Chk_ChooseColor_FirstLoad.Size = New System.Drawing.Size(224, 29)
        Me.Chk_ChooseColor_FirstLoad.TabIndex = 39
        Me.Chk_ChooseColor_FirstLoad.Text = "启动时应用自定义配色"
        Me.Chk_ChooseColor_FirstLoad.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 25)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "高："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 25)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "宽："
        '
        'Txt_Width
        '
        Me.Txt_Width.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.iRead.My.MySettings.Default, "Text_Txt_Width", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Txt_Width.Enabled = False
        Me.Txt_Width.Location = New System.Drawing.Point(62, 250)
        Me.Txt_Width.Name = "Txt_Width"
        Me.Txt_Width.Size = New System.Drawing.Size(67, 31)
        Me.Txt_Width.TabIndex = 35
        Me.Txt_Width.Text = Global.iRead.My.MySettings.Default.Text_Txt_Width
        '
        'Lbl_BackColor
        '
        Me.Lbl_BackColor.AutoSize = True
        Me.Lbl_BackColor.Location = New System.Drawing.Point(162, 108)
        Me.Lbl_BackColor.Name = "Lbl_BackColor"
        Me.Lbl_BackColor.Size = New System.Drawing.Size(74, 100)
        Me.Lbl_BackColor.TabIndex = 34
        Me.Lbl_BackColor.Text = "背景色:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "R:255" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "G:255" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "B:255" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Lbl_ForeColor
        '
        Me.Lbl_ForeColor.AutoSize = True
        Me.Lbl_ForeColor.Location = New System.Drawing.Point(55, 108)
        Me.Lbl_ForeColor.Name = "Lbl_ForeColor"
        Me.Lbl_ForeColor.Size = New System.Drawing.Size(74, 100)
        Me.Lbl_ForeColor.TabIndex = 33
        Me.Lbl_ForeColor.Text = "前景色:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "R:0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "G:0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "B:0"
        '
        'Chk_Size
        '
        Me.Chk_Size.AutoSize = True
        Me.Chk_Size.Checked = Global.iRead.My.MySettings.Default.Text_Chk_Size
        Me.Chk_Size.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Text_Chk_Size", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_Size.Location = New System.Drawing.Point(12, 211)
        Me.Chk_Size.Name = "Chk_Size"
        Me.Chk_Size.Size = New System.Drawing.Size(167, 29)
        Me.Chk_Size.TabIndex = 31
        Me.Chk_Size.Text = "自定义文本尺寸"
        Me.Chk_Size.UseVisualStyleBackColor = True
        '
        'Chk_ChooseColor
        '
        Me.Chk_ChooseColor.AutoSize = True
        Me.Chk_ChooseColor.Checked = Global.iRead.My.MySettings.Default.Text_Chk_ChooseColor
        Me.Chk_ChooseColor.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Text_Chk_ChooseColor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_ChooseColor.Location = New System.Drawing.Point(12, 23)
        Me.Chk_ChooseColor.Name = "Chk_ChooseColor"
        Me.Chk_ChooseColor.Size = New System.Drawing.Size(167, 29)
        Me.Chk_ChooseColor.TabIndex = 29
        Me.Chk_ChooseColor.Text = "自定义文本配色"
        Me.Chk_ChooseColor.UseVisualStyleBackColor = True
        '
        'Group_Advanced
        '
        Me.Group_Advanced.Controls.Add(Me.Chk_NonClip)
        Me.Group_Advanced.Controls.Add(Me.Chk_ShowCompiler)
        Me.Group_Advanced.Controls.Add(Me.Chk_OutSourcePath)
        Me.Group_Advanced.Controls.Add(Me.Label6)
        Me.Group_Advanced.Controls.Add(Me.Txt_Interval)
        Me.Group_Advanced.Controls.Add(Me.Chk_Interval)
        Me.Group_Advanced.Controls.Add(Me.Chk_EnglishBreakingLine)
        Me.Group_Advanced.Controls.Add(Me.Chk_Divide)
        Me.Group_Advanced.Controls.Add(Me.Chk_OS3_1)
        Me.Group_Advanced.Controls.Add(Me.Chk_Image)
        Me.Group_Advanced.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Group_Advanced.Location = New System.Drawing.Point(492, 258)
        Me.Group_Advanced.Name = "Group_Advanced"
        Me.Group_Advanced.Size = New System.Drawing.Size(239, 334)
        Me.Group_Advanced.TabIndex = 34
        Me.Group_Advanced.TabStop = False
        Me.Group_Advanced.Text = "高级选项"
        Me.Group_Advanced.Visible = False
        '
        'Chk_NonClip
        '
        Me.Chk_NonClip.AutoSize = True
        Me.Chk_NonClip.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_NonClip
        Me.Chk_NonClip.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_NonClip", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_NonClip.Location = New System.Drawing.Point(21, 267)
        Me.Chk_NonClip.Name = "Chk_NonClip"
        Me.Chk_NonClip.Size = New System.Drawing.Size(186, 29)
        Me.Chk_NonClip.TabIndex = 42
        Me.Chk_NonClip.Text = "书签不存入剪贴板"
        Me.Chk_NonClip.UseVisualStyleBackColor = True
        '
        'Chk_ShowCompiler
        '
        Me.Chk_ShowCompiler.AutoSize = True
        Me.Chk_ShowCompiler.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_ShowCompiler
        Me.Chk_ShowCompiler.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_ShowCompiler", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_ShowCompiler.Location = New System.Drawing.Point(21, 302)
        Me.Chk_ShowCompiler.Name = "Chk_ShowCompiler"
        Me.Chk_ShowCompiler.Size = New System.Drawing.Size(167, 29)
        Me.Chk_ShowCompiler.TabIndex = 41
        Me.Chk_ShowCompiler.Text = "显示编译器窗口"
        Me.Chk_ShowCompiler.UseVisualStyleBackColor = True
        '
        'Chk_OutSourcePath
        '
        Me.Chk_OutSourcePath.AutoSize = True
        Me.Chk_OutSourcePath.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_OutPath
        Me.Chk_OutSourcePath.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_OutPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_OutSourcePath.Location = New System.Drawing.Point(21, 22)
        Me.Chk_OutSourcePath.Name = "Chk_OutSourcePath"
        Me.Chk_OutSourcePath.Size = New System.Drawing.Size(186, 29)
        Me.Chk_OutSourcePath.TabIndex = 40
        Me.Chk_OutSourcePath.Text = "输出至源文件目录"
        Me.Chk_OutSourcePath.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(103, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 25)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "秒/页"
        '
        'Txt_Interval
        '
        Me.Txt_Interval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.iRead.My.MySettings.Default, "Advanced_Txt_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Txt_Interval.Enabled = False
        Me.Txt_Interval.Location = New System.Drawing.Point(42, 197)
        Me.Txt_Interval.Name = "Txt_Interval"
        Me.Txt_Interval.Size = New System.Drawing.Size(55, 31)
        Me.Txt_Interval.TabIndex = 26
        Me.Txt_Interval.Text = Global.iRead.My.MySettings.Default.Advanced_Txt_Interval
        '
        'Chk_Interval
        '
        Me.Chk_Interval.AutoSize = True
        Me.Chk_Interval.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_Interval
        Me.Chk_Interval.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_Interval.Location = New System.Drawing.Point(21, 162)
        Me.Chk_Interval.Name = "Chk_Interval"
        Me.Chk_Interval.Size = New System.Drawing.Size(205, 29)
        Me.Chk_Interval.TabIndex = 25
        Me.Chk_Interval.Text = "自定义自动翻页速度"
        Me.Chk_Interval.UseVisualStyleBackColor = True
        '
        'Chk_EnglishBreakingLine
        '
        Me.Chk_EnglishBreakingLine.AutoSize = True
        Me.Chk_EnglishBreakingLine.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_EnglishBreakingLine
        Me.Chk_EnglishBreakingLine.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_EnglishBreakingLine", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_EnglishBreakingLine.Location = New System.Drawing.Point(21, 127)
        Me.Chk_EnglishBreakingLine.Name = "Chk_EnglishBreakingLine"
        Me.Chk_EnglishBreakingLine.Size = New System.Drawing.Size(148, 29)
        Me.Chk_EnglishBreakingLine.TabIndex = 21
        Me.Chk_EnglishBreakingLine.Text = "英文自动换行"
        Me.Chk_EnglishBreakingLine.UseVisualStyleBackColor = True
        '
        'Chk_Divide
        '
        Me.Chk_Divide.AutoSize = True
        Me.Chk_Divide.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_Divide
        Me.Chk_Divide.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_Divide", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_Divide.Location = New System.Drawing.Point(21, 57)
        Me.Chk_Divide.Name = "Chk_Divide"
        Me.Chk_Divide.Size = New System.Drawing.Size(91, 29)
        Me.Chk_Divide.TabIndex = 20
        Me.Chk_Divide.Text = "预分页"
        Me.Chk_Divide.UseVisualStyleBackColor = True
        '
        'Chk_OS3_1
        '
        Me.Chk_OS3_1.AutoSize = True
        Me.Chk_OS3_1.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_OS3_1
        Me.Chk_OS3_1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_OS3_1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_OS3_1.Enabled = False
        Me.Chk_OS3_1.Location = New System.Drawing.Point(21, 92)
        Me.Chk_OS3_1.Name = "Chk_OS3_1"
        Me.Chk_OS3_1.Size = New System.Drawing.Size(163, 29)
        Me.Chk_OS3_1.TabIndex = 24
        Me.Chk_OS3_1.Text = "OS3.1文本尺寸"
        Me.Chk_OS3_1.UseVisualStyleBackColor = True
        '
        'Chk_Image
        '
        Me.Chk_Image.AutoSize = True
        Me.Chk_Image.Checked = Global.iRead.My.MySettings.Default.Advanced_Chk_Image
        Me.Chk_Image.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Advanced_Chk_Image", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_Image.Location = New System.Drawing.Point(21, 232)
        Me.Chk_Image.Name = "Chk_Image"
        Me.Chk_Image.Size = New System.Drawing.Size(148, 29)
        Me.Chk_Image.TabIndex = 25
        Me.Chk_Image.Text = "使用背景图片"
        Me.Chk_Image.UseVisualStyleBackColor = True
        '
        'Btn_About
        '
        Me.Btn_About.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_About.Location = New System.Drawing.Point(768, 205)
        Me.Btn_About.Name = "Btn_About"
        Me.Btn_About.Size = New System.Drawing.Size(117, 49)
        Me.Btn_About.TabIndex = 25
        Me.Btn_About.Text = "关于"
        Me.Btn_About.UseVisualStyleBackColor = True
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_Exit.Location = New System.Drawing.Point(910, 205)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(117, 49)
        Me.Btn_Exit.TabIndex = 35
        Me.Btn_Exit.Text = "退出"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'Open_Txt
        '
        Me.Open_Txt.DefaultExt = "txt"
        Me.Open_Txt.Filter = "ANSI文本文档|*.txt"
        Me.Open_Txt.Title = "打开文本文档"
        '
        'Open_Image
        '
        Me.Open_Image.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff;*.wmf"
        '
        'Save_Tns
        '
        Me.Save_Tns.DefaultExt = "tns"
        Me.Save_Tns.Filter = "TI-Nspire专用格式|*.tns"
        Me.Save_Tns.Title = "保存到TNS文件"
        '
        'Open_Folder
        '
        Me.Open_Folder.Description = "选择文本文档所在文件夹"
        Me.Open_Folder.ShowNewFolderButton = False
        '
        'PB_Batch
        '
        Me.PB_Batch.Location = New System.Drawing.Point(15, 233)
        Me.PB_Batch.Name = "PB_Batch"
        Me.PB_Batch.Size = New System.Drawing.Size(443, 35)
        Me.PB_Batch.TabIndex = 37
        Me.PB_Batch.Visible = False
        '
        'Lbl_BatchProgress
        '
        Me.Lbl_BatchProgress.AutoSize = True
        Me.Lbl_BatchProgress.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lbl_BatchProgress.Location = New System.Drawing.Point(183, 205)
        Me.Lbl_BatchProgress.Name = "Lbl_BatchProgress"
        Me.Lbl_BatchProgress.Size = New System.Drawing.Size(72, 25)
        Me.Lbl_BatchProgress.TabIndex = 38
        Me.Lbl_BatchProgress.Text = "Label1"
        Me.Lbl_BatchProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lbl_BatchProgress.Visible = False
        '
        'Chk_ProfessionalMode
        '
        Me.Chk_ProfessionalMode.AutoSize = True
        Me.Chk_ProfessionalMode.Checked = Global.iRead.My.MySettings.Default.Form_Chk_ProfessionalMode
        Me.Chk_ProfessionalMode.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Form_Chk_ProfessionalMode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_ProfessionalMode.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Chk_ProfessionalMode.Location = New System.Drawing.Point(490, 205)
        Me.Chk_ProfessionalMode.Name = "Chk_ProfessionalMode"
        Me.Chk_ProfessionalMode.Size = New System.Drawing.Size(132, 35)
        Me.Chk_ProfessionalMode.TabIndex = 39
        Me.Chk_ProfessionalMode.Text = "专家模式"
        Me.Chk_ProfessionalMode.UseVisualStyleBackColor = True
        '
        'Chk_Batch
        '
        Me.Chk_Batch.AutoSize = True
        Me.Chk_Batch.Checked = Global.iRead.My.MySettings.Default.Form_Chk_Batch
        Me.Chk_Batch.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iRead.My.MySettings.Default, "Form_Chk_Batch", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Chk_Batch.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Chk_Batch.Location = New System.Drawing.Point(628, 208)
        Me.Chk_Batch.Name = "Chk_Batch"
        Me.Chk_Batch.Size = New System.Drawing.Size(114, 31)
        Me.Chk_Batch.TabIndex = 36
        Me.Chk_Batch.Text = "批量生成"
        Me.Chk_Batch.UseVisualStyleBackColor = True
        '
        'Color_ForeColor
        '
        Me.Color_ForeColor.Color = Global.iRead.My.MySettings.Default.Text_Color_ForeColor
        '
        'Color_BackColor
        '
        Me.Color_BackColor.Color = Global.iRead.My.MySettings.Default.Text_Color_BackColor
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1045, 597)
        Me.Controls.Add(Me.Chk_ProfessionalMode)
        Me.Controls.Add(Me.Lbl_BatchProgress)
        Me.Controls.Add(Me.PB_Batch)
        Me.Controls.Add(Me.Chk_Batch)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_About)
        Me.Controls.Add(Me.Group_Advanced)
        Me.Controls.Add(Me.Group_TextSetting)
        Me.Controls.Add(Me.Btn_OpenImage)
        Me.Controls.Add(Me.Btn_SaveTNS)
        Me.Controls.Add(Me.Btn_OpenTxt)
        Me.Controls.Add(Me.Txt_Image)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PB_Status)
        Me.Controls.Add(Me.Lbl_Save)
        Me.Controls.Add(Me.Lbl_Open)
        Me.Controls.Add(Me.Txt_OutputFile)
        Me.Controls.Add(Me.Txt_InputFile)
        Me.Controls.Add(Me.Txt_Status)
        Me.Controls.Add(Me.Btn_Make)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Main"
        Me.Text = "iRead II 文件生成器"
        Me.Group_TextSetting.ResumeLayout(False)
        Me.Group_TextSetting.PerformLayout()
        Me.Group_Advanced.ResumeLayout(False)
        Me.Group_Advanced.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Make As System.Windows.Forms.Button
    Friend WithEvents Txt_Status As System.Windows.Forms.TextBox
    Friend WithEvents Txt_InputFile As System.Windows.Forms.TextBox
    Friend WithEvents Txt_OutputFile As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Open As System.Windows.Forms.Label
    Friend WithEvents Lbl_Save As System.Windows.Forms.Label
    Friend WithEvents PB_Status As System.Windows.Forms.ProgressBar
    Friend WithEvents Chk_Divide As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_EnglishBreakingLine As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Image As System.Windows.Forms.TextBox
    Friend WithEvents Chk_OS3_1 As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Image As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_OpenTxt As System.Windows.Forms.Button
    Friend WithEvents Btn_SaveTNS As System.Windows.Forms.Button
    Friend WithEvents Btn_OpenImage As System.Windows.Forms.Button
    Friend WithEvents Chk_ChooseColor As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_ChooseForeColor As System.Windows.Forms.Button
    Friend WithEvents Chk_Size As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_ChooseBackColor As System.Windows.Forms.Button
    Friend WithEvents Group_TextSetting As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_BackColor As System.Windows.Forms.Label
    Friend WithEvents Txt_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Width As System.Windows.Forms.TextBox
    Friend WithEvents Group_Advanced As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_About As System.Windows.Forms.Button
    Friend WithEvents Btn_Exit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Interval As System.Windows.Forms.TextBox
    Friend WithEvents Chk_Interval As System.Windows.Forms.CheckBox
    Friend WithEvents Color_ForeColor As System.Windows.Forms.ColorDialog
    Friend WithEvents Color_BackColor As System.Windows.Forms.ColorDialog
    Friend WithEvents Open_Txt As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Open_Image As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Save_Tns As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Chk_ChooseColor_FirstLoad As System.Windows.Forms.CheckBox
    Friend WithEvents Lbl_ForeColor As System.Windows.Forms.Label
    Friend WithEvents Chk_OutSourcePath As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_ShowCompiler As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_NonClip As System.Windows.Forms.CheckBox
    Friend WithEvents Open_Folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Chk_Batch As System.Windows.Forms.CheckBox
    Friend WithEvents Save_Folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PB_Batch As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_BatchProgress As System.Windows.Forms.Label
    Friend WithEvents Chk_ProfessionalMode As System.Windows.Forms.CheckBox

End Class
