--[[
    iRead Kernel V2.0  Final
    �����Ϣ:
    �й���½(Chinese Mainland)��
    ���������֪ʶ���� ����-��ͬ��ʽ���� 3.0 �й���½ ���Э�������ɡ�Ҫ�鿴�����Э�飬
    �ɷ��� http://creativecommons.org/licenses/by-sa/3.0/cn/ ����д�ŵ�
    Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.

    ��������/����(Other countries/regions):
    This program is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
    To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/
    or send a letter to
    Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.

    ����:wtof1996
    �������ڣ�2013-7-18 21:07:36

]]--

--------           Init            --------
iRead_Text = class();

--��ʼ������
function iRead_Text:init(TextData)

    self.TextColor = {["R"] = 0, ["G"] = 0, ["B"] = 0}; --Ĭ��ǰ��ɫ�����ı���ɫ
    self.BackBoradColor = {["R"] = 255, ["G"] = 255, ["B"] = 255}; --Ĭ�ϱ���ɫ
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
    --����Դ���ɫ���û��Զ�����ɫ,FR,FG,FBΪǰ��ɫRGB����,BR,BG,BBΪ����ɫ����

    self.LineHeight = 23;  --ÿ���ı��߶�
    self.TextBuffer = {};  --��ǰ��ʾҳ����ı�����

    self.BackBoradImage = nil;  --����ͼƬ
    self.IfShowBackBoradImage = true;--�Ƿ���ʾ����ͼƬ

    self.AutoPageDownInterval = nil; --�Զ���ҳʱ����
    self.IfAuto = false;             --�Ƿ����Զ���ҳ

    self.Pointer  = 1;     --�ı�����������ָ�롱��Ĭ��ָ���ı���ͷ
    self.LinePointer = 1;  --������������ָ�롱
    self.PageNo = 0;       --��ǰҳ����"ָ��"
    self.MaxPage = 0;      --��ǰ������ҳ��
    self.Page = {};        --��ҳ��Ϣ
    self.Line = {};        --������Ϣ
    self.IfDivided = false; --�Ƿ�����Ԥ��ҳ


    self.MaxTextWidth = 305;  --�ı����
    self.MaxTextHeight= 184;  --�ı��߶�
    self.TextHeightDistance = 0;  --�о�
    self.DefaultDividePageNumber = 100; --ÿ�λ���ҳ����
    self.IfBreakingLine = false;  --Ӣ���Զ�����
    self.PointerNow = 0;      --��ǰҳ�����һ���ַ���Ӧ���ı������е�����ֵ�����ڼ����Ķ�����
    self.LabelX = 0;          --״̬��X����
    self.LabelY = 210;        --״̬��Y����
    self.LabelFontSize = 9;   --״̬���ֺ�(���ھ�ΪASCII�ַ����Կ��Ե���)

    self.BookMarker = 1;      --��ǩ
    self.SaveToClipboard = true; --�Ƿ���������
    self.IfInputJumper = false;  --��ǰ�Ƿ���ʾ��ҳ����
    self.JumpTarget = 0;        --�û���ͼ��ת��ҳ��
    self.InputText = "";        --�û���������
    self.InputNotice = {
                                    "������Ŀ��ҳ��,������Χ���������һҳ" ,
                                    "esc�˳�  enterȷ�� del��"..string.uchar(26684),
                                    "��ʾ:���������淶Χ���ܻ����",
                                    "��ǰҳ��/�ѻ���ҳ����:",
                       };
    --��ҳ��ʾ����

    self.About = {
                            "����iRead II",
                            "����:wtof1996",
                            "����:Faith",
                            "����:imath,ExAcler,chsi,urill,˶ѩX��,Ƥ��,",
                            "��ĩ,nbzwt,diameter,����,��ëë,wakaka101,",
                            "�����,���׵��Ƴ�����,DAS,Suica",
                            "��������� CC-BY-SA 3.0������Ȩ",
                            "wtof1996 Copyright 2013 Some rights reserved",
                             "�밴esc����"
                            };
    --������Ϣ����
    self.IfShowAbout = false;
    --�Ƿ���ʾ���ڽ���

    self.OS = "3.2"; --OS�汾
    self.IfColor = platform.isColorDisplay(); --��ǰ�Ƿ����
    self.IfDraw = true;  --�Ƿ������ʼ��
