#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2830923563.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// EnglishDraught.EnglishDraughtMoveUI
struct EnglishDraughtMoveUI_t1639954244;
// EnglishDraught.NoneRule.EnglishDraughtCustomSetUI
struct EnglishDraughtCustomSetUI_t4229312096;
// EnglishDraught.NoneRule.EnglishDraughtCustomMoveUI
struct EnglishDraughtCustomMoveUI_t3952544853;
// LastMoveCheckChange`1<EnglishDraught.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t2434291480;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.LastMoveUI
struct  LastMoveUI_t2561796017  : public UIBehavior_1_t2830923563
{
public:
	// UnityEngine.Transform EnglishDraught.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// EnglishDraught.EnglishDraughtMoveUI EnglishDraught.LastMoveUI::englishDraughtMovePrefab
	EnglishDraughtMoveUI_t1639954244 * ___englishDraughtMovePrefab_7;
	// EnglishDraught.NoneRule.EnglishDraughtCustomSetUI EnglishDraught.LastMoveUI::englishDraughtCustomSetPrefab
	EnglishDraughtCustomSetUI_t4229312096 * ___englishDraughtCustomSetPrefab_8;
	// EnglishDraught.NoneRule.EnglishDraughtCustomMoveUI EnglishDraught.LastMoveUI::englishDraughtCustomMovePrefab
	EnglishDraughtCustomMoveUI_t3952544853 * ___englishDraughtCustomMovePrefab_9;
	// LastMoveCheckChange`1<EnglishDraught.LastMoveUI/UIData> EnglishDraught.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t2434291480 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t2561796017, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_englishDraughtMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t2561796017, ___englishDraughtMovePrefab_7)); }
	inline EnglishDraughtMoveUI_t1639954244 * get_englishDraughtMovePrefab_7() const { return ___englishDraughtMovePrefab_7; }
	inline EnglishDraughtMoveUI_t1639954244 ** get_address_of_englishDraughtMovePrefab_7() { return &___englishDraughtMovePrefab_7; }
	inline void set_englishDraughtMovePrefab_7(EnglishDraughtMoveUI_t1639954244 * value)
	{
		___englishDraughtMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_englishDraughtCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t2561796017, ___englishDraughtCustomSetPrefab_8)); }
	inline EnglishDraughtCustomSetUI_t4229312096 * get_englishDraughtCustomSetPrefab_8() const { return ___englishDraughtCustomSetPrefab_8; }
	inline EnglishDraughtCustomSetUI_t4229312096 ** get_address_of_englishDraughtCustomSetPrefab_8() { return &___englishDraughtCustomSetPrefab_8; }
	inline void set_englishDraughtCustomSetPrefab_8(EnglishDraughtCustomSetUI_t4229312096 * value)
	{
		___englishDraughtCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_englishDraughtCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t2561796017, ___englishDraughtCustomMovePrefab_9)); }
	inline EnglishDraughtCustomMoveUI_t3952544853 * get_englishDraughtCustomMovePrefab_9() const { return ___englishDraughtCustomMovePrefab_9; }
	inline EnglishDraughtCustomMoveUI_t3952544853 ** get_address_of_englishDraughtCustomMovePrefab_9() { return &___englishDraughtCustomMovePrefab_9; }
	inline void set_englishDraughtCustomMovePrefab_9(EnglishDraughtCustomMoveUI_t3952544853 * value)
	{
		___englishDraughtCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t2561796017, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t2434291480 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t2434291480 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t2434291480 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
