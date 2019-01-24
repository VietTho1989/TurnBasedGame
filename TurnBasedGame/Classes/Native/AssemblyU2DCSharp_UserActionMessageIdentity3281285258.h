#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_UserActionMessage_Action3817957147.h"

// NetData`1<UserActionMessage>
struct NetData_1_t3023308129;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserActionMessageIdentity
struct  UserActionMessageIdentity_t3281285258  : public DataIdentity_t543951486
{
public:
	// System.UInt32 UserActionMessageIdentity::userId
	uint32_t ___userId_17;
	// UserActionMessage/Action UserActionMessageIdentity::action
	int32_t ___action_18;
	// NetData`1<UserActionMessage> UserActionMessageIdentity::netData
	NetData_1_t3023308129 * ___netData_19;

public:
	inline static int32_t get_offset_of_userId_17() { return static_cast<int32_t>(offsetof(UserActionMessageIdentity_t3281285258, ___userId_17)); }
	inline uint32_t get_userId_17() const { return ___userId_17; }
	inline uint32_t* get_address_of_userId_17() { return &___userId_17; }
	inline void set_userId_17(uint32_t value)
	{
		___userId_17 = value;
	}

	inline static int32_t get_offset_of_action_18() { return static_cast<int32_t>(offsetof(UserActionMessageIdentity_t3281285258, ___action_18)); }
	inline int32_t get_action_18() const { return ___action_18; }
	inline int32_t* get_address_of_action_18() { return &___action_18; }
	inline void set_action_18(int32_t value)
	{
		___action_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(UserActionMessageIdentity_t3281285258, ___netData_19)); }
	inline NetData_1_t3023308129 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t3023308129 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t3023308129 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
