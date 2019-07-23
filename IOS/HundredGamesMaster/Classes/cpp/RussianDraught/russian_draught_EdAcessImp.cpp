// #include <windows.h>
#include <fstream>
using namespace std;

#include "russian_draught_EdAccessImp.hpp"

namespace RussianDraught
{
    int32_t combi_array[64][64];
    int32_t single[64][64][12];
    
    void InitSingle()
    {
        for (int32_t n = 0; n < 8; n++)
            for (int32_t f = 0; f <= 32; f++) {
                int32_t index = 0;
                for (int32_t lp = 0; lp < f; lp++) {
                    if(lp>=0 && lp<64 && f>=0 && f<64 && n>=0 && n<12){
                        single[lp][f][n] = index;
                    }else{
                        printf("error, single: index error\n");
                    }
                    if(f - lp - 1>=0 && f - lp - 1<64 && n-1>=0 && n-1<64){
                        // printf("correct, combi_array: index correct\n");
                        index += combi_array[f - lp - 1][n - 1];
                    }else{
                        // printf("error, combi_array: index error\n");
                    }
                }
            }
    }
    
    int32_t fac(int32_t a)
    {
        int32_t res = 1;
        for (int32_t i = 2; i <= a; i++)
            res *= i;
        return res;
    }
    
    int32_t combi_calc(int32_t a, int32_t b)
    {
        int32_t res = 1;
        if (2 * b < a)
            b = a - b;
        int32_t i = b + 1;
        while (i <= a) {
            res *= i;
            i++;
        }
        res /= fac(a - b);
        return res;
    }
    
    void InitIndex()
    {
        printf("initIndex\n");
        int32_t i, j;
        for (i = 0; i <=32; i++) {
            for (j = 0; j <= 12 && j <= i; j++) {
                if(i>=0 && i<64 && j>=0 && j<64){
                    combi_array[i][j] = combi_calc(i, j);
                }else{
                    printf("error, combi_array: index error\n");
                }
            }
            for (j = i; j >= 0 && j >= i - 12; j--) {
                if(i>=0 && i<64 && j>=0 && j<64){
                    combi_array[i][j] = combi_calc(i, j);
                }else{
                    printf("error, combi_array: index error\n");
                }
            }
        }
        InitSingle();
    }
    
    int32_t index_single(int32_t *pos, int32_t fields, int32_t n)
    {
        int32_t res = 0;
        int32_t lp = -1;
        for (int32_t i = 0; i < n; i++) {
            lp = pos[i] - lp - 1;
            res += single[lp][fields][n - i];
            fields -= lp + 1;
            lp = pos[i];
        }
        return res;
    }
    
    int32_t EdAccessImp::GetResult(EdBoard1 *board, uint32_t flags)
    {
        int32_t wkl[12], wk = 0;
        int32_t bkl[12], bk = 0;
        int32_t wml[12], wm = 0;
        int32_t bml[12], bm = 0;
        int32_t jmp1 = 0;
        int32_t jmp2 = 0;
        for (uint32_t i = 0; i < 32; i++) {
            switch (board->board[i])  {
                case white:
                    wml[wm++] = i - 4;
                    jmp1++;
                    jmp2++;
                    break;
                case black:
                    bml[bm++] = i;
                    jmp1++;
                    jmp2++;
                    break;
                case white | king:
                    wkl[wk++] = i - jmp1;
                    jmp2++;
                    break;
                case black | king:
                    bkl[bk++] = i - jmp2;
            }
        }
        
        if (wk + wm == 0)
            return lose;
        if (bk + bm == 0)
            return win;
        if (wk + bk + wm + bm > ed_pieces)
            return not_found;
        
        if (!Bases[wk][bk][wm][bm])
            return not_found;
        
        int32_t p3 = combi_array[32 - wm - bm - wk][bk];
        int32_t p2 = p3 * combi_array[32 - wm - bm][wk];
        int32_t p1 = p2 * combi_array[28][bm];
        
        int32_t ind = index_single(wml, 28, wm) * p1;
        ind += index_single(bml, 28, bm) * p2;
        ind += index_single(wkl, 32 - wm - bm, wk) * p3;
        ind += index_single(bkl, 32 - wm - bm - wk, bk);
        
        unsigned char res = Bases[wk][bk][wm][bm]->GetValue(ind);
        
        if (res == 1)
            return EdAccess::win;
        else if (res == 2)
            return EdAccess::lose;
        else
            return EdAccess::draw;
    }
    
    int32_t EdAccessImp::GetResult(EdBoard2 *board, uint32_t flags)
    {
        // MessageBox(0, "GetResult(table2, flags) is not implemented yet", "EdAccess error", 0);
        printf("GetResult(table2, flags) is not implemented yet\n");
        return not_found;
    }
    
