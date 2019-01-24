#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1384610271.h"

// MineSweeper.MineSweeperMoveUI
struct MineSweeperMoveUI_t2921947319;
// MineSweeper.MineSweeperGameDataUI/UIData
struct UIData_t1952477953;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.ShowHintUI
struct  ShowHintUI_t2142858972  : public UIBehavior_1_t1384610271
{
public:
	// System.Int32 MineSweeper.ShowHintUI::lastMove
	int32_t ___lastMove_6;
	// MineSweeper.MineSweeperMoveUI MineSweeper.ShowHintUI::mineSweeperMovePrefab
	MineSweeperMoveUI_t2921947319 * ___mineSweeperMovePrefab_7;
	// MineSweeper.MineSweeperGameDataUI/UIData MineSweeper.ShowHintUI::mineSweeperGameDataUIData
	UIData_t1952477953 * ___mineSweeperGameDataUIData_8;
	// GameDataUI/UIData MineSweeper.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_9;

public:
	inline static int32_t get_offset_of_lastMove_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t2142858972, ___lastMove_6)); }
	inline int32_t get_lastMove_6() const { return ___lastMove_6; }
	inline int32_t* get_address_of_lastMove_6() { return &___lastMove_6; }
	inline void set_lastMove_6(int32_t value)
	{
		___lastMove_6 = value;
	}

	inline static int32_t get_offset_of_mineSweeperMovePrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t2142858972, ___mineSweeperMovePrefab_7)); }
	inline MineSweeperMoveUI_t2921947319 * get_mineSweeperMovePrefab_7() const { return ___mineSweeperMovePrefab_7; }
	inline MineSweeperMoveUI_t2921947319 ** get_address_of_mineSweeperMovePrefab_7() { return &___mineSweeperMovePrefab_7; }
	inline void set_mineSweeperMovePrefab_7(MineSweeperMoveUI_t2921947319 * value)
	{
		___mineSweeperMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_mineSweeperGameDataUIData_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t2142858972, ___mineSweeperGameDataUIData_8)); }
	inline UIData_t1952477953 * get_mineSweeperGameDataUIData_8() const { return ___mineSweeperGameDataUIData_8; }
	inline UIData_t1952477953 ** get_address_of_mineSweeperGameDataUIData_8() { return &___mineSweeperGameDataUIData_8; }
	inline void set_mineSweeperGameDataUIData_8(UIData_t1952477953 * value)
	{
		___mineSweeperGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___mineSweeperGameDataUIData_8, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t2142858972, ___gameDataUIData_9)); }
	inline UIData_t306925783 * get_gameDataUIData_9() const { return ___gameDataUIData_9; }
	inline UIData_t306925783 ** get_address_of_gameDataUIData_9() { return &___gameDataUIData_9; }
	inline void set_gameDataUIData_9(UIData_t306925783 * value)
	{
		___gameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
