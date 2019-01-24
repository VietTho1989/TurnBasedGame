#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.CfbBlockCipher
struct  CfbBlockCipher_t1093564787  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::cfbV
	ByteU5BU5D_t3397334013* ___cfbV_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::cfbOutV
	ByteU5BU5D_t3397334013* ___cfbOutV_2;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::encrypting
	bool ___encrypting_3;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::blockSize
	int32_t ___blockSize_4;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.CfbBlockCipher::cipher
	Il2CppObject * ___cipher_5;

public:
	inline static int32_t get_offset_of_IV_0() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___IV_0)); }
	inline ByteU5BU5D_t3397334013* get_IV_0() const { return ___IV_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_0() { return &___IV_0; }
	inline void set_IV_0(ByteU5BU5D_t3397334013* value)
	{
		___IV_0 = value;
		Il2CppCodeGenWriteBarrier(&___IV_0, value);
	}

	inline static int32_t get_offset_of_cfbV_1() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___cfbV_1)); }
	inline ByteU5BU5D_t3397334013* get_cfbV_1() const { return ___cfbV_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_cfbV_1() { return &___cfbV_1; }
	inline void set_cfbV_1(ByteU5BU5D_t3397334013* value)
	{
		___cfbV_1 = value;
		Il2CppCodeGenWriteBarrier(&___cfbV_1, value);
	}

	inline static int32_t get_offset_of_cfbOutV_2() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___cfbOutV_2)); }
	inline ByteU5BU5D_t3397334013* get_cfbOutV_2() const { return ___cfbOutV_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_cfbOutV_2() { return &___cfbOutV_2; }
	inline void set_cfbOutV_2(ByteU5BU5D_t3397334013* value)
	{
		___cfbOutV_2 = value;
		Il2CppCodeGenWriteBarrier(&___cfbOutV_2, value);
	}

	inline static int32_t get_offset_of_encrypting_3() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___encrypting_3)); }
	inline bool get_encrypting_3() const { return ___encrypting_3; }
	inline bool* get_address_of_encrypting_3() { return &___encrypting_3; }
	inline void set_encrypting_3(bool value)
	{
		___encrypting_3 = value;
	}

	inline static int32_t get_offset_of_blockSize_4() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___blockSize_4)); }
	inline int32_t get_blockSize_4() const { return ___blockSize_4; }
	inline int32_t* get_address_of_blockSize_4() { return &___blockSize_4; }
	inline void set_blockSize_4(int32_t value)
	{
		___blockSize_4 = value;
	}

	inline static int32_t get_offset_of_cipher_5() { return static_cast<int32_t>(offsetof(CfbBlockCipher_t1093564787, ___cipher_5)); }
	inline Il2CppObject * get_cipher_5() const { return ___cipher_5; }
	inline Il2CppObject ** get_address_of_cipher_5() { return &___cipher_5; }
	inline void set_cipher_5(Il2CppObject * value)
	{
		___cipher_5 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
