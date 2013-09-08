--[[
    iRead Kernel V2.0  Final
    许可信息:
    中国大陆(Chinese Mainland)：
    本程序采用知识共享 署名-相同方式共享 3.0 中国大陆 许可协议进行许可。要查看该许可协议，
    可访问 http://creativecommons.org/licenses/by-sa/3.0/cn/ 或者写信到
    Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.

    其他国家/地区(Other countries/regions):
    This program is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
    To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/
    or send a letter to
    Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.

    作者:wtof1996
    更新日期：2013-7-18 21:07:36

]]--

--------           Init            --------
iRead_Text = class();

--初始化属性
function iRead_Text:init(TextData)

    self.TextColor = {["R"] = 0, ["G"] = 0, ["B"] = 0}; --默认前景色，即文本颜色
    self.BackBoradColor = {["R"] = 255, ["G"] = 255, ["B"] = 255}; --默认背景色
    self.SystemColor = {
                        ["Default"] = {
                                                ["FR"] = 0, ["FG"] = 0, ["FB"] = 0,
                                                ["BR"] = 255,["BG"] = 255, ["BB"] = 255
                                           },
                        ["Night_Blue"] = {
                                                    ["FR"] = 16, ["FG"] = 168, ["FB"] = 233,
                                                    ["BR"] = 0, ["BG"] = 0, ["BB"] = 0
                                                },
                        ["Night_DOS"] = {
                                                    ["FR"] = 192 , ["FG"] = 192, ["FB"] = 192,
                                                    ["BR"] = 0, ["BG"] = 0, ["BB"] = 0
                                                },
                        ["Night_Green"] = {
                                                        ["FR"] = 142, ["FG"] = 255, ["FB"] = 142,
                                                        ["BR"] = 0, ["BG"] = 0, ["BB"] = 0
                                                },
                        ["High_Constrat_Purple"] = {
                                                        ["FR"] = 170 , ["FG"] = 10, ["FB"] = 170,
                                                        ["BR"] = 0, ["BG"] = 0, ["BB"] = 0
                                                },
                        ["Customize"] = {
                                                ["FR"] = 0, ["FG"] = 0, ["FB"] = 0,
                                                ["BR"] = 255,["BG"] = 255, ["BB"] = 255
                                                }
                        };
    --软件自带配色及用户自定义配色,FR,FG,FB为前景色RGB分量,BR,BG,BB为背景色分量

    self.LineHeight = 23;  --每行文本高度
    self.TextBuffer = {};  --当前显示页面的文本缓存

    self.BackBoradImage = nil;  --背景图片
    self.IfShowBackBoradImage = true;--是否显示背景图片

    self.AutoPageDownInterval = nil; --自动翻页时间间隔
    self.IfAuto = false;             --是否开启自动翻页

    self.Pointer  = 1;     --文本数据索引“指针”，默认指向文本开头
    self.LinePointer = 1;  --行数据索引“指针”
    self.PageNo = 0;       --当前页索引"指针"
    self.MaxPage = 0;      --当前最大可用页数
    self.Page = {};        --分页信息
    self.Line = {};        --分行信息
    self.IfDivided = false; --是否启用预分页


    self.MaxTextWidth = 305;  --文本宽度
    self.MaxTextHeight= 184;  --文本高度
    self.TextHeightDistance = 0;  --行距
    self.DefaultDividePageNumber = 100; --每次缓存页面数
    self.IfBreakingLine = false;  --英文自动换行
    self.PointerNow = 0;      --当前页面最后一个字符对应在文本数据中的索引值，用于计算阅读进度
    self.LabelX = 0;          --状态栏X坐标
    self.LabelY = 210;        --状态栏Y坐标
    self.LabelFontSize = 9;   --状态栏字号(由于均为ASCII字符所以可以调整)

    self.BookMarker = 1;      --书签
    self.SaveToClipboard = true; --是否存入剪贴板
    self.IfInputJumper = false;  --当前是否显示跳页界面
    self.JumpTarget = 0;        --用户试图跳转的页面
    self.InputText = "";        --用户输入内容
    self.InputNotice = {
                                    "请输入目标页码,超出范围将跳至最后一页" ,
                                    "esc退出  enter确认 del退"..string.uchar(26684),
                                    "提示:若超出缓存范围可能会较慢",
                                    "当前页面/已缓存页面数:",
                       };
    --跳页提示内容

    self.About = {
                            "关于iRead II",
                            "作者:wtof1996",
                            "代号:Faith",
                            "测试:imath,ExAcler,chsi,urill,硕雪X忆,皮丘,",
                            "禾末,nbzwt,diameter,老友,虫毛毛,wakaka101,",
                            "零点五,还俗的唐朝和尚,DAS,Suica",
                            "本程序采用 CC-BY-SA 3.0进行授权",
                            "wtof1996 Copyright 2013 Some rights reserved",
                             "请按esc返回"
                            };
    --关于信息内容
    self.IfShowAbout = false;
    --是否显示关于界面

    self.OS = "3.2"; --OS版本
    self.IfColor = platform.isColorDisplay(); --当前是否彩屏
    self.IfDraw = true;  --是否结束初始化
