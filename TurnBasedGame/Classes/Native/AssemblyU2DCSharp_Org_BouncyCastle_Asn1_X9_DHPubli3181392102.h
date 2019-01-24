#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.DHPublicKey
struct  DHPublicKey_t3181392102  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHPublicKey::y
	DerInteger_t967720487 * ___y_2;

public:
	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(DHPublicKey_t3181392102, ___y_2)); }
	inline DerInteger_t967720487 * get_y_2() const { return ___y_2; }
	inline DerInteger_t967720487 ** get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(DerInteger_t967720487 * value)
	{
		___y_2 = value;
		Il2CppCodeGenWriteBarrier(&___y_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
