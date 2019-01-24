#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3034733974.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// GameDataBoardCheckPerspectiveChange`1<Shogi.UseRule.LegalMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t1995087422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.UseRule.LegalMoveUI
struct  LegalMoveUI_t1665776580  : public UIBehavior_1_t3034733974
{
public:
	// UnityEngine.GameObject Shogi.UseRule.LegalMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// GameDataBoardCheckPerspectiveChange`1<Shogi.UseRule.LegalMoveUI/UIData> Shogi.UseRule.LegalMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t1995087422 * ___perspectiveChange_7;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(LegalMoveUI_t1665776580, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_7() { return static_cast<int32_t>(offsetof(LegalMoveUI_t1665776580, ___perspectiveChange_7)); }
	inline GameDataBoardCheckPerspectiveChange_1_t1995087422 * get_perspectiveChange_7() const { return ___perspectiveChange_7; }
	inline GameDataBoardCheckPerspectiveChange_1_t1995087422 ** get_address_of_perspectiveChange_7() { return &___perspectiveChange_7; }
	inline void set_perspectiveChange_7(GameDataBoardCheckPerspectiveChange_1_t1995087422 * value)
	{
		___perspectiveChange_7 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
