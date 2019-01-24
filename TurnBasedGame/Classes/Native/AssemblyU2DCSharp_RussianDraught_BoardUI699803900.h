#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2156488661.h"

// RussianDraught.RussianDraughtFenUI
struct RussianDraughtFenUI_t1475855871;
// UnityEngine.Transform
struct Transform_t3275118058;
// RussianDraught.PieceUI
struct PieceUI_t97924718;
// AnimationManagerCheckChange`1<RussianDraught.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t3087386346;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.BoardUI
struct  BoardUI_t699803900  : public UIBehavior_1_t2156488661
{
public:
	// RussianDraught.RussianDraughtFenUI RussianDraught.BoardUI::russianDraughtFenPrefab
	RussianDraughtFenUI_t1475855871 * ___russianDraughtFenPrefab_6;
	// UnityEngine.Transform RussianDraught.BoardUI::russianDraughtFenContainer
	Transform_t3275118058 * ___russianDraughtFenContainer_7;
	// RussianDraught.PieceUI RussianDraught.BoardUI::piecePrefab
	PieceUI_t97924718 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<RussianDraught.BoardUI/UIData> RussianDraught.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t3087386346 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_russianDraughtFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t699803900, ___russianDraughtFenPrefab_6)); }
	inline RussianDraughtFenUI_t1475855871 * get_russianDraughtFenPrefab_6() const { return ___russianDraughtFenPrefab_6; }
	inline RussianDraughtFenUI_t1475855871 ** get_address_of_russianDraughtFenPrefab_6() { return &___russianDraughtFenPrefab_6; }
	inline void set_russianDraughtFenPrefab_6(RussianDraughtFenUI_t1475855871 * value)
	{
		___russianDraughtFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_russianDraughtFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t699803900, ___russianDraughtFenContainer_7)); }
	inline Transform_t3275118058 * get_russianDraughtFenContainer_7() const { return ___russianDraughtFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_russianDraughtFenContainer_7() { return &___russianDraughtFenContainer_7; }
	inline void set_russianDraughtFenContainer_7(Transform_t3275118058 * value)
	{
		___russianDraughtFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t699803900, ___piecePrefab_8)); }
	inline PieceUI_t97924718 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t97924718 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t97924718 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t699803900, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t3087386346 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t3087386346 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t3087386346 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
