#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2533066135.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.GamePlayerTimeHourGlassUI
struct  GamePlayerTimeHourGlassUI_t1489757784  : public UIBehavior_1_t2533066135
{
public:
	// UnityEngine.UI.Text TimeControl.HourGlass.GamePlayerTimeHourGlassUI::tvServerTime
	Text_t356221433 * ___tvServerTime_6;
	// UnityEngine.UI.Text TimeControl.HourGlass.GamePlayerTimeHourGlassUI::tvClientTime
	Text_t356221433 * ___tvClientTime_7;
	// UnityEngine.UI.Text TimeControl.HourGlass.GamePlayerTimeHourGlassUI::tvReportTime
	Text_t356221433 * ___tvReportTime_8;
	// Game TimeControl.HourGlass.GamePlayerTimeHourGlassUI::game
	Game_t1600141214 * ___game_9;

public:
	inline static int32_t get_offset_of_tvServerTime_6() { return static_cast<int32_t>(offsetof(GamePlayerTimeHourGlassUI_t1489757784, ___tvServerTime_6)); }
	inline Text_t356221433 * get_tvServerTime_6() const { return ___tvServerTime_6; }
	inline Text_t356221433 ** get_address_of_tvServerTime_6() { return &___tvServerTime_6; }
	inline void set_tvServerTime_6(Text_t356221433 * value)
	{
		___tvServerTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvServerTime_6, value);
	}

	inline static int32_t get_offset_of_tvClientTime_7() { return static_cast<int32_t>(offsetof(GamePlayerTimeHourGlassUI_t1489757784, ___tvClientTime_7)); }
	inline Text_t356221433 * get_tvClientTime_7() const { return ___tvClientTime_7; }
	inline Text_t356221433 ** get_address_of_tvClientTime_7() { return &___tvClientTime_7; }
	inline void set_tvClientTime_7(Text_t356221433 * value)
	{
		___tvClientTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvClientTime_7, value);
	}

	inline static int32_t get_offset_of_tvReportTime_8() { return static_cast<int32_t>(offsetof(GamePlayerTimeHourGlassUI_t1489757784, ___tvReportTime_8)); }
	inline Text_t356221433 * get_tvReportTime_8() const { return ___tvReportTime_8; }
	inline Text_t356221433 ** get_address_of_tvReportTime_8() { return &___tvReportTime_8; }
	inline void set_tvReportTime_8(Text_t356221433 * value)
	{
		___tvReportTime_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvReportTime_8, value);
	}

	inline static int32_t get_offset_of_game_9() { return static_cast<int32_t>(offsetof(GamePlayerTimeHourGlassUI_t1489757784, ___game_9)); }
	inline Game_t1600141214 * get_game_9() const { return ___game_9; }
	inline Game_t1600141214 ** get_address_of_game_9() { return &___game_9; }
	inline void set_game_9(Game_t1600141214 * value)
	{
		___game_9 = value;
		Il2CppCodeGenWriteBarrier(&___game_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
