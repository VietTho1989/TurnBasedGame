#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1638006231.h"

// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.ResultUI
struct  ResultUI_t2447012345  : public UIBehavior_1_t1638006231
{
public:
	// UnityEngine.UI.Text GameState.ResultUI::tvResult
	Text_t356221433 * ___tvResult_6;

public:
	inline static int32_t get_offset_of_tvResult_6() { return static_cast<int32_t>(offsetof(ResultUI_t2447012345, ___tvResult_6)); }
	inline Text_t356221433 * get_tvResult_6() const { return ___tvResult_6; }
	inline Text_t356221433 ** get_address_of_tvResult_6() { return &___tvResult_6; }
	inline void set_tvResult_6(Text_t356221433 * value)
	{
		___tvResult_6 = value;
		Il2CppCodeGenWriteBarrier(&___tvResult_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
