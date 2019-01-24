#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters
struct Gost3410Parameters_t602285121;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.Gost3410KeyParameters
struct  Gost3410KeyParameters_t1164823134  : public AsymmetricKeyParameter_t1663727050
{
public:
	// Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters Org.BouncyCastle.Crypto.Parameters.Gost3410KeyParameters::parameters
	Gost3410Parameters_t602285121 * ___parameters_1;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Crypto.Parameters.Gost3410KeyParameters::publicKeyParamSet
	DerObjectIdentifier_t3495876513 * ___publicKeyParamSet_2;

public:
	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(Gost3410KeyParameters_t1164823134, ___parameters_1)); }
	inline Gost3410Parameters_t602285121 * get_parameters_1() const { return ___parameters_1; }
	inline Gost3410Parameters_t602285121 ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(Gost3410Parameters_t602285121 * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}

	inline static int32_t get_offset_of_publicKeyParamSet_2() { return static_cast<int32_t>(offsetof(Gost3410KeyParameters_t1164823134, ___publicKeyParamSet_2)); }
	inline DerObjectIdentifier_t3495876513 * get_publicKeyParamSet_2() const { return ___publicKeyParamSet_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_publicKeyParamSet_2() { return &___publicKeyParamSet_2; }
	inline void set_publicKeyParamSet_2(DerObjectIdentifier_t3495876513 * value)
	{
		___publicKeyParamSet_2 = value;
		Il2CppCodeGenWriteBarrier(&___publicKeyParamSet_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
