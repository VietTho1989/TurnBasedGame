#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GlobalRoomsUI_UIData_Sub4229027329.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<RoomAdapter/UIData>
struct VP_1_t1294731075;
// VP`1<RoomListUI/UIData/Sub>
struct VP_1_t4147273785;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomListUI/UIData
struct  UIData_t2342812172  : public Sub_t4229027329
{
public:
	// VP`1<ReferenceData`1<Server>> RoomListUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<RoomAdapter/UIData> RoomListUI/UIData::roomAdapter
	VP_1_t1294731075 * ___roomAdapter_6;
	// VP`1<RoomListUI/UIData/Sub> RoomListUI/UIData::sub
	VP_1_t4147273785 * ___sub_7;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t2342812172, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_roomAdapter_6() { return static_cast<int32_t>(offsetof(UIData_t2342812172, ___roomAdapter_6)); }
	inline VP_1_t1294731075 * get_roomAdapter_6() const { return ___roomAdapter_6; }
	inline VP_1_t1294731075 ** get_address_of_roomAdapter_6() { return &___roomAdapter_6; }
	inline void set_roomAdapter_6(VP_1_t1294731075 * value)
	{
		___roomAdapter_6 = value;
		Il2CppCodeGenWriteBarrier(&___roomAdapter_6, value);
	}

	inline static int32_t get_offset_of_sub_7() { return static_cast<int32_t>(offsetof(UIData_t2342812172, ___sub_7)); }
	inline VP_1_t4147273785 * get_sub_7() const { return ___sub_7; }
	inline VP_1_t4147273785 ** get_address_of_sub_7() { return &___sub_7; }
	inline void set_sub_7(VP_1_t4147273785 * value)
	{
		___sub_7 = value;
		Il2CppCodeGenWriteBarrier(&___sub_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
