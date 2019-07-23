#include <algorithm>
#include <fstream>
#include <iostream>
#include "reversi_eval.hpp"

#include "../Platform.h"
#ifdef Android
#include <android/log.h>
#endif

using namespace std;

namespace Reversi
{
    std::string bookPath = "";
    
    // Converts the packed bits for one side into an index for the pattern values
    // array.
    const int32_t PIECES_TO_INDEX[1024] = {
        0, 1, 3, 4, 9, 10, 12, 13, 27, 28, 30, 31, 36, 37, 39, 40, 81, 82, 84, 85, 90,
        91, 93, 94, 108, 109, 111, 112, 117, 118, 120, 121, 243, 244, 246, 247, 252,
        253, 255, 256, 270, 271, 273, 274, 279, 280, 282, 283, 324, 325, 327, 328, 333,
        334, 336, 337, 351, 352, 354, 355, 360, 361, 363, 364, 729, 730, 732, 733, 738,
        739, 741, 742, 756, 757, 759, 760, 765, 766, 768, 769, 810, 811, 813, 814, 819,
        820, 822, 823, 837, 838, 840, 841, 846, 847, 849, 850, 972, 973, 975, 976, 981,
        982, 984, 985, 999, 1000, 1002, 1003, 1008, 1009, 1011, 1012, 1053, 1054, 1056,
        1057, 1062, 1063, 1065, 1066, 1080, 1081, 1083, 1084, 1089, 1090, 1092, 1093,
        2187, 2188, 2190, 2191, 2196, 2197, 2199, 2200, 2214, 2215, 2217, 2218, 2223,
        2224, 2226, 2227, 2268, 2269, 2271, 2272, 2277, 2278, 2280, 2281, 2295, 2296,
        2298, 2299, 2304, 2305, 2307, 2308, 2430, 2431, 2433, 2434, 2439, 2440, 2442,
        2443, 2457, 2458, 2460, 2461, 2466, 2467, 2469, 2470, 2511, 2512, 2514, 2515,
        2520, 2521, 2523, 2524, 2538, 2539, 2541, 2542, 2547, 2548, 2550, 2551, 2916,
        2917, 2919, 2920, 2925, 2926, 2928, 2929, 2943, 2944, 2946, 2947, 2952, 2953,
        2955, 2956, 2997, 2998, 3000, 3001, 3006, 3007, 3009, 3010, 3024, 3025, 3027,
        3028, 3033, 3034, 3036, 3037, 3159, 3160, 3162, 3163, 3168, 3169, 3171, 3172,
        3186, 3187, 3189, 3190, 3195, 3196, 3198, 3199, 3240, 3241, 3243, 3244, 3249,
        3250, 3252, 3253, 3267, 3268, 3270, 3271, 3276, 3277, 3279, 3280, 6561, 6562,
        6564, 6565, 6570, 6571, 6573, 6574, 6588, 6589, 6591, 6592, 6597, 6598, 6600,
        6601, 6642, 6643, 6645, 6646, 6651, 6652, 6654, 6655, 6669, 6670, 6672, 6673,
        6678, 6679, 6681, 6682, 6804, 6805, 6807, 6808, 6813, 6814, 6816, 6817, 6831,
        6832, 6834, 6835, 6840, 6841, 6843, 6844, 6885, 6886, 6888, 6889, 6894, 6895,
        6897, 6898, 6912, 6913, 6915, 6916, 6921, 6922, 6924, 6925, 7290, 7291, 7293,
        7294, 7299, 7300, 7302, 7303, 7317, 7318, 7320, 7321, 7326, 7327, 7329, 7330,
        7371, 7372, 7374, 7375, 7380, 7381, 7383, 7384, 7398, 7399, 7401, 7402, 7407,
        7408, 7410, 7411, 7533, 7534, 7536, 7537, 7542, 7543, 7545, 7546, 7560, 7561,
        7563, 7564, 7569, 7570, 7572, 7573, 7614, 7615, 7617, 7618, 7623, 7624, 7626,
        7627, 7641, 7642, 7644, 7645, 7650, 7651, 7653, 7654, 8748, 8749, 8751, 8752,
        8757, 8758, 8760, 8761, 8775, 8776, 8778, 8779, 8784, 8785, 8787, 8788, 8829,
        8830, 8832, 8833, 8838, 8839, 8841, 8842, 8856, 8857, 8859, 8860, 8865, 8866,
        8868, 8869, 8991, 8992, 8994, 8995, 9000, 9001, 9003, 9004, 9018, 9019, 9021,
        9022, 9027, 9028, 9030, 9031, 9072, 9073, 9075, 9076, 9081, 9082, 9084, 9085,
        9099, 9100, 9102, 9103, 9108, 9109, 9111, 9112, 9477, 9478, 9480, 9481, 9486,
        9487, 9489, 9490, 9504, 9505, 9507, 9508, 9513, 9514, 9516, 9517, 9558, 9559,
        9561, 9562, 9567, 9568, 9570, 9571, 9585, 9586, 9588, 9589, 9594, 9595, 9597,
        9598, 9720, 9721, 9723, 9724, 9729, 9730, 9732, 9733, 9747, 9748, 9750, 9751,
        9756, 9757, 9759, 9760, 9801, 9802, 9804, 9805, 9810, 9811, 9813, 9814, 9828,
        9829, 9831, 9832, 9837, 9838, 9840, 9841,
        19683, 19684, 19686, 19687, 19692, 19693, 19695, 19696,
        19710, 19711, 19713, 19714, 19719, 19720, 19722, 19723,
        19764, 19765, 19767, 19768, 19773, 19774, 19776, 19777,
        19791, 19792, 19794, 19795, 19800, 19801, 19803, 19804,
        19926, 19927, 19929, 19930, 19935, 19936, 19938, 19939,
        19953, 19954, 19956, 19957, 19962, 19963, 19965, 19966,
        20007, 20008, 20010, 20011, 20016, 20017, 20019, 20020,
        20034, 20035, 20037, 20038, 20043, 20044, 20046, 20047,
        20412, 20413, 20415, 20416, 20421, 20422, 20424, 20425,
        20439, 20440, 20442, 20443, 20448, 20449, 20451, 20452,
        20493, 20494, 20496, 20497, 20502, 20503, 20505, 20506,
        20520, 20521, 20523, 20524, 20529, 20530, 20532, 20533,
        20655, 20656, 20658, 20659, 20664, 20665, 20667, 20668,
        20682, 20683, 20685, 20686, 20691, 20692, 20694, 20695,
        20736, 20737, 20739, 20740, 20745, 20746, 20748, 20749,
        20763, 20764, 20766, 20767, 20772, 20773, 20775, 20776,
        21870, 21871, 21873, 21874, 21879, 21880, 21882, 21883,
        21897, 21898, 21900, 21901, 21906, 21907, 21909, 21910,
        21951, 21952, 21954, 21955, 21960, 21961, 21963, 21964,
        21978, 21979, 21981, 21982, 21987, 21988, 21990, 21991,
        22113, 22114, 22116, 22117, 22122, 22123, 22125, 22126,
        22140, 22141, 22143, 22144, 22149, 22150, 22152, 22153,
        22194, 22195, 22197, 22198, 22203, 22204, 22206, 22207,
        22221, 22222, 22224, 22225, 22230, 22231, 22233, 22234,
        22599, 22600, 22602, 22603, 22608, 22609, 22611, 22612,
        22626, 22627, 22629, 22630, 22635, 22636, 22638, 22639,
        22680, 22681, 22683, 22684, 22689, 22690, 22692, 22693,
        22707, 22708, 22710, 22711, 22716, 22717, 22719, 22720,
        22842, 22843, 22845, 22846, 22851, 22852, 22854, 22855,
        22869, 22870, 22872, 22873, 22878, 22879, 22881, 22882,
        22923, 22924, 22926, 22927, 22932, 22933, 22935, 22936,
        22950, 22951, 22953, 22954, 22959, 22960, 22962, 22963,
        26244, 26245, 26247, 26248, 26253, 26254, 26256, 26257,
        26271, 26272, 26274, 26275, 26280, 26281, 26283, 26284,
        26325, 26326, 26328, 26329, 26334, 26335, 26337, 26338,
        26352, 26353, 26355, 26356, 26361, 26362, 26364, 26365,
        26487, 26488, 26490, 26491, 26496, 26497, 26499, 26500,
        26514, 26515, 26517, 26518, 26523, 26524, 26526, 26527,
        26568, 26569, 26571, 26572, 26577, 26578, 26580, 26581,
        26595, 26596, 26598, 26599, 26604, 26605, 26607, 26608,
        26973, 26974, 26976, 26977, 26982, 26983, 26985, 26986,
        27000, 27001, 27003, 27004, 27009, 27010, 27012, 27013,
        27054, 27055, 27057, 27058, 27063, 27064, 27066, 27067,
        27081, 27082, 27084, 27085, 27090, 27091, 27093, 27094,
        27216, 27217, 27219, 27220, 27225, 27226, 27228, 27229,
        27243, 27244, 27246, 27247, 27252, 27253, 27255, 27256,
        27297, 27298, 27300, 27301, 27306, 27307, 27309, 27310,
        27324, 27325, 27327, 27328, 27333, 27334, 27336, 27337,
        28431, 28432, 28434, 28435, 28440, 28441, 28443, 28444,
        28458, 28459, 28461, 28462, 28467, 28468, 28470, 28471,
        28512, 28513, 28515, 28516, 28521, 28522, 28524, 28525,
        28539, 28540, 28542, 28543, 28548, 28549, 28551, 28552,
        28674, 28675, 28677, 28678, 28683, 28684, 28686, 28687,
        28701, 28702, 28704, 28705, 28710, 28711, 28713, 28714,
        28755, 28756, 28758, 28759, 28764, 28765, 28767, 28768,
        28782, 28783, 28785, 28786, 28791, 28792, 28794, 28795,
        29160, 29161, 29163, 29164, 29169, 29170, 29172, 29173,
        29187, 29188, 29190, 29191, 29196, 29197, 29199, 29200,
        29241, 29242, 29244, 29245, 29250, 29251, 29253, 29254,
        29268, 29269, 29271, 29272, 29277, 29278, 29280, 29281,
        29403, 29404, 29406, 29407, 29412, 29413, 29415, 29416,
        29430, 29431, 29433, 29434, 29439, 29440, 29442, 29443,
        29484, 29485, 29487, 29488, 29493, 29494, 29496, 29497,
        29511, 29512, 29514, 29515, 29520, 29521, 29523, 29524
    };
    
