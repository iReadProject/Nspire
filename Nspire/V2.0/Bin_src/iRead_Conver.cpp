#include <fstream>
#include <iostream>
#include <sstream>

#include <vector>
#include <string>
#include <utility>

#include <cstring>
#include <clocale>
#include <cwctype>

#include "font_data.h"

//#define DEBUG

using namespace std;

typedef pair<int, int> Line;
typedef wstring::iterator wstr_iter;
typedef vector<Line>::iterator Line_iter;
typedef vector<int>::iterator Page_iter;

#ifdef DEBUG
    ofstream debug("debug.txt", ios::out);
#endif // DEBUG

wifstream fin;
ifstream fin_check;
ofstream data_out;
ofstream page_out;
ofstream line_out;

const int HeightDistance = 23;
const int UTF8_FAULT = -1;

vector<int> Pages;
Line_iter Line_Pointer, Line_Pointer_end, Line_Pointer_begin;
vector<Line> Lines;
wstr_iter Pointer,Pointer_end, Pointer_begin, LastPointer;

string page_path, line_path;
bool IfDividePage = false;
bool IfEnglishLineBreaking = false;
int Max_Width = 305;
int Max_Height = 184;

inline bool CheckUTF8();
inline int getnum(const string &a);
inline int GetTextPos();
inline int GetLinePos();
inline bool CheckAlpha(const int a);
Line GetLine();
inline int GetPage();

int main(int argc, char *argv[])
{
    setlocale(LC_CTYPE, "chs");
    cout << "******************************\n"
         << "iRead Data Convert V2.1 Beta III\n"
         << "By wtof1996\n"
         << "Built in 2013-5-28 20:36:52\n"
         << "******************************\n\n";
    if(argc < 3 || strcmpi(argv[1], "/?") == 0){
    help: cout << "USAGE: \n"
                           "iRead_Conver <input> <data output> \n"
                           "[/o <line output> <page output>] [/size <height> <width>] [/e]\n\n"
                           "[/o <line output> <page output>] divide pages & lines\n"
                           "[/size <width> <height>]Specify file size manually, must use with /o\n"
        	               "[/e] Use the Line Breaking(only for English)\n\n"
                           "You'd better use this with iLua.\n";
        return 0;
    }

    for(int i = 3; i < argc; ++i){
        if(strcmpi(argv[i], "/o") == 0){
            line_path = argv[i + 1];
            page_path = argv[i + 2];
            IfDividePage = true;
            i += 2;
        }
        else if(strcmpi(argv[i], "/e") == 0){
            IfEnglishLineBreaking = true;
        }
        else if(strcmpi(argv[i], "/size") == 0){
            Max_Width = getnum(string(argv[i + 1]));
            if(Max_Width <= 0){
                    Max_Width = 305;
                    cout << "Illegal Width setting, reset it to default(305 Pixel). \n";
            }
			Max_Height = getnum(string(argv[i + 2]));
            if(Max_Height <= 0){
                    Max_Height = 184;
                    cout << "Illegal Height setting, reset it to default(184 Pixel). \n";
            }

            i += 2;
        }
        else  goto help;
    }

    if(strcmpi(argv[1], argv[2]) == 0){
        cout << "ERROR:The input and output files cannot be the same.\n"
             << endl;
        return 0;
    }

	if(IfEnglishLineBreaking && (Max_Width == 305 || Max_Width == 300) ){
		Max_Width = 285;
	}

    cout << "Reading from " << argv[1];
	fin_check.open(argv[1], ios::binary);

	if(!fin_check){
		cout << "ERROR: Unable to open input file:"
			 << argv[1]<< endl;
		return 0;
	}

    if(!CheckUTF8()){
        fin_check.close();
        fin_check.clear();
        cout << endl;
        cout << "ERROR:Illegal file, conversion aborted." << endl;
        return UTF8_FAULT;
    }
    fin_check.close();
    fin_check.clear();

    fin.open(argv[1], ios::binary);
    fin.sync_with_stdio(false);

    wchar_t buff[1000] = {0};
    wstring read;
	int Readed_Bytes;

	do{
        fin.read(buff, 1000);
        Readed_Bytes = fin.gcount();
        read.append(buff, Readed_Bytes);
    }while(Readed_Bytes == 1000);

    fin.close();

    cout << "......Success!" << endl;
    cout << "Outputing.....";

    data_out.open(argv[2]);
    data_out.sync_with_stdio(false);

    if(!data_out){
		cout << "ERROR: Unable to open output file:"
			 << fin << endl;
		return 0;
    }

    wstr_iter iter_out_data, iter_out_data_end = read.end(), iter_tmp;
    wchar_t del = '\r';
    for(iter_out_data = read.begin();iter_out_data != iter_out_data_end; ++iter_out_data){
        if(*iter_out_data == del){
            iter_tmp = read.erase(iter_out_data);
            iter_out_data = iter_tmp;
            --iter_out_data;
            iter_out_data_end = read.end();
        }
    }
    iter_out_data = read.begin();
    iter_out_data_end = read.end();

    data_out << "{" << static_cast<int>(*iter_out_data);
    iter_out_data++;

    for(; iter_out_data != iter_out_data_end; ++iter_out_data){
        data_out << "," << static_cast<int>(*iter_out_data);
    }
    data_out << "}" << endl;
	data_out.close();
    data_out.clear();
   cout << "Success!" << endl;

    if(IfDividePage){
        cout << "Divide Pages Mode" <<endl;
        cout << "Width:" << Max_Width <<endl;
        cout << "Height:" << Max_Height <<endl;
        if(IfEnglishLineBreaking) cout << "Using EnglishLineBreaking." << endl;
        cout << "Start dividing lines & pages, please wait......";

        Pointer = read.begin();
        Pointer_end = read.end();
        Pointer_begin = read.begin();
        while(Pointer < Pointer_end){
            Lines.push_back(GetLine());
        }

        Line_Pointer = Lines.begin();
        Line_Pointer_begin = Lines.begin();
        Line_Pointer_end = Lines.end();

        while(Line_Pointer < Line_Pointer_end){
            Pages.push_back(GetPage());
        }
        cout << "Success!" <<endl;
        cout << "Outputing......";
        line_out.open(line_path.c_str());
        page_out.open(page_path.c_str());
        if(!line_out){
            cout << "ERROR: Unable to open output file:"
			 << line_path << endl;
			 return 0;
        }
        if(!page_out){
            cout << "ERROR: Unable to open output file:"
			 << page_path << endl;
			 return 0;
        }
        line_out.sync_with_stdio(false);
        Line_iter Line_out_iter = Lines.begin();
        line_out << "{";
        line_out << "{" << Line_out_iter->first << "," << Line_out_iter-> second<< "}";
        ++Line_out_iter;
        for(; Line_out_iter != Line_Pointer_end; ++Line_out_iter){
            line_out << "," <<  "{" << Line_out_iter->first << "," << Line_out_iter-> second<< "}";
        }
        line_out << "}" <<endl;
        line_out.close();
        line_out.clear();

        page_out.sync_with_stdio(false);
        Page_iter page_out_iter = Pages.begin(), page_end = Pages.end();
        page_out << "{" << *page_out_iter;
        ++page_out_iter;
        for(;page_out_iter != page_end; ++page_out_iter){
            page_out << "," << *page_out_iter;
        }
        page_out << "}" << endl;
        page_out.close();
        page_out.clear();
        cout << "Success!" << endl;
    }
    cout << "The conversion is completed" << endl;

    return 0;
}


