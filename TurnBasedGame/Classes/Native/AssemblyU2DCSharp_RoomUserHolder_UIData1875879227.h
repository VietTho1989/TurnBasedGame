﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<RoomUser>>
struct VP_1_t2362588725;
// VP`1<AccountAvatarUI/UIData>
struct VP_1_t3547432187;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserHolder/UIData
struct  UIData_t1875879227  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<RoomUser>> RoomUserHolder/UIData::roomUser
	VP_1_t2362588725 * ___roomUser_8;
	// VP`1<AccountAvatarUI/UIData> RoomUserHolder/UIData::avatar
	VP_1_t3547432187 * ___avatar_9;

public:
	inline static int32_t get_offset_of_roomUser_8() { return static_cast<int32_t>(offsetof(UIData_t1875879227, ___roomUser_8)); }
	inline VP_1_t2362588725 * get_roomUser_8() const { return ___roomUser_8; }
	inline VP_1_t2362588725 ** get_address_of_roomUser_8() { return &___roomUser_8; }
	inline void set_roomUser_8(VP_1_t2362588725 * value)
	{
		___roomUser_8 = value;
		Il2CppCodeGenWriteBarrier(&___roomUser_8, value);
	}

	inline static int32_t get_offset_of_avatar_9() { return static_cast<int32_t>(offsetof(UIData_t1875879227, ___avatar_9)); }
	inline VP_1_t3547432187 * get_avatar_9() const { return ___avatar_9; }
	inline VP_1_t3547432187 ** get_address_of_avatar_9() { return &___avatar_9; }
	inline void set_avatar_9(VP_1_t3547432187 * value)
	{
		___avatar_9 = value;
		Il2CppCodeGenWriteBarrier(&___avatar_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif