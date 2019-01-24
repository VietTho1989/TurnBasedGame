#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2736986047.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginState.LogUI
struct  LogUI_t1659339182  : public UIBehavior_1_t2736986047
{
public:
	// UnityEngine.UI.Text LoginState.LogUI::tvTime
	Text_t356221433 * ___tvTime_6;
	// UnityEngine.UI.Text LoginState.LogUI::tvProgress
	Text_t356221433 * ___tvProgress_7;

public:
	inline static int32_t get_offset_of_tvTime_6() { return static_cast<int32_t>(offsetof(LogUI_t1659339182, ___tvTime_6)); }
	inline Text_t356221433 * get_tvTime_6() const { return ___tvTime_6; }
	inline Text_t356221433 ** get_address_of_tvTime_6() { return &___tvTime_6; }
	inline void set_tvTime_6(Text_t356221433 * value)
	{
		___tvTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvTime_6, value);
	}

	inline static int32_t get_offset_of_tvProgress_7() { return static_cast<int32_t>(offsetof(LogUI_t1659339182, ___tvProgress_7)); }
	inline Text_t356221433 * get_tvProgress_7() const { return ___tvProgress_7; }
	inline Text_t356221433 ** get_address_of_tvProgress_7() { return &___tvProgress_7; }
	inline void set_tvProgress_7(Text_t356221433 * value)
	{
		___tvProgress_7 = value;
		Il2CppCodeGenWriteBarrier(&___tvProgress_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
