#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_RoomListUI_UIData_Sub3768996779.h"

// VP`1<EditData`1<CreateRoom>>
struct VP_1_t3415967323;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CreateRoomUI/UIData
struct  UIData_t3959676436  : public Sub_t3768996779
{
public:
	// VP`1<EditData`1<CreateRoom>> CreateRoomUI/UIData::editCreateRoom
	VP_1_t3415967323 * ___editCreateRoom_5;
	// VP`1<RequestChangeEnumUI/UIData> CreateRoomUI/UIData::gameType
	VP_1_t3850875635 * ___gameType_6;
	// VP`1<RequestChangeStringUI/UIData> CreateRoomUI/UIData::roomName
	VP_1_t1525575381 * ___roomName_7;
	// VP`1<RequestChangeStringUI/UIData> CreateRoomUI/UIData::password
	VP_1_t1525575381 * ___password_8;

public:
	inline static int32_t get_offset_of_editCreateRoom_5() { return static_cast<int32_t>(offsetof(UIData_t3959676436, ___editCreateRoom_5)); }
	inline VP_1_t3415967323 * get_editCreateRoom_5() const { return ___editCreateRoom_5; }
	inline VP_1_t3415967323 ** get_address_of_editCreateRoom_5() { return &___editCreateRoom_5; }
	inline void set_editCreateRoom_5(VP_1_t3415967323 * value)
	{
		___editCreateRoom_5 = value;
		Il2CppCodeGenWriteBarrier(&___editCreateRoom_5, value);
	}

	inline static int32_t get_offset_of_gameType_6() { return static_cast<int32_t>(offsetof(UIData_t3959676436, ___gameType_6)); }
	inline VP_1_t3850875635 * get_gameType_6() const { return ___gameType_6; }
	inline VP_1_t3850875635 ** get_address_of_gameType_6() { return &___gameType_6; }
	inline void set_gameType_6(VP_1_t3850875635 * value)
	{
		___gameType_6 = value;
		Il2CppCodeGenWriteBarrier(&___gameType_6, value);
	}

	inline static int32_t get_offset_of_roomName_7() { return static_cast<int32_t>(offsetof(UIData_t3959676436, ___roomName_7)); }
	inline VP_1_t1525575381 * get_roomName_7() const { return ___roomName_7; }
	inline VP_1_t1525575381 ** get_address_of_roomName_7() { return &___roomName_7; }
	inline void set_roomName_7(VP_1_t1525575381 * value)
	{
		___roomName_7 = value;
		Il2CppCodeGenWriteBarrier(&___roomName_7, value);
	}

	inline static int32_t get_offset_of_password_8() { return static_cast<int32_t>(offsetof(UIData_t3959676436, ___password_8)); }
	inline VP_1_t1525575381 * get_password_8() const { return ___password_8; }
	inline VP_1_t1525575381 ** get_address_of_password_8() { return &___password_8; }
	inline void set_password_8(VP_1_t1525575381 * value)
	{
		___password_8 = value;
		Il2CppCodeGenWriteBarrier(&___password_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
