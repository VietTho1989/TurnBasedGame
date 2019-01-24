#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1007625425.h"

// Shogi.UseRule.ClickPieceUI
struct ClickPieceUI_t2747634898;
// Shogi.UseRule.ClickDestUI
struct ClickDestUI_t3288336842;
// Shogi.UseRule.DropPieceUI
struct DropPieceUI_t2451273747;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.ShowUI
struct  ShowUI_t3736266973  : public UIBehavior_1_t1007625425
{
public:
	// Shogi.UseRule.ClickPieceUI Shogi.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t2747634898 * ___clickPiecePrefab_6;
	// Shogi.UseRule.ClickDestUI Shogi.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t3288336842 * ___clickDestPrefab_7;
	// Shogi.UseRule.DropPieceUI Shogi.UseRule.ShowUI::dropPiecePrefab
	DropPieceUI_t2451273747 * ___dropPiecePrefab_8;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t3736266973, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t2747634898 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t2747634898 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t2747634898 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t3736266973, ___clickDestPrefab_7)); }
	inline ClickDestUI_t3288336842 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t3288336842 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t3288336842 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}

	inline static int32_t get_offset_of_dropPiecePrefab_8() { return static_cast<int32_t>(offsetof(ShowUI_t3736266973, ___dropPiecePrefab_8)); }
	inline DropPieceUI_t2451273747 * get_dropPiecePrefab_8() const { return ___dropPiecePrefab_8; }
	inline DropPieceUI_t2451273747 ** get_address_of_dropPiecePrefab_8() { return &___dropPiecePrefab_8; }
	inline void set_dropPiecePrefab_8(DropPieceUI_t2451273747 * value)
	{
		___dropPiecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___dropPiecePrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
