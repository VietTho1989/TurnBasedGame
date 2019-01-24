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

// Org.BouncyCastle.Math.EC.Abc.SimpleBigDecimal
struct  SimpleBigDecimal_t2857025313  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.EC.Abc.SimpleBigDecimal::bigInt
	BigInteger_t4268922522 * ___bigInt_0;
	// System.Int32 Org.BouncyCastle.Math.EC.Abc.SimpleBigDecimal::scale
	int32_t ___scale_1;

public:
	inline static int32_t get_offset_of_bigInt_0() { return static_cast<int32_t>(offsetof(SimpleBigDecimal_t2857025313, ___bigInt_0)); }
	inline BigInteger_t4268922522 * get_bigInt_0() const { return ___bigInt_0; }
	inline BigInteger_t4268922522 ** get_address_of_bigInt_0() { return &___bigInt_0; }
	inline void set_bigInt_0(BigInteger_t4268922522 * value)
	{
		___bigInt_0 = value;
		Il2CppCodeGenWriteBarrier(&___bigInt_0, value);
	}

	inline static int32_t get_offset_of_scale_1() { return static_cast<int32_t>(offsetof(SimpleBigDecimal_t2857025313, ___scale_1)); }
	inline int32_t get_scale_1() const { return ___scale_1; }
	inline int32_t* get_address_of_scale_1() { return &___scale_1; }
	inline void set_scale_1(int32_t value)
	{
		___scale_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
