#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2286099219.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountAdminUI
struct  AccountAdminUI_t151041060  : public UIBehavior_1_t2286099219
{
public:
	// System.Boolean AccountAdminUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject AccountAdminUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeStringUI AccountAdminUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_8;
	// UnityEngine.Transform AccountAdminUI::customNameContainer
	Transform_t3275118058 * ___customNameContainer_9;
	// UnityEngine.Transform AccountAdminUI::avatarUrlContainer
	Transform_t3275118058 * ___avatarUrlContainer_10;
	// Server AccountAdminUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_8() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___requestStringPrefab_8)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_8() const { return ___requestStringPrefab_8; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_8() { return &___requestStringPrefab_8; }
	inline void set_requestStringPrefab_8(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_8, value);
	}

	inline static int32_t get_offset_of_customNameContainer_9() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___customNameContainer_9)); }
	inline Transform_t3275118058 * get_customNameContainer_9() const { return ___customNameContainer_9; }
	inline Transform_t3275118058 ** get_address_of_customNameContainer_9() { return &___customNameContainer_9; }
	inline void set_customNameContainer_9(Transform_t3275118058 * value)
	{
		___customNameContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___customNameContainer_9, value);
	}

	inline static int32_t get_offset_of_avatarUrlContainer_10() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___avatarUrlContainer_10)); }
	inline Transform_t3275118058 * get_avatarUrlContainer_10() const { return ___avatarUrlContainer_10; }
	inline Transform_t3275118058 ** get_address_of_avatarUrlContainer_10() { return &___avatarUrlContainer_10; }
	inline void set_avatarUrlContainer_10(Transform_t3275118058 * value)
	{
		___avatarUrlContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrlContainer_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(AccountAdminUI_t151041060, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