    const bitbrd CORNERS = 0x8100000000000081;
    const bitbrd EDGES = 0x3C0081818181003C;
    const bitbrd ADJ_CORNERS = 0x4281000000008142;
    const bitbrd X_CORNERS = 0x0042000000004200;
    
    Eval::Eval() {
        edgeTable = new int32_t *[TSPLITS];
        p24Table = new int32_t *[TSPLITS];
        pE2XTable = new int32_t *[TSPLITS];
        p33TableABCD = new int32_t *[TSPLITS];
        line3Table = new int32_t *[TSPLITS];
        line4Table = new int32_t *[TSPLITS];
        diag8Table = new int32_t *[TSPLITS];
        
        for(int32_t i = 0; i < TSPLITS; i++) {
            edgeTable[i] = new int[6561];
            p24Table[i] = new int[6561];
            pE2XTable[i] = new int[59049];
            p33TableABCD[i] = new int[19683];
            line3Table[i] = new int[6561];
            line4Table[i] = new int[6561];
            diag8Table[i] = new int[6561];
        }
        
        s44Table = new int[65536];
        
        readTable(bookPath + "/edgetable.txt", 729, edgeTable);
        readTable(bookPath + "/p24table.txt", 729, p24Table);
        readTable(bookPath + "/pE2Xtable.txt", 6561, pE2XTable);
        readTable(bookPath + "/p33table.txt", 2187, p33TableABCD);
        readTable(bookPath + "/line3table.txt", 729, line3Table);
        readTable(bookPath + "/line4table.txt", 729, line4Table);
        readTable(bookPath + "/diag8table.txt", 729, diag8Table);
        readStability44Table();
    }
    
