#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3782826361.h"

// UnityEngine.UI.Button
struct Button_t2872111280;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FileSystem.BtnCopyUI
struct  BtnCopyUI_t1456523269  : public UIBehavior_1_t3782826361
{
public:
	// UnityEngine.UI.Button FileSystem.BtnCopyUI::btnCopy
	Button_t2872111280 * ___btnCopy_6;
	// UnityEngine.UI.Text FileSystem.BtnCopyUI::tvCopy
	Text_t356221433 * ___tvCopy_7;

public:
	inline static int32_t get_offset_of_btnCopy_6() { return static_cast<int32_t>(offsetof(BtnCopyUI_t1456523269, ___btnCopy_6)); }
	inline Button_t2872111280 * get_btnCopy_6() const { return ___btnCopy_6; }
	inline Button_t2872111280 ** get_address_of_btnCopy_6() { return &___btnCopy_6; }
	inline void set_btnCopy_6(Button_t2872111280 * value)
	{
		___btnCopy_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnCopy_6, value);
	}

	inline static int32_t get_offset_of_tvCopy_7() { return static_cast<int32_t>(offsetof(BtnCopyUI_t1456523269, ___tvCopy_7)); }
	inline Text_t356221433 * get_tvCopy_7() const { return ___tvCopy_7; }
	inline Text_t356221433 ** get_address_of_tvCopy_7() { return &___tvCopy_7; }
	inline void set_tvCopy_7(Text_t356221433 * value)
	{
		___tvCopy_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvCopy_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
