#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3175349520.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// MiniGameDataUI
struct MiniGameDataUI_t29488987;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeEnumUI
struct RequestChangeEnumUI_t1927196230;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.DefaultFairyChessUI
struct  DefaultFairyChessUI_t4103913230  : public UIBehavior_1_t3175349520
{
public:
	// System.Boolean FairyChess.DefaultFairyChessUI::needReset
	bool ___needReset_6;
	// System.Boolean FairyChess.DefaultFairyChessUI::miniGameDataDirty
	bool ___miniGameDataDirty_7;
	// UnityEngine.GameObject FairyChess.DefaultFairyChessUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_8;
	// MiniGameDataUI FairyChess.DefaultFairyChessUI::miniGameDataUIPrefab
	MiniGameDataUI_t29488987 * ___miniGameDataUIPrefab_9;
	// UnityEngine.Transform FairyChess.DefaultFairyChessUI::miniGameDataUIContainer
	Transform_t3275118058 * ___miniGameDataUIContainer_10;
	// RequestChangeEnumUI FairyChess.DefaultFairyChessUI::requestEnumPrefab
	RequestChangeEnumUI_t1927196230 * ___requestEnumPrefab_11;
	// UnityEngine.Transform FairyChess.DefaultFairyChessUI::variantTypeContainer
	Transform_t3275118058 * ___variantTypeContainer_12;
	// RequestChangeBoolUI FairyChess.DefaultFairyChessUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_13;
	// UnityEngine.Transform FairyChess.DefaultFairyChessUI::chess960Container
	Transform_t3275118058 * ___chess960Container_14;
	// Server FairyChess.DefaultFairyChessUI::server
	Server_t2724320767 * ___server_15;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_miniGameDataDirty_7() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___miniGameDataDirty_7)); }
	inline bool get_miniGameDataDirty_7() const { return ___miniGameDataDirty_7; }
	inline bool* get_address_of_miniGameDataDirty_7() { return &___miniGameDataDirty_7; }
	inline void set_miniGameDataDirty_7(bool value)
	{
		___miniGameDataDirty_7 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_8() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___differentIndicator_8)); }
	inline GameObject_t1756533147 * get_differentIndicator_8() const { return ___differentIndicator_8; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_8() { return &___differentIndicator_8; }
	inline void set_differentIndicator_8(GameObject_t1756533147 * value)
	{
		___differentIndicator_8 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_8, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIPrefab_9() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___miniGameDataUIPrefab_9)); }
	inline MiniGameDataUI_t29488987 * get_miniGameDataUIPrefab_9() const { return ___miniGameDataUIPrefab_9; }
	inline MiniGameDataUI_t29488987 ** get_address_of_miniGameDataUIPrefab_9() { return &___miniGameDataUIPrefab_9; }
	inline void set_miniGameDataUIPrefab_9(MiniGameDataUI_t29488987 * value)
	{
		___miniGameDataUIPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIPrefab_9, value);
	}

	inline static int32_t get_offset_of_miniGameDataUIContainer_10() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___miniGameDataUIContainer_10)); }
	inline Transform_t3275118058 * get_miniGameDataUIContainer_10() const { return ___miniGameDataUIContainer_10; }
	inline Transform_t3275118058 ** get_address_of_miniGameDataUIContainer_10() { return &___miniGameDataUIContainer_10; }
	inline void set_miniGameDataUIContainer_10(Transform_t3275118058 * value)
	{
		___miniGameDataUIContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___miniGameDataUIContainer_10, value);
	}

	inline static int32_t get_offset_of_requestEnumPrefab_11() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___requestEnumPrefab_11)); }
	inline RequestChangeEnumUI_t1927196230 * get_requestEnumPrefab_11() const { return ___requestEnumPrefab_11; }
	inline RequestChangeEnumUI_t1927196230 ** get_address_of_requestEnumPrefab_11() { return &___requestEnumPrefab_11; }
	inline void set_requestEnumPrefab_11(RequestChangeEnumUI_t1927196230 * value)
	{
		___requestEnumPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestEnumPrefab_11, value);
	}

	inline static int32_t get_offset_of_variantTypeContainer_12() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___variantTypeContainer_12)); }
	inline Transform_t3275118058 * get_variantTypeContainer_12() const { return ___variantTypeContainer_12; }
	inline Transform_t3275118058 ** get_address_of_variantTypeContainer_12() { return &___variantTypeContainer_12; }
	inline void set_variantTypeContainer_12(Transform_t3275118058 * value)
	{
		___variantTypeContainer_12 = value;
		Il2CppCodeGenWriteBarrier(&___variantTypeContainer_12, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_13() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___requestBoolPrefab_13)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_13() const { return ___requestBoolPrefab_13; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_13() { return &___requestBoolPrefab_13; }
	inline void set_requestBoolPrefab_13(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_13 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_13, value);
	}

	inline static int32_t get_offset_of_chess960Container_14() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___chess960Container_14)); }
	inline Transform_t3275118058 * get_chess960Container_14() const { return ___chess960Container_14; }
	inline Transform_t3275118058 ** get_address_of_chess960Container_14() { return &___chess960Container_14; }
	inline void set_chess960Container_14(Transform_t3275118058 * value)
	{
		___chess960Container_14 = value;
		Il2CppCodeGenWriteBarrier(&___chess960Container_14, value);
	}

	inline static int32_t get_offset_of_server_15() { return static_cast<int32_t>(offsetof(DefaultFairyChessUI_t4103913230, ___server_15)); }
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
