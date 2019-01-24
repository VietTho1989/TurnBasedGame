#ifndef KALLISTO_H
#define KALLISTO_H

#include <iostream>
#include <cstdint>
#include "russian_draught_EdAccess.hpp"

namespace RussianDraught
{
    typedef void (*PF_SearchInfo)(int score, int depth, int speed, char *pv, char *cm);
    typedef void (*PF_SearchInfoEx)(char *score, char *depth, char *speed, char **pv, char *cv);
    
    extern EdAccess *ED;
    
    /* definitions of new types   */
#define U64 uint64_t
#define S64 int64_t
#define U32 uint32_t
#define S32 int32_t
#define U16 uint16_t
#define S16 int16_t
#define U8 uint8_t
#define S8 int8_t
    
    /* board values */
#define OCCUPIED 0xf0
#define WHITE 1
#define BLACK 2
#define MAN 4
#define KING 8
#define FREE 0
#define MCP_MARGIN 32
    
#define WHT_MAN 5
#define BLK_MAN 6
#define WHT_KNG 9
#define BLK_KNG  10
    
#define SHIFT_BM 0x180 //  (BLK_MAN << 6) or 384 or 0x180 in hex
#define SHIFT_WM 0x140 // (WHT_MAN << 6) or 320 or 0x140 in hex
#define SHIFT_BK 0x280    // (BLK_KNG << 6) or 640 or 0x280 in hex
#define SHIFT_WK 0x240  //   (WHT_KNG << 6) or 576 or 0x240 in hex
    
#define MOVE_PIECE( move )       ( (U8)  ((move.m[1]) >> 6 ))
#define CC 3 // change color
#define MAXMOVES 60
#define MAXCAPTURES 50
#define MAXHIST 524288
    
#define MATE 30000   // de facto accepted value
#define INFINITY1 30001
#define HASHMATE 29900// handle mates up to 100 ply
#define EC_SIZE  ( 0x8000 )
#define EC_MASK ( EC_SIZE - 1 )
    
#define ED_WIN 30000
#define REHASH 4
#define ETCDEPTH 6  // if depth >= ETCDEPTH do ETC
#define RADIUS 40
    
    //#define KALLISTOAPI WINAPI
    //#undef KALLISTO // uncomment if compile to CheckerBoard
#define KALLISTO // uncomment if compile to KallistoGUI
    
    /*----------> compile options  */
    // not used options
    //#define PERFT
#undef PERFT
#undef MUTE
#undef VERBOSE
#undef STATISTICS
    
    /* getmove return values */
#define DRAW 0
#define WIN 1
#define LOSS 2
#define UNKNOWN 3

#define SQUARE_TO_32(square) (SquareTo32[square])
    
#define EARLY_GAME  ((pos->g_pieces[ (color | KING)  ] > pos->g_pieces[ (color^CC| KING)  ] + 1 ) || ( pos->g_pieces[ (color | KING)  ] + pos->g_pieces[ ( color | MAN ) ] >= 8 ))
#define NOT_ENDGAME ( g_pieces[BLK_KNG] + g_pieces[BLK_MAN] + g_pieces[WHT_KNG ] + g_pieces[WHT_MAN ] > 13 )
#define DO_EXTENSIONS  ( realdepth < depth )
    
    //enum ValueType{
    //	NONE=0, UPPER=1, LOWER=2, EXACT= 1 | 2};
    const int32_t NONE = 0;
    const int32_t UPPER = 1 << 0;
    const int32_t LOWER = 1 << 1;
    const int32_t EXACT = UPPER | LOWER;
    
#ifndef _MSC_VER
#define PACK( __Declaration__ ) __Declaration__ __attribute__((__packed__))
#else
#define PACK( __Declaration__ ) __pragma( pack(push, 1) ) __Declaration__ __pragma( pack(pop) )
#endif
    
PACK(
    typedef struct {
        U32  m_lock;// 4
        S32  m_value;// 4
        S8  m_depth;// 1
        S16  m_age;// 2
        U8 m_best_from;// 1
        U8 m_best_to;// 1
        S8 m_valuetype;// 1
        U8 m_best_from2;// 1
        U8 m_best_to2;// 1
    })  TEntry;
    
#define NODE_OPP(type) (-(type))
#define ISWINSCORE(score) ((score) >= HASHMATE)
#define ISLOSSSCORE(score) ((score) <= -HASHMATE)
#define MAX(x, y) (( (x) >= (y)) ? (x) : (y))
#define MIN(x, y) (( (x) <= (y)) ? (x) : (y))
    struct coor             /* coordinate structure for board coordinates */
    {
        uint32_t x = 0;
        uint32_t y = 0;
    };
    
    struct CBmove    // all the information there is about a move
    {
        int32_t jumps = 0;               // how many jumps are there in this move?
        int32_t newpiece = 0;            // what type of piece appears on to
        int32_t oldpiece = 0;            // what disappears on from
        struct  coor from, to;            // coordinates of the piece in 8x8 notation
        struct coor path[12];            // intermediate path coordinates
        struct  coor del[12];            // squares whose pieces are deleted
        int32_t delpiece[12];            // what is on these squares
    };
    
    struct move2
    {
        uint16_t m[12];
        char path[11]; // was short path[12];
        unsigned char l; // move's length
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(move2* move, uint8_t* &byteArray);
        
        static int32_t parseByteArray(move2* move, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
    };
    
    struct move
    {
        uint16_t m[2];
    };
    
    //////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////// Struct ///////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////
    
#define MAXDEPTH 80
    
    void initCore();
    
    extern const char* StartFen;
    
