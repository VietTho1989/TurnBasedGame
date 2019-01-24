#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4217465994.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Image
struct Image_t2042527209;
// HEX.BoardUI/UIData
struct UIData_t3072543816;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.PieceUI
struct  PieceUI_t1788896792  : public UIBehavior_1_t4217465994
{
public:
	// UnityEngine.GameObject HEX.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Image HEX.PieceUI::imgPiece
	Image_t2042527209 * ___imgPiece_7;
	// HEX.BoardUI/UIData HEX.PieceUI::boardUIData
	UIData_t3072543816 * ___boardUIData_8;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(PieceUI_t1788896792, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_imgPiece_7() { return static_cast<int32_t>(offsetof(PieceUI_t1788896792, ___imgPiece_7)); }
	inline Image_t2042527209 * get_imgPiece_7() const { return ___imgPiece_7; }
	inline Image_t2042527209 ** get_address_of_imgPiece_7() { return &___imgPiece_7; }
	inline void set_imgPiece_7(Image_t2042527209 * value)
	{
		___imgPiece_7 = value;
		Il2CppCodeGenWriteBarrier(&___imgPiece_7, value);
	}

	inline static int32_t get_offset_of_boardUIData_8() { return static_cast<int32_t>(offsetof(PieceUI_t1788896792, ___boardUIData_8)); }
	inline UIData_t3072543816 * get_boardUIData_8() const { return ___boardUIData_8; }
	inline UIData_t3072543816 ** get_address_of_boardUIData_8() { return &___boardUIData_8; }
	inline void set_boardUIData_8(UIData_t3072543816 * value)
	{
		___boardUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___boardUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