end
--------          Check Character Type           --------
--以下函数均仿照cctype库中相关函数所编写

--检查char是否是字母
function iRead_Text:IsAlpha(char)
    if(char >= 65 and char <= 90) then       return true;
    elseif(char >= 97 and char <= 122) then  return true;
    else                                     return false;
    end
end

--检查char是否是数字
function iRead_Text:IsNumber(char)
    if(char < 48 or char > 57) then
        return false;
    end
    return true;
end
--------           OS Adapt            --------
--自适应

--试图使用domain函数以检查OS版本，若不支持则为3.1
function iRead_Text:OSChecker()
    local str, err;
    str, err = math.eval("domain(1,1)");
    if(err == "incompatible data type") then
        self.OS = "3.1";
    end
end

--根据屏幕颜色及系统版本调整参数
function iRead_Text:SelfAdapt()
    if(self.OS == "3.1") then
        self.MaxTextHeight = 175;
        self.MaxTextWidth = 300;
        self.LabelY = 200;
        self.LabelFontSize= 7;  --OS 3.1文本尺寸
    end
    if(self.IfColor == false) then
        self.IfShowBackBoradImage = false;
        self:SetColor("Default");
    end             --黑白屏则不开启背景图片及使用白底黑字
end

--------           Menu Function            --------
--菜单相关函数

--切换背景图片是否显示
function iRead_Text:SwitchBackBoradImageShow()
    self.IfShowBackBoradImage = not self.IfShowBackBoradImage;
    platform.window:invalidate();
end

--读取用户自定义配色
function iRead_Text:LoadColorCustomize()
    local F, B;
    F = var.recall("iread_color_f");--前景色
    if(F == nil) then
        return;
    end

    B = var.recall("iread_color_b");--背景色
    if(B == nil) then
        return;
    end

    for i = 1, 3 do
        F[i] = tonumber(F[i]);
        if(F[i] == nil) then
            return;
        end
        F[i] = math.floor(F[i]);
        if (F[i] < 0) or (F[i] > 255) then
            return;
        end
        B[i] = tonumber(B[i]);
        if(B[i] == nil) then
            return;
        end
        B[i] = math.floor(B[i]);
        if (B[i] < 0) or (B[i] > 255) then
            return;
        end
    end
    --取整及检查是否输入有误

    self.SystemColor.Customize.FR = F[1];
    self.SystemColor.Customize.FG = F[2];
    self.SystemColor.Customize.FB = F[3];
    self.SystemColor.Customize.BR = B[1];
    self.SystemColor.Customize.BG = B[2];
    self.SystemColor.Customize.BB = B[3];
    --检查无误则分配给各个RGB分量

    self:SetColor("Customize");--载入自定义配色

end


--设置文本配色
function iRead_Text:SetColor(ColorIndex)
    if(self.SystemColor[ColorIndex] ~= nil) then
        local Color = self.SystemColor[ColorIndex];
        self.TextColor.R = Color.FR;
        self.TextColor.G = Color.FG;
        self.TextColor.B = Color.FB;

        self.BackBoradColor.R = Color.BR;
        self.BackBoradColor.G = Color.BG;
        self.BackBoradColor.B = Color.BB;

        platform.window:invalidate();
    end
