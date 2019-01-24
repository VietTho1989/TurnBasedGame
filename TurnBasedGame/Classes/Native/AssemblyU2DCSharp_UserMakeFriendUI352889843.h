#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3702521226.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;
// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// FriendStateUI
struct FriendStateUI_t2246718195;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserMakeFriendUI
struct  UserMakeFriendUI_t352889843  : public UIBehavior_1_t3702521226
{
public:
	// UnityEngine.GameObject UserMakeFriendUI::yourInform
	GameObject_t1756533147 * ___yourInform_6;
	// UnityEngine.UI.Button UserMakeFriendUI::btnMakeFriend
	Button_t2872111280 * ___btnMakeFriend_7;
	// UnityEngine.UI.Text UserMakeFriendUI::tvMakeFriend
	Text_t356221433 * ___tvMakeFriend_8;
	// AdvancedCoroutines.Routine UserMakeFriendUI::wait
	Routine_t2502590640 * ___wait_9;
	// FriendStateUI UserMakeFriendUI::friendStatePrefab
	FriendStateUI_t2246718195 * ___friendStatePrefab_10;
	// UnityEngine.Transform UserMakeFriendUI::friendStateContainer
	Transform_t3275118058 * ___friendStateContainer_11;
	// Server UserMakeFriendUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_yourInform_6() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___yourInform_6)); }
	inline GameObject_t1756533147 * get_yourInform_6() const { return ___yourInform_6; }
	inline GameObject_t1756533147 ** get_address_of_yourInform_6() { return &___yourInform_6; }
	inline void set_yourInform_6(GameObject_t1756533147 * value)
	{
		___yourInform_6 = value;
		Il2CppCodeGenWriteBarrier(&___yourInform_6, value);
	}

	inline static int32_t get_offset_of_btnMakeFriend_7() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___btnMakeFriend_7)); }
	inline Button_t2872111280 * get_btnMakeFriend_7() const { return ___btnMakeFriend_7; }
	inline Button_t2872111280 ** get_address_of_btnMakeFriend_7() { return &___btnMakeFriend_7; }
	inline void set_btnMakeFriend_7(Button_t2872111280 * value)
	{
		___btnMakeFriend_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnMakeFriend_7, value);
	}

	inline static int32_t get_offset_of_tvMakeFriend_8() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___tvMakeFriend_8)); }
	inline Text_t356221433 * get_tvMakeFriend_8() const { return ___tvMakeFriend_8; }
	inline Text_t356221433 ** get_address_of_tvMakeFriend_8() { return &___tvMakeFriend_8; }
	inline void set_tvMakeFriend_8(Text_t356221433 * value)
	{
		___tvMakeFriend_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvMakeFriend_8, value);
	}

	inline static int32_t get_offset_of_wait_9() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___wait_9)); }
	inline Routine_t2502590640 * get_wait_9() const { return ___wait_9; }
	inline Routine_t2502590640 ** get_address_of_wait_9() { return &___wait_9; }
	inline void set_wait_9(Routine_t2502590640 * value)
	{
		___wait_9 = value;
		Il2CppCodeGenWriteBarrier(&___wait_9, value);
	}

	inline static int32_t get_offset_of_friendStatePrefab_10() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___friendStatePrefab_10)); }
	inline FriendStateUI_t2246718195 * get_friendStatePrefab_10() const { return ___friendStatePrefab_10; }
	inline FriendStateUI_t2246718195 ** get_address_of_friendStatePrefab_10() { return &___friendStatePrefab_10; }
	inline void set_friendStatePrefab_10(FriendStateUI_t2246718195 * value)
	{
		___friendStatePrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___friendStatePrefab_10, value);
	}

	inline static int32_t get_offset_of_friendStateContainer_11() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___friendStateContainer_11)); }
	inline Transform_t3275118058 * get_friendStateContainer_11() const { return ___friendStateContainer_11; }
	inline Transform_t3275118058 ** get_address_of_friendStateContainer_11() { return &___friendStateContainer_11; }
	inline void set_friendStateContainer_11(Transform_t3275118058 * value)
	{
		___friendStateContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___friendStateContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(UserMakeFriendUI_t352889843, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
