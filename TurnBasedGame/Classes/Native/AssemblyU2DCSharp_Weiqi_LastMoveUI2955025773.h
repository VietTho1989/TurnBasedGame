#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2308925391.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Weiqi.WeiqiMoveUI
struct WeiqiMoveUI_t2369461500;
// Weiqi.NoneRule.WeiqiCustomSetUI
struct WeiqiCustomSetUI_t3060179092;
// Weiqi.NoneRule.WeiqiCustomMoveUI
struct WeiqiCustomMoveUI_t2786002911;
// LastMoveCheckChange`1<Weiqi.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t1912293308;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.LastMoveUI
struct  LastMoveUI_t2955025773  : public UIBehavior_1_t2308925391
{
public:
	// UnityEngine.Transform Weiqi.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Weiqi.WeiqiMoveUI Weiqi.LastMoveUI::weiqiMovePrefab
	WeiqiMoveUI_t2369461500 * ___weiqiMovePrefab_7;
	// Weiqi.NoneRule.WeiqiCustomSetUI Weiqi.LastMoveUI::weiqiCustomSetPrefab
	WeiqiCustomSetUI_t3060179092 * ___weiqiCustomSetPrefab_8;
	// Weiqi.NoneRule.WeiqiCustomMoveUI Weiqi.LastMoveUI::weiqiCustomMovePrefab
	WeiqiCustomMoveUI_t2786002911 * ___weiqiCustomMovePrefab_9;
	// LastMoveCheckChange`1<Weiqi.LastMoveUI/UIData> Weiqi.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t1912293308 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t2955025773, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_weiqiMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t2955025773, ___weiqiMovePrefab_7)); }
	inline WeiqiMoveUI_t2369461500 * get_weiqiMovePrefab_7() const { return ___weiqiMovePrefab_7; }
	inline WeiqiMoveUI_t2369461500 ** get_address_of_weiqiMovePrefab_7() { return &___weiqiMovePrefab_7; }
	inline void set_weiqiMovePrefab_7(WeiqiMoveUI_t2369461500 * value)
	{
		___weiqiMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_weiqiCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t2955025773, ___weiqiCustomSetPrefab_8)); }
	inline WeiqiCustomSetUI_t3060179092 * get_weiqiCustomSetPrefab_8() const { return ___weiqiCustomSetPrefab_8; }
	inline WeiqiCustomSetUI_t3060179092 ** get_address_of_weiqiCustomSetPrefab_8() { return &___weiqiCustomSetPrefab_8; }
	inline void set_weiqiCustomSetPrefab_8(WeiqiCustomSetUI_t3060179092 * value)
	{
		___weiqiCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_weiqiCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t2955025773, ___weiqiCustomMovePrefab_9)); }
	inline WeiqiCustomMoveUI_t2786002911 * get_weiqiCustomMovePrefab_9() const { return ___weiqiCustomMovePrefab_9; }
	inline WeiqiCustomMoveUI_t2786002911 ** get_address_of_weiqiCustomMovePrefab_9() { return &___weiqiCustomMovePrefab_9; }
	inline void set_weiqiCustomMovePrefab_9(WeiqiCustomMoveUI_t2786002911 * value)
	{
		___weiqiCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t2955025773, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t1912293308 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t1912293308 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t1912293308 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
