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

// Org.BouncyCastle.Crypto.Modes.CbcBlockCipher
struct  CbcBlockCipher_t424533760  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::cbcV
	ByteU5BU5D_t3397334013* ___cbcV_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::cbcNextV
	ByteU5BU5D_t3397334013* ___cbcNextV_2;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::blockSize
	int32_t ___blockSize_3;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::cipher
	Il2CppObject * ___cipher_4;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.CbcBlockCipher::encrypting
	bool ___encrypting_5;

public:
	inline static int32_t get_offset_of_IV_0() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___IV_0)); }
	inline ByteU5BU5D_t3397334013* get_IV_0() const { return ___IV_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_0() { return &___IV_0; }
	inline void set_IV_0(ByteU5BU5D_t3397334013* value)
	{
		___IV_0 = value;
		Il2CppCodeGenWriteBarrier(&___IV_0, value);
	}

	inline static int32_t get_offset_of_cbcV_1() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___cbcV_1)); }
	inline ByteU5BU5D_t3397334013* get_cbcV_1() const { return ___cbcV_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_cbcV_1() { return &___cbcV_1; }
	inline void set_cbcV_1(ByteU5BU5D_t3397334013* value)
	{
		___cbcV_1 = value;
		Il2CppCodeGenWriteBarrier(&___cbcV_1, value);
	}

	inline static int32_t get_offset_of_cbcNextV_2() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___cbcNextV_2)); }
	inline ByteU5BU5D_t3397334013* get_cbcNextV_2() const { return ___cbcNextV_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_cbcNextV_2() { return &___cbcNextV_2; }
	inline void set_cbcNextV_2(ByteU5BU5D_t3397334013* value)
	{
		___cbcNextV_2 = value;
		Il2CppCodeGenWriteBarrier(&___cbcNextV_2, value);
	}

	inline static int32_t get_offset_of_blockSize_3() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___blockSize_3)); }
	inline int32_t get_blockSize_3() const { return ___blockSize_3; }
	inline int32_t* get_address_of_blockSize_3() { return &___blockSize_3; }
	inline void set_blockSize_3(int32_t value)
	{
		___blockSize_3 = value;
	}

	inline static int32_t get_offset_of_cipher_4() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___cipher_4)); }
	inline Il2CppObject * get_cipher_4() const { return ___cipher_4; }
	inline Il2CppObject ** get_address_of_cipher_4() { return &___cipher_4; }
	inline void set_cipher_4(Il2CppObject * value)
	{
		___cipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_4, value);
	}

	inline static int32_t get_offset_of_encrypting_5() { return static_cast<int32_t>(offsetof(CbcBlockCipher_t424533760, ___encrypting_5)); }
	inline bool get_encrypting_5() const { return ___encrypting_5; }
	inline bool* get_address_of_encrypting_5() { return &___encrypting_5; }
	inline void set_encrypting_5(bool value)
	{
		___encrypting_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
