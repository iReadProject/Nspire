--[[
    iRead Main V2.0 Final
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

iRead = iRead_Text();
--�½�һ�����ʵ��

function on.create()
    --��ʼ��
    __Draw();
    on.arrowDown();
    if(iRead.MaxPage < 15) then
        for i = 1, 500000 do
        end
    end
    --���ı���ʱ�Է�ֹ��ʵ����Ͽ��ܴ��ڵ���ʾ����
end

--��������¼���Link��iRead_Text��������¼�

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

--�˳�ʱ�����ڴ棬��ֹ���ܵ��ڴ�����
function on.destroy()
    collectgarbage();
end

