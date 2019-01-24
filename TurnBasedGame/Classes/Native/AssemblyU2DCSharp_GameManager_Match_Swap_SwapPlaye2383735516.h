#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4196037962.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// InformAvatarUI
struct InformAvatarUI_t2288633734;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.SwapPlayerUI
struct  SwapPlayerUI_t2383735516  : public UIBehavior_1_t4196037962
{
public:
	// UnityEngine.UI.Text GameManager.Match.Swap.SwapPlayerUI::tvPlayerIndex
	Text_t356221433 * ___tvPlayerIndex_6;
	// UnityEngine.UI.Text GameManager.Match.Swap.SwapPlayerUI::tvPlayerName
	Text_t356221433 * ___tvPlayerName_7;
	// InformAvatarUI GameManager.Match.Swap.SwapPlayerUI::avatarPrefab
	InformAvatarUI_t2288633734 * ___avatarPrefab_8;
	// UnityEngine.Transform GameManager.Match.Swap.SwapPlayerUI::avatarContainer
	Transform_t3275118058 * ___avatarContainer_9;

public:
	inline static int32_t get_offset_of_tvPlayerIndex_6() { return static_cast<int32_t>(offsetof(SwapPlayerUI_t2383735516, ___tvPlayerIndex_6)); }
	inline Text_t356221433 * get_tvPlayerIndex_6() const { return ___tvPlayerIndex_6; }
	inline Text_t356221433 ** get_address_of_tvPlayerIndex_6() { return &___tvPlayerIndex_6; }
	inline void set_tvPlayerIndex_6(Text_t356221433 * value)
	{
		___tvPlayerIndex_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayerIndex_6, value);
	}

	inline static int32_t get_offset_of_tvPlayerName_7() { return static_cast<int32_t>(offsetof(SwapPlayerUI_t2383735516, ___tvPlayerName_7)); }
	inline Text_t356221433 * get_tvPlayerName_7() const { return ___tvPlayerName_7; }
	inline Text_t356221433 ** get_address_of_tvPlayerName_7() { return &___tvPlayerName_7; }
	inline void set_tvPlayerName_7(Text_t356221433 * value)
	{
		___tvPlayerName_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvPlayerName_7, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_8() { return static_cast<int32_t>(offsetof(SwapPlayerUI_t2383735516, ___avatarPrefab_8)); }
	inline InformAvatarUI_t2288633734 * get_avatarPrefab_8() const { return ___avatarPrefab_8; }
	inline InformAvatarUI_t2288633734 ** get_address_of_avatarPrefab_8() { return &___avatarPrefab_8; }
	inline void set_avatarPrefab_8(InformAvatarUI_t2288633734 * value)
	{
		___avatarPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_8, value);
	}

	inline static int32_t get_offset_of_avatarContainer_9() { return static_cast<int32_t>(offsetof(SwapPlayerUI_t2383735516, ___avatarContainer_9)); }
	inline Transform_t3275118058 * get_avatarContainer_9() const { return ___avatarContainer_9; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_9() { return &___avatarContainer_9; }
	inline void set_avatarContainer_9(Transform_t3275118058 * value)
	{
		___avatarContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
