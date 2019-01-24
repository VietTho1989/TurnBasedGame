#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen111175832.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Login
struct Login_t3555589017;
// LoginState.Log
struct Log_t1025284008;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StepLoginUpdate
struct  StepLoginUpdate_t3738269396  : public UpdateBehavior_1_t111175832
{
public:
	// AdvancedCoroutines.Routine LoginState.StepLoginUpdate::wait
	Routine_t2502590640 * ___wait_4;
	// Login LoginState.StepLoginUpdate::login
	Login_t3555589017 * ___login_5;
	// LoginState.Log LoginState.StepLoginUpdate::log
	Log_t1025284008 * ___log_6;

public:
	inline static int32_t get_offset_of_wait_4() { return static_cast<int32_t>(offsetof(StepLoginUpdate_t3738269396, ___wait_4)); }
	inline Routine_t2502590640 * get_wait_4() const { return ___wait_4; }
	inline Routine_t2502590640 ** get_address_of_wait_4() { return &___wait_4; }
	inline void set_wait_4(Routine_t2502590640 * value)
	{
		___wait_4 = value;
		Il2CppCodeGenWriteBarrier(&___wait_4, value);
	}

	inline static int32_t get_offset_of_login_5() { return static_cast<int32_t>(offsetof(StepLoginUpdate_t3738269396, ___login_5)); }
	inline Login_t3555589017 * get_login_5() const { return ___login_5; }
	inline Login_t3555589017 ** get_address_of_login_5() { return &___login_5; }
	inline void set_login_5(Login_t3555589017 * value)
	{
		___login_5 = value;
		Il2CppCodeGenWriteBarrier(&___login_5, value);
	}

	inline static int32_t get_offset_of_log_6() { return static_cast<int32_t>(offsetof(StepLoginUpdate_t3738269396, ___log_6)); }
	inline Log_t1025284008 * get_log_6() const { return ___log_6; }
	inline Log_t1025284008 ** get_address_of_log_6() { return &___log_6; }
	inline void set_log_6(Log_t1025284008 * value)
	{
		___log_6 = value;
		Il2CppCodeGenWriteBarrier(&___log_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
