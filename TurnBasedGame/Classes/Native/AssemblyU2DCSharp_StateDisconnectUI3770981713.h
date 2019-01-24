#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1043378408.h"

// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// UnityEngine.Transform
struct Transform_t3275118058;
// LoginStateUI
struct LoginStateUI_t232962672;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StateDisconnectUI
struct  StateDisconnectUI_t3770981713  : public UIBehavior_1_t1043378408
{
public:
	// RequestChangeStringUI StateDisconnectUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_6;
	// UnityEngine.Transform StateDisconnectUI::timeContainer
	Transform_t3275118058 * ___timeContainer_7;
	// LoginStateUI StateDisconnectUI::loginStatePrefab
	LoginStateUI_t232962672 * ___loginStatePrefab_8;
	// UnityEngine.Transform StateDisconnectUI::loginStateContainer
	Transform_t3275118058 * ___loginStateContainer_9;

public:
	inline static int32_t get_offset_of_requestStringPrefab_6() { return static_cast<int32_t>(offsetof(StateDisconnectUI_t3770981713, ___requestStringPrefab_6)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_6() const { return ___requestStringPrefab_6; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_6() { return &___requestStringPrefab_6; }
	inline void set_requestStringPrefab_6(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_6, value);
	}

	inline static int32_t get_offset_of_timeContainer_7() { return static_cast<int32_t>(offsetof(StateDisconnectUI_t3770981713, ___timeContainer_7)); }
	inline Transform_t3275118058 * get_timeContainer_7() const { return ___timeContainer_7; }
	inline Transform_t3275118058 ** get_address_of_timeContainer_7() { return &___timeContainer_7; }
	inline void set_timeContainer_7(Transform_t3275118058 * value)
	{
		___timeContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___timeContainer_7, value);
	}

	inline static int32_t get_offset_of_loginStatePrefab_8() { return static_cast<int32_t>(offsetof(StateDisconnectUI_t3770981713, ___loginStatePrefab_8)); }
	inline LoginStateUI_t232962672 * get_loginStatePrefab_8() const { return ___loginStatePrefab_8; }
	inline LoginStateUI_t232962672 ** get_address_of_loginStatePrefab_8() { return &___loginStatePrefab_8; }
	inline void set_loginStatePrefab_8(LoginStateUI_t232962672 * value)
	{
		___loginStatePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___loginStatePrefab_8, value);
	}

	inline static int32_t get_offset_of_loginStateContainer_9() { return static_cast<int32_t>(offsetof(StateDisconnectUI_t3770981713, ___loginStateContainer_9)); }
	inline Transform_t3275118058 * get_loginStateContainer_9() const { return ___loginStateContainer_9; }
	inline Transform_t3275118058 ** get_address_of_loginStateContainer_9() { return &___loginStateContainer_9; }
	inline void set_loginStateContainer_9(Transform_t3275118058 * value)
	{
		___loginStateContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___loginStateContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
