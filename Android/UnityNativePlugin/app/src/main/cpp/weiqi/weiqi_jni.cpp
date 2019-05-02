//
//  jni.cpp
//  weiqi
//
//  Created by Viet Tho on 3/26/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "../Platform.h"
#include <mutex>
#include "weiqi_jni.hpp"
#include "weiqi_random_engine.hpp"
#include "weiqi_timeinfo.hpp"
#include "weiqi_position.hpp"
#include "weiqi_patternprob.hpp"
#include "weiqi_fbook.hpp"
#include "weiqi_pattern3.hpp"

#include "uct/weiqi_uct.hpp"
#include "distributed/engines/weiqi_patternscan.hpp"
#include "distributed/engines/weiqi_patternplay.hpp"
#include "distributed/engines/weiqi_montecarlo.hpp"

namespace weiqi
{
    
    bool weiqiAlreadyInit = false;
    
    char strCapture[] = "capture";
    char strAtariescape[] = "atariescape";
    char strSelfatari[] = "selfatari";
    char strAtari[] = "atari";
    char strBorder[] = "border";
    char strCont[] = "cont";
    char strS[] = "s";
    
    void weiqi_initCore()
    {
        if(!weiqiAlreadyInit){
            weiqiAlreadyInit = true;
            // feature info
            {
                {
                    features[FEAT_CAPTURE].name = strCapture;
                    features[FEAT_CAPTURE].payloads = 64;
                }
                {
                    features[FEAT_AESCAPE].name = strAtariescape;
                    features[FEAT_AESCAPE].payloads = 16;
                }
                {
                    features[FEAT_SELFATARI].name = strSelfatari;
                    features[FEAT_SELFATARI].payloads = 4;
                }
                {
                    features[FEAT_ATARI].name = strAtari;
                    features[FEAT_ATARI].payloads = 4;
                }
                {
                    features[FEAT_BORDER].name = strBorder;
                    features[FEAT_BORDER].payloads = -1;
                }
                {
                    features[FEAT_CONTIGUITY].name = strCont;
                    features[FEAT_CONTIGUITY].payloads = 2;
                }
                {
                    features[FEAT_SPATIAL].name = strS;
                    features[FEAT_SPATIAL].payloads = -1;
                }
            }
            p3hashes_init();
            spatial_init();
            random_init();
            default_ti_init();
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////
    ///////////////// set file multithread ///////////////////
    ///////////////////////////////////////////////////////////////////////////////
    
    std::mutex weiqi_prepareMutex;
    int32_t weiqi_prepareCount = 0;
    volatile bool isWaitSetBookFile = false;
    
    void prepareMultiThreadSetFile(bool isSetFile, bool isEnd)
    {
        if(isSetFile){
            if(!isEnd){
                // start set file
                do{
                    weiqi_prepareMutex.lock();
                    {
                        isWaitSetBookFile = true;
                        if(weiqi_prepareCount==0){
                            printf("prepare finish, will set book file\n");
                            break;
                        }else{
                            printf("prepare not finish, won't set book file\n");
                            weiqi_prepareMutex.unlock();
                            time_sleep(0.1f);
                        }
                    }
                }while (true);
            }else{
                // end set file
                isWaitSetBookFile = false;
                weiqi_prepareMutex.unlock();
            }
        }else{
            if(!isEnd){
                // start method
                while (isWaitSetBookFile) {
                    time_sleep(0.1f);
                }
                weiqi_prepareMutex.lock();
                {
                    weiqi_prepareCount++;
                }
                weiqi_prepareMutex.unlock();
            }else{
                // end method
                weiqi_prepareMutex.lock();
                {
                    weiqi_prepareCount--;
                    if(weiqi_prepareCount<0){
                        weiqi_prepareCount=0;
                        printf("error, why prepareMutext<0\n");
                    }
                }
                weiqi_prepareMutex.unlock();
            }
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////
    ///////////////// set file name ///////////////////
    ///////////////////////////////////////////////////////////////////////////////
    
    bool setSpatialDictFilename(const char* newSpatialDictFileName)
    {
        if(strcmp(spatial_dict_filename, newSpatialDictFileName)!=0){
            strcpy(spatial_dict_filename, newSpatialDictFileName);
            // init
            {
                weiqi_alreadyInitSpatialDict = spatial_dict_init(&cached_dict, false, false);
                DEFAULT_PATTERN_CONFIG.spat_dict = &cached_dict;
            }
        }else{
            printf("error, why same spatialDictFileName: %s\n", spatial_dict_filename);
        }
        return true;
    }
    
    bool setPatternFileName(const char* newPatternFileName)
    {
        if(strcmp(patternFileName, newPatternFileName)!=0){
            if(weiqi_alreadyInitSpatialDict){
                strcpy(patternFileName, newPatternFileName);
                weiqi_alreadyInitPatternFile = my_pattern_pdict_init(patternFileName);
            }else{
                printf("error, initSpatialDict not success: don't init pDict\n");
            }
        }else{
            printf("error, why same spatialDictFileName\n");
        }
        return true;
    }
    
    std::mutex fileMutext;
    
    bool weiqi_alreadyInitSpatialDict = false;
    bool weiqi_alreadyInitPatternFile = false;
    
    bool weiqi_setFileName(const char* newSpatialDictFileName, const char* newPatternFileName)
    {
        fileMutext.lock();
        {
            prepareMultiThreadSetFile(true, false);
            {
                setSpatialDictFilename(newSpatialDictFileName);
                setPatternFileName(newPatternFileName);
            }
            prepareMultiThreadSetFile(true, true);
        }
        fileMutext.unlock();
        // return
        return true;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// set book  /////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    
    char bookPath[500] = "";
    
    bool weiqi_setBookPath(const char* newBookPath)
    {
        strcpy(bookPath, newBookPath);
        return true;
    }
    
    struct fbook* my_fbook_init(char *filename, struct board *b)
    {
        printf("my_fbook_init: %s\n", filename);
        bool isAndroidAsset = false;
#ifdef Android
        {
            assetistream f(assetManager, filename);
            if(f.isOpen()){
                isAndroidAsset = true;
                // init fbook
                struct fbook* fbook = (struct fbook*)calloc(1, sizeof(*fbook));
                fbook->bsize = board_size(b);
                fbook->handicap = b->handicap;
                /* We do not set handicap=1 in case of too low komi on purpose;
                 * we want to go with the no-handicap fbook for now. */
                for (int32_t i = 0; i < 1<<fbook_hash_bits; i++)
                    fbook->moves[i] = pass;

                /* Scratch board where we lay out the sequence;
                 * one for each transposition. */
                struct board *bs[8];
                for (int32_t i = 0; i < 8; i++) {
                    bs[i] = new struct board;
                    board_init(bs[i], NULL);
                    board_resize(bs[i], fbook->bsize - 2);
                }

                std::string linebuf;
                while (getline(f, linebuf)) {
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "linebuf: %s\n", linebuf.c_str());
                    char *line = const_cast<char*>(linebuf.c_str());

                    /* Format of line is:
                     * BSIZE COORD COORD COORD... | COORD
                     * BSIZE/HANDI COORD COORD COORD... | COORD */
                    int32_t bsize = (int32_t)strtol(line, &line, 10);
                    if (bsize != fbook->bsize - 2)
                        continue;
                    int32_t handi = 0;
                    if (*line == '/') {
                        line++;
                        handi = (int)strtol(line, &line, 10);
                    }
                    if (handi != fbook->handicap)
                        continue;
                    while (isspace(*line)) line++;

                    for (int32_t i = 0; i < 8; i++) {
                        board_clear(bs[i]);
                        bs[i]->last_move.color = S_WHITE;
                    }

                    while (*line != '|') {
                        coord_t c = str2coord(line, fbook->bsize);

                        for (int32_t i = 0; i < 8; i++) {
                            coord_t coord = coord_transform(b, c, i);
                            struct move m;
                            {
                                m.coord = coord;
                                m.color = stone_other(bs[i]->last_move.color);
                            }
                            int32_t ret = board_play(bs[i], &m);
                            {
                                // assert(ret >= 0);
                                if(!(ret >= 0)){
                                    printf("error, assert(ret >= 0)\n");
                                }
                            }
                        }

                        while (!isspace(*line)) line++;
                        while (isspace(*line)) line++;
                    }

                    line++;
                    while (isspace(*line)) line++;

                    /* In case of multiple candidates, pick one with
                     * exponentially decreasing likelihood. */
                    while (strchr(line, ' ') && fast_random(2)) {
                        line = strchr(line, ' ');
                        while (isspace(*line)) line++;
                    }

                    coord_t c = str2coord(line, fbook->bsize);
                    for (int32_t i = 0; i < 8; i++) {
                        coord_t coord = coord_transform(b, c, i);
#if 0
                        char conflict = is_pass(fbook->moves[bs[i]->hash & fbook_hash_mask]) ? '+' : 'C';
                if (conflict == 'C')
                    for (int32_t j = 0; j < i; j++)
                        if (bs[i]->hash == bs[j]->hash)
                            conflict = '+';
                if (conflict == 'C') {
                    hash_t hi = bs[i]->hash;
                    while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash)
                        hi++;
                    if (fbook->hashes[hi & fbook_hash_mask] == bs[i]->hash)
                        hi = 'c';
                }
                printf("my_fbook_init1 %c %"PRIhash":%"PRIhash" (<%d> %s)\n", conflict, bs[i]->hash & fbook_hash_mask, bs[i]->hash, i, linebuf);
#endif
                        hash_t hi = bs[i]->hash;
                        while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash){
                            hi++;
                        }
                        // add
                        {
                            fbook->moves[hi & fbook_hash_mask] = coord;
                            fbook->hashes[hi & fbook_hash_mask] = bs[i]->hash;
                            fbook->movecnt++;
                            // printf("add book move: %d, %llu, %llu, %d, %d\n", coord, hi, hi & fbook_hash_mask, fbook->movecnt, fbook_hash_mask);
                        }
                    }
                }

                for (int32_t i = 0; i < 8; i++) {
                    board_done(bs[i]);
                }

                if (!fbook->movecnt) {
                    /* Empty book is not worth the hassle. */
                    fbook_done(fbook);
                    return NULL;
                }
                printf("fbook movecnt: %d\n", fbook->movecnt);
                return fbook;
            } else {
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "my_fbook_init: not open: %s\n", filename);
            }
        }
#endif
        if(!isAndroidAsset){
            FILE *f = fopen_data_file(filename, "r");
            if (!f) {
                perror(filename);
                return NULL;
            }

            struct fbook* fbook = (struct fbook*)calloc(1, sizeof(*fbook));
            fbook->bsize = board_size(b);
            fbook->handicap = b->handicap;
            /* We do not set handicap=1 in case of too low komi on purpose;
             * we want to go with the no-handicap fbook for now. */
            for (int32_t i = 0; i < 1<<fbook_hash_bits; i++)
                fbook->moves[i] = pass;

            if (DEBUGL(1))
                printf("Loading opening fbook %s...\n", filename);

            /* Scratch board where we lay out the sequence;
             * one for each transposition. */
            struct board *bs[8];
            for (int32_t i = 0; i < 8; i++) {
                bs[i] = new struct board;
                board_init(bs[i], NULL);
                board_resize(bs[i], fbook->bsize - 2);
            }

            char linebuf[1024];
            while (fgets(linebuf, sizeof(linebuf), f)) {
                // printf("linebuf: %s\n", linebuf);
                char *line = linebuf;
                linebuf[strlen(linebuf) - 1] = 0; // chop

                /* Format of line is:
                 * BSIZE COORD COORD COORD... | COORD
                 * BSIZE/HANDI COORD COORD COORD... | COORD */
                int32_t bsize = (int32_t)strtol(line, &line, 10);
                if (bsize != fbook->bsize - 2)
                    continue;
                int32_t handi = 0;
                if (*line == '/') {
                    line++;
                    handi = (int)strtol(line, &line, 10);
                }
                if (handi != fbook->handicap)
                    continue;
                while (isspace(*line)) line++;

                for (int32_t i = 0; i < 8; i++) {
                    board_clear(bs[i]);
                    bs[i]->last_move.color = S_WHITE;
                }

                while (*line != '|') {
                    coord_t c = str2coord(line, fbook->bsize);

                    for (int32_t i = 0; i < 8; i++) {
                        coord_t coord = coord_transform(b, c, i);
                        struct move m;
                        {
                            m.coord = coord;
                            m.color = stone_other(bs[i]->last_move.color);
                        };
                        int32_t ret = board_play(bs[i], &m);
                        {
                            // assert(ret >= 0);
                            if(!(ret >= 0)){
                                printf("error, assert(ret >= 0)\n");
                            }
                        }
                    }

                    while (!isspace(*line)) line++;
                    while (isspace(*line)) line++;
                }

                line++;
                while (isspace(*line)) line++;

                /* In case of multiple candidates, pick one with
                 * exponentially decreasing likelihood. */
                while (strchr(line, ' ') && fast_random(2)) {
                    line = strchr(line, ' ');
                    while (isspace(*line)) line++;
                }

                coord_t c = str2coord(line, fbook->bsize);
                for (int32_t i = 0; i < 8; i++) {
                    coord_t coord = coord_transform(b, c, i);
#if 0
                    char conflict = is_pass(fbook->moves[bs[i]->hash & fbook_hash_mask]) ? '+' : 'C';
                if (conflict == 'C')
                    for (int32_t j = 0; j < i; j++)
                        if (bs[i]->hash == bs[j]->hash)
                            conflict = '+';
                if (conflict == 'C') {
                    hash_t hi = bs[i]->hash;
                    while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash)
                        hi++;
                    if (fbook->hashes[hi & fbook_hash_mask] == bs[i]->hash)
                        hi = 'c';
                }
                printf("my_fbook_init1 %c %"PRIhash":%"PRIhash" (<%d> %s)\n", conflict, bs[i]->hash & fbook_hash_mask, bs[i]->hash, i, linebuf);
#endif
                    hash_t hi = bs[i]->hash;
                    while (!is_pass(fbook->moves[hi & fbook_hash_mask]) && fbook->hashes[hi & fbook_hash_mask] != bs[i]->hash){
                        hi++;
                    }
                    // add
                    {
                        fbook->moves[hi & fbook_hash_mask] = coord;
                        fbook->hashes[hi & fbook_hash_mask] = bs[i]->hash;
                        fbook->movecnt++;
                        // printf("add book move: %d, %llu, %llu, %d, %d\n", coord, hi, hi & fbook_hash_mask, fbook->movecnt, fbook_hash_mask);
                    }
                }
            }

            for (int32_t i = 0; i < 8; i++) {
                board_done(bs[i]);
            }

            fclose(f);

            if (!fbook->movecnt) {
                /* Empty book is not worth the hassle. */
                fbook_done(fbook);
                return NULL;
            }
            printf("fbook movecnt: %d\n", fbook->movecnt);
            return fbook;
        } else {
            return NULL;
        }
    }
    
