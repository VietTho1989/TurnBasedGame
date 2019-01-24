#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2855426247.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;
// Weiqi.WeiqiGameDataUI/UIData
struct UIData_t3165614177;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.NoneRule.WeiqiCustomMoveUI
struct  WeiqiCustomMoveUI_t2786002911  : public UIBehavior_1_t2855426247
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Weiqi.NoneRule.WeiqiCustomMoveUI::lineRendererFrom
	UILineRenderer_t3031355003 * ___lineRendererFrom_6;
	// UnityEngine.UI.Extensions.UILineRenderer Weiqi.NoneRule.WeiqiCustomMoveUI::lineRendererDest
	UILineRenderer_t3031355003 * ___lineRendererDest_7;
	// Weiqi.WeiqiGameDataUI/UIData Weiqi.NoneRule.WeiqiCustomMoveUI::weiqiGameDataUIData
	UIData_t3165614177 * ___weiqiGameDataUIData_8;

public:
	inline static int32_t get_offset_of_lineRendererFrom_6() { return static_cast<int32_t>(offsetof(WeiqiCustomMoveUI_t2786002911, ___lineRendererFrom_6)); }
	inline UILineRenderer_t3031355003 * get_lineRendererFrom_6() const { return ___lineRendererFrom_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererFrom_6() { return &___lineRendererFrom_6; }
	inline void set_lineRendererFrom_6(UILineRenderer_t3031355003 * value)
	{
		___lineRendererFrom_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererFrom_6, value);
	}

	inline static int32_t get_offset_of_lineRendererDest_7() { return static_cast<int32_t>(offsetof(WeiqiCustomMoveUI_t2786002911, ___lineRendererDest_7)); }
	inline UILineRenderer_t3031355003 * get_lineRendererDest_7() const { return ___lineRendererDest_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererDest_7() { return &___lineRendererDest_7; }
	inline void set_lineRendererDest_7(UILineRenderer_t3031355003 * value)
	{
		___lineRendererDest_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererDest_7, value);
	}

	inline static int32_t get_offset_of_weiqiGameDataUIData_8() { return static_cast<int32_t>(offsetof(WeiqiCustomMoveUI_t2786002911, ___weiqiGameDataUIData_8)); }
	inline UIData_t3165614177 * get_weiqiGameDataUIData_8() const { return ___weiqiGameDataUIData_8; }
	inline UIData_t3165614177 ** get_address_of_weiqiGameDataUIData_8() { return &___weiqiGameDataUIData_8; }
	inline void set_weiqiGameDataUIData_8(UIData_t3165614177 * value)
	{
		___weiqiGameDataUIData_8 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiGameDataUIData_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