end
--------          Check Character Type           --------
--���º���������cctype������غ�������д

--���char�Ƿ�����ĸ
function iRead_Text:IsAlpha(char)
    if(char >= 65 and char <= 90) then       return true;
    elseif(char >= 97 and char <= 122) then  return true;
    else                                     return false;
    end
end

--���char�Ƿ�������
function iRead_Text:IsNumber(char)
    if(char < 48 or char > 57) then
        return false;
    end
    return true;
end
--------           OS Adapt            --------
--����Ӧ

--��ͼʹ��domain�����Լ��OS�汾������֧����Ϊ3.1
function iRead_Text:OSChecker()
    local str, err;
    str, err = math.eval("domain(1,1)");
    if(err == "incompatible data type") then
        self.OS = "3.1";
    end
end

--������Ļ��ɫ��ϵͳ�汾��������
function iRead_Text:SelfAdapt()
    if(self.OS == "3.1") then
        self.MaxTextHeight = 175;
        self.MaxTextWidth = 300;
        self.LabelY = 200;
        self.LabelFontSize= 7;  --OS 3.1�ı��ߴ�
    end
    if(self.IfColor == false) then
        self.IfShowBackBoradImage = false;
        self:SetColor("Default");
    end             --�ڰ����򲻿�������ͼƬ��ʹ�ð׵׺���
end

--------           Menu Function            --------
--�˵���غ���

--�л�����ͼƬ�Ƿ���ʾ
function iRead_Text:SwitchBackBoradImageShow()
    self.IfShowBackBoradImage = not self.IfShowBackBoradImage;
    platform.window:invalidate();
end

--��ȡ�û��Զ�����ɫ
function iRead_Text:LoadColorCustomize()
    local F, B;
    F = var.recall("iread_color_f");--ǰ��ɫ
    if(F == nil) then
        return;
    end

    B = var.recall("iread_color_b");--����ɫ
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
    --ȡ��������Ƿ���������

    self.SystemColor.Customize.FR = F[1];
    self.SystemColor.Customize.FG = F[2];
    self.SystemColor.Customize.FB = F[3];
    self.SystemColor.Customize.BR = B[1];
    self.SystemColor.Customize.BG = B[2];
    self.SystemColor.Customize.BB = B[3];
    --�����������������RGB����

    self:SetColor("Customize");--�����Զ�����ɫ

end


--�����ı���ɫ
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


--��ȡ�û��Զ����Զ���ҳ�ٶ�
function iRead_Text:LoadAutoPageDownCustomize()
    local speed;
    speed = tonumber(var.recall("iread_interval"));
    if(speed == nil) or (speed <= 0) then
        return;
    end

    self.AutoPageDownInterval = speed;
end

--------           BookMarker Function            --------
--��ǩ��غ���

--�洢��ǩ
function iRead_Text:SaveMarker()
    var.store("iread_bookmarker", self.PageNo);
    self.BookMarker = self.PageNo;
    if (self.SaveToClipboard == true) then
        clipboard.addText(tostring(self.PageNo));
    end
end

--�л��Ƿ�ʹ�ü�������ǩ
function iRead_Text:SwitchSaveToClipboard()
    self.SaveToClipboard = not self.SaveToClipboard;
end

--�Ӽ�������ȡ��ǩ
function iRead_Text:ReloadMarkerFromClip()
    local target = clipboard.getText();
    target = tonumber(target);
    if(target ~= nil) then
        var.store("iread_bookmarker", target);
        self:ReloadMarker();
        --����Ч����벢������ǩ
    end

