#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2229124966.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.DefaultShogiUI
struct  DefaultShogiUI_t3971775599  : public UIBehavior_1_t2229124966
{
public:
	// System.Boolean Shogi.DefaultShogiUI::needReset
	bool ___needReset_6;
	// System.Boolean Shogi.DefaultShogiUI::miniGameDataDirty
	bool ___miniGameDataDirty_7;
	// UnityEngine.GameObject Shogi.DefaultShogiUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;
	// MiniGameDataUI Shogi.DefaultShogiUI::miniGameDataUIPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataUIPrefab_9;
	// UnityEngine.Transform Shogi.DefaultShogiUI::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_10;
	// Server Shogi.DefaultShogiUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_miniGameDataDirty_7() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___miniGameDataDirty_7)); }
	inline bool get_miniGameDataDirty_7() const { return ___miniGameDataDirty_7; }
	inline bool* get_address_of_miniGameDataDirty_7() { return &___miniGameDataDirty_7; }
	inline void set_miniGameDataDirty_7(bool value)
	{
		___miniGameDataDirty_7 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIPrefab_9() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___miniGameDataUIPrefab_9)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataUIPrefab_9() const { return ___miniGameDataUIPrefab_9; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataUIPrefab_9() { return &___miniGameDataUIPrefab_9; }
	inline void set_miniGameDataUIPrefab_9(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataUIPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIPrefab_9, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_10() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___miniGameDataUIContainer_10)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_10() const { return ___miniGameDataUIContainer_10; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_10() { return &___miniGameDataUIContainer_10; }
	inline void set_miniGameDataUIContainer_10(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(DefaultShogiUI_t3971775599, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
