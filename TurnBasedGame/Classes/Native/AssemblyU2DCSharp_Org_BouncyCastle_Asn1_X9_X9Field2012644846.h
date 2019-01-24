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
// Org.BouncyCastle.Asn1.Asn1Object
struct Asn1Object_t564283626;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9FieldID
struct  X9FieldID_t2012644846  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X9.X9FieldID::id
	DerObjectIdentifier_t3495876513 * ___id_2;
	// Org.BouncyCastle.Asn1.Asn1Object Org.BouncyCastle.Asn1.X9.X9FieldID::parameters
	Asn1Object_t564283626 * ___parameters_3;

public:
	inline static int32_t get_offset_of_id_2() { return static_cast<int32_t>(offsetof(X9FieldID_t2012644846, ___id_2)); }
	inline DerObjectIdentifier_t3495876513 * get_id_2() const { return ___id_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_id_2() { return &___id_2; }
	inline void set_id_2(DerObjectIdentifier_t3495876513 * value)
	{
		___id_2 = value;
		Il2CppCodeGenWriteBarrier(&___id_2, value);
	}

	inline static int32_t get_offset_of_parameters_3() { return static_cast<int32_t>(offsetof(X9FieldID_t2012644846, ___parameters_3)); }
	inline Asn1Object_t564283626 * get_parameters_3() const { return ___parameters_3; }
	inline Asn1Object_t564283626 ** get_address_of_parameters_3() { return &___parameters_3; }
	inline void set_parameters_3(Asn1Object_t564283626 * value)
	{
		___parameters_3 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
