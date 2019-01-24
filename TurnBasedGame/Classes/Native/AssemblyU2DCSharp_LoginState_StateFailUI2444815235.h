#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1745220714.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.StateFailUI
struct  StateFailUI_t2444815235  : public UIBehavior_1_t1745220714
{
public:
	// UnityEngine.UI.Text LoginState.StateFailUI::tvReason
	Text_t356221433 * ___tvReason_6;

public:
	inline static int32_t get_offset_of_tvReason_6() { return static_cast<int32_t>(offsetof(StateFailUI_t2444815235, ___tvReason_6)); }
	inline Text_t356221433 * get_tvReason_6() const { return ___tvReason_6; }
	inline Text_t356221433 ** get_address_of_tvReason_6() { return &___tvReason_6; }
	inline void set_tvReason_6(Text_t356221433 * value)
	{
		___tvReason_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvReason_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
