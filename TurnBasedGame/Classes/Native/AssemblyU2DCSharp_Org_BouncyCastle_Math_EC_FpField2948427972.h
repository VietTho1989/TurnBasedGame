#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_ECField1092946118.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.FpFieldElement
struct  FpFieldElement_t2948427972  : public ECFieldElement_t1092946118
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.FpFieldElement::q
	BigInteger_t4268922522 * ___q_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.FpFieldElement::r
	BigInteger_t4268922522 * ___r_1;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.FpFieldElement::x
	BigInteger_t4268922522 * ___x_2;

public:
	inline static int32_t get_offset_of_q_0() { return static_cast<int32_t>(offsetof(FpFieldElement_t2948427972, ___q_0)); }
	inline BigInteger_t4268922522 * get_q_0() const { return ___q_0; }
	inline BigInteger_t4268922522 ** get_address_of_q_0() { return &___q_0; }
	inline void set_q_0(BigInteger_t4268922522 * value)
	{
		___q_0 = value;
		Il2CppCodeGenWriteBarrier(&___q_0, value);
	}

	inline static int32_t get_offset_of_r_1() { return static_cast<int32_t>(offsetof(FpFieldElement_t2948427972, ___r_1)); }
	inline BigInteger_t4268922522 * get_r_1() const { return ___r_1; }
	inline BigInteger_t4268922522 ** get_address_of_r_1() { return &___r_1; }
	inline void set_r_1(BigInteger_t4268922522 * value)
	{
		___r_1 = value;
		Il2CppCodeGenWriteBarrier(&___r_1, value);
	}

	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(FpFieldElement_t2948427972, ___x_2)); }
	inline BigInteger_t4268922522 * get_x_2() const { return ___x_2; }
	inline BigInteger_t4268922522 ** get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(BigInteger_t4268922522 * value)
	{
		___x_2 = value;
		Il2CppCodeGenWriteBarrier(&___x_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
