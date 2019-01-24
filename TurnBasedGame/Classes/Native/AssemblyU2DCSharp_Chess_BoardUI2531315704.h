#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2936045759.h"

// Chess.ChessFenUI
struct ChessFenUI_t2955231689;
// UnityEngine.Transform
struct Transform_t3275118058;
// Chess.PieceUI
struct PieceUI_t3827350998;
// AnimationManagerCheckChange`1<Chess.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t3866943444;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Chess.BoardUI
struct  BoardUI_t2531315704  : public UIBehavior_1_t2936045759
{
public:
	// Chess.ChessFenUI Chess.BoardUI::chessFenPrefab
	ChessFenUI_t2955231689 * ___chessFenPrefab_6;
	// UnityEngine.Transform Chess.BoardUI::chessFenContainer
	Transform_t3275118058 * ___chessFenContainer_7;
	// Chess.PieceUI Chess.BoardUI::piecePrefab
	PieceUI_t3827350998 * ___piecePrefab_8;
	// AnimationManagerCheckChange`1<Chess.BoardUI/UIData> Chess.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t3866943444 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_chessFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t2531315704, ___chessFenPrefab_6)); }
	inline ChessFenUI_t2955231689 * get_chessFenPrefab_6() const { return ___chessFenPrefab_6; }
	inline ChessFenUI_t2955231689 ** get_address_of_chessFenPrefab_6() { return &___chessFenPrefab_6; }
	inline void set_chessFenPrefab_6(ChessFenUI_t2955231689 * value)
	{
		___chessFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___chessFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_chessFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t2531315704, ___chessFenContainer_7)); }
	inline Transform_t3275118058 * get_chessFenContainer_7() const { return ___chessFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_chessFenContainer_7() { return &___chessFenContainer_7; }
	inline void set_chessFenContainer_7(Transform_t3275118058 * value)
	{
		___chessFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___chessFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t2531315704, ___piecePrefab_8)); }
	inline PieceUI_t3827350998 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t3827350998 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t3827350998 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t2531315704, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t3866943444 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t3866943444 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t3866943444 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
