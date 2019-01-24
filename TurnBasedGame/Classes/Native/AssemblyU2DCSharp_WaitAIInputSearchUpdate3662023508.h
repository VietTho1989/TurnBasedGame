#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1361960910.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// WaitAIInput
struct WaitAIInput_t471222699;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputSearchUpdate
struct  WaitAIInputSearchUpdate_t3662023508  : public UpdateBehavior_1_t1361960910
{
public:
	// AdvancedCoroutines.Routine WaitAIInputSearchUpdate::findAIRoutine
	Routine_t2502590640 * ___findAIRoutine_4;
	// System.Boolean WaitAIInputSearchUpdate::haveChange
	bool ___haveChange_5;
	// WaitAIInput WaitAIInputSearchUpdate::waitAIInput
	WaitAIInput_t471222699 * ___waitAIInput_6;
	// Game WaitAIInputSearchUpdate::game
	Game_t1600141214 * ___game_7;

public:
	inline static int32_t get_offset_of_findAIRoutine_4() { return static_cast<int32_t>(offsetof(WaitAIInputSearchUpdate_t3662023508, ___findAIRoutine_4)); }
	inline Routine_t2502590640 * get_findAIRoutine_4() const { return ___findAIRoutine_4; }
	inline Routine_t2502590640 ** get_address_of_findAIRoutine_4() { return &___findAIRoutine_4; }
	inline void set_findAIRoutine_4(Routine_t2502590640 * value)
	{
		___findAIRoutine_4 = value;
		Il2CppCodeGenWriteBarrier(&___findAIRoutine_4, value);
	}

	inline static int32_t get_offset_of_haveChange_5() { return static_cast<int32_t>(offsetof(WaitAIInputSearchUpdate_t3662023508, ___haveChange_5)); }
	inline bool get_haveChange_5() const { return ___haveChange_5; }
	inline bool* get_address_of_haveChange_5() { return &___haveChange_5; }
	inline void set_haveChange_5(bool value)
	{
		___haveChange_5 = value;
	}

	inline static int32_t get_offset_of_waitAIInput_6() { return static_cast<int32_t>(offsetof(WaitAIInputSearchUpdate_t3662023508, ___waitAIInput_6)); }
	inline WaitAIInput_t471222699 * get_waitAIInput_6() const { return ___waitAIInput_6; }
	inline WaitAIInput_t471222699 ** get_address_of_waitAIInput_6() { return &___waitAIInput_6; }
	inline void set_waitAIInput_6(WaitAIInput_t471222699 * value)
	{
		___waitAIInput_6 = value;
		Il2CppCodeGenWriteBarrier(&___waitAIInput_6, value);
	}

	inline static int32_t get_offset_of_game_7() { return static_cast<int32_t>(offsetof(WaitAIInputSearchUpdate_t3662023508, ___game_7)); }
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
