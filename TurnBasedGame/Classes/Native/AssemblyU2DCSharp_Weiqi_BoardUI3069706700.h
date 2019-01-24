#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2390644476.h"

// Weiqi.BoardBackgroundUI
struct BoardBackgroundUI_t4184703426;
// Weiqi.PieceUI
struct PieceUI_t549916648;
// GameDataCheckChangeRule`1<Weiqi.Weiqi>
struct GameDataCheckChangeRule_1_t2597178741;
// AnimationManagerCheckChange`1<Weiqi.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t3321542161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardUI
struct  BoardUI_t3069706700  : public UIBehavior_1_t2390644476
{
public:
	// Weiqi.BoardBackgroundUI Weiqi.BoardUI::backgroundPrefab
	BoardBackgroundUI_t4184703426 * ___backgroundPrefab_6;
	// Weiqi.PieceUI Weiqi.BoardUI::piecePrefab
	PieceUI_t549916648 * ___piecePrefab_7;
	// GameDataCheckChangeRule`1<Weiqi.Weiqi> Weiqi.BoardUI::checkUseRule
	GameDataCheckChangeRule_1_t2597178741 * ___checkUseRule_8;
	// AnimationManagerCheckChange`1<Weiqi.BoardUI/UIData> Weiqi.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t3321542161 * ___animationManagerCheckChange_9;

public:
	inline static int32_t get_offset_of_backgroundPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t3069706700, ___backgroundPrefab_6)); }
	inline BoardBackgroundUI_t4184703426 * get_backgroundPrefab_6() const { return ___backgroundPrefab_6; }
	inline BoardBackgroundUI_t4184703426 ** get_address_of_backgroundPrefab_6() { return &___backgroundPrefab_6; }
	inline void set_backgroundPrefab_6(BoardBackgroundUI_t4184703426 * value)
	{
		___backgroundPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___backgroundPrefab_6, value);
	}

	inline static int32_t get_offset_of_piecePrefab_7() { return static_cast<int32_t>(offsetof(BoardUI_t3069706700, ___piecePrefab_7)); }
	inline PieceUI_t549916648 * get_piecePrefab_7() const { return ___piecePrefab_7; }
	inline PieceUI_t549916648 ** get_address_of_piecePrefab_7() { return &___piecePrefab_7; }
	inline void set_piecePrefab_7(PieceUI_t549916648 * value)
	{
		___piecePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_7, value);
	}

	inline static int32_t get_offset_of_checkUseRule_8() { return static_cast<int32_t>(offsetof(BoardUI_t3069706700, ___checkUseRule_8)); }
	inline GameDataCheckChangeRule_1_t2597178741 * get_checkUseRule_8() const { return ___checkUseRule_8; }
	inline GameDataCheckChangeRule_1_t2597178741 ** get_address_of_checkUseRule_8() { return &___checkUseRule_8; }
	inline void set_checkUseRule_8(GameDataCheckChangeRule_1_t2597178741 * value)
	{
		___checkUseRule_8 = value;
		Il2CppCodeGenWriteBarrier(&___checkUseRule_8, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t3069706700, ___animationManagerCheckChange_9)); }
	inline AnimationManagerCheckChange_1_t3321542161 * get_animationManagerCheckChange_9() const { return ___animationManagerCheckChange_9; }
	inline AnimationManagerCheckChange_1_t3321542161 ** get_address_of_animationManagerCheckChange_9() { return &___animationManagerCheckChange_9; }
	inline void set_animationManagerCheckChange_9(AnimationManagerCheckChange_1_t3321542161 * value)
	{
		___animationManagerCheckChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
