#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Parameter215653120.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DesParameters
struct  DesParameters_t4026919406  : public KeyParameter_t215653120
{
public:

public:
};

struct DesParameters_t4026919406_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.DesParameters::DES_weak_keys
	ByteU5BU5D_t3397334013* ___DES_weak_keys_3;

public:
	inline static int32_t get_offset_of_DES_weak_keys_3() { return static_cast<int32_t>(offsetof(DesParameters_t4026919406_StaticFields, ___DES_weak_keys_3)); }
	inline ByteU5BU5D_t3397334013* get_DES_weak_keys_3() const { return ___DES_weak_keys_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_DES_weak_keys_3() { return &___DES_weak_keys_3; }
	inline void set_DES_weak_keys_3(ByteU5BU5D_t3397334013* value)
	{
		___DES_weak_keys_3 = value;
		Il2CppCodeGenWriteBarrier(&___DES_weak_keys_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