    Eval::~Eval() {
        for(int32_t i = 0; i < TSPLITS; i++) {
            delete[] edgeTable[i];
            delete[] p24Table[i];
            delete[] pE2XTable[i];
            delete[] p33TableABCD[i];
            delete[] line3Table[i];
            delete[] line4Table[i];
            delete[] diag8Table[i];
        }
        
        delete[] edgeTable;
        delete[] p24Table;
        delete[] pE2XTable;
        delete[] p33TableABCD;
        delete[] line3Table;
        delete[] line4Table;
        delete[] diag8Table;
        delete[] s44Table;
    }

    int32_t Eval::heuristic(Board &b, int32_t s) {
        if(b.count(s) == 0)
            return -WIPEOUT;

        int32_t turn = 64 - b.countEmpty();
        int32_t score = 0;

        int32_t patterns = 2*boardTo24PV(b, turn) + boardToEPV(b, turn)
        + 3*boardToE2XPV(b, turn) + boardTo33PV(b, turn)
        // + std::max(0, std::min(40-turn, 32)) * (boardToLine3PV(b, turn) + boardToLine4PV(b, turn)
        //                                       + boardToDiag8PV(b, turn)) / 32
        + 200 * (boardTo44SV(b, CBLACK) - boardTo44SV(b, CWHITE));
        //+ 200*(b.getStability(CBLACK) - b.getStability(CWHITE));
        if(s == CBLACK)
            score += patterns;
        else
            score -= patterns;
        bitbrd bm = b.getBits(s);
        bitbrd bo = b.getBits(s^1);
        score += 1000 * (countSetBits(bm&CORNERS) - countSetBits(bo&CORNERS));
        score += 50 * (countSetBits(bm&EDGES) - countSetBits(bo&EDGES));
        score -= 150 * (countSetBits(bm&X_CORNERS) - countSetBits(bo&X_CORNERS));
        //score -= 50 * (countSetBits(bm&ADJ_CORNERS) - countSetBits(bo&ADJ_CORNERS));

        int32_t myLM = b.numLegalMoves(s);
        int32_t oppLM = b.numLegalMoves(s^1);
        score += 100 * 4 * (myLM - oppLM);
        score += 100 * (20 + (64 - turn) / 4) * (myLM - oppLM) / (min(oppLM, myLM) + 1);
        //score += 100 * ((64 - turn) / 16) * (b.potentialMobility(s) - b.potentialMobility(s^1));
        
        return score;
    }

