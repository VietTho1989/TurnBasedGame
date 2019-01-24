#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1137570685.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<Xiangqi.XiangqiPieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t97924133;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.XiangqiPieceUI
struct  XiangqiPieceUI_t4230850847  : public UIBehavior_1_t1137570685
{
public:
	// UnityEngine.UI.Image Xiangqi.XiangqiPieceUI::image
	Image_t2042527209 * ___image_6;
	// GameDataBoardCheckPerspectiveChange`1<Xiangqi.XiangqiPieceUI/UIData> Xiangqi.XiangqiPieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t97924133 * ___perspectiveChange_9;

public:
	inline static int32_t get_offset_of_image_6() { return static_cast<int32_t>(offsetof(XiangqiPieceUI_t4230850847, ___image_6)); }
	inline Image_t2042527209 * get_image_6() const { return ___image_6; }
	inline Image_t2042527209 ** get_address_of_image_6() { return &___image_6; }
	inline void set_image_6(Image_t2042527209 * value)
	{
		___image_6 = value;
		Il2CppCodeGenWriteBarrier(&___image_6, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(XiangqiPieceUI_t4230850847, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t97924133 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t97924133 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t97924133 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
