#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2998370599.h"

// UnityEngine.RectTransform
struct RectTransform_t3349966182;
// MineSweeper.BoardUI/UIData
struct UIData_t4134355993;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.BoundaryUI
struct  BoundaryUI_t1901979134  : public UIBehavior_1_t2998370599
{
public:
	// UnityEngine.RectTransform MineSweeper.BoundaryUI::left
	RectTransform_t3349966182 * ___left_6;
	// UnityEngine.RectTransform MineSweeper.BoundaryUI::right
	RectTransform_t3349966182 * ___right_7;
	// UnityEngine.RectTransform MineSweeper.BoundaryUI::top
	RectTransform_t3349966182 * ___top_8;
	// UnityEngine.RectTransform MineSweeper.BoundaryUI::bottom
	RectTransform_t3349966182 * ___bottom_9;
	// MineSweeper.BoardUI/UIData MineSweeper.BoundaryUI::boardUIData
	UIData_t4134355993 * ___boardUIData_10;

public:
	inline static int32_t get_offset_of_left_6() { return static_cast<int32_t>(offsetof(BoundaryUI_t1901979134, ___left_6)); }
	inline RectTransform_t3349966182 * get_left_6() const { return ___left_6; }
	inline RectTransform_t3349966182 ** get_address_of_left_6() { return &___left_6; }
	inline void set_left_6(RectTransform_t3349966182 * value)
	{
		___left_6 = value;
		Il2CppCodeGenWriteBarrier(&___left_6, value);
	}

	inline static int32_t get_offset_of_right_7() { return static_cast<int32_t>(offsetof(BoundaryUI_t1901979134, ___right_7)); }
	inline RectTransform_t3349966182 * get_right_7() const { return ___right_7; }
	inline RectTransform_t3349966182 ** get_address_of_right_7() { return &___right_7; }
	inline void set_right_7(RectTransform_t3349966182 * value)
	{
		___right_7 = value;
		Il2CppCodeGenWriteBarrier(&___right_7, value);
	}

	inline static int32_t get_offset_of_top_8() { return static_cast<int32_t>(offsetof(BoundaryUI_t1901979134, ___top_8)); }
	inline RectTransform_t3349966182 * get_top_8() const { return ___top_8; }
	inline RectTransform_t3349966182 ** get_address_of_top_8() { return &___top_8; }
	inline void set_top_8(RectTransform_t3349966182 * value)
	{
		___top_8 = value;
		Il2CppCodeGenWriteBarrier(&___top_8, value);
	}

	inline static int32_t get_offset_of_bottom_9() { return static_cast<int32_t>(offsetof(BoundaryUI_t1901979134, ___bottom_9)); }
	inline RectTransform_t3349966182 * get_bottom_9() const { return ___bottom_9; }
	inline RectTransform_t3349966182 ** get_address_of_bottom_9() { return &___bottom_9; }
	inline void set_bottom_9(RectTransform_t3349966182 * value)
	{
		___bottom_9 = value;
		Il2CppCodeGenWriteBarrier(&___bottom_9, value);
	}

	inline static int32_t get_offset_of_boardUIData_10() { return static_cast<int32_t>(offsetof(BoundaryUI_t1901979134, ___boardUIData_10)); }
	inline UIData_t4134355993 * get_boardUIData_10() const { return ___boardUIData_10; }
	inline UIData_t4134355993 ** get_address_of_boardUIData_10() { return &___boardUIData_10; }
	inline void set_boardUIData_10(UIData_t4134355993 * value)
	{
		___boardUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___boardUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
