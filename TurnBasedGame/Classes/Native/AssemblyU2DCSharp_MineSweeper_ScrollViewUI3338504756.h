#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2203490327.h"

// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// UnityEngine.Transform
struct Transform_t3275118058;
// MineSweeper.BoardUI/UIData
struct UIData_t4134355993;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.ScrollViewUI
struct  ScrollViewUI_t3338504756  : public UIBehavior_1_t2203490327
{
public:
	// System.Boolean MineSweeper.ScrollViewUI::needReset
	bool ___needReset_6;
	// RequestChangeFloatUI MineSweeper.ScrollViewUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_7;
	// UnityEngine.Transform MineSweeper.ScrollViewUI::xContainer
	Transform_t3275118058 * ___xContainer_8;
	// UnityEngine.Transform MineSweeper.ScrollViewUI::yContainer
	Transform_t3275118058 * ___yContainer_9;
	// MineSweeper.BoardUI/UIData MineSweeper.ScrollViewUI::boardUIData
	UIData_t4134355993 * ___boardUIData_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(ScrollViewUI_t3338504756, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_requestFloatPrefab_7() { return static_cast<int32_t>(offsetof(ScrollViewUI_t3338504756, ___requestFloatPrefab_7)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_7() const { return ___requestFloatPrefab_7; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_7() { return &___requestFloatPrefab_7; }
	inline void set_requestFloatPrefab_7(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_7, value);
	}

	inline static int32_t get_offset_of_xContainer_8() { return static_cast<int32_t>(offsetof(ScrollViewUI_t3338504756, ___xContainer_8)); }
	inline Transform_t3275118058 * get_xContainer_8() const { return ___xContainer_8; }
	inline Transform_t3275118058 ** get_address_of_xContainer_8() { return &___xContainer_8; }
	inline void set_xContainer_8(Transform_t3275118058 * value)
	{
		___xContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___xContainer_8, value);
	}

	inline static int32_t get_offset_of_yContainer_9() { return static_cast<int32_t>(offsetof(ScrollViewUI_t3338504756, ___yContainer_9)); }
	inline Transform_t3275118058 * get_yContainer_9() const { return ___yContainer_9; }
	inline Transform_t3275118058 ** get_address_of_yContainer_9() { return &___yContainer_9; }
	inline void set_yContainer_9(Transform_t3275118058 * value)
	{
		___yContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___yContainer_9, value);
	}

	inline static int32_t get_offset_of_boardUIData_10() { return static_cast<int32_t>(offsetof(ScrollViewUI_t3338504756, ___boardUIData_10)); }
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
