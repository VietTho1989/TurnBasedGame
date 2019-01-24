#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Weiqi_NoneRuleInputUI_UIData_Sub1818009229.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<Weiqi.NoneRule.ChoosePieceAdapter/UIData>
struct VP_1_t1462654194;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NoneRule.SetPieceUI/UIData
struct  UIData_t1747895660  : public Sub_t1818009229
{
public:
	// VP`1<System.Int32> Weiqi.NoneRule.SetPieceUI/UIData::coord
	VP_1_t2450154454 * ___coord_5;
	// VP`1<Weiqi.NoneRule.ChoosePieceAdapter/UIData> Weiqi.NoneRule.SetPieceUI/UIData::choosePieceAdapter
	VP_1_t1462654194 * ___choosePieceAdapter_6;

public:
	inline static int32_t get_offset_of_coord_5() { return static_cast<int32_t>(offsetof(UIData_t1747895660, ___coord_5)); }
	inline VP_1_t2450154454 * get_coord_5() const { return ___coord_5; }
	inline VP_1_t2450154454 ** get_address_of_coord_5() { return &___coord_5; }
	inline void set_coord_5(VP_1_t2450154454 * value)
	{
		___coord_5 = value;
		Il2CppCodeGenWriteBarrier(&___coord_5, value);
	}

	inline static int32_t get_offset_of_choosePieceAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t1747895660, ___choosePieceAdapter_6)); }
	inline VP_1_t1462654194 * get_choosePieceAdapter_6() const { return ___choosePieceAdapter_6; }
	inline VP_1_t1462654194 ** get_address_of_choosePieceAdapter_6() { return &___choosePieceAdapter_6; }
	inline void set_choosePieceAdapter_6(VP_1_t1462654194 * value)
	{
		___choosePieceAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___choosePieceAdapter_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
