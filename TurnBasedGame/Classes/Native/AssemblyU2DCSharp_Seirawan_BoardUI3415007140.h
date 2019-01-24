#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3269665389.h"

// Seirawan.SeirawanFenUI
struct SeirawanFenUI_t2809794929;
// UnityEngine.Transform
struct Transform_t3275118058;
// Seirawan.PieceUI
struct PieceUI_t3991446970;
// Seirawan.HandsUI
struct HandsUI_t3967686;
// AnimationManagerCheckChange`1<Seirawan.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t4200563074;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.BoardUI
struct  BoardUI_t3415007140  : public UIBehavior_1_t3269665389
{
public:
	// Seirawan.SeirawanFenUI Seirawan.BoardUI::seirawanFenPrefab
	SeirawanFenUI_t2809794929 * ___seirawanFenPrefab_6;
	// UnityEngine.Transform Seirawan.BoardUI::seirawanFenContainer
	Transform_t3275118058 * ___seirawanFenContainer_7;
	// Seirawan.PieceUI Seirawan.BoardUI::piecePrefab
	PieceUI_t3991446970 * ___piecePrefab_8;
	// Seirawan.HandsUI Seirawan.BoardUI::handsPrefab
	HandsUI_t3967686 * ___handsPrefab_9;
	// AnimationManagerCheckChange`1<Seirawan.BoardUI/UIData> Seirawan.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t4200563074 * ___animationManagerCheckChange_10;

public:
	inline static int32_t get_offset_of_seirawanFenPrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t3415007140, ___seirawanFenPrefab_6)); }
	inline SeirawanFenUI_t2809794929 * get_seirawanFenPrefab_6() const { return ___seirawanFenPrefab_6; }
	inline SeirawanFenUI_t2809794929 ** get_address_of_seirawanFenPrefab_6() { return &___seirawanFenPrefab_6; }
	inline void set_seirawanFenPrefab_6(SeirawanFenUI_t2809794929 * value)
	{
		___seirawanFenPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___seirawanFenPrefab_6, value);
	}

	inline static int32_t get_offset_of_seirawanFenContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t3415007140, ___seirawanFenContainer_7)); }
	inline Transform_t3275118058 * get_seirawanFenContainer_7() const { return ___seirawanFenContainer_7; }
	inline Transform_t3275118058 ** get_address_of_seirawanFenContainer_7() { return &___seirawanFenContainer_7; }
	inline void set_seirawanFenContainer_7(Transform_t3275118058 * value)
	{
		___seirawanFenContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___seirawanFenContainer_7, value);
	}

	inline static int32_t get_offset_of_piecePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t3415007140, ___piecePrefab_8)); }
	inline PieceUI_t3991446970 * get_piecePrefab_8() const { return ___piecePrefab_8; }
	inline PieceUI_t3991446970 ** get_address_of_piecePrefab_8() { return &___piecePrefab_8; }
	inline void set_piecePrefab_8(PieceUI_t3991446970 * value)
	{
		___piecePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_8, value);
	}

	inline static int32_t get_offset_of_handsPrefab_9() { return static_cast<int32_t>(offsetof(BoardUI_t3415007140, ___handsPrefab_9)); }
	inline HandsUI_t3967686 * get_handsPrefab_9() const { return ___handsPrefab_9; }
	inline HandsUI_t3967686 ** get_address_of_handsPrefab_9() { return &___handsPrefab_9; }
	inline void set_handsPrefab_9(HandsUI_t3967686 * value)
	{
		___handsPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___handsPrefab_9, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_10() { return static_cast<int32_t>(offsetof(BoardUI_t3415007140, ___animationManagerCheckChange_10)); }
	inline AnimationManagerCheckChange_1_t4200563074 * get_animationManagerCheckChange_10() const { return ___animationManagerCheckChange_10; }
	inline AnimationManagerCheckChange_1_t4200563074 ** get_address_of_animationManagerCheckChange_10() { return &___animationManagerCheckChange_10; }
	inline void set_animationManagerCheckChange_10(AnimationManagerCheckChange_1_t4200563074 * value)
	{
		___animationManagerCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
