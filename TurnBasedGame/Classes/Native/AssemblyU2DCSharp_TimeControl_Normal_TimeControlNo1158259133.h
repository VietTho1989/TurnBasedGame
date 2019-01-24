#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TimeControl_TimeControlUI_UIData3367598026.h"

// VP`1<EditData`1<TimeControl.Normal.TimeControlNormal>>
struct VP_1_t4108225049;
// VP`1<TimeControl.Normal.TimeInfoUI/UIData>
struct VP_1_t2705611277;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeControlNormalUI/UIData
struct  UIData_t1158259133  : public Sub_t3367598026
{
public:
	// VP`1<EditData`1<TimeControl.Normal.TimeControlNormal>> TimeControl.Normal.TimeControlNormalUI/UIData::editTimeControlNormal
	VP_1_t4108225049 * ___editTimeControlNormal_5;
	// VP`1<TimeControl.Normal.TimeInfoUI/UIData> TimeControl.Normal.TimeControlNormalUI/UIData::generalInfo
	VP_1_t2705611277 * ___generalInfo_6;

public:
	inline static int32_t get_offset_of_editTimeControlNormal_5() { return static_cast<int32_t>(offsetof(UIData_t1158259133, ___editTimeControlNormal_5)); }
	inline VP_1_t4108225049 * get_editTimeControlNormal_5() const { return ___editTimeControlNormal_5; }
	inline VP_1_t4108225049 ** get_address_of_editTimeControlNormal_5() { return &___editTimeControlNormal_5; }
	inline void set_editTimeControlNormal_5(VP_1_t4108225049 * value)
	{
		___editTimeControlNormal_5 = value;
		Il2CppCodeGenWriteBarrier(&___editTimeControlNormal_5, value);
	}

	inline static int32_t get_offset_of_generalInfo_6() { return static_cast<int32_t>(offsetof(UIData_t1158259133, ___generalInfo_6)); }
	inline VP_1_t2705611277 * get_generalInfo_6() const { return ___generalInfo_6; }
	inline VP_1_t2705611277 ** get_address_of_generalInfo_6() { return &___generalInfo_6; }
	inline void set_generalInfo_6(VP_1_t2705611277 * value)
	{
		___generalInfo_6 = value;
		Il2CppCodeGenWriteBarrier(&___generalInfo_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
