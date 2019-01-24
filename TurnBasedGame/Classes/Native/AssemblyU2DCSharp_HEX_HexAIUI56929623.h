#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3519462955.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexAIUI
struct  HexAIUI_t56929623  : public UIBehavior_1_t3519462955
{
public:
	// System.Boolean HEX.HexAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject HEX.HexAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform HEX.HexAIUI::limitTimeContainer
	Transform_t3275118058 * ___limitTimeContainer_8;
	// UnityEngine.Transform HEX.HexAIUI::firstMoveCenterContainer
	Transform_t3275118058 * ___firstMoveCenterContainer_9;
	// RequestChangeIntUI HEX.HexAIUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_10;
	// RequestChangeBoolUI HEX.HexAIUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_11;
	// Server HEX.HexAIUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_limitTimeContainer_8() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___limitTimeContainer_8)); }
	inline Transform_t3275118058 * get_limitTimeContainer_8() const { return ___limitTimeContainer_8; }
	inline Transform_t3275118058 ** get_address_of_limitTimeContainer_8() { return &___limitTimeContainer_8; }
	inline void set_limitTimeContainer_8(Transform_t3275118058 * value)
	{
		___limitTimeContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___limitTimeContainer_8, value);
	}

	inline static int32_t get_offset_of_firstMoveCenterContainer_9() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___firstMoveCenterContainer_9)); }
	inline Transform_t3275118058 * get_firstMoveCenterContainer_9() const { return ___firstMoveCenterContainer_9; }
	inline Transform_t3275118058 ** get_address_of_firstMoveCenterContainer_9() { return &___firstMoveCenterContainer_9; }
	inline void set_firstMoveCenterContainer_9(Transform_t3275118058 * value)
	{
		___firstMoveCenterContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___firstMoveCenterContainer_9, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_10() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___requestIntPrefab_10)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_10() const { return ___requestIntPrefab_10; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_10() { return &___requestIntPrefab_10; }
	inline void set_requestIntPrefab_10(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_10, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_11() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___requestBoolPrefab_11)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_11() const { return ___requestBoolPrefab_11; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_11() { return &___requestBoolPrefab_11; }
	inline void set_requestBoolPrefab_11(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(HexAIUI_t56929623, ___server_12)); }
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
