#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2843839788.h"

// GameDataBoardUI/UIData
struct UIData_t2908617385;
// Game
struct Game_t1600141214;
// Record.ViewRecordUI/UIData
struct UIData_t3378654950;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AnimationManagerUpdate
struct  AnimationManagerUpdate_t3472656784  : public UpdateBehavior_1_t2843839788
{
public:
	// System.Single AnimationManagerUpdate::delayTime
	float ___delayTime_4;
	// GameDataBoardUI/UIData AnimationManagerUpdate::gameDataBoardUIData
	UIData_t2908617385 * ___gameDataBoardUIData_6;
	// Game AnimationManagerUpdate::game
	Game_t1600141214 * ___game_7;
	// Record.ViewRecordUI/UIData AnimationManagerUpdate::viewRecordUIData
	UIData_t3378654950 * ___viewRecordUIData_8;

public:
	inline static int32_t get_offset_of_delayTime_4() { return static_cast<int32_t>(offsetof(AnimationManagerUpdate_t3472656784, ___delayTime_4)); }
	inline float get_delayTime_4() const { return ___delayTime_4; }
	inline float* get_address_of_delayTime_4() { return &___delayTime_4; }
	inline void set_delayTime_4(float value)
	{
		___delayTime_4 = value;
	}

	inline static int32_t get_offset_of_gameDataBoardUIData_6() { return static_cast<int32_t>(offsetof(AnimationManagerUpdate_t3472656784, ___gameDataBoardUIData_6)); }
	inline UIData_t2908617385 * get_gameDataBoardUIData_6() const { return ___gameDataBoardUIData_6; }
	inline UIData_t2908617385 ** get_address_of_gameDataBoardUIData_6() { return &___gameDataBoardUIData_6; }
	inline void set_gameDataBoardUIData_6(UIData_t2908617385 * value)
	{
		___gameDataBoardUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataBoardUIData_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(AnimationManagerUpdate_t3472656784, ___game_7)); }
	inline Game_t1600141214 * get_game_7() const { return ___game_7; }
	inline Game_t1600141214 ** get_address_of_game_7() { return &___game_7; }
	inline void set_game_7(Game_t1600141214 * value)
	{
		___game_7 = value;
		Il2CppCodeGenWriteBarrier(&___game_7, value);
	}

	inline static int32_t get_offset_of_viewRecordUIData_8() { return static_cast<int32_t>(offsetof(AnimationManagerUpdate_t3472656784, ___viewRecordUIData_8)); }
	inline UIData_t3378654950 * get_viewRecordUIData_8() const { return ___viewRecordUIData_8; }
	inline UIData_t3378654950 ** get_address_of_viewRecordUIData_8() { return &___viewRecordUIData_8; }
	inline void set_viewRecordUIData_8(UIData_t3378654950 * value)
	{
		___viewRecordUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___viewRecordUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
