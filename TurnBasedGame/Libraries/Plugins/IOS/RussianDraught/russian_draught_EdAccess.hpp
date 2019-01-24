#ifndef RUSSIAN_DRAUGHT_ED_ACCESS_HPP
#define RUSSIAN_DRAUGHT_ED_ACCESS_HPP

namespace RussianDraught
{
    // ������������ ����� ��� ������� � ����������� �����
    struct EdAccess
    {
        // ��������� ��� ������������� �������� �������
        
        struct EdBoard1
        {
            // ��� ���� ���� �� ������� b8, d8, � �.�. �� g1
            unsigned char board[32];
        };
        
        struct EdBoard2
        {
            unsigned char *wman;
            uint32_t wman_cnt;
            
            unsigned char *wkings;
            uint32_t wkings_cnt;
            
            unsigned char *bman;
            uint32_t bman_cnt;
            
            unsigned char *bkings;
            uint32_t bkings_cnt;
        };
        
        
        // ������������ ��������
        
        enum
        {
            draw      =      0,
            win       =  10000,
            lose      = -10000,
            not_found =  32000
        };
        
        
        // ���� ��� ����������� �����
        
        enum
        {
            white = 1,
            black = 2,
            empty = 4,
            king  = 8
        };
        
        
        // ����� ��� ������� � ����
        
        enum
        {
            in_mem = 1
        };
        
        
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
        
        virtual uint32_t Load(char *game_type) = 0;
        
        
        // �������� ��� ����
        
        virtual char* GetBaseType() = 0;
        
        
        // ������ ������� (������ ��� �����)
        
        virtual int32_t GetResult(EdBoard1 *board, uint32_t flags) = 0;
        virtual int32_t GetResult(EdBoard2 *board, uint32_t flags) = 0;
        
        
        // �������� ��������� �� ������� �� ���������
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk) = 0;
        
        
        // �������� ��������� �� ������� �� ��������� � �� �������� ����������� �����
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk, uint32_t rank) = 0;
        
        
        // �������� ������������� ������� ������� � ������
        
        virtual uint32_t IsTableInMemory(uint32_t table) = 0;
        
        
        // �������� ������ � �������
        
        virtual uint64_t GetIndex(EdBoard1 *board) = 0;
        virtual uint64_t GetIndex(EdBoard2 *board) = 0;
        
        
        // �������� ������ �� ��������� �� ������� � �������
        
        virtual int32_t GetResult(uint32_t table, uint64_t index, uint32_t flags) = 0;
    };
}

#endif
