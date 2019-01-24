#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<RoomUser>>
struct VP_1_t2362588725;
// VP`1<RoomUserBtnKickUI/UIData/State>
struct VP_1_t2092717299;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserBtnKickUI/UIData
struct  UIData_t2044232641  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RoomUser>> RoomUserBtnKickUI/UIData::roomUser
	VP_1_t2362588725 * ___roomUser_5;
	// VP`1<RoomUserBtnKickUI/UIData/State> RoomUserBtnKickUI/UIData::state
	VP_1_t2092717299 * ___state_6;

public:
	inline static int32_t get_offset_of_roomUser_5() { return static_cast<int32_t>(offsetof(UIData_t2044232641, ___roomUser_5)); }
	inline VP_1_t2362588725 * get_roomUser_5() const { return ___roomUser_5; }
	inline VP_1_t2362588725 ** get_address_of_roomUser_5() { return &___roomUser_5; }
	inline void set_roomUser_5(VP_1_t2362588725 * value)
	{
		___roomUser_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomUser_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t2044232641, ___state_6)); }
	inline VP_1_t2092717299 * get_state_6() const { return ___state_6; }
	inline VP_1_t2092717299 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2092717299 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
