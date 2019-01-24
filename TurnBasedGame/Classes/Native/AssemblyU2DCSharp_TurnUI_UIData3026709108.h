#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Turn>>
struct VP_1_t3596775048;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TurnUI/UIData
struct  UIData_t3026709108  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Turn>> TurnUI/UIData::turn
	VP_1_t3596775048 * ___turn_5;

public:
	inline static int32_t get_offset_of_turn_5() { return static_cast<int32_t>(offsetof(UIData_t3026709108, ___turn_5)); }
	inline VP_1_t3596775048 * get_turn_5() const { return ___turn_5; }
	inline VP_1_t3596775048 ** get_address_of_turn_5() { return &___turn_5; }
	inline void set_turn_5(VP_1_t3596775048 * value)
	{
		___turn_5 = value;
		Il2CppCodeGenWriteBarrier(&___turn_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
