#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2904013544.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Shogi.ShogiMoveUI
struct ShogiMoveUI_t3235352245;
// Shogi.NoneRule.ShogiCustomSetUI
struct ShogiCustomSetUI_t4055169757;
// Shogi.NoneRule.ShogiCustomMoveUI
struct ShogiCustomMoveUI_t771121374;
// Shogi.NoneRule.ShogiCustomHandUI
struct ShogiCustomHandUI_t677776742;
// LastMoveCheckChange`1<Shogi.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t2507381461;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.LastMoveUI
struct  LastMoveUI_t1342308785  : public UIBehavior_1_t2904013544
{
public:
	// UnityEngine.Transform Shogi.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Shogi.ShogiMoveUI Shogi.LastMoveUI::shogiMovePrefab
	ShogiMoveUI_t3235352245 * ___shogiMovePrefab_7;
	// Shogi.NoneRule.ShogiCustomSetUI Shogi.LastMoveUI::shogiCustomSetPrefab
	ShogiCustomSetUI_t4055169757 * ___shogiCustomSetPrefab_8;
	// Shogi.NoneRule.ShogiCustomMoveUI Shogi.LastMoveUI::shogiCustomMovePrefab
	ShogiCustomMoveUI_t771121374 * ___shogiCustomMovePrefab_9;
	// Shogi.NoneRule.ShogiCustomHandUI Shogi.LastMoveUI::shogiCustomHandPrefab
	ShogiCustomHandUI_t677776742 * ___shogiCustomHandPrefab_10;
	// LastMoveCheckChange`1<Shogi.LastMoveUI/UIData> Shogi.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t2507381461 * ___lastMoveCheckChange_11;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_shogiMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___shogiMovePrefab_7)); }
	inline ShogiMoveUI_t3235352245 * get_shogiMovePrefab_7() const { return ___shogiMovePrefab_7; }
	inline ShogiMoveUI_t3235352245 ** get_address_of_shogiMovePrefab_7() { return &___shogiMovePrefab_7; }
	inline void set_shogiMovePrefab_7(ShogiMoveUI_t3235352245 * value)
	{
		___shogiMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___shogiMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_shogiCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___shogiCustomSetPrefab_8)); }
	inline ShogiCustomSetUI_t4055169757 * get_shogiCustomSetPrefab_8() const { return ___shogiCustomSetPrefab_8; }
	inline ShogiCustomSetUI_t4055169757 ** get_address_of_shogiCustomSetPrefab_8() { return &___shogiCustomSetPrefab_8; }
	inline void set_shogiCustomSetPrefab_8(ShogiCustomSetUI_t4055169757 * value)
	{
		___shogiCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_shogiCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___shogiCustomMovePrefab_9)); }
	inline ShogiCustomMoveUI_t771121374 * get_shogiCustomMovePrefab_9() const { return ___shogiCustomMovePrefab_9; }
	inline ShogiCustomMoveUI_t771121374 ** get_address_of_shogiCustomMovePrefab_9() { return &___shogiCustomMovePrefab_9; }
	inline void set_shogiCustomMovePrefab_9(ShogiCustomMoveUI_t771121374 * value)
	{
		___shogiCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_shogiCustomHandPrefab_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___shogiCustomHandPrefab_10)); }
	inline ShogiCustomHandUI_t677776742 * get_shogiCustomHandPrefab_10() const { return ___shogiCustomHandPrefab_10; }
	inline ShogiCustomHandUI_t677776742 ** get_address_of_shogiCustomHandPrefab_10() { return &___shogiCustomHandPrefab_10; }
	inline void set_shogiCustomHandPrefab_10(ShogiCustomHandUI_t677776742 * value)
	{
		___shogiCustomHandPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomHandPrefab_10, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_11() { return static_cast<int32_t>(offsetof(LastMoveUI_t1342308785, ___lastMoveCheckChange_11)); }
	inline LastMoveCheckChange_1_t2507381461 * get_lastMoveCheckChange_11() const { return ___lastMoveCheckChange_11; }
	inline LastMoveCheckChange_1_t2507381461 ** get_address_of_lastMoveCheckChange_11() { return &___lastMoveCheckChange_11; }
	inline void set_lastMoveCheckChange_11(LastMoveCheckChange_1_t2507381461 * value)
	{
		___lastMoveCheckChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
