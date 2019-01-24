#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1619974914.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<EnglishDraught.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t580328362;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.PieceUI
struct  PieceUI_t4135479008  : public UIBehavior_1_t1619974914
{
public:
	// UnityEngine.GameObject EnglishDraught.PieceUI::activeContent
	GameObject_t1756533147 * ___activeContent_6;
	// UnityEngine.UI.Image EnglishDraught.PieceUI::imgPiece
	Image_t2042527209 * ___imgPiece_7;
	// GameDataBoardCheckPerspectiveChange`1<EnglishDraught.PieceUI/UIData> EnglishDraught.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t580328362 * ___perspectiveChange_8;

public:
	inline static int32_t get_offset_of_activeContent_6() { return static_cast<int32_t>(offsetof(PieceUI_t4135479008, ___activeContent_6)); }
	inline GameObject_t1756533147 * get_activeContent_6() const { return ___activeContent_6; }
	inline GameObject_t1756533147 ** get_address_of_activeContent_6() { return &___activeContent_6; }
	inline void set_activeContent_6(GameObject_t1756533147 * value)
	{
		___activeContent_6 = value;
		Il2CppCodeGenWriteBarrier(&___activeContent_6, value);
	}

	inline static int32_t get_offset_of_imgPiece_7() { return static_cast<int32_t>(offsetof(PieceUI_t4135479008, ___imgPiece_7)); }
	inline Image_t2042527209 * get_imgPiece_7() const { return ___imgPiece_7; }
	inline Image_t2042527209 ** get_address_of_imgPiece_7() { return &___imgPiece_7; }
	inline void set_imgPiece_7(Image_t2042527209 * value)
	{
		___imgPiece_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_7, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_8() { return static_cast<int32_t>(offsetof(PieceUI_t4135479008, ___perspectiveChange_8)); }
	inline GameDataBoardCheckPerspectiveChange_1_t580328362 * get_perspectiveChange_8() const { return ___perspectiveChange_8; }
	inline GameDataBoardCheckPerspectiveChange_1_t580328362 ** get_address_of_perspectiveChange_8() { return &___perspectiveChange_8; }
	inline void set_perspectiveChange_8(GameDataBoardCheckPerspectiveChange_1_t580328362 * value)
	{
		___perspectiveChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
