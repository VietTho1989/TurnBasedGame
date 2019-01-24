#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// LP`1<Shogi.NoneRule.ChoosePieceHolder/UIData>
struct LP_1_t3062138062;
// System.Collections.Generic.List`1<Shogi.Common/Piece>
struct List_1_t4108929922;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ChoosePieceAdapter/UIData
struct  UIData_t3443905587  : public BaseParams_t1775368447
{
public:
	// LP`1<Shogi.NoneRule.ChoosePieceHolder/UIData> Shogi.NoneRule.ChoosePieceAdapter/UIData::holders
	LP_1_t3062138062 * ___holders_20;
	// System.Collections.Generic.List`1<Shogi.Common/Piece> Shogi.NoneRule.ChoosePieceAdapter/UIData::pieces
	List_1_t4108929922 * ___pieces_21;

public:
	inline static int32_t get_offset_of_holders_20() { return static_cast<int32_t>(offsetof(UIData_t3443905587, ___holders_20)); }
	inline LP_1_t3062138062 * get_holders_20() const { return ___holders_20; }
	inline LP_1_t3062138062 ** get_address_of_holders_20() { return &___holders_20; }
	inline void set_holders_20(LP_1_t3062138062 * value)
	{
		___holders_20 = value;
		Il2CppCodeGenWriteBarrier(&___holders_20, value);
	}

	inline static int32_t get_offset_of_pieces_21() { return static_cast<int32_t>(offsetof(UIData_t3443905587, ___pieces_21)); }
	inline List_1_t4108929922 * get_pieces_21() const { return ___pieces_21; }
	inline List_1_t4108929922 ** get_address_of_pieces_21() { return &___pieces_21; }
	inline void set_pieces_21(List_1_t4108929922 * value)
	{
		___pieces_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
