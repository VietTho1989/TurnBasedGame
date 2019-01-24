#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Record_ViewRecordUI_UIData_Sub3864338805.h"

// VP`1<ReferenceData`1<Game>>
struct VP_1_t1049201283;
// VP`1<GameUI/UIData>
struct VP_1_t4256190837;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Record.ViewGameRecordUI/UIData
struct  UIData_t834196900  : public Sub_t3864338805
{
public:
	// VP`1<ReferenceData`1<Game>> Record.ViewGameRecordUI/UIData::game
	VP_1_t1049201283 * ___game_5;
	// VP`1<GameUI/UIData> Record.ViewGameRecordUI/UIData::gameUIData
	VP_1_t4256190837 * ___gameUIData_6;

public:
	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(UIData_t834196900, ___game_5)); }
	inline VP_1_t1049201283 * get_game_5() const { return ___game_5; }
	inline VP_1_t1049201283 ** get_address_of_game_5() { return &___game_5; }
	inline void set_game_5(VP_1_t1049201283 * value)
	{
		___game_5 = value;
		Il2CppCodeGenWriteBarrier(&___game_5, value);
	}

	inline static int32_t get_offset_of_gameUIData_6() { return static_cast<int32_t>(offsetof(UIData_t834196900, ___gameUIData_6)); }
	inline VP_1_t4256190837 * get_gameUIData_6() const { return ___gameUIData_6; }
	inline VP_1_t4256190837 ** get_address_of_gameUIData_6() { return &___gameUIData_6; }
	inline void set_gameUIData_6(VP_1_t4256190837 * value)
	{
		___gameUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameUIData_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
