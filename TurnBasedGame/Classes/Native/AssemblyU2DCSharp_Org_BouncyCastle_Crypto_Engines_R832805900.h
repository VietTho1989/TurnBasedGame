#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Engines.RsaCoreEngine
struct RsaCoreEngine_t359658953;
// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct RsaKeyParameters_t3425534311;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.RsaBlindedEngine
struct  RsaBlindedEngine_t832805900  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Engines.RsaCoreEngine Org.BouncyCastle.Crypto.Engines.RsaBlindedEngine::core
	RsaCoreEngine_t359658953 * ___core_0;
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters Org.BouncyCastle.Crypto.Engines.RsaBlindedEngine::key
	RsaKeyParameters_t3425534311 * ___key_1;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Engines.RsaBlindedEngine::random
	SecureRandom_t3117234712 * ___random_2;

public:
	inline static int32_t get_offset_of_core_0() { return static_cast<int32_t>(offsetof(RsaBlindedEngine_t832805900, ___core_0)); }
	inline RsaCoreEngine_t359658953 * get_core_0() const { return ___core_0; }
	inline RsaCoreEngine_t359658953 ** get_address_of_core_0() { return &___core_0; }
	inline void set_core_0(RsaCoreEngine_t359658953 * value)
	{
		___core_0 = value;
		Il2CppCodeGenWriteBarrier(&___core_0, value);
	}

	inline static int32_t get_offset_of_key_1() { return static_cast<int32_t>(offsetof(RsaBlindedEngine_t832805900, ___key_1)); }
	inline RsaKeyParameters_t3425534311 * get_key_1() const { return ___key_1; }
	inline RsaKeyParameters_t3425534311 ** get_address_of_key_1() { return &___key_1; }
	inline void set_key_1(RsaKeyParameters_t3425534311 * value)
	{
		___key_1 = value;
		Il2CppCodeGenWriteBarrier(&___key_1, value);
	}

	inline static int32_t get_offset_of_random_2() { return static_cast<int32_t>(offsetof(RsaBlindedEngine_t832805900, ___random_2)); }
	inline SecureRandom_t3117234712 * get_random_2() const { return ___random_2; }
	inline SecureRandom_t3117234712 ** get_address_of_random_2() { return &___random_2; }
	inline void set_random_2(SecureRandom_t3117234712 * value)
	{
		___random_2 = value;
		Il2CppCodeGenWriteBarrier(&___random_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
