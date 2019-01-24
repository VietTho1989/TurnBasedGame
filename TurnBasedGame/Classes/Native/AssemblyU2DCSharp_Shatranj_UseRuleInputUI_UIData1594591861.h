#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Shatranj_InputUI_UIData_Sub1348330323.h"

// VP`1<ReferenceData`1<Shatranj.Shatranj>>
struct VP_1_t2644303178;
// VP`1<Shatranj.UseRuleInputUI/UIData/State>
struct VP_1_t3708712895;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRuleInputUI/UIData
struct  UIData_t1594591861  : public Sub_t1348330323
{
public:
	// VP`1<ReferenceData`1<Shatranj.Shatranj>> Shatranj.UseRuleInputUI/UIData::shatranj
	VP_1_t2644303178 * ___shatranj_5;
	// VP`1<Shatranj.UseRuleInputUI/UIData/State> Shatranj.UseRuleInputUI/UIData::state
	VP_1_t3708712895 * ___state_6;

public:
	inline static int32_t get_offset_of_shatranj_5() { return static_cast<int32_t>(offsetof(UIData_t1594591861, ___shatranj_5)); }
	inline VP_1_t2644303178 * get_shatranj_5() const { return ___shatranj_5; }
	inline VP_1_t2644303178 ** get_address_of_shatranj_5() { return &___shatranj_5; }
	inline void set_shatranj_5(VP_1_t2644303178 * value)
	{
		___shatranj_5 = value;
		Il2CppCodeGenWriteBarrier(&___shatranj_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t1594591861, ___state_6)); }
	inline VP_1_t3708712895 * get_state_6() const { return ___state_6; }
	inline VP_1_t3708712895 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3708712895 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
