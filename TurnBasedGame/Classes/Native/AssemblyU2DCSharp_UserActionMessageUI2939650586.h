#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen923371185.h"

// Human
struct Human_t1156088493;
// ChatMessage
struct ChatMessage_t2384228687;
// AccountAvatarUI
struct AccountAvatarUI_t3584502088;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserActionMessageUI
struct  UserActionMessageUI_t2939650586  : public UIBehavior_1_t923371185
{
public:
	// Human UserActionMessageUI::human
	Human_t1156088493 * ___human_6;
	// ChatMessage UserActionMessageUI::chatMessage
	ChatMessage_t2384228687 * ___chatMessage_7;
	// AccountAvatarUI UserActionMessageUI::avatarPrefab
	AccountAvatarUI_t3584502088 * ___avatarPrefab_8;
	// RequestChangeStringUI UserActionMessageUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_9;
	// UnityEngine.Transform UserActionMessageUI::avatarContainer
	Transform_t3275118058 * ___avatarContainer_10;
	// UnityEngine.Transform UserActionMessageUI::contentContainer
	Transform_t3275118058 * ___contentContainer_11;
	// UnityEngine.Transform UserActionMessageUI::timeContainer
	Transform_t3275118058 * ___timeContainer_12;

public:
	inline static int32_t get_offset_of_human_6() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___human_6)); }
	inline Human_t1156088493 * get_human_6() const { return ___human_6; }
	inline Human_t1156088493 ** get_address_of_human_6() { return &___human_6; }
	inline void set_human_6(Human_t1156088493 * value)
	{
		___human_6 = value;
		Il2CppCodeGenWriteBarrier(&___human_6, value);
	}

	inline static int32_t get_offset_of_chatMessage_7() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___chatMessage_7)); }
	inline ChatMessage_t2384228687 * get_chatMessage_7() const { return ___chatMessage_7; }
	inline ChatMessage_t2384228687 ** get_address_of_chatMessage_7() { return &___chatMessage_7; }
	inline void set_chatMessage_7(ChatMessage_t2384228687 * value)
	{
		___chatMessage_7 = value;
		Il2CppCodeGenWriteBarrier(&___chatMessage_7, value);
	}

	inline static int32_t get_offset_of_avatarPrefab_8() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___avatarPrefab_8)); }
	inline AccountAvatarUI_t3584502088 * get_avatarPrefab_8() const { return ___avatarPrefab_8; }
	inline AccountAvatarUI_t3584502088 ** get_address_of_avatarPrefab_8() { return &___avatarPrefab_8; }
	inline void set_avatarPrefab_8(AccountAvatarUI_t3584502088 * value)
	{
		___avatarPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___avatarPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_9() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___requestStringPrefab_9)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_9() const { return ___requestStringPrefab_9; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_9() { return &___requestStringPrefab_9; }
	inline void set_requestStringPrefab_9(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_9, value);
	}

	inline static int32_t get_offset_of_avatarContainer_10() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___avatarContainer_10)); }
	inline Transform_t3275118058 * get_avatarContainer_10() const { return ___avatarContainer_10; }
	inline Transform_t3275118058 ** get_address_of_avatarContainer_10() { return &___avatarContainer_10; }
	inline void set_avatarContainer_10(Transform_t3275118058 * value)
	{
		___avatarContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___avatarContainer_10, value);
	}

	inline static int32_t get_offset_of_contentContainer_11() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___contentContainer_11)); }
	inline Transform_t3275118058 * get_contentContainer_11() const { return ___contentContainer_11; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_11() { return &___contentContainer_11; }
	inline void set_contentContainer_11(Transform_t3275118058 * value)
	{
		___contentContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_11, value);
	}

	inline static int32_t get_offset_of_timeContainer_12() { return static_cast<int32_t>(offsetof(UserActionMessageUI_t2939650586, ___timeContainer_12)); }
	inline Transform_t3275118058 * get_timeContainer_12() const { return ___timeContainer_12; }
	inline Transform_t3275118058 ** get_address_of_timeContainer_12() { return &___timeContainer_12; }
	inline void set_timeContainer_12(Transform_t3275118058 * value)
	{
		___timeContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___timeContainer_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
