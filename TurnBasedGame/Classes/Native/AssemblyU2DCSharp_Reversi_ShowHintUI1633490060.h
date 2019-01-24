#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen329312175.h"

// Reversi.ReversiMoveUI
struct ReversiMoveUI_t4189603031;
// Reversi.NoneRule.ReversiCustomSetUI
struct ReversiCustomSetUI_t1123309767;
// Reversi.NoneRule.ReversiCustomMoveUI
struct ReversiCustomMoveUI_t3466784508;
// Reversi.ReversiGameDataUI/UIData
struct UIData_t1808669889;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ShowHintUI
struct  ShowHintUI_t1633490060  : public UIBehavior_1_t329312175
{
public:
	// Reversi.ReversiMoveUI Reversi.ShowHintUI::reversiMovePrefab
	ReversiMoveUI_t4189603031 * ___reversiMovePrefab_6;
	// Reversi.NoneRule.ReversiCustomSetUI Reversi.ShowHintUI::reversiCustomSetPrefab
	ReversiCustomSetUI_t1123309767 * ___reversiCustomSetPrefab_7;
	// Reversi.NoneRule.ReversiCustomMoveUI Reversi.ShowHintUI::reversiCustomMovePrefab
	ReversiCustomMoveUI_t3466784508 * ___reversiCustomMovePrefab_8;
	// Reversi.ReversiGameDataUI/UIData Reversi.ShowHintUI::reversiGameDataUIData
	UIData_t1808669889 * ___reversiGameDataUIData_9;
	// GameDataUI/UIData Reversi.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_reversiMovePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t1633490060, ___reversiMovePrefab_6)); }
	inline ReversiMoveUI_t4189603031 * get_reversiMovePrefab_6() const { return ___reversiMovePrefab_6; }
	inline ReversiMoveUI_t4189603031 ** get_address_of_reversiMovePrefab_6() { return &___reversiMovePrefab_6; }
	inline void set_reversiMovePrefab_6(ReversiMoveUI_t4189603031 * value)
	{
		___reversiMovePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___reversiMovePrefab_6, value);
	}

	inline static int32_t get_offset_of_reversiCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t1633490060, ___reversiCustomSetPrefab_7)); }
	inline ReversiCustomSetUI_t1123309767 * get_reversiCustomSetPrefab_7() const { return ___reversiCustomSetPrefab_7; }
	inline ReversiCustomSetUI_t1123309767 ** get_address_of_reversiCustomSetPrefab_7() { return &___reversiCustomSetPrefab_7; }
	inline void set_reversiCustomSetPrefab_7(ReversiCustomSetUI_t1123309767 * value)
	{
		___reversiCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___reversiCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_reversiCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t1633490060, ___reversiCustomMovePrefab_8)); }
	inline ReversiCustomMoveUI_t3466784508 * get_reversiCustomMovePrefab_8() const { return ___reversiCustomMovePrefab_8; }
	inline ReversiCustomMoveUI_t3466784508 ** get_address_of_reversiCustomMovePrefab_8() { return &___reversiCustomMovePrefab_8; }
	inline void set_reversiCustomMovePrefab_8(ReversiCustomMoveUI_t3466784508 * value)
	{
		___reversiCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___reversiCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_reversiGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t1633490060, ___reversiGameDataUIData_9)); }
	inline UIData_t1808669889 * get_reversiGameDataUIData_9() const { return ___reversiGameDataUIData_9; }
	inline UIData_t1808669889 ** get_address_of_reversiGameDataUIData_9() { return &___reversiGameDataUIData_9; }
	inline void set_reversiGameDataUIData_9(UIData_t1808669889 * value)
	{
		___reversiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___reversiGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t1633490060, ___gameDataUIData_10)); }
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
