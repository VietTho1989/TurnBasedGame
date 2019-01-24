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

// Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher
struct  MacCFBBlockCipher_t3850993954  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher::cfbV
	ByteU5BU5D_t3397334013* ___cfbV_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher::cfbOutV
	ByteU5BU5D_t3397334013* ___cfbOutV_2;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher::blockSize
	int32_t ___blockSize_3;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher::cipher
	Il2CppObject * ___cipher_4;

public:
	inline static int32_t get_offset_of_IV_0() { return static_cast<int32_t>(offsetof(MacCFBBlockCipher_t3850993954, ___IV_0)); }
	inline ByteU5BU5D_t3397334013* get_IV_0() const { return ___IV_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_0() { return &___IV_0; }
	inline void set_IV_0(ByteU5BU5D_t3397334013* value)
	{
		___IV_0 = value;
		Il2CppCodeGenWriteBarrier(&___IV_0, value);
	}

	inline static int32_t get_offset_of_cfbV_1() { return static_cast<int32_t>(offsetof(MacCFBBlockCipher_t3850993954, ___cfbV_1)); }
	inline ByteU5BU5D_t3397334013* get_cfbV_1() const { return ___cfbV_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_cfbV_1() { return &___cfbV_1; }
	inline void set_cfbV_1(ByteU5BU5D_t3397334013* value)
	{
		___cfbV_1 = value;
		Il2CppCodeGenWriteBarrier(&___cfbV_1, value);
	}

	inline static int32_t get_offset_of_cfbOutV_2() { return static_cast<int32_t>(offsetof(MacCFBBlockCipher_t3850993954, ___cfbOutV_2)); }
	inline ByteU5BU5D_t3397334013* get_cfbOutV_2() const { return ___cfbOutV_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_cfbOutV_2() { return &___cfbOutV_2; }
	inline void set_cfbOutV_2(ByteU5BU5D_t3397334013* value)
	{
		___cfbOutV_2 = value;
		Il2CppCodeGenWriteBarrier(&___cfbOutV_2, value);
	}

	inline static int32_t get_offset_of_blockSize_3() { return static_cast<int32_t>(offsetof(MacCFBBlockCipher_t3850993954, ___blockSize_3)); }
	inline int32_t get_blockSize_3() const { return ___blockSize_3; }
	inline int32_t* get_address_of_blockSize_3() { return &___blockSize_3; }
	inline void set_blockSize_3(int32_t value)
	{
		___blockSize_3 = value;
	}

	inline static int32_t get_offset_of_cipher_4() { return static_cast<int32_t>(offsetof(MacCFBBlockCipher_t3850993954, ___cipher_4)); }
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
