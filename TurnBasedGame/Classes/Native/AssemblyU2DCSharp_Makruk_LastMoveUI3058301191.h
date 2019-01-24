#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3953841003.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// Makruk.MakrukMoveUI
struct MakrukMoveUI_t468248000;
// Makruk.NoneRule.MakrukCustomSetUI
struct MakrukCustomSetUI_t551211256;
// Makruk.NoneRule.MakrukCustomMoveUI
struct MakrukCustomMoveUI_t673197805;
// LastMoveCheckChange`1<Makruk.LastMoveUI/UIData>
struct LastMoveCheckChange_1_t3557208920;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.LastMoveUI
struct  LastMoveUI_t3058301191  : public UIBehavior_1_t3953841003
{
public:
	// UnityEngine.Transform Makruk.LastMoveUI::contentContainer
	Transform_t3275118058 * ___contentContainer_6;
	// Makruk.MakrukMoveUI Makruk.LastMoveUI::makrukMovePrefab
	MakrukMoveUI_t468248000 * ___makrukMovePrefab_7;
	// Makruk.NoneRule.MakrukCustomSetUI Makruk.LastMoveUI::makrukCustomSetPrefab
	MakrukCustomSetUI_t551211256 * ___makrukCustomSetPrefab_8;
	// Makruk.NoneRule.MakrukCustomMoveUI Makruk.LastMoveUI::makrukCustomMovePrefab
	MakrukCustomMoveUI_t673197805 * ___makrukCustomMovePrefab_9;
	// LastMoveCheckChange`1<Makruk.LastMoveUI/UIData> Makruk.LastMoveUI::lastMoveCheckChange
	LastMoveCheckChange_1_t3557208920 * ___lastMoveCheckChange_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LastMoveUI_t3058301191, ___contentContainer_6)); }
	inline Transform_t3275118058 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(Transform_t3275118058 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_makrukMovePrefab_7() { return static_cast<int32_t>(offsetof(LastMoveUI_t3058301191, ___makrukMovePrefab_7)); }
	inline MakrukMoveUI_t468248000 * get_makrukMovePrefab_7() const { return ___makrukMovePrefab_7; }
	inline MakrukMoveUI_t468248000 ** get_address_of_makrukMovePrefab_7() { return &___makrukMovePrefab_7; }
	inline void set_makrukMovePrefab_7(MakrukMoveUI_t468248000 * value)
	{
		___makrukMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___makrukMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_makrukCustomSetPrefab_8() { return static_cast<int32_t>(offsetof(LastMoveUI_t3058301191, ___makrukCustomSetPrefab_8)); }
	inline MakrukCustomSetUI_t551211256 * get_makrukCustomSetPrefab_8() const { return ___makrukCustomSetPrefab_8; }
	inline MakrukCustomSetUI_t551211256 ** get_address_of_makrukCustomSetPrefab_8() { return &___makrukCustomSetPrefab_8; }
	inline void set_makrukCustomSetPrefab_8(MakrukCustomSetUI_t551211256 * value)
	{
		___makrukCustomSetPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___makrukCustomSetPrefab_8, value);
	}

	inline static int32_t get_offset_of_makrukCustomMovePrefab_9() { return static_cast<int32_t>(offsetof(LastMoveUI_t3058301191, ___makrukCustomMovePrefab_9)); }
	inline MakrukCustomMoveUI_t673197805 * get_makrukCustomMovePrefab_9() const { return ___makrukCustomMovePrefab_9; }
	inline MakrukCustomMoveUI_t673197805 ** get_address_of_makrukCustomMovePrefab_9() { return &___makrukCustomMovePrefab_9; }
	inline void set_makrukCustomMovePrefab_9(MakrukCustomMoveUI_t673197805 * value)
	{
		___makrukCustomMovePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___makrukCustomMovePrefab_9, value);
	}

	inline static int32_t get_offset_of_lastMoveCheckChange_10() { return static_cast<int32_t>(offsetof(LastMoveUI_t3058301191, ___lastMoveCheckChange_10)); }
	inline LastMoveCheckChange_1_t3557208920 * get_lastMoveCheckChange_10() const { return ___lastMoveCheckChange_10; }
	inline LastMoveCheckChange_1_t3557208920 ** get_address_of_lastMoveCheckChange_10() { return &___lastMoveCheckChange_10; }
	inline void set_lastMoveCheckChange_10(LastMoveCheckChange_1_t3557208920 * value)
	{
		___lastMoveCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___lastMoveCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
