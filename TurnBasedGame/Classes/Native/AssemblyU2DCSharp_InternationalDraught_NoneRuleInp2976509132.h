﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1022666688.h"

// InternationalDraught.NoneRule.ClickNoneUI
struct ClickNoneUI_t3141002382;
// InternationalDraught.NoneRule.ClickPosUI
struct ClickPosUI_t523112564;
// InternationalDraught.NoneRule.SetPieceUI
struct SetPieceUI_t2352651354;
// InternationalDraught.NoneRule.ClickMoveUI
struct ClickMoveUI_t3073228577;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.NoneRuleInputUI
struct  NoneRuleInputUI_t2976509132  : public UIBehavior_1_t1022666688
{
public:
	// InternationalDraught.NoneRule.ClickNoneUI InternationalDraught.NoneRuleInputUI::nonePrefab
	ClickNoneUI_t3141002382 * ___nonePrefab_6;
	// InternationalDraught.NoneRule.ClickPosUI InternationalDraught.NoneRuleInputUI::posPrefab
	ClickPosUI_t523112564 * ___posPrefab_7;
	// InternationalDraught.NoneRule.SetPieceUI InternationalDraught.NoneRuleInputUI::setPiecePrefab
	SetPieceUI_t2352651354 * ___setPiecePrefab_8;
	// InternationalDraught.NoneRule.ClickMoveUI InternationalDraught.NoneRuleInputUI::clickMovePrefab
	ClickMoveUI_t3073228577 * ___clickMovePrefab_9;
	// UnityEngine.Transform InternationalDraught.NoneRuleInputUI::subContainer
	Transform_t3275118058 * ___subContainer_10;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(NoneRuleInputUI_t2976509132, ___nonePrefab_6)); }
	inline ClickNoneUI_t3141002382 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline ClickNoneUI_t3141002382 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(ClickNoneUI_t3141002382 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_posPrefab_7() { return static_cast<int32_t>(offsetof(NoneRuleInputUI_t2976509132, ___posPrefab_7)); }
	inline ClickPosUI_t523112564 * get_posPrefab_7() const { return ___posPrefab_7; }
	inline ClickPosUI_t523112564 ** get_address_of_posPrefab_7() { return &___posPrefab_7; }
	inline void set_posPrefab_7(ClickPosUI_t523112564 * value)
	{
		___posPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___posPrefab_7, value);
	}

	inline static int32_t get_offset_of_setPiecePrefab_8() { return static_cast<int32_t>(offsetof(NoneRuleInputUI_t2976509132, ___setPiecePrefab_8)); }
	inline SetPieceUI_t2352651354 * get_setPiecePrefab_8() const { return ___setPiecePrefab_8; }
	inline SetPieceUI_t2352651354 ** get_address_of_setPiecePrefab_8() { return &___setPiecePrefab_8; }
	inline void set_setPiecePrefab_8(SetPieceUI_t2352651354 * value)
	{
		___setPiecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___setPiecePrefab_8, value);
	}

	inline static int32_t get_offset_of_clickMovePrefab_9() { return static_cast<int32_t>(offsetof(NoneRuleInputUI_t2976509132, ___clickMovePrefab_9)); }
	inline ClickMoveUI_t3073228577 * get_clickMovePrefab_9() const { return ___clickMovePrefab_9; }
	inline ClickMoveUI_t3073228577 ** get_address_of_clickMovePrefab_9() { return &___clickMovePrefab_9; }
	inline void set_clickMovePrefab_9(ClickMoveUI_t3073228577 * value)
	{
		___clickMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___clickMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_subContainer_10() { return static_cast<int32_t>(offsetof(NoneRuleInputUI_t2976509132, ___subContainer_10)); }
	inline Transform_t3275118058 * get_subContainer_10() const { return ___subContainer_10; }
	inline Transform_t3275118058 ** get_address_of_subContainer_10() { return &___subContainer_10; }
	inline void set_subContainer_10(Transform_t3275118058 * value)
	{
		___subContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
