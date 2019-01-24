#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2371420396.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shogi.ShogiFenUI
struct  ShogiFenUI_t717694717  : public UIBehavior_1_t2371420396
{
public:
	// UnityEngine.UI.Text Shogi.ShogiFenUI::tvFen
	Text_t356221433 * ___tvFen_6;

public:
	inline static int32_t get_offset_of_tvFen_6() { return static_cast<int32_t>(offsetof(ShogiFenUI_t717694717, ___tvFen_6)); }
	inline Text_t356221433 * get_tvFen_6() const { return ___tvFen_6; }
	inline Text_t356221433 ** get_address_of_tvFen_6() { return &___tvFen_6; }
	inline void set_tvFen_6(Text_t356221433 * value)
	{
		___tvFen_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvFen_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
