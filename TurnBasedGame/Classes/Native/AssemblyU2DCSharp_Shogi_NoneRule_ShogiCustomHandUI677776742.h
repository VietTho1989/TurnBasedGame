#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1197896953.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.NoneRule.ShogiCustomHandUI
struct  ShogiCustomHandUI_t677776742  : public UIBehavior_1_t1197896953
{
public:
	// UnityEngine.UI.Image Shogi.NoneRule.ShogiCustomHandUI::imgHint
	Image_t2042527209 * ___imgHint_6;
	// UnityEngine.GameObject Shogi.NoneRule.ShogiCustomHandUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;
	// Shogi.ShogiGameDataUI/UIData Shogi.NoneRule.ShogiCustomHandUI::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_8;

public:
	inline static int32_t get_offset_of_imgHint_6() { return static_cast<int32_t>(offsetof(ShogiCustomHandUI_t677776742, ___imgHint_6)); }
	inline Image_t2042527209 * get_imgHint_6() const { return ___imgHint_6; }
	inline Image_t2042527209 ** get_address_of_imgHint_6() { return &___imgHint_6; }
	inline void set_imgHint_6(Image_t2042527209 * value)
	{
		___imgHint_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(ShogiCustomHandUI_t677776742, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_8() { return static_cast<int32_t>(offsetof(ShogiCustomHandUI_t677776742, ___shogiGameDataUIData_8)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_8() const { return ___shogiGameDataUIData_8; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_8() { return &___shogiGameDataUIData_8; }
	inline void set_shogiGameDataUIData_8(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
