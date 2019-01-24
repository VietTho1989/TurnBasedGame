#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Friend_State2030436698.h"

// VP`1<FriendStateCancel/State>
struct VP_1_t201908055;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateCancel
struct  FriendStateCancel_t1713282589  : public State_t2030436698
{
public:
	// VP`1<FriendStateCancel/State> FriendStateCancel::state
	VP_1_t201908055 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(FriendStateCancel_t1713282589, ___state_5)); }
	inline VP_1_t201908055 * get_state_5() const { return ___state_5; }
	inline VP_1_t201908055 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t201908055 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
