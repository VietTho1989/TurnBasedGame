#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// System.Object
struct Il2CppObject;
// GameData
struct GameData_t450274222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameDataCheckChangeRule`1<System.Object>
struct  GameDataCheckChangeRule_1_t147705003  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameDataCheckChangeRule`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameDataCheckChangeRule`1::data
	Il2CppObject * ___data_6;
	// GameData GameDataCheckChangeRule`1::gameData
	GameData_t450274222 * ___gameData_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(GameDataCheckChangeRule_1_t147705003, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(GameDataCheckChangeRule_1_t147705003, ___data_6)); }
	inline Il2CppObject * get_data_6() const { return ___data_6; }
	inline Il2CppObject ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(Il2CppObject * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_gameData_7() { return static_cast<int32_t>(offsetof(GameDataCheckChangeRule_1_t147705003, ___gameData_7)); }
	inline GameData_t450274222 * get_gameData_7() const { return ___gameData_7; }
	inline GameData_t450274222 ** get_address_of_gameData_7() { return &___gameData_7; }
	inline void set_gameData_7(GameData_t450274222 * value)
	{
		___gameData_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