    int32_t Eval::heuristic2(Board &b, int32_t s) {
        if(b.count(s) == 0)
            return -INFTY;

        int32_t turn = 64 - b.countEmpty();
        int32_t score = 0;
        
        /*int32_t patterns = 2*boardTo24PV(b, turn) + boardToEPV(b, turn)
         + 3*boardToE2XPV(b, turn) + boardTo33PV(b, turn)
         + 100 * (boardTo44SV(b, CBLACK) - boardTo44SV(b, CWHITE));
         //+ 100*(b.getStability(CBLACK) - b.getStability(CWHITE));
         if(s == CBLACK)
         score += patterns;
         else
         score -= patterns;*/
        bitbrd bm = b.getBits(s);
        bitbrd bo = b.getBits(s^1);
        score += 10000 * (countSetBits(bm&CORNERS) - countSetBits(bo&CORNERS));
        score += 100 * (countSetBits(bm&EDGES) - countSetBits(bo&EDGES));
        score -= 500 * (countSetBits(bm&X_CORNERS) - countSetBits(bo&X_CORNERS));
        score -= 150 * (countSetBits(bm&ADJ_CORNERS) - countSetBits(bo&ADJ_CORNERS));

        int32_t myLM = b.numLegalMoves(s);
        int32_t oppLM = b.numLegalMoves(s^1);
        score += 100 * (12 + (64 - turn) / 16) * (myLM - oppLM);
        //score += 100 * (45 + (64 - turn) / 2) * (myLM - oppLM) / (min(oppLM, myLM) + 1);
        score += 100 * (4 + (64 - turn) / 32) * (b.potentialMobility(s) - b.potentialMobility(s^1));
        
        return score;
    }
    
