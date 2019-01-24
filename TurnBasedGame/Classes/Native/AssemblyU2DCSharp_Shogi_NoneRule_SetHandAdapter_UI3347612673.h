#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// LP`1<Shogi.NoneRule.SetHandHolder/UIData>
struct LP_1_t2600009122;
// VP`1<Shogi.Common/ColorAndHandPiece>
struct VP_1_t1673001165;
// System.Collections.Generic.List`1<Shogi.Common/ColorAndHandPiece>
struct List_1_t663845291;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.SetHandAdapter/UIData
struct  UIData_t3347612673  : public BaseParams_t1775368447
{
public:
	// LP`1<Shogi.NoneRule.SetHandHolder/UIData> Shogi.NoneRule.SetHandAdapter/UIData::holders
	LP_1_t2600009122 * ___holders_20;
	// VP`1<Shogi.Common/ColorAndHandPiece> Shogi.NoneRule.SetHandAdapter/UIData::chosen
	VP_1_t1673001165 * ___chosen_21;
	// System.Collections.Generic.List`1<Shogi.Common/ColorAndHandPiece> Shogi.NoneRule.SetHandAdapter/UIData::pieces
	List_1_t663845291 * ___pieces_22;

public:
	inline static int32_t get_offset_of_holders_20() { return static_cast<int32_t>(offsetof(UIData_t3347612673, ___holders_20)); }
	inline LP_1_t2600009122 * get_holders_20() const { return ___holders_20; }
	inline LP_1_t2600009122 ** get_address_of_holders_20() { return &___holders_20; }
	inline void set_holders_20(LP_1_t2600009122 * value)
	{
		___holders_20 = value;
		Il2CppCodeGenWriteBarrier(&___holders_20, value);
	}

	inline static int32_t get_offset_of_chosen_21() { return static_cast<int32_t>(offsetof(UIData_t3347612673, ___chosen_21)); }
	inline VP_1_t1673001165 * get_chosen_21() const { return ___chosen_21; }
	inline VP_1_t1673001165 ** get_address_of_chosen_21() { return &___chosen_21; }
	inline void set_chosen_21(VP_1_t1673001165 * value)
	{
		___chosen_21 = value;
		Il2CppCodeGenWriteBarrier(&___chosen_21, value);
	}

	inline static int32_t get_offset_of_pieces_22() { return static_cast<int32_t>(offsetof(UIData_t3347612673, ___pieces_22)); }
	inline List_1_t663845291 * get_pieces_22() const { return ___pieces_22; }
	inline List_1_t663845291 ** get_address_of_pieces_22() { return &___pieces_22; }
	inline void set_pieces_22(List_1_t663845291 * value)
	{
		___pieces_22 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
