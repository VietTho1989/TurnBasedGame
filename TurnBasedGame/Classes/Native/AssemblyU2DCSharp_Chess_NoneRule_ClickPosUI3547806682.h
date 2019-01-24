#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2705889121.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.UI.Button
struct Button_t2872111280;
// GameDataBoardCheckPerspectiveChange`1<Chess.NoneRule.ClickPosUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t1666242569;
// Chess.NoneRuleInputUI/UIData
struct UIData_t960065731;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.NoneRule.ClickPosUI
struct  ClickPosUI_t3547806682  : public UIBehavior_1_t2705889121
{
public:
	// UnityEngine.UI.Image Chess.NoneRule.ClickPosUI::imgSelect
	Image_t2042527209 * ___imgSelect_6;
	// UnityEngine.Transform Chess.NoneRule.ClickPosUI::contentContainer
	Transform_t3275118058 * ___contentContainer_7;
	// UnityEngine.UI.Button Chess.NoneRule.ClickPosUI::btnMove
	Button_t2872111280 * ___btnMove_8;
	// GameDataBoardCheckPerspectiveChange`1<Chess.NoneRule.ClickPosUI/UIData> Chess.NoneRule.ClickPosUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t1666242569 * ___perspectiveChange_9;
	// Chess.NoneRuleInputUI/UIData Chess.NoneRule.ClickPosUI::noneRuleInputUIData
	UIData_t960065731 * ___noneRuleInputUIData_10;

public:
	inline static int32_t get_offset_of_imgSelect_6() { return static_cast<int32_t>(offsetof(ClickPosUI_t3547806682, ___imgSelect_6)); }
	inline Image_t2042527209 * get_imgSelect_6() const { return ___imgSelect_6; }
	inline Image_t2042527209 ** get_address_of_imgSelect_6() { return &___imgSelect_6; }
	inline void set_imgSelect_6(Image_t2042527209 * value)
	{
		___imgSelect_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgSelect_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(ClickPosUI_t3547806682, ___contentContainer_7)); }
	inline Transform_t3275118058 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline Transform_t3275118058 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(Transform_t3275118058 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_btnMove_8() { return static_cast<int32_t>(offsetof(ClickPosUI_t3547806682, ___btnMove_8)); }
	inline Button_t2872111280 * get_btnMove_8() const { return ___btnMove_8; }
	inline Button_t2872111280 ** get_address_of_btnMove_8() { return &___btnMove_8; }
	inline void set_btnMove_8(Button_t2872111280 * value)
	{
		___btnMove_8 = value;
		Il2CppCodeGenWriteBarrier(&___btnMove_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(ClickPosUI_t3547806682, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t1666242569 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t1666242569 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t1666242569 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}

	inline static int32_t get_offset_of_noneRuleInputUIData_10() { return static_cast<int32_t>(offsetof(ClickPosUI_t3547806682, ___noneRuleInputUIData_10)); }
	inline UIData_t960065731 * get_noneRuleInputUIData_10() const { return ___noneRuleInputUIData_10; }
	inline UIData_t960065731 ** get_address_of_noneRuleInputUIData_10() { return &___noneRuleInputUIData_10; }
	inline void set_noneRuleInputUIData_10(UIData_t960065731 * value)
	{
		___noneRuleInputUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___noneRuleInputUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
