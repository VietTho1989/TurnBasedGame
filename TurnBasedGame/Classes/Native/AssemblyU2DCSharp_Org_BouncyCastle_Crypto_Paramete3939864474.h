#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECCurve
struct ECCurve_t140895757;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Math.EC.ECPoint
struct ECPoint_t626351532;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ECDomainParameters
struct  ECDomainParameters_t3939864474  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECCurve Org.BouncyCastle.Crypto.Parameters.ECDomainParameters::curve
	ECCurve_t140895757 * ___curve_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Parameters.ECDomainParameters::seed
	ByteU5BU5D_t3397334013* ___seed_1;
	// Org.BouncyCastle.Math.EC.ECPoint Org.BouncyCastle.Crypto.Parameters.ECDomainParameters::g
	ECPoint_t626351532 * ___g_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ECDomainParameters::n
	BigInteger_t4268922522 * ___n_3;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ECDomainParameters::h
	BigInteger_t4268922522 * ___h_4;

public:
	inline static int32_t get_offset_of_curve_0() { return static_cast<int32_t>(offsetof(ECDomainParameters_t3939864474, ___curve_0)); }
	inline ECCurve_t140895757 * get_curve_0() const { return ___curve_0; }
	inline ECCurve_t140895757 ** get_address_of_curve_0() { return &___curve_0; }
	inline void set_curve_0(ECCurve_t140895757 * value)
	{
		___curve_0 = value;
		Il2CppCodeGenWriteBarrier(&___curve_0, value);
	}

	inline static int32_t get_offset_of_seed_1() { return static_cast<int32_t>(offsetof(ECDomainParameters_t3939864474, ___seed_1)); }
	inline ByteU5BU5D_t3397334013* get_seed_1() const { return ___seed_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_seed_1() { return &___seed_1; }
	inline void set_seed_1(ByteU5BU5D_t3397334013* value)
	{
		___seed_1 = value;
		Il2CppCodeGenWriteBarrier(&___seed_1, value);
	}

	inline static int32_t get_offset_of_g_2() { return static_cast<int32_t>(offsetof(ECDomainParameters_t3939864474, ___g_2)); }
	inline ECPoint_t626351532 * get_g_2() const { return ___g_2; }
	inline ECPoint_t626351532 ** get_address_of_g_2() { return &___g_2; }
	inline void set_g_2(ECPoint_t626351532 * value)
	{
		___g_2 = value;
		Il2CppCodeGenWriteBarrier(&___g_2, value);
	}

	inline static int32_t get_offset_of_n_3() { return static_cast<int32_t>(offsetof(ECDomainParameters_t3939864474, ___n_3)); }
	inline BigInteger_t4268922522 * get_n_3() const { return ___n_3; }
	inline BigInteger_t4268922522 ** get_address_of_n_3() { return &___n_3; }
	inline void set_n_3(BigInteger_t4268922522 * value)
	{
		___n_3 = value;
		Il2CppCodeGenWriteBarrier(&___n_3, value);
	}

	inline static int32_t get_offset_of_h_4() { return static_cast<int32_t>(offsetof(ECDomainParameters_t3939864474, ___h_4)); }
	inline BigInteger_t4268922522 * get_h_4() const { return ___h_4; }
	inline BigInteger_t4268922522 ** get_address_of_h_4() { return &___h_4; }
	inline void set_h_4(BigInteger_t4268922522 * value)
	{
		___h_4 = value;
		Il2CppCodeGenWriteBarrier(&___h_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
