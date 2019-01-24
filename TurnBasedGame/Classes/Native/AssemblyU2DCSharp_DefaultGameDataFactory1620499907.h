#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameDataFactory4084277332.h"

// VP`1<DefaultGameType>
struct VP_1_t2019297189;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DefaultGameDataFactory
struct  DefaultGameDataFactory_t1620499907  : public GameDataFactory_t4084277332
{
public:
	// VP`1<DefaultGameType> DefaultGameDataFactory::defaultGameType
	VP_1_t2019297189 * ___defaultGameType_5;
	// VP`1<System.Boolean> DefaultGameDataFactory::useRule
	VP_1_t4203851724 * ___useRule_6;

public:
	inline static int32_t get_offset_of_defaultGameType_5() { return static_cast<int32_t>(offsetof(DefaultGameDataFactory_t1620499907, ___defaultGameType_5)); }
	inline VP_1_t2019297189 * get_defaultGameType_5() const { return ___defaultGameType_5; }
	inline VP_1_t2019297189 ** get_address_of_defaultGameType_5() { return &___defaultGameType_5; }
	inline void set_defaultGameType_5(VP_1_t2019297189 * value)
	{
		___defaultGameType_5 = value;
		Il2CppCodeGenWriteBarrier(&___defaultGameType_5, value);
	}

	inline static int32_t get_offset_of_useRule_6() { return static_cast<int32_t>(offsetof(DefaultGameDataFactory_t1620499907, ___useRule_6)); }
	inline VP_1_t4203851724 * get_useRule_6() const { return ___useRule_6; }
	inline VP_1_t4203851724 ** get_address_of_useRule_6() { return &___useRule_6; }
	inline void set_useRule_6(VP_1_t4203851724 * value)
	{
		___useRule_6 = value;
		Il2CppCodeGenWriteBarrier(&___useRule_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
