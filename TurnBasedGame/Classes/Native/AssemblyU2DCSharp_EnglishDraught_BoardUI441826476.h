#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4286413828.h"

// EnglishDraught.EnglishDraughtFenUI
struct EnglishDraughtFenUI_t532474780;
// UnityEngine.Transform
struct Transform_t3275118058;
// EnglishDraught.PieceUI
struct PieceUI_t4135479008;
// AnimationManagerCheckChange`1<EnglishDraught.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t922344217;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.BoardUI
struct  BoardUI_t441826476  : public UIBehavior_1_t4286413828
{
public:
	// EnglishDraught.EnglishDraughtFenUI EnglishDraught.BoardUI::englishDraughtFenPrefab
	EnglishDraughtFenUI_t532474780 * ___englishDraughtFenPrefab_6;
	// UnityEngine.Transform EnglishDraught.BoardUI::englishDraughtFenContainer
	Transform_t3275118058 * ___englishDraughtFenContainer_7;
	// EnglishDraught.PieceUI EnglishDraught.BoardUI::piecePrefab
	PieceUI_t4135479008 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<EnglishDraught.BoardUI/UIData> EnglishDraught.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t922344217 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_englishDraughtFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t441826476, ___englishDraughtFenPrefab_6)); }
	inline EnglishDraughtFenUI_t532474780 * get_englishDraughtFenPrefab_6() const { return ___englishDraughtFenPrefab_6; }
	inline EnglishDraughtFenUI_t532474780 ** get_address_of_englishDraughtFenPrefab_6() { return &___englishDraughtFenPrefab_6; }
	inline void set_englishDraughtFenPrefab_6(EnglishDraughtFenUI_t532474780 * value)
	{
		___englishDraughtFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_englishDraughtFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t441826476, ___englishDraughtFenContainer_7)); }
	inline Transform_t3275118058 * get_englishDraughtFenContainer_7() const { return ___englishDraughtFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_englishDraughtFenContainer_7() { return &___englishDraughtFenContainer_7; }
	inline void set_englishDraughtFenContainer_7(Transform_t3275118058 * value)
	{
		___englishDraughtFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t441826476, ___piecePrefab_8)); }
	inline PieceUI_t4135479008 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t4135479008 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t4135479008 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t441826476, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t922344217 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t922344217 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t922344217 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
