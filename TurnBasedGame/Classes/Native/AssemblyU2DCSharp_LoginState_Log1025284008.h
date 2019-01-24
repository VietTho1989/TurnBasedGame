#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Login_State2662870813.h"

// VP`1<LoginState.Log/ConnectState>
struct VP_1_t1880574594;
// VP`1<LoginState.Log/Step>
struct VP_1_t3682805935;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.Log
struct  Log_t1025284008  : public State_t2662870813
{
public:
	// VP`1<LoginState.Log/ConnectState> LoginState.Log::connectState
	VP_1_t1880574594 * ___connectState_5;
	// VP`1<LoginState.Log/Step> LoginState.Log::step
	VP_1_t3682805935 * ___step_6;
	// VP`1<System.Single> LoginState.Log::time
	VP_1_t2454786938 * ___time_7;
	// VP`1<System.Single> LoginState.Log::timeOut
	VP_1_t2454786938 * ___timeOut_8;

public:
	inline static int32_t get_offset_of_connectState_5() { return static_cast<int32_t>(offsetof(Log_t1025284008, ___connectState_5)); }
	inline VP_1_t1880574594 * get_connectState_5() const { return ___connectState_5; }
	inline VP_1_t1880574594 ** get_address_of_connectState_5() { return &___connectState_5; }
	inline void set_connectState_5(VP_1_t1880574594 * value)
	{
		___connectState_5 = value;
		Il2CppCodeGenWriteBarrier(&___connectState_5, value);
	}

	inline static int32_t get_offset_of_step_6() { return static_cast<int32_t>(offsetof(Log_t1025284008, ___step_6)); }
	inline VP_1_t3682805935 * get_step_6() const { return ___step_6; }
	inline VP_1_t3682805935 ** get_address_of_step_6() { return &___step_6; }
	inline void set_step_6(VP_1_t3682805935 * value)
	{
		___step_6 = value;
		Il2CppCodeGenWriteBarrier(&___step_6, value);
	}

	inline static int32_t get_offset_of_time_7() { return static_cast<int32_t>(offsetof(Log_t1025284008, ___time_7)); }
	inline VP_1_t2454786938 * get_time_7() const { return ___time_7; }
	inline VP_1_t2454786938 ** get_address_of_time_7() { return &___time_7; }
	inline void set_time_7(VP_1_t2454786938 * value)
	{
		___time_7 = value;
		Il2CppCodeGenWriteBarrier(&___time_7, value);
	}

	inline static int32_t get_offset_of_timeOut_8() { return static_cast<int32_t>(offsetof(Log_t1025284008, ___timeOut_8)); }
	inline VP_1_t2454786938 * get_timeOut_8() const { return ___timeOut_8; }
	inline VP_1_t2454786938 ** get_address_of_timeOut_8() { return &___timeOut_8; }
	inline void set_timeOut_8(VP_1_t2454786938 * value)
	{
		___timeOut_8 = value;
		Il2CppCodeGenWriteBarrier(&___timeOut_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
