#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1304895129.h"

// Weiqi.BoardBackgroundUI
struct BoardBackgroundUI_t4184703426;
// Gomoku.PieceUI
struct PieceUI_t832588318;
// AnimationManagerCheckChange`1<Gomoku.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t2235792814;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.BoardUI
struct  BoardUI_t760474964  : public UIBehavior_1_t1304895129
{
public:
	// Weiqi.BoardBackgroundUI Gomoku.BoardUI::backgroundPrefab
	BoardBackgroundUI_t4184703426 * ___backgroundPrefab_6;
	// Gomoku.PieceUI Gomoku.BoardUI::piecePrefab
	PieceUI_t832588318 * ___piecePrefab_7;
	// AnimationManagerCheckChange`1<Gomoku.BoardUI/UIData> Gomoku.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t2235792814 * ___animationManagerCheckChange_8;

public:
	inline static int32_t get_offset_of_backgroundPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t760474964, ___backgroundPrefab_6)); }
	inline BoardBackgroundUI_t4184703426 * get_backgroundPrefab_6() const { return ___backgroundPrefab_6; }
	inline BoardBackgroundUI_t4184703426 ** get_address_of_backgroundPrefab_6() { return &___backgroundPrefab_6; }
	inline void set_backgroundPrefab_6(BoardBackgroundUI_t4184703426 * value)
	{
		___backgroundPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___backgroundPrefab_6, value);
	}

	inline static int32_t get_offset_of_piecePrefab_7() { return static_cast<int32_t>(offsetof(BoardUI_t760474964, ___piecePrefab_7)); }
	inline PieceUI_t832588318 * get_piecePrefab_7() const { return ___piecePrefab_7; }
	inline PieceUI_t832588318 ** get_address_of_piecePrefab_7() { return &___piecePrefab_7; }
	inline void set_piecePrefab_7(PieceUI_t832588318 * value)
	{
		___piecePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_7, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_8() { return static_cast<int32_t>(offsetof(BoardUI_t760474964, ___animationManagerCheckChange_8)); }
	inline AnimationManagerCheckChange_1_t2235792814 * get_animationManagerCheckChange_8() const { return ___animationManagerCheckChange_8; }
	inline AnimationManagerCheckChange_1_t2235792814 ** get_address_of_animationManagerCheckChange_8() { return &___animationManagerCheckChange_8; }
	inline void set_animationManagerCheckChange_8(AnimationManagerCheckChange_1_t2235792814 * value)
	{
		___animationManagerCheckChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
