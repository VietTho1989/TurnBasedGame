#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1882269455.h"

// UnityEngine.UI.Extensions.UILineRenderer
struct UILineRenderer_t3031355003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Reversi.NoneRule.ReversiCustomMoveUI
struct  ReversiCustomMoveUI_t3466784508  : public UIBehavior_1_t1882269455
{
public:
	// UnityEngine.UI.Extensions.UILineRenderer Reversi.NoneRule.ReversiCustomMoveUI::lineRendererFrom
	UILineRenderer_t3031355003 * ___lineRendererFrom_6;
	// UnityEngine.UI.Extensions.UILineRenderer Reversi.NoneRule.ReversiCustomMoveUI::lineRendererDest
	UILineRenderer_t3031355003 * ___lineRendererDest_7;

public:
	inline static int32_t get_offset_of_lineRendererFrom_6() { return static_cast<int32_t>(offsetof(ReversiCustomMoveUI_t3466784508, ___lineRendererFrom_6)); }
	inline UILineRenderer_t3031355003 * get_lineRendererFrom_6() const { return ___lineRendererFrom_6; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererFrom_6() { return &___lineRendererFrom_6; }
	inline void set_lineRendererFrom_6(UILineRenderer_t3031355003 * value)
	{
		___lineRendererFrom_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererFrom_6, value);
	}

	inline static int32_t get_offset_of_lineRendererDest_7() { return static_cast<int32_t>(offsetof(ReversiCustomMoveUI_t3466784508, ___lineRendererDest_7)); }
	inline UILineRenderer_t3031355003 * get_lineRendererDest_7() const { return ___lineRendererDest_7; }
	inline UILineRenderer_t3031355003 ** get_address_of_lineRendererDest_7() { return &___lineRendererDest_7; }
	inline void set_lineRendererDest_7(UILineRenderer_t3031355003 * value)
	{
		___lineRendererDest_7 = value;
		Il2CppCodeGenWriteBarrier(&___lineRendererDest_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
