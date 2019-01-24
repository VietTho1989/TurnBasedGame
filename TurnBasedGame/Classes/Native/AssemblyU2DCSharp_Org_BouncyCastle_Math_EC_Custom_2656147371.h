#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac2530650717.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Point
struct SecP192R1Point_t969689792;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Curve
struct  SecP192R1Curve_t2656147371  : public AbstractFpCurve_t2530650717
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Point Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Curve::m_infinity
	SecP192R1Point_t969689792 * ___m_infinity_18;

public:
	inline static int32_t get_offset_of_m_infinity_18() { return static_cast<int32_t>(offsetof(SecP192R1Curve_t2656147371, ___m_infinity_18)); }
	inline SecP192R1Point_t969689792 * get_m_infinity_18() const { return ___m_infinity_18; }
	inline SecP192R1Point_t969689792 ** get_address_of_m_infinity_18() { return &___m_infinity_18; }
	inline void set_m_infinity_18(SecP192R1Point_t969689792 * value)
	{
		___m_infinity_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_18, value);
	}
};

struct SecP192R1Curve_t2656147371_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Curve::q
	BigInteger_t4268922522 * ___q_16;

public:
	inline static int32_t get_offset_of_q_16() { return static_cast<int32_t>(offsetof(SecP192R1Curve_t2656147371_StaticFields, ___q_16)); }
	inline BigInteger_t4268922522 * get_q_16() const { return ___q_16; }
	inline BigInteger_t4268922522 ** get_address_of_q_16() { return &___q_16; }
	inline void set_q_16(BigInteger_t4268922522 * value)
	{
		___q_16 = value;
		Il2CppCodeGenWriteBarrier(&___q_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
