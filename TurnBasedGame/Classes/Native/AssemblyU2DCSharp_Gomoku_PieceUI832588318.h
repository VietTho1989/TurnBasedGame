#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2554487709.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.UI.Text
struct Text_t356221433;
// Gomoku.BoardUI/UIData
struct UIData_t2020820277;
// GameDataBoardCheckPerspectiveChange`1<Gomoku.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t1514841157;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.PieceUI
struct  PieceUI_t832588318  : public UIBehavior_1_t2554487709
{
public:
	// UnityEngine.GameObject Gomoku.PieceUI::activeContainer
	GameObject_t1756533147 * ___activeContainer_6;
	// UnityEngine.UI.Image Gomoku.PieceUI::imgStone
	Image_t2042527209 * ___imgStone_7;
	// UnityEngine.UI.Text Gomoku.PieceUI::tvLastMoveIndex
	Text_t356221433 * ___tvLastMoveIndex_8;
	// UnityEngine.UI.Image Gomoku.PieceUI::imgWinCoord
	Image_t2042527209 * ___imgWinCoord_9;
	// Gomoku.BoardUI/UIData Gomoku.PieceUI::boardUIData
	UIData_t2020820277 * ___boardUIData_10;
	// GameDataBoardCheckPerspectiveChange`1<Gomoku.PieceUI/UIData> Gomoku.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t1514841157 * ___perspectiveChange_11;

public:
	inline static int32_t get_offset_of_activeContainer_6() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___activeContainer_6)); }
	inline GameObject_t1756533147 * get_activeContainer_6() const { return ___activeContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_activeContainer_6() { return &___activeContainer_6; }
	inline void set_activeContainer_6(GameObject_t1756533147 * value)
	{
		___activeContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___activeContainer_6, value);
	}

	inline static int32_t get_offset_of_imgStone_7() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___imgStone_7)); }
	inline Image_t2042527209 * get_imgStone_7() const { return ___imgStone_7; }
	inline Image_t2042527209 ** get_address_of_imgStone_7() { return &___imgStone_7; }
	inline void set_imgStone_7(Image_t2042527209 * value)
	{
		___imgStone_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgStone_7, value);
	}

	inline static int32_t get_offset_of_tvLastMoveIndex_8() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___tvLastMoveIndex_8)); }
	inline Text_t356221433 * get_tvLastMoveIndex_8() const { return ___tvLastMoveIndex_8; }
	inline Text_t356221433 ** get_address_of_tvLastMoveIndex_8() { return &___tvLastMoveIndex_8; }
	inline void set_tvLastMoveIndex_8(Text_t356221433 * value)
	{
		___tvLastMoveIndex_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvLastMoveIndex_8, value);
	}

	inline static int32_t get_offset_of_imgWinCoord_9() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___imgWinCoord_9)); }
	inline Image_t2042527209 * get_imgWinCoord_9() const { return ___imgWinCoord_9; }
	inline Image_t2042527209 ** get_address_of_imgWinCoord_9() { return &___imgWinCoord_9; }
	inline void set_imgWinCoord_9(Image_t2042527209 * value)
	{
		___imgWinCoord_9 = value;
		Il2CppCodeGenWriteBarrier(&___imgWinCoord_9, value);
	}

	inline static int32_t get_offset_of_boardUIData_10() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___boardUIData_10)); }
	inline UIData_t2020820277 * get_boardUIData_10() const { return ___boardUIData_10; }
	inline UIData_t2020820277 ** get_address_of_boardUIData_10() { return &___boardUIData_10; }
	inline void set_boardUIData_10(UIData_t2020820277 * value)
	{
		___boardUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___boardUIData_10, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_11() { return static_cast<int32_t>(offsetof(PieceUI_t832588318, ___perspectiveChange_11)); }
	inline GameDataBoardCheckPerspectiveChange_1_t1514841157 * get_perspectiveChange_11() const { return ___perspectiveChange_11; }
	inline GameDataBoardCheckPerspectiveChange_1_t1514841157 ** get_address_of_perspectiveChange_11() { return &___perspectiveChange_11; }
	inline void set_perspectiveChange_11(GameDataBoardCheckPerspectiveChange_1_t1514841157 * value)
	{
		___perspectiveChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
