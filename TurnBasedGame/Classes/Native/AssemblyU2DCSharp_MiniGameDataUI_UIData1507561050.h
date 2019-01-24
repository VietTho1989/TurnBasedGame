#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameData>>
struct VP_1_t4194301587;
// VP`1<GameDataBoardUI/UIData>
struct VP_1_t3286894391;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MiniGameDataUI/UIData
struct  UIData_t1507561050  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameData>> MiniGameDataUI/UIData::gameData
	VP_1_t4194301587 * ___gameData_5;
	// VP`1<GameDataBoardUI/UIData> MiniGameDataUI/UIData::board
	VP_1_t3286894391 * ___board_6;

public:
	inline static int32_t get_offset_of_gameData_5() { return static_cast<int32_t>(offsetof(UIData_t1507561050, ___gameData_5)); }
	inline VP_1_t4194301587 * get_gameData_5() const { return ___gameData_5; }
	inline VP_1_t4194301587 ** get_address_of_gameData_5() { return &___gameData_5; }
	inline void set_gameData_5(VP_1_t4194301587 * value)
	{
		___gameData_5 = value;
		Il2CppCodeGenWriteBarrier(&___gameData_5, value);
	}

	inline static int32_t get_offset_of_board_6() { return static_cast<int32_t>(offsetof(UIData_t1507561050, ___board_6)); }
	inline VP_1_t3286894391 * get_board_6() const { return ___board_6; }
	inline VP_1_t3286894391 ** get_address_of_board_6() { return &___board_6; }
	inline void set_board_6(VP_1_t3286894391 * value)
	{
		___board_6 = value;
		Il2CppCodeGenWriteBarrier(&___board_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
