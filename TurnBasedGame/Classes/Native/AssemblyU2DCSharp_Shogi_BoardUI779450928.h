#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen749061275.h"

// Shogi.ShogiFenUI
struct ShogiFenUI_t717694717;
// UnityEngine.Transform
struct Transform_t3275118058;
// Shogi.PieceUI
struct PieceUI_t2622754438;
// Shogi.HandUI
struct HandUI_t108272417;
// AnimationManagerCheckChange`1<Shogi.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t1679958960;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.BoardUI
struct  BoardUI_t779450928  : public UIBehavior_1_t749061275
{
public:
	// Shogi.ShogiFenUI Shogi.BoardUI::shogiFenPrefab
	ShogiFenUI_t717694717 * ___shogiFenPrefab_6;
	// UnityEngine.Transform Shogi.BoardUI::shogiFenContainer
	Transform_t3275118058 * ___shogiFenContainer_7;
	// Shogi.PieceUI Shogi.BoardUI::piecePrefab
	PieceUI_t2622754438 * ___piecePrefab_8;
	// Shogi.HandUI Shogi.BoardUI::handPrefab
	HandUI_t108272417 * ___handPrefab_9;
	// AnimationManagerCheckChange`1<Shogi.BoardUI/UIData> Shogi.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t1679958960 * ___animationManagerCheckChange_10;

public:
	inline static int32_t get_offset_of_shogiFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t779450928, ___shogiFenPrefab_6)); }
	inline ShogiFenUI_t717694717 * get_shogiFenPrefab_6() const { return ___shogiFenPrefab_6; }
	inline ShogiFenUI_t717694717 ** get_address_of_shogiFenPrefab_6() { return &___shogiFenPrefab_6; }
	inline void set_shogiFenPrefab_6(ShogiFenUI_t717694717 * value)
	{
		___shogiFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___shogiFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_shogiFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t779450928, ___shogiFenContainer_7)); }
	inline Transform_t3275118058 * get_shogiFenContainer_7() const { return ___shogiFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_shogiFenContainer_7() { return &___shogiFenContainer_7; }
	inline void set_shogiFenContainer_7(Transform_t3275118058 * value)
	{
		___shogiFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___shogiFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t779450928, ___piecePrefab_8)); }
	inline PieceUI_t2622754438 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t2622754438 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t2622754438 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_handPrefab_9() { return static_cast<int32_t>(offsetof(BoardUI_t779450928, ___handPrefab_9)); }
	inline HandUI_t108272417 * get_handPrefab_9() const { return ___handPrefab_9; }
	inline HandUI_t108272417 ** get_address_of_handPrefab_9() { return &___handPrefab_9; }
	inline void set_handPrefab_9(HandUI_t108272417 * value)
	{
		___handPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___handPrefab_9, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_10() { return static_cast<int32_t>(offsetof(BoardUI_t779450928, ___animationManagerCheckChange_10)); }
	inline AnimationManagerCheckChange_1_t1679958960 * get_animationManagerCheckChange_10() const { return ___animationManagerCheckChange_10; }
	inline AnimationManagerCheckChange_1_t1679958960 ** get_address_of_animationManagerCheckChange_10() { return &___animationManagerCheckChange_10; }
	inline void set_animationManagerCheckChange_10(AnimationManagerCheckChange_1_t1679958960 * value)
	{
		___animationManagerCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
