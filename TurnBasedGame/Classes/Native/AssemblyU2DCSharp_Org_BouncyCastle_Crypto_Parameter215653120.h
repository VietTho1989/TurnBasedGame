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

// Org.BouncyCastle.Crypto.Parameters.KeyParameter
struct  KeyParameter_t215653120  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.KeyParameter::key
	ByteU5BU5D_t3397334013* ___key_0;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(KeyParameter_t215653120, ___key_0)); }
	inline ByteU5BU5D_t3397334013* get_key_0() const { return ___key_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(ByteU5BU5D_t3397334013* value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
