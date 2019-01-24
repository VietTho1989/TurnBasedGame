#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen27113957.h"

// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.Transform
struct Transform_t3275118058;
// GameDataBoardCheckPerspectiveChange`1<FairyChess.HandPieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t3282434701;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.HandPieceUI
struct  HandPieceUI_t904353653  : public UIBehavior_1_t27113957
{
public:
	// UnityEngine.UI.Image FairyChess.HandPieceUI::imgPiece
	Image_t2042527209 * ___imgPiece_6;
	// UnityEngine.UI.Text FairyChess.HandPieceUI::txtCount
	Text_t356221433 * ___txtCount_7;
	// UnityEngine.Transform FairyChess.HandPieceUI::handMoveContainer
	Transform_t3275118058 * ___handMoveContainer_8;
	// GameDataBoardCheckPerspectiveChange`1<FairyChess.HandPieceUI/UIData> FairyChess.HandPieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t3282434701 * ___perspectiveChange_9;

public:
	inline static int32_t get_offset_of_imgPiece_6() { return static_cast<int32_t>(offsetof(HandPieceUI_t904353653, ___imgPiece_6)); }
	inline Image_t2042527209 * get_imgPiece_6() const { return ___imgPiece_6; }
	inline Image_t2042527209 ** get_address_of_imgPiece_6() { return &___imgPiece_6; }
	inline void set_imgPiece_6(Image_t2042527209 * value)
	{
		___imgPiece_6 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_6, value);
	}

	inline static int32_t get_offset_of_txtCount_7() { return static_cast<int32_t>(offsetof(HandPieceUI_t904353653, ___txtCount_7)); }
	inline Text_t356221433 * get_txtCount_7() const { return ___txtCount_7; }
	inline Text_t356221433 ** get_address_of_txtCount_7() { return &___txtCount_7; }
	inline void set_txtCount_7(Text_t356221433 * value)
	{
		___txtCount_7 = value;
		Il2CppCodeGenWriteBarrier(&___txtCount_7, value);
	}

	inline static int32_t get_offset_of_handMoveContainer_8() { return static_cast<int32_t>(offsetof(HandPieceUI_t904353653, ___handMoveContainer_8)); }
	inline Transform_t3275118058 * get_handMoveContainer_8() const { return ___handMoveContainer_8; }
	inline Transform_t3275118058 ** get_address_of_handMoveContainer_8() { return &___handMoveContainer_8; }
	inline void set_handMoveContainer_8(Transform_t3275118058 * value)
	{
		___handMoveContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___handMoveContainer_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(HandPieceUI_t904353653, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t3282434701 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t3282434701 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t3282434701 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
