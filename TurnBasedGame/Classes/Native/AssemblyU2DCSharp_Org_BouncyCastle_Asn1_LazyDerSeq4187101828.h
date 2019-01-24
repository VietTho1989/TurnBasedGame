#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_DerSequenc4250014174.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.LazyDerSequence
struct  LazyDerSequence_t4187101828  : public DerSequence_t4250014174
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.LazyDerSequence::encoded
	ByteU5BU5D_t3397334013* ___encoded_4;

public:
	inline static int32_t get_offset_of_encoded_4() { return static_cast<int32_t>(offsetof(LazyDerSequence_t4187101828, ___encoded_4)); }
	inline ByteU5BU5D_t3397334013* get_encoded_4() const { return ___encoded_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_encoded_4() { return &___encoded_4; }
	inline void set_encoded_4(ByteU5BU5D_t3397334013* value)
	{
		___encoded_4 = value;
		Il2CppCodeGenWriteBarrier(&___encoded_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
