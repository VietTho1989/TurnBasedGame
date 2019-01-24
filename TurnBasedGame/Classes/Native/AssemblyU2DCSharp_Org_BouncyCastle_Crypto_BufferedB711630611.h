#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Buffered3241650255.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.BufferedBlockCipher
struct  BufferedBlockCipher_t711630611  : public BufferedCipherBase_t3241650255
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.BufferedBlockCipher::buf
	ByteU5BU5D_t3397334013* ___buf_1;
	// System.Int32 Org.BouncyCastle.Crypto.BufferedBlockCipher::bufOff
	int32_t ___bufOff_2;
	// System.Boolean Org.BouncyCastle.Crypto.BufferedBlockCipher::forEncryption
	bool ___forEncryption_3;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.BufferedBlockCipher::cipher
	Il2CppObject * ___cipher_4;

public:
	inline static int32_t get_offset_of_buf_1() { return static_cast<int32_t>(offsetof(BufferedBlockCipher_t711630611, ___buf_1)); }
	inline ByteU5BU5D_t3397334013* get_buf_1() const { return ___buf_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_1() { return &___buf_1; }
	inline void set_buf_1(ByteU5BU5D_t3397334013* value)
	{
		___buf_1 = value;
		Il2CppCodeGenWriteBarrier(&___buf_1, value);
	}

	inline static int32_t get_offset_of_bufOff_2() { return static_cast<int32_t>(offsetof(BufferedBlockCipher_t711630611, ___bufOff_2)); }
	inline int32_t get_bufOff_2() const { return ___bufOff_2; }
	inline int32_t* get_address_of_bufOff_2() { return &___bufOff_2; }
	inline void set_bufOff_2(int32_t value)
	{
		___bufOff_2 = value;
	}

	inline static int32_t get_offset_of_forEncryption_3() { return static_cast<int32_t>(offsetof(BufferedBlockCipher_t711630611, ___forEncryption_3)); }
	inline bool get_forEncryption_3() const { return ___forEncryption_3; }
	inline bool* get_address_of_forEncryption_3() { return &___forEncryption_3; }
	inline void set_forEncryption_3(bool value)
	{
		___forEncryption_3 = value;
	}

	inline static int32_t get_offset_of_cipher_4() { return static_cast<int32_t>(offsetof(BufferedBlockCipher_t711630611, ___cipher_4)); }
	inline Il2CppObject * get_cipher_4() const { return ___cipher_4; }
	inline Il2CppObject ** get_address_of_cipher_4() { return &___cipher_4; }
	inline void set_cipher_4(Il2CppObject * value)
	{
		___cipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