end

--��ȡ��ǩ
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
            --��ȡ�������Ч��

            self.BookMarker = target;

            if (self.IfDraw == true) then
                return;
            end
            --����ǰ���ڳ�ʼ����������ǩ����ҳ��

            self.PageNo = target;

            break;
        end
    end
    if (self.IfDraw == false) then
        self:PageJumper();
        --��ҳ
    end

end
--------           About & PageJumper            --------
--���ڽ��漰��ҳ���

--��ʾ��ҳ����
function iRead_Text:ShowPageJumper()
	self.IfInputJumper = true;
	platform.window:invalidate();
end

function iRead_Text:PageJumper()
    local tmp;
    while(self.MaxPage < self.PageNo) do --���Ŀ��ҳ�泬����ǰ�ѻ���ҳ��
       if(self.IfDivided == true) then  --����Ԥ��ҳʱ��ֱ���������һҳ
            self.PageNo = self.MaxPage;
            break;
       end
        tmp = self.MaxPage; --��ǰ����ҳ����
        self:DividePage(self.DefaultDividePageNumber); --��ͼ��ҳ
        if(tmp == self.MaxPage)  then  --�������ҳ��������
            self.PageNo = self.MaxPage;
            break;  --�������һҳ
        end
    end
    self:SetPageBuffer();  --����ҳ�滺��
    platform.window:invalidate(); --ˢ��
end

--��ʾ���ڽ���
function iRead_Text:ShowAbout()
    self.IfShowAbout = true;
    platform.window:invalidate();
end
--------           Divide Page             --------
--��ҳ���
--[[
    iRead IIҳ�����ݲ������½ṹ:
    �ı�������������ʽ�洢��self.TextData�У�ÿ���ַ��洢Ϊ���Ӧ��UTF8���ֱ���

    ����ҳ��ʱ�ȷ��У�ÿ�в��ó���Ϊ2��һ��Table�洢���ṹΪ
        {<�п�ʼ����>��<�н�������>}
    ��������ָ���������ı��е�λ�ã���������ͳһ�洢��self.Line��
    Ȼ�������ҳ����ҳ���ݴ洢��self.Page��
    Ȼ��ҳ�����¼��ǰҳ���һ�����������������о�������
    ��ǰҳ���еĽ��������ɸ�����һҳ��ʼλ�ý��е���
]]--

--�õ�һ������
function iRead_Text:MakeLine()
    return {0, 0};
end

--��ǰ��ת��Ϊ�ַ���
function iRead_Text:GetString(Line)
    local ret = "";
    for i = Line[1], Line[2] do
        ret = ret .. string.uchar(self.TextData[i]);
    end
    return ret .. "  ";
    --ÿ��ĩβ����һ���ո�
end