    struct BookCache bookCaches[21];
    
    void make_fbook_cache(struct fbook* fbook, char *filename, struct board *b)
    {
        // make cache
        {
            // check already have cache
            bool alreadyCache = false;
            {
                for(int32_t i=0; i<21; i++){
                    if(bookCaches[i].fbook!=NULL){
                        if(board_size(b)==bookCaches[i].fbook->bsize){
                            printf("error, why already have cache\n");
                            alreadyCache = true;
                            break;
                        }
                    }
                }
            }
            // cache
            if(!alreadyCache){
                for(int32_t i=0; i<21; i++){
                    if(bookCaches[i].fbook==NULL){
                        printf("make cache fbook success: %d, %p\n", i, fbook);
                        bookCaches[i].fbook = fbook;
                        return;
                    }
                }
            }
        }
        // release data
        {
            printf("error, why cannot make cache fbook\n");
            free(fbook);
        }
    }
    
    std::mutex initBookMtx;
    
    struct fbook* find_fbook_cache(char *filename, struct board *b)
    {
        // find fbook first, not find init
        {
            for(int32_t i=0; i<21; i++){
                if(bookCaches[i].fbook!=NULL){
                    if(board_size(b)==bookCaches[i].fbook->bsize){
                        printf("find fbook cache\n");
                        return bookCaches[i].fbook;
                    }else{
                        printf("why board size different: %d, %d\n", board_size(b), bookCaches[i].fbook->bsize);
                    }
                }else{
                    // printf("find book cache null\n");
                }
            }
        }
        initBookMtx.lock();
        fbook* fbook = NULL;
        // TODO can hoan thien
        for(int32_t i=0; i<21; i++){
            if(bookCaches[i].fbook!=NULL){
                if(board_size(b)==bookCaches[i].fbook->bsize){
                    printf("find fbook cache\n");
                    fbook = bookCaches[i].fbook;
                    break;
                }else{
                    printf("why board size different: %d, %d\n", board_size(b), bookCaches[i].fbook->bsize);
                }
            }else{
                // printf("find book cache null\n");
            }
        }
        // make new fbook
        if(fbook==NULL){
            printf("cannot find fbook_cache\n");
            // init book
            fbook = my_fbook_init(filename, b);
            // make fbook cache
            if(fbook!=NULL){
                make_fbook_cache(fbook, filename, b);
            }else{
                printf("cannot make new fbook\n");
            }
        }
        initBookMtx.unlock();
        return fbook;
    }
    