    uint32_t EdAccessImp::GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk)
    {
        // MessageBox(0, "GetTable() is not implemented yet", "EdAccess error", 0);
        printf("GetTable() is not implemented yet\n");
        return 0;
    }
    
    uint32_t EdAccessImp::GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk, uint32_t rank)
    {
        // MessageBox(0, "GetTable() with rank is not supported by this ED", "EdAccess error", 0);
        printf("GetTable() with rank is not supported by this ED\n");
        return 0;
    }
    
    uint32_t EdAccessImp::IsTableInMemory(uint32_t table)
    {
        return table;
    }
    
    // получить индекс в таблице
    
    uint64_t EdAccessImp::GetIndex(EdBoard1 *board)
    {
        // MessageBox(0, "GetIndex() is not implemented yet", "EdAccess error", 0);
        printf("GetIndex() is not implemented yet\n");
        return 0;
    }
    
    uint64_t EdAccessImp::GetIndex(EdBoard2 *board)
    {
        // MessageBox(0, "GetIndex() is not implemented yet", "EdAccess error", 0);
        printf("GetIndex() is not implemented yet\n");
        return 0;
    }
    
    // получить оценку по указателю на таблицу и индексу
    int32_t EdAccessImp::GetResult(uint32_t table, uint64_t index, uint32_t flags)
    {
        // MessageBox(0, "GetResult(table, index, flags) is not implemented yet", "EdAccess error", 0);
        printf("GetResult(table, index, flags) is not implemented yet\n");
        return not_found;
    }
    
    char strBaseType[100];
    
    char *EdAccessImp::GetBaseType()
    {
        {
            strBaseType[0] = 0;
            sprintf(strBaseType, "%sKallisto", strBaseType);
        }
        return strBaseType;
    }
    
    unsigned char EGDB::GetValue(int32_t index)
    {
        unsigned char c = data[index >> 2];
        c >>= (index & 3) << 1;
        return c & 3;
    }
    
    void EdAccessImp::GetName(char *name, uint32_t wk, uint32_t bk, uint32_t wm, uint32_t bm)
    {
        name[0] = wk + bk + wm + bm + '0';
        name[1] = wk + '0';
        name[2] = bk + '0';
        name[3] = wm + '0';
        name[4] = bm + '0';
        name[5] = '.';
        name[6] = 0;
        
        strcat(name, ext);
    }
    
    EdAccessImp::EdAccessImp()
    {
        ed_pieces = 0;
        for (uint32_t cnt = 2; cnt <= EdMaxPieces; cnt++) {
            for (uint32_t white = 1; white < cnt; white++) {
                uint32_t black = cnt - white;
                for (uint32_t wm = 0; wm <= white; wm++) {
                    uint32_t wk = white - wm;
                    for (uint32_t bm = 0; bm <= black; bm++) {
                        uint32_t bk = black - bm;
                        Bases[wk][bk][wm][bm] = 0;
                    }
                }
            }
        }
    }
    
    void EdAccessImp::Load(uint32_t wk, uint32_t bk, uint32_t wm, uint32_t bm)
    {
        if(wk<EdMaxPieces && bk<EdMaxPieces && wm<EdMaxPieces && bm<EdMaxPieces){
            
        }else{
            printf("error, Bases index error\n");
        }
        /*if (Bases[wk][bk][wm][bm])
            return;*/
        
        /*char name[16];
        GetName(name, wk, bk, wm, bm);
        
        char file[128];
        strcpy(file, path);
        strcat(file, name);
        
        uint32_t size;
        ifstream fdb;
        fdb.open(file, ios::in | ios::binary);
        if (!fdb)
            return;
        
        Bases[wk][bk][wm][bm] = new EGDB;
        if (wk + bk + wm + bm > ed_pieces)
            ed_pieces = wk + bk + wm + bm;
        fdb.seekg(0, ios::end);
        size = fdb.tellg();
        Bases[wk][bk][wm][bm]->data = new unsigned char [size];
        fdb.seekg(0, ios::beg);
        fdb.read((char *)Bases[wk][bk][wm][bm]->data, size);
        Bases[wk][bk][wm][bm]->size = size;*/
    }
    
    void EdAccessImp::Load(uint32_t cnt)
    {
        for (uint32_t white = 1; white < cnt; white++) {
            uint32_t black = cnt - white;
            for (uint32_t wm = 0; wm <= white; wm++) {
                uint32_t wk = white - wm;
                for (uint32_t bm = 0; bm <= black; bm++) {
                    uint32_t bk = black - bm;
                    Load(wk, bk, wm, bm);
                }
            }
        }
    }
    
    uint32_t EdAccessImp::Load(char *game_type)
    {
        /*strcpy(path, "..\\ED\\Kallisto");
        if (!strcmp(game_type, "russian")) {
            strcat(ext, "ed");
        } else if (!strcmp(game_type, "russianlosers")) {
            strcat(path, " Losers");
            strcat(ext, "led");
        } else if (!strcmp(game_type, "brazil")) {
            strcat(path, " Brazil");
            strcat(ext, "bed");
        } else if (!strcmp(game_type, "brazillosers")) {
            strcat(path, " Brazil Losers");
            strcat(ext, "lbed");
        } else if (!strcmp(game_type, "pool")) {
            strcat(path, " Pool");
            strcat(ext, "ped");
        } else if (!strcmp(game_type, "poollosers")) {
            strcat(path, " Pool Losers");
            strcat(ext, "lped");
        } else if (!strcmp(game_type, "checkers")) {
            strcat(path, " Checkers");
            strcat(ext, "ced");
        } else if (!strcmp(game_type, "checkerslosers")) {
            strcat(path, " Checkers Losers");
            strcat(ext, "lced");
        } else
            return 0;
        
        strcat(path, "\\");*/
        
        for (uint32_t i = 2; i <= EdMaxPieces; i++)
            Load(i);
        return ed_pieces;
    }
    
    void GetEGDB_imp(EdAccess **eda)
    {
        InitIndex();
        *eda = new EdAccessImp;
    }
    
}
