#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters
struct ECDomainParameters_t3939864474;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator
struct  ECKeyPairGenerator_t1267912930  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator::algorithm
	String_t* ___algorithm_0;
	// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator::parameters
	ECDomainParameters_t3939864474 * ___parameters_1;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator::publicKeyParamSet
	DerObjectIdentifier_t3495876513 * ___publicKeyParamSet_2;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Generators.ECKeyPairGenerator::random
	SecureRandom_t3117234712 * ___random_3;

public:
	inline static int32_t get_offset_of_algorithm_0() { return static_cast<int32_t>(offsetof(ECKeyPairGenerator_t1267912930, ___algorithm_0)); }
	inline String_t* get_algorithm_0() const { return ___algorithm_0; }
	inline String_t** get_address_of_algorithm_0() { return &___algorithm_0; }
	inline void set_algorithm_0(String_t* value)
	{
		___algorithm_0 = value;
		Il2CppCodeGenWriteBarrier(&___algorithm_0, value);
	}

	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(ECKeyPairGenerator_t1267912930, ___parameters_1)); }
	inline ECDomainParameters_t3939864474 * get_parameters_1() const { return ___parameters_1; }
	inline ECDomainParameters_t3939864474 ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(ECDomainParameters_t3939864474 * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}

	inline static int32_t get_offset_of_publicKeyParamSet_2() { return static_cast<int32_t>(offsetof(ECKeyPairGenerator_t1267912930, ___publicKeyParamSet_2)); }
	inline DerObjectIdentifier_t3495876513 * get_publicKeyParamSet_2() const { return ___publicKeyParamSet_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_publicKeyParamSet_2() { return &___publicKeyParamSet_2; }
	inline void set_publicKeyParamSet_2(DerObjectIdentifier_t3495876513 * value)
	{
		___publicKeyParamSet_2 = value;
		Il2CppCodeGenWriteBarrier(&___publicKeyParamSet_2, value);
	}

	inline static int32_t get_offset_of_random_3() { return static_cast<int32_t>(offsetof(ECKeyPairGenerator_t1267912930, ___random_3)); }
	inline SecureRandom_t3117234712 * get_random_3() const { return ___random_3; }
	inline SecureRandom_t3117234712 ** get_address_of_random_3() { return &___random_3; }
	inline void set_random_3(SecureRandom_t3117234712 * value)
	{
		___random_3 = value;
		Il2CppCodeGenWriteBarrier(&___random_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
