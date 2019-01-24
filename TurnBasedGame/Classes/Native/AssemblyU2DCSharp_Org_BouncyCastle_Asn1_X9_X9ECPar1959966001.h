#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X9.X9FieldID
struct X9FieldID_t2012644846;
// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// Org.BouncyCastle.Math.EC.ECPoint
struct ECPoint_t626351532;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.X9ECParameters
struct  X9ECParameters_t1959966001  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X9.X9FieldID Org.BouncyCastle.Asn1.X9.X9ECParameters::fieldID
	X9FieldID_t2012644846 * ___fieldID_2;
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Asn1.X9.X9ECParameters::curve
	ECCurve_t140895757 * ___curve_3;
	// Org.BouncyCastle.Math.EC.ECPoint Org.BouncyCastle.Asn1.X9.X9ECParameters::g
	ECPoint_t626351532 * ___g_4;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Asn1.X9.X9ECParameters::n
	BigInteger_t4268922522 * ___n_5;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Asn1.X9.X9ECParameters::h
	BigInteger_t4268922522 * ___h_6;
	// System.Byte[] Org.BouncyCastle.Asn1.X9.X9ECParameters::seed
	ByteU5BU5D_t3397334013* ___seed_7;

public:
	inline static int32_t get_offset_of_fieldID_2() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___fieldID_2)); }
	inline X9FieldID_t2012644846 * get_fieldID_2() const { return ___fieldID_2; }
	inline X9FieldID_t2012644846 ** get_address_of_fieldID_2() { return &___fieldID_2; }
	inline void set_fieldID_2(X9FieldID_t2012644846 * value)
	{
		___fieldID_2 = value;
		Il2CppCodeGenWriteBarrier(&___fieldID_2, value);
	}

	inline static int32_t get_offset_of_curve_3() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___curve_3)); }
	inline ECCurve_t140895757 * get_curve_3() const { return ___curve_3; }
	inline ECCurve_t140895757 ** get_address_of_curve_3() { return &___curve_3; }
	inline void set_curve_3(ECCurve_t140895757 * value)
	{
		___curve_3 = value;
		Il2CppCodeGenWriteBarrier(&___curve_3, value);
	}

	inline static int32_t get_offset_of_g_4() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___g_4)); }
	inline ECPoint_t626351532 * get_g_4() const { return ___g_4; }
	inline ECPoint_t626351532 ** get_address_of_g_4() { return &___g_4; }
	inline void set_g_4(ECPoint_t626351532 * value)
	{
		___g_4 = value;
		Il2CppCodeGenWriteBarrier(&___g_4, value);
	}

	inline static int32_t get_offset_of_n_5() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___n_5)); }
	inline BigInteger_t4268922522 * get_n_5() const { return ___n_5; }
	inline BigInteger_t4268922522 ** get_address_of_n_5() { return &___n_5; }
	inline void set_n_5(BigInteger_t4268922522 * value)
	{
		___n_5 = value;
		Il2CppCodeGenWriteBarrier(&___n_5, value);
	}

	inline static int32_t get_offset_of_h_6() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___h_6)); }
	inline BigInteger_t4268922522 * get_h_6() const { return ___h_6; }
	inline BigInteger_t4268922522 ** get_address_of_h_6() { return &___h_6; }
	inline void set_h_6(BigInteger_t4268922522 * value)
	{
		___h_6 = value;
		Il2CppCodeGenWriteBarrier(&___h_6, value);
	}

	inline static int32_t get_offset_of_seed_7() { return static_cast<int32_t>(offsetof(X9ECParameters_t1959966001, ___seed_7)); }
	inline ByteU5BU5D_t3397334013* get_seed_7() const { return ___seed_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_7() { return &___seed_7; }
	inline void set_seed_7(ByteU5BU5D_t3397334013* value)
	{
		___seed_7 = value;
		Il2CppCodeGenWriteBarrier(&___seed_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