    /**
     * @brief An evaluation function for endgame move ordering. Always returns a
     * score from black's point of view.
     */
    int32_t Eval::end_heuristic(Board &b) {
        int32_t score = 0;
        int32_t t = 60;
        
        score += 2*boardTo24PV(b, t);
        score += boardToEPV(b, t);
        score += 3*boardToE2XPV(b, t);
        score += boardTo33PV(b, t);
        // score += boardToLine3PV(b, t);
        // score += boardToLine4PV(b, t);
        // score += boardToDiag8PV(b, t);
        //score += 64 * (b.getStability(CBLACK) - b.getStability(CWHITE));
        score += 128*(boardTo44SV(b, CBLACK) - boardTo44SV(b, CWHITE));
        
        return score;
    }

    int32_t Eval::stability(Board &b, int32_t s) {
        return boardTo44SV(b, s);
    }

    int32_t Eval::boardToEPV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t r2 = bitsToPI( (int32_t)((black >> 8) & 0xFF), (int)((white >> 8) & 0xFF) );
        int32_t r7 = bitsToPI( (int32_t)((black >> 48) & 0xFF), (int)((white >> 48) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>1) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>1) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<1) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<1) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );
        int32_t result = shift * (edgeTable[index][r2] + edgeTable[index][r7] +
                              edgeTable[index][c2] + edgeTable[index][c7])
        + (TURNSPERDIV-shift) * (edgeTable[index2][r2] + edgeTable[index2][r7] +
                                 edgeTable[index2][c2] + edgeTable[index2][c7]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardTo24PV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t ulb = (int32_t) ((black&0xF) + ((black>>4)&0xF0));
        int32_t ulw = (int32_t) ((white&0xF) + ((white>>4)&0xF0));
        int32_t ul = bitsToPI(ulb, ulw);
        
        bitbrd rvb = reflectVertical(black);
        bitbrd rvw = reflectVertical(white);
        int32_t llb = (int) ((rvb&0xF) + ((rvb>>4)&0xF0));
        int32_t llw = (int) ((rvw&0xF) + ((rvw>>4)&0xF0));
        int32_t ll = bitsToPI(llb, llw);
        
        bitbrd rhb = reflectHorizontal(black);
        bitbrd rhw = reflectHorizontal(white);
        int32_t urb = (int) ((rhb&0xF) + ((rhb>>4)&0xF0));
        int32_t urw = (int) ((rhw&0xF) + ((rhw>>4)&0xF0));
        int32_t ur = bitsToPI(urb, urw);
        
        bitbrd rbb = reflectVertical(rhb);
        bitbrd rbw = reflectVertical(rhw);
        int32_t lrb = (int) ((rbb&0xF) + ((rbb>>4)&0xF0));
        int32_t lrw = (int) ((rbw&0xF) + ((rbw>>4)&0xF0));
        int32_t lr = bitsToPI(lrb, lrw);
        
        bitbrd rotb = reflectDiag(black);
        bitbrd rotw = reflectDiag(white);
        int32_t rulb = (int32_t) ((rotb&0xF) + ((rotb>>4)&0xF0));
        int32_t rulw = (int32_t) ((rotw&0xF) + ((rotw>>4)&0xF0));
        int32_t rul = bitsToPI(rulb, rulw);
        
        bitbrd rotvb = reflectVertical(rotb);
        bitbrd rotvw = reflectVertical(rotw);
        int32_t rllb = (int32_t) ((rotvb&0xF) + ((rotvb>>4)&0xF0));
        int32_t rllw = (int32_t) ((rotvw&0xF) + ((rotvw>>4)&0xF0));
        int32_t rll = bitsToPI(rllb, rllw);
        
        bitbrd rothb = reflectHorizontal(rotb);
        bitbrd rothw = reflectHorizontal(rotw);
        int32_t rurb = (int32_t) ((rothb&0xF) + ((rothb>>4)&0xF0));
        int32_t rurw = (int32_t) ((rothw&0xF) + ((rothw>>4)&0xF0));
        int32_t rur = bitsToPI(rurb, rurw);
        
        bitbrd rotbb = reflectVertical(rothb);
        bitbrd rotbw = reflectVertical(rothw);
        int32_t rlrb = (int) ((rotbb&0xF) + ((rotbb>>4)&0xF0));
        int32_t rlrw = (int) ((rotbw&0xF) + ((rotbw>>4)&0xF0));
        int32_t rlr = bitsToPI(rlrb, rlrw);

        int32_t result = shift * (p24Table[index][ul] + p24Table[index][ll] + p24Table[index][ur] +
                              p24Table[index][lr] + p24Table[index][rul] + p24Table[index][rll] +
                              p24Table[index][rur] + p24Table[index][rlr])
        + (TURNSPERDIV-shift) * (p24Table[index2][ul] + p24Table[index2][ll] + p24Table[index2][ur] +
                                 p24Table[index2][lr] + p24Table[index2][rul] + p24Table[index2][rll] +
                                 p24Table[index2][rur] + p24Table[index2][rlr]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardToE2XPV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t r1b = (int32_t) ( (black & 0xFF) +
                         ((black & 0x200) >> 1) + ((black & 0x4000) >> 5) );
        int32_t r1w = (int32_t) ( (white & 0xFF) +
                         ((white & 0x200) >> 1) + ((white & 0x4000) >> 5) );
        int32_t r1 = bitsToPI(r1b, r1w);

        int32_t r8b = (int32_t) ( (black>>56) + ((black & 0x2000000000000) >> 41) +
                         ((black & 0x40000000000000) >> 45) );
        int32_t r8w = (int32_t) ( (white>>56) + ((white & 0x2000000000000) >> 41) +
                         ((white & 0x40000000000000) >> 45) );
        int32_t r8 = bitsToPI(r8b, r8w);

        int32_t c1b = (int32_t) (
                         (((black & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) +
                         ((black & 0x200) >> 1) + ((black & 0x2000000000000) >> 40) );
        int32_t c1w = (int32_t) (
                         (((white & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) +
                         ((white & 0x200) >> 1) + ((white & 0x2000000000000) >> 40) );
        int32_t c1 = bitsToPI(c1b, c1w);

        int32_t c8b = (int32_t) (
                         (((black & 0x8080808080808080ULL) * 0x0002040810204081ULL) >> 56) +
                         ((black & 0x4000) >> 6) + ((black & 0x40000000000000) >> 45) );
        int32_t c8w = (int32_t) (
                         (((white & 0x8080808080808080ULL) * 0x0002040810204081ULL) >> 56) +
                         ((white & 0x4000) >> 6) + ((white & 0x40000000000000) >> 45) );
        int32_t c8 = bitsToPI(c8b, c8w);

        int32_t result = shift * (pE2XTable[index][r1] + pE2XTable[index][r8] +
                              pE2XTable[index][c1] + pE2XTable[index][c8])
        + (TURNSPERDIV-shift) * (pE2XTable[index2][r1] + pE2XTable[index2][r8] +
                                 pE2XTable[index2][c1] + pE2XTable[index2][c8]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardTo33PV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t ulb = (int32_t) ((black&7) + ((black>>5)&0x38) + ((black>>10)&0x1C0));
        int32_t ulw = (int32_t) ((white&7) + ((white>>5)&0x38) + ((white>>10)&0x1C0));
        int32_t ul = bitsToPI(ulb, ulw);
        
        bitbrd rvb = reflectVertical(black);
        bitbrd rvw = reflectVertical(white);
        int32_t llb = (int32_t) ((rvb&7) + ((rvb>>5)&0x38) + ((rvb>>10)&0x1C0));
        int32_t llw = (int32_t) ((rvw&7) + ((rvw>>5)&0x38) + ((rvw>>10)&0x1C0));
        int32_t ll = bitsToPI(llb, llw);
        
        bitbrd rhb = reflectHorizontal(black);
        bitbrd rhw = reflectHorizontal(white);
        int32_t urb = (int32_t) ((rhb&7) + ((rhb>>5)&0x38) + ((rhb>>10)&0x1C0));
        int32_t urw = (int32_t) ((rhw&7) + ((rhw>>5)&0x38) + ((rhw>>10)&0x1C0));
        int32_t ur = bitsToPI(urb, urw);
        
        bitbrd rbb = reflectVertical(rhb);
        bitbrd rbw = reflectVertical(rhw);
        int32_t lrb = (int32_t) ((rbb&7) + ((rbb>>5)&0x38) + ((rbb>>10)&0x1C0));
        int32_t lrw = (int32_t) ((rbw&7) + ((rbw>>5)&0x38) + ((rbw>>10)&0x1C0));
        int32_t lr = bitsToPI(lrb, lrw);

        int32_t result = shift * (p33TableABCD[index][ul] + p33TableABCD[index][ll] +
                              p33TableABCD[index][ur] + p33TableABCD[index][lr])
        + (TURNSPERDIV-shift) * (p33TableABCD[index2][ul] + p33TableABCD[index2][ll] +
                                 p33TableABCD[index2][ur] + p33TableABCD[index2][lr]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardToLine3PV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t r2 = bitsToPI( (int32_t)((black >> 16) & 0xFF), (int)((white >> 16) & 0xFF) );
        int32_t r7 = bitsToPI( (int32_t)((black >> 40) & 0xFF), (int)((white >> 40) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>2) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>2) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<2) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<2) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );

        int32_t result = shift * (line3Table[index][r2] + line3Table[index][r7] +
                              line3Table[index][c2] + line3Table[index][c7])
        + (TURNSPERDIV-shift) * (line3Table[index2][r2] + line3Table[index2][r7] +
                                 line3Table[index2][c2] + line3Table[index2][c7]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardToLine4PV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t r2 = bitsToPI( (int)((black >> 24) & 0xFF), (int32_t)((white >> 24) & 0xFF) );
        int32_t r7 = bitsToPI( (int)((black >> 32) & 0xFF), (int32_t)((white >> 32) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>3) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>3) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<3) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<3) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );

        int32_t result = shift * (line4Table[index][r2] + line4Table[index][r7] +
                              line4Table[index][c2] + line4Table[index][c7])
        + (TURNSPERDIV-shift) * (line4Table[index2][r2] + line4Table[index2][r7] +
                                 line4Table[index2][c2] + line4Table[index2][c7]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardToDiag8PV(Board &b, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        int32_t index2 = (index >= TSPLITS-1) ? index : index+1;
        int32_t shift = (turn - IOFFSET) - index * TURNSPERDIV;
        bitbrd black = b.getBits(CBLACK);
        bitbrd white = b.getBits(CWHITE);
        int32_t d8 = bitsToPI( (int32_t)(((black & 0x8040201008040201ULL) * 0x0101010101010101ULL) >> 56),
                          (int32_t)(((white & 0x8040201008040201ULL) * 0x0101010101010101ULL) >> 56) );
        int32_t ad8 = bitsToPI( (int32_t)(((black & 0x0102040810204080ULL) * 0x0101010101010101ULL) >> 56),
                           (int32_t)(((white & 0x0102040810204080ULL) * 0x0101010101010101ULL) >> 56) );

        int32_t result = shift * (diag8Table[index][d8] + diag8Table[index][ad8])
        + (TURNSPERDIV-shift) * (diag8Table[index2][d8] + diag8Table[index2][ad8]);
        return result / TURNSPERDIV;
    }

    int32_t Eval::boardTo44SV(Board &b, int32_t s) {
        bitbrd sbits = b.getBits(s);

        int32_t ul = (int32_t) ((sbits & 0xF) + ((sbits>>4) & 0xF0) +
                        ((sbits>>8) & 0xF00) + ((sbits>>12) & 0xF000));
        
        bitbrd rv = reflectVertical(sbits);
        int32_t ll = (int32_t) ((rv & 0xF) + ((rv>>4) & 0xF0) +
                        ((rv>>8) & 0xF00) + ((rv>>12) & 0xF000));
        
        bitbrd rh = reflectHorizontal(sbits);
        int32_t ur = (int32_t) ((rh & 0xF) + ((rh>>4) & 0xF0) +
                        ((rh>>8) & 0xF00) + ((rh>>12) & 0xF000));
        
        bitbrd rb = reflectVertical(rh);
        int32_t lr = (int32_t) ((rb & 0xF) + ((rb>>4) & 0xF0) +
                        ((rb>>8) & 0xF00) + ((rb>>12) & 0xF000));

        int32_t result = s44Table[ul] + s44Table[ll] + s44Table[ur] + s44Table[lr];
        return result;
    }

    int32_t Eval::bitsToPI(int32_t b, int32_t w) {
        return PIECES_TO_INDEX[b] + 2*PIECES_TO_INDEX[w];
    }
    
    void Eval::readTable(std::string fileName, int32_t lines, int32_t **tableArray) {
#ifdef Android
        std::string line;
        assetistream table(assetManager, fileName);
        if(table.isOpen()){
            for(int32_t n = 0; n < TSPLITS; n++) {
                for (int32_t i = 0; i < lines; i++) {
                    getline(table, line);
                    // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "success, readTable: get line: %s, %s\n", fileName.c_str(), line.c_str());
                    for (int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        tableArray[n][9 * i + j] = std::stoi(line, &sz, 0);
                        line = line.substr(sz);
                    }
                }
            }
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, readTable: not open: %s\n", fileName.c_str());
        }
#else
        std::string line;
        std::ifstream table(fileName);
        if(table.is_open()) {
            for(int32_t n = 0; n < TSPLITS; n++) {
                for(int32_t i = 0; i < lines; i++) {
                    getline(table, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        tableArray[n][9*i+j] = std::stoi(line, &sz, 0);
                        line = line.substr(sz);
                    }
                }
            }
            table.close();
        } else {
            printf("error, cannot open: %s\n", fileName.c_str());
        }
#endif
    }
    
    void Eval::readStability44Table() {
#ifdef Android
        std::string line;
        assetistream s44table(assetManager, bookPath + "/s44table.txt");
        if(s44table.isOpen()){
            for(int32_t i = 0; i < 2048; i++) {
                getline(s44table, line);
                // __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "success, readTable: s44table: get line: %s\n", line.c_str());
                for(int32_t j = 0; j < 32; j++) {
                    std::string::size_type sz = 0;
                    s44Table[32*i+j] = std::stoi(line, &sz, 0);
                    line = line.substr(sz);
                }
            }
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, readTable: not open: %s\n", bookPath.c_str());
        }
#else
        std::string line;
        std::string file = bookPath + "/s44table.txt";
        std::ifstream s44table(file);

        if(s44table.is_open()) {
            for(int32_t i = 0; i < 2048; i++) {
                getline(s44table, line);
                for(int32_t j = 0; j < 32; j++) {
                    std::string::size_type sz = 0;
                    s44Table[32*i+j] = std::stoi(line, &sz, 0);
                    line = line.substr(sz);
                }
            }
            s44table.close();
        } else {
            printf("Error: could not open Flippy_Resources/s44table.txt\n");
        }
#endif
    }
}
