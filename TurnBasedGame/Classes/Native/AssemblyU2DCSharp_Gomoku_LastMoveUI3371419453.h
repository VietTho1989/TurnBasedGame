#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen616792138.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Gomoku.GomokuMoveUI
struct GomokuMoveUI_t3075731379;
// Gomoku.NoneRule.GomokuCustomSetUI
struct GomokuCustomSetUI_t2266270591;
// Gomoku.NoneRule.GomokuCustomMoveUI
struct GomokuCustomMoveUI_t845601140;
// LastMoveCheckChange`1<Gomoku.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t220160055;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.LastMoveUI
struct  LastMoveUI_t3371419453  : public UIBehavior_1_t616792138
{
public:
	// UnityEngine.Transform Gomoku.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Gomoku.GomokuMoveUI Gomoku.LastMoveUI::gomokuMovePrefab
	GomokuMoveUI_t3075731379 * ___gomokuMovePrefab_7;
	// Gomoku.NoneRule.GomokuCustomSetUI Gomoku.LastMoveUI::gomokuCustomSetPrefab
	GomokuCustomSetUI_t2266270591 * ___gomokuCustomSetPrefab_8;
	// Gomoku.NoneRule.GomokuCustomMoveUI Gomoku.LastMoveUI::gomokuCustomMovePrefab
	GomokuCustomMoveUI_t845601140 * ___gomokuCustomMovePrefab_9;
	// LastMoveCheckChange`1<Gomoku.LastMoveUI/UIData> Gomoku.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t220160055 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t3371419453, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_gomokuMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t3371419453, ___gomokuMovePrefab_7)); }
	inline GomokuMoveUI_t3075731379 * get_gomokuMovePrefab_7() const { return ___gomokuMovePrefab_7; }
	inline GomokuMoveUI_t3075731379 ** get_address_of_gomokuMovePrefab_7() { return &___gomokuMovePrefab_7; }
	inline void set_gomokuMovePrefab_7(GomokuMoveUI_t3075731379 * value)
	{
		___gomokuMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_gomokuCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t3371419453, ___gomokuCustomSetPrefab_8)); }
	inline GomokuCustomSetUI_t2266270591 * get_gomokuCustomSetPrefab_8() const { return ___gomokuCustomSetPrefab_8; }
	inline GomokuCustomSetUI_t2266270591 ** get_address_of_gomokuCustomSetPrefab_8() { return &___gomokuCustomSetPrefab_8; }
	inline void set_gomokuCustomSetPrefab_8(GomokuCustomSetUI_t2266270591 * value)
	{
		___gomokuCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_gomokuCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t3371419453, ___gomokuCustomMovePrefab_9)); }
	inline GomokuCustomMoveUI_t845601140 * get_gomokuCustomMovePrefab_9() const { return ___gomokuCustomMovePrefab_9; }
	inline GomokuCustomMoveUI_t845601140 ** get_address_of_gomokuCustomMovePrefab_9() { return &___gomokuCustomMovePrefab_9; }
	inline void set_gomokuCustomMovePrefab_9(GomokuCustomMoveUI_t845601140 * value)
	{
		___gomokuCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t3371419453, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t220160055 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t220160055 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t220160055 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
