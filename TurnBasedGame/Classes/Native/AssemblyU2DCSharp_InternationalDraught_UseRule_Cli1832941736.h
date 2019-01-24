#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3610429701.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// InternationalDraught.UseRule.LegalMoveUI
struct LegalMoveUI_t1709845832;
// InternationalDraught.UseRule.ClickDestUI/UIData
struct UIData_t2285002083;
// InternationalDraught.UseRule.ShowUI/UIData
struct UIData_t1101430890;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.UseRule.ClickDestClickUI
struct  ClickDestClickUI_t1832941736  : public UIBehavior_1_t3610429701
{
public:
	// UnityEngine.UI.Image InternationalDraught.UseRule.ClickDestClickUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// InternationalDraught.UseRule.LegalMoveUI InternationalDraught.UseRule.ClickDestClickUI::legalMovePrefab
	LegalMoveUI_t1709845832 * ___legalMovePrefab_7;
	// InternationalDraught.UseRule.ClickDestUI/UIData InternationalDraught.UseRule.ClickDestClickUI::clickDestUIData
	UIData_t2285002083 * ___clickDestUIData_8;
	// InternationalDraught.UseRule.ShowUI/UIData InternationalDraught.UseRule.ClickDestClickUI::show
	UIData_t1101430890 * ___show_9;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1832941736, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_legalMovePrefab_7() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1832941736, ___legalMovePrefab_7)); }
	inline LegalMoveUI_t1709845832 * get_legalMovePrefab_7() const { return ___legalMovePrefab_7; }
	inline LegalMoveUI_t1709845832 ** get_address_of_legalMovePrefab_7() { return &___legalMovePrefab_7; }
	inline void set_legalMovePrefab_7(LegalMoveUI_t1709845832 * value)
	{
		___legalMovePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalMovePrefab_7, value);
	}

	inline static int32_t get_offset_of_clickDestUIData_8() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1832941736, ___clickDestUIData_8)); }
	inline UIData_t2285002083 * get_clickDestUIData_8() const { return ___clickDestUIData_8; }
	inline UIData_t2285002083 ** get_address_of_clickDestUIData_8() { return &___clickDestUIData_8; }
	inline void set_clickDestUIData_8(UIData_t2285002083 * value)
	{
		___clickDestUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___clickDestUIData_8, value);
	}

	inline static int32_t get_offset_of_show_9() { return static_cast<int32_t>(offsetof(ClickDestClickUI_t1832941736, ___show_9)); }
	inline UIData_t1101430890 * get_show_9() const { return ___show_9; }
	inline UIData_t1101430890 ** get_address_of_show_9() { return &___show_9; }
	inline void set_show_9(UIData_t1101430890 * value)
	{
		___show_9 = value;
		Il2CppCodeGenWriteBarrier(&___show_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
