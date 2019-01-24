#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Buffered3241650255.h"

// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher
struct  BufferedAsymmetricBlockCipher_t862890205  : public BufferedCipherBase_t3241650255
{
public:
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher::cipher
	Il2CppObject * ___cipher_1;
	// System.Byte[] Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher::buffer
	ByteU5BU5D_t3397334013* ___buffer_2;
	// System.Int32 Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher::bufOff
	int32_t ___bufOff_3;

public:
	inline static int32_t get_offset_of_cipher_1() { return static_cast<int32_t>(offsetof(BufferedAsymmetricBlockCipher_t862890205, ___cipher_1)); }
	inline Il2CppObject * get_cipher_1() const { return ___cipher_1; }
	inline Il2CppObject ** get_address_of_cipher_1() { return &___cipher_1; }
	inline void set_cipher_1(Il2CppObject * value)
	{
		___cipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_1, value);
	}

	inline static int32_t get_offset_of_buffer_2() { return static_cast<int32_t>(offsetof(BufferedAsymmetricBlockCipher_t862890205, ___buffer_2)); }
	inline ByteU5BU5D_t3397334013* get_buffer_2() const { return ___buffer_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_buffer_2() { return &___buffer_2; }
	inline void set_buffer_2(ByteU5BU5D_t3397334013* value)
	{
		___buffer_2 = value;
		Il2CppCodeGenWriteBarrier(&___buffer_2, value);
	}

	inline static int32_t get_offset_of_bufOff_3() { return static_cast<int32_t>(offsetof(BufferedAsymmetricBlockCipher_t862890205, ___bufOff_3)); }
	inline int32_t get_bufOff_3() const { return ___bufOff_3; }
	inline int32_t* get_address_of_bufOff_3() { return &___bufOff_3; }
	inline void set_bufOff_3(int32_t value)
	{
		___bufOff_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
