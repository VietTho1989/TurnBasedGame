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
// Org.BouncyCastle.Crypto.Parameters.DHValidationParameters
struct DHValidationParameters_t2841123689;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DHParameters
struct  DHParameters_t431035336  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.DHParameters::p
	BigInteger_t4268922522 * ___p_1;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.DHParameters::g
	BigInteger_t4268922522 * ___g_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.DHParameters::q
	BigInteger_t4268922522 * ___q_3;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.DHParameters::j
	BigInteger_t4268922522 * ___j_4;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.DHParameters::m
	int32_t ___m_5;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.DHParameters::l
	int32_t ___l_6;
	// Org.BouncyCastle.Crypto.Parameters.DHValidationParameters Org.BouncyCastle.Crypto.Parameters.DHParameters::validation
	DHValidationParameters_t2841123689 * ___validation_7;

public:
	inline static int32_t get_offset_of_p_1() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___p_1)); }
	inline BigInteger_t4268922522 * get_p_1() const { return ___p_1; }
	inline BigInteger_t4268922522 ** get_address_of_p_1() { return &___p_1; }
	inline void set_p_1(BigInteger_t4268922522 * value)
	{
		___p_1 = value;
		Il2CppCodeGenWriteBarrier(&___p_1, value);
	}

	inline static int32_t get_offset_of_g_2() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___g_2)); }
	inline BigInteger_t4268922522 * get_g_2() const { return ___g_2; }
	inline BigInteger_t4268922522 ** get_address_of_g_2() { return &___g_2; }
	inline void set_g_2(BigInteger_t4268922522 * value)
	{
		___g_2 = value;
		Il2CppCodeGenWriteBarrier(&___g_2, value);
	}

	inline static int32_t get_offset_of_q_3() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___q_3)); }
	inline BigInteger_t4268922522 * get_q_3() const { return ___q_3; }
	inline BigInteger_t4268922522 ** get_address_of_q_3() { return &___q_3; }
	inline void set_q_3(BigInteger_t4268922522 * value)
	{
		___q_3 = value;
		Il2CppCodeGenWriteBarrier(&___q_3, value);
	}

	inline static int32_t get_offset_of_j_4() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___j_4)); }
	inline BigInteger_t4268922522 * get_j_4() const { return ___j_4; }
	inline BigInteger_t4268922522 ** get_address_of_j_4() { return &___j_4; }
	inline void set_j_4(BigInteger_t4268922522 * value)
	{
		___j_4 = value;
		Il2CppCodeGenWriteBarrier(&___j_4, value);
	}

	inline static int32_t get_offset_of_m_5() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___m_5)); }
	inline int32_t get_m_5() const { return ___m_5; }
	inline int32_t* get_address_of_m_5() { return &___m_5; }
	inline void set_m_5(int32_t value)
	{
		___m_5 = value;
	}

	inline static int32_t get_offset_of_l_6() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___l_6)); }
	inline int32_t get_l_6() const { return ___l_6; }
	inline int32_t* get_address_of_l_6() { return &___l_6; }
	inline void set_l_6(int32_t value)
	{
		___l_6 = value;
	}

	inline static int32_t get_offset_of_validation_7() { return static_cast<int32_t>(offsetof(DHParameters_t431035336, ___validation_7)); }
	inline DHValidationParameters_t2841123689 * get_validation_7() const { return ___validation_7; }
	inline DHValidationParameters_t2841123689 ** get_address_of_validation_7() { return &___validation_7; }
	inline void set_validation_7(DHValidationParameters_t2841123689 * value)
	{
		___validation_7 = value;
		Il2CppCodeGenWriteBarrier(&___validation_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
