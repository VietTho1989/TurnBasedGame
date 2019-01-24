#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.Iso18033KdfParameters
struct  Iso18033KdfParameters_t964742789  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.Iso18033KdfParameters::seed
	ByteU5BU5D_t3397334013* ___seed_0;

public:
	inline static int32_t get_offset_of_seed_0() { return static_cast<int32_t>(offsetof(Iso18033KdfParameters_t964742789, ___seed_0)); }
	inline ByteU5BU5D_t3397334013* get_seed_0() const { return ___seed_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_0() { return &___seed_0; }
	inline void set_seed_0(ByteU5BU5D_t3397334013* value)
	{
		___seed_0 = value;
		Il2CppCodeGenWriteBarrier(&___seed_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