inline bool CheckUTF8()
{
    bool res = false;
    int read[3] = {0};
    for(int i = 0; i < 3; ++i) read[i] = fin_check.get();
    if(read[0] != 0xEF || read[1] != 0xBB || read[2] != 0XBF) res = true;

    return res;
}

inline int getnum(const string &a)
{
    int ret = 0;
    stringstream tmp(a);
    tmp >> ret;
    return ret;

}

inline int GetTextPos()
{
    return static_cast<int>(Pointer - Pointer_begin + 1);
}

inline int GetLinePos()
{
    return static_cast<int>(Line_Pointer - Line_Pointer_begin + 1);
}

inline bool CheckAlpha(const int a)
{
    if(a >= 128) return false;
    else return static_cast<bool>(iswalpha(a));
}

Line GetLine()
{
	Line ret;
    ret.first = GetTextPos();
    ret.second = 0;
    int width = Max_Width, lastchar = -1;
    int tmp_char;
    bool commer = false;

    while(width >= 0){

        if(Pointer >= Pointer_end) break;
        tmp_char = static_cast<int>(*Pointer);
        if(tmp_char == '\n'){

            ret.second = GetTextPos() - 1;
            ++Pointer;
            break;
        }

        if(Font_Width[tmp_char] < width){
            if(IfEnglishLineBreaking){

                if(tmp_char == '"'){
                    commer = !commer;
                    if(commer){
                        lastchar = GetTextPos() - 1;
                    }
                }
                else if(!CheckAlpha(tmp_char)){
                    lastchar = GetTextPos();

                }
            }
            ++Pointer;
        }
        width -= Font_Width[tmp_char];
    }
    if(IfEnglishLineBreaking){

        if(lastchar != -1 && Pointer + 1 != Pointer_end && Pointer != Pointer_begin){
			if(CheckAlpha(*(Pointer - 1)) && CheckAlpha(*(Pointer))){

                ret.second = lastchar;
				Pointer = Pointer_begin + lastchar;
            }
        }
    }

    if(ret.second == 0){
        ret.second = GetTextPos() - 1;
    }

	return ret;
}

inline int GetPage()
{
	int ret = GetLinePos();
    int height = Max_Height;
    while(height >= 0){
        if(Line_Pointer >= Line_Pointer_end) break;
        ++Line_Pointer;
        height -= HeightDistance;
    }
	return ret;
}

