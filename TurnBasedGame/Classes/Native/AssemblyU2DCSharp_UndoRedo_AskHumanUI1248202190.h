#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3003115637.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// UndoRedo.Ask
struct Ask_t735773131;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UndoRedo.AskHumanUI
struct  AskHumanUI_t1248202190  : public UIBehavior_1_t3003115637
{
public:
	// UnityEngine.UI.Text UndoRedo.AskHumanUI::tvName
	Text_t356221433 * ___tvName_6;
	// UnityEngine.UI.Text UndoRedo.AskHumanUI::tvAnswer
	Text_t356221433 * ___tvAnswer_7;
	// UndoRedo.Ask UndoRedo.AskHumanUI::ask
	Ask_t735773131 * ___ask_8;
	// AccountAvatarUI UndoRedo.AskHumanUI::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_9;
	// UnityEngine.Transform UndoRedo.AskHumanUI::avatarContainer
	Transform_t3275118058 * ___avatarContainer_10;

public:
	inline static int32_t get_offset_of_tvName_6() { return static_cast<int32_t>(offsetof(AskHumanUI_t1248202190, ___tvName_6)); }
	inline Text_t356221433 * get_tvName_6() const { return ___tvName_6; }
	inline Text_t356221433 ** get_address_of_tvName_6() { return &___tvName_6; }
	inline void set_tvName_6(Text_t356221433 * value)
	{
		___tvName_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvName_6, value);
	}

	inline static int32_t get_offset_of_tvAnswer_7() { return static_cast<int32_t>(offsetof(AskHumanUI_t1248202190, ___tvAnswer_7)); }
	inline Text_t356221433 * get_tvAnswer_7() const { return ___tvAnswer_7; }
	inline Text_t356221433 ** get_address_of_tvAnswer_7() { return &___tvAnswer_7; }
	inline void set_tvAnswer_7(Text_t356221433 * value)
	{
		___tvAnswer_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvAnswer_7, value);
	}

	inline static int32_t get_offset_of_ask_8() { return static_cast<int32_t>(offsetof(AskHumanUI_t1248202190, ___ask_8)); }
	inline Ask_t735773131 * get_ask_8() const { return ___ask_8; }
	inline Ask_t735773131 ** get_address_of_ask_8() { return &___ask_8; }
	inline void set_ask_8(Ask_t735773131 * value)
	{
		___ask_8 = value;
		Il2CppCodeGenWriteBarrier(&___ask_8, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_9() { return static_cast<int32_t>(offsetof(AskHumanUI_t1248202190, ___avatarPrefab_9)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_9() const { return ___avatarPrefab_9; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_9() { return &___avatarPrefab_9; }
	inline void set_avatarPrefab_9(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_9, value);
	}

	inline static int32_t get_offset_of_avatarContainer_10() { return static_cast<int32_t>(offsetof(AskHumanUI_t1248202190, ___avatarContainer_10)); }
	inline Transform_t3275118058 * get_avatarContainer_10() const { return ___avatarContainer_10; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_10() { return &___avatarContainer_10; }
	inline void set_avatarContainer_10(Transform_t3275118058 * value)
	{
		___avatarContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
