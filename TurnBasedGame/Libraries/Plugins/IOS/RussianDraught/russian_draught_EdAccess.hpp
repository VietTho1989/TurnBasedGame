#ifndef RUSSIAN_DRAUGHT_ED_ACCESS_HPP
#define RUSSIAN_DRAUGHT_ED_ACCESS_HPP

namespace RussianDraught
{
    // интерфейсный класс для доступа к эндшпильным базам
    struct EdAccess
    {
        // структуры для представления шашечной позиции
        
        struct EdBoard1
        {
            // все поля идут по порядку b8, d8, и т.д. до g1
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
        
        
        // возвращаемые значения
        
        enum
        {
            draw      =      0,
            win       =  10000,
            lose      = -10000,
            not_found =  32000
        };
        
        
        // коды для обозначений шашек
        
        enum
        {
            white = 1,
            black = 2,
            empty = 4,
            king  = 8
        };
        
        
        // флаги для доступа к базе
        
        enum
        {
            in_mem = 1
        };
        
        
        // загрузить базы
        // пока такие типы игр:
        // 		russian
        // 		russianlosers
        // 		brazil
        // 		brazillosers
        // 		pool
        // 		poollosers
        // 		checkers
        // 		checkerslosers
        
        virtual uint32_t Load(char *game_type) = 0;
        
        
        // получить тип базы
        
        virtual char* GetBaseType() = 0;
        
        
        // оценка позиции (всегда ход белых)
        
        virtual int32_t GetResult(EdBoard1 *board, uint32_t flags) = 0;
        virtual int32_t GetResult(EdBoard2 *board, uint32_t flags) = 0;
        
        
        // получить указатель на таблицу по материалу
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk) = 0;
        
        
        // получить указатель на таблицу по материалу и по наиболее продвинутой шашке
        
        virtual uint32_t GetTable(uint32_t wm, uint32_t wk, uint32_t bm, uint32_t bk, uint32_t rank) = 0;
        
        
        // проверка загруженности таблицы целиком в память
        
        virtual uint32_t IsTableInMemory(uint32_t table) = 0;
        
        
        // получить индекс в таблице
        
        virtual uint64_t GetIndex(EdBoard1 *board) = 0;
        virtual uint64_t GetIndex(EdBoard2 *board) = 0;
        
        
        // получить оценку по указателю на таблицу и индексу
        
        virtual int32_t GetResult(uint32_t table, uint64_t index, uint32_t flags) = 0;
    };
}

#endif
