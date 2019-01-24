#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2227476052.h"

// Shatranj.UseRule.ClickPieceUI
struct ClickPieceUI_t2129811650;
// Shatranj.UseRule.ClickDestUI
struct ClickDestUI_t2606573944;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.ShowUI
struct  ShowUI_t7027405  : public UIBehavior_1_t2227476052
{
public:
	// Shatranj.UseRule.ClickPieceUI Shatranj.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t2129811650 * ___clickPiecePrefab_6;
	// Shatranj.UseRule.ClickDestUI Shatranj.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t2606573944 * ___clickDestPrefab_7;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t7027405, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t2129811650 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t2129811650 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t2129811650 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t7027405, ___clickDestPrefab_7)); }
	inline ClickDestUI_t2606573944 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t2606573944 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t2606573944 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
