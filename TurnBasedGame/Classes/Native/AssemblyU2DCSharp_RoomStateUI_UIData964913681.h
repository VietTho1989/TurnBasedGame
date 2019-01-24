#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Room/State>>
struct VP_1_t3232708598;
// VP`1<RoomStateUI/UIData/Sub>
struct VP_1_t1974806378;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateUI/UIData
struct  UIData_t964913681  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Room/State>> RoomStateUI/UIData::roomState
	VP_1_t3232708598 * ___roomState_5;
	// VP`1<RoomStateUI/UIData/Sub> RoomStateUI/UIData::sub
	VP_1_t1974806378 * ___sub_6;

public:
	inline static int32_t get_offset_of_roomState_5() { return static_cast<int32_t>(offsetof(UIData_t964913681, ___roomState_5)); }
	inline VP_1_t3232708598 * get_roomState_5() const { return ___roomState_5; }
	inline VP_1_t3232708598 ** get_address_of_roomState_5() { return &___roomState_5; }
	inline void set_roomState_5(VP_1_t3232708598 * value)
	{
		___roomState_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomState_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t964913681, ___sub_6)); }
	inline VP_1_t1974806378 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1974806378 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1974806378 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
