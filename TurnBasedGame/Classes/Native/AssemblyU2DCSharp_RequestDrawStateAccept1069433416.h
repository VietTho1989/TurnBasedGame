#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_RequestDraw_State3353934123.h"

// LP`1<System.UInt32>
struct LP_1_t887425977;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDrawStateAccept
struct  RequestDrawStateAccept_t1069433416  : public State_t3353934123
{
public:
	// LP`1<System.UInt32> RequestDrawStateAccept::accepts
	LP_1_t887425977 * ___accepts_5;
	// LP`1<System.UInt32> RequestDrawStateAccept::refuses
	LP_1_t887425977 * ___refuses_6;

public:
	inline static int32_t get_offset_of_accepts_5() { return static_cast<int32_t>(offsetof(RequestDrawStateAccept_t1069433416, ___accepts_5)); }
	inline LP_1_t887425977 * get_accepts_5() const { return ___accepts_5; }
	inline LP_1_t887425977 ** get_address_of_accepts_5() { return &___accepts_5; }
	inline void set_accepts_5(LP_1_t887425977 * value)
	{
		___accepts_5 = value;
		Il2CppCodeGenWriteBarrier(&___accepts_5, value);
	}

	inline static int32_t get_offset_of_refuses_6() { return static_cast<int32_t>(offsetof(RequestDrawStateAccept_t1069433416, ___refuses_6)); }
	inline LP_1_t887425977 * get_refuses_6() const { return ___refuses_6; }
	inline LP_1_t887425977 ** get_address_of_refuses_6() { return &___refuses_6; }
	inline void set_refuses_6(LP_1_t887425977 * value)
	{
		___refuses_6 = value;
		Il2CppCodeGenWriteBarrier(&___refuses_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
