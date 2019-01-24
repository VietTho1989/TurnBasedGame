#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_RoomUser_Role677923855.h"
#include "AssemblyU2DCSharp_RoomUser_State1802867622.h"

// NetData`1<RoomUser>
struct NetData_1_t3159877181;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomUserIdentity
struct  RoomUserIdentity_t3068918298  : public DataIdentity_t543951486
{
public:
	// RoomUser/Role RoomUserIdentity::role
	int32_t ___role_17;
	// RoomUser/State RoomUserIdentity::state
	int32_t ___state_18;
	// NetData`1<RoomUser> RoomUserIdentity::netData
	NetData_1_t3159877181 * ___netData_19;

public:
	inline static int32_t get_offset_of_role_17() { return static_cast<int32_t>(offsetof(RoomUserIdentity_t3068918298, ___role_17)); }
	inline int32_t get_role_17() const { return ___role_17; }
	inline int32_t* get_address_of_role_17() { return &___role_17; }
	inline void set_role_17(int32_t value)
	{
		___role_17 = value;
	}

	inline static int32_t get_offset_of_state_18() { return static_cast<int32_t>(offsetof(RoomUserIdentity_t3068918298, ___state_18)); }
	inline int32_t get_state_18() const { return ___state_18; }
	inline int32_t* get_address_of_state_18() { return &___state_18; }
	inline void set_state_18(int32_t value)
	{
		___state_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(RoomUserIdentity_t3068918298, ___netData_19)); }
	inline NetData_1_t3159877181 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3159877181 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3159877181 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
