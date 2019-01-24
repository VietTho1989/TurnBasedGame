#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// LP`1<InternationalDraught.NoneRule.ChoosePieceHolder/UIData>
struct LP_1_t3909869797;
// System.Collections.Generic.List`1<InternationalDraught.Common/Piece_Side>
struct List_1_t2997818247;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NoneRule.ChoosePieceAdapter/UIData
struct  UIData_t2950624960  : public BaseParams_t1775368447
{
public:
	// LP`1<InternationalDraught.NoneRule.ChoosePieceHolder/UIData> InternationalDraught.NoneRule.ChoosePieceAdapter/UIData::holders
	LP_1_t3909869797 * ___holders_20;
	// System.Collections.Generic.List`1<InternationalDraught.Common/Piece_Side> InternationalDraught.NoneRule.ChoosePieceAdapter/UIData::pieceSides
	List_1_t2997818247 * ___pieceSides_21;

public:
	inline static int32_t get_offset_of_holders_20() { return static_cast<int32_t>(offsetof(UIData_t2950624960, ___holders_20)); }
	inline LP_1_t3909869797 * get_holders_20() const { return ___holders_20; }
	inline LP_1_t3909869797 ** get_address_of_holders_20() { return &___holders_20; }
	inline void set_holders_20(LP_1_t3909869797 * value)
	{
		___holders_20 = value;
		Il2CppCodeGenWriteBarrier(&___holders_20, value);
	}

	inline static int32_t get_offset_of_pieceSides_21() { return static_cast<int32_t>(offsetof(UIData_t2950624960, ___pieceSides_21)); }
	inline List_1_t2997818247 * get_pieceSides_21() const { return ___pieceSides_21; }
	inline List_1_t2997818247 ** get_address_of_pieceSides_21() { return &___pieceSides_21; }
	inline void set_pieceSides_21(List_1_t2997818247 * value)
	{
		___pieceSides_21 = value;
		Il2CppCodeGenWriteBarrier(&___pieceSides_21, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
