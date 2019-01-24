#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Buffered3241650255.h"

// Org.BouncyCastle.Crypto.IStreamCipher
struct IStreamCipher_t1073853310;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.BufferedStreamCipher
struct  BufferedStreamCipher_t702588694  : public BufferedCipherBase_t3241650255
{
public:
	// Org.BouncyCastle.Crypto.IStreamCipher Org.BouncyCastle.Crypto.BufferedStreamCipher::cipher
	Il2CppObject * ___cipher_1;

public:
	inline static int32_t get_offset_of_cipher_1() { return static_cast<int32_t>(offsetof(BufferedStreamCipher_t702588694, ___cipher_1)); }
	inline Il2CppObject * get_cipher_1() const { return ___cipher_1; }
	inline Il2CppObject ** get_address_of_cipher_1() { return &___cipher_1; }
	inline void set_cipher_1(Il2CppObject * value)
	{
		___cipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
