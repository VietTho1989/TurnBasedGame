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
// Reversi.InputUI/UIData
struct UIData_t3005903509;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameDataUICheckAllowInputChange`1<Reversi.InputUI/UIData>
struct  GameDataUICheckAllowInputChange_1_t451684194  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameDataUICheckAllowInputChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameDataUICheckAllowInputChange`1::data
	UIData_t3005903509 * ___data_6;
	// GameDataUI/UIData GameDataUICheckAllowInputChange`1::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(GameDataUICheckAllowInputChange_1_t451684194, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(GameDataUICheckAllowInputChange_1_t451684194, ___data_6)); }
	inline UIData_t3005903509 * get_data_6() const { return ___data_6; }
	inline UIData_t3005903509 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(UIData_t3005903509 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_7() { return static_cast<int32_t>(offsetof(GameDataUICheckAllowInputChange_1_t451684194, ___gameDataUIData_7)); }
	inline UIData_t306925783 * get_gameDataUIData_7() const { return ___gameDataUIData_7; }
	inline UIData_t306925783 ** get_address_of_gameDataUIData_7() { return &___gameDataUIData_7; }
	inline void set_gameDataUIData_7(UIData_t306925783 * value)
	{
		___gameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
