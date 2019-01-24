#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1007589170.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Reversi.ReversiMoveUI
struct ReversiMoveUI_t4189603031;
// Reversi.NoneRule.ReversiCustomSetUI
struct ReversiCustomSetUI_t1123309767;
// Reversi.NoneRule.ReversiCustomMoveUI
struct ReversiCustomMoveUI_t3466784508;
// LastMoveCheckChange`1<Reversi.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t610957087;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.LastMoveUI
struct  LastMoveUI_t2246690057  : public UIBehavior_1_t1007589170
{
public:
	// UnityEngine.Transform Reversi.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Reversi.ReversiMoveUI Reversi.LastMoveUI::reversiMovePrefab
	ReversiMoveUI_t4189603031 * ___reversiMovePrefab_7;
	// Reversi.NoneRule.ReversiCustomSetUI Reversi.LastMoveUI::reversiCustomSetPrefab
	ReversiCustomSetUI_t1123309767 * ___reversiCustomSetPrefab_8;
	// Reversi.NoneRule.ReversiCustomMoveUI Reversi.LastMoveUI::reversiCustomMovePrefab
	ReversiCustomMoveUI_t3466784508 * ___reversiCustomMovePrefab_9;
	// LastMoveCheckChange`1<Reversi.LastMoveUI/UIData> Reversi.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t610957087 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t2246690057, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_reversiMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t2246690057, ___reversiMovePrefab_7)); }
	inline ReversiMoveUI_t4189603031 * get_reversiMovePrefab_7() const { return ___reversiMovePrefab_7; }
	inline ReversiMoveUI_t4189603031 ** get_address_of_reversiMovePrefab_7() { return &___reversiMovePrefab_7; }
	inline void set_reversiMovePrefab_7(ReversiMoveUI_t4189603031 * value)
	{
		___reversiMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___reversiMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_reversiCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t2246690057, ___reversiCustomSetPrefab_8)); }
	inline ReversiCustomSetUI_t1123309767 * get_reversiCustomSetPrefab_8() const { return ___reversiCustomSetPrefab_8; }
	inline ReversiCustomSetUI_t1123309767 ** get_address_of_reversiCustomSetPrefab_8() { return &___reversiCustomSetPrefab_8; }
	inline void set_reversiCustomSetPrefab_8(ReversiCustomSetUI_t1123309767 * value)
	{
		___reversiCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___reversiCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_reversiCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t2246690057, ___reversiCustomMovePrefab_9)); }
	inline ReversiCustomMoveUI_t3466784508 * get_reversiCustomMovePrefab_9() const { return ___reversiCustomMovePrefab_9; }
	inline ReversiCustomMoveUI_t3466784508 ** get_address_of_reversiCustomMovePrefab_9() { return &___reversiCustomMovePrefab_9; }
	inline void set_reversiCustomMovePrefab_9(ReversiCustomMoveUI_t3466784508 * value)
	{
		___reversiCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___reversiCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t2246690057, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t610957087 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t610957087 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t610957087 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
