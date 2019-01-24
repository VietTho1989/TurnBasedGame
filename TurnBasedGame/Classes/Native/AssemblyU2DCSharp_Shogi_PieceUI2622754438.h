#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3504347243.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;
// GameDataBoardCheckPerspectiveChange`1<Shogi.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2464700691;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.PieceUI
struct  PieceUI_t2622754438  : public UIBehavior_1_t3504347243
{
public:
	// UnityEngine.UI.Image Shogi.PieceUI::image
	Image_t2042527209 * ___image_6;
	// Shogi.ShogiGameDataUI/UIData Shogi.PieceUI::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_7;
	// GameDataBoardCheckPerspectiveChange`1<Shogi.PieceUI/UIData> Shogi.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2464700691 * ___perspectiveChange_8;

public:
	inline static int32_t get_offset_of_image_6() { return static_cast<int32_t>(offsetof(PieceUI_t2622754438, ___image_6)); }
	inline Image_t2042527209 * get_image_6() const { return ___image_6; }
	inline Image_t2042527209 ** get_address_of_image_6() { return &___image_6; }
	inline void set_image_6(Image_t2042527209 * value)
	{
		___image_6 = value;
		Il2CppCodeGenWriteBarrier(&___image_6, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_7() { return static_cast<int32_t>(offsetof(PieceUI_t2622754438, ___shogiGameDataUIData_7)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_7() const { return ___shogiGameDataUIData_7; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_7() { return &___shogiGameDataUIData_7; }
	inline void set_shogiGameDataUIData_7(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(PieceUI_t2622754438, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2464700691 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t2464700691 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t2464700691 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
