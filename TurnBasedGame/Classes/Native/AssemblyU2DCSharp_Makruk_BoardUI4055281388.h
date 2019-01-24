#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4130953138.h"

// Makruk.MakrukFenUI
struct MakrukFenUI_t3713850072;
// UnityEngine.Transform
struct Transform_t3275118058;
// Makruk.PieceUI
struct PieceUI_t1791786296;
// AnimationManagerCheckChange`1<Makruk.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t766883527;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.BoardUI
struct  BoardUI_t4055281388  : public UIBehavior_1_t4130953138
{
public:
	// Makruk.MakrukFenUI Makruk.BoardUI::makrukFenPrefab
	MakrukFenUI_t3713850072 * ___makrukFenPrefab_6;
	// UnityEngine.Transform Makruk.BoardUI::makrukFenContainer
	Transform_t3275118058 * ___makrukFenContainer_7;
	// Makruk.PieceUI Makruk.BoardUI::piecePrefab
	PieceUI_t1791786296 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<Makruk.BoardUI/UIData> Makruk.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t766883527 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_makrukFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t4055281388, ___makrukFenPrefab_6)); }
	inline MakrukFenUI_t3713850072 * get_makrukFenPrefab_6() const { return ___makrukFenPrefab_6; }
	inline MakrukFenUI_t3713850072 ** get_address_of_makrukFenPrefab_6() { return &___makrukFenPrefab_6; }
	inline void set_makrukFenPrefab_6(MakrukFenUI_t3713850072 * value)
	{
		___makrukFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___makrukFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_makrukFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t4055281388, ___makrukFenContainer_7)); }
	inline Transform_t3275118058 * get_makrukFenContainer_7() const { return ___makrukFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_makrukFenContainer_7() { return &___makrukFenContainer_7; }
	inline void set_makrukFenContainer_7(Transform_t3275118058 * value)
	{
		___makrukFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___makrukFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t4055281388, ___piecePrefab_8)); }
	inline PieceUI_t1791786296 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t1791786296 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t1791786296 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t4055281388, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t766883527 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t766883527 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t766883527 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
