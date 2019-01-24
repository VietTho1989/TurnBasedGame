#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<FairyChess.FairyChess>>
struct VP_1_t3341857400;
// VP`1<FairyChess.FairyChessFenUI/UIData>
struct VP_1_t3258142496;
// LP`1<FairyChess.PieceUI/UIData>
struct LP_1_t1025546264;
// LP`1<FairyChess.HandPieceUI/UIData>
struct LP_1_t3775750357;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.BoardUI/UIData
struct  UIData_t2805356858  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<FairyChess.FairyChess>> FairyChess.BoardUI/UIData::fairyChess
	VP_1_t3341857400 * ___fairyChess_5;
	// VP`1<FairyChess.FairyChessFenUI/UIData> FairyChess.BoardUI/UIData::fairyChessFen
	VP_1_t3258142496 * ___fairyChessFen_6;
	// LP`1<FairyChess.PieceUI/UIData> FairyChess.BoardUI/UIData::pieces
	LP_1_t1025546264 * ___pieces_7;
	// LP`1<FairyChess.HandPieceUI/UIData> FairyChess.BoardUI/UIData::whiteHand
	LP_1_t3775750357 * ___whiteHand_8;
	// LP`1<FairyChess.HandPieceUI/UIData> FairyChess.BoardUI/UIData::blackHand
	LP_1_t3775750357 * ___blackHand_9;

public:
	inline static int32_t get_offset_of_fairyChess_5() { return static_cast<int32_t>(offsetof(UIData_t2805356858, ___fairyChess_5)); }
	inline VP_1_t3341857400 * get_fairyChess_5() const { return ___fairyChess_5; }
	inline VP_1_t3341857400 ** get_address_of_fairyChess_5() { return &___fairyChess_5; }
	inline void set_fairyChess_5(VP_1_t3341857400 * value)
	{
		___fairyChess_5 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChess_5, value);
	}

	inline static int32_t get_offset_of_fairyChessFen_6() { return static_cast<int32_t>(offsetof(UIData_t2805356858, ___fairyChessFen_6)); }
	inline VP_1_t3258142496 * get_fairyChessFen_6() const { return ___fairyChessFen_6; }
	inline VP_1_t3258142496 ** get_address_of_fairyChessFen_6() { return &___fairyChessFen_6; }
	inline void set_fairyChessFen_6(VP_1_t3258142496 * value)
	{
		___fairyChessFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChessFen_6, value);
	}

	inline static int32_t get_offset_of_pieces_7() { return static_cast<int32_t>(offsetof(UIData_t2805356858, ___pieces_7)); }
	inline LP_1_t1025546264 * get_pieces_7() const { return ___pieces_7; }
	inline LP_1_t1025546264 ** get_address_of_pieces_7() { return &___pieces_7; }
	inline void set_pieces_7(LP_1_t1025546264 * value)
	{
		___pieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_7, value);
	}

	inline static int32_t get_offset_of_whiteHand_8() { return static_cast<int32_t>(offsetof(UIData_t2805356858, ___whiteHand_8)); }
	inline LP_1_t3775750357 * get_whiteHand_8() const { return ___whiteHand_8; }
	inline LP_1_t3775750357 ** get_address_of_whiteHand_8() { return &___whiteHand_8; }
	inline void set_whiteHand_8(LP_1_t3775750357 * value)
	{
		___whiteHand_8 = value;
		Il2CppCodeGenWriteBarrier(&___whiteHand_8, value);
	}

	inline static int32_t get_offset_of_blackHand_9() { return static_cast<int32_t>(offsetof(UIData_t2805356858, ___blackHand_9)); }
	inline LP_1_t3775750357 * get_blackHand_9() const { return ___blackHand_9; }
	inline LP_1_t3775750357 ** get_address_of_blackHand_9() { return &___blackHand_9; }
	inline void set_blackHand_9(LP_1_t3775750357 * value)
	{
		___blackHand_9 = value;
		Il2CppCodeGenWriteBarrier(&___blackHand_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
