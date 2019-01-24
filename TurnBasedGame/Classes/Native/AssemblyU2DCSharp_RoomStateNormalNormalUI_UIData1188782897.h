#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_RoomStateNormalUI_UIData_Sub912387385.h"

// VP`1<ReferenceData`1<RoomStateNormalNormal>>
struct VP_1_t2078432065;
// VP`1<RoomStateNormalNormalUI/UIData/State>
struct VP_1_t4264626995;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateNormalNormalUI/UIData
struct  UIData_t1188782897  : public Sub_t912387385
{
public:
	// VP`1<ReferenceData`1<RoomStateNormalNormal>> RoomStateNormalNormalUI/UIData::normal
	VP_1_t2078432065 * ___normal_5;
	// VP`1<RoomStateNormalNormalUI/UIData/State> RoomStateNormalNormalUI/UIData::state
	VP_1_t4264626995 * ___state_6;

public:
	inline static int32_t get_offset_of_normal_5() { return static_cast<int32_t>(offsetof(UIData_t1188782897, ___normal_5)); }
	inline VP_1_t2078432065 * get_normal_5() const { return ___normal_5; }
	inline VP_1_t2078432065 ** get_address_of_normal_5() { return &___normal_5; }
	inline void set_normal_5(VP_1_t2078432065 * value)
	{
		___normal_5 = value;
		Il2CppCodeGenWriteBarrier(&___normal_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t1188782897, ___state_6)); }
	inline VP_1_t4264626995 * get_state_6() const { return ___state_6; }
	inline VP_1_t4264626995 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t4264626995 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
