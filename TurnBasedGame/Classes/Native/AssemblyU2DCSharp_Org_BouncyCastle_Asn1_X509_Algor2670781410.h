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
// Org.BouncyCastle.Asn1.Asn1Encodable
struct Asn1Encodable_t3447851422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct  AlgorithmIdentifier_t2670781410  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier::objectID
	DerObjectIdentifier_t3495876513 * ___objectID_2;
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier::parameters
	Asn1Encodable_t3447851422 * ___parameters_3;
	// System.Boolean Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier::parametersDefined
	bool ___parametersDefined_4;

public:
	inline static int32_t get_offset_of_objectID_2() { return static_cast<int32_t>(offsetof(AlgorithmIdentifier_t2670781410, ___objectID_2)); }
	inline DerObjectIdentifier_t3495876513 * get_objectID_2() const { return ___objectID_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_objectID_2() { return &___objectID_2; }
	inline void set_objectID_2(DerObjectIdentifier_t3495876513 * value)
	{
		___objectID_2 = value;
		Il2CppCodeGenWriteBarrier(&___objectID_2, value);
	}

	inline static int32_t get_offset_of_parameters_3() { return static_cast<int32_t>(offsetof(AlgorithmIdentifier_t2670781410, ___parameters_3)); }
	inline Asn1Encodable_t3447851422 * get_parameters_3() const { return ___parameters_3; }
	inline Asn1Encodable_t3447851422 ** get_address_of_parameters_3() { return &___parameters_3; }
	inline void set_parameters_3(Asn1Encodable_t3447851422 * value)
	{
		___parameters_3 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_3, value);
	}

	inline static int32_t get_offset_of_parametersDefined_4() { return static_cast<int32_t>(offsetof(AlgorithmIdentifier_t2670781410, ___parametersDefined_4)); }
	inline bool get_parametersDefined_4() const { return ___parametersDefined_4; }
	inline bool* get_address_of_parametersDefined_4() { return &___parametersDefined_4; }
	inline void set_parametersDefined_4(bool value)
	{
		___parametersDefined_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
