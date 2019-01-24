#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2028201603.h"

// GameData
struct GameData_t450274222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CheckGameFinishUpdate
struct  CheckGameFinishUpdate_t977214300  : public UpdateBehavior_1_t2028201603
{
public:
	// GameData CheckGameFinishUpdate::gameData
	GameData_t450274222 * ___gameData_4;

public:
	inline static int32_t get_offset_of_gameData_4() { return static_cast<int32_t>(offsetof(CheckGameFinishUpdate_t977214300, ___gameData_4)); }
	inline GameData_t450274222 * get_gameData_4() const { return ___gameData_4; }
	inline GameData_t450274222 ** get_address_of_gameData_4() { return &___gameData_4; }
	inline void set_gameData_4(GameData_t450274222 * value)
	{
		___gameData_4 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
