#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3243751288.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
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

// CreateRoomUI
struct  CreateRoomUI_t2106253281  : public UIBehavior_1_t3243751288
{
public:
	// System.Boolean CreateRoomUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject CreateRoomUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeEnumUI CreateRoomUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_8;
	// RequestChangeStringUI CreateRoomUI::requestStringPrefab
	RequestChangeStringUI_t3074934670 * ___requestStringPrefab_9;
	// UnityEngine.Transform CreateRoomUI::gameTypeContainer
	Transform_t3275118058 * ___gameTypeContainer_10;
	// UnityEngine.Transform CreateRoomUI::roomNameContainer
	Transform_t3275118058 * ___roomNameContainer_11;
	// UnityEngine.Transform CreateRoomUI::passwordContainer
	Transform_t3275118058 * ___passwordContainer_12;
	// Server CreateRoomUI::server
	Server_t2724320767 * ___server_13;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_8() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___requestEnumPrefab_8)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_8() const { return ___requestEnumPrefab_8; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_8() { return &___requestEnumPrefab_8; }
	inline void set_requestEnumPrefab_8(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestStringPrefab_9() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___requestStringPrefab_9)); }
	inline RequestChangeStringUI_t3074934670 * get_requestStringPrefab_9() const { return ___requestStringPrefab_9; }
	inline RequestChangeStringUI_t3074934670 ** get_address_of_requestStringPrefab_9() { return &___requestStringPrefab_9; }
	inline void set_requestStringPrefab_9(RequestChangeStringUI_t3074934670 * value)
	{
		___requestStringPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestStringPrefab_9, value);
	}

	inline static int32_t get_offset_of_gameTypeContainer_10() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___gameTypeContainer_10)); }
	inline Transform_t3275118058 * get_gameTypeContainer_10() const { return ___gameTypeContainer_10; }
	inline Transform_t3275118058 ** get_address_of_gameTypeContainer_10() { return &___gameTypeContainer_10; }
	inline void set_gameTypeContainer_10(Transform_t3275118058 * value)
	{
		___gameTypeContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___gameTypeContainer_10, value);
	}

	inline static int32_t get_offset_of_roomNameContainer_11() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___roomNameContainer_11)); }
	inline Transform_t3275118058 * get_roomNameContainer_11() const { return ___roomNameContainer_11; }
	inline Transform_t3275118058 ** get_address_of_roomNameContainer_11() { return &___roomNameContainer_11; }
	inline void set_roomNameContainer_11(Transform_t3275118058 * value)
	{
		___roomNameContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___roomNameContainer_11, value);
	}

	inline static int32_t get_offset_of_passwordContainer_12() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___passwordContainer_12)); }
	inline Transform_t3275118058 * get_passwordContainer_12() const { return ___passwordContainer_12; }
	inline Transform_t3275118058 ** get_address_of_passwordContainer_12() { return &___passwordContainer_12; }
	inline void set_passwordContainer_12(Transform_t3275118058 * value)
	{
		___passwordContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___passwordContainer_12, value);
	}

	inline static int32_t get_offset_of_server_13() { return static_cast<int32_t>(offsetof(CreateRoomUI_t2106253281, ___server_13)); }
	inline Server_t2724320767 * get_server_13() const { return ___server_13; }
	inline Server_t2724320767 ** get_address_of_server_13() { return &___server_13; }
	inline void set_server_13(Server_t2724320767 * value)
	{
		___server_13 = value;
		Il2CppCodeGenWriteBarrier(&___server_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
