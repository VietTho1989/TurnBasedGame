#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.CryptoPro.Gost3410PublicKeyAlgParameters
struct  Gost3410PublicKeyAlgParameters_t4257955415  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.CryptoPro.Gost3410PublicKeyAlgParameters::publicKeyParamSet
	DerObjectIdentifier_t3495876513 * ___publicKeyParamSet_2;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.CryptoPro.Gost3410PublicKeyAlgParameters::digestParamSet
	DerObjectIdentifier_t3495876513 * ___digestParamSet_3;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.CryptoPro.Gost3410PublicKeyAlgParameters::encryptionParamSet
	DerObjectIdentifier_t3495876513 * ___encryptionParamSet_4;

public:
	inline static int32_t get_offset_of_publicKeyParamSet_2() { return static_cast<int32_t>(offsetof(Gost3410PublicKeyAlgParameters_t4257955415, ___publicKeyParamSet_2)); }
	inline DerObjectIdentifier_t3495876513 * get_publicKeyParamSet_2() const { return ___publicKeyParamSet_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_publicKeyParamSet_2() { return &___publicKeyParamSet_2; }
	inline void set_publicKeyParamSet_2(DerObjectIdentifier_t3495876513 * value)
	{
		___publicKeyParamSet_2 = value;
		Il2CppCodeGenWriteBarrier(&___publicKeyParamSet_2, value);
	}

	inline static int32_t get_offset_of_digestParamSet_3() { return static_cast<int32_t>(offsetof(Gost3410PublicKeyAlgParameters_t4257955415, ___digestParamSet_3)); }
	inline DerObjectIdentifier_t3495876513 * get_digestParamSet_3() const { return ___digestParamSet_3; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_digestParamSet_3() { return &___digestParamSet_3; }
	inline void set_digestParamSet_3(DerObjectIdentifier_t3495876513 * value)
	{
		___digestParamSet_3 = value;
		Il2CppCodeGenWriteBarrier(&___digestParamSet_3, value);
	}

	inline static int32_t get_offset_of_encryptionParamSet_4() { return static_cast<int32_t>(offsetof(Gost3410PublicKeyAlgParameters_t4257955415, ___encryptionParamSet_4)); }
	inline DerObjectIdentifier_t3495876513 * get_encryptionParamSet_4() const { return ___encryptionParamSet_4; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_encryptionParamSet_4() { return &___encryptionParamSet_4; }
	inline void set_encryptionParamSet_4(DerObjectIdentifier_t3495876513 * value)
	{
		___encryptionParamSet_4 = value;
		Il2CppCodeGenWriteBarrier(&___encryptionParamSet_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
