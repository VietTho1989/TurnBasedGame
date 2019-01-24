#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ChatNormalContent/Message
struct  Message_t1364052338 
{
public:
	// System.Int64 ChatNormalContent/Message::time
	int64_t ___time_0;
	// System.String ChatNormalContent/Message::message
	String_t* ___message_1;

public:
	inline static int32_t get_offset_of_time_0() { return static_cast<int32_t>(offsetof(Message_t1364052338, ___time_0)); }
	inline int64_t get_time_0() const { return ___time_0; }
	inline int64_t* get_address_of_time_0() { return &___time_0; }
	inline void set_time_0(int64_t value)
	{
		___time_0 = value;
	}

	inline static int32_t get_offset_of_message_1() { return static_cast<int32_t>(offsetof(Message_t1364052338, ___message_1)); }
	inline String_t* get_message_1() const { return ___message_1; }
	inline String_t** get_address_of_message_1() { return &___message_1; }
	inline void set_message_1(String_t* value)
	{
		___message_1 = value;
		Il2CppCodeGenWriteBarrier(&___message_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of ChatNormalContent/Message
struct Message_t1364052338_marshaled_pinvoke
{
	int64_t ___time_0;
	char* ___message_1;
};
// Native definition for COM marshalling of ChatNormalContent/Message
struct Message_t1364052338_marshaled_com
{
	int64_t ___time_0;
	Il2CppChar* ___message_1;
};
