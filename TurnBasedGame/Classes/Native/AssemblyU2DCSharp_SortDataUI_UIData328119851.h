#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<EditData`1<SortData>>
struct VP_1_t2450469894;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SortDataUI/UIData
struct  UIData_t328119851  : public Data_t3569509720
{
public:
	// VP`1<EditData`1<SortData>> SortDataUI/UIData::editSortData
	VP_1_t2450469894 * ___editSortData_5;
	// VP`1<RequestChangeStringUI/UIData> SortDataUI/UIData::filter
	VP_1_t1525575381 * ___filter_6;
	// VP`1<RequestChangeEnumUI/UIData> SortDataUI/UIData::sortType
	VP_1_t3850875635 * ___sortType_7;

public:
	inline static int32_t get_offset_of_editSortData_5() { return static_cast<int32_t>(offsetof(UIData_t328119851, ___editSortData_5)); }
	inline VP_1_t2450469894 * get_editSortData_5() const { return ___editSortData_5; }
	inline VP_1_t2450469894 ** get_address_of_editSortData_5() { return &___editSortData_5; }
	inline void set_editSortData_5(VP_1_t2450469894 * value)
	{
		___editSortData_5 = value;
		Il2CppCodeGenWriteBarrier(&___editSortData_5, value);
	}

	inline static int32_t get_offset_of_filter_6() { return static_cast<int32_t>(offsetof(UIData_t328119851, ___filter_6)); }
	inline VP_1_t1525575381 * get_filter_6() const { return ___filter_6; }
	inline VP_1_t1525575381 ** get_address_of_filter_6() { return &___filter_6; }
	inline void set_filter_6(VP_1_t1525575381 * value)
	{
		___filter_6 = value;
		Il2CppCodeGenWriteBarrier(&___filter_6, value);
	}

	inline static int32_t get_offset_of_sortType_7() { return static_cast<int32_t>(offsetof(UIData_t328119851, ___sortType_7)); }
	inline VP_1_t3850875635 * get_sortType_7() const { return ___sortType_7; }
	inline VP_1_t3850875635 ** get_address_of_sortType_7() { return &___sortType_7; }
	inline void set_sortType_7(VP_1_t3850875635 * value)
	{
		___sortType_7 = value;
		Il2CppCodeGenWriteBarrier(&___sortType_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
