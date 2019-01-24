#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameData_State1609625640.h"

// LP`1<PlayerResult>
struct LP_1_t2096204856;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameDataStateFinish
struct  GameDataStateFinish_t1266101068  : public State_t1609625640
{
public:
	// LP`1<PlayerResult> GameDataStateFinish::playerResults
	LP_1_t2096204856 * ___playerResults_5;

public:
	inline static int32_t get_offset_of_playerResults_5() { return static_cast<int32_t>(offsetof(GameDataStateFinish_t1266101068, ___playerResults_5)); }
	inline LP_1_t2096204856 * get_playerResults_5() const { return ___playerResults_5; }
	inline LP_1_t2096204856 ** get_address_of_playerResults_5() { return &___playerResults_5; }
	inline void set_playerResults_5(LP_1_t2096204856 * value)
	{
		___playerResults_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerResults_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
