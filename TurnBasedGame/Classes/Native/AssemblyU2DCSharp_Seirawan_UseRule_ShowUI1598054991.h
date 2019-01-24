#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1180952323.h"

// Seirawan.UseRule.ClickPieceUI
struct ClickPieceUI_t2902318286;
// Seirawan.UseRule.ClickDestUI
struct ClickDestUI_t2381317722;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.UseRule.ShowUI
struct  ShowUI_t1598054991  : public UIBehavior_1_t1180952323
{
public:
	// Seirawan.UseRule.ClickPieceUI Seirawan.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t2902318286 * ___clickPiecePrefab_6;
	// Seirawan.UseRule.ClickDestUI Seirawan.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t2381317722 * ___clickDestPrefab_7;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t1598054991, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t2902318286 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t2902318286 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t2902318286 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t1598054991, ___clickDestPrefab_7)); }
	inline ClickDestUI_t2381317722 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t2381317722 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t2381317722 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
