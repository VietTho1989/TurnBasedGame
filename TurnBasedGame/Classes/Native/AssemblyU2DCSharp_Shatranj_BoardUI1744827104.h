#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2479054614.h"

// Shatranj.ShatranjFenUI
struct ShatranjFenUI_t4060331930;
// UnityEngine.Transform
struct Transform_t3275118058;
// Shatranj.PieceUI
struct PieceUI_t2515045496;
// AnimationManagerCheckChange`1<Shatranj.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t3409952299;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.BoardUI
struct  BoardUI_t1744827104  : public UIBehavior_1_t2479054614
{
public:
	// Shatranj.ShatranjFenUI Shatranj.BoardUI::shatranjFenPrefab
	ShatranjFenUI_t4060331930 * ___shatranjFenPrefab_6;
	// UnityEngine.Transform Shatranj.BoardUI::shatranjFenContainer
	Transform_t3275118058 * ___shatranjFenContainer_7;
	// Shatranj.PieceUI Shatranj.BoardUI::piecePrefab
	PieceUI_t2515045496 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<Shatranj.BoardUI/UIData> Shatranj.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t3409952299 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_shatranjFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t1744827104, ___shatranjFenPrefab_6)); }
	inline ShatranjFenUI_t4060331930 * get_shatranjFenPrefab_6() const { return ___shatranjFenPrefab_6; }
	inline ShatranjFenUI_t4060331930 ** get_address_of_shatranjFenPrefab_6() { return &___shatranjFenPrefab_6; }
	inline void set_shatranjFenPrefab_6(ShatranjFenUI_t4060331930 * value)
	{
		___shatranjFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_shatranjFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t1744827104, ___shatranjFenContainer_7)); }
	inline Transform_t3275118058 * get_shatranjFenContainer_7() const { return ___shatranjFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_shatranjFenContainer_7() { return &___shatranjFenContainer_7; }
	inline void set_shatranjFenContainer_7(Transform_t3275118058 * value)
	{
		___shatranjFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t1744827104, ___piecePrefab_8)); }
	inline PieceUI_t2515045496 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t2515045496 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t2515045496 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t1744827104, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t3409952299 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t3409952299 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t3409952299 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
