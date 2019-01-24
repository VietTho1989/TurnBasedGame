#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2184454820.h"

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

// AccountFacebookUI
struct  AccountFacebookUI_t1525017307  : public UIBehavior_1_t2184454820
{
public:
	// System.Boolean AccountFacebookUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject AccountFacebookUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeStringUI AccountFacebookUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_8;
	// UnityEngine.Transform AccountFacebookUI::userIdContainer
	Transform_t3275118058 * ___userIdContainer_9;
	// UnityEngine.Transform AccountFacebookUI::firstNameContainer
	Transform_t3275118058 * ___firstNameContainer_10;
	// UnityEngine.Transform AccountFacebookUI::lastNameContainer
	Transform_t3275118058 * ___lastNameContainer_11;
	// Server AccountFacebookUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_8() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___requestStringPrefab_8)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_8() const { return ___requestStringPrefab_8; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_8() { return &___requestStringPrefab_8; }
	inline void set_requestStringPrefab_8(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_8, value);
	}

	inline static int32_t get_offset_of_userIdContainer_9() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___userIdContainer_9)); }
	inline Transform_t3275118058 * get_userIdContainer_9() const { return ___userIdContainer_9; }
	inline Transform_t3275118058 ** get_address_of_userIdContainer_9() { return &___userIdContainer_9; }
	inline void set_userIdContainer_9(Transform_t3275118058 * value)
	{
		___userIdContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___userIdContainer_9, value);
	}

	inline static int32_t get_offset_of_firstNameContainer_10() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___firstNameContainer_10)); }
	inline Transform_t3275118058 * get_firstNameContainer_10() const { return ___firstNameContainer_10; }
	inline Transform_t3275118058 ** get_address_of_firstNameContainer_10() { return &___firstNameContainer_10; }
	inline void set_firstNameContainer_10(Transform_t3275118058 * value)
	{
		___firstNameContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___firstNameContainer_10, value);
	}

	inline static int32_t get_offset_of_lastNameContainer_11() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___lastNameContainer_11)); }
	inline Transform_t3275118058 * get_lastNameContainer_11() const { return ___lastNameContainer_11; }
	inline Transform_t3275118058 ** get_address_of_lastNameContainer_11() { return &___lastNameContainer_11; }
	inline void set_lastNameContainer_11(Transform_t3275118058 * value)
	{
		___lastNameContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___lastNameContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(AccountFacebookUI_t1525017307, ___server_12)); }
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
