#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.BinaryWriter
struct BinaryWriter_t3179371318;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.HTTPRequest/<SendHeaders>c__AnonStorey1
struct  U3CSendHeadersU3Ec__AnonStorey1_t3710205996  : public Il2CppObject
{
public:
	// System.IO.BinaryWriter BestHTTP.HTTPRequest/<SendHeaders>c__AnonStorey1::stream
	BinaryWriter_t3179371318 * ___stream_0;

public:
	inline static int32_t get_offset_of_stream_0() { return static_cast<int32_t>(offsetof(U3CSendHeadersU3Ec__AnonStorey1_t3710205996, ___stream_0)); }
	inline BinaryWriter_t3179371318 * get_stream_0() const { return ___stream_0; }
	inline BinaryWriter_t3179371318 ** get_address_of_stream_0() { return &___stream_0; }
	inline void set_stream_0(BinaryWriter_t3179371318 * value)
	{
		___stream_0 = value;
		Il2CppCodeGenWriteBarrier(&___stream_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
