#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FriendStateUI_UIData_Sub1685311667.h"

// VP`1<ReferenceData`1<FriendStateRequest>>
struct VP_1_t3059084147;
// VP`1<FriendStateRequestUI/UIData/State>
struct VP_1_t3254398415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateRequestUI/UIData
struct  UIData_t535169461  : public Sub_t1685311667
{
public:
	// VP`1<ReferenceData`1<FriendStateRequest>> FriendStateRequestUI/UIData::friendStateRequest
	VP_1_t3059084147 * ___friendStateRequest_5;
	// VP`1<FriendStateRequestUI/UIData/State> FriendStateRequestUI/UIData::state
	VP_1_t3254398415 * ___state_6;

public:
	inline static int32_t get_offset_of_friendStateRequest_5() { return static_cast<int32_t>(offsetof(UIData_t535169461, ___friendStateRequest_5)); }
	inline VP_1_t3059084147 * get_friendStateRequest_5() const { return ___friendStateRequest_5; }
	inline VP_1_t3059084147 ** get_address_of_friendStateRequest_5() { return &___friendStateRequest_5; }
	inline void set_friendStateRequest_5(VP_1_t3059084147 * value)
	{
		___friendStateRequest_5 = value;
		Il2CppCodeGenWriteBarrier(&___friendStateRequest_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t535169461, ___state_6)); }
	inline VP_1_t3254398415 * get_state_6() const { return ___state_6; }
	inline VP_1_t3254398415 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t3254398415 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
