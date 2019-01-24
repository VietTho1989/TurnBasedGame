#ifndef RUSSIAN_DRAUGHT_ED_ACCESS_IMP_HPP
#define RUSSIAN_DRAUGHT_ED_ACCESS_IMP_HPP

#include "russian_draught_EdAccess.hpp"

namespace RussianDraught
{
    // ������� ����������� ����
    struct EGDB
    {
        unsigned char *data;
        int32_t *idx;
        int32_t block_cnt;
        int32_t size;
        
        EGDB() {
            data = 0;
            idx = 0;
        }
        ~EGDB() {
            if (data)
                delete[] data;
            if (idx)
                delete[] idx;
        }
        
        unsigned char GetValue(int index);
    };
    
    struct EdAccessImp: public EdAccess
    {
        static const int32_t EdMaxPieces = 6;
        uint32_t ed_pieces;
        EGDB *Bases[EdMaxPieces][EdMaxPieces][EdMaxPieces][EdMaxPieces];
        
        char path[128];
        char ext[8];
        
        EdAccessImp();
        
        void Load(uint32_t cnt);
        void Load(uint32_t wk, uint32_t bk, uint32_t wm, uint32_t bm);
        void GetName(char *name, uint32_t wk, uint32_t bk, uint32_t wm, uint32_t bm);
        
        
        //-----------------------------------------------------
        // ����������� �������
        
        // ��������� ����
        // ���� ����� ���� ���:
        // 		russian
        // 		russianlosers
        // 		brazil
        // 		brazillosers
        // 		pool
        // 		poollosers
        // 		checkers
        // 		checkerslosers
        
        virtual uint32_t Load(char *game_type);
        
        
        // �������� ��� ����
        
        virtual char* GetBaseType();
        
        
        // ������ ������� (������ ��� �����)
        
        virtual int32_t GetResult(EdBoard1 *board, uint32_t flags);
        virtual int32_t GetResult(EdBoard2 *board, uint32_t flags);
        
        
        // �������� ��������� �� ������� �� ���������
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk);
        
        
        // �������� ��������� �� ������� �� ��������� � �� �������� ����������� �����
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk, uint32_t rank);
        
        
        // �������� ������������� ������� ������� � ������
        
        virtual uint32_t IsTableInMemory(uint32_t table);
        
        
        // �������� ������ � �������
        
        virtual uint64_t GetIndex(EdBoard1 *board);
        virtual uint64_t GetIndex(EdBoard2 *board);
        
        
        // �������� ������ �� ��������� �� ������� � �������
        
        virtual int GetResult(uint32_t table, uint64_t index, uint32_t flags);
        
    };
    
    void InitIndex();
}

#endif
