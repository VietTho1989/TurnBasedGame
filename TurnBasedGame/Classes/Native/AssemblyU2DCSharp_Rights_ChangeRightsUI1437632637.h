#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen687257189.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// Rights.UndoRedoRightUI
struct UndoRedoRightUI_t3980360378;
// GameManager.Match.Swap.ChangeGamePlayerRightUI
struct ChangeGamePlayerRightUI_t1647758943;
// ChangeUseRuleRightUI
struct ChangeUseRuleRightUI_t465923693;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.ChangeRightsUI
struct  ChangeRightsUI_t1437632637  : public UIBehavior_1_t687257189
{
public:
	// System.Boolean Rights.ChangeRightsUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Rights.ChangeRightsUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform Rights.ChangeRightsUI::undoRedoRightContainer
	Transform_t3275118058 * ___undoRedoRightContainer_8;
	// UnityEngine.Transform Rights.ChangeRightsUI::changeGamePlayerRightContainer
	Transform_t3275118058 * ___changeGamePlayerRightContainer_9;
	// UnityEngine.Transform Rights.ChangeRightsUI::changeUseRuleRightContainer
	Transform_t3275118058 * ___changeUseRuleRightContainer_10;
	// Rights.UndoRedoRightUI Rights.ChangeRightsUI::undoRedoRightPrefab
	UndoRedoRightUI_t3980360378 * ___undoRedoRightPrefab_11;
	// GameManager.Match.Swap.ChangeGamePlayerRightUI Rights.ChangeRightsUI::changeGamePlayerRightPrefab
	ChangeGamePlayerRightUI_t1647758943 * ___changeGamePlayerRightPrefab_12;
	// ChangeUseRuleRightUI Rights.ChangeRightsUI::changeUseRuleRightPrefab
	ChangeUseRuleRightUI_t465923693 * ___changeUseRuleRightPrefab_13;
	// Server Rights.ChangeRightsUI::server
	Server_t2724320767 * ___server_14;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_undoRedoRightContainer_8() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___undoRedoRightContainer_8)); }
	inline Transform_t3275118058 * get_undoRedoRightContainer_8() const { return ___undoRedoRightContainer_8; }
	inline Transform_t3275118058 ** get_address_of_undoRedoRightContainer_8() { return &___undoRedoRightContainer_8; }
	inline void set_undoRedoRightContainer_8(Transform_t3275118058 * value)
	{
		___undoRedoRightContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRightContainer_8, value);
	}

	inline static int32_t get_offset_of_changeGamePlayerRightContainer_9() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___changeGamePlayerRightContainer_9)); }
	inline Transform_t3275118058 * get_changeGamePlayerRightContainer_9() const { return ___changeGamePlayerRightContainer_9; }
	inline Transform_t3275118058 ** get_address_of_changeGamePlayerRightContainer_9() { return &___changeGamePlayerRightContainer_9; }
	inline void set_changeGamePlayerRightContainer_9(Transform_t3275118058 * value)
	{
		___changeGamePlayerRightContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___changeGamePlayerRightContainer_9, value);
	}

	inline static int32_t get_offset_of_changeUseRuleRightContainer_10() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___changeUseRuleRightContainer_10)); }
	inline Transform_t3275118058 * get_changeUseRuleRightContainer_10() const { return ___changeUseRuleRightContainer_10; }
	inline Transform_t3275118058 ** get_address_of_changeUseRuleRightContainer_10() { return &___changeUseRuleRightContainer_10; }
	inline void set_changeUseRuleRightContainer_10(Transform_t3275118058 * value)
	{
		___changeUseRuleRightContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___changeUseRuleRightContainer_10, value);
	}

	inline static int32_t get_offset_of_undoRedoRightPrefab_11() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___undoRedoRightPrefab_11)); }
	inline UndoRedoRightUI_t3980360378 * get_undoRedoRightPrefab_11() const { return ___undoRedoRightPrefab_11; }
	inline UndoRedoRightUI_t3980360378 ** get_address_of_undoRedoRightPrefab_11() { return &___undoRedoRightPrefab_11; }
	inline void set_undoRedoRightPrefab_11(UndoRedoRightUI_t3980360378 * value)
	{
		___undoRedoRightPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___undoRedoRightPrefab_11, value);
	}

	inline static int32_t get_offset_of_changeGamePlayerRightPrefab_12() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___changeGamePlayerRightPrefab_12)); }
	inline ChangeGamePlayerRightUI_t1647758943 * get_changeGamePlayerRightPrefab_12() const { return ___changeGamePlayerRightPrefab_12; }
	inline ChangeGamePlayerRightUI_t1647758943 ** get_address_of_changeGamePlayerRightPrefab_12() { return &___changeGamePlayerRightPrefab_12; }
	inline void set_changeGamePlayerRightPrefab_12(ChangeGamePlayerRightUI_t1647758943 * value)
	{
		___changeGamePlayerRightPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___changeGamePlayerRightPrefab_12, value);
	}

	inline static int32_t get_offset_of_changeUseRuleRightPrefab_13() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___changeUseRuleRightPrefab_13)); }
	inline ChangeUseRuleRightUI_t465923693 * get_changeUseRuleRightPrefab_13() const { return ___changeUseRuleRightPrefab_13; }
	inline ChangeUseRuleRightUI_t465923693 ** get_address_of_changeUseRuleRightPrefab_13() { return &___changeUseRuleRightPrefab_13; }
	inline void set_changeUseRuleRightPrefab_13(ChangeUseRuleRightUI_t465923693 * value)
	{
		___changeUseRuleRightPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___changeUseRuleRightPrefab_13, value);
	}

	inline static int32_t get_offset_of_server_14() { return static_cast<int32_t>(offsetof(ChangeRightsUI_t1437632637, ___server_14)); }
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
