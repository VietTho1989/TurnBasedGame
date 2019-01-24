#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Server_State3514787095.h"

// VP`1<System.Single>
struct VP_1_t2454786938;
// VP`1<Login>
struct VP_1_t3933866023;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Server/State/Disconnect
struct  Disconnect_t3392142940  : public State_t3514787095
{
public:
	// VP`1<System.Single> Server/State/Disconnect::time
	VP_1_t2454786938 * ___time_5;
	// VP`1<Login> Server/State/Disconnect::login
	VP_1_t3933866023 * ___login_6;

public:
	inline static int32_t get_offset_of_time_5() { return static_cast<int32_t>(offsetof(Disconnect_t3392142940, ___time_5)); }
	inline VP_1_t2454786938 * get_time_5() const { return ___time_5; }
	inline VP_1_t2454786938 ** get_address_of_time_5() { return &___time_5; }
	inline void set_time_5(VP_1_t2454786938 * value)
	{
		___time_5 = value;
		Il2CppCodeGenWriteBarrier(&___time_5, value);
	}

	inline static int32_t get_offset_of_login_6() { return static_cast<int32_t>(offsetof(Disconnect_t3392142940, ___login_6)); }
	inline VP_1_t3933866023 * get_login_6() const { return ___login_6; }
	inline VP_1_t3933866023 ** get_address_of_login_6() { return &___login_6; }
	inline void set_login_6(VP_1_t3933866023 * value)
	{
		___login_6 = value;
		Il2CppCodeGenWriteBarrier(&___login_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
