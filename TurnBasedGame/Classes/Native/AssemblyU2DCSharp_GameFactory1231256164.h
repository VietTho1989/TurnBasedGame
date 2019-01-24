#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<TimeControl.TimeControl>
struct VP_1_t2384873450;
// VP`1<GameDataFactory>
struct VP_1_t167587042;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameFactory
struct  GameFactory_t1231256164  : public Data_t3569509720
{
public:
	// VP`1<TimeControl.TimeControl> GameFactory::timeControl
	VP_1_t2384873450 * ___timeControl_5;
	// VP`1<GameDataFactory> GameFactory::gameDataFactory
	VP_1_t167587042 * ___gameDataFactory_6;

public:
	inline static int32_t get_offset_of_timeControl_5() { return static_cast<int32_t>(offsetof(GameFactory_t1231256164, ___timeControl_5)); }
	inline VP_1_t2384873450 * get_timeControl_5() const { return ___timeControl_5; }
	inline VP_1_t2384873450 ** get_address_of_timeControl_5() { return &___timeControl_5; }
	inline void set_timeControl_5(VP_1_t2384873450 * value)
	{
		___timeControl_5 = value;
		Il2CppCodeGenWriteBarrier(&___timeControl_5, value);
	}

	inline static int32_t get_offset_of_gameDataFactory_6() { return static_cast<int32_t>(offsetof(GameFactory_t1231256164, ___gameDataFactory_6)); }
	inline VP_1_t167587042 * get_gameDataFactory_6() const { return ___gameDataFactory_6; }
	inline VP_1_t167587042 ** get_address_of_gameDataFactory_6() { return &___gameDataFactory_6; }
	inline void set_gameDataFactory_6(VP_1_t167587042 * value)
	{
		___gameDataFactory_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataFactory_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
