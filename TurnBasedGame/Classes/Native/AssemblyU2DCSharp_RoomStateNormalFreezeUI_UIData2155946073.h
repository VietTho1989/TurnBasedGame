#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_RoomStateNormalUI_UIData_Sub912387385.h"

// VP`1<ReferenceData`1<RoomStateNormalFreeze>>
struct VP_1_t2028349969;
// VP`1<RoomStateNormalFreezeUI/UIData/State>
struct VP_1_t1410494187;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateNormalFreezeUI/UIData
struct  UIData_t2155946073  : public Sub_t912387385
{
public:
	// VP`1<ReferenceData`1<RoomStateNormalFreeze>> RoomStateNormalFreezeUI/UIData::freeze
	VP_1_t2028349969 * ___freeze_5;
	// VP`1<RoomStateNormalFreezeUI/UIData/State> RoomStateNormalFreezeUI/UIData::state
	VP_1_t1410494187 * ___state_6;

public:
	inline static int32_t get_offset_of_freeze_5() { return static_cast<int32_t>(offsetof(UIData_t2155946073, ___freeze_5)); }
	inline VP_1_t2028349969 * get_freeze_5() const { return ___freeze_5; }
	inline VP_1_t2028349969 ** get_address_of_freeze_5() { return &___freeze_5; }
	inline void set_freeze_5(VP_1_t2028349969 * value)
	{
		___freeze_5 = value;
		Il2CppCodeGenWriteBarrier(&___freeze_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t2155946073, ___state_6)); }
	inline VP_1_t1410494187 * get_state_6() const { return ___state_6; }
	inline VP_1_t1410494187 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t1410494187 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
