#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4251466310.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// ComputerAvatarUI
struct ComputerAvatarUI_t2672989554;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// AIUI
struct AIUI_t2407226900;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ComputerUI
struct  ComputerUI_t1250452161  : public UIBehavior_1_t4251466310
{
public:
	// System.Boolean ComputerUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject ComputerUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// ComputerAvatarUI ComputerUI::computerAvatarPrefab
	ComputerAvatarUI_t2672989554 * ___computerAvatarPrefab_8;
	// UnityEngine.Transform ComputerUI::computerAvatarContainer
	Transform_t3275118058 * ___computerAvatarContainer_9;
	// UnityEngine.Transform ComputerUI::nameContainer
	Transform_t3275118058 * ___nameContainer_10;
	// UnityEngine.Transform ComputerUI::avatarUrlContainer
	Transform_t3275118058 * ___avatarUrlContainer_11;
	// RequestChangeStringUI ComputerUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_12;
	// AIUI ComputerUI::aiUIPrefab
	AIUI_t2407226900 * ___aiUIPrefab_13;
	// UnityEngine.Transform ComputerUI::aiUIContainer
	Transform_t3275118058 * ___aiUIContainer_14;
	// Server ComputerUI::server
	Server_t2724320767 * ___server_15;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_computerAvatarPrefab_8() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___computerAvatarPrefab_8)); }
	inline ComputerAvatarUI_t2672989554 * get_computerAvatarPrefab_8() const { return ___computerAvatarPrefab_8; }
	inline ComputerAvatarUI_t2672989554 ** get_address_of_computerAvatarPrefab_8() { return &___computerAvatarPrefab_8; }
	inline void set_computerAvatarPrefab_8(ComputerAvatarUI_t2672989554 * value)
	{
		___computerAvatarPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___computerAvatarPrefab_8, value);
	}

	inline static int32_t get_offset_of_computerAvatarContainer_9() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___computerAvatarContainer_9)); }
	inline Transform_t3275118058 * get_computerAvatarContainer_9() const { return ___computerAvatarContainer_9; }
	inline Transform_t3275118058 ** get_address_of_computerAvatarContainer_9() { return &___computerAvatarContainer_9; }
	inline void set_computerAvatarContainer_9(Transform_t3275118058 * value)
	{
		___computerAvatarContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___computerAvatarContainer_9, value);
	}

	inline static int32_t get_offset_of_nameContainer_10() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___nameContainer_10)); }
	inline Transform_t3275118058 * get_nameContainer_10() const { return ___nameContainer_10; }
	inline Transform_t3275118058 ** get_address_of_nameContainer_10() { return &___nameContainer_10; }
	inline void set_nameContainer_10(Transform_t3275118058 * value)
	{
		___nameContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___nameContainer_10, value);
	}

	inline static int32_t get_offset_of_avatarUrlContainer_11() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___avatarUrlContainer_11)); }
	inline Transform_t3275118058 * get_avatarUrlContainer_11() const { return ___avatarUrlContainer_11; }
	inline Transform_t3275118058 ** get_address_of_avatarUrlContainer_11() { return &___avatarUrlContainer_11; }
	inline void set_avatarUrlContainer_11(Transform_t3275118058 * value)
	{
		___avatarUrlContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrlContainer_11, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_12() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___requestStringPrefab_12)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_12() const { return ___requestStringPrefab_12; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_12() { return &___requestStringPrefab_12; }
	inline void set_requestStringPrefab_12(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_12, value);
	}

	inline static int32_t get_offset_of_aiUIPrefab_13() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___aiUIPrefab_13)); }
	inline AIUI_t2407226900 * get_aiUIPrefab_13() const { return ___aiUIPrefab_13; }
	inline AIUI_t2407226900 ** get_address_of_aiUIPrefab_13() { return &___aiUIPrefab_13; }
	inline void set_aiUIPrefab_13(AIUI_t2407226900 * value)
	{
		___aiUIPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___aiUIPrefab_13, value);
	}

	inline static int32_t get_offset_of_aiUIContainer_14() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___aiUIContainer_14)); }
	inline Transform_t3275118058 * get_aiUIContainer_14() const { return ___aiUIContainer_14; }
	inline Transform_t3275118058 ** get_address_of_aiUIContainer_14() { return &___aiUIContainer_14; }
	inline void set_aiUIContainer_14(Transform_t3275118058 * value)
	{
		___aiUIContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___aiUIContainer_14, value);
	}

	inline static int32_t get_offset_of_server_15() { return static_cast<int32_t>(offsetof(ComputerUI_t1250452161, ___server_15)); }
	inline Server_t2724320767 * get_server_15() const { return ___server_15; }
	inline Server_t2724320767 ** get_address_of_server_15() { return &___server_15; }
	inline void set_server_15(Server_t2724320767 * value)
	{
		___server_15 = value;
		Il2CppCodeGenWriteBarrier(&___server_15, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
