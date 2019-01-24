#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3839612477.h"

// Login
struct Login_t3555589017;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StepGetDataUpdate
struct  StepGetDataUpdate_t1236472351  : public UpdateBehavior_1_t3839612477
{
public:
	// Login LoginState.StepGetDataUpdate::login
	Login_t3555589017 * ___login_4;

public:
	inline static int32_t get_offset_of_login_4() { return static_cast<int32_t>(offsetof(StepGetDataUpdate_t1236472351, ___login_4)); }
	inline Login_t3555589017 * get_login_4() const { return ___login_4; }
	inline Login_t3555589017 ** get_address_of_login_4() { return &___login_4; }
	inline void set_login_4(Login_t3555589017 * value)
	{
		___login_4 = value;
		Il2CppCodeGenWriteBarrier(&___login_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
