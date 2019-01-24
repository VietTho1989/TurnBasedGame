#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen677750094.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// RussianDraught.RussianDraughtMoveUI
struct RussianDraughtMoveUI_t958083007;
// RussianDraught.NoneRule.RussianDraughtCustomSetUI
struct RussianDraughtCustomSetUI_t1417818331;
// RussianDraught.NoneRule.RussianDraughtCustomMoveUI
struct RussianDraughtCustomMoveUI_t3227079760;
// LastMoveCheckChange`1<RussianDraught.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t281118011;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.LastMoveUI
struct  LastMoveUI_t1949683581  : public UIBehavior_1_t677750094
{
public:
	// UnityEngine.Transform RussianDraught.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// RussianDraught.RussianDraughtMoveUI RussianDraught.LastMoveUI::russianDraughtMovePrefab
	RussianDraughtMoveUI_t958083007 * ___russianDraughtMovePrefab_7;
	// RussianDraught.NoneRule.RussianDraughtCustomSetUI RussianDraught.LastMoveUI::russianDraughtCustomSetPrefab
	RussianDraughtCustomSetUI_t1417818331 * ___russianDraughtCustomSetPrefab_8;
	// RussianDraught.NoneRule.RussianDraughtCustomMoveUI RussianDraught.LastMoveUI::russianDraughtCustomMovePrefab
	RussianDraughtCustomMoveUI_t3227079760 * ___russianDraughtCustomMovePrefab_9;
	// LastMoveCheckChange`1<RussianDraught.LastMoveUI/UIData> RussianDraught.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t281118011 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t1949683581, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_russianDraughtMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t1949683581, ___russianDraughtMovePrefab_7)); }
	inline RussianDraughtMoveUI_t958083007 * get_russianDraughtMovePrefab_7() const { return ___russianDraughtMovePrefab_7; }
	inline RussianDraughtMoveUI_t958083007 ** get_address_of_russianDraughtMovePrefab_7() { return &___russianDraughtMovePrefab_7; }
	inline void set_russianDraughtMovePrefab_7(RussianDraughtMoveUI_t958083007 * value)
	{
		___russianDraughtMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_russianDraughtCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t1949683581, ___russianDraughtCustomSetPrefab_8)); }
	inline RussianDraughtCustomSetUI_t1417818331 * get_russianDraughtCustomSetPrefab_8() const { return ___russianDraughtCustomSetPrefab_8; }
	inline RussianDraughtCustomSetUI_t1417818331 ** get_address_of_russianDraughtCustomSetPrefab_8() { return &___russianDraughtCustomSetPrefab_8; }
	inline void set_russianDraughtCustomSetPrefab_8(RussianDraughtCustomSetUI_t1417818331 * value)
	{
		___russianDraughtCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_russianDraughtCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t1949683581, ___russianDraughtCustomMovePrefab_9)); }
	inline RussianDraughtCustomMoveUI_t3227079760 * get_russianDraughtCustomMovePrefab_9() const { return ___russianDraughtCustomMovePrefab_9; }
	inline RussianDraughtCustomMoveUI_t3227079760 ** get_address_of_russianDraughtCustomMovePrefab_9() { return &___russianDraughtCustomMovePrefab_9; }
	inline void set_russianDraughtCustomMovePrefab_9(RussianDraughtCustomMoveUI_t3227079760 * value)
	{
		___russianDraughtCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t1949683581, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t281118011 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t281118011 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t281118011 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
