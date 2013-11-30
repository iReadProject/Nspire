--[[
    iRead Main V2.0 Final
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

iRead = iRead_Text();
--新建一个类的实例

function on.create()
    --初始化
    __Draw();
    on.arrowDown();
    if(iRead.MaxPage < 15) then
        for i = 1, 500000 do
        end
    end
    --短文本延时以防止在实体机上可能存在的显示问题
end

--以下相关事件均Link至iRead_Text类中相关事件

function on.paint(gc)
    iRead:paint(gc);
end

function on.arrowDown()
    iRead:PageDown();
    platform.window:invalidate();
end

function on.arrowUp()
    iRead:PageUp();
    platform.window:invalidate();
end

function on.enterKey()
    collectgarbage();
    iRead:enterKey();
end

function on.backspaceKey()
    iRead:backspaceKey();
end

function on.escapeKey()
    iRead:escapeKey();
end

function on.tabKey()
    iRead:tabKey();
end

function on.charIn(char)
    iRead:charIn(char);
end

function on.timer()
    iRead:timer();
end

--退出时回收内存，防止可能的内存问题
function on.destroy()
    collectgarbage();
end

