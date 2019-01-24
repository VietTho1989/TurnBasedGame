#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// LP`1<Seirawan.NoneRule.SetHandHolder/UIData>
struct LP_1_t3201323790;
// System.Collections.Generic.List`1<Seirawan.Common/Piece>
struct List_1_t2131979566;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.NoneRule.SetHandAdapter/UIData
struct  UIData_t2529106927  : public BaseParams_t1775368447
{
public:
	// LP`1<Seirawan.NoneRule.SetHandHolder/UIData> Seirawan.NoneRule.SetHandAdapter/UIData::holders
	LP_1_t3201323790 * ___holders_20;
	// System.Collections.Generic.List`1<Seirawan.Common/Piece> Seirawan.NoneRule.SetHandAdapter/UIData::pieces
	List_1_t2131979566 * ___pieces_21;

public:
	inline static int32_t get_offset_of_holders_20() { return static_cast<int32_t>(offsetof(UIData_t2529106927, ___holders_20)); }
	inline LP_1_t3201323790 * get_holders_20() const { return ___holders_20; }
	inline LP_1_t3201323790 ** get_address_of_holders_20() { return &___holders_20; }
	inline void set_holders_20(LP_1_t3201323790 * value)
	{
		___holders_20 = value;
		Il2CppCodeGenWriteBarrier(&___holders_20, value);
	}

	inline static int32_t get_offset_of_pieces_21() { return static_cast<int32_t>(offsetof(UIData_t2529106927, ___pieces_21)); }
	inline List_1_t2131979566 * get_pieces_21() const { return ___pieces_21; }
	inline List_1_t2131979566 ** get_address_of_pieces_21() { return &___pieces_21; }
	inline void set_pieces_21(List_1_t2131979566 * value)
	{
		___pieces_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieces_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
