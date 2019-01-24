#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// System.String[]
struct StringU5BU5D_t1642385972;
// System.String
struct String_t;
// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters
struct ECDomainParameters_t3939864474;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ECKeyParameters
struct  ECKeyParameters_t1064568751  : public AsymmetricKeyParameter_t1663727050
{
public:
	// System.String Org.BouncyCastle.Crypto.Parameters.ECKeyParameters::algorithm
	String_t* ___algorithm_2;
	// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters Org.BouncyCastle.Crypto.Parameters.ECKeyParameters::parameters
	ECDomainParameters_t3939864474 * ___parameters_3;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Crypto.Parameters.ECKeyParameters::publicKeyParamSet
	DerObjectIdentifier_t3495876513 * ___publicKeyParamSet_4;

public:
	inline static int32_t get_offset_of_algorithm_2() { return static_cast<int32_t>(offsetof(ECKeyParameters_t1064568751, ___algorithm_2)); }
	inline String_t* get_algorithm_2() const { return ___algorithm_2; }
	inline String_t** get_address_of_algorithm_2() { return &___algorithm_2; }
	inline void set_algorithm_2(String_t* value)
	{
		___algorithm_2 = value;
		Il2CppCodeGenWriteBarrier(&___algorithm_2, value);
	}

	inline static int32_t get_offset_of_parameters_3() { return static_cast<int32_t>(offsetof(ECKeyParameters_t1064568751, ___parameters_3)); }
	inline ECDomainParameters_t3939864474 * get_parameters_3() const { return ___parameters_3; }
	inline ECDomainParameters_t3939864474 ** get_address_of_parameters_3() { return &___parameters_3; }
	inline void set_parameters_3(ECDomainParameters_t3939864474 * value)
	{
		___parameters_3 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_3, value);
	}

	inline static int32_t get_offset_of_publicKeyParamSet_4() { return static_cast<int32_t>(offsetof(ECKeyParameters_t1064568751, ___publicKeyParamSet_4)); }
	inline DerObjectIdentifier_t3495876513 * get_publicKeyParamSet_4() const { return ___publicKeyParamSet_4; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_publicKeyParamSet_4() { return &___publicKeyParamSet_4; }
	inline void set_publicKeyParamSet_4(DerObjectIdentifier_t3495876513 * value)
	{
		___publicKeyParamSet_4 = value;
		Il2CppCodeGenWriteBarrier(&___publicKeyParamSet_4, value);
	}
};

struct ECKeyParameters_t1064568751_StaticFields
{
public:
	// System.String[] Org.BouncyCastle.Crypto.Parameters.ECKeyParameters::algorithms
	StringU5BU5D_t1642385972* ___algorithms_1;

public:
	inline static int32_t get_offset_of_algorithms_1() { return static_cast<int32_t>(offsetof(ECKeyParameters_t1064568751_StaticFields, ___algorithms_1)); }
	inline StringU5BU5D_t1642385972* get_algorithms_1() const { return ___algorithms_1; }
	inline StringU5BU5D_t1642385972** get_address_of_algorithms_1() { return &___algorithms_1; }
	inline void set_algorithms_1(StringU5BU5D_t1642385972* value)
	{
		___algorithms_1 = value;
		Il2CppCodeGenWriteBarrier(&___algorithms_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
