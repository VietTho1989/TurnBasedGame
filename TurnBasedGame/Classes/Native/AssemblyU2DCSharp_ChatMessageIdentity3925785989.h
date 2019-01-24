#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_ChatMessage_State783631223.h"

// NetData`1<ChatMessage>
struct NetData_1_t2630577212;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatMessageIdentity
struct  ChatMessageIdentity_t3925785989  : public DataIdentity_t543951486
{
public:
	// ChatMessage/State ChatMessageIdentity::state
	int32_t ___state_17;
	// System.Int64 ChatMessageIdentity::time
	int64_t ___time_18;
	// NetData`1<ChatMessage> ChatMessageIdentity::netData
	NetData_1_t2630577212 * ___netData_19;

public:
	inline static int32_t get_offset_of_state_17() { return static_cast<int32_t>(offsetof(ChatMessageIdentity_t3925785989, ___state_17)); }
	inline int32_t get_state_17() const { return ___state_17; }
	inline int32_t* get_address_of_state_17() { return &___state_17; }
	inline void set_state_17(int32_t value)
	{
		___state_17 = value;
	}

	inline static int32_t get_offset_of_time_18() { return static_cast<int32_t>(offsetof(ChatMessageIdentity_t3925785989, ___time_18)); }
	inline int64_t get_time_18() const { return ___time_18; }
	inline int64_t* get_address_of_time_18() { return &___time_18; }
	inline void set_time_18(int64_t value)
	{
		___time_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(ChatMessageIdentity_t3925785989, ___netData_19)); }
	inline NetData_1_t2630577212 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2630577212 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2630577212 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