end


--读取用户自定义自动翻页速度
function iRead_Text:LoadAutoPageDownCustomize()
    local speed;
    speed = tonumber(var.recall("iread_interval"));
    if(speed == nil) or (speed <= 0) then
        return;
    end

    self.AutoPageDownInterval = speed;
end

--------           BookMarker Function            --------
--书签相关函数

--存储书签
function iRead_Text:SaveMarker()
    var.store("iread_bookmarker", self.PageNo);
    self.BookMarker = self.PageNo;
    if (self.SaveToClipboard == true) then
        clipboard.addText(tostring(self.PageNo));
    end
end

--切换是否使用剪贴板书签
function iRead_Text:SwitchSaveToClipboard()
    self.SaveToClipboard = not self.SaveToClipboard;
end

--从剪贴板提取书签
function iRead_Text:ReloadMarkerFromClip()
    local target = clipboard.getText();
    target = tonumber(target);
    if(target ~= nil) then
        var.store("iread_bookmarker", target);
        self:ReloadMarker();
        --若有效则存入并载入书签
    end

end

--提取书签
function iRead_Text:ReloadMarker()
    local list, target;
    list = var.list();
    for i in pairs(list) do
        if(list[i] == "iread_bookmarker") then
            target = var.recall("iread_bookmarker");
            if(target == nil or target < 1 or target > self.MaxPage) then
                var.store("iread_bookmarker",  self.BookMarker);
                return;
            end
            --读取并检查有效性

            self.BookMarker = target;

            if (self.IfDraw == true) then
                return;
            end
            --若当前正在初始化则不跳至书签所在页面

            self.PageNo = target;

            break;
        end
    end
    if (self.IfDraw == false) then
        self:PageJumper();
        --跳页
    end

end
--------           About & PageJumper            --------
--关于界面及跳页相关

--显示跳页界面
function iRead_Text:ShowPageJumper()
	self.IfInputJumper = true;
	platform.window:invalidate();
end

function iRead_Text:PageJumper()
    local tmp;
    while(self.MaxPage < self.PageNo) do --如果目标页面超出当前已缓存页面
       if(self.IfDivided == true) then  --开启预分页时，直接跳至最后一页
            self.PageNo = self.MaxPage;
            break;
       end
        tmp = self.MaxPage; --当前可用页面数
        self:DividePage(self.DefaultDividePageNumber); --试图分页
        if(tmp == self.MaxPage)  then  --如果可用页面数不变
            self.PageNo = self.MaxPage;
            break;  --跳至最后一页
        end
    end
    self:SetPageBuffer();  --设置页面缓存
    platform.window:invalidate(); --刷新
end

--显示关于界面
function iRead_Text:ShowAbout()
    self.IfShowAbout = true;
    platform.window:invalidate();
end
--------           Divide Page             --------
--分页相关
--[[
    iRead II页面数据采用以下结构:
    文本数据以连续方式存储在self.TextData中，每个字符存储为其对应的UTF8数字编码

    划分页面时先分行，每行采用长度为2的一个Table存储，结构为
        {<行开始索引>，<行结束索引>}
    其中索引指的是在总文本中的位置，分行数据统一存储至self.Line中
    然后继续分页，分页数据存储在self.Page中
    然后页面仅记录当前页面第一行所在索引，由于行均连续，
    当前页面行的结束索引可根据下一页开始位置进行递推
]]--

--得到一个空行
function iRead_Text:MakeLine()
    return {0, 0};
end

--当前行转换为字符串
function iRead_Text:GetString(Line)
    local ret = "";
    for i = Line[1], Line[2] do
        ret = ret .. string.uchar(self.TextData[i]);
    end
    return ret .. "  ";
    --每行末尾加上一个空格
end

