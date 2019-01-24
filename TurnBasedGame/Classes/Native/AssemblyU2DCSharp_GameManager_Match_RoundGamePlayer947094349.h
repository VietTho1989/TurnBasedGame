#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen223026628.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// InformAvatarUI
struct InformAvatarUI_t2288633734;
// UnityEngine.Transform
struct Transform_t3275118058;
// Game
struct Game_t1600141214;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGamePlayerUI
struct  RoundGamePlayerUI_t947094349  : public UIBehavior_1_t223026628
{
public:
	// UnityEngine.UI.Text GameManager.Match.RoundGamePlayerUI::tvName
	Text_t356221433 * ___tvName_6;
	// InformAvatarUI GameManager.Match.RoundGamePlayerUI::informAvatarPrefab
	InformAvatarUI_t2288633734 * ___informAvatarPrefab_7;
	// UnityEngine.Transform GameManager.Match.RoundGamePlayerUI::informAvatarContainer
	Transform_t3275118058 * ___informAvatarContainer_8;
	// Game GameManager.Match.RoundGamePlayerUI::game
	Game_t1600141214 * ___game_9;

public:
	inline static int32_t get_offset_of_tvName_6() { return static_cast<int32_t>(offsetof(RoundGamePlayerUI_t947094349, ___tvName_6)); }
	inline Text_t356221433 * get_tvName_6() const { return ___tvName_6; }
	inline Text_t356221433 ** get_address_of_tvName_6() { return &___tvName_6; }
	inline void set_tvName_6(Text_t356221433 * value)
	{
		___tvName_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_6, value);
	}

	inline static int32_t get_offset_of_informAvatarPrefab_7() { return static_cast<int32_t>(offsetof(RoundGamePlayerUI_t947094349, ___informAvatarPrefab_7)); }
	inline InformAvatarUI_t2288633734 * get_informAvatarPrefab_7() const { return ___informAvatarPrefab_7; }
	inline InformAvatarUI_t2288633734 ** get_address_of_informAvatarPrefab_7() { return &___informAvatarPrefab_7; }
	inline void set_informAvatarPrefab_7(InformAvatarUI_t2288633734 * value)
	{
		___informAvatarPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___informAvatarPrefab_7, value);
	}

	inline static int32_t get_offset_of_informAvatarContainer_8() { return static_cast<int32_t>(offsetof(RoundGamePlayerUI_t947094349, ___informAvatarContainer_8)); }
	inline Transform_t3275118058 * get_informAvatarContainer_8() const { return ___informAvatarContainer_8; }
	inline Transform_t3275118058 ** get_address_of_informAvatarContainer_8() { return &___informAvatarContainer_8; }
	inline void set_informAvatarContainer_8(Transform_t3275118058 * value)
	{
		___informAvatarContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___informAvatarContainer_8, value);
	}

	inline static int32_t get_offset_of_game_9() { return static_cast<int32_t>(offsetof(RoundGamePlayerUI_t947094349, ___game_9)); }
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
