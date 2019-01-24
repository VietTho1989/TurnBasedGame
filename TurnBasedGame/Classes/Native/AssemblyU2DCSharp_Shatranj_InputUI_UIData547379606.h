#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Shatranj.Shatranj>>
struct VP_1_t2644303178;
// VP`1<Shatranj.InputUI/UIData/Sub>
struct VP_1_t1726607329;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.InputUI/UIData
struct  UIData_t547379606  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shatranj.Shatranj>> Shatranj.InputUI/UIData::shatranj
	VP_1_t2644303178 * ___shatranj_5;
	// VP`1<Shatranj.InputUI/UIData/Sub> Shatranj.InputUI/UIData::sub
	VP_1_t1726607329 * ___sub_6;

public:
	inline static int32_t get_offset_of_shatranj_5() { return static_cast<int32_t>(offsetof(UIData_t547379606, ___shatranj_5)); }
	inline VP_1_t2644303178 * get_shatranj_5() const { return ___shatranj_5; }
	inline VP_1_t2644303178 ** get_address_of_shatranj_5() { return &___shatranj_5; }
	inline void set_shatranj_5(VP_1_t2644303178 * value)
	{
		___shatranj_5 = value;
		Il2CppCodeGenWriteBarrier(&___shatranj_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t547379606, ___sub_6)); }
	inline VP_1_t1726607329 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1726607329 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1726607329 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