--�����㷨
function iRead_Text:GetLine()
    local ret = self:MakeLine(); --�õ�һ������
    ret[1] = self.Pointer;       --��ǰ�еĿ�ʼλ�þ��ǵ�ǰ������ָ�롱λ��
    local gc = platform.gc();    --����Graphic Context
    gc:begin();                  --��������Graphic Context

    local width = self.MaxTextWidth;  --��ǰ���ÿ�ȣ���ʼ��Ϊ�����
    local CharWidth = 0;              --�ַ����
    local Char = "";                  --�ַ�
    local LastChar = nil;             --Ӣ���Զ�����ʱ����ǰ���жϵ�λ��
    local Comer = false;             --Ӣ���Զ�����ʱ����ʶ����ǰ���Ż��Ǻ�����
    if(self.TextData[self.Pointer] == nil) then --��ǰ�Ѿ�Խ�磬����nil
        return nil;
    end

    while(width >= 0) do    --������п��ʣ�࣬��ô��������ǰ��������ַ�

        if(self.TextData[self.Pointer] == nil) then --Խ������
            break;
        end

        if(self.TextData[self.Pointer] == 10) then --���з����������Ҫע�������PC��ת������ʱ�Ѿ�ȥ��CR,�˴�ΪLF
            ret[2]= self.Pointer - 1;                           --���н����ַ�ǰ�ƣ���Ϊʵ������޷���������LF
            self.Pointer = self.Pointer + 1;               --������ָ�롱����
            break;
        end

        Char = string.uchar(self.TextData[self.Pointer]);   --�õ���ǰ����ָ��ָ���UTF8�����Ӧ���ַ�
        CharWidth = gc:getStringWidth(Char);                 --�õ��ַ����

        if(CharWidth < width) then                                  --���ʣ�����㹻

            if(self.IfBreakingLine == true) then                --Ӣ���Զ����е����

                if(self.TextData[self.Pointer] == 34) then      --����
                    Comer =not Comer;                                    --�л�ǰ/������״̬
                    if(Commer == true) then                           --ǰ����ʱ
                        LastChar = self.Pointer - 1;                     --����Ӣ���Զ������ж��е�λ��
                    end

                elseif(self.TextData[self.Pointer] >= 128 or self:IsAlpha(self.TextData[self.Pointer]) == false) then
                    --��ǰ�ַ�Ϊ��Ӣ���ַ�ʱ���ж��ڴ�
                    LastChar = self.Pointer;
                end
            end
            --�������ϸ����ж�λ�ã���ʵ��Ӣ���Զ�����

            self.Pointer = self.Pointer + 1;  --������ָ�롱���ƣ���������ַ��Ѿ��ɹ����뵱ǰ��
        end

        width = width - CharWidth;  --�õ��µ�ʣ����
    end

    if(self.IfBreakingLine == true) then        --Ӣ���Զ������жϴ���
        if(LastChar ~= nil) then                       --������ڽض�λ��
            if(self:IsAlpha(self.TextData[self.Pointer - 1]) == true and
                self:IsAlpha(self.TextData[self.Pointer]) == true) then --��ǰλ���ַ�����һ���ַ���ΪӢ��
                ret[2] = LastChar;                  --�ض�
                self.Pointer = LastChar + 1;  --ָ�������ڽض�λ�ú�
            end
        end
    end

    if(ret[2] == 0) then  --��Ӣ���Զ����еĴ���
        ret[2] = self.Pointer - 1;
    end

    gc:finish();  --������������Graphic Context
    return ret;
end

--��ҳ�㷨
function iRead_Text:GetPageLines()
    local height = self.MaxTextHeight;    --��ǰ���ø߶ȣ���ʼ��Ϊ���߶�
    local ret = self.LinePointer;                  --��ǰ��������ָ�롱λ�ô洢,���ڷ���ҳ�濪ʼλ��

    while(height >= 0) do           --�������ʣ������ô���ϳ��Է���
        self.Line[self.LinePointer] = self:GetLine();   --��һ��
        if(self.Line[self.LinePointer] == nil) then break; end --���е����
        height = height - self.TextHeightDistance - self.LineHeight; --���¸߶�
        self.LinePointer = self.LinePointer + 1;    --�ƶ�������"ָ��"
    end
    if(self.LinePointer == ret) then --���һ�ж�û�з֣���ʱ�Ѿ�Խ�磬����nil
        return nil;
    end
    return ret;         --����ҳ�濪ʼλ��
end

--������ָ��ҳ��
function iRead_Text:DividePage(amount)
    if(self.IfDivided == true) then  return; end   --�Ѿ�Ԥ��ҳ�����
    local i = self.MaxPage;                                      --��ǰ����ҳ����
    local count = 0;                                                 --��ҳ�ɹ���
    repeat
        self.Page[i+ 1] = self:GetPageLines();          --��һҳ
        if(self.Page[i + 1] == nil) then break; end   --ʧ����ֹͣ
        count = count + 1;
        i = i + 1;
    until(count >= amount);
    self.MaxPage = i;   --���¿���ҳ����
    collectgarbage();   --�������գ���ֹ���ܵ��ڴ治������
