#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3178595412.h"

// Shogi.Common/Color[]
struct ColorU5BU5D_t1710722892;
// Shogi.Common/HandPiece[]
struct HandPieceU5BU5D_t1029127404;
// Shogi.HandPieceUI
struct HandPieceUI_t1821181595;
// UnityEngine.Transform
struct Transform_t3275118058;
// AnimationManagerCheckChange`1<Shogi.HandUI/UIData>
struct AnimationManagerCheckChange_1_t4109493097;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.HandUI
struct  HandUI_t108272417  : public UIBehavior_1_t3178595412
{
public:
	// Shogi.HandPieceUI Shogi.HandUI::handPiecePrefab
	HandPieceUI_t1821181595 * ___handPiecePrefab_8;
	// UnityEngine.Transform Shogi.HandUI::blackTransform
	Transform_t3275118058 * ___blackTransform_9;
	// UnityEngine.Transform Shogi.HandUI::whiteTransform
	Transform_t3275118058 * ___whiteTransform_10;
	// AnimationManagerCheckChange`1<Shogi.HandUI/UIData> Shogi.HandUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t4109493097 * ___animationManagerCheckChange_11;

public:
	inline static int32_t get_offset_of_handPiecePrefab_8() { return static_cast<int32_t>(offsetof(HandUI_t108272417, ___handPiecePrefab_8)); }
	inline HandPieceUI_t1821181595 * get_handPiecePrefab_8() const { return ___handPiecePrefab_8; }
	inline HandPieceUI_t1821181595 ** get_address_of_handPiecePrefab_8() { return &___handPiecePrefab_8; }
	inline void set_handPiecePrefab_8(HandPieceUI_t1821181595 * value)
	{
		___handPiecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___handPiecePrefab_8, value);
	}

	inline static int32_t get_offset_of_blackTransform_9() { return static_cast<int32_t>(offsetof(HandUI_t108272417, ___blackTransform_9)); }
	inline Transform_t3275118058 * get_blackTransform_9() const { return ___blackTransform_9; }
	inline Transform_t3275118058 ** get_address_of_blackTransform_9() { return &___blackTransform_9; }
	inline void set_blackTransform_9(Transform_t3275118058 * value)
	{
		___blackTransform_9 = value;
		Il2CppCodeGenWriteBarrier(&___blackTransform_9, value);
	}

	inline static int32_t get_offset_of_whiteTransform_10() { return static_cast<int32_t>(offsetof(HandUI_t108272417, ___whiteTransform_10)); }
	inline Transform_t3275118058 * get_whiteTransform_10() const { return ___whiteTransform_10; }
	inline Transform_t3275118058 ** get_address_of_whiteTransform_10() { return &___whiteTransform_10; }
	inline void set_whiteTransform_10(Transform_t3275118058 * value)
	{
		___whiteTransform_10 = value;
		Il2CppCodeGenWriteBarrier(&___whiteTransform_10, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_11() { return static_cast<int32_t>(offsetof(HandUI_t108272417, ___animationManagerCheckChange_11)); }
	inline AnimationManagerCheckChange_1_t4109493097 * get_animationManagerCheckChange_11() const { return ___animationManagerCheckChange_11; }
	inline AnimationManagerCheckChange_1_t4109493097 ** get_address_of_animationManagerCheckChange_11() { return &___animationManagerCheckChange_11; }
	inline void set_animationManagerCheckChange_11(AnimationManagerCheckChange_1_t4109493097 * value)
	{
		___animationManagerCheckChange_11 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_11, value);
	}
};

struct HandUI_t108272417_StaticFields
{
public:
	// Shogi.Common/Color[] Shogi.HandUI::colors
	ColorU5BU5D_t1710722892* ___colors_6;
	// Shogi.Common/HandPiece[] Shogi.HandUI::handPieces
	HandPieceU5BU5D_t1029127404* ___handPieces_7;

public:
	inline static int32_t get_offset_of_colors_6() { return static_cast<int32_t>(offsetof(HandUI_t108272417_StaticFields, ___colors_6)); }
	inline ColorU5BU5D_t1710722892* get_colors_6() const { return ___colors_6; }
	inline ColorU5BU5D_t1710722892** get_address_of_colors_6() { return &___colors_6; }
	inline void set_colors_6(ColorU5BU5D_t1710722892* value)
	{
		___colors_6 = value;
		Il2CppCodeGenWriteBarrier(&___colors_6, value);
	}

	inline static int32_t get_offset_of_handPieces_7() { return static_cast<int32_t>(offsetof(HandUI_t108272417_StaticFields, ___handPieces_7)); }
	inline HandPieceU5BU5D_t1029127404* get_handPieces_7() const { return ___handPieces_7; }
	inline HandPieceU5BU5D_t1029127404** get_address_of_handPieces_7() { return &___handPieces_7; }
	inline void set_handPieces_7(HandPieceU5BU5D_t1029127404* value)
	{
		___handPieces_7 = value;
		Il2CppCodeGenWriteBarrier(&___handPieces_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
