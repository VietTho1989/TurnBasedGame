#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RoomUser/Role>
struct VP_1_t1056200861;
// VP`1<Human>
struct VP_1_t1534365499;
// VP`1<RoomUser/State>
struct VP_1_t2181144628;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUser
struct  RoomUser_t2913528656  : public Data_t3569509720
{
public:
	// VP`1<RoomUser/Role> RoomUser::role
	VP_1_t1056200861 * ___role_5;
	// VP`1<Human> RoomUser::inform
	VP_1_t1534365499 * ___inform_6;
	// VP`1<RoomUser/State> RoomUser::state
	VP_1_t2181144628 * ___state_7;

public:
	inline static int32_t get_offset_of_role_5() { return static_cast<int32_t>(offsetof(RoomUser_t2913528656, ___role_5)); }
	inline VP_1_t1056200861 * get_role_5() const { return ___role_5; }
	inline VP_1_t1056200861 ** get_address_of_role_5() { return &___role_5; }
	inline void set_role_5(VP_1_t1056200861 * value)
	{
		___role_5 = value;
		Il2CppCodeGenWriteBarrier(&___role_5, value);
	}

	inline static int32_t get_offset_of_inform_6() { return static_cast<int32_t>(offsetof(RoomUser_t2913528656, ___inform_6)); }
	inline VP_1_t1534365499 * get_inform_6() const { return ___inform_6; }
	inline VP_1_t1534365499 ** get_address_of_inform_6() { return &___inform_6; }
	inline void set_inform_6(VP_1_t1534365499 * value)
	{
		___inform_6 = value;
		Il2CppCodeGenWriteBarrier(&___inform_6, value);
	}

	inline static int32_t get_offset_of_state_7() { return static_cast<int32_t>(offsetof(RoomUser_t2913528656, ___state_7)); }
	inline VP_1_t2181144628 * get_state_7() const { return ___state_7; }
	inline VP_1_t2181144628 ** get_address_of_state_7() { return &___state_7; }
	inline void set_state_7(VP_1_t2181144628 * value)
	{
		___state_7 = value;
		Il2CppCodeGenWriteBarrier(&___state_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
