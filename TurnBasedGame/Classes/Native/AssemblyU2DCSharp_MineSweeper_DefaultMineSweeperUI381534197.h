#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen787941302.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.DefaultMineSweeperUI
struct  DefaultMineSweeperUI_t381534197  : public UIBehavior_1_t787941302
{
public:
	// System.Boolean MineSweeper.DefaultMineSweeperUI::needReset
	bool ___needReset_6;
	// System.Boolean MineSweeper.DefaultMineSweeperUI::miniGameDataDirty
	bool ___miniGameDataDirty_7;
	// UnityEngine.GameObject MineSweeper.DefaultMineSweeperUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;
	// MiniGameDataUI MineSweeper.DefaultMineSweeperUI::miniGameDataUIPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataUIPrefab_9;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_10;
	// RequestChangeIntUI MineSweeper.DefaultMineSweeperUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_11;
	// RequestChangeFloatUI MineSweeper.DefaultMineSweeperUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_12;
	// RequestChangeBoolUI MineSweeper.DefaultMineSweeperUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_13;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::NContainer
	Transform_t3275118058 * ___NContainer_14;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::MContainer
	Transform_t3275118058 * ___MContainer_15;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::minKContainer
	Transform_t3275118058 * ___minKContainer_16;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::maxKContainer
	Transform_t3275118058 * ___maxKContainer_17;
	// UnityEngine.Transform MineSweeper.DefaultMineSweeperUI::allowWatchBombContainer
	Transform_t3275118058 * ___allowWatchBombContainer_18;
	// Server MineSweeper.DefaultMineSweeperUI::server
	Server_t2724320767 * ___server_19;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_miniGameDataDirty_7() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___miniGameDataDirty_7)); }
	inline bool get_miniGameDataDirty_7() const { return ___miniGameDataDirty_7; }
	inline bool* get_address_of_miniGameDataDirty_7() { return &___miniGameDataDirty_7; }
	inline void set_miniGameDataDirty_7(bool value)
	{
		___miniGameDataDirty_7 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIPrefab_9() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___miniGameDataUIPrefab_9)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataUIPrefab_9() const { return ___miniGameDataUIPrefab_9; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataUIPrefab_9() { return &___miniGameDataUIPrefab_9; }
	inline void set_miniGameDataUIPrefab_9(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataUIPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIPrefab_9, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_10() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___miniGameDataUIContainer_10)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_10() const { return ___miniGameDataUIContainer_10; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_10() { return &___miniGameDataUIContainer_10; }
	inline void set_miniGameDataUIContainer_10(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_10, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_11() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___requestIntPrefab_11)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_11() const { return ___requestIntPrefab_11; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_11() { return &___requestIntPrefab_11; }
	inline void set_requestIntPrefab_11(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_11, value);
	}

	inline static int32_t get_offset_of_requestFloatPrefab_12() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___requestFloatPrefab_12)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_12() const { return ___requestFloatPrefab_12; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_12() { return &___requestFloatPrefab_12; }
	inline void set_requestFloatPrefab_12(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_12 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_12, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_13() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___requestBoolPrefab_13)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_13() const { return ___requestBoolPrefab_13; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_13() { return &___requestBoolPrefab_13; }
	inline void set_requestBoolPrefab_13(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_13, value);
	}

	inline static int32_t get_offset_of_NContainer_14() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___NContainer_14)); }
	inline Transform_t3275118058 * get_NContainer_14() const { return ___NContainer_14; }
	inline Transform_t3275118058 ** get_address_of_NContainer_14() { return &___NContainer_14; }
	inline void set_NContainer_14(Transform_t3275118058 * value)
	{
		___NContainer_14 = value;
		Il2CppCodeGenWriteBarrier(&___NContainer_14, value);
	}

	inline static int32_t get_offset_of_MContainer_15() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___MContainer_15)); }
	inline Transform_t3275118058 * get_MContainer_15() const { return ___MContainer_15; }
	inline Transform_t3275118058 ** get_address_of_MContainer_15() { return &___MContainer_15; }
	inline void set_MContainer_15(Transform_t3275118058 * value)
	{
		___MContainer_15 = value;
		Il2CppCodeGenWriteBarrier(&___MContainer_15, value);
	}

	inline static int32_t get_offset_of_minKContainer_16() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___minKContainer_16)); }
	inline Transform_t3275118058 * get_minKContainer_16() const { return ___minKContainer_16; }
	inline Transform_t3275118058 ** get_address_of_minKContainer_16() { return &___minKContainer_16; }
	inline void set_minKContainer_16(Transform_t3275118058 * value)
	{
		___minKContainer_16 = value;
		Il2CppCodeGenWriteBarrier(&___minKContainer_16, value);
	}

	inline static int32_t get_offset_of_maxKContainer_17() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___maxKContainer_17)); }
	inline Transform_t3275118058 * get_maxKContainer_17() const { return ___maxKContainer_17; }
	inline Transform_t3275118058 ** get_address_of_maxKContainer_17() { return &___maxKContainer_17; }
	inline void set_maxKContainer_17(Transform_t3275118058 * value)
	{
		___maxKContainer_17 = value;
		Il2CppCodeGenWriteBarrier(&___maxKContainer_17, value);
	}

	inline static int32_t get_offset_of_allowWatchBombContainer_18() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___allowWatchBombContainer_18)); }
	inline Transform_t3275118058 * get_allowWatchBombContainer_18() const { return ___allowWatchBombContainer_18; }
	inline Transform_t3275118058 ** get_address_of_allowWatchBombContainer_18() { return &___allowWatchBombContainer_18; }
	inline void set_allowWatchBombContainer_18(Transform_t3275118058 * value)
	{
		___allowWatchBombContainer_18 = value;
		Il2CppCodeGenWriteBarrier(&___allowWatchBombContainer_18, value);
	}

	inline static int32_t get_offset_of_server_19() { return static_cast<int32_t>(offsetof(DefaultMineSweeperUI_t381534197, ___server_19)); }
	inline Server_t2724320767 * get_server_19() const { return ___server_19; }
	inline Server_t2724320767 ** get_address_of_server_19() { return &___server_19; }
	inline void set_server_19(Server_t2724320767 * value)
	{
		___server_19 = value;
		Il2CppCodeGenWriteBarrier(&___server_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
