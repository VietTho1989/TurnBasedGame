#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.MemoryStream
struct MemoryStream_t743994179;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Digests.NullDigest
struct  NullDigest_t368343707  : public Il2CppObject
{
public:
	// System.IO.MemoryStream Org.BouncyCastle.Crypto.Digests.NullDigest::bOut
	MemoryStream_t743994179 * ___bOut_0;

public:
	inline static int32_t get_offset_of_bOut_0() { return static_cast<int32_t>(offsetof(NullDigest_t368343707, ___bOut_0)); }
	inline MemoryStream_t743994179 * get_bOut_0() const { return ___bOut_0; }
	inline MemoryStream_t743994179 ** get_address_of_bOut_0() { return &___bOut_0; }
	inline void set_bOut_0(MemoryStream_t743994179 * value)
	{
		___bOut_0 = value;
		Il2CppCodeGenWriteBarrier(&___bOut_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