--分行算法
function iRead_Text:GetLine()
    local ret = self:MakeLine(); --得到一个空行
    ret[1] = self.Pointer;       --当前行的开始位置就是当前索引“指针”位置
    local gc = platform.gc();    --虚拟Graphic Context
    gc:begin();                  --启用虚拟Graphic Context

    local width = self.MaxTextWidth;  --当前可用宽度，初始化为最大宽度
    local CharWidth = 0;              --字符宽度
    local Char = "";                  --字符
    local LastChar = nil;             --英文自动换行时，当前行切断的位置
    local Comer = false;             --英文自动换行时用于识别是前引号还是后引号
    if(self.TextData[self.Pointer] == nil) then --当前已经越界，返回nil
        return nil;
    end

    while(width >= 0) do    --如果还有宽度剩余，那么不断往当前行中填充字符

        if(self.TextData[self.Pointer] == nil) then --越界的情况
            break;
        end

        if(self.TextData[self.Pointer] == 10) then --换行符的情况，需要注意的是在PC上转换数据时已经去除CR,此处为LF
            ret[2]= self.Pointer - 1;                           --此行结束字符前移，因为实体机上无法正常绘制LF
            self.Pointer = self.Pointer + 1;               --索引“指针”后移
            break;
        end

        Char = string.uchar(self.TextData[self.Pointer]);   --得到当前索引指针指向的UTF8代码对应的字符
        CharWidth = gc:getStringWidth(Char);                 --得到字符宽度

        if(CharWidth < width) then                                  --如果剩余宽度足够

            if(self.IfBreakingLine == true) then                --英文自动换行的情况

                if(self.TextData[self.Pointer] == 34) then      --引号
                    Comer =not Comer;                                    --切换前/后引号状态
                    if(Commer == true) then                           --前引号时
                        LastChar = self.Pointer - 1;                     --更改英文自动换行切断行的位置
                    end

                elseif(self.TextData[self.Pointer] >= 128 or self:IsAlpha(self.TextData[self.Pointer]) == false) then
                    --当前字符为非英文字符时，切断在此
                    LastChar = self.Pointer;
                end
            end
            --这样不断更新切断位置，以实现英文自动换行

            self.Pointer = self.Pointer + 1;  --索引“指针”后移，表明这个字符已经成功加入当前行
        end

        width = width - CharWidth;  --得到新的剩余宽度
    end

    if(self.IfBreakingLine == true) then        --英文自动换行切断处理
        if(LastChar ~= nil) then                       --如果存在截断位置
            if(self:IsAlpha(self.TextData[self.Pointer - 1]) == true and
                self:IsAlpha(self.TextData[self.Pointer]) == true) then --当前位置字符与上一个字符均为英文
                ret[2] = LastChar;                  --截断
                self.Pointer = LastChar + 1;  --指针重设在截断位置后
            end
        end
    end

    if(ret[2] == 0) then  --非英文自动换行的处理
        ret[2] = self.Pointer - 1;
    end

    gc:finish();  --结束调用虚拟Graphic Context
    return ret;
end

--分页算法
function iRead_Text:GetPageLines()
    local height = self.MaxTextHeight;    --当前可用高度，初始化为最大高度
    local ret = self.LinePointer;                  --当前行索引“指针”位置存储,用于返回页面开始位置

    while(height >= 0) do           --如果还有剩余宽度那么不断尝试分行
        self.Line[self.LinePointer] = self:GetLine();   --分一行
        if(self.Line[self.LinePointer] == nil) then break; end --空行的情况
        height = height - self.TextHeightDistance - self.LineHeight; --更新高度
        self.LinePointer = self.LinePointer + 1;    --移动行索引"指针"
    end
    if(self.LinePointer == ret) then --如果一行都没有分，此时已经越界，返回nil
        return nil;
    end
    return ret;         --返回页面开始位置
end

--批量分指定页数
function iRead_Text:DividePage(amount)
    if(self.IfDivided == true) then  return; end   --已经预分页的情况
    local i = self.MaxPage;                                      --当前可用页面数
    local count = 0;                                                 --分页成功数
    repeat
        self.Page[i+ 1] = self:GetPageLines();          --分一页
        if(self.Page[i + 1] == nil) then break; end   --失败则停止
        count = count + 1;
        i = i + 1;
    until(count >= amount);
    self.MaxPage = i;   --更新可用页面数
    collectgarbage();   --垃圾回收，防止可能的内存不足问题
end

