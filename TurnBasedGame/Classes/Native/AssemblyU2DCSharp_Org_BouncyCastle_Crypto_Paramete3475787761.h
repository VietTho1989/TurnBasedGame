#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_KeyGenera650995725.h"

// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters
struct ECDomainParameters_t3939864474;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters
struct  ECKeyGenerationParameters_t3475787761  : public KeyGenerationParameters_t650995725
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters::domainParams
	ECDomainParameters_t3939864474 * ___domainParams_2;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Crypto.Parameters.ECKeyGenerationParameters::publicKeyParamSet
	DerObjectIdentifier_t3495876513 * ___publicKeyParamSet_3;

public:
	inline static int32_t get_offset_of_domainParams_2() { return static_cast<int32_t>(offsetof(ECKeyGenerationParameters_t3475787761, ___domainParams_2)); }
	inline ECDomainParameters_t3939864474 * get_domainParams_2() const { return ___domainParams_2; }
	inline ECDomainParameters_t3939864474 ** get_address_of_domainParams_2() { return &___domainParams_2; }
	inline void set_domainParams_2(ECDomainParameters_t3939864474 * value)
	{
		___domainParams_2 = value;
		Il2CppCodeGenWriteBarrier(&___domainParams_2, value);
	}

	inline static int32_t get_offset_of_publicKeyParamSet_3() { return static_cast<int32_t>(offsetof(ECKeyGenerationParameters_t3475787761, ___publicKeyParamSet_3)); }
	inline DerObjectIdentifier_t3495876513 * get_publicKeyParamSet_3() const { return ___publicKeyParamSet_3; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_publicKeyParamSet_3() { return &___publicKeyParamSet_3; }
	inline void set_publicKeyParamSet_3(DerObjectIdentifier_t3495876513 * value)
	{
		___publicKeyParamSet_3 = value;
		Il2CppCodeGenWriteBarrier(&___publicKeyParamSet_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
