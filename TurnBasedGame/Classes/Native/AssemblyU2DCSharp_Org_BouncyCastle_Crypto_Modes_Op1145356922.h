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

// Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher
struct  OpenPgpCfbBlockCipher_t1145356922  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::FR
	ByteU5BU5D_t3397334013* ___FR_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::FRE
	ByteU5BU5D_t3397334013* ___FRE_2;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::cipher
	Il2CppObject * ___cipher_3;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::blockSize
	int32_t ___blockSize_4;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::count
	int32_t ___count_5;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher::forEncryption
	bool ___forEncryption_6;

public:
	inline static int32_t get_offset_of_IV_0() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___IV_0)); }
	inline ByteU5BU5D_t3397334013* get_IV_0() const { return ___IV_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_0() { return &___IV_0; }
	inline void set_IV_0(ByteU5BU5D_t3397334013* value)
	{
		___IV_0 = value;
		Il2CppCodeGenWriteBarrier(&___IV_0, value);
	}

	inline static int32_t get_offset_of_FR_1() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___FR_1)); }
	inline ByteU5BU5D_t3397334013* get_FR_1() const { return ___FR_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_FR_1() { return &___FR_1; }
	inline void set_FR_1(ByteU5BU5D_t3397334013* value)
	{
		___FR_1 = value;
		Il2CppCodeGenWriteBarrier(&___FR_1, value);
	}

	inline static int32_t get_offset_of_FRE_2() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___FRE_2)); }
	inline ByteU5BU5D_t3397334013* get_FRE_2() const { return ___FRE_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_FRE_2() { return &___FRE_2; }
	inline void set_FRE_2(ByteU5BU5D_t3397334013* value)
	{
		___FRE_2 = value;
		Il2CppCodeGenWriteBarrier(&___FRE_2, value);
	}

	inline static int32_t get_offset_of_cipher_3() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___cipher_3)); }
	inline Il2CppObject * get_cipher_3() const { return ___cipher_3; }
	inline Il2CppObject ** get_address_of_cipher_3() { return &___cipher_3; }
	inline void set_cipher_3(Il2CppObject * value)
	{
		___cipher_3 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_3, value);
	}

	inline static int32_t get_offset_of_blockSize_4() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___blockSize_4)); }
	inline int32_t get_blockSize_4() const { return ___blockSize_4; }
	inline int32_t* get_address_of_blockSize_4() { return &___blockSize_4; }
	inline void set_blockSize_4(int32_t value)
	{
		___blockSize_4 = value;
	}

	inline static int32_t get_offset_of_count_5() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___count_5)); }
	inline int32_t get_count_5() const { return ___count_5; }
	inline int32_t* get_address_of_count_5() { return &___count_5; }
	inline void set_count_5(int32_t value)
	{
		___count_5 = value;
	}

	inline static int32_t get_offset_of_forEncryption_6() { return static_cast<int32_t>(offsetof(OpenPgpCfbBlockCipher_t1145356922, ___forEncryption_6)); }
	inline bool get_forEncryption_6() const { return ___forEncryption_6; }
	inline bool* get_address_of_forEncryption_6() { return &___forEncryption_6; }
	inline void set_forEncryption_6(bool value)
	{
		___forEncryption_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
