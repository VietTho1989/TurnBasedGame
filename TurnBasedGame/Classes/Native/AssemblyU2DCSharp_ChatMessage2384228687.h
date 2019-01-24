#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"
#include "mscorlib_System_DateTime693205669.h"

// VP`1<ChatMessage/State>
struct VP_1_t1161908229;
// VP`1<System.Int64>
struct VP_1_t1287355043;
// VP`1<ChatMessage/Content>
struct VP_1_t2462031859;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatMessage
struct  ChatMessage_t2384228687  : public Data_t3569509720
{
public:
	// VP`1<ChatMessage/State> ChatMessage::state
	VP_1_t1161908229 * ___state_5;
	// VP`1<System.Int64> ChatMessage::time
	VP_1_t1287355043 * ___time_6;
	// VP`1<ChatMessage/Content> ChatMessage::content
	VP_1_t2462031859 * ___content_8;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(ChatMessage_t2384228687, ___state_5)); }
	inline VP_1_t1161908229 * get_state_5() const { return ___state_5; }
	inline VP_1_t1161908229 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1161908229 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(ChatMessage_t2384228687, ___time_6)); }
	inline VP_1_t1287355043 * get_time_6() const { return ___time_6; }
	inline VP_1_t1287355043 ** get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(VP_1_t1287355043 * value)
	{
		___time_6 = value;
		Il2CppCodeGenWriteBarrier(&___time_6, value);
	}

	inline static int32_t get_offset_of_content_8() { return static_cast<int32_t>(offsetof(ChatMessage_t2384228687, ___content_8)); }
	inline VP_1_t2462031859 * get_content_8() const { return ___content_8; }
	inline VP_1_t2462031859 ** get_address_of_content_8() { return &___content_8; }
	inline void set_content_8(VP_1_t2462031859 * value)
	{
		___content_8 = value;
		Il2CppCodeGenWriteBarrier(&___content_8, value);
	}
};

struct ChatMessage_t2384228687_StaticFields
{
public:
	// System.DateTime ChatMessage::EPOCH_START_TIME
	DateTime_t693205669  ___EPOCH_START_TIME_7;

public:
	inline static int32_t get_offset_of_EPOCH_START_TIME_7() { return static_cast<int32_t>(offsetof(ChatMessage_t2384228687_StaticFields, ___EPOCH_START_TIME_7)); }
	inline DateTime_t693205669  get_EPOCH_START_TIME_7() const { return ___EPOCH_START_TIME_7; }
	inline DateTime_t693205669 * get_address_of_EPOCH_START_TIME_7() { return &___EPOCH_START_TIME_7; }
	inline void set_EPOCH_START_TIME_7(DateTime_t693205669  value)
	{
		___EPOCH_START_TIME_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
