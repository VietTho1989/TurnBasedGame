#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen51549987.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// CoTuongUp.BoardUI/UIData
struct UIData_t1123630175;
// GameDataBoardCheckPerspectiveChange`1<CoTuongUp.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3306870731;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.PieceUI
struct  PieceUI_t542454310  : public UIBehavior_1_t51549987
{
public:
	// UnityEngine.UI.Image CoTuongUp.PieceUI::img
	Image_t2042527209 * ___img_6;
	// UnityEngine.GameObject CoTuongUp.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_7;
	// CoTuongUp.BoardUI/UIData CoTuongUp.PieceUI::boardUIData
	UIData_t1123630175 * ___boardUIData_8;
	// GameDataBoardCheckPerspectiveChange`1<CoTuongUp.PieceUI/UIData> CoTuongUp.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3306870731 * ___perspectiveChange_9;

public:
	inline static int32_t get_offset_of_img_6() { return static_cast<int32_t>(offsetof(PieceUI_t542454310, ___img_6)); }
	inline Image_t2042527209 * get_img_6() const { return ___img_6; }
	inline Image_t2042527209 ** get_address_of_img_6() { return &___img_6; }
	inline void set_img_6(Image_t2042527209 * value)
	{
		___img_6 = value;
		Il2CppCodeGenWriteBarrier(&___img_6, value);
	}

	inline static int32_t get_offset_of_contentContainer_7() { return static_cast<int32_t>(offsetof(PieceUI_t542454310, ___contentContainer_7)); }
	inline GameObject_t1756533147 * get_contentContainer_7() const { return ___contentContainer_7; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_7() { return &___contentContainer_7; }
	inline void set_contentContainer_7(GameObject_t1756533147 * value)
	{
		___contentContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_7, value);
	}

	inline static int32_t get_offset_of_boardUIData_8() { return static_cast<int32_t>(offsetof(PieceUI_t542454310, ___boardUIData_8)); }
	inline UIData_t1123630175 * get_boardUIData_8() const { return ___boardUIData_8; }
	inline UIData_t1123630175 ** get_address_of_boardUIData_8() { return &___boardUIData_8; }
	inline void set_boardUIData_8(UIData_t1123630175 * value)
	{
		___boardUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___boardUIData_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(PieceUI_t542454310, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3306870731 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t3306870731 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t3306870731 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
