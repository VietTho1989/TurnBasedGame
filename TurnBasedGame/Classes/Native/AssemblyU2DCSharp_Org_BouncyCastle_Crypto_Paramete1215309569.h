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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ElGamalParameters
struct  ElGamalParameters_t1215309569  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ElGamalParameters::p
	BigInteger_t4268922522 * ___p_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Parameters.ElGamalParameters::g
	BigInteger_t4268922522 * ___g_1;
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.ElGamalParameters::l
	int32_t ___l_2;

public:
	inline static int32_t get_offset_of_p_0() { return static_cast<int32_t>(offsetof(ElGamalParameters_t1215309569, ___p_0)); }
	inline BigInteger_t4268922522 * get_p_0() const { return ___p_0; }
	inline BigInteger_t4268922522 ** get_address_of_p_0() { return &___p_0; }
	inline void set_p_0(BigInteger_t4268922522 * value)
	{
		___p_0 = value;
		Il2CppCodeGenWriteBarrier(&___p_0, value);
	}

	inline static int32_t get_offset_of_g_1() { return static_cast<int32_t>(offsetof(ElGamalParameters_t1215309569, ___g_1)); }
	inline BigInteger_t4268922522 * get_g_1() const { return ___g_1; }
	inline BigInteger_t4268922522 ** get_address_of_g_1() { return &___g_1; }
	inline void set_g_1(BigInteger_t4268922522 * value)
	{
		___g_1 = value;
		Il2CppCodeGenWriteBarrier(&___g_1, value);
	}

	inline static int32_t get_offset_of_l_2() { return static_cast<int32_t>(offsetof(ElGamalParameters_t1215309569, ___l_2)); }
	inline int32_t get_l_2() const { return ___l_2; }
	inline int32_t* get_address_of_l_2() { return &___l_2; }
	inline void set_l_2(int32_t value)
	{
		___l_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
