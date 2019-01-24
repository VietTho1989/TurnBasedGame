#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3356896232.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnCutUI
struct  BtnCutUI_t1375355700  : public UIBehavior_1_t3356896232
{
public:
	// UnityEngine.UI.Button FileSystem.BtnCutUI::btnCut
	Button_t2872111280 * ___btnCut_6;
	// UnityEngine.UI.Text FileSystem.BtnCutUI::tvCut
	Text_t356221433 * ___tvCut_7;

public:
	inline static int32_t get_offset_of_btnCut_6() { return static_cast<int32_t>(offsetof(BtnCutUI_t1375355700, ___btnCut_6)); }
	inline Button_t2872111280 * get_btnCut_6() const { return ___btnCut_6; }
	inline Button_t2872111280 ** get_address_of_btnCut_6() { return &___btnCut_6; }
	inline void set_btnCut_6(Button_t2872111280 * value)
	{
		___btnCut_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnCut_6, value);
	}

	inline static int32_t get_offset_of_tvCut_7() { return static_cast<int32_t>(offsetof(BtnCutUI_t1375355700, ___tvCut_7)); }
	inline Text_t356221433 * get_tvCut_7() const { return ___tvCut_7; }
	inline Text_t356221433 ** get_address_of_tvCut_7() { return &___tvCut_7; }
	inline void set_tvCut_7(Text_t356221433 * value)
	{
		___tvCut_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvCut_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
