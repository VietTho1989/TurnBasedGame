#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2356618668.h"

// HEX.PieceUI
struct PieceUI_t1788896792;
// AnimationManagerCheckChange`1<HEX.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t3287516353;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.BoardUI
struct  BoardUI_t2803900944  : public UIBehavior_1_t2356618668
{
public:
	// HEX.PieceUI HEX.BoardUI::piecePrefab
	PieceUI_t1788896792 * ___piecePrefab_6;
	// AnimationManagerCheckChange`1<HEX.BoardUI/UIData> HEX.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t3287516353 * ___animationManagerCheckChange_7;

public:
	inline static int32_t get_offset_of_piecePrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t2803900944, ___piecePrefab_6)); }
	inline PieceUI_t1788896792 * get_piecePrefab_6() const { return ___piecePrefab_6; }
	inline PieceUI_t1788896792 ** get_address_of_piecePrefab_6() { return &___piecePrefab_6; }
	inline void set_piecePrefab_6(PieceUI_t1788896792 * value)
	{
		___piecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_6, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_7() { return static_cast<int32_t>(offsetof(BoardUI_t2803900944, ___animationManagerCheckChange_7)); }
	inline AnimationManagerCheckChange_1_t3287516353 * get_animationManagerCheckChange_7() const { return ___animationManagerCheckChange_7; }
	inline AnimationManagerCheckChange_1_t3287516353 ** get_address_of_animationManagerCheckChange_7() { return &___animationManagerCheckChange_7; }
	inline void set_animationManagerCheckChange_7(AnimationManagerCheckChange_1_t3287516353 * value)
	{
		___animationManagerCheckChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
