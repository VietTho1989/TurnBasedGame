#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1761466568.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Chess.UseRule.LegalMoveUI
struct LegalMoveUI_t640540300;
// Chess.UseRule.ClickDestClickMoveOrChooseUI
struct ClickDestClickMoveOrChooseUI_t3293133097;
// Chess.UseRule.ClickDestUI/UIData
struct UIData_t1534712046;
// Chess.UseRule.ShowUI/UIData
struct UIData_t3752262345;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.UseRule.ClickDestClickUI
struct  ClickDestClickUI_t3652416100  : public UIBehavior_1_t1761466568
{
public:
	// UnityEngine.UI.Image Chess.UseRule.ClickDestClickUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// Chess.UseRule.LegalMoveUI Chess.UseRule.ClickDestClickUI::legalMovePrefab
	LegalMoveUI_t640540300 * ___legalMovePrefab_7;
	// Chess.UseRule.ClickDestClickMoveOrChooseUI Chess.UseRule.ClickDestClickUI::moveOrChoosePrefab
	ClickDestClickMoveOrChooseUI_t3293133097 * ___moveOrChoosePrefab_8;
	// Chess.UseRule.ClickDestUI/UIData Chess.UseRule.ClickDestClickUI::clickDestUIData
	UIData_t1534712046 * ___clickDestUIData_9;
	// Chess.UseRule.ShowUI/UIData Chess.UseRule.ClickDestClickUI::show
	UIData_t3752262345 * ___show_10;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3652416100, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3652416100, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t640540300 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t640540300 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t640540300 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_moveOrChoosePrefab_8() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3652416100, ___moveOrChoosePrefab_8)); }
	inline ClickDestClickMoveOrChooseUI_t3293133097 * get_moveOrChoosePrefab_8() const { return ___moveOrChoosePrefab_8; }
	inline ClickDestClickMoveOrChooseUI_t3293133097 ** get_address_of_moveOrChoosePrefab_8() { return &___moveOrChoosePrefab_8; }
	inline void set_moveOrChoosePrefab_8(ClickDestClickMoveOrChooseUI_t3293133097 * value)
	{
		___moveOrChoosePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___moveOrChoosePrefab_8, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_9() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3652416100, ___clickDestUIData_9)); }
	inline UIData_t1534712046 * get_clickDestUIData_9() const { return ___clickDestUIData_9; }
	inline UIData_t1534712046 ** get_address_of_clickDestUIData_9() { return &___clickDestUIData_9; }
	inline void set_clickDestUIData_9(UIData_t1534712046 * value)
	{
		___clickDestUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_9, value);
	}

	inline static int32_t get_offset_of_show_10() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t3652416100, ___show_10)); }
	inline UIData_t3752262345 * get_show_10() const { return ___show_10; }
	inline UIData_t3752262345 ** get_address_of_show_10() { return &___show_10; }
	inline void set_show_10(UIData_t3752262345 * value)
	{
		___show_10 = value;
		Il2CppCodeGenWriteBarrier(&___show_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
