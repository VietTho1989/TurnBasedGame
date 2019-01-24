#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_WaitInputAction_Sub2792249764.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitHumanInput
struct  WaitHumanInput_t3668463842  : public Sub_t2792249764
{
public:
	// VP`1<System.UInt32> WaitHumanInput::userId
	VP_1_t2527959027 * ___userId_5;

public:
	inline static int32_t get_offset_of_userId_5() { return static_cast<int32_t>(offsetof(WaitHumanInput_t3668463842, ___userId_5)); }
	inline VP_1_t2527959027 * get_userId_5() const { return ___userId_5; }
	inline VP_1_t2527959027 ** get_address_of_userId_5() { return &___userId_5; }
	inline void set_userId_5(VP_1_t2527959027 * value)
	{
		___userId_5 = value;
		Il2CppCodeGenWriteBarrier(&___userId_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
