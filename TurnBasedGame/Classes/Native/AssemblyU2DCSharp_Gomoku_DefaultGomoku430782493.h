#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DefaultGameType1641020183.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.DefaultGomoku
struct  DefaultGomoku_t430782493  : public DefaultGameType_t1641020183
{
public:
	// VP`1<System.Int32> Gomoku.DefaultGomoku::boardSize
	VP_1_t2450154454 * ___boardSize_5;

public:
	inline static int32_t get_offset_of_boardSize_5() { return static_cast<int32_t>(offsetof(DefaultGomoku_t430782493, ___boardSize_5)); }
	inline VP_1_t2450154454 * get_boardSize_5() const { return ___boardSize_5; }
	inline VP_1_t2450154454 ** get_address_of_boardSize_5() { return &___boardSize_5; }
	inline void set_boardSize_5(VP_1_t2450154454 * value)
	{
		___boardSize_5 = value;
		Il2CppCodeGenWriteBarrier(&___boardSize_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