    /* Check if we can make a move along the fbook right away.
     * Otherwise return pass. */
    coord_t my_fbook_check(struct fbook* fbook, struct board *board)
    {
        hash_t hi = board->hash;
        // printf("my_fbook_check: hash: %llu\n", hi);
        coord_t cf = pass;
        while (!is_pass(fbook->moves[hi & fbook_hash_mask])) {
            // printf("check book move: hash %llu, %llu\n", (hi & fbook_hash_mask), hi);
            if (fbook->hashes[hi & fbook_hash_mask] == board->hash) {
                cf = fbook->moves[hi & fbook_hash_mask];
                // printf("find book move: hash %llu, %llu, %d\n", (hi & fbook_hash_mask), hi, cf);
                break;
            }
            hi++;
        }
        if (!is_pass(cf)) {
            if (DEBUGL(1))
                printf("fbook match %" PRIhash ":%" PRIhash "\n", board->hash, board->hash & fbook_hash_mask);
        } else {
            /* No match, also prevent further fbook usage
             * until the next clear_board. */
            if (DEBUGL(4))
                printf("fbook out %" PRIhash ":%" PRIhash "\n", board->hash, board->hash & fbook_hash_mask);
        }
        return cf;
    }
    
    coord_t getBookMove(Position* pos)
    {
        coord_t coord = pass;
        // find
        {
            // find fbook
            struct fbook* fbook = find_fbook_cache(bookPath, &pos->b);
            // find book move
            if(fbook!=NULL){
                // find coord
                coord = my_fbook_check(fbook, &pos->b);
            }else{
                printf("error, why fbook null\n");
            }
        }
        // return
        return coord;
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// normal method  /////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    int32_t weiqi_makeDefaultPosition(int32_t size, floating_t komi, go_ruleset rule, int32_t handicap, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        // correct parameter
        {
            if(size<5) {
                printf("error, size not correct\n");
                size = 5;
            } else if(size>19) {
                size = 19;
            }
        }
        // make position
        struct Position position;
        {
            board_init(&position.b, nullptr);
            board_resize(&position.b, size);
            board_clear(&position.b);
            position.b.rules = rule;
            position.b.komi = komi;
            board_handicap(&position.b, handicap, nullptr);
            // TODO co them vao ko nhi?
            {
                board_statics_init(&position.b);
            }
            position.updateScoreAndOwnerMap();
        }
        // convert
        int32_t length = Position::convertToByteArray(&position, outRet);
        // return
        prepareMultiThreadSetFile(false, true);
        return length;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////// print dead groups //////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////
    
    void my_print_dead_groups(char* ret, struct board *b, struct move_queue *mq)
    {
        sprintf(ret, "%sdead groups: %d\n", ret, mq->moves);
        if (!mq->moves){
            sprintf(ret, "%s  none\n", ret);
        }
        for (uint32_t i = 0; i < mq->moves; i++) {
            sprintf(ret, "%s  ", ret);
            foreach_in_group(b, mq->move[i]) {
                char strStone[20];
                {
                    coord2sstr(strStone, c, b);
                }
                sprintf(ret, "%s%s ", ret, strStone);
            } foreach_in_group_end;
            sprintf(ret, "%s\n", ret);
        }
    }
    
    void my_print_owner_map(char* f, struct Position* position)
    {
        int32_t boardSize = board_size(&position->b);
        sprintf(f, "%sOwnerMap:\n", f);
        // print top
        {
            {
                char asdf[] = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
                sprintf(f, "%s      ", f);
                for (int32_t x = 1; x < boardSize - 1; x++){
                    sprintf(f, "%s%c ", f, asdf[x - 1]);
                }
                sprintf(f, "%s ", f);
            }
            sprintf(f, "%s\n", f);
            {
                sprintf(f, "%s    +-", f);
                for (int32_t x = 1; x < boardSize - 1; x++)
                    sprintf(f, "%s--", f);
                sprintf(f, "%s+", f);
            }
            sprintf(f, "%s\n", f);
        }
        // print row
        {
            // for row
            for (int32_t y = boardSize - 2; y >= 1; y--){
                // print row
                sprintf(f, "%s %2d | ", f, y);
                for (int32_t x = 1; x < boardSize - 1; x++){
                    int32_t coord = x + boardSize * y;
                    switch (position->scoreOwnerMap[coord]) {
                        case 0:
                        {
                            sprintf(f, "%s. ", f);
                        }
                            break;
                        case 1:
                        {
                            // black
                            char str[3];
                            {
                                strcpy(str, "X ");
                            }
                            // choose correct char to print
                            {
                                enum stone s = position->b.b[coord];
                                // cho trong
                                if(s==S_NONE){
                                    strcpy(str, "x ");
                                }
                                // quan den
                                else if(s==S_BLACK){
                                    strcpy(str, "X ");
                                }
                                // quan trang capture
                                else if(s==S_WHITE){
                                    strcpy(str, "x)");
                                }
                            }
                            sprintf(f, "%s%s", f, str);
                        }
                            break;
                        case 2:
                        {
                            // white
                            char str[3];
                            {
                                strcpy(str, "X ");
                            }
                            // choose correct char to print
                            {
                                enum stone s = position->b.b[coord];
                                // cho trong
                                if(s==S_NONE){
                                    strcpy(str, "o ");
                                }
                                // quan trang
                                else if(s==S_WHITE){
                                    strcpy(str, "O ");
                                }
                                // quan den capture
                                else if(s==S_WHITE){
                                    strcpy(str, "o)");
                                }
                            }
                            sprintf(f, "%s%s", f, str);
                        }
                            break;
                        case 3:
                        {
                            // dame
                            sprintf(f, "%s. ", f);
                        }
                            break;
                        default:
                        {
                            //printf("error, don't know score owner map value: %d\n", value);
                            sprintf(f, "%s  ", f);
                        }
                            break;
                    }
                }
                sprintf(f, "%s|\n", f);
            }
        }
        // print bottom
        {
            {
                sprintf(f, "%s    +-", f);
                for (int32_t x = 1; x < board_size(&position->b) - 1; x++)
                    sprintf(f, "%s--", f);
                sprintf(f, "%s+", f);
            }
            sprintf(f, "%s\n", f);
        }
    }
    
    void weiqi_printPosition(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // print
        {
            // buffer
            char f[10240];
            // init
            {
                f[0] = 0;
                sprintf(f, "%s\n", f);
            }
            {
                // board
                {
                    sprintf(f, "%s\n", f);
                    board_print_ownermap(&pos.b, f, NULL);
                }
                // print owner map
                {
                    sprintf(f, "%s\n", f);
                    my_print_owner_map(f, &pos);
                }
                // dead group
                {
                    sprintf(f, "%s\n", f);
                    my_print_dead_groups(f, &pos.b, &pos.deadgroup);
                }
                // score
                sprintf(f, "%s\n black score: %d, white score: %d, dame: %d, score: %f", f, pos.scoreBlack, pos.scoreWhite, pos.dame, pos.score);
            }
            printf("%s\n", f);
            printf("printPosition: %zu\n", strlen(f));
        }
    }
    
    int32_t weiqi_makeCustomPosition(int32_t size, floating_t komi, go_ruleset rule, int* board, int32_t captureBlack, int32_t captureWhite, int lastMoveColor, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        // correct parameter
        {
            if(size<5) {
                printf("error, size not correct\n");
                size = 5;
            } else if(size>19) {
                size = 19;
            }
        }
        // make position
        struct Position pos;
        {
            board_init(&pos.b, nullptr);
            board_resize(&pos.b, size);
            board_clear(&pos.b);
            pos.b.rules = rule;
            pos.b.komi = komi;
            // TODO co them vao ko nhi?
            {
                board_statics_init(&pos.b);
            }
            // init board
            {
                int32_t blackCoords[BOARD_MAX_COORDS];
                int32_t blackCount = 0;
                int32_t whiteCoords[BOARD_MAX_COORDS];
                int32_t whiteCount = 0;
                // add coord
                for(int coord=0; coord<BOARD_MAX_COORDS; coord++){
                    if (board[coord]==S_BLACK) {
                        blackCoords[blackCount] = coord;
                        blackCount++;
                    } else if(board[coord]==S_WHITE){
                        whiteCoords[whiteCount] = coord;
                        whiteCount++;
                    }
                }
                // find minCount
                int32_t minCount = blackCount < whiteCount ? blackCount : whiteCount;
                // add black and white
                for(int32_t i=0; i<minCount; i++){
                    // add black
                    {
                        struct move m;
                        {
                            m.coord = blackCoords[i];
                            m.color = S_BLACK;
                        }
                        board_play(&pos.b, &m);
                    }
                    // add white
                    {
                        struct move m;
                        {
                            m.coord = whiteCoords[i];
                            m.color = S_WHITE;
                        }
                        board_play(&pos.b, &m);
                    }
                }
                // add black or white
                {
                    // add black
                    {
                        for(int32_t i=minCount; i<blackCount; i++){
                            // add black
                            {
                                struct move m;
                                {
                                    m.coord = blackCoords[i];
                                    m.color = S_BLACK;
                                }
                                board_play(&pos.b, &m);
                            }
                            // add pass
                            if(i<blackCount-1){
                                struct move m;
                                {
                                    m.coord = pass;
                                    m.color = S_BLACK;
                                }
                                board_play(&pos.b, &m);
                            }
                        }
                    }
                    // add white
                    {
                        for(int32_t i=minCount; i<whiteCount; i++){
                            // add pass
                            {
                                struct move m;
                                {
                                    m.coord = pass;
                                    m.color = S_WHITE;
                                }
                                board_play(&pos.b, &m);
                            }
                            // add white
                            {
                                struct move m;
                                {
                                    m.coord = whiteCoords[i];
                                    m.color = S_WHITE;
                                }
                                board_play(&pos.b, &m);
                            }
                        }
                    }
                }
            }
            // capture
            {
                /*pos.b.captures[S_BLACK] = captureBlack;
                pos.b.captures[S_WHITE] = captureWhite;*/
            }
            // lastMove
            {
                // get current color
                int currentColor = S_BLACK;
                {
                    if(pos.b.last_move.color==S_BLACK){
                        currentColor = S_WHITE;
                    }else{
                        currentColor = S_BLACK;
                    }
                }
                // change
                if(currentColor!=lastMoveColor){
                    // pass
                    struct move m;
                    {
                        m.coord = pass;
                        m.color = (enum stone)currentColor;
                    }
                    board_play(&pos.b, &m);
                }
            }
        }
        // print
        {
            // buffer
            char f[10240];
            // init
            {
                f[0] = 0;
                sprintf(f, "%s\n", f);
            }
            {
                // board
                {
                    sprintf(f, "%s\n", f);
                    board_print_ownermap(&pos.b, f, NULL);
                }
                // score
                sprintf(f, "%s\n black score: %d, white score: %d, dame: %d, score: %f", f, pos.scoreBlack, pos.scoreWhite, pos.dame, pos.score);
            }
            printf("CustomBoard:\n %s\n", f);
            printf("printPosition: %zu\n", strlen(f));
        }
        // convert
        int32_t length = Position::convertToByteArray(&pos, outRet);
        // return
        prepareMultiThreadSetFile(false, true);
        return length;
    }

    int32_t weiqi_isGameFinish(uint8_t* positionBytes, int32_t length, bool canCorrect)
    {
        prepareMultiThreadSetFile(false, false);
        int32_t ret = 0;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // printf("pos moves: %d\n", pos.b.moves);
            if(pos.b.moves>=2){
                // resign
                if(pos.b.last_move.coord==resign){
                    switch (pos.b.last_move.color) {
                        case S_BLACK:
                            // black resign, white win
                            ret = 2;
                            break;
                        case S_WHITE:
                            // white resign, black win
                            ret = 1;
                            break;
                        default:
                            break;
                    }
                    // score
                    {
                        // find dead group list
                        struct move_queue q;
                        {
                            q.moves = 0;
                        }
                        {
                            // make uct
                            struct uct* u = uct_state_init(NULL, &pos.b);
                            {
                                uct_dead_group_list(u, &pos.b, &q);
                            }
                            my_uct_done(u);
                        }
                        printf("find dead group list: %d\n", q.moves);
                        // find score
                        floating_t score = board_official_score(&pos.b, &q);
                        printf("counted score %.1f\n", score);
                    }
                }
                // pass
                else if((pos.b.last_move.coord==pass && pos.b.last_move2.coord==pass) || (pos.b.moves>=pos.b.size*pos.b.size || pos.b.moves>=BOARD_MAX_MOVES)){
                    // find dead group list
                    struct move_queue q;
                    {
                        q.moves = 0;
                    }
                    {
                        // make uct
                        struct uct* u = uct_state_init(NULL, &pos.b);
                        {
                            uct_dead_group_list(u, &pos.b, &q);
                        }
                        my_uct_done(u);
                    }
                    // find score
                    floating_t score = board_official_score(&pos.b, &q);
                    // printf("counted score %.1f\n", score);
                    if (score == 0){
                        printf("score draw\n");
                        // draw
                        ret = 3;
                    } else if (score > 0){
                        printf("W+%.1f\n", score);
                        // white win
                        ret = 2;
                    } else {
                        printf("B+%.1f\n", -score);
                        // black win
                        ret = 1;
                    }
                }
            }else{
                printf("not enough move to finish game\n");
            }
        }
        prepareMultiThreadSetFile(false, true);
        return ret;
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////// let computer think ////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////


    int32_t weiqi_letComputerThink(uint8_t* positionBytes, int32_t length, bool canCorrect, bool canResign, bool usebook, int64_t time, int32_t games, engine_id engine, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        struct move ret;
        {
            ret.color = S_BLACK;
            ret.coord = pass;
        }
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // find stone
            stone color = S_BLACK;
            {
                switch (pos.b.last_move.color) {
                    case S_NONE:
                        color = S_BLACK;
                        break;
                    case S_BLACK:
                        color = S_WHITE;
                        break;
                    case S_WHITE:
                        color = S_BLACK;
                        break;
                    default:
                        printf("error, unknown last move color: %d\n", pos.b.last_move.color);
                        break;
                }
            }
            // TODO Test
            /*{
                if(color==S_BLACK){
                    pos.b.komi = 1.2f*pos.b.komi;
                }
            }*/
            bool pass_all_alive = true;
            // book
            bool haveBookMove = false;
            if(usebook){
                coord_t coord = getBookMove(&pos);
                if(coord!=pass){
                    haveBookMove = true;
                    // update move
                    {
                        ret.color = color;
                        ret.coord = coord;
                    }
                    // print book move
                    {
                        char strCoord[256];
                        coord2str(strCoord, coord, &pos.b);
                        printf("find book move: %s\n", strCoord);
                    }
                }else{
                    printf("don't find book move\n");
                }
            }
            // find ai move
            if(!haveBookMove){
                // time
                struct time_info ti;
                {
                    ti.period = TT_NULL;
                }
                {
                    // set time per turn
                    {
                        int64_t mTime = time;
                        if(mTime<=0){
                            mTime = 1200;
                        }
                        char buffer [50];
                        sprintf(buffer, "_%lld", mTime);
                        time_parse(&ti, buffer);
                        // start time
                        {
                            ti.len.t.timer_start = time_now();
                        }
                    }
                    // MC_GAMES
                    {
                        if(games<10){
                            // printf("erro, why games<0");
                            ti.len.games = MC_GAMES;
                        }else{
                            ti.len.games = games;
                        }
                    }
                }
                // find by engine
                switch (engine) {
                    case E_RANDOM:
                    {
                        int32_t coord = random_genmove(&pos.b, color, pass_all_alive);
                        // update
                        {
                            ret.color = color;
                            ret.coord = coord;
                        }
                    }
                        break;
                        /*case E_PATTERNSCAN:
                         {
                         // TODO ko co tim ai move
                         }
                         break;*/
                    case E_PATTERNPLAY:
                    {
                        struct patternplay* pp = patternplay_state_init(NULL);
                        // genmove
                        int32_t coord = patternplay_genmove(pp, &pos.b, &ti, color, pass_all_alive);
                        // update
                        {
                            ret.color = color;
                            ret.coord = coord;
                        }
                        // release data
                        free(pp);
                    }
                        break;
                    case E_MONTECARLO:
                    {
                        struct montecarlo* mc = montecarlo_state_init(NULL, &pos.b);
                        // genmove
                        int32_t coord = montecarlo_genmove(mc, &pos.b, &ti, color, pass_all_alive);
                        // update
                        {
                            ret.color = color;
                            ret.coord = coord;
                        }
                        // release data
                        montecarlo_done(mc);
                    }
                        break;
                    case E_UCT:
                    default:
                        // uct
                    {
                        // make uct
                        struct uct* u = uct_state_init(NULL, &pos.b);
                        {
                            u->time_start = now();
                            u->time = time;
                        }
                        // genmove
                        int32_t coord = uct_genmove(u, &pos.b, &ti, color, pass_all_alive);
                        // update
                        {
                            ret.color = color;
                            ret.coord = coord;
                        }
                        // release data
                        my_uct_done(u);
                    }
                        break;
                }
            }else{
                printf("already have book move, so not search\n");
            }
            // TODO test qhash
            {
                // printf("qhash: %llu, %llu, %llu, %llu\n", pos.b.qhash[0], pos.b.qhash[1], pos.b.qhash[2], pos.b.qhash[3]);
                // coord transform
                /*{
                    char strCoords[2000];
                    {
                        strCoords[0] = 0;
                    }
                    for(int32_t i=0; i<8; i++){
                        coord_t coord = coord_transform(&pos.b, ret.coord, i);
                        char strCoord[256];
                        {
                            strCoord[0] = 0;
                        }
                        {
                            coord2sstr(strCoord, coord, &pos.b);
                        }
                        sprintf(strCoords, "%s%d(%s), ", strCoords, coord, strCoord);
                    }
                    // printf("coord transform: %s\n", strCoords);
                }*/
                
            }
        }
        // can resign?
        if(!canResign){
            if(ret.coord==resign){
                printf("error, cannot resign\n");
                ret.coord = pass;
            }
        }
        // return
        int32_t moveLength = move::convertToByteArray(&ret, outRet);
        prepareMultiThreadSetFile(false, true);
        return moveLength;
    }
    
