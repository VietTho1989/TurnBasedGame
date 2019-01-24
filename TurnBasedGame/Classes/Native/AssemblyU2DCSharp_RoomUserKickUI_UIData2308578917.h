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
// VP`1<RoomUserBtnKickUI/UIData>
struct VP_1_t2422509647;
// VP`1<RoomUserBtnUnKickUI/UIData>
struct VP_1_t3805984968;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserKickUI/UIData
struct  UIData_t2308578917  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RoomUser>> RoomUserKickUI/UIData::roomUser
	VP_1_t2362588725 * ___roomUser_5;
	// VP`1<RoomUserBtnKickUI/UIData> RoomUserKickUI/UIData::btnKick
	VP_1_t2422509647 * ___btnKick_6;
	// VP`1<RoomUserBtnUnKickUI/UIData> RoomUserKickUI/UIData::btnUnKick
	VP_1_t3805984968 * ___btnUnKick_7;

public:
	inline static int32_t get_offset_of_roomUser_5() { return static_cast<int32_t>(offsetof(UIData_t2308578917, ___roomUser_5)); }
	inline VP_1_t2362588725 * get_roomUser_5() const { return ___roomUser_5; }
	inline VP_1_t2362588725 ** get_address_of_roomUser_5() { return &___roomUser_5; }
	inline void set_roomUser_5(VP_1_t2362588725 * value)
	{
		___roomUser_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomUser_5, value);
	}

	inline static int32_t get_offset_of_btnKick_6() { return static_cast<int32_t>(offsetof(UIData_t2308578917, ___btnKick_6)); }
	inline VP_1_t2422509647 * get_btnKick_6() const { return ___btnKick_6; }
	inline VP_1_t2422509647 ** get_address_of_btnKick_6() { return &___btnKick_6; }
	inline void set_btnKick_6(VP_1_t2422509647 * value)
	{
		___btnKick_6 = value;
		Il2CppCodeGenWriteBarrier(&___btnKick_6, value);
	}

	inline static int32_t get_offset_of_btnUnKick_7() { return static_cast<int32_t>(offsetof(UIData_t2308578917, ___btnUnKick_7)); }
	inline VP_1_t3805984968 * get_btnUnKick_7() const { return ___btnUnKick_7; }
	inline VP_1_t3805984968 ** get_address_of_btnUnKick_7() { return &___btnUnKick_7; }
	inline void set_btnUnKick_7(VP_1_t3805984968 * value)
	{
		___btnUnKick_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnUnKick_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
