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

// UnityEngine.Networking.NetworkSystem.CRCMessageEntry
struct  CRCMessageEntry_t524088197 
{
public:
	// System.String UnityEngine.Networking.NetworkSystem.CRCMessageEntry::name
	String_t* ___name_0;
	// System.Byte UnityEngine.Networking.NetworkSystem.CRCMessageEntry::channel
	uint8_t ___channel_1;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(CRCMessageEntry_t524088197, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_channel_1() { return static_cast<int32_t>(offsetof(CRCMessageEntry_t524088197, ___channel_1)); }
	inline uint8_t get_channel_1() const { return ___channel_1; }
	inline uint8_t* get_address_of_channel_1() { return &___channel_1; }
	inline void set_channel_1(uint8_t value)
	{
		___channel_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Networking.NetworkSystem.CRCMessageEntry
struct CRCMessageEntry_t524088197_marshaled_pinvoke
{
	char* ___name_0;
	uint8_t ___channel_1;
};
// Native definition for COM marshalling of UnityEngine.Networking.NetworkSystem.CRCMessageEntry
struct CRCMessageEntry_t524088197_marshaled_com
{
	Il2CppChar* ___name_0;
	uint8_t ___channel_1;
};
