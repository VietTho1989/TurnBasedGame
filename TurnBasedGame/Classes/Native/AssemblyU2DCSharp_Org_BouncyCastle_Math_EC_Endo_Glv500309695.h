#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Math.BigInteger[]
struct BigIntegerU5BU5D_t431507903;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters
struct  GlvTypeBParameters_t500309695  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_beta
	BigInteger_t4268922522 * ___m_beta_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_lambda
	BigInteger_t4268922522 * ___m_lambda_1;
	// Org.BouncyCastle.Math.BigInteger[] Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_v1
	BigIntegerU5BU5D_t431507903* ___m_v1_2;
	// Org.BouncyCastle.Math.BigInteger[] Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_v2
	BigIntegerU5BU5D_t431507903* ___m_v2_3;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_g1
	BigInteger_t4268922522 * ___m_g1_4;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_g2
	BigInteger_t4268922522 * ___m_g2_5;
	// System.Int32 Org.BouncyCastle.Math.EC.Endo.GlvTypeBParameters::m_bits
	int32_t ___m_bits_6;

public:
	inline static int32_t get_offset_of_m_beta_0() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_beta_0)); }
	inline BigInteger_t4268922522 * get_m_beta_0() const { return ___m_beta_0; }
	inline BigInteger_t4268922522 ** get_address_of_m_beta_0() { return &___m_beta_0; }
	inline void set_m_beta_0(BigInteger_t4268922522 * value)
	{
		___m_beta_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_beta_0, value);
	}

	inline static int32_t get_offset_of_m_lambda_1() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_lambda_1)); }
	inline BigInteger_t4268922522 * get_m_lambda_1() const { return ___m_lambda_1; }
	inline BigInteger_t4268922522 ** get_address_of_m_lambda_1() { return &___m_lambda_1; }
	inline void set_m_lambda_1(BigInteger_t4268922522 * value)
	{
		___m_lambda_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_lambda_1, value);
	}

	inline static int32_t get_offset_of_m_v1_2() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_v1_2)); }
	inline BigIntegerU5BU5D_t431507903* get_m_v1_2() const { return ___m_v1_2; }
	inline BigIntegerU5BU5D_t431507903** get_address_of_m_v1_2() { return &___m_v1_2; }
	inline void set_m_v1_2(BigIntegerU5BU5D_t431507903* value)
	{
		___m_v1_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_v1_2, value);
	}

	inline static int32_t get_offset_of_m_v2_3() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_v2_3)); }
	inline BigIntegerU5BU5D_t431507903* get_m_v2_3() const { return ___m_v2_3; }
	inline BigIntegerU5BU5D_t431507903** get_address_of_m_v2_3() { return &___m_v2_3; }
	inline void set_m_v2_3(BigIntegerU5BU5D_t431507903* value)
	{
		___m_v2_3 = value;
		Il2CppCodeGenWriteBarrier(&___m_v2_3, value);
	}

	inline static int32_t get_offset_of_m_g1_4() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_g1_4)); }
	inline BigInteger_t4268922522 * get_m_g1_4() const { return ___m_g1_4; }
	inline BigInteger_t4268922522 ** get_address_of_m_g1_4() { return &___m_g1_4; }
	inline void set_m_g1_4(BigInteger_t4268922522 * value)
	{
		___m_g1_4 = value;
		Il2CppCodeGenWriteBarrier(&___m_g1_4, value);
	}

	inline static int32_t get_offset_of_m_g2_5() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_g2_5)); }
	inline BigInteger_t4268922522 * get_m_g2_5() const { return ___m_g2_5; }
	inline BigInteger_t4268922522 ** get_address_of_m_g2_5() { return &___m_g2_5; }
	inline void set_m_g2_5(BigInteger_t4268922522 * value)
	{
		___m_g2_5 = value;
		Il2CppCodeGenWriteBarrier(&___m_g2_5, value);
	}

	inline static int32_t get_offset_of_m_bits_6() { return static_cast<int32_t>(offsetof(GlvTypeBParameters_t500309695, ___m_bits_6)); }
	inline int32_t get_m_bits_6() const { return ___m_bits_6; }
	inline int32_t* get_address_of_m_bits_6() { return &___m_bits_6; }
	inline void set_m_bits_6(int32_t value)
	{
		___m_bits_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
