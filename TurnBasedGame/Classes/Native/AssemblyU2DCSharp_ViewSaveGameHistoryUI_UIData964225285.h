﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<History>>
struct VP_1_t3287900393;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ViewSaveGameHistoryUI/UIData
struct  UIData_t964225285  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<History>> ViewSaveGameHistoryUI/UIData::history
	VP_1_t3287900393 * ___history_5;

public:
	inline static int32_t get_offset_of_history_5() { return static_cast<int32_t>(offsetof(UIData_t964225285, ___history_5)); }
	inline VP_1_t3287900393 * get_history_5() const { return ___history_5; }
	inline VP_1_t3287900393 ** get_address_of_history_5() { return &___history_5; }
	inline void set_history_5(VP_1_t3287900393 * value)
	{
		___history_5 = value;
		Il2CppCodeGenWriteBarrier(&___history_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif