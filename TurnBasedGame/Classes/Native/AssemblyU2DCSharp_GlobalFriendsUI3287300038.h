#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1380971939.h"

// FriendAdapter
struct FriendAdapter_t3334636495;
// UnityEngine.Transform
struct Transform_t3275118058;
// FriendDetailUI
struct FriendDetailUI_t4036636645;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GlobalFriendsUI
struct  GlobalFriendsUI_t3287300038  : public UIBehavior_1_t1380971939
{
public:
	// FriendAdapter GlobalFriendsUI::friendAdapterPrefab
	FriendAdapter_t3334636495 * ___friendAdapterPrefab_6;
	// UnityEngine.Transform GlobalFriendsUI::friendAdapterContainer
	Transform_t3275118058 * ___friendAdapterContainer_7;
	// FriendDetailUI GlobalFriendsUI::friendDetailPrefab
	FriendDetailUI_t4036636645 * ___friendDetailPrefab_8;
	// UnityEngine.Transform GlobalFriendsUI::friendDetailContainer
	Transform_t3275118058 * ___friendDetailContainer_9;

public:
	inline static int32_t get_offset_of_friendAdapterPrefab_6() { return static_cast<int32_t>(offsetof(GlobalFriendsUI_t3287300038, ___friendAdapterPrefab_6)); }
	inline FriendAdapter_t3334636495 * get_friendAdapterPrefab_6() const { return ___friendAdapterPrefab_6; }
	inline FriendAdapter_t3334636495 ** get_address_of_friendAdapterPrefab_6() { return &___friendAdapterPrefab_6; }
	inline void set_friendAdapterPrefab_6(FriendAdapter_t3334636495 * value)
	{
		___friendAdapterPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___friendAdapterPrefab_6, value);
	}

	inline static int32_t get_offset_of_friendAdapterContainer_7() { return static_cast<int32_t>(offsetof(GlobalFriendsUI_t3287300038, ___friendAdapterContainer_7)); }
	inline Transform_t3275118058 * get_friendAdapterContainer_7() const { return ___friendAdapterContainer_7; }
	inline Transform_t3275118058 ** get_address_of_friendAdapterContainer_7() { return &___friendAdapterContainer_7; }
	inline void set_friendAdapterContainer_7(Transform_t3275118058 * value)
	{
		___friendAdapterContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___friendAdapterContainer_7, value);
	}

	inline static int32_t get_offset_of_friendDetailPrefab_8() { return static_cast<int32_t>(offsetof(GlobalFriendsUI_t3287300038, ___friendDetailPrefab_8)); }
	inline FriendDetailUI_t4036636645 * get_friendDetailPrefab_8() const { return ___friendDetailPrefab_8; }
	inline FriendDetailUI_t4036636645 ** get_address_of_friendDetailPrefab_8() { return &___friendDetailPrefab_8; }
	inline void set_friendDetailPrefab_8(FriendDetailUI_t4036636645 * value)
	{
		___friendDetailPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___friendDetailPrefab_8, value);
	}

	inline static int32_t get_offset_of_friendDetailContainer_9() { return static_cast<int32_t>(offsetof(GlobalFriendsUI_t3287300038, ___friendDetailContainer_9)); }
	inline Transform_t3275118058 * get_friendDetailContainer_9() const { return ___friendDetailContainer_9; }
	inline Transform_t3275118058 ** get_address_of_friendDetailContainer_9() { return &___friendDetailContainer_9; }
	inline void set_friendDetailContainer_9(Transform_t3275118058 * value)
	{
		___friendDetailContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___friendDetailContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
