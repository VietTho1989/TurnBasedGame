#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Rights_Limit_UIData2904876889.h"

// VP`1<EditData`1<Rights.HaveLimit>>
struct VP_1_t3476127545;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.HaveLimitUI/UIData
struct  UIData_t1581843351  : public UIData_t2904876889
{
public:
	// VP`1<EditData`1<Rights.HaveLimit>> Rights.HaveLimitUI/UIData::editHaveLimit
	VP_1_t3476127545 * ___editHaveLimit_5;
	// VP`1<RequestChangeIntUI/UIData> Rights.HaveLimitUI/UIData::limit
	VP_1_t1437137211 * ___limit_6;

public:
	inline static int32_t get_offset_of_editHaveLimit_5() { return static_cast<int32_t>(offsetof(UIData_t1581843351, ___editHaveLimit_5)); }
	inline VP_1_t3476127545 * get_editHaveLimit_5() const { return ___editHaveLimit_5; }
	inline VP_1_t3476127545 ** get_address_of_editHaveLimit_5() { return &___editHaveLimit_5; }
	inline void set_editHaveLimit_5(VP_1_t3476127545 * value)
	{
		___editHaveLimit_5 = value;
		Il2CppCodeGenWriteBarrier(&___editHaveLimit_5, value);
	}

	inline static int32_t get_offset_of_limit_6() { return static_cast<int32_t>(offsetof(UIData_t1581843351, ___limit_6)); }
	inline VP_1_t1437137211 * get_limit_6() const { return ___limit_6; }
	inline VP_1_t1437137211 ** get_address_of_limit_6() { return &___limit_6; }
	inline void set_limit_6(VP_1_t1437137211 * value)
	{
		___limit_6 = value;
		Il2CppCodeGenWriteBarrier(&___limit_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
