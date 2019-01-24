#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// Org.BouncyCastle.Crypto.Parameters.DHParameters
struct DHParameters_t431035336;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DHKeyParameters
struct  DHKeyParameters_t508500971  : public AsymmetricKeyParameter_t1663727050
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DHParameters Org.BouncyCastle.Crypto.Parameters.DHKeyParameters::parameters
	DHParameters_t431035336 * ___parameters_1;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Crypto.Parameters.DHKeyParameters::algorithmOid
	DerObjectIdentifier_t3495876513 * ___algorithmOid_2;

public:
	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(DHKeyParameters_t508500971, ___parameters_1)); }
	inline DHParameters_t431035336 * get_parameters_1() const { return ___parameters_1; }
	inline DHParameters_t431035336 ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(DHParameters_t431035336 * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}

	inline static int32_t get_offset_of_algorithmOid_2() { return static_cast<int32_t>(offsetof(DHKeyParameters_t508500971, ___algorithmOid_2)); }
	inline DerObjectIdentifier_t3495876513 * get_algorithmOid_2() const { return ___algorithmOid_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_algorithmOid_2() { return &___algorithmOid_2; }
	inline void set_algorithmOid_2(DerObjectIdentifier_t3495876513 * value)
	{
		___algorithmOid_2 = value;
		Il2CppCodeGenWriteBarrier(&___algorithmOid_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
