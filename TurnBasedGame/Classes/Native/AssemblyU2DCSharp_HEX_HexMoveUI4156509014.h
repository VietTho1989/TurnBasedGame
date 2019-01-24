#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1527467872.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// UnityEngine.UI.Image
struct Image_t2042527209;
// GameDataBoardCheckPerspectiveChange`1<HEX.HexMoveUI/UIData>
struct GameDataBoardCheckPerspectiveChange_1_t487821320;
// HEX.HexGameDataUI/UIData
struct UIData_t3485590849;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexMoveUI
struct  HexMoveUI_t4156509014  : public UIBehavior_1_t1527467872
{
public:
	// UnityEngine.GameObject HEX.HexMoveUI::contentContainer
	GameObject_t1756533147 * ___contentContainer_6;
	// UnityEngine.UI.Extensions.UILineRenderer HEX.HexMoveUI::lineRenderer
	UILineRenderer_t3031355003 * ___lineRenderer_7;
	// UnityEngine.UI.Image HEX.HexMoveUI::imgHint
	Image_t2042527209 * ___imgHint_8;
	// GameDataBoardCheckPerspectiveChange`1<HEX.HexMoveUI/UIData> HEX.HexMoveUI::perspectiveChange
	GameDataBoardCheckPerspectiveChange_1_t487821320 * ___perspectiveChange_9;
	// HEX.HexGameDataUI/UIData HEX.HexMoveUI::hexGameDataUIData
	UIData_t3485590849 * ___hexGameDataUIData_10;

public:
	inline static int32_t get_offset_of_contentContainer_6() { return static_cast<int32_t>(offsetof(HexMoveUI_t4156509014, ___contentContainer_6)); }
	inline GameObject_t1756533147 * get_contentContainer_6() const { return ___contentContainer_6; }
	inline GameObject_t1756533147 ** get_address_of_contentContainer_6() { return &___contentContainer_6; }
	inline void set_contentContainer_6(GameObject_t1756533147 * value)
	{
		___contentContainer_6 = value;
		Il2CppCodeGenWriteBarrier(&___contentContainer_6, value);
	}

	inline static int32_t get_offset_of_lineRenderer_7() { return static_cast<int32_t>(offsetof(HexMoveUI_t4156509014, ___lineRenderer_7)); }
	inline UILineRenderer_t3031355003 * get_lineRenderer_7() const { return ___lineRenderer_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRenderer_7() { return &___lineRenderer_7; }
	inline void set_lineRenderer_7(UILineRenderer_t3031355003 * value)
	{
		___lineRenderer_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRenderer_7, value);
	}

	inline static int32_t get_offset_of_imgHint_8() { return static_cast<int32_t>(offsetof(HexMoveUI_t4156509014, ___imgHint_8)); }
	inline Image_t2042527209 * get_imgHint_8() const { return ___imgHint_8; }
	inline Image_t2042527209 ** get_address_of_imgHint_8() { return &___imgHint_8; }
	inline void set_imgHint_8(Image_t2042527209 * value)
	{
		___imgHint_8 = value;
		Il2CppCodeGenWriteBarrier(&___imgHint_8, value);
	}

	inline static int32_t get_offset_of_perspectiveChange_9() { return static_cast<int32_t>(offsetof(HexMoveUI_t4156509014, ___perspectiveChange_9)); }
	inline GameDataBoardCheckPerspectiveChange_1_t487821320 * get_perspectiveChange_9() const { return ___perspectiveChange_9; }
	inline GameDataBoardCheckPerspectiveChange_1_t487821320 ** get_address_of_perspectiveChange_9() { return &___perspectiveChange_9; }
	inline void set_perspectiveChange_9(GameDataBoardCheckPerspectiveChange_1_t487821320 * value)
	{
		___perspectiveChange_9 = value;
		Il2CppCodeGenWriteBarrier(&___perspectiveChange_9, value);
	}

	inline static int32_t get_offset_of_hexGameDataUIData_10() { return static_cast<int32_t>(offsetof(HexMoveUI_t4156509014, ___hexGameDataUIData_10)); }
	inline UIData_t3485590849 * get_hexGameDataUIData_10() const { return ___hexGameDataUIData_10; }
	inline UIData_t3485590849 ** get_address_of_hexGameDataUIData_10() { return &___hexGameDataUIData_10; }
	inline void set_hexGameDataUIData_10(UIData_t3485590849 * value)
	{
		___hexGameDataUIData_10 = value;
		Il2CppCodeGenWriteBarrier(&___hexGameDataUIData_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
