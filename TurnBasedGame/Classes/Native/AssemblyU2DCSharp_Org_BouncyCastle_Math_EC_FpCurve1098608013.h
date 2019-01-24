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
// Org.BouncyCastle.Math.EC.FpPoint
struct FpPoint_t301080990;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.FpCurve
struct  FpCurve_t1098608013  : public AbstractFpCurve_t2530650717
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.FpCurve::m_q
	BigInteger_t4268922522 * ___m_q_17;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.FpCurve::m_r
	BigInteger_t4268922522 * ___m_r_18;
	// Org.BouncyCastle.Math.EC.FpPoint Org.BouncyCastle.Math.EC.FpCurve::m_infinity
	FpPoint_t301080990 * ___m_infinity_19;

public:
	inline static int32_t get_offset_of_m_q_17() { return static_cast<int32_t>(offsetof(FpCurve_t1098608013, ___m_q_17)); }
	inline BigInteger_t4268922522 * get_m_q_17() const { return ___m_q_17; }
	inline BigInteger_t4268922522 ** get_address_of_m_q_17() { return &___m_q_17; }
	inline void set_m_q_17(BigInteger_t4268922522 * value)
	{
		___m_q_17 = value;
		Il2CppCodeGenWriteBarrier(&___m_q_17, value);
	}

	inline static int32_t get_offset_of_m_r_18() { return static_cast<int32_t>(offsetof(FpCurve_t1098608013, ___m_r_18)); }
	inline BigInteger_t4268922522 * get_m_r_18() const { return ___m_r_18; }
	inline BigInteger_t4268922522 ** get_address_of_m_r_18() { return &___m_r_18; }
	inline void set_m_r_18(BigInteger_t4268922522 * value)
	{
		___m_r_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_r_18, value);
	}

	inline static int32_t get_offset_of_m_infinity_19() { return static_cast<int32_t>(offsetof(FpCurve_t1098608013, ___m_infinity_19)); }
	inline FpPoint_t301080990 * get_m_infinity_19() const { return ___m_infinity_19; }
	inline FpPoint_t301080990 ** get_address_of_m_infinity_19() { return &___m_infinity_19; }
	inline void set_m_infinity_19(FpPoint_t301080990 * value)
	{
		___m_infinity_19 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
