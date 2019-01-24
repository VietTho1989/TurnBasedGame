#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerBitString
struct DerBitString_t2717907355;
// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.DHValidationParms
struct  DHValidationParms_t4010119324  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X9.DHValidationParms::seed
	DerBitString_t2717907355 * ___seed_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHValidationParms::pgenCounter
	DerInteger_t967720487 * ___pgenCounter_3;

public:
	inline static int32_t get_offset_of_seed_2() { return static_cast<int32_t>(offsetof(DHValidationParms_t4010119324, ___seed_2)); }
	inline DerBitString_t2717907355 * get_seed_2() const { return ___seed_2; }
	inline DerBitString_t2717907355 ** get_address_of_seed_2() { return &___seed_2; }
	inline void set_seed_2(DerBitString_t2717907355 * value)
	{
		___seed_2 = value;
		Il2CppCodeGenWriteBarrier(&___seed_2, value);
	}

	inline static int32_t get_offset_of_pgenCounter_3() { return static_cast<int32_t>(offsetof(DHValidationParms_t4010119324, ___pgenCounter_3)); }
	inline DerInteger_t967720487 * get_pgenCounter_3() const { return ___pgenCounter_3; }
	inline DerInteger_t967720487 ** get_address_of_pgenCounter_3() { return &___pgenCounter_3; }
	inline void set_pgenCounter_3(DerInteger_t967720487 * value)
	{
		___pgenCounter_3 = value;
		Il2CppCodeGenWriteBarrier(&___pgenCounter_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
