﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3700949878.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<InternationalDraught.PieceUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t2661303326;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.PieceUI
struct  PieceUI_t2252431856  : public UIBehavior_1_t3700949878
{
public:
	// UnityEngine.GameObject InternationalDraught.PieceUI::activeContent
	GameObject_t1756533147 * ___activeContent_6;
	// UnityEngine.UI.Image InternationalDraught.PieceUI::imgPieceSide
	Image_t2042527209 * ___imgPieceSide_7;
	// UnityEngine.UI.Image InternationalDraught.PieceUI::imgLastCapture
	Image_t2042527209 * ___imgLastCapture_8;
	// GameDataBoardCheckPerspectiveChange`1<InternationalDraught.PieceUI/UIData> InternationalDraught.PieceUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t2661303326 * ___perspectiveChange_9;

public:
	inline static int32_t get_offset_of_activeContent_6() { return static_cast<int32_t>(offsetof(PieceUI_t2252431856, ___activeContent_6)); }
	inline GameObject_t1756533147 * get_activeContent_6() const { return ___activeContent_6; }
	inline GameObject_t1756533147 ** get_address_of_activeContent_6() { return &___activeContent_6; }
	inline void set_activeContent_6(GameObject_t1756533147 * value)
	{
		___activeContent_6 = value;
		Il2CppCodeGenWriteBarrier(&___activeContent_6, value);
	}

	inline static int32_t get_offset_of_imgPieceSide_7() { return static_cast<int32_t>(offsetof(PieceUI_t2252431856, ___imgPieceSide_7)); }
	inline Image_t2042527209 * get_imgPieceSide_7() const { return ___imgPieceSide_7; }
	inline Image_t2042527209 ** get_address_of_imgPieceSide_7() { return &___imgPieceSide_7; }
	inline void set_imgPieceSide_7(Image_t2042527209 * value)
	{
		___imgPieceSide_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgPieceSide_7, value);
	}

	inline static int32_t get_offset_of_imgLastCapture_8() { return static_cast<int32_t>(offsetof(PieceUI_t2252431856, ___imgLastCapture_8)); }
	inline Image_t2042527209 * get_imgLastCapture_8() const { return ___imgLastCapture_8; }
	inline Image_t2042527209 ** get_address_of_imgLastCapture_8() { return &___imgLastCapture_8; }
	inline void set_imgLastCapture_8(Image_t2042527209 * value)
	{
		___imgLastCapture_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgLastCapture_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(PieceUI_t2252431856, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t2661303326 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t2661303326 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t2661303326 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif