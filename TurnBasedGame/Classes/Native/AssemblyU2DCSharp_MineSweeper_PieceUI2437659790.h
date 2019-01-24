#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1314025097.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Image
struct Image_t2042527209;
// MineSweeper.BoardUI/UIData
struct UIData_t4134355993;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.PieceUI
struct  PieceUI_t2437659790  : public UIBehavior_1_t1314025097
{
public:
	// UnityEngine.GameObject MineSweeper.PieceUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.GameObject MineSweeper.PieceUI::piece
	GameObject_t1756533147 * ___piece_7;
	// UnityEngine.UI.Text MineSweeper.PieceUI::tvPiece
	Text_t356221433 * ___tvPiece_8;
	// UnityEngine.UI.Image MineSweeper.PieceUI::imgBomb
	Image_t2042527209 * ___imgBomb_9;
	// UnityEngine.GameObject MineSweeper.PieceUI::flag
	GameObject_t1756533147 * ___flag_10;
	// UnityEngine.Color MineSweeper.PieceUI::alphaColor
	Color_t2020392075  ___alphaColor_11;
	// MineSweeper.BoardUI/UIData MineSweeper.PieceUI::boardUIData
	UIData_t4134355993 * ___boardUIData_12;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_piece_7() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___piece_7)); }
	inline GameObject_t1756533147 * get_piece_7() const { return ___piece_7; }
	inline GameObject_t1756533147 ** get_address_of_piece_7() { return &___piece_7; }
	inline void set_piece_7(GameObject_t1756533147 * value)
	{
		___piece_7 = value;
		Il2CppCodeGenWriteBarrier(&___piece_7, value);
	}

	inline static int32_t get_offset_of_tvPiece_8() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___tvPiece_8)); }
	inline Text_t356221433 * get_tvPiece_8() const { return ___tvPiece_8; }
	inline Text_t356221433 ** get_address_of_tvPiece_8() { return &___tvPiece_8; }
	inline void set_tvPiece_8(Text_t356221433 * value)
	{
		___tvPiece_8 = value;
		Il2CppCodeGenWriteBarrier(&___tvPiece_8, value);
	}

	inline static int32_t get_offset_of_imgBomb_9() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___imgBomb_9)); }
	inline Image_t2042527209 * get_imgBomb_9() const { return ___imgBomb_9; }
	inline Image_t2042527209 ** get_address_of_imgBomb_9() { return &___imgBomb_9; }
	inline void set_imgBomb_9(Image_t2042527209 * value)
	{
		___imgBomb_9 = value;
		Il2CppCodeGenWriteBarrier(&___imgBomb_9, value);
	}

	inline static int32_t get_offset_of_flag_10() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___flag_10)); }
	inline GameObject_t1756533147 * get_flag_10() const { return ___flag_10; }
	inline GameObject_t1756533147 ** get_address_of_flag_10() { return &___flag_10; }
	inline void set_flag_10(GameObject_t1756533147 * value)
	{
		___flag_10 = value;
		Il2CppCodeGenWriteBarrier(&___flag_10, value);
	}

	inline static int32_t get_offset_of_alphaColor_11() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___alphaColor_11)); }
	inline Color_t2020392075  get_alphaColor_11() const { return ___alphaColor_11; }
	inline Color_t2020392075 * get_address_of_alphaColor_11() { return &___alphaColor_11; }
	inline void set_alphaColor_11(Color_t2020392075  value)
	{
		___alphaColor_11 = value;
	}

	inline static int32_t get_offset_of_boardUIData_12() { return static_cast<int32_t>(offsetof(PieceUI_t2437659790, ___boardUIData_12)); }
	inline UIData_t4134355993 * get_boardUIData_12() const { return ___boardUIData_12; }
	inline UIData_t4134355993 ** get_address_of_boardUIData_12() { return &___boardUIData_12; }
	inline void set_boardUIData_12(UIData_t4134355993 * value)
	{
		___boardUIData_12 = value;
		Il2CppCodeGenWriteBarrier(&___boardUIData_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
