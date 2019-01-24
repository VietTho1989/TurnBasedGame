#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<Room>>
struct VP_1_t491458442;
// LP`1<RoomUserHolder/UIData>
struct LP_1_t613623183;
// System.Collections.Generic.List`1<RoomUser>
struct List_1_t2282649788;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserAdapter/UIData
struct  UIData_t115426826  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<Room>> RoomUserAdapter/UIData::room
	VP_1_t491458442 * ___room_20;
	// LP`1<RoomUserHolder/UIData> RoomUserAdapter/UIData::holders
	LP_1_t613623183 * ___holders_21;
	// System.Collections.Generic.List`1<RoomUser> RoomUserAdapter/UIData::roomUsers
	List_1_t2282649788 * ___roomUsers_22;

public:
	inline static int32_t get_offset_of_room_20() { return static_cast<int32_t>(offsetof(UIData_t115426826, ___room_20)); }
	inline VP_1_t491458442 * get_room_20() const { return ___room_20; }
	inline VP_1_t491458442 ** get_address_of_room_20() { return &___room_20; }
	inline void set_room_20(VP_1_t491458442 * value)
	{
		___room_20 = value;
		Il2CppCodeGenWriteBarrier(&___room_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t115426826, ___holders_21)); }
	inline LP_1_t613623183 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t613623183 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t613623183 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_roomUsers_22() { return static_cast<int32_t>(offsetof(UIData_t115426826, ___roomUsers_22)); }
	inline List_1_t2282649788 * get_roomUsers_22() const { return ___roomUsers_22; }
	inline List_1_t2282649788 ** get_address_of_roomUsers_22() { return &___roomUsers_22; }
	inline void set_roomUsers_22(List_1_t2282649788 * value)
	{
		___roomUsers_22 = value;
		Il2CppCodeGenWriteBarrier(&___roomUsers_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