    void weiqi_printMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        // TODO ham nay co loi
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        struct move move;
        {
            move::parseByteArray(&move, moveBytes, moveLength, 0);
        }
        // print
        {
            char strCoord[256];
            coord2str(strCoord, move.coord, &pos.b);
            switch (move.color) {
                case S_BLACK:
                    printf("Black: %s, %d\n", strCoord, move.coord);
                    break;
                case S_WHITE:
                    printf("White: %s, %d\n", strCoord, move.coord);
                    break;
                default:
                    printf("error, unknown move color\n");
                    break;
            }
        }
    }
    
    bool weiqi_isLegalMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength)
    {
        prepareMultiThreadSetFile(false, false);
        bool ret = false;
        {
            // make position
            struct Position pos;
            {
                Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
            }
            // make move
            struct move move;
            {
                move::parseByteArray(&move, moveBytes, moveLength, 0);
            }
            // check
            if (board_play(&pos.b, &move) < 0) {
                printf("error, illegal move: %d %d\n", move.coord, move.color);
                ret = false;
            } else {
                // printf("legal move: %d %d\n", move.coord, move.color);
                ret = true;
            }
        }
        // return
        prepareMultiThreadSetFile(false, true);
        return ret;
    }

    int32_t weiqi_doMove(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* moveBytes, int32_t moveLength, bool needUpdateScore, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // make move
        struct move move;
        {
            move::parseByteArray(&move, moveBytes, moveLength, 0);
        }
        // play move
        if (board_play(&pos.b, &move) < 0) {
            printf("error, illegal move: %d %d\n", move.coord, move.color);
        } else {
            // legal move, so update score and owner map
            if(needUpdateScore){
                pos.updateScoreAndOwnerMap();
            }
            
            // TODO Test make custom postion
            {
                int32_t size = pos.b.size-2;
                float komi = pos.b.komi;
                go_ruleset rule = pos.b.rules;
                // board
                int board[BOARD_MAX_COORDS];
                {
                    for(int i=0; i<BOARD_MAX_COORDS; i++){
                        board[i] = pos.b.b[i];
                    }
                }
                int captureBlack = pos.b.captures[S_BLACK];
                int captureWhite = pos.b.captures[S_WHITE];
                uint8_t* newOutCustomPosition;
                weiqi_makeCustomPosition(size, komi, rule, board, captureBlack, captureWhite, pos.b.last_move.color, newOutCustomPosition);
                free(newOutCustomPosition);
            }
        }
        // return
        int32_t newLength = Position::convertToByteArray(&pos, outRet);
        prepareMultiThreadSetFile(false, true);
        return newLength;
    }

    int32_t weiqi_updateScore(uint8_t* positionBytes, int32_t length, bool canCorrect, uint8_t* &outRet)
    {
        prepareMultiThreadSetFile(false, false);
        // make position
        struct Position pos;
        {
            Position::parseByteArray(&pos, positionBytes, length, 0, canCorrect);
        }
        // update score
        pos.updateScoreAndOwnerMap();
        // return
        int32_t newLength = Position::convertToByteArray(&pos, outRet);
        prepareMultiThreadSetFile(false, true);
        return newLength;
    }
}
