#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameTypeUI1278715567.h"

// VP`1<EditData`1<Shogi.DefaultShogi>>
struct VP_1_t1123343905;
// VP`1<MiniGameDataUI/UIData>
struct VP_1_t1885838056;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.DefaultShogiUI/UIData
struct  UIData_t2945050114  : public DefaultGameTypeUI_t1278715567
{
public:
	// VP`1<EditData`1<Shogi.DefaultShogi>> Shogi.DefaultShogiUI/UIData::editDefaultShogi
	VP_1_t1123343905 * ___editDefaultShogi_5;
	// VP`1<MiniGameDataUI/UIData> Shogi.DefaultShogiUI/UIData::miniGameDataUIData
	VP_1_t1885838056 * ___miniGameDataUIData_6;

public:
	inline static int32_t get_offset_of_editDefaultShogi_5() { return static_cast<int32_t>(offsetof(UIData_t2945050114, ___editDefaultShogi_5)); }
	inline VP_1_t1123343905 * get_editDefaultShogi_5() const { return ___editDefaultShogi_5; }
	inline VP_1_t1123343905 ** get_address_of_editDefaultShogi_5() { return &___editDefaultShogi_5; }
	inline void set_editDefaultShogi_5(VP_1_t1123343905 * value)
	{
		___editDefaultShogi_5 = value;
		Il2CppCodeGenWriteBarrier(&___editDefaultShogi_5, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIData_6() { return static_cast<int32_t>(offsetof(UIData_t2945050114, ___miniGameDataUIData_6)); }
	inline VP_1_t1885838056 * get_miniGameDataUIData_6() const { return ___miniGameDataUIData_6; }
	inline VP_1_t1885838056 ** get_address_of_miniGameDataUIData_6() { return &___miniGameDataUIData_6; }
	inline void set_miniGameDataUIData_6(VP_1_t1885838056 * value)
	{
		___miniGameDataUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
