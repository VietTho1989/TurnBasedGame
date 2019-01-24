#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Hint_HintUI_UIData_State1980716959.h"

// VP`1<GameMove>
struct VP_1_t2240176003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Hint.ShowUI/UIData
struct  UIData_t4226086491  : public State_t1980716959
{
public:
	// VP`1<GameMove> Hint.ShowUI/UIData::hintMove
	VP_1_t2240176003 * ___hintMove_5;

public:
	inline static int32_t get_offset_of_hintMove_5() { return static_cast<int32_t>(offsetof(UIData_t4226086491, ___hintMove_5)); }
	inline VP_1_t2240176003 * get_hintMove_5() const { return ___hintMove_5; }
	inline VP_1_t2240176003 ** get_address_of_hintMove_5() { return &___hintMove_5; }
	inline void set_hintMove_5(VP_1_t2240176003 * value)
	{
		___hintMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___hintMove_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