--全部分页，思路基本上类似批量分页，只不过此处是试图分完为止，而不是指定数量页面
function iRead_Text:DivideAllPage()
    if(self.IfDivided == true) then  return; end
    local i = self.MaxPage;
    while(true) do
        self.Page[i + 1] = self:GetPageLines();
        if(self.Page[i + 1] == nil) then break; end
        i = i + 1;
    end
    self.MaxPage = i;
    collectgarbage();
end

--------          Change Page            --------
--翻页相关

--向下翻页
function iRead_Text:PageDown()
    if(self.IfShowAbout == true) or (self.IfInputJumper == true) then
        return;    --显示其他页面时返回
    end
    local tmp = self.MaxPage;   --当前可用页面数
    if(self.Page[self.PageNo + 1] == nil) then  --如果不足
        self:DividePage(self.DefaultDividePageNumber); --试图继续分页
        if(tmp == self.MaxPage) then --如果可用页面数不变，则表示已经到头
            return;
        end
    end
    self.PageNo = self.PageNo + 1; --向后移动页面"指针"
    self:SetPageBuffer();       --更新页面缓存
end

--向上翻页
function iRead_Text:PageUp()
    if(self.IfShowAbout == true) or (self.IfInputJumper == true) then
        return;
    end     --显示其他页面时返回
    if(self.Page[self.PageNo - 1] == nil) then  --到头的情况
        return;
    end
    self.PageNo = self.PageNo - 1;  --向前移动页面"指针"
    self:SetPageBuffer();           --更新页面缓存
end

--开始自动翻页
function iRead_Text:SetAutoPageDown()
    if(self.AutoPageDownInterval == nil or self.AutoPageDownInterval <= 0) then
        self.AutoPageDownInterval = 15;     --时间间隔不合法的情况
    end
    timer.start(self.AutoPageDownInterval);  --启动timer
    self.IfAuto = true;                                       --已经开始自动翻页
    toolpalette.enable("自动翻页", "开始", false);
    toolpalette.enable("自动翻页", "停止", true);         --更新菜单状态
end

--停止自动翻页
function iRead_Text:StopAutoPageDown()
    self.IfAuto = false;            --停止自动翻页
    timer.stop();                       --停止timer
    toolpalette.enable("自动翻页", "开始", true);
    toolpalette.enable("自动翻页", "停止", false); --更新菜单状态
end

--更新页面缓存
function iRead_Text:SetPageBuffer()
    self.TextBuffer = {};               --清空
    local page_start = self.Page[self.PageNo]; --当前页面开始行
    local page_end = 0;                                       --当前页面结束行，取决于以下两种情况
    if(self.Page[self.PageNo + 1] ~= nil) then  --不是最后一页时
        page_end = self.Page[self.PageNo + 1] - 1; --根据下一页递推
    else
        page_end = #self.Line;                                  --否则直接为最后一行
    end
    self.PointerNow = self.Line[page_end][2];      --当前页面最后一个字符在总文本中的位置，用于显示百分比进度
    local count = 1;                                                 --当前页面行号
    for i = page_start, page_end do                     --读取行数据，并且填入缓存
        self.TextBuffer[count] = self:GetString(self.Line[i]);
        count = count + 1;
    end
    self.TextBuffer[count] = nil;                           --页面缓存末尾标记
end
--------           System Events            --------
--这里对应的是相关系统事件，均从on模块的相应事件传入

