#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LastMoveSub4144089413.h"

// VP`1<ReferenceData`1<Shogi.NoneRule.ShogiCustomSet>>
struct VP_1_t2626673874;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomSetUI/UIData
struct  UIData_t219141914  : public LastMoveSub_t4144089413
{
public:
	// VP`1<ReferenceData`1<Shogi.NoneRule.ShogiCustomSet>> Shogi.NoneRule.ShogiCustomSetUI/UIData::shogiCustomSet
	VP_1_t2626673874 * ___shogiCustomSet_5;
	// VP`1<System.Boolean> Shogi.NoneRule.ShogiCustomSetUI/UIData::isHint
	VP_1_t4203851724 * ___isHint_6;

public:
	inline static int32_t get_offset_of_shogiCustomSet_5() { return static_cast<int32_t>(offsetof(UIData_t219141914, ___shogiCustomSet_5)); }
	inline VP_1_t2626673874 * get_shogiCustomSet_5() const { return ___shogiCustomSet_5; }
	inline VP_1_t2626673874 ** get_address_of_shogiCustomSet_5() { return &___shogiCustomSet_5; }
	inline void set_shogiCustomSet_5(VP_1_t2626673874 * value)
	{
		___shogiCustomSet_5 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomSet_5, value);
	}

	inline static int32_t get_offset_of_isHint_6() { return static_cast<int32_t>(offsetof(UIData_t219141914, ___isHint_6)); }
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
