#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2365634543.h"

// Gomoku.GomokuMoveUI
struct GomokuMoveUI_t3075731379;
// Gomoku.NoneRule.GomokuCustomSetUI
struct GomokuCustomSetUI_t2266270591;
// Gomoku.NoneRule.GomokuCustomMoveUI
struct GomokuCustomMoveUI_t845601140;
// Gomoku.GomokuGameDataUI/UIData
struct UIData_t2272016985;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.ShowHintUI
struct  ShowHintUI_t3723161080  : public UIBehavior_1_t2365634543
{
public:
	// Gomoku.GomokuMoveUI Gomoku.ShowHintUI::gomokuMovePrefab
	GomokuMoveUI_t3075731379 * ___gomokuMovePrefab_6;
	// Gomoku.NoneRule.GomokuCustomSetUI Gomoku.ShowHintUI::gomokuCustomSetPrefab
	GomokuCustomSetUI_t2266270591 * ___gomokuCustomSetPrefab_7;
	// Gomoku.NoneRule.GomokuCustomMoveUI Gomoku.ShowHintUI::gomokuCustomMovePrefab
	GomokuCustomMoveUI_t845601140 * ___gomokuCustomMovePrefab_8;
	// Gomoku.GomokuGameDataUI/UIData Gomoku.ShowHintUI::gomokuGameDataUIData
	UIData_t2272016985 * ___gomokuGameDataUIData_9;
	// GameDataUI/UIData Gomoku.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_gomokuMovePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t3723161080, ___gomokuMovePrefab_6)); }
	inline GomokuMoveUI_t3075731379 * get_gomokuMovePrefab_6() const { return ___gomokuMovePrefab_6; }
	inline GomokuMoveUI_t3075731379 ** get_address_of_gomokuMovePrefab_6() { return &___gomokuMovePrefab_6; }
	inline void set_gomokuMovePrefab_6(GomokuMoveUI_t3075731379 * value)
	{
		___gomokuMovePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuMovePrefab_6, value);
	}

	inline static int32_t get_offset_of_gomokuCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t3723161080, ___gomokuCustomSetPrefab_7)); }
	inline GomokuCustomSetUI_t2266270591 * get_gomokuCustomSetPrefab_7() const { return ___gomokuCustomSetPrefab_7; }
	inline GomokuCustomSetUI_t2266270591 ** get_address_of_gomokuCustomSetPrefab_7() { return &___gomokuCustomSetPrefab_7; }
	inline void set_gomokuCustomSetPrefab_7(GomokuCustomSetUI_t2266270591 * value)
	{
		___gomokuCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_gomokuCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t3723161080, ___gomokuCustomMovePrefab_8)); }
	inline GomokuCustomMoveUI_t845601140 * get_gomokuCustomMovePrefab_8() const { return ___gomokuCustomMovePrefab_8; }
	inline GomokuCustomMoveUI_t845601140 ** get_address_of_gomokuCustomMovePrefab_8() { return &___gomokuCustomMovePrefab_8; }
	inline void set_gomokuCustomMovePrefab_8(GomokuCustomMoveUI_t845601140 * value)
	{
		___gomokuCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_gomokuGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t3723161080, ___gomokuGameDataUIData_9)); }
	inline UIData_t2272016985 * get_gomokuGameDataUIData_9() const { return ___gomokuGameDataUIData_9; }
	inline UIData_t2272016985 ** get_address_of_gomokuGameDataUIData_9() { return &___gomokuGameDataUIData_9; }
	inline void set_gomokuGameDataUIData_9(UIData_t2272016985 * value)
	{
		___gomokuGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t3723161080, ___gameDataUIData_10)); }
	inline UIData_t306925783 * get_gameDataUIData_10() const { return ___gameDataUIData_10; }
	inline UIData_t306925783 ** get_address_of_gameDataUIData_10() { return &___gameDataUIData_10; }
	inline void set_gameDataUIData_10(UIData_t306925783 * value)
	{
		___gameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___gameDataUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
