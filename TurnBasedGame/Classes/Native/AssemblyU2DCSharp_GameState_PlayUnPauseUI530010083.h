#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1573749031.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUnPauseUI
struct  PlayUnPauseUI_t530010083  : public UIBehavior_1_t1573749031
{
public:
	// UnityEngine.UI.Text GameState.PlayUnPauseUI::tvName
	Text_t356221433 * ___tvName_6;
	// UnityEngine.UI.Text GameState.PlayUnPauseUI::tvTime
	Text_t356221433 * ___tvTime_7;
	// AccountAvatarUI GameState.PlayUnPauseUI::accountAvatarPrefab
	AccountAvatarUI_t3584502088 * ___accountAvatarPrefab_8;
	// UnityEngine.Transform GameState.PlayUnPauseUI::accountAvatarContainer
	Transform_t3275118058 * ___accountAvatarContainer_9;

public:
	inline static int32_t get_offset_of_tvName_6() { return static_cast<int32_t>(offsetof(PlayUnPauseUI_t530010083, ___tvName_6)); }
	inline Text_t356221433 * get_tvName_6() const { return ___tvName_6; }
	inline Text_t356221433 ** get_address_of_tvName_6() { return &___tvName_6; }
	inline void set_tvName_6(Text_t356221433 * value)
	{
		___tvName_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_6, value);
	}

	inline static int32_t get_offset_of_tvTime_7() { return static_cast<int32_t>(offsetof(PlayUnPauseUI_t530010083, ___tvTime_7)); }
	inline Text_t356221433 * get_tvTime_7() const { return ___tvTime_7; }
	inline Text_t356221433 ** get_address_of_tvTime_7() { return &___tvTime_7; }
	inline void set_tvTime_7(Text_t356221433 * value)
	{
		___tvTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvTime_7, value);
	}

	inline static int32_t get_offset_of_accountAvatarPrefab_8() { return static_cast<int32_t>(offsetof(PlayUnPauseUI_t530010083, ___accountAvatarPrefab_8)); }
	inline AccountAvatarUI_t3584502088 * get_accountAvatarPrefab_8() const { return ___accountAvatarPrefab_8; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_accountAvatarPrefab_8() { return &___accountAvatarPrefab_8; }
	inline void set_accountAvatarPrefab_8(AccountAvatarUI_t3584502088 * value)
	{
		___accountAvatarPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatarPrefab_8, value);
	}

	inline static int32_t get_offset_of_accountAvatarContainer_9() { return static_cast<int32_t>(offsetof(PlayUnPauseUI_t530010083, ___accountAvatarContainer_9)); }
	inline Transform_t3275118058 * get_accountAvatarContainer_9() const { return ___accountAvatarContainer_9; }
	inline Transform_t3275118058 ** get_address_of_accountAvatarContainer_9() { return &___accountAvatarContainer_9; }
	inline void set_accountAvatarContainer_9(Transform_t3275118058 * value)
	{
		___accountAvatarContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___accountAvatarContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
