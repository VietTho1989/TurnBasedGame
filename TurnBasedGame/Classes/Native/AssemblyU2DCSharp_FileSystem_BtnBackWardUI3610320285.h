#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2126474995.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnBackWardUI
struct  BtnBackWardUI_t3610320285  : public UIBehavior_1_t2126474995
{
public:
	// UnityEngine.UI.Button FileSystem.BtnBackWardUI::btnBackWard
	Button_t2872111280 * ___btnBackWard_6;
	// UnityEngine.UI.Text FileSystem.BtnBackWardUI::tvBackWard
	Text_t356221433 * ___tvBackWard_7;

public:
	inline static int32_t get_offset_of_btnBackWard_6() { return static_cast<int32_t>(offsetof(BtnBackWardUI_t3610320285, ___btnBackWard_6)); }
	inline Button_t2872111280 * get_btnBackWard_6() const { return ___btnBackWard_6; }
	inline Button_t2872111280 ** get_address_of_btnBackWard_6() { return &___btnBackWard_6; }
	inline void set_btnBackWard_6(Button_t2872111280 * value)
	{
		___btnBackWard_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnBackWard_6, value);
	}

	inline static int32_t get_offset_of_tvBackWard_7() { return static_cast<int32_t>(offsetof(BtnBackWardUI_t3610320285, ___tvBackWard_7)); }
	inline Text_t356221433 * get_tvBackWard_7() const { return ___tvBackWard_7; }
	inline Text_t356221433 ** get_address_of_tvBackWard_7() { return &___tvBackWard_7; }
	inline void set_tvBackWard_7(Text_t356221433 * value)
	{
		___tvBackWard_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvBackWard_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
