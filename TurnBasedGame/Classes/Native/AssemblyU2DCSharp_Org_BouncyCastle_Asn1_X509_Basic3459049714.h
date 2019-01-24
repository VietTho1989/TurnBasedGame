#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerBoolean
struct DerBoolean_t857650049;
// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.BasicConstraints
struct  BasicConstraints_t3459049714  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerBoolean Org.BouncyCastle.Asn1.X509.BasicConstraints::cA
	DerBoolean_t857650049 * ___cA_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.BasicConstraints::pathLenConstraint
	DerInteger_t967720487 * ___pathLenConstraint_3;

public:
	inline static int32_t get_offset_of_cA_2() { return static_cast<int32_t>(offsetof(BasicConstraints_t3459049714, ___cA_2)); }
	inline DerBoolean_t857650049 * get_cA_2() const { return ___cA_2; }
	inline DerBoolean_t857650049 ** get_address_of_cA_2() { return &___cA_2; }
	inline void set_cA_2(DerBoolean_t857650049 * value)
	{
		___cA_2 = value;
		Il2CppCodeGenWriteBarrier(&___cA_2, value);
	}

	inline static int32_t get_offset_of_pathLenConstraint_3() { return static_cast<int32_t>(offsetof(BasicConstraints_t3459049714, ___pathLenConstraint_3)); }
	inline DerInteger_t967720487 * get_pathLenConstraint_3() const { return ___pathLenConstraint_3; }
	inline DerInteger_t967720487 ** get_address_of_pathLenConstraint_3() { return &___pathLenConstraint_3; }
	inline void set_pathLenConstraint_3(DerInteger_t967720487 * value)
	{
		___pathLenConstraint_3 = value;
		Il2CppCodeGenWriteBarrier(&___pathLenConstraint_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
