#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<SortDataUI/UIData>
struct VP_1_t706396857;
// LP`1<RoomHolder/UIData>
struct LP_1_t1210746724;
// System.Collections.Generic.List`1<Room>
struct List_1_t411519505;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomAdapter/UIData
struct  UIData_t916454069  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<Server>> RoomAdapter/UIData::server
	VP_1_t2173380836 * ___server_20;
	// VP`1<SortDataUI/UIData> RoomAdapter/UIData::sortData
	VP_1_t706396857 * ___sortData_21;
	// LP`1<RoomHolder/UIData> RoomAdapter/UIData::holders
	LP_1_t1210746724 * ___holders_22;
	// System.Collections.Generic.List`1<Room> RoomAdapter/UIData::rooms
	List_1_t411519505 * ___rooms_23;

public:
	inline static int32_t get_offset_of_server_20() { return static_cast<int32_t>(offsetof(UIData_t916454069, ___server_20)); }
	inline VP_1_t2173380836 * get_server_20() const { return ___server_20; }
	inline VP_1_t2173380836 ** get_address_of_server_20() { return &___server_20; }
	inline void set_server_20(VP_1_t2173380836 * value)
	{
		___server_20 = value;
		Il2CppCodeGenWriteBarrier(&___server_20, value);
	}

	inline static int32_t get_offset_of_sortData_21() { return static_cast<int32_t>(offsetof(UIData_t916454069, ___sortData_21)); }
	inline VP_1_t706396857 * get_sortData_21() const { return ___sortData_21; }
	inline VP_1_t706396857 ** get_address_of_sortData_21() { return &___sortData_21; }
	inline void set_sortData_21(VP_1_t706396857 * value)
	{
		___sortData_21 = value;
		Il2CppCodeGenWriteBarrier(&___sortData_21, value);
	}

	inline static int32_t get_offset_of_holders_22() { return static_cast<int32_t>(offsetof(UIData_t916454069, ___holders_22)); }
	inline LP_1_t1210746724 * get_holders_22() const { return ___holders_22; }
	inline LP_1_t1210746724 ** get_address_of_holders_22() { return &___holders_22; }
	inline void set_holders_22(LP_1_t1210746724 * value)
	{
		___holders_22 = value;
		Il2CppCodeGenWriteBarrier(&___holders_22, value);
	}

	inline static int32_t get_offset_of_rooms_23() { return static_cast<int32_t>(offsetof(UIData_t916454069, ___rooms_23)); }
	inline List_1_t411519505 * get_rooms_23() const { return ___rooms_23; }
	inline List_1_t411519505 ** get_address_of_rooms_23() { return &___rooms_23; }
	inline void set_rooms_23(List_1_t411519505 * value)
	{
		___rooms_23 = value;
		Il2CppCodeGenWriteBarrier(&___rooms_23, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
