#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters
struct RsaKeyGenerationParameters_t2592312329;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator
struct  RsaKeyPairGenerator_t3263126028  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::parameters
	RsaKeyGenerationParameters_t2592312329 * ___parameters_6;

public:
	inline static int32_t get_offset_of_parameters_6() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028, ___parameters_6)); }
	inline RsaKeyGenerationParameters_t2592312329 * get_parameters_6() const { return ___parameters_6; }
	inline RsaKeyGenerationParameters_t2592312329 ** get_address_of_parameters_6() { return &___parameters_6; }
	inline void set_parameters_6(RsaKeyGenerationParameters_t2592312329 * value)
	{
		___parameters_6 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_6, value);
	}
};

struct RsaKeyPairGenerator_t3263126028_StaticFields
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::SPECIAL_E_VALUES
	Int32U5BU5D_t3030399641* ___SPECIAL_E_VALUES_0;
	// System.Int32 Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::SPECIAL_E_HIGHEST
	int32_t ___SPECIAL_E_HIGHEST_1;
	// System.Int32 Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::SPECIAL_E_BITS
	int32_t ___SPECIAL_E_BITS_2;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::One
	BigInteger_t4268922522 * ___One_3;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator::DefaultPublicExponent
	BigInteger_t4268922522 * ___DefaultPublicExponent_4;

public:
	inline static int32_t get_offset_of_SPECIAL_E_VALUES_0() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028_StaticFields, ___SPECIAL_E_VALUES_0)); }
	inline Int32U5BU5D_t3030399641* get_SPECIAL_E_VALUES_0() const { return ___SPECIAL_E_VALUES_0; }
	inline Int32U5BU5D_t3030399641** get_address_of_SPECIAL_E_VALUES_0() { return &___SPECIAL_E_VALUES_0; }
	inline void set_SPECIAL_E_VALUES_0(Int32U5BU5D_t3030399641* value)
	{
		___SPECIAL_E_VALUES_0 = value;
		Il2CppCodeGenWriteBarrier(&___SPECIAL_E_VALUES_0, value);
	}

	inline static int32_t get_offset_of_SPECIAL_E_HIGHEST_1() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028_StaticFields, ___SPECIAL_E_HIGHEST_1)); }
	inline int32_t get_SPECIAL_E_HIGHEST_1() const { return ___SPECIAL_E_HIGHEST_1; }
	inline int32_t* get_address_of_SPECIAL_E_HIGHEST_1() { return &___SPECIAL_E_HIGHEST_1; }
	inline void set_SPECIAL_E_HIGHEST_1(int32_t value)
	{
		___SPECIAL_E_HIGHEST_1 = value;
	}

	inline static int32_t get_offset_of_SPECIAL_E_BITS_2() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028_StaticFields, ___SPECIAL_E_BITS_2)); }
	inline int32_t get_SPECIAL_E_BITS_2() const { return ___SPECIAL_E_BITS_2; }
	inline int32_t* get_address_of_SPECIAL_E_BITS_2() { return &___SPECIAL_E_BITS_2; }
	inline void set_SPECIAL_E_BITS_2(int32_t value)
	{
		___SPECIAL_E_BITS_2 = value;
	}

	inline static int32_t get_offset_of_One_3() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028_StaticFields, ___One_3)); }
	inline BigInteger_t4268922522 * get_One_3() const { return ___One_3; }
	inline BigInteger_t4268922522 ** get_address_of_One_3() { return &___One_3; }
	inline void set_One_3(BigInteger_t4268922522 * value)
	{
		___One_3 = value;
		Il2CppCodeGenWriteBarrier(&___One_3, value);
	}

	inline static int32_t get_offset_of_DefaultPublicExponent_4() { return static_cast<int32_t>(offsetof(RsaKeyPairGenerator_t3263126028_StaticFields, ___DefaultPublicExponent_4)); }
	inline BigInteger_t4268922522 * get_DefaultPublicExponent_4() const { return ___DefaultPublicExponent_4; }
	inline BigInteger_t4268922522 ** get_address_of_DefaultPublicExponent_4() { return &___DefaultPublicExponent_4; }
	inline void set_DefaultPublicExponent_4(BigInteger_t4268922522 * value)
	{
		___DefaultPublicExponent_4 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultPublicExponent_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
