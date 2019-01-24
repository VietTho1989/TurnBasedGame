#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.AsymmetricKeyParameter
struct AsymmetricKeyParameter_t1663727050;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair
struct  AsymmetricCipherKeyPair_t1825508216  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.AsymmetricKeyParameter Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair::publicParameter
	AsymmetricKeyParameter_t1663727050 * ___publicParameter_0;
	// Org.BouncyCastle.Crypto.AsymmetricKeyParameter Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair::privateParameter
	AsymmetricKeyParameter_t1663727050 * ___privateParameter_1;

public:
	inline static int32_t get_offset_of_publicParameter_0() { return static_cast<int32_t>(offsetof(AsymmetricCipherKeyPair_t1825508216, ___publicParameter_0)); }
	inline AsymmetricKeyParameter_t1663727050 * get_publicParameter_0() const { return ___publicParameter_0; }
	inline AsymmetricKeyParameter_t1663727050 ** get_address_of_publicParameter_0() { return &___publicParameter_0; }
	inline void set_publicParameter_0(AsymmetricKeyParameter_t1663727050 * value)
	{
		___publicParameter_0 = value;
		Il2CppCodeGenWriteBarrier(&___publicParameter_0, value);
	}

	inline static int32_t get_offset_of_privateParameter_1() { return static_cast<int32_t>(offsetof(AsymmetricCipherKeyPair_t1825508216, ___privateParameter_1)); }
	inline AsymmetricKeyParameter_t1663727050 * get_privateParameter_1() const { return ___privateParameter_1; }
	inline AsymmetricKeyParameter_t1663727050 ** get_address_of_privateParameter_1() { return &___privateParameter_1; }
	inline void set_privateParameter_1(AsymmetricKeyParameter_t1663727050 * value)
	{
		___privateParameter_1 = value;
		Il2CppCodeGenWriteBarrier(&___privateParameter_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
