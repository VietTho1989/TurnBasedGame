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
// Chess.BoardUI/UIData
struct UIData_t3651970907;
// GameDataBoardUI/UIData
struct UIData_t2908617385;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AnimationManagerCheckChange`1<Chess.BoardUI/UIData>
struct  AnimationManagerCheckChange_1_t3866943444  : public Data_t3569509720
{
public:
	// System.Boolean AnimationManagerCheckChange`1::needTimeChange
	bool ___needTimeChange_5;
	// VP`1<System.Int32> AnimationManagerCheckChange`1::change
	VP_1_t2450154454 * ___change_6;
	// K AnimationManagerCheckChange`1::data
	UIData_t3651970907 * ___data_7;
	// GameDataBoardUI/UIData AnimationManagerCheckChange`1::gameDataBoardUIData
	UIData_t2908617385 * ___gameDataBoardUIData_8;

public:
	inline static int32_t get_offset_of_needTimeChange_5() { return static_cast<int32_t>(offsetof(AnimationManagerCheckChange_1_t3866943444, ___needTimeChange_5)); }
	inline bool get_needTimeChange_5() const { return ___needTimeChange_5; }
	inline bool* get_address_of_needTimeChange_5() { return &___needTimeChange_5; }
	inline void set_needTimeChange_5(bool value)
	{
		___needTimeChange_5 = value;
	}

	inline static int32_t get_offset_of_change_6() { return static_cast<int32_t>(offsetof(AnimationManagerCheckChange_1_t3866943444, ___change_6)); }
	inline VP_1_t2450154454 * get_change_6() const { return ___change_6; }
	inline VP_1_t2450154454 ** get_address_of_change_6() { return &___change_6; }
	inline void set_change_6(VP_1_t2450154454 * value)
	{
		___change_6 = value;
		Il2CppCodeGenWriteBarrier(&___change_6, value);
	}

	inline static int32_t get_offset_of_data_7() { return static_cast<int32_t>(offsetof(AnimationManagerCheckChange_1_t3866943444, ___data_7)); }
	inline UIData_t3651970907 * get_data_7() const { return ___data_7; }
	inline UIData_t3651970907 ** get_address_of_data_7() { return &___data_7; }
	inline void set_data_7(UIData_t3651970907 * value)
	{
		___data_7 = value;
		Il2CppCodeGenWriteBarrier(&___data_7, value);
	}

	inline static int32_t get_offset_of_gameDataBoardUIData_8() { return static_cast<int32_t>(offsetof(AnimationManagerCheckChange_1_t3866943444, ___gameDataBoardUIData_8)); }
	inline UIData_t2908617385 * get_gameDataBoardUIData_8() const { return ___gameDataBoardUIData_8; }
	inline UIData_t2908617385 ** get_address_of_gameDataBoardUIData_8() { return &___gameDataBoardUIData_8; }
	inline void set_gameDataBoardUIData_8(UIData_t2908617385 * value)
	{
		___gameDataBoardUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
