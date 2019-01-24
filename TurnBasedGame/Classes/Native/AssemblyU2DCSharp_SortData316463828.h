#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<SortData/SortType>
struct VP_1_t3524480379;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SortData
struct  SortData_t316463828  : public Data_t3569509720
{
public:
	// VP`1<System.String> SortData::filter
	VP_1_t2407497239 * ___filter_5;
	// VP`1<SortData/SortType> SortData::sortType
	VP_1_t3524480379 * ___sortType_6;

public:
	inline static int32_t get_offset_of_filter_5() { return static_cast<int32_t>(offsetof(SortData_t316463828, ___filter_5)); }
	inline VP_1_t2407497239 * get_filter_5() const { return ___filter_5; }
	inline VP_1_t2407497239 ** get_address_of_filter_5() { return &___filter_5; }
	inline void set_filter_5(VP_1_t2407497239 * value)
	{
		___filter_5 = value;
		Il2CppCodeGenWriteBarrier(&___filter_5, value);
	}

	inline static int32_t get_offset_of_sortType_6() { return static_cast<int32_t>(offsetof(SortData_t316463828, ___sortType_6)); }
	inline VP_1_t3524480379 * get_sortType_6() const { return ___sortType_6; }
	inline VP_1_t3524480379 ** get_address_of_sortType_6() { return &___sortType_6; }
	inline void set_sortType_6(VP_1_t3524480379 * value)
	{
		___sortType_6 = value;
		Il2CppCodeGenWriteBarrier(&___sortType_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