    struct Position
    {
        int32_t Board[46];
        
        uint32_t num_wpieces = 0;
        uint32_t num_bpieces = 0;
        
        int32_t Color = WHITE;
        
        int32_t g_root_mb = 0;    // root material balance
        
        int32_t realdepth = 0;
        
        U64 RepNum[MAXDEPTH];
        
        U64 HASH_KEY = 0; // global variable HASH_KEY
        
        uint32_t p_list[3][16]; // p_list contains the location of all the pieces of either color
        
        uint32_t indices[41]; // indexes into p_list for a given square
        
        int32_t g_pieces[11]; // global array
        
        bool Reversible[MAXDEPTH+1];
        
        uint32_t c_num[MAXDEPTH+1][16]; // captured number
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Position* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Position* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    public:
        // evalHash
        U64 EvalHash[EC_SIZE];
        
        void EvalHashClear(void);
        
    public:
        void domove(struct move2 *move);
        
        void EI_NewGame(const char* fen);
        
        void EI_SetupBoard(const char *p);
        
        void toFen(char* fen);
        
        void PrintBoard(char* ret);
        
        int32_t russian_draught_isGameFinish();
        
    };
    
    void domove(int32_t *b, struct move2 *move, int32_t stm, Position* pos);
    
    extern uint32_t size; // default size 8 MB
    
#define MAX_SEARCH_TIME 300*1000
#define MAX_SEARCH_DEPTH 30
    
    struct Search
    {
        
    public:
        
        Search()
        {
            TTableInit(size);
            ClearHistory();
        }
        
        ~Search()
        {
            if (ttable != NULL ){
                free(ttable);
                ttable = NULL;
            }
        }
        
    public:
        Position* pos = NULL;
        
    public:
        
        int32_t pickBestMove = 90;
        
        int32_t timeLimit = 10000;
        
    public:
        int32_t g_seldepth = 0; // selective depth i.e.  maximal reached depth
        
        int32_t EdRoot[3];
        
        // killer slots
        U8 killersf1[MAXDEPTH+2];
        U8 killerst1[MAXDEPTH+2];
        
        U8 killersf2[MAXDEPTH+2];
        U8 killerst2[MAXDEPTH+2];
        
        void __inline killer(U8 bestfrom, U8 bestto, int32_t realdepth, int32_t capture);
        
    public:
        bool inSearch = false;
        
        double start = 0, t = 0, maxtime = 0; // time variables
        
        TEntry *ttable = NULL;
        int32_t tableSize = 0;
        U64 MASK = 0;
        
        void TTableInit(uint32_t size);
        
        void hashstore(int32_t value, int32_t depth, U8 best_from, U8 best_to, int32_t f, U64& HASH_KEY);
        
        int32_t hashretrieve(int32_t *tr_depth, int32_t depth, int32_t *value, int32_t alpha, int32_t beta, U8 *best_from, U8 *best_to, U8 *best_from2, U8 *best_to2, int32_t* try_mcp, int& realdepth, U64& HASH_KEY);
        
        int32_t play = 0;
        
        int32_t n = 0;
        int32_t capture = 0;
        struct move2 movelist[MAXMOVES];
        
        struct move2 bestrootmove;
        
        CBmove GCBmove;
        
        uint32_t nodes = 0;
        
        int32_t g_Panic; // add more time
        uint32_t searches_performed_in_game = 0; // age or generation
        
        void ClearHistory(void);
        
    public:
        // history
        
        int32_t history_tabular[1024]; // array used by history heuristics
        
        void hist_succ(U8 from, U8 to, int32_t depth, int32_t capture);
        
        void history_bad(U8 from, U8 to, int32_t depth);
        
    public:
        void EI_Think();
        
        void EI_PonderHit(char *move);
        
        void EI_Analyse();
        
        void setbestmove(struct move2 move);
        
        int32_t rootsearch(int32_t b[46], int32_t alpha, int32_t beta, int32_t depth, int32_t color, int32_t search_type);
        
        int32_t search(int32_t b[46], int32_t depth, int32_t beta, int32_t color, int32_t node_type, bool mcp);
        
        int32_t compute(int32_t b[46], int32_t color, int32_t time, char output[256]);
        
        int32_t QSearch(int32_t b[46], int32_t alpha, int32_t beta, int32_t color);
        
        int32_t PVSearch(int32_t b[46], int32_t depth, int32_t alpha, int32_t beta, int32_t color);
        
        int getmove (int board[8][8], int color, double maxtime, char str[1024], int *playnow, int info, int unused, struct CBmove *move);
        
        int32_t LowDepth(int32_t b[46], int32_t depth, int32_t beta, int32_t color);
        
        void retrievepv(int32_t b[46], char *pv, int32_t color);
        
    };
    
    //////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////// Struct ///////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////
    
    void EI_MakeMove(Position* pos, char *move);
    
    void EI_Ponder();
    
    void EI_Initialization(PF_SearchInfo si, int mem_lim);
    void EI_Stop();
    void EI_SetTimeControl(int time, int inc);
    void EI_SetTime(int time, int otime);
    
    void EI_EGDB(EdAccess *eda);
    void EI_SetSearchInfoEx(PF_SearchInfoEx sie);
    
    uint32_t Gen_Captures(int32_t *b, struct move2 *movelist, int32_t color, uint32_t start, Position* pos);
    uint32_t Gen_Moves(int32_t *b, struct move2 *movelist, int32_t color, Position* pos);
    
    void movetonotation(struct move2 move, char str[80]);
    
    void MoveToStr(move2 m, char *s);
    
}

#endif