--Paint  Event
function iRead_Text:paint(gc)

    if(self.IfShowAbout == true) then   --绘制关于界面
        gc:setColorRGB(255, 255, 255);
        gc:fillRect(0, 0, 320, 240);
        gc:setColorRGB(0, 0, 0);
        local Height = 20;
        for i in pairs(self.About) do
            gc:drawString(self.About[i], 0, Height);
            Height = Height + gc:getStringHeight(i);
        end
        return;
    end

    if(self.IfInputJumper == true) then --跳页界面
        gc:setColorRGB(255, 255, 255);
        gc:fillRect(0, 0, 320, 240);
        gc:setColorRGB(0, 0, 0);
        local Height = 20;
        for i in pairs(self.InputNotice) do
            gc:drawString(self.InputNotice[i], 0, Height);
            Height = Height + gc:getStringHeight(i);
        end
        local PageProgress = string.format("%d/%d",self.PageNo, self.MaxPage);
        gc:drawString(PageProgress, 0, Height);
        gc:drawString(self.InputText, 0, 140);   --绘制用户输入内容
        return;
    end

    gc:setColorRGB(self.BackBoradColor.R,
                                self.BackBoradColor.G,
                                self.BackBoradColor.B
                              );
    --设置背景色
    gc:fillRect(0, 0, 320, 240);    --清屏
    if(self.BackBoradImage ~= nil) then
        if(self.IfShowBackBoradImage == true) then
            gc:drawImage(self.BackBoradImage, 0, 0);    --绘制背景图片，注意此处会覆盖单色背景
        end
    end
    gc:setColorRGB(self.TextColor.R, self.TextColor.G, self.TextColor.B);   --设置文本颜色
    gc:setFont("sansserif", "r", self.LabelFontSize);       --设置状态栏字体
    local LabelStr = string.format("%d/%d        %.2f%%      Marker:%d",
                                   self.PageNo,
                                   self.MaxPage,
                                   (1.0 * self.PointerNow / (#self.TextData)) * 100,
                                    self.BookMarker);
                                    --合成状态栏内容
    gc:drawString(LabelStr, self.LabelX, self.LabelY); --绘制状态栏
    gc:setFont("sansserif", "r", 12);   --设置文本正文字体
    local Height = 20;
    for i in pairs(self.TextBuffer) do      --按缓存中顺序绘制每一行文本
        if(self.TextBuffer[i] == nil) then
            break;
        end
        gc:drawString(self.TextBuffer[i], 0, Height);
        Height = Height + self.TextHeightDistance + gc:getStringHeight(i);
    end
end

--CharIn Event
--用于在跳页界面中得到用户输入
function iRead_Text:charIn(char)
    if(self.IfInputJumper == false) then  --当前如果不是跳页界面直接返回
        return;
    end
    if(#char > 1) then                              --输入不是单个字符，直接返回
        return;
    end
    if(self:IsNumber(string.byte(char)) == false) then  --非数字，直接返回
        return;
    end
    self.InputText = self.InputText .. char;    --连接用户输入文本
    platform.window:invalidate();
end

--backspaceKey Event
--用于响应跳页界面中的退格以及正常界面中的提取书签快捷键
function iRead_Text:backspaceKey()
    if(self.IfShowAbout == true) then           --当前正在显示关于界面，返回
        return;
    end
    if(self.IfInputJumper == false) then        --当前显示文本正文时提取书签
        self:ReloadMarker();
        return;
    end
    self.InputText = string.sub(self.InputText, 1, #self.InputText - 1);  --截取字符串
    platform.window:invalidate();
end

--tabKey Event
--显示跳页界面
function iRead_Text:tabKey()
    self:ShowPageJumper();
end

--escapeKey Event
--退出跳页界面及关于界面
function iRead_Text:escapeKey()
    if(self.IfInputJumper == true) then
        self.IfInputJumper = false;
        self.InputText = "";
        self.JumpTarget = 0;        --重置
        platform.window:invalidate();
    end
    if(self.IfShowAbout == true) then
        self.IfShowAbout = false;
        platform.window:invalidate();
    end

end

--enterKey Event
--跳页界面中的确定，以及正常界面中的保存书签
function iRead_Text:enterKey()
    if(self.IfShowAbout == true) then   --当前正在显示关于界面，返回
        return;
    end
    if(self.IfInputJumper == false) then    --显示文本正文时存储书签
        self:SaveMarker();
        platform.window:invalidate();
        return;
    end
    self.JumpTarget = tonumber(self.InputText);      --转换为数字
    self.InputText = "";
    self.IfInputJumper = false;
    if(self.JumpTarget > 0) then
        self.PageNo = self.JumpTarget;
    end
    self.JumpTarget = 0;        --重置
    self:PageJumper();            --跳页
end

--timer Event
--实现自动翻页
function iRead_Text:timer()
    if(self.IfShowAbout == true) or (self.IfInputJumper == true) then
        return;
    end
    if (self.IfAuto == false) then
        return;
    end
    self:PageDown();
    platform.window:invalidate();
end
