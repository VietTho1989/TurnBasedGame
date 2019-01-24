#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen407705027.h"

// CoTuongUp.PieceUI
struct PieceUI_t542454310;
// UnityEngine.Transform
struct Transform_t3275118058;
// CoTuongUp.CaptureUI
struct CaptureUI_t3073727490;
// GameCheckPlayerChange`1<CoTuongUp.CoTuongUp>
struct GameCheckPlayerChange_1_t1499089459;
// AnimationManagerCheckChange`1<CoTuongUp.BoardUI/UIData>
struct AnimationManagerCheckChange_1_t1338602712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.BoardUI
struct  BoardUI_t3771060760  : public UIBehavior_1_t407705027
{
public:
	// CoTuongUp.PieceUI CoTuongUp.BoardUI::piecePrefab
	PieceUI_t542454310 * ___piecePrefab_6;
	// UnityEngine.Transform CoTuongUp.BoardUI::captureContainer
	Transform_t3275118058 * ___captureContainer_7;
	// CoTuongUp.CaptureUI CoTuongUp.BoardUI::capturePrefab
	CaptureUI_t3073727490 * ___capturePrefab_8;
	// GameCheckPlayerChange`1<CoTuongUp.CoTuongUp> CoTuongUp.BoardUI::gameCheckPlayerChange
	GameCheckPlayerChange_1_t1499089459 * ___gameCheckPlayerChange_9;
	// AnimationManagerCheckChange`1<CoTuongUp.BoardUI/UIData> CoTuongUp.BoardUI::animationManagerCheckChange
	AnimationManagerCheckChange_1_t1338602712 * ___animationManagerCheckChange_10;

public:
	inline static int32_t get_offset_of_piecePrefab_6() { return static_cast<int32_t>(offsetof(BoardUI_t3771060760, ___piecePrefab_6)); }
	inline PieceUI_t542454310 * get_piecePrefab_6() const { return ___piecePrefab_6; }
	inline PieceUI_t542454310 ** get_address_of_piecePrefab_6() { return &___piecePrefab_6; }
	inline void set_piecePrefab_6(PieceUI_t542454310 * value)
	{
		___piecePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___piecePrefab_6, value);
	}

	inline static int32_t get_offset_of_captureContainer_7() { return static_cast<int32_t>(offsetof(BoardUI_t3771060760, ___captureContainer_7)); }
	inline Transform_t3275118058 * get_captureContainer_7() const { return ___captureContainer_7; }
	inline Transform_t3275118058 ** get_address_of_captureContainer_7() { return &___captureContainer_7; }
	inline void set_captureContainer_7(Transform_t3275118058 * value)
	{
		___captureContainer_7 = value;
		Il2CppCodeGenWriteBarrier(&___captureContainer_7, value);
	}

	inline static int32_t get_offset_of_capturePrefab_8() { return static_cast<int32_t>(offsetof(BoardUI_t3771060760, ___capturePrefab_8)); }
	inline CaptureUI_t3073727490 * get_capturePrefab_8() const { return ___capturePrefab_8; }
	inline CaptureUI_t3073727490 ** get_address_of_capturePrefab_8() { return &___capturePrefab_8; }
	inline void set_capturePrefab_8(CaptureUI_t3073727490 * value)
	{
		___capturePrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___capturePrefab_8, value);
	}

	inline static int32_t get_offset_of_gameCheckPlayerChange_9() { return static_cast<int32_t>(offsetof(BoardUI_t3771060760, ___gameCheckPlayerChange_9)); }
	inline GameCheckPlayerChange_1_t1499089459 * get_gameCheckPlayerChange_9() const { return ___gameCheckPlayerChange_9; }
	inline GameCheckPlayerChange_1_t1499089459 ** get_address_of_gameCheckPlayerChange_9() { return &___gameCheckPlayerChange_9; }
	inline void set_gameCheckPlayerChange_9(GameCheckPlayerChange_1_t1499089459 * value)
	{
		___gameCheckPlayerChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___gameCheckPlayerChange_9, value);
	}

	inline static int32_t get_offset_of_animationManagerCheckChange_10() { return static_cast<int32_t>(offsetof(BoardUI_t3771060760, ___animationManagerCheckChange_10)); }
	inline AnimationManagerCheckChange_1_t1338602712 * get_animationManagerCheckChange_10() const { return ___animationManagerCheckChange_10; }
	inline AnimationManagerCheckChange_1_t1338602712 ** get_address_of_animationManagerCheckChange_10() { return &___animationManagerCheckChange_10; }
	inline void set_animationManagerCheckChange_10(AnimationManagerCheckChange_1_t1338602712 * value)
	{
		___animationManagerCheckChange_10 = value;
		Il2CppCodeGenWriteBarrier(&___animationManagerCheckChange_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
