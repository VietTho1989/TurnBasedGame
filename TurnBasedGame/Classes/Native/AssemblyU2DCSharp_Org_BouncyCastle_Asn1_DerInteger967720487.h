#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerInteger
struct  DerInteger_t967720487  : public Asn1Object_t564283626
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.DerInteger::bytes
	ByteU5BU5D_t3397334013* ___bytes_2;

public:
	inline static int32_t get_offset_of_bytes_2() { return static_cast<int32_t>(offsetof(DerInteger_t967720487, ___bytes_2)); }
	inline ByteU5BU5D_t3397334013* get_bytes_2() const { return ___bytes_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_bytes_2() { return &___bytes_2; }
	inline void set_bytes_2(ByteU5BU5D_t3397334013* value)
	{
		___bytes_2 = value;
		Il2CppCodeGenWriteBarrier(&___bytes_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
