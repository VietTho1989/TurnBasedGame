#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameType1641020183.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.DefaultChess
struct  DefaultChess_t2058417003  : public DefaultGameType_t1641020183
{
public:
	// VP`1<System.Boolean> Chess.DefaultChess::chess960
	VP_1_t4203851724 * ___chess960_5;

public:
	inline static int32_t get_offset_of_chess960_5() { return static_cast<int32_t>(offsetof(DefaultChess_t2058417003, ___chess960_5)); }
	inline VP_1_t4203851724 * get_chess960_5() const { return ___chess960_5; }
	inline VP_1_t4203851724 ** get_address_of_chess960_5() { return &___chess960_5; }
	inline void set_chess960_5(VP_1_t4203851724 * value)
	{
		___chess960_5 = value;
		Il2CppCodeGenWriteBarrier(&___chess960_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
