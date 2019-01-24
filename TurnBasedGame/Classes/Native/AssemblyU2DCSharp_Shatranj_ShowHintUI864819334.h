#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2962885856.h"

// Shatranj.ShatranjMoveUI
struct ShatranjMoveUI_t1257348402;
// Shatranj.NoneRule.ShatranjCustomSetUI
struct ShatranjCustomSetUI_t3032430214;
// Shatranj.NoneRule.ShatranjCustomMoveUI
struct ShatranjCustomMoveUI_t2556971451;
// Shatranj.ShatranjGameDataUI/UIData
struct UIData_t2391886061;
// GameDataUI/UIData
struct UIData_t306925783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.ShowHintUI
struct  ShowHintUI_t864819334  : public UIBehavior_1_t2962885856
{
public:
	// Shatranj.ShatranjMoveUI Shatranj.ShowHintUI::shatranjMovePrefab
	ShatranjMoveUI_t1257348402 * ___shatranjMovePrefab_6;
	// Shatranj.NoneRule.ShatranjCustomSetUI Shatranj.ShowHintUI::shatranjCustomSetPrefab
	ShatranjCustomSetUI_t3032430214 * ___shatranjCustomSetPrefab_7;
	// Shatranj.NoneRule.ShatranjCustomMoveUI Shatranj.ShowHintUI::shatranjCustomMovePrefab
	ShatranjCustomMoveUI_t2556971451 * ___shatranjCustomMovePrefab_8;
	// Shatranj.ShatranjGameDataUI/UIData Shatranj.ShowHintUI::shatranjGameDataUIData
	UIData_t2391886061 * ___shatranjGameDataUIData_9;
	// GameDataUI/UIData Shatranj.ShowHintUI::gameDataUIData
	UIData_t306925783 * ___gameDataUIData_10;

public:
	inline static int32_t get_offset_of_shatranjMovePrefab_6() { return static_cast<int32_t>(offsetof(ShowHintUI_t864819334, ___shatranjMovePrefab_6)); }
	inline ShatranjMoveUI_t1257348402 * get_shatranjMovePrefab_6() const { return ___shatranjMovePrefab_6; }
	inline ShatranjMoveUI_t1257348402 ** get_address_of_shatranjMovePrefab_6() { return &___shatranjMovePrefab_6; }
	inline void set_shatranjMovePrefab_6(ShatranjMoveUI_t1257348402 * value)
	{
		___shatranjMovePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjMovePrefab_6, value);
	}

	inline static int32_t get_offset_of_shatranjCustomSetPrefab_7() { return static_cast<int32_t>(offsetof(ShowHintUI_t864819334, ___shatranjCustomSetPrefab_7)); }
	inline ShatranjCustomSetUI_t3032430214 * get_shatranjCustomSetPrefab_7() const { return ___shatranjCustomSetPrefab_7; }
	inline ShatranjCustomSetUI_t3032430214 ** get_address_of_shatranjCustomSetPrefab_7() { return &___shatranjCustomSetPrefab_7; }
	inline void set_shatranjCustomSetPrefab_7(ShatranjCustomSetUI_t3032430214 * value)
	{
		___shatranjCustomSetPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjCustomSetPrefab_7, value);
	}

	inline static int32_t get_offset_of_shatranjCustomMovePrefab_8() { return static_cast<int32_t>(offsetof(ShowHintUI_t864819334, ___shatranjCustomMovePrefab_8)); }
	inline ShatranjCustomMoveUI_t2556971451 * get_shatranjCustomMovePrefab_8() const { return ___shatranjCustomMovePrefab_8; }
	inline ShatranjCustomMoveUI_t2556971451 ** get_address_of_shatranjCustomMovePrefab_8() { return &___shatranjCustomMovePrefab_8; }
	inline void set_shatranjCustomMovePrefab_8(ShatranjCustomMoveUI_t2556971451 * value)
	{
		___shatranjCustomMovePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjCustomMovePrefab_8, value);
	}

	inline static int32_t get_offset_of_shatranjGameDataUIData_9() { return static_cast<int32_t>(offsetof(ShowHintUI_t864819334, ___shatranjGameDataUIData_9)); }
	inline UIData_t2391886061 * get_shatranjGameDataUIData_9() const { return ___shatranjGameDataUIData_9; }
	inline UIData_t2391886061 ** get_address_of_shatranjGameDataUIData_9() { return &___shatranjGameDataUIData_9; }
	inline void set_shatranjGameDataUIData_9(UIData_t2391886061 * value)
	{
		___shatranjGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_gameDataUIData_10() { return static_cast<int32_t>(offsetof(ShowHintUI_t864819334, ___gameDataUIData_10)); }
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
