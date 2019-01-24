#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2163448670.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChangeUseRuleRightUI
struct  ChangeUseRuleRightUI_t465923693  : public UIBehavior_1_t2163448670
{
public:
	// System.Boolean ChangeUseRuleRightUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject ChangeUseRuleRightUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform ChangeUseRuleRightUI::canChangeContainer
	Transform_t3275118058 * ___canChangeContainer_8;
	// UnityEngine.Transform ChangeUseRuleRightUI::onlyAdminContainer
	Transform_t3275118058 * ___onlyAdminContainer_9;
	// UnityEngine.Transform ChangeUseRuleRightUI::needAdminContainer
	Transform_t3275118058 * ___needAdminContainer_10;
	// UnityEngine.Transform ChangeUseRuleRightUI::needAcceptContainer
	Transform_t3275118058 * ___needAcceptContainer_11;
	// RequestChangeBoolUI ChangeUseRuleRightUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_12;
	// Server ChangeUseRuleRightUI::server
	Server_t2724320767 * ___server_13;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_canChangeContainer_8() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___canChangeContainer_8)); }
	inline Transform_t3275118058 * get_canChangeContainer_8() const { return ___canChangeContainer_8; }
	inline Transform_t3275118058 ** get_address_of_canChangeContainer_8() { return &___canChangeContainer_8; }
	inline void set_canChangeContainer_8(Transform_t3275118058 * value)
	{
		___canChangeContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___canChangeContainer_8, value);
	}

	inline static int32_t get_offset_of_onlyAdminContainer_9() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___onlyAdminContainer_9)); }
	inline Transform_t3275118058 * get_onlyAdminContainer_9() const { return ___onlyAdminContainer_9; }
	inline Transform_t3275118058 ** get_address_of_onlyAdminContainer_9() { return &___onlyAdminContainer_9; }
	inline void set_onlyAdminContainer_9(Transform_t3275118058 * value)
	{
		___onlyAdminContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___onlyAdminContainer_9, value);
	}

	inline static int32_t get_offset_of_needAdminContainer_10() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___needAdminContainer_10)); }
	inline Transform_t3275118058 * get_needAdminContainer_10() const { return ___needAdminContainer_10; }
	inline Transform_t3275118058 ** get_address_of_needAdminContainer_10() { return &___needAdminContainer_10; }
	inline void set_needAdminContainer_10(Transform_t3275118058 * value)
	{
		___needAdminContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___needAdminContainer_10, value);
	}

	inline static int32_t get_offset_of_needAcceptContainer_11() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___needAcceptContainer_11)); }
	inline Transform_t3275118058 * get_needAcceptContainer_11() const { return ___needAcceptContainer_11; }
	inline Transform_t3275118058 ** get_address_of_needAcceptContainer_11() { return &___needAcceptContainer_11; }
	inline void set_needAcceptContainer_11(Transform_t3275118058 * value)
	{
		___needAcceptContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___needAcceptContainer_11, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_12() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___requestBoolPrefab_12)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_12() const { return ___requestBoolPrefab_12; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_12() { return &___requestBoolPrefab_12; }
	inline void set_requestBoolPrefab_12(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_12, value);
	}

	inline static int32_t get_offset_of_server_13() { return static_cast<int32_t>(offsetof(ChangeUseRuleRightUI_t465923693, ___server_13)); }
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
