#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher
struct CbcBlockCipher_t424533760;
// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV
struct ParametersWithIV_t2760900877;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine
struct  Rfc3211WrapEngine_t810080994  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine::engine
	CbcBlockCipher_t424533760 * ___engine_0;
	// Org.BouncyCastle.Crypto.Parameters.ParametersWithIV Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine::param
	ParametersWithIV_t2760900877 * ___param_1;
	// System.Boolean Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine::forWrapping
	bool ___forWrapping_2;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Engines.Rfc3211WrapEngine::rand
	SecureRandom_t3117234712 * ___rand_3;

public:
	inline static int32_t get_offset_of_engine_0() { return static_cast<int32_t>(offsetof(Rfc3211WrapEngine_t810080994, ___engine_0)); }
	inline CbcBlockCipher_t424533760 * get_engine_0() const { return ___engine_0; }
	inline CbcBlockCipher_t424533760 ** get_address_of_engine_0() { return &___engine_0; }
	inline void set_engine_0(CbcBlockCipher_t424533760 * value)
	{
		___engine_0 = value;
		Il2CppCodeGenWriteBarrier(&___engine_0, value);
	}

	inline static int32_t get_offset_of_param_1() { return static_cast<int32_t>(offsetof(Rfc3211WrapEngine_t810080994, ___param_1)); }
	inline ParametersWithIV_t2760900877 * get_param_1() const { return ___param_1; }
	inline ParametersWithIV_t2760900877 ** get_address_of_param_1() { return &___param_1; }
	inline void set_param_1(ParametersWithIV_t2760900877 * value)
	{
		___param_1 = value;
		Il2CppCodeGenWriteBarrier(&___param_1, value);
	}

	inline static int32_t get_offset_of_forWrapping_2() { return static_cast<int32_t>(offsetof(Rfc3211WrapEngine_t810080994, ___forWrapping_2)); }
	inline bool get_forWrapping_2() const { return ___forWrapping_2; }
	inline bool* get_address_of_forWrapping_2() { return &___forWrapping_2; }
	inline void set_forWrapping_2(bool value)
	{
		___forWrapping_2 = value;
	}

	inline static int32_t get_offset_of_rand_3() { return static_cast<int32_t>(offsetof(Rfc3211WrapEngine_t810080994, ___rand_3)); }
	inline SecureRandom_t3117234712 * get_rand_3() const { return ___rand_3; }
	inline SecureRandom_t3117234712 ** get_address_of_rand_3() { return &___rand_3; }
	inline void set_rand_3(SecureRandom_t3117234712 * value)
	{
		___rand_3 = value;
		Il2CppCodeGenWriteBarrier(&___rand_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
