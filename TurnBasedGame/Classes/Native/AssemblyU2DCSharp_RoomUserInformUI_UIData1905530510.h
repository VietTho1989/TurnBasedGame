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
// VP`1<HumanUI/UIData>
struct VP_1_t3489413060;
// VP`1<UserMakeFriendUI/UIData>
struct VP_1_t501756084;
// VP`1<RoomUserKickUI/UIData>
struct VP_1_t2686855923;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserInformUI/UIData
struct  UIData_t1905530510  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RoomUser>> RoomUserInformUI/UIData::roomUser
	VP_1_t2362588725 * ___roomUser_5;
	// VP`1<HumanUI/UIData> RoomUserInformUI/UIData::humanUI
	VP_1_t3489413060 * ___humanUI_6;
	// VP`1<UserMakeFriendUI/UIData> RoomUserInformUI/UIData::userMakeFriend
	VP_1_t501756084 * ___userMakeFriend_7;
	// VP`1<RoomUserKickUI/UIData> RoomUserInformUI/UIData::kickUI
	VP_1_t2686855923 * ___kickUI_8;

public:
	inline static int32_t get_offset_of_roomUser_5() { return static_cast<int32_t>(offsetof(UIData_t1905530510, ___roomUser_5)); }
	inline VP_1_t2362588725 * get_roomUser_5() const { return ___roomUser_5; }
	inline VP_1_t2362588725 ** get_address_of_roomUser_5() { return &___roomUser_5; }
	inline void set_roomUser_5(VP_1_t2362588725 * value)
	{
		___roomUser_5 = value;
		Il2CppCodeGenWriteBarrier(&___roomUser_5, value);
	}

	inline static int32_t get_offset_of_humanUI_6() { return static_cast<int32_t>(offsetof(UIData_t1905530510, ___humanUI_6)); }
	inline VP_1_t3489413060 * get_humanUI_6() const { return ___humanUI_6; }
	inline VP_1_t3489413060 ** get_address_of_humanUI_6() { return &___humanUI_6; }
	inline void set_humanUI_6(VP_1_t3489413060 * value)
	{
		___humanUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___humanUI_6, value);
	}

	inline static int32_t get_offset_of_userMakeFriend_7() { return static_cast<int32_t>(offsetof(UIData_t1905530510, ___userMakeFriend_7)); }
	inline VP_1_t501756084 * get_userMakeFriend_7() const { return ___userMakeFriend_7; }
	inline VP_1_t501756084 ** get_address_of_userMakeFriend_7() { return &___userMakeFriend_7; }
	inline void set_userMakeFriend_7(VP_1_t501756084 * value)
	{
		___userMakeFriend_7 = value;
		Il2CppCodeGenWriteBarrier(&___userMakeFriend_7, value);
	}

	inline static int32_t get_offset_of_kickUI_8() { return static_cast<int32_t>(offsetof(UIData_t1905530510, ___kickUI_8)); }
	inline VP_1_t2686855923 * get_kickUI_8() const { return ___kickUI_8; }
	inline VP_1_t2686855923 ** get_address_of_kickUI_8() { return &___kickUI_8; }
	inline void set_kickUI_8(VP_1_t2686855923 * value)
	{
		___kickUI_8 = value;
		Il2CppCodeGenWriteBarrier(&___kickUI_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
