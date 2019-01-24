#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Math.EC.ECFieldElement
struct ECFieldElement_t1092946118;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9FieldElement
struct  X9FieldElement_t706679609  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Math.EC.ECFieldElement Org.BouncyCastle.Asn1.X9.X9FieldElement::f
	ECFieldElement_t1092946118 * ___f_2;

public:
	inline static int32_t get_offset_of_f_2() { return static_cast<int32_t>(offsetof(X9FieldElement_t706679609, ___f_2)); }
	inline ECFieldElement_t1092946118 * get_f_2() const { return ___f_2; }
	inline ECFieldElement_t1092946118 ** get_address_of_f_2() { return &___f_2; }
	inline void set_f_2(ECFieldElement_t1092946118 * value)
	{
		___f_2 = value;
		Il2CppCodeGenWriteBarrier(&___f_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
