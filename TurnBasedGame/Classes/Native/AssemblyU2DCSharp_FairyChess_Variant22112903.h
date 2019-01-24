#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Rank1469664291.h"
#include "AssemblyU2DCSharp_FairyChess_Common_File3472531759.h"

// System.Collections.Generic.HashSet`1<FairyChess.Common/PieceType>
struct HashSet_1_t1184112373;
// System.String
struct String_t;
// FairyChess.Common/PieceType[]
struct PieceTypeU5BU5D_t2385426854;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.Variant
struct  Variant_t22112903  : public Il2CppObject
{
public:
	// FairyChess.Common/Rank FairyChess.Variant::maxRank
	int32_t ___maxRank_0;
	// FairyChess.Common/File FairyChess.Variant::maxFile
	int32_t ___maxFile_1;
	// System.Collections.Generic.HashSet`1<FairyChess.Common/PieceType> FairyChess.Variant::pieceTypes
	HashSet_1_t1184112373 * ___pieceTypes_2;
	// System.String FairyChess.Variant::pieceToChar
	String_t* ___pieceToChar_3;
	// System.String FairyChess.Variant::startFen
	String_t* ___startFen_4;
	// FairyChess.Common/Rank FairyChess.Variant::promotionRank
	int32_t ___promotionRank_5;
	// System.Collections.Generic.HashSet`1<FairyChess.Common/PieceType> FairyChess.Variant::promotionPieceTypes
	HashSet_1_t1184112373 * ___promotionPieceTypes_6;
	// FairyChess.Common/PieceType[] FairyChess.Variant::promotedPieceType
	PieceTypeU5BU5D_t2385426854* ___promotedPieceType_7;
	// System.Boolean FairyChess.Variant::mandatoryPiecePromotion
	bool ___mandatoryPiecePromotion_8;
	// System.Boolean FairyChess.Variant::endgameEval
	bool ___endgameEval_9;
	// System.Boolean FairyChess.Variant::doubleStep
	bool ___doubleStep_10;
	// System.Boolean FairyChess.Variant::castling
	bool ___castling_11;
	// System.Boolean FairyChess.Variant::checking
	bool ___checking_12;
	// System.Boolean FairyChess.Variant::mustCapture
	bool ___mustCapture_13;
	// System.Boolean FairyChess.Variant::pieceDrops
	bool ___pieceDrops_14;
	// System.Boolean FairyChess.Variant::dropLoop
	bool ___dropLoop_15;
	// System.Boolean FairyChess.Variant::capturesToHand
	bool ___capturesToHand_16;
	// System.Boolean FairyChess.Variant::firstRankDrops
	bool ___firstRankDrops_17;
	// System.Int32 FairyChess.Variant::stalemateValue
	int32_t ___stalemateValue_18;
	// System.Int32 FairyChess.Variant::checkmateValue
	int32_t ___checkmateValue_19;
	// System.Int32 FairyChess.Variant::bareKingValue
	int32_t ___bareKingValue_20;
	// System.Int32 FairyChess.Variant::extinctionValue
	int32_t ___extinctionValue_21;
	// System.Boolean FairyChess.Variant::bareKingMove
	bool ___bareKingMove_22;
	// System.Collections.Generic.HashSet`1<FairyChess.Common/PieceType> FairyChess.Variant::extinctionPieceTypes
	HashSet_1_t1184112373 * ___extinctionPieceTypes_23;
	// System.UInt64 FairyChess.Variant::whiteFlag
	uint64_t ___whiteFlag_24;
	// System.UInt64 FairyChess.Variant::blackFlag
	uint64_t ___blackFlag_25;
	// System.Boolean FairyChess.Variant::flagMove
	bool ___flagMove_26;
	// System.Int32 FairyChess.Variant::maxCheckCount
	int32_t ___maxCheckCount_27;

public:
	inline static int32_t get_offset_of_maxRank_0() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___maxRank_0)); }
	inline int32_t get_maxRank_0() const { return ___maxRank_0; }
	inline int32_t* get_address_of_maxRank_0() { return &___maxRank_0; }
	inline void set_maxRank_0(int32_t value)
	{
		___maxRank_0 = value;
	}

	inline static int32_t get_offset_of_maxFile_1() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___maxFile_1)); }
	inline int32_t get_maxFile_1() const { return ___maxFile_1; }
	inline int32_t* get_address_of_maxFile_1() { return &___maxFile_1; }
	inline void set_maxFile_1(int32_t value)
	{
		___maxFile_1 = value;
	}

	inline static int32_t get_offset_of_pieceTypes_2() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___pieceTypes_2)); }
	inline HashSet_1_t1184112373 * get_pieceTypes_2() const { return ___pieceTypes_2; }
	inline HashSet_1_t1184112373 ** get_address_of_pieceTypes_2() { return &___pieceTypes_2; }
	inline void set_pieceTypes_2(HashSet_1_t1184112373 * value)
	{
		___pieceTypes_2 = value;
		Il2CppCodeGenWriteBarrier(&___pieceTypes_2, value);
	}

	inline static int32_t get_offset_of_pieceToChar_3() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___pieceToChar_3)); }
	inline String_t* get_pieceToChar_3() const { return ___pieceToChar_3; }
	inline String_t** get_address_of_pieceToChar_3() { return &___pieceToChar_3; }
	inline void set_pieceToChar_3(String_t* value)
	{
		___pieceToChar_3 = value;
		Il2CppCodeGenWriteBarrier(&___pieceToChar_3, value);
	}

	inline static int32_t get_offset_of_startFen_4() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___startFen_4)); }
	inline String_t* get_startFen_4() const { return ___startFen_4; }
	inline String_t** get_address_of_startFen_4() { return &___startFen_4; }
	inline void set_startFen_4(String_t* value)
	{
		___startFen_4 = value;
		Il2CppCodeGenWriteBarrier(&___startFen_4, value);
	}

	inline static int32_t get_offset_of_promotionRank_5() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___promotionRank_5)); }
	inline int32_t get_promotionRank_5() const { return ___promotionRank_5; }
	inline int32_t* get_address_of_promotionRank_5() { return &___promotionRank_5; }
	inline void set_promotionRank_5(int32_t value)
	{
		___promotionRank_5 = value;
	}

	inline static int32_t get_offset_of_promotionPieceTypes_6() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___promotionPieceTypes_6)); }
	inline HashSet_1_t1184112373 * get_promotionPieceTypes_6() const { return ___promotionPieceTypes_6; }
	inline HashSet_1_t1184112373 ** get_address_of_promotionPieceTypes_6() { return &___promotionPieceTypes_6; }
	inline void set_promotionPieceTypes_6(HashSet_1_t1184112373 * value)
	{
		___promotionPieceTypes_6 = value;
		Il2CppCodeGenWriteBarrier(&___promotionPieceTypes_6, value);
	}

	inline static int32_t get_offset_of_promotedPieceType_7() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___promotedPieceType_7)); }
	inline PieceTypeU5BU5D_t2385426854* get_promotedPieceType_7() const { return ___promotedPieceType_7; }
	inline PieceTypeU5BU5D_t2385426854** get_address_of_promotedPieceType_7() { return &___promotedPieceType_7; }
	inline void set_promotedPieceType_7(PieceTypeU5BU5D_t2385426854* value)
	{
		___promotedPieceType_7 = value;
		Il2CppCodeGenWriteBarrier(&___promotedPieceType_7, value);
	}

	inline static int32_t get_offset_of_mandatoryPiecePromotion_8() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___mandatoryPiecePromotion_8)); }
	inline bool get_mandatoryPiecePromotion_8() const { return ___mandatoryPiecePromotion_8; }
	inline bool* get_address_of_mandatoryPiecePromotion_8() { return &___mandatoryPiecePromotion_8; }
	inline void set_mandatoryPiecePromotion_8(bool value)
	{
		___mandatoryPiecePromotion_8 = value;
	}

	inline static int32_t get_offset_of_endgameEval_9() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___endgameEval_9)); }
	inline bool get_endgameEval_9() const { return ___endgameEval_9; }
	inline bool* get_address_of_endgameEval_9() { return &___endgameEval_9; }
	inline void set_endgameEval_9(bool value)
	{
		___endgameEval_9 = value;
	}

	inline static int32_t get_offset_of_doubleStep_10() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___doubleStep_10)); }
	inline bool get_doubleStep_10() const { return ___doubleStep_10; }
	inline bool* get_address_of_doubleStep_10() { return &___doubleStep_10; }
	inline void set_doubleStep_10(bool value)
	{
		___doubleStep_10 = value;
	}

	inline static int32_t get_offset_of_castling_11() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___castling_11)); }
	inline bool get_castling_11() const { return ___castling_11; }
	inline bool* get_address_of_castling_11() { return &___castling_11; }
	inline void set_castling_11(bool value)
	{
		___castling_11 = value;
	}

	inline static int32_t get_offset_of_checking_12() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___checking_12)); }
	inline bool get_checking_12() const { return ___checking_12; }
	inline bool* get_address_of_checking_12() { return &___checking_12; }
	inline void set_checking_12(bool value)
	{
		___checking_12 = value;
	}

	inline static int32_t get_offset_of_mustCapture_13() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___mustCapture_13)); }
	inline bool get_mustCapture_13() const { return ___mustCapture_13; }
	inline bool* get_address_of_mustCapture_13() { return &___mustCapture_13; }
	inline void set_mustCapture_13(bool value)
	{
		___mustCapture_13 = value;
	}

	inline static int32_t get_offset_of_pieceDrops_14() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___pieceDrops_14)); }
	inline bool get_pieceDrops_14() const { return ___pieceDrops_14; }
	inline bool* get_address_of_pieceDrops_14() { return &___pieceDrops_14; }
	inline void set_pieceDrops_14(bool value)
	{
		___pieceDrops_14 = value;
	}

	inline static int32_t get_offset_of_dropLoop_15() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___dropLoop_15)); }
	inline bool get_dropLoop_15() const { return ___dropLoop_15; }
	inline bool* get_address_of_dropLoop_15() { return &___dropLoop_15; }
	inline void set_dropLoop_15(bool value)
	{
		___dropLoop_15 = value;
	}

	inline static int32_t get_offset_of_capturesToHand_16() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___capturesToHand_16)); }
	inline bool get_capturesToHand_16() const { return ___capturesToHand_16; }
	inline bool* get_address_of_capturesToHand_16() { return &___capturesToHand_16; }
	inline void set_capturesToHand_16(bool value)
	{
		___capturesToHand_16 = value;
	}

	inline static int32_t get_offset_of_firstRankDrops_17() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___firstRankDrops_17)); }
	inline bool get_firstRankDrops_17() const { return ___firstRankDrops_17; }
	inline bool* get_address_of_firstRankDrops_17() { return &___firstRankDrops_17; }
	inline void set_firstRankDrops_17(bool value)
	{
		___firstRankDrops_17 = value;
	}

	inline static int32_t get_offset_of_stalemateValue_18() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___stalemateValue_18)); }
	inline int32_t get_stalemateValue_18() const { return ___stalemateValue_18; }
	inline int32_t* get_address_of_stalemateValue_18() { return &___stalemateValue_18; }
	inline void set_stalemateValue_18(int32_t value)
	{
		___stalemateValue_18 = value;
	}

	inline static int32_t get_offset_of_checkmateValue_19() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___checkmateValue_19)); }
	inline int32_t get_checkmateValue_19() const { return ___checkmateValue_19; }
	inline int32_t* get_address_of_checkmateValue_19() { return &___checkmateValue_19; }
	inline void set_checkmateValue_19(int32_t value)
	{
		___checkmateValue_19 = value;
	}

	inline static int32_t get_offset_of_bareKingValue_20() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___bareKingValue_20)); }
	inline int32_t get_bareKingValue_20() const { return ___bareKingValue_20; }
	inline int32_t* get_address_of_bareKingValue_20() { return &___bareKingValue_20; }
	inline void set_bareKingValue_20(int32_t value)
	{
		___bareKingValue_20 = value;
	}

	inline static int32_t get_offset_of_extinctionValue_21() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___extinctionValue_21)); }
	inline int32_t get_extinctionValue_21() const { return ___extinctionValue_21; }
	inline int32_t* get_address_of_extinctionValue_21() { return &___extinctionValue_21; }
	inline void set_extinctionValue_21(int32_t value)
	{
		___extinctionValue_21 = value;
	}

	inline static int32_t get_offset_of_bareKingMove_22() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___bareKingMove_22)); }
	inline bool get_bareKingMove_22() const { return ___bareKingMove_22; }
	inline bool* get_address_of_bareKingMove_22() { return &___bareKingMove_22; }
	inline void set_bareKingMove_22(bool value)
	{
		___bareKingMove_22 = value;
	}

	inline static int32_t get_offset_of_extinctionPieceTypes_23() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___extinctionPieceTypes_23)); }
	inline HashSet_1_t1184112373 * get_extinctionPieceTypes_23() const { return ___extinctionPieceTypes_23; }
	inline HashSet_1_t1184112373 ** get_address_of_extinctionPieceTypes_23() { return &___extinctionPieceTypes_23; }
	inline void set_extinctionPieceTypes_23(HashSet_1_t1184112373 * value)
	{
		___extinctionPieceTypes_23 = value;
		Il2CppCodeGenWriteBarrier(&___extinctionPieceTypes_23, value);
	}

	inline static int32_t get_offset_of_whiteFlag_24() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___whiteFlag_24)); }
	inline uint64_t get_whiteFlag_24() const { return ___whiteFlag_24; }
	inline uint64_t* get_address_of_whiteFlag_24() { return &___whiteFlag_24; }
	inline void set_whiteFlag_24(uint64_t value)
	{
		___whiteFlag_24 = value;
	}

	inline static int32_t get_offset_of_blackFlag_25() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___blackFlag_25)); }
	inline uint64_t get_blackFlag_25() const { return ___blackFlag_25; }
	inline uint64_t* get_address_of_blackFlag_25() { return &___blackFlag_25; }
	inline void set_blackFlag_25(uint64_t value)
	{
		___blackFlag_25 = value;
	}

	inline static int32_t get_offset_of_flagMove_26() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___flagMove_26)); }
	inline bool get_flagMove_26() const { return ___flagMove_26; }
	inline bool* get_address_of_flagMove_26() { return &___flagMove_26; }
	inline void set_flagMove_26(bool value)
	{
		___flagMove_26 = value;
	}

	inline static int32_t get_offset_of_maxCheckCount_27() { return static_cast<int32_t>(offsetof(Variant_t22112903, ___maxCheckCount_27)); }
	inline int32_t get_maxCheckCount_27() const { return ___maxCheckCount_27; }
	inline int32_t* get_address_of_maxCheckCount_27() { return &___maxCheckCount_27; }
	inline void set_maxCheckCount_27(int32_t value)
	{
		___maxCheckCount_27 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
