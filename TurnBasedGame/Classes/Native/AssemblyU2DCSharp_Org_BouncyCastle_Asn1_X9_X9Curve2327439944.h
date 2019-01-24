#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9Curve
struct  X9Curve_t2327439944  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Asn1.X9.X9Curve::curve
	ECCurve_t140895757 * ___curve_2;
	// System.Byte[] Org.BouncyCastle.Asn1.X9.X9Curve::seed
	ByteU5BU5D_t3397334013* ___seed_3;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X9.X9Curve::fieldIdentifier
	DerObjectIdentifier_t3495876513 * ___fieldIdentifier_4;

public:
	inline static int32_t get_offset_of_curve_2() { return static_cast<int32_t>(offsetof(X9Curve_t2327439944, ___curve_2)); }
	inline ECCurve_t140895757 * get_curve_2() const { return ___curve_2; }
	inline ECCurve_t140895757 ** get_address_of_curve_2() { return &___curve_2; }
	inline void set_curve_2(ECCurve_t140895757 * value)
	{
		___curve_2 = value;
		Il2CppCodeGenWriteBarrier(&___curve_2, value);
	}

	inline static int32_t get_offset_of_seed_3() { return static_cast<int32_t>(offsetof(X9Curve_t2327439944, ___seed_3)); }
	inline ByteU5BU5D_t3397334013* get_seed_3() const { return ___seed_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_3() { return &___seed_3; }
	inline void set_seed_3(ByteU5BU5D_t3397334013* value)
	{
		___seed_3 = value;
		Il2CppCodeGenWriteBarrier(&___seed_3, value);
	}

	inline static int32_t get_offset_of_fieldIdentifier_4() { return static_cast<int32_t>(offsetof(X9Curve_t2327439944, ___fieldIdentifier_4)); }
	inline DerObjectIdentifier_t3495876513 * get_fieldIdentifier_4() const { return ___fieldIdentifier_4; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_fieldIdentifier_4() { return &___fieldIdentifier_4; }
	inline void set_fieldIdentifier_4(DerObjectIdentifier_t3495876513 * value)
	{
		___fieldIdentifier_4 = value;
		Il2CppCodeGenWriteBarrier(&___fieldIdentifier_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
