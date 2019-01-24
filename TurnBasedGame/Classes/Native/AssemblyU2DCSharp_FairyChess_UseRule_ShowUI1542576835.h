#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4242844544.h"

// FairyChess.UseRule.ClickPieceUI
struct ClickPieceUI_t390316706;
// FairyChess.UseRule.ClickDestUI
struct ClickDestUI_t3749533480;
// FairyChess.UseRule.DropPieceUI
struct DropPieceUI_t3867110443;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.UseRule.ShowUI
struct  ShowUI_t1542576835  : public UIBehavior_1_t4242844544
{
public:
	// FairyChess.UseRule.ClickPieceUI FairyChess.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t390316706 * ___clickPiecePrefab_6;
	// FairyChess.UseRule.ClickDestUI FairyChess.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t3749533480 * ___clickDestPrefab_7;
	// FairyChess.UseRule.DropPieceUI FairyChess.UseRule.ShowUI::dropPiecePrefab
	DropPieceUI_t3867110443 * ___dropPiecePrefab_8;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t1542576835, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t390316706 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t390316706 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t390316706 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t1542576835, ___clickDestPrefab_7)); }
	inline ClickDestUI_t3749533480 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t3749533480 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t3749533480 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}

	inline static int32_t get_offset_of_dropPiecePrefab_8() { return static_cast<int32_t>(offsetof(ShowUI_t1542576835, ___dropPiecePrefab_8)); }
	inline DropPieceUI_t3867110443 * get_dropPiecePrefab_8() const { return ___dropPiecePrefab_8; }
	inline DropPieceUI_t3867110443 ** get_address_of_dropPiecePrefab_8() { return &___dropPiecePrefab_8; }
	inline void set_dropPiecePrefab_8(DropPieceUI_t3867110443 * value)
	{
		___dropPiecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___dropPiecePrefab_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
