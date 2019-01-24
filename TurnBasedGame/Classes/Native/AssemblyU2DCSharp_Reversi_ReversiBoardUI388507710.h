#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3282354553.h"

// Reversi.ReversiPieceUI
struct ReversiPieceUI_t964963564;
// Reversi.ReversiLegalUI
struct ReversiLegalUI_t4146846693;
// AnimationManagerCheckChange`1<Reversi.ReversiBoardUI/UIData>
struct AnimationManagerCheckChange_1_t4213252238;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.ReversiBoardUI
struct  ReversiBoardUI_t388507710  : public UIBehavior_1_t3282354553
{
public:
	// Reversi.ReversiPieceUI Reversi.ReversiBoardUI::piecePrefab
	ReversiPieceUI_t964963564 * ___piecePrefab_6;
	// Reversi.ReversiLegalUI Reversi.ReversiBoardUI::legalPrefab
	ReversiLegalUI_t4146846693 * ___legalPrefab_7;
	// AnimationManagerCheckChange`1<Reversi.ReversiBoardUI/UIData> Reversi.ReversiBoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t4213252238 * ___animationManagerCheckChange_8;

public:
	inline static int32_t get_offset_of_piecePrefab_6() { return static_cast<int32_t>(offsetof(ReversiBoardUI_t388507710, ___piecePrefab_6)); }
	inline ReversiPieceUI_t964963564 * get_piecePrefab_6() const { return ___piecePrefab_6; }
	inline ReversiPieceUI_t964963564 ** get_address_of_piecePrefab_6() { return &___piecePrefab_6; }
	inline void set_piecePrefab_6(ReversiPieceUI_t964963564 * value)
	{
		___piecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_6, value);
	}

	inline static int32_t get_offset_of_legalPrefab_7() { return static_cast<int32_t>(offsetof(ReversiBoardUI_t388507710, ___legalPrefab_7)); }
	inline ReversiLegalUI_t4146846693 * get_legalPrefab_7() const { return ___legalPrefab_7; }
	inline ReversiLegalUI_t4146846693 ** get_address_of_legalPrefab_7() { return &___legalPrefab_7; }
	inline void set_legalPrefab_7(ReversiLegalUI_t4146846693 * value)
	{
		___legalPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___legalPrefab_7, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_8() { return static_cast<int32_t>(offsetof(ReversiBoardUI_t388507710, ___animationManagerCheckChange_8)); }
	inline AnimationManagerCheckChange_1_t4213252238 * get_animationManagerCheckChange_8() const { return ___animationManagerCheckChange_8; }
	inline AnimationManagerCheckChange_1_t4213252238 ** get_address_of_animationManagerCheckChange_8() { return &___animationManagerCheckChange_8; }
	inline void set_animationManagerCheckChange_8(AnimationManagerCheckChange_1_t4213252238 * value)
	{
		___animationManagerCheckChange_8 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
