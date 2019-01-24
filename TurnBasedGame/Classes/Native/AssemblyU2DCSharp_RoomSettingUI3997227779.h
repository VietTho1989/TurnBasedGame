#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1947703266.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeStringUI
struct RequestChangeStringUI_t3074934670;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// Rights.ChangeRightsUI
struct ChangeRightsUI_t1437632637;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomSettingUI
struct  RoomSettingUI_t3997227779  : public UIBehavior_1_t1947703266
{
public:
	// System.Boolean RoomSettingUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject RoomSettingUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeStringUI RoomSettingUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_8;
	// RequestChangeEnumUI RoomSettingUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_9;
	// Rights.ChangeRightsUI RoomSettingUI::changeRightsPrefab
	ChangeRightsUI_t1437632637 * ___changeRightsPrefab_10;
	// UnityEngine.Transform RoomSettingUI::nameContainer
	Transform_t3275118058 * ___nameContainer_11;
	// UnityEngine.Transform RoomSettingUI::allowHintContainer
	Transform_t3275118058 * ___allowHintContainer_12;
	// UnityEngine.Transform RoomSettingUI::changeRightsContainer
	Transform_t3275118058 * ___changeRightsContainer_13;
	// Server RoomSettingUI::server
	Server_t2724320767 * ___server_14;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_8() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___requestStringPrefab_8)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_8() const { return ___requestStringPrefab_8; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_8() { return &___requestStringPrefab_8; }
	inline void set_requestStringPrefab_8(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_9() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___requestEnumPrefab_9)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_9() const { return ___requestEnumPrefab_9; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_9() { return &___requestEnumPrefab_9; }
	inline void set_requestEnumPrefab_9(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_9, value);
	}

	inline static int32_t get_offset_of_changeRightsPrefab_10() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___changeRightsPrefab_10)); }
	inline ChangeRightsUI_t1437632637 * get_changeRightsPrefab_10() const { return ___changeRightsPrefab_10; }
	inline ChangeRightsUI_t1437632637 ** get_address_of_changeRightsPrefab_10() { return &___changeRightsPrefab_10; }
	inline void set_changeRightsPrefab_10(ChangeRightsUI_t1437632637 * value)
	{
		___changeRightsPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___changeRightsPrefab_10, value);
	}

	inline static int32_t get_offset_of_nameContainer_11() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___nameContainer_11)); }
	inline Transform_t3275118058 * get_nameContainer_11() const { return ___nameContainer_11; }
	inline Transform_t3275118058 ** get_address_of_nameContainer_11() { return &___nameContainer_11; }
	inline void set_nameContainer_11(Transform_t3275118058 * value)
	{
		___nameContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___nameContainer_11, value);
	}

	inline static int32_t get_offset_of_allowHintContainer_12() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___allowHintContainer_12)); }
	inline Transform_t3275118058 * get_allowHintContainer_12() const { return ___allowHintContainer_12; }
	inline Transform_t3275118058 ** get_address_of_allowHintContainer_12() { return &___allowHintContainer_12; }
	inline void set_allowHintContainer_12(Transform_t3275118058 * value)
	{
		___allowHintContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___allowHintContainer_12, value);
	}

	inline static int32_t get_offset_of_changeRightsContainer_13() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___changeRightsContainer_13)); }
	inline Transform_t3275118058 * get_changeRightsContainer_13() const { return ___changeRightsContainer_13; }
	inline Transform_t3275118058 ** get_address_of_changeRightsContainer_13() { return &___changeRightsContainer_13; }
	inline void set_changeRightsContainer_13(Transform_t3275118058 * value)
	{
		___changeRightsContainer_13 = value;
		Il2CppCodeGenWriteBarrier(&___changeRightsContainer_13, value);
	}

	inline static int32_t get_offset_of_server_14() { return static_cast<int32_t>(offsetof(RoomSettingUI_t3997227779, ___server_14)); }
	inline Server_t2724320767 * get_server_14() const { return ___server_14; }
	inline Server_t2724320767 ** get_address_of_server_14() { return &___server_14; }
	inline void set_server_14(Server_t2724320767 * value)
	{
		___server_14 = value;
		Il2CppCodeGenWriteBarrier(&___server_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
