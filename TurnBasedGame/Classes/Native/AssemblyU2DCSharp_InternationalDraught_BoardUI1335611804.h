#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3258908736.h"

// UnityEngine.UI.Text
struct Text_t356221433;
// InternationalDraught.InternationalDraughtFenUI
struct InternationalDraughtFenUI_t205241028;
// UnityEngine.Transform
struct Transform_t3275118058;
// InternationalDraught.PieceUI
struct PieceUI_t2252431856;
// AnimationManagerCheckChange`1<InternationalDraught.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t4189806421;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.BoardUI
struct  BoardUI_t1335611804  : public UIBehavior_1_t3258908736
{
public:
	// UnityEngine.UI.Text InternationalDraught.BoardUI::tvVariant
	Text_t356221433 * ___tvVariant_6;
	// InternationalDraught.InternationalDraughtFenUI InternationalDraught.BoardUI::internationalDraughtFenPrefab
	InternationalDraughtFenUI_t205241028 * ___internationalDraughtFenPrefab_7;
	// UnityEngine.Transform InternationalDraught.BoardUI::internationalDraughtFenContainer
	Transform_t3275118058 * ___internationalDraughtFenContainer_8;
	// InternationalDraught.PieceUI InternationalDraught.BoardUI::piecePrefab
	PieceUI_t2252431856 * ___piecePrefab_9;
	// AnimationManagerCheckChange`1<InternationalDraught.BoardUI/UIData> InternationalDraught.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t4189806421 * ___animationManagerCheckChange_10;

public:
	inline static int32_t get_offset_of_tvVariant_6() { return static_cast<int32_t>(offsetof(BoardUI_t1335611804, ___tvVariant_6)); }
	inline Text_t356221433 * get_tvVariant_6() const { return ___tvVariant_6; }
	inline Text_t356221433 ** get_address_of_tvVariant_6() { return &___tvVariant_6; }
	inline void set_tvVariant_6(Text_t356221433 * value)
	{
		___tvVariant_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvVariant_6, value);
	}

	inline static int32_t get_offset_of_internationalDraughtFenPrefab_7() { return static_cast<int32_t>(offsetof(BoardUI_t1335611804, ___internationalDraughtFenPrefab_7)); }
	inline InternationalDraughtFenUI_t205241028 * get_internationalDraughtFenPrefab_7() const { return ___internationalDraughtFenPrefab_7; }
	inline InternationalDraughtFenUI_t205241028 ** get_address_of_internationalDraughtFenPrefab_7() { return &___internationalDraughtFenPrefab_7; }
	inline void set_internationalDraughtFenPrefab_7(InternationalDraughtFenUI_t205241028 * value)
	{
		___internationalDraughtFenPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtFenPrefab_7, value);
	}

	inline static int32_t get_offset_of_internationalDraughtFenContainer_8() { return static_cast<int32_t>(offsetof(BoardUI_t1335611804, ___internationalDraughtFenContainer_8)); }
	inline Transform_t3275118058 * get_internationalDraughtFenContainer_8() const { return ___internationalDraughtFenContainer_8; }
	inline Transform_t3275118058 ** get_address_of_internationalDraughtFenContainer_8() { return &___internationalDraughtFenContainer_8; }
	inline void set_internationalDraughtFenContainer_8(Transform_t3275118058 * value)
	{
		___internationalDraughtFenContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___internationalDraughtFenContainer_8, value);
	}

	inline static int32_t get_offset_of_piecePrefab_9() { return static_cast<int32_t>(offsetof(BoardUI_t1335611804, ___piecePrefab_9)); }
	inline PieceUI_t2252431856 * get_piecePrefab_9() const { return ___piecePrefab_9; }
	inline PieceUI_t2252431856 ** get_address_of_piecePrefab_9() { return &___piecePrefab_9; }
	inline void set_piecePrefab_9(PieceUI_t2252431856 * value)
	{
		___piecePrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_9, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_10() { return static_cast<int32_t>(offsetof(BoardUI_t1335611804, ___animationManagerCheckChange_10)); }
	inline AnimationManagerCheckChange_1_t4189806421 * get_animationManagerCheckChange_10() const { return ___animationManagerCheckChange_10; }
	inline AnimationManagerCheckChange_1_t4189806421 ** get_address_of_animationManagerCheckChange_10() { return &___animationManagerCheckChange_10; }
	inline void set_animationManagerCheckChange_10(AnimationManagerCheckChange_1_t4189806421 * value)
	{
		___animationManagerCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
