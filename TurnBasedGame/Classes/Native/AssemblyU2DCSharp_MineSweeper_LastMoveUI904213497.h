#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3257937282.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// MineSweeper.MineSweeperMoveUI
struct MineSweeperMoveUI_t2921947319;
// MineSweeper.NoneRule.MineSweeperCustomSetUI
struct MineSweeperCustomSetUI_t2786621207;
// MineSweeper.NoneRule.MineSweeperCustomMoveUI
struct MineSweeperCustomMoveUI_t517262796;
// LastMoveCheckChange`1<MineSweeper.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t2861305199;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.LastMoveUI
struct  LastMoveUI_t904213497  : public UIBehavior_1_t3257937282
{
public:
	// UnityEngine.Transform MineSweeper.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// MineSweeper.MineSweeperMoveUI MineSweeper.LastMoveUI::mineSweeperMovePrefab
	MineSweeperMoveUI_t2921947319 * ___mineSweeperMovePrefab_7;
	// MineSweeper.NoneRule.MineSweeperCustomSetUI MineSweeper.LastMoveUI::mineSweeperCustomSetPrefab
	MineSweeperCustomSetUI_t2786621207 * ___mineSweeperCustomSetPrefab_8;
	// MineSweeper.NoneRule.MineSweeperCustomMoveUI MineSweeper.LastMoveUI::mineSweeperCustomMovePrefab
	MineSweeperCustomMoveUI_t517262796 * ___mineSweeperCustomMovePrefab_9;
	// LastMoveCheckChange`1<MineSweeper.LastMoveUI/UIData> MineSweeper.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t2861305199 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t904213497, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_mineSweeperMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t904213497, ___mineSweeperMovePrefab_7)); }
	inline MineSweeperMoveUI_t2921947319 * get_mineSweeperMovePrefab_7() const { return ___mineSweeperMovePrefab_7; }
	inline MineSweeperMoveUI_t2921947319 ** get_address_of_mineSweeperMovePrefab_7() { return &___mineSweeperMovePrefab_7; }
	inline void set_mineSweeperMovePrefab_7(MineSweeperMoveUI_t2921947319 * value)
	{
		___mineSweeperMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_mineSweeperCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t904213497, ___mineSweeperCustomSetPrefab_8)); }
	inline MineSweeperCustomSetUI_t2786621207 * get_mineSweeperCustomSetPrefab_8() const { return ___mineSweeperCustomSetPrefab_8; }
	inline MineSweeperCustomSetUI_t2786621207 ** get_address_of_mineSweeperCustomSetPrefab_8() { return &___mineSweeperCustomSetPrefab_8; }
	inline void set_mineSweeperCustomSetPrefab_8(MineSweeperCustomSetUI_t2786621207 * value)
	{
		___mineSweeperCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_mineSweeperCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t904213497, ___mineSweeperCustomMovePrefab_9)); }
	inline MineSweeperCustomMoveUI_t517262796 * get_mineSweeperCustomMovePrefab_9() const { return ___mineSweeperCustomMovePrefab_9; }
	inline MineSweeperCustomMoveUI_t517262796 ** get_address_of_mineSweeperCustomMovePrefab_9() { return &___mineSweeperCustomMovePrefab_9; }
	inline void set_mineSweeperCustomMovePrefab_9(MineSweeperCustomMoveUI_t517262796 * value)
	{
		___mineSweeperCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t904213497, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t2861305199 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t2861305199 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t2861305199 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
