﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<ClientInput>>
struct VP_1_t542967082;
// VP`1<ClientInputUI/UIData/Sub>
struct VP_1_t1605371383;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientInputUI/UIData
struct  UIData_t2832171482  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<ClientInput>> ClientInputUI/UIData::clientInput
	VP_1_t542967082 * ___clientInput_5;
	// VP`1<ClientInputUI/UIData/Sub> ClientInputUI/UIData::sub
	VP_1_t1605371383 * ___sub_6;

public:
	inline static int32_t get_offset_of_clientInput_5() { return static_cast<int32_t>(offsetof(UIData_t2832171482, ___clientInput_5)); }
	inline VP_1_t542967082 * get_clientInput_5() const { return ___clientInput_5; }
	inline VP_1_t542967082 ** get_address_of_clientInput_5() { return &___clientInput_5; }
	inline void set_clientInput_5(VP_1_t542967082 * value)
	{
		___clientInput_5 = value;
		Il2CppCodeGenWriteBarrier(&___clientInput_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2832171482, ___sub_6)); }
	inline VP_1_t1605371383 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1605371383 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1605371383 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif