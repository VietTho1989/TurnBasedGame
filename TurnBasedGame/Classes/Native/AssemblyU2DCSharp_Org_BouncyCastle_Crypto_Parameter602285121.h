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
// Org.BouncyCastle.Crypto.Parameters.Gost3410ValidationParameters
struct Gost3410ValidationParameters_t2048269886;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters
struct  Gost3410Parameters_t602285121  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters::p
	BigInteger_t4268922522 * ___p_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters::q
	BigInteger_t4268922522 * ___q_1;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters::a
	BigInteger_t4268922522 * ___a_2;
	// Org.BouncyCastle.Crypto.Parameters.Gost3410ValidationParameters Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters::validation
	Gost3410ValidationParameters_t2048269886 * ___validation_3;

public:
	inline static int32_t get_offset_of_p_0() { return static_cast<int32_t>(offsetof(Gost3410Parameters_t602285121, ___p_0)); }
	inline BigInteger_t4268922522 * get_p_0() const { return ___p_0; }
	inline BigInteger_t4268922522 ** get_address_of_p_0() { return &___p_0; }
	inline void set_p_0(BigInteger_t4268922522 * value)
	{
		___p_0 = value;
		Il2CppCodeGenWriteBarrier(&___p_0, value);
	}

	inline static int32_t get_offset_of_q_1() { return static_cast<int32_t>(offsetof(Gost3410Parameters_t602285121, ___q_1)); }
	inline BigInteger_t4268922522 * get_q_1() const { return ___q_1; }
	inline BigInteger_t4268922522 ** get_address_of_q_1() { return &___q_1; }
	inline void set_q_1(BigInteger_t4268922522 * value)
	{
		___q_1 = value;
		Il2CppCodeGenWriteBarrier(&___q_1, value);
	}

	inline static int32_t get_offset_of_a_2() { return static_cast<int32_t>(offsetof(Gost3410Parameters_t602285121, ___a_2)); }
	inline BigInteger_t4268922522 * get_a_2() const { return ___a_2; }
	inline BigInteger_t4268922522 ** get_address_of_a_2() { return &___a_2; }
	inline void set_a_2(BigInteger_t4268922522 * value)
	{
		___a_2 = value;
		Il2CppCodeGenWriteBarrier(&___a_2, value);
	}

	inline static int32_t get_offset_of_validation_3() { return static_cast<int32_t>(offsetof(Gost3410Parameters_t602285121, ___validation_3)); }
	inline Gost3410ValidationParameters_t2048269886 * get_validation_3() const { return ___validation_3; }
	inline Gost3410ValidationParameters_t2048269886 ** get_address_of_validation_3() { return &___validation_3; }
	inline void set_validation_3(Gost3410ValidationParameters_t2048269886 * value)
	{
		___validation_3 = value;
		Il2CppCodeGenWriteBarrier(&___validation_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
