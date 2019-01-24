#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen871468112.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// Shogi.ShogiGameDataUI/UIData
struct UIData_t2555805633;
// GameDataBoardCheckPerspectiveChange`1<Shogi.HandPieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t4126788856;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.HandPieceUI
struct  HandPieceUI_t1821181595  : public UIBehavior_1_t871468112
{
public:
	// UnityEngine.Transform Shogi.HandPieceUI::shogiCustomHandContainer
	Transform_t3275118058 * ___shogiCustomHandContainer_6;
	// UnityEngine.UI.Image Shogi.HandPieceUI::imgPiece
	Image_t2042527209 * ___imgPiece_7;
	// UnityEngine.UI.Text Shogi.HandPieceUI::tvCount
	Text_t356221433 * ___tvCount_8;
	// Shogi.ShogiGameDataUI/UIData Shogi.HandPieceUI::shogiGameDataUIData
	UIData_t2555805633 * ___shogiGameDataUIData_9;
	// GameDataBoardCheckPerspectiveChange`1<Shogi.HandPieceUI/UIData> Shogi.HandPieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t4126788856 * ___perspectiveChange_10;

public:
	inline static int32_t get_offset_of_shogiCustomHandContainer_6() { return static_cast<int32_t>(offsetof(HandPieceUI_t1821181595, ___shogiCustomHandContainer_6)); }
	inline Transform_t3275118058 * get_shogiCustomHandContainer_6() const { return ___shogiCustomHandContainer_6; }
	inline Transform_t3275118058 ** get_address_of_shogiCustomHandContainer_6() { return &___shogiCustomHandContainer_6; }
	inline void set_shogiCustomHandContainer_6(Transform_t3275118058 * value)
	{
		___shogiCustomHandContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___shogiCustomHandContainer_6, value);
	}

	inline static int32_t get_offset_of_imgPiece_7() { return static_cast<int32_t>(offsetof(HandPieceUI_t1821181595, ___imgPiece_7)); }
	inline Image_t2042527209 * get_imgPiece_7() const { return ___imgPiece_7; }
	inline Image_t2042527209 ** get_address_of_imgPiece_7() { return &___imgPiece_7; }
	inline void set_imgPiece_7(Image_t2042527209 * value)
	{
		___imgPiece_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_7, value);
	}

	inline static int32_t get_offset_of_tvCount_8() { return static_cast<int32_t>(offsetof(HandPieceUI_t1821181595, ___tvCount_8)); }
	inline Text_t356221433 * get_tvCount_8() const { return ___tvCount_8; }
	inline Text_t356221433 ** get_address_of_tvCount_8() { return &___tvCount_8; }
	inline void set_tvCount_8(Text_t356221433 * value)
	{
		___tvCount_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvCount_8, value);
	}

	inline static int32_t get_offset_of_shogiGameDataUIData_9() { return static_cast<int32_t>(offsetof(HandPieceUI_t1821181595, ___shogiGameDataUIData_9)); }
	inline UIData_t2555805633 * get_shogiGameDataUIData_9() const { return ___shogiGameDataUIData_9; }
	inline UIData_t2555805633 ** get_address_of_shogiGameDataUIData_9() { return &___shogiGameDataUIData_9; }
	inline void set_shogiGameDataUIData_9(UIData_t2555805633 * value)
	{
		___shogiGameDataUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___shogiGameDataUIData_9, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_10() { return static_cast<int32_t>(offsetof(HandPieceUI_t1821181595, ___perspectiveChange_10)); }
	inline GameDataBoardCheckPerspectiveChange_1_t4126788856 * get_perspectiveChange_10() const { return ___perspectiveChange_10; }
	inline GameDataBoardCheckPerspectiveChange_1_t4126788856 ** get_address_of_perspectiveChange_10() { return &___perspectiveChange_10; }
	inline void set_perspectiveChange_10(GameDataBoardCheckPerspectiveChange_1_t4126788856 * value)
	{
		___perspectiveChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
