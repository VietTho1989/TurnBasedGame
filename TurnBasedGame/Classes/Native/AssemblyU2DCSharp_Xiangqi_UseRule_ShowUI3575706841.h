#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1585360172.h"

// Xiangqi.UseRule.ClickPieceUI
struct ClickPieceUI_t1563610474;
// Xiangqi.UseRule.ClickDestUI
struct ClickDestUI_t359877600;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.UseRule.ShowUI
struct  ShowUI_t3575706841  : public UIBehavior_1_t1585360172
{
public:
	// Xiangqi.UseRule.ClickPieceUI Xiangqi.UseRule.ShowUI::clickPiecePrefab
	ClickPieceUI_t1563610474 * ___clickPiecePrefab_6;
	// Xiangqi.UseRule.ClickDestUI Xiangqi.UseRule.ShowUI::clickDestPrefab
	ClickDestUI_t359877600 * ___clickDestPrefab_7;

public:
	inline static int32_t get_offset_of_clickPiecePrefab_6() { return static_cast<int32_t>(offsetof(ShowUI_t3575706841, ___clickPiecePrefab_6)); }
	inline ClickPieceUI_t1563610474 * get_clickPiecePrefab_6() const { return ___clickPiecePrefab_6; }
	inline ClickPieceUI_t1563610474 ** get_address_of_clickPiecePrefab_6() { return &___clickPiecePrefab_6; }
	inline void set_clickPiecePrefab_6(ClickPieceUI_t1563610474 * value)
	{
		___clickPiecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___clickPiecePrefab_6, value);
	}

	inline static int32_t get_offset_of_clickDestPrefab_7() { return static_cast<int32_t>(offsetof(ShowUI_t3575706841, ___clickDestPrefab_7)); }
	inline ClickDestUI_t359877600 * get_clickDestPrefab_7() const { return ___clickDestPrefab_7; }
	inline ClickDestUI_t359877600 ** get_address_of_clickDestPrefab_7() { return &___clickDestPrefab_7; }
	inline void set_clickDestPrefab_7(ClickDestUI_t359877600 * value)
	{
		___clickDestPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
