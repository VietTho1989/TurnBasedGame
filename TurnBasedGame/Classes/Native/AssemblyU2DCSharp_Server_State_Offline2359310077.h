#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Server_State3514787095.h"

// VP`1<Login>
struct VP_1_t3933866023;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Server/State/Offline
struct  Offline_t2359310077  : public State_t3514787095
{
public:
	// VP`1<Login> Server/State/Offline::login
	VP_1_t3933866023 * ___login_5;

public:
	inline static int32_t get_offset_of_login_5() { return static_cast<int32_t>(offsetof(Offline_t2359310077, ___login_5)); }
	inline VP_1_t3933866023 * get_login_5() const { return ___login_5; }
	inline VP_1_t3933866023 ** get_address_of_login_5() { return &___login_5; }
	inline void set_login_5(VP_1_t3933866023 * value)
	{
		___login_5 = value;
		Il2CppCodeGenWriteBarrier(&___login_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