end

--ȫ����ҳ��˼·����������������ҳ��ֻ�����˴�����ͼ����Ϊֹ��������ָ������ҳ��
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
--��ҳ���

--���·�ҳ
function iRead_Text:PageDown()
    if(self.IfShowAbout == true) or (self.IfInputJumper == true) then
        return;    --��ʾ����ҳ��ʱ����
    end
    local tmp = self.MaxPage;   --��ǰ����ҳ����
    if(self.Page[self.PageNo + 1] == nil) then  --�������
        self:DividePage(self.DefaultDividePageNumber); --��ͼ������ҳ
        if(tmp == self.MaxPage) then --�������ҳ�������䣬���ʾ�Ѿ���ͷ
            return;
        end
    end
    self.PageNo = self.PageNo + 1; --����ƶ�ҳ��"ָ��"
    self:SetPageBuffer();       --����ҳ�滺��
end

--���Ϸ�ҳ
function iRead_Text:PageUp()
    if(self.IfShowAbout == true) or (self.IfInputJumper == true) then
        return;
    end     --��ʾ����ҳ��ʱ����
    if(self.Page[self.PageNo - 1] == nil) then  --��ͷ�����
        return;
    end
    self.PageNo = self.PageNo - 1;  --��ǰ�ƶ�ҳ��"ָ��"
    self:SetPageBuffer();           --����ҳ�滺��
end

--��ʼ�Զ���ҳ
function iRead_Text:SetAutoPageDown()
    if(self.AutoPageDownInterval == nil or self.AutoPageDownInterval <= 0) then
        self.AutoPageDownInterval = 15;     --ʱ�������Ϸ������
    end
    timer.start(self.AutoPageDownInterval);  --����timer
    self.IfAuto = true;                                       --�Ѿ���ʼ�Զ���ҳ
    toolpalette.enable("�Զ���ҳ", "��ʼ", false);
    toolpalette.enable("�Զ���ҳ", "ֹͣ", true);         --���²˵�״̬
end

--ֹͣ�Զ���ҳ
function iRead_Text:StopAutoPageDown()
    self.IfAuto = false;            --ֹͣ�Զ���ҳ
    timer.stop();                       --ֹͣtimer
    toolpalette.enable("�Զ���ҳ", "��ʼ", true);
    toolpalette.enable("�Զ���ҳ", "ֹͣ", false); --���²˵�״̬
end

--����ҳ�滺��
function iRead_Text:SetPageBuffer()
    self.TextBuffer = {};               --���
    local page_start = self.Page[self.PageNo]; --��ǰҳ�濪ʼ��
    local page_end = 0;                                       --��ǰҳ������У�ȡ���������������
    if(self.Page[self.PageNo + 1] ~= nil) then  --�������һҳʱ
        page_end = self.Page[self.PageNo + 1] - 1; --������һҳ����
    else
        page_end = #self.Line;                                  --����ֱ��Ϊ���һ��
    end
    self.PointerNow = self.Line[page_end][2];      --��ǰҳ�����һ���ַ������ı��е�λ�ã�������ʾ�ٷֱȽ���
    local count = 1;                                                 --��ǰҳ���к�
    for i = page_start, page_end do                     --��ȡ�����ݣ��������뻺��
        self.TextBuffer[count] = self:GetString(self.Line[i]);
        count = count + 1;
    end
    self.TextBuffer[count] = nil;                           --ҳ�滺��ĩβ���
end
--------           System Events            --------
--�����Ӧ�������ϵͳ�¼�������onģ�����Ӧ�¼�����

