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

// Org.BouncyCastle.Crypto.Parameters.KdfParameters
struct  KdfParameters_t1337840219  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.KdfParameters::iv
	ByteU5BU5D_t3397334013* ___iv_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.KdfParameters::shared
	ByteU5BU5D_t3397334013* ___shared_1;

public:
	inline static int32_t get_offset_of_iv_0() { return static_cast<int32_t>(offsetof(KdfParameters_t1337840219, ___iv_0)); }
	inline ByteU5BU5D_t3397334013* get_iv_0() const { return ___iv_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_iv_0() { return &___iv_0; }
	inline void set_iv_0(ByteU5BU5D_t3397334013* value)
	{
		___iv_0 = value;
		Il2CppCodeGenWriteBarrier(&___iv_0, value);
	}

	inline static int32_t get_offset_of_shared_1() { return static_cast<int32_t>(offsetof(KdfParameters_t1337840219, ___shared_1)); }
	inline ByteU5BU5D_t3397334013* get_shared_1() const { return ___shared_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_shared_1() { return &___shared_1; }
	inline void set_shared_1(ByteU5BU5D_t3397334013* value)
	{
		___shared_1 = value;
		Il2CppCodeGenWriteBarrier(&___shared_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
