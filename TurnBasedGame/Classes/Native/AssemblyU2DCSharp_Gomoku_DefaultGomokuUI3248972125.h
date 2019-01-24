#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2517074736.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.DefaultGomokuUI
struct  DefaultGomokuUI_t3248972125  : public UIBehavior_1_t2517074736
{
public:
	// System.Boolean Gomoku.DefaultGomokuUI::needReset
	bool ___needReset_6;
	// System.Boolean Gomoku.DefaultGomokuUI::miniGameDataDirty
	bool ___miniGameDataDirty_7;
	// UnityEngine.GameObject Gomoku.DefaultGomokuUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;
	// MiniGameDataUI Gomoku.DefaultGomokuUI::miniGameDataUIPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataUIPrefab_9;
	// UnityEngine.Transform Gomoku.DefaultGomokuUI::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_10;
	// RequestChangeIntUI Gomoku.DefaultGomokuUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_11;
	// UnityEngine.Transform Gomoku.DefaultGomokuUI::boardSizeContainer
	Transform_t3275118058 * ___boardSizeContainer_12;
	// Server Gomoku.DefaultGomokuUI::server
	Server_t2724320767 * ___server_13;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_miniGameDataDirty_7() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___miniGameDataDirty_7)); }
	inline bool get_miniGameDataDirty_7() const { return ___miniGameDataDirty_7; }
	inline bool* get_address_of_miniGameDataDirty_7() { return &___miniGameDataDirty_7; }
	inline void set_miniGameDataDirty_7(bool value)
	{
		___miniGameDataDirty_7 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIPrefab_9() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___miniGameDataUIPrefab_9)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataUIPrefab_9() const { return ___miniGameDataUIPrefab_9; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataUIPrefab_9() { return &___miniGameDataUIPrefab_9; }
	inline void set_miniGameDataUIPrefab_9(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataUIPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIPrefab_9, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_10() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___miniGameDataUIContainer_10)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_10() const { return ___miniGameDataUIContainer_10; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_10() { return &___miniGameDataUIContainer_10; }
	inline void set_miniGameDataUIContainer_10(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_10, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_11() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___requestIntPrefab_11)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_11() const { return ___requestIntPrefab_11; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_11() { return &___requestIntPrefab_11; }
	inline void set_requestIntPrefab_11(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_11, value);
	}

	inline static int32_t get_offset_of_boardSizeContainer_12() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___boardSizeContainer_12)); }
	inline Transform_t3275118058 * get_boardSizeContainer_12() const { return ___boardSizeContainer_12; }
	inline Transform_t3275118058 ** get_address_of_boardSizeContainer_12() { return &___boardSizeContainer_12; }
	inline void set_boardSizeContainer_12(Transform_t3275118058 * value)
	{
		___boardSizeContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___boardSizeContainer_12, value);
	}

	inline static int32_t get_offset_of_server_13() { return static_cast<int32_t>(offsetof(DefaultGomokuUI_t3248972125, ___server_13)); }
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
