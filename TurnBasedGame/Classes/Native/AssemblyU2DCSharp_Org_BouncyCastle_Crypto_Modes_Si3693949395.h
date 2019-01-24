#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.SicBlockCipher
struct  SicBlockCipher_t3693949395  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.SicBlockCipher::cipher
	Il2CppObject * ___cipher_0;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.SicBlockCipher::blockSize
	int32_t ___blockSize_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.SicBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.SicBlockCipher::counter
	ByteU5BU5D_t3397334013* ___counter_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.SicBlockCipher::counterOut
	ByteU5BU5D_t3397334013* ___counterOut_4;

public:
	inline static int32_t get_offset_of_cipher_0() { return static_cast<int32_t>(offsetof(SicBlockCipher_t3693949395, ___cipher_0)); }
	inline Il2CppObject * get_cipher_0() const { return ___cipher_0; }
	inline Il2CppObject ** get_address_of_cipher_0() { return &___cipher_0; }
	inline void set_cipher_0(Il2CppObject * value)
	{
		___cipher_0 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_0, value);
	}

	inline static int32_t get_offset_of_blockSize_1() { return static_cast<int32_t>(offsetof(SicBlockCipher_t3693949395, ___blockSize_1)); }
	inline int32_t get_blockSize_1() const { return ___blockSize_1; }
	inline int32_t* get_address_of_blockSize_1() { return &___blockSize_1; }
	inline void set_blockSize_1(int32_t value)
	{
		___blockSize_1 = value;
	}

	inline static int32_t get_offset_of_IV_2() { return static_cast<int32_t>(offsetof(SicBlockCipher_t3693949395, ___IV_2)); }
	inline ByteU5BU5D_t3397334013* get_IV_2() const { return ___IV_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_2() { return &___IV_2; }
	inline void set_IV_2(ByteU5BU5D_t3397334013* value)
	{
		___IV_2 = value;
		Il2CppCodeGenWriteBarrier(&___IV_2, value);
	}

	inline static int32_t get_offset_of_counter_3() { return static_cast<int32_t>(offsetof(SicBlockCipher_t3693949395, ___counter_3)); }
	inline ByteU5BU5D_t3397334013* get_counter_3() const { return ___counter_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_counter_3() { return &___counter_3; }
	inline void set_counter_3(ByteU5BU5D_t3397334013* value)
	{
		___counter_3 = value;
		Il2CppCodeGenWriteBarrier(&___counter_3, value);
	}

	inline static int32_t get_offset_of_counterOut_4() { return static_cast<int32_t>(offsetof(SicBlockCipher_t3693949395, ___counterOut_4)); }
	inline ByteU5BU5D_t3397334013* get_counterOut_4() const { return ___counterOut_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_counterOut_4() { return &___counterOut_4; }
	inline void set_counterOut_4(ByteU5BU5D_t3397334013* value)
	{
		___counterOut_4 = value;
		Il2CppCodeGenWriteBarrier(&___counterOut_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
