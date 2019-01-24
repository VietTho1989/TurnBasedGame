#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyParameters
struct ElGamalKeyParameters_t352675504;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.ElGamalEngine
struct  ElGamalEngine_t291645553  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyParameters Org.BouncyCastle.Crypto.Engines.ElGamalEngine::key
	ElGamalKeyParameters_t352675504 * ___key_0;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Engines.ElGamalEngine::random
	SecureRandom_t3117234712 * ___random_1;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.ElGamalEngine::forEncryption
	bool ___forEncryption_2;
	// System.Int32 Org.BouncyCastle.Crypto.Engines.ElGamalEngine::bitSize
	int32_t ___bitSize_3;

public:
	inline static int32_t get_offset_of_key_0() { return static_cast<int32_t>(offsetof(ElGamalEngine_t291645553, ___key_0)); }
	inline ElGamalKeyParameters_t352675504 * get_key_0() const { return ___key_0; }
	inline ElGamalKeyParameters_t352675504 ** get_address_of_key_0() { return &___key_0; }
	inline void set_key_0(ElGamalKeyParameters_t352675504 * value)
	{
		___key_0 = value;
		Il2CppCodeGenWriteBarrier(&___key_0, value);
	}

	inline static int32_t get_offset_of_random_1() { return static_cast<int32_t>(offsetof(ElGamalEngine_t291645553, ___random_1)); }
	inline SecureRandom_t3117234712 * get_random_1() const { return ___random_1; }
	inline SecureRandom_t3117234712 ** get_address_of_random_1() { return &___random_1; }
	inline void set_random_1(SecureRandom_t3117234712 * value)
	{
		___random_1 = value;
		Il2CppCodeGenWriteBarrier(&___random_1, value);
	}

	inline static int32_t get_offset_of_forEncryption_2() { return static_cast<int32_t>(offsetof(ElGamalEngine_t291645553, ___forEncryption_2)); }
	inline bool get_forEncryption_2() const { return ___forEncryption_2; }
	inline bool* get_address_of_forEncryption_2() { return &___forEncryption_2; }
	inline void set_forEncryption_2(bool value)
	{
		___forEncryption_2 = value;
	}

	inline static int32_t get_offset_of_bitSize_3() { return static_cast<int32_t>(offsetof(ElGamalEngine_t291645553, ___bitSize_3)); }
	inline int32_t get_bitSize_3() const { return ___bitSize_3; }
	inline int32_t* get_address_of_bitSize_3() { return &___bitSize_3; }
	inline void set_bitSize_3(int32_t value)
	{
		___bitSize_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
