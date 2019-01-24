#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1246328925.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Shatranj.ShatranjMoveUI
struct ShatranjMoveUI_t1257348402;
// Shatranj.NoneRule.ShatranjCustomSetUI
struct ShatranjCustomSetUI_t3032430214;
// Shatranj.NoneRule.ShatranjCustomMoveUI
struct ShatranjCustomMoveUI_t2556971451;
// LastMoveCheckChange`1<Shatranj.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t849696842;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.LastMoveUI
struct  LastMoveUI_t2580088265  : public UIBehavior_1_t1246328925
{
public:
	// UnityEngine.Transform Shatranj.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Shatranj.ShatranjMoveUI Shatranj.LastMoveUI::shatranjMovePrefab
	ShatranjMoveUI_t1257348402 * ___shatranjMovePrefab_7;
	// Shatranj.NoneRule.ShatranjCustomSetUI Shatranj.LastMoveUI::shatranjCustomSetPrefab
	ShatranjCustomSetUI_t3032430214 * ___shatranjCustomSetPrefab_8;
	// Shatranj.NoneRule.ShatranjCustomMoveUI Shatranj.LastMoveUI::shatranjCustomMovePrefab
	ShatranjCustomMoveUI_t2556971451 * ___shatranjCustomMovePrefab_9;
	// LastMoveCheckChange`1<Shatranj.LastMoveUI/UIData> Shatranj.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t849696842 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t2580088265, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_shatranjMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t2580088265, ___shatranjMovePrefab_7)); }
	inline ShatranjMoveUI_t1257348402 * get_shatranjMovePrefab_7() const { return ___shatranjMovePrefab_7; }
	inline ShatranjMoveUI_t1257348402 ** get_address_of_shatranjMovePrefab_7() { return &___shatranjMovePrefab_7; }
	inline void set_shatranjMovePrefab_7(ShatranjMoveUI_t1257348402 * value)
	{
		___shatranjMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_shatranjCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t2580088265, ___shatranjCustomSetPrefab_8)); }
	inline ShatranjCustomSetUI_t3032430214 * get_shatranjCustomSetPrefab_8() const { return ___shatranjCustomSetPrefab_8; }
	inline ShatranjCustomSetUI_t3032430214 ** get_address_of_shatranjCustomSetPrefab_8() { return &___shatranjCustomSetPrefab_8; }
	inline void set_shatranjCustomSetPrefab_8(ShatranjCustomSetUI_t3032430214 * value)
	{
		___shatranjCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_shatranjCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t2580088265, ___shatranjCustomMovePrefab_9)); }
	inline ShatranjCustomMoveUI_t2556971451 * get_shatranjCustomMovePrefab_9() const { return ___shatranjCustomMovePrefab_9; }
	inline ShatranjCustomMoveUI_t2556971451 ** get_address_of_shatranjCustomMovePrefab_9() { return &___shatranjCustomMovePrefab_9; }
	inline void set_shatranjCustomMovePrefab_9(ShatranjCustomMoveUI_t2556971451 * value)
	{
		___shatranjCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t2580088265, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t849696842 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t849696842 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t849696842 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
