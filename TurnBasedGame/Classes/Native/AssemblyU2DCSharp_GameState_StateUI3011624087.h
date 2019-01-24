#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen931555837.h"

// GameState.LoadUI
struct LoadUI_t2444666096;
// GameState.StartUI
struct StartUI_t403700626;
// GameState.PlayUI
struct PlayUI_t1674166730;
// GameState.EndUI
struct EndUI_t3866404643;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.StateUI
struct  StateUI_t3011624087  : public UIBehavior_1_t931555837
{
public:
	// GameState.LoadUI GameState.StateUI::loadPrefab
	LoadUI_t2444666096 * ___loadPrefab_6;
	// GameState.StartUI GameState.StateUI::startPrefab
	StartUI_t403700626 * ___startPrefab_7;
	// GameState.PlayUI GameState.StateUI::playPrefab
	PlayUI_t1674166730 * ___playPrefab_8;
	// GameState.EndUI GameState.StateUI::endPrefab
	EndUI_t3866404643 * ___endPrefab_9;

public:
	inline static int32_t get_offset_of_loadPrefab_6() { return static_cast<int32_t>(offsetof(StateUI_t3011624087, ___loadPrefab_6)); }
	inline LoadUI_t2444666096 * get_loadPrefab_6() const { return ___loadPrefab_6; }
	inline LoadUI_t2444666096 ** get_address_of_loadPrefab_6() { return &___loadPrefab_6; }
	inline void set_loadPrefab_6(LoadUI_t2444666096 * value)
	{
		___loadPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___loadPrefab_6, value);
	}

	inline static int32_t get_offset_of_startPrefab_7() { return static_cast<int32_t>(offsetof(StateUI_t3011624087, ___startPrefab_7)); }
	inline StartUI_t403700626 * get_startPrefab_7() const { return ___startPrefab_7; }
	inline StartUI_t403700626 ** get_address_of_startPrefab_7() { return &___startPrefab_7; }
	inline void set_startPrefab_7(StartUI_t403700626 * value)
	{
		___startPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___startPrefab_7, value);
	}

	inline static int32_t get_offset_of_playPrefab_8() { return static_cast<int32_t>(offsetof(StateUI_t3011624087, ___playPrefab_8)); }
	inline PlayUI_t1674166730 * get_playPrefab_8() const { return ___playPrefab_8; }
	inline PlayUI_t1674166730 ** get_address_of_playPrefab_8() { return &___playPrefab_8; }
	inline void set_playPrefab_8(PlayUI_t1674166730 * value)
	{
		___playPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___playPrefab_8, value);
	}

	inline static int32_t get_offset_of_endPrefab_9() { return static_cast<int32_t>(offsetof(StateUI_t3011624087, ___endPrefab_9)); }
	inline EndUI_t3866404643 * get_endPrefab_9() const { return ___endPrefab_9; }
	inline EndUI_t3866404643 ** get_address_of_endPrefab_9() { return &___endPrefab_9; }
	inline void set_endPrefab_9(EndUI_t3866404643 * value)
	{
		___endPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___endPrefab_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
