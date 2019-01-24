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
// TimeControl.HourGlass.TimeControlHourGlass
struct TimeControlHourGlass_t3851955822;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameCheckPlayerChange`1<TimeControl.HourGlass.TimeControlHourGlass>
struct  GameCheckPlayerChange_1_t2883130939  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameCheckPlayerChange`1::change
	VP_1_t2450154454 * ___change_5;
	// K GameCheckPlayerChange`1::data
	TimeControlHourGlass_t3851955822 * ___data_6;
	// Game GameCheckPlayerChange`1::game
	Game_t1600141214 * ___game_7;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(GameCheckPlayerChange_1_t2883130939, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(GameCheckPlayerChange_1_t2883130939, ___data_6)); }
	inline TimeControlHourGlass_t3851955822 * get_data_6() const { return ___data_6; }
	inline TimeControlHourGlass_t3851955822 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(TimeControlHourGlass_t3851955822 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(GameCheckPlayerChange_1_t2883130939, ___game_7)); }
	inline Game_t1600141214 * get_game_7() const { return ___game_7; }
	inline Game_t1600141214 ** get_address_of_game_7() { return &___game_7; }
	inline void set_game_7(Game_t1600141214 * value)
	{
		___game_7 = value;
		Il2CppCodeGenWriteBarrier(&___game_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
