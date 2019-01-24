#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3260769785.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// FairyChess.FairyChessGameDataUI/UIData
struct UIData_t3976046997;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.NoneRule.FairyChessCustomHandUI
struct  FairyChessCustomHandUI_t1973079333  : public UIBehavior_1_t3260769785
{
public:
	// UnityEngine.UI.Image FairyChess.NoneRule.FairyChessCustomHandUI::imgHint
	Image_t2042527209 * ___imgHint_6;
	// UnityEngine.GameObject FairyChess.NoneRule.FairyChessCustomHandUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;
	// FairyChess.FairyChessGameDataUI/UIData FairyChess.NoneRule.FairyChessCustomHandUI::fairyChessGameDataUIData
	UIData_t3976046997 * ___fairyChessGameDataUIData_8;

public:
	inline static int32_t get_offset_of_imgHint_6() { return static_cast<int32_t>(offsetof(FairyChessCustomHandUI_t1973079333, ___imgHint_6)); }
	inline Image_t2042527209 * get_imgHint_6() const { return ___imgHint_6; }
	inline Image_t2042527209 ** get_address_of_imgHint_6() { return &___imgHint_6; }
	inline void set_imgHint_6(Image_t2042527209 * value)
	{
		___imgHint_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(FairyChessCustomHandUI_t1973079333, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_fairyChessGameDataUIData_8() { return static_cast<int32_t>(offsetof(FairyChessCustomHandUI_t1973079333, ___fairyChessGameDataUIData_8)); }
	inline UIData_t3976046997 * get_fairyChessGameDataUIData_8() const { return ___fairyChessGameDataUIData_8; }
	inline UIData_t3976046997 ** get_address_of_fairyChessGameDataUIData_8() { return &___fairyChessGameDataUIData_8; }
	inline void set_fairyChessGameDataUIData_8(UIData_t3976046997 * value)
	{
		___fairyChessGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___fairyChessGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
