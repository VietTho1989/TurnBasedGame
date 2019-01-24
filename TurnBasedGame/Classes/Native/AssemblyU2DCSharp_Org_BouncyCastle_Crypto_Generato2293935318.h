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
// System.Int32[][]
struct Int32U5BU5DU5BU5D_t3750818532;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// Org.BouncyCastle.Math.BigInteger[]
struct BigIntegerU5BU5D_t431507903;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Generators.DHParametersHelper
struct  DHParametersHelper_t2293935318  : public Il2CppObject
{
public:

public:
};

struct DHParametersHelper_t2293935318_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Generators.DHParametersHelper::Six
	BigInteger_t4268922522 * ___Six_0;
	// System.Int32[][] Org.BouncyCastle.Crypto.Generators.DHParametersHelper::primeLists
	Int32U5BU5DU5BU5D_t3750818532* ___primeLists_1;
	// System.Int32[] Org.BouncyCastle.Crypto.Generators.DHParametersHelper::primeProducts
	Int32U5BU5D_t3030399641* ___primeProducts_2;
	// Org.BouncyCastle.Math.BigInteger[] Org.BouncyCastle.Crypto.Generators.DHParametersHelper::BigPrimeProducts
	BigIntegerU5BU5D_t431507903* ___BigPrimeProducts_3;

public:
	inline static int32_t get_offset_of_Six_0() { return static_cast<int32_t>(offsetof(DHParametersHelper_t2293935318_StaticFields, ___Six_0)); }
	inline BigInteger_t4268922522 * get_Six_0() const { return ___Six_0; }
	inline BigInteger_t4268922522 ** get_address_of_Six_0() { return &___Six_0; }
	inline void set_Six_0(BigInteger_t4268922522 * value)
	{
		___Six_0 = value;
		Il2CppCodeGenWriteBarrier(&___Six_0, value);
	}

	inline static int32_t get_offset_of_primeLists_1() { return static_cast<int32_t>(offsetof(DHParametersHelper_t2293935318_StaticFields, ___primeLists_1)); }
	inline Int32U5BU5DU5BU5D_t3750818532* get_primeLists_1() const { return ___primeLists_1; }
	inline Int32U5BU5DU5BU5D_t3750818532** get_address_of_primeLists_1() { return &___primeLists_1; }
	inline void set_primeLists_1(Int32U5BU5DU5BU5D_t3750818532* value)
	{
		___primeLists_1 = value;
		Il2CppCodeGenWriteBarrier(&___primeLists_1, value);
	}

	inline static int32_t get_offset_of_primeProducts_2() { return static_cast<int32_t>(offsetof(DHParametersHelper_t2293935318_StaticFields, ___primeProducts_2)); }
	inline Int32U5BU5D_t3030399641* get_primeProducts_2() const { return ___primeProducts_2; }
	inline Int32U5BU5D_t3030399641** get_address_of_primeProducts_2() { return &___primeProducts_2; }
	inline void set_primeProducts_2(Int32U5BU5D_t3030399641* value)
	{
		___primeProducts_2 = value;
		Il2CppCodeGenWriteBarrier(&___primeProducts_2, value);
	}

	inline static int32_t get_offset_of_BigPrimeProducts_3() { return static_cast<int32_t>(offsetof(DHParametersHelper_t2293935318_StaticFields, ___BigPrimeProducts_3)); }
	inline BigIntegerU5BU5D_t431507903* get_BigPrimeProducts_3() const { return ___BigPrimeProducts_3; }
	inline BigIntegerU5BU5D_t431507903** get_address_of_BigPrimeProducts_3() { return &___BigPrimeProducts_3; }
	inline void set_BigPrimeProducts_3(BigIntegerU5BU5D_t431507903* value)
	{
		___BigPrimeProducts_3 = value;
		Il2CppCodeGenWriteBarrier(&___BigPrimeProducts_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
