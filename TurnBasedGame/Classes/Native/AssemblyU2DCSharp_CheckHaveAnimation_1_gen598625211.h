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
// FairyChess.FairyChessGameDataUI/UIData
struct UIData_t3976046997;
// GameDataBoardUI/UIData
struct UIData_t2908617385;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CheckHaveAnimation`1<FairyChess.FairyChessGameDataUI/UIData>
struct  CheckHaveAnimation_1_t598625211  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> CheckHaveAnimation`1::change
	VP_1_t2450154454 * ___change_5;
	// K CheckHaveAnimation`1::data
	UIData_t3976046997 * ___data_6;
	// GameDataBoardUI/UIData CheckHaveAnimation`1::gameDataBoardUIData
	UIData_t2908617385 * ___gameDataBoardUIData_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(CheckHaveAnimation_1_t598625211, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(CheckHaveAnimation_1_t598625211, ___data_6)); }
	inline UIData_t3976046997 * get_data_6() const { return ___data_6; }
	inline UIData_t3976046997 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(UIData_t3976046997 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_gameDataBoardUIData_7() { return static_cast<int32_t>(offsetof(CheckHaveAnimation_1_t598625211, ___gameDataBoardUIData_7)); }
	inline UIData_t2908617385 * get_gameDataBoardUIData_7() const { return ___gameDataBoardUIData_7; }
	inline UIData_t2908617385 ** get_address_of_gameDataBoardUIData_7() { return &___gameDataBoardUIData_7; }
	inline void set_gameDataBoardUIData_7(UIData_t2908617385 * value)
	{
		___gameDataBoardUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
