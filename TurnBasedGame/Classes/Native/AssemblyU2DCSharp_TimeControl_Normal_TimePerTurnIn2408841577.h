#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<EditData`1<TimeControl.Normal.TimePerTurnInfo>>
struct VP_1_t3557510795;
// VP`1<TimeControl.Normal.TimePerTurnInfoUI/UIData/Sub>
struct VP_1_t309194248;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimePerTurnInfoUI/UIData
struct  UIData_t2408841577  : public Data_t3569509720
{
public:
	// VP`1<EditData`1<TimeControl.Normal.TimePerTurnInfo>> TimeControl.Normal.TimePerTurnInfoUI/UIData::editTimePerTurnInfo
	VP_1_t3557510795 * ___editTimePerTurnInfo_5;
	// VP`1<TimeControl.Normal.TimePerTurnInfoUI/UIData/Sub> TimeControl.Normal.TimePerTurnInfoUI/UIData::sub
	VP_1_t309194248 * ___sub_6;

public:
	inline static int32_t get_offset_of_editTimePerTurnInfo_5() { return static_cast<int32_t>(offsetof(UIData_t2408841577, ___editTimePerTurnInfo_5)); }
	inline VP_1_t3557510795 * get_editTimePerTurnInfo_5() const { return ___editTimePerTurnInfo_5; }
	inline VP_1_t3557510795 ** get_address_of_editTimePerTurnInfo_5() { return &___editTimePerTurnInfo_5; }
	inline void set_editTimePerTurnInfo_5(VP_1_t3557510795 * value)
	{
		___editTimePerTurnInfo_5 = value;
		Il2CppCodeGenWriteBarrier(&___editTimePerTurnInfo_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2408841577, ___sub_6)); }
	inline VP_1_t309194248 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t309194248 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t309194248 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
