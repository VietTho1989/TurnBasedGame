#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.RsaPublicKeyStructure
struct  RsaPublicKeyStructure_t197361851  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Asn1.X509.RsaPublicKeyStructure::modulus
	BigInteger_t4268922522 * ___modulus_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Asn1.X509.RsaPublicKeyStructure::publicExponent
	BigInteger_t4268922522 * ___publicExponent_3;

public:
	inline static int32_t get_offset_of_modulus_2() { return static_cast<int32_t>(offsetof(RsaPublicKeyStructure_t197361851, ___modulus_2)); }
	inline BigInteger_t4268922522 * get_modulus_2() const { return ___modulus_2; }
	inline BigInteger_t4268922522 ** get_address_of_modulus_2() { return &___modulus_2; }
	inline void set_modulus_2(BigInteger_t4268922522 * value)
	{
		___modulus_2 = value;
		Il2CppCodeGenWriteBarrier(&___modulus_2, value);
	}

	inline static int32_t get_offset_of_publicExponent_3() { return static_cast<int32_t>(offsetof(RsaPublicKeyStructure_t197361851, ___publicExponent_3)); }
	inline BigInteger_t4268922522 * get_publicExponent_3() const { return ___publicExponent_3; }
	inline BigInteger_t4268922522 ** get_address_of_publicExponent_3() { return &___publicExponent_3; }
	inline void set_publicExponent_3(BigInteger_t4268922522 * value)
	{
		___publicExponent_3 = value;
		Il2CppCodeGenWriteBarrier(&___publicExponent_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
