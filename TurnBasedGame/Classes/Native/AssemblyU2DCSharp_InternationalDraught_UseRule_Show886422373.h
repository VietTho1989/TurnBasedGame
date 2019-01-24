#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen385505742.h"

// InternationalDraught.UseRule.ClickPieceUI
struct ClickPieceUI_t1703245094;
// InternationalDraught.UseRule.ClickDestUI
struct ClickDestUI_t3438678000;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.UseRule.ShowUI
struct  ShowUI_t886422373  : public UIBehavior_1_t385505742
{
public:
	// InternationalDraught.UseRule.ClickPieceUI InternationalDraught.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t1703245094 * ___clickPiecePrefab_6;
	// InternationalDraught.UseRule.ClickDestUI InternationalDraught.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t3438678000 * ___clickDestPrefab_7;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t886422373, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t1703245094 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t1703245094 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t1703245094 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t886422373, ___clickDestPrefab_7)); }
	inline ClickDestUI_t3438678000 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t3438678000 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t3438678000 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
