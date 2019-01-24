#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3156579879.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnForWardUI
struct  BtnForWardUI_t70167255  : public UIBehavior_1_t3156579879
{
public:
	// UnityEngine.UI.Button FileSystem.BtnForWardUI::btnForWard
	Button_t2872111280 * ___btnForWard_6;
	// UnityEngine.UI.Text FileSystem.BtnForWardUI::tvForWard
	Text_t356221433 * ___tvForWard_7;

public:
	inline static int32_t get_offset_of_btnForWard_6() { return static_cast<int32_t>(offsetof(BtnForWardUI_t70167255, ___btnForWard_6)); }
	inline Button_t2872111280 * get_btnForWard_6() const { return ___btnForWard_6; }
	inline Button_t2872111280 ** get_address_of_btnForWard_6() { return &___btnForWard_6; }
	inline void set_btnForWard_6(Button_t2872111280 * value)
	{
		___btnForWard_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnForWard_6, value);
	}

	inline static int32_t get_offset_of_tvForWard_7() { return static_cast<int32_t>(offsetof(BtnForWardUI_t70167255, ___tvForWard_7)); }
	inline Text_t356221433 * get_tvForWard_7() const { return ___tvForWard_7; }
	inline Text_t356221433 ** get_address_of_tvForWard_7() { return &___tvForWard_7; }
	inline void set_tvForWard_7(Text_t356221433 * value)
	{
		___tvForWard_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvForWard_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
