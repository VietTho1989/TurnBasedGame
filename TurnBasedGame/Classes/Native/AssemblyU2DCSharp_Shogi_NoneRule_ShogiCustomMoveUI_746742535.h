#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LastMoveSub4144089413.h"

// VP`1<ReferenceData`1<Shogi.NoneRule.ShogiCustomMove>>
struct VP_1_t1435442749;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomMoveUI/UIData
struct  UIData_t746742535  : public LastMoveSub_t4144089413
{
public:
	// VP`1<ReferenceData`1<Shogi.NoneRule.ShogiCustomMove>> Shogi.NoneRule.ShogiCustomMoveUI/UIData::shogiCustomMove
	VP_1_t1435442749 * ___shogiCustomMove_5;
	// VP`1<System.Boolean> Shogi.NoneRule.ShogiCustomMoveUI/UIData::isHint
	VP_1_t4203851724 * ___isHint_6;

public:
	inline static int32_t get_offset_of_shogiCustomMove_5() { return static_cast<int32_t>(offsetof(UIData_t746742535, ___shogiCustomMove_5)); }
	inline VP_1_t1435442749 * get_shogiCustomMove_5() const { return ___shogiCustomMove_5; }
	inline VP_1_t1435442749 ** get_address_of_shogiCustomMove_5() { return &___shogiCustomMove_5; }
	inline void set_shogiCustomMove_5(VP_1_t1435442749 * value)
	{
		___shogiCustomMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomMove_5, value);
	}

	inline static int32_t get_offset_of_isHint_6() { return static_cast<int32_t>(offsetof(UIData_t746742535, ___isHint_6)); }
	inline VP_1_t4203851724 * get_isHint_6() const { return ___isHint_6; }
	inline VP_1_t4203851724 ** get_address_of_isHint_6() { return &___isHint_6; }
	inline void set_isHint_6(VP_1_t4203851724 * value)
	{
		___isHint_6 = value;
		Il2CppCodeGenWriteBarrier(&___isHint_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
