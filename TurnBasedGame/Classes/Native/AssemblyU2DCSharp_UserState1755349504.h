#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<UserState/State>
struct VP_1_t1346371684;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<System.Int64>
struct VP_1_t1287355043;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserState
struct  UserState_t1755349504  : public Data_t3569509720
{
public:
	// VP`1<UserState/State> UserState::state
	VP_1_t1346371684 * ___state_5;
	// VP`1<System.Boolean> UserState::hide
	VP_1_t4203851724 * ___hide_6;
	// VP`1<System.Int64> UserState::time
	VP_1_t1287355043 * ___time_7;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UserState_t1755349504, ___state_5)); }
	inline VP_1_t1346371684 * get_state_5() const { return ___state_5; }
	inline VP_1_t1346371684 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1346371684 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_hide_6() { return static_cast<int32_t>(offsetof(UserState_t1755349504, ___hide_6)); }
	inline VP_1_t4203851724 * get_hide_6() const { return ___hide_6; }
	inline VP_1_t4203851724 ** get_address_of_hide_6() { return &___hide_6; }
	inline void set_hide_6(VP_1_t4203851724 * value)
	{
		___hide_6 = value;
		Il2CppCodeGenWriteBarrier(&___hide_6, value);
	}

	inline static int32_t get_offset_of_time_7() { return static_cast<int32_t>(offsetof(UserState_t1755349504, ___time_7)); }
	inline VP_1_t1287355043 * get_time_7() const { return ___time_7; }
	inline VP_1_t1287355043 ** get_address_of_time_7() { return &___time_7; }
	inline void set_time_7(VP_1_t1287355043 * value)
	{
		___time_7 = value;
		Il2CppCodeGenWriteBarrier(&___time_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
