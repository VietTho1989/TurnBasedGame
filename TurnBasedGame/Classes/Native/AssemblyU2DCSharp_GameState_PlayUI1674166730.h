#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1785616630.h"

// GameState.PlayNormalUI
struct PlayNormalUI_t3256511585;
// GameState.PlayPauseUI
struct PlayPauseUI_t4065594944;
// GameState.PlayUnPauseUI
struct PlayUnPauseUI_t530010083;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUI
struct  PlayUI_t1674166730  : public UIBehavior_1_t1785616630
{
public:
	// GameState.PlayNormalUI GameState.PlayUI::playNormalPrefab
	PlayNormalUI_t3256511585 * ___playNormalPrefab_6;
	// GameState.PlayPauseUI GameState.PlayUI::playPausePrefab
	PlayPauseUI_t4065594944 * ___playPausePrefab_7;
	// GameState.PlayUnPauseUI GameState.PlayUI::playUnPausePrefab
	PlayUnPauseUI_t530010083 * ___playUnPausePrefab_8;

public:
	inline static int32_t get_offset_of_playNormalPrefab_6() { return static_cast<int32_t>(offsetof(PlayUI_t1674166730, ___playNormalPrefab_6)); }
	inline PlayNormalUI_t3256511585 * get_playNormalPrefab_6() const { return ___playNormalPrefab_6; }
	inline PlayNormalUI_t3256511585 ** get_address_of_playNormalPrefab_6() { return &___playNormalPrefab_6; }
	inline void set_playNormalPrefab_6(PlayNormalUI_t3256511585 * value)
	{
		___playNormalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___playNormalPrefab_6, value);
	}

	inline static int32_t get_offset_of_playPausePrefab_7() { return static_cast<int32_t>(offsetof(PlayUI_t1674166730, ___playPausePrefab_7)); }
	inline PlayPauseUI_t4065594944 * get_playPausePrefab_7() const { return ___playPausePrefab_7; }
	inline PlayPauseUI_t4065594944 ** get_address_of_playPausePrefab_7() { return &___playPausePrefab_7; }
	inline void set_playPausePrefab_7(PlayPauseUI_t4065594944 * value)
	{
		___playPausePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___playPausePrefab_7, value);
	}

	inline static int32_t get_offset_of_playUnPausePrefab_8() { return static_cast<int32_t>(offsetof(PlayUI_t1674166730, ___playUnPausePrefab_8)); }
	inline PlayUnPauseUI_t530010083 * get_playUnPausePrefab_8() const { return ___playUnPausePrefab_8; }
	inline PlayUnPauseUI_t530010083 ** get_address_of_playUnPausePrefab_8() { return &___playUnPausePrefab_8; }
	inline void set_playUnPausePrefab_8(PlayUnPauseUI_t530010083 * value)
	{
		___playUnPausePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___playUnPausePrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