--Paint  Event
function iRead_Text:paint(gc)

    if(self.IfShowAbout == true) then   --���ƹ��ڽ���
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

    if(self.IfInputJumper == true) then --��ҳ����
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
        gc:drawString(self.InputText, 0, 140);   --�����û���������
        return;
    end

    gc:setColorRGB(self.BackBoradColor.R,
                                self.BackBoradColor.G,
                                self.BackBoradColor.B
                              );
    --���ñ���ɫ
    gc:fillRect(0, 0, 320, 240);    --����
    if(self.BackBoradImage ~= nil) then
        if(self.IfShowBackBoradImage == true) then
            gc:drawImage(self.BackBoradImage, 0, 0);    --���Ʊ���ͼƬ��ע��˴��Ḳ�ǵ�ɫ����
        end
    end
    gc:setColorRGB(self.TextColor.R, self.TextColor.G, self.TextColor.B);   --�����ı���ɫ
    gc:setFont("sansserif", "r", self.LabelFontSize);       --����״̬������
    local LabelStr = string.format("%d/%d        %.2f%%      Marker:%d",
                                   self.PageNo,
                                   self.MaxPage,
                                   (1.0 * self.PointerNow / (#self.TextData)) * 100,
                                    self.BookMarker);
                                    --�ϳ�״̬������
    gc:drawString(LabelStr, self.LabelX, self.LabelY); --����״̬��
    gc:setFont("sansserif", "r", 12);   --�����ı���������
    local Height = 20;
    for i in pairs(self.TextBuffer) do      --��������˳�����ÿһ���ı�
        if(self.TextBuffer[i] == nil) then
            break;
        end
        gc:drawString(self.TextBuffer[i], 0, Height);
        Height = Height + self.TextHeightDistance + gc:getStringHeight(i);
    end
end

--CharIn Event
--��������ҳ�����еõ��û�����
function iRead_Text:charIn(char)
    if(self.IfInputJumper == false) then  --��ǰ���������ҳ����ֱ�ӷ���
        return;
    end
    if(#char > 1) then                              --���벻�ǵ����ַ���ֱ�ӷ���
        return;
    end
    if(self:IsNumber(string.byte(char)) == false) then  --�����֣�ֱ�ӷ���
        return;
    end
    self.InputText = self.InputText .. char;    --�����û������ı�
    platform.window:invalidate();
end

--backspaceKey Event
--������Ӧ��ҳ�����е��˸��Լ����������е���ȡ��ǩ��ݼ�
function iRead_Text:backspaceKey()
    if(self.IfShowAbout == true) then           --��ǰ������ʾ���ڽ��棬����
        return;
    end
    if(self.IfInputJumper == false) then        --��ǰ��ʾ�ı�����ʱ��ȡ��ǩ
        self:ReloadMarker();
        return;
    end
    self.InputText = string.sub(self.InputText, 1, #self.InputText - 1);  --��ȡ�ַ���
    platform.window:invalidate();
end

--tabKey Event
--��ʾ��ҳ����
function iRead_Text:tabKey()
    self:ShowPageJumper();
end

--escapeKey Event
--�˳���ҳ���漰���ڽ���
function iRead_Text:escapeKey()
    if(self.IfInputJumper == true) then
        self.IfInputJumper = false;
        self.InputText = "";
        self.JumpTarget = 0;        --����
        platform.window:invalidate();
    end
    if(self.IfShowAbout == true) then
        self.IfShowAbout = false;
        platform.window:invalidate();
    end

end

--enterKey Event
--��ҳ�����е�ȷ�����Լ����������еı�����ǩ
function iRead_Text:enterKey()
    if(self.IfShowAbout == true) then   --��ǰ������ʾ���ڽ��棬����
        return;
    end
    if(self.IfInputJumper == false) then    --��ʾ�ı�����ʱ�洢��ǩ
        self:SaveMarker();
        platform.window:invalidate();
        return;
    end
    self.JumpTarget = tonumber(self.InputText);      --ת��Ϊ����
    self.InputText = "";
    self.IfInputJumper = false;
    if(self.JumpTarget > 0) then
        self.PageNo = self.JumpTarget;
    end
    self.JumpTarget = 0;        --����
    self:PageJumper();            --��ҳ
end

--timer Event
--ʵ���Զ���ҳ
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
