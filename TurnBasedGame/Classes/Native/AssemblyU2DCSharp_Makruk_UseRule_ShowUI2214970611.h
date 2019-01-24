#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2495478544.h"

// Makruk.UseRule.ClickPieceUI
struct ClickPieceUI_t328767006;
// Makruk.UseRule.ClickDestUI
struct ClickDestUI_t1649561996;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.UseRule.ShowUI
struct  ShowUI_t2214970611  : public UIBehavior_1_t2495478544
{
public:
	// Makruk.UseRule.ClickPieceUI Makruk.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t328767006 * ___clickPiecePrefab_6;
	// Makruk.UseRule.ClickDestUI Makruk.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t1649561996 * ___clickDestPrefab_7;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t2214970611, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t328767006 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t328767006 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t328767006 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t2214970611, ___clickDestPrefab_7)); }
	inline ClickDestUI_t1649561996 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t1649561996 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t1649561996 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
