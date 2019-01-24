#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1751099883.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.MineSweeperAIUI
struct  MineSweeperAIUI_t3008992632  : public UIBehavior_1_t1751099883
{
public:
	// System.Boolean MineSweeper.MineSweeperAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject MineSweeper.MineSweeperAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeEnumUI MineSweeper.MineSweeperAIUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_8;
	// UnityEngine.Transform MineSweeper.MineSweeperAIUI::firstMoveTypeContainer
	Transform_t3275118058 * ___firstMoveTypeContainer_9;
	// Server MineSweeper.MineSweeperAIUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(MineSweeperAIUI_t3008992632, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(MineSweeperAIUI_t3008992632, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_8() { return static_cast<int32_t>(offsetof(MineSweeperAIUI_t3008992632, ___requestEnumPrefab_8)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_8() const { return ___requestEnumPrefab_8; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_8() { return &___requestEnumPrefab_8; }
	inline void set_requestEnumPrefab_8(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_8, value);
	}

	inline static int32_t get_offset_of_firstMoveTypeContainer_9() { return static_cast<int32_t>(offsetof(MineSweeperAIUI_t3008992632, ___firstMoveTypeContainer_9)); }
	inline Transform_t3275118058 * get_firstMoveTypeContainer_9() const { return ___firstMoveTypeContainer_9; }
	inline Transform_t3275118058 ** get_address_of_firstMoveTypeContainer_9() { return &___firstMoveTypeContainer_9; }
	inline void set_firstMoveTypeContainer_9(Transform_t3275118058 * value)
	{
		___firstMoveTypeContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___firstMoveTypeContainer_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(MineSweeperAIUI_t3008992632, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
