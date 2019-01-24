#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Utilities_3440239854.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.IO.PushbackStream
struct  PushbackStream_t2874148781  : public FilterStream_t3440239854
{
public:
	// System.Int32 Org.BouncyCastle.Utilities.IO.PushbackStream::buf
	int32_t ___buf_3;

public:
	inline static int32_t get_offset_of_buf_3() { return static_cast<int32_t>(offsetof(PushbackStream_t2874148781, ___buf_3)); }
	inline int32_t get_buf_3() const { return ___buf_3; }
	inline int32_t* get_address_of_buf_3() { return &___buf_3; }
	inline void set_buf_3(int32_t value)
	{
		___buf_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
