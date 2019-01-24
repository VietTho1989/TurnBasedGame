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

// Org.BouncyCastle.Math.Field.PrimeField
struct  PrimeField_t623492065  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.Field.PrimeField::characteristic
	BigInteger_t4268922522 * ___characteristic_0;

public:
	inline static int32_t get_offset_of_characteristic_0() { return static_cast<int32_t>(offsetof(PrimeField_t623492065, ___characteristic_0)); }
	inline BigInteger_t4268922522 * get_characteristic_0() const { return ___characteristic_0; }
	inline BigInteger_t4268922522 ** get_address_of_characteristic_0() { return &___characteristic_0; }
	inline void set_characteristic_0(BigInteger_t4268922522 * value)
	{
		___characteristic_0 = value;
		Il2CppCodeGenWriteBarrier(&___characteristic_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
