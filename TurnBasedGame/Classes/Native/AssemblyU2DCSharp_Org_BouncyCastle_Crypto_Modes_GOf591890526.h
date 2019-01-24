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

// Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher
struct  GOfbBlockCipher_t591890526  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::IV
	ByteU5BU5D_t3397334013* ___IV_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::ofbV
	ByteU5BU5D_t3397334013* ___ofbV_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::ofbOutV
	ByteU5BU5D_t3397334013* ___ofbOutV_2;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::blockSize
	int32_t ___blockSize_3;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::cipher
	Il2CppObject * ___cipher_4;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::firstStep
	bool ___firstStep_5;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::N3
	int32_t ___N3_6;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher::N4
	int32_t ___N4_7;

public:
	inline static int32_t get_offset_of_IV_0() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___IV_0)); }
	inline ByteU5BU5D_t3397334013* get_IV_0() const { return ___IV_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_IV_0() { return &___IV_0; }
	inline void set_IV_0(ByteU5BU5D_t3397334013* value)
	{
		___IV_0 = value;
		Il2CppCodeGenWriteBarrier(&___IV_0, value);
	}

	inline static int32_t get_offset_of_ofbV_1() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___ofbV_1)); }
	inline ByteU5BU5D_t3397334013* get_ofbV_1() const { return ___ofbV_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_ofbV_1() { return &___ofbV_1; }
	inline void set_ofbV_1(ByteU5BU5D_t3397334013* value)
	{
		___ofbV_1 = value;
		Il2CppCodeGenWriteBarrier(&___ofbV_1, value);
	}

	inline static int32_t get_offset_of_ofbOutV_2() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___ofbOutV_2)); }
	inline ByteU5BU5D_t3397334013* get_ofbOutV_2() const { return ___ofbOutV_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_ofbOutV_2() { return &___ofbOutV_2; }
	inline void set_ofbOutV_2(ByteU5BU5D_t3397334013* value)
	{
		___ofbOutV_2 = value;
		Il2CppCodeGenWriteBarrier(&___ofbOutV_2, value);
	}

	inline static int32_t get_offset_of_blockSize_3() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___blockSize_3)); }
	inline int32_t get_blockSize_3() const { return ___blockSize_3; }
	inline int32_t* get_address_of_blockSize_3() { return &___blockSize_3; }
	inline void set_blockSize_3(int32_t value)
	{
		___blockSize_3 = value;
	}

	inline static int32_t get_offset_of_cipher_4() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___cipher_4)); }
	inline Il2CppObject * get_cipher_4() const { return ___cipher_4; }
	inline Il2CppObject ** get_address_of_cipher_4() { return &___cipher_4; }
	inline void set_cipher_4(Il2CppObject * value)
	{
		___cipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_4, value);
	}

	inline static int32_t get_offset_of_firstStep_5() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___firstStep_5)); }
	inline bool get_firstStep_5() const { return ___firstStep_5; }
	inline bool* get_address_of_firstStep_5() { return &___firstStep_5; }
	inline void set_firstStep_5(bool value)
	{
		___firstStep_5 = value;
	}

	inline static int32_t get_offset_of_N3_6() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___N3_6)); }
	inline int32_t get_N3_6() const { return ___N3_6; }
	inline int32_t* get_address_of_N3_6() { return &___N3_6; }
	inline void set_N3_6(int32_t value)
	{
		___N3_6 = value;
	}

	inline static int32_t get_offset_of_N4_7() { return static_cast<int32_t>(offsetof(GOfbBlockCipher_t591890526, ___N4_7)); }
	inline int32_t get_N4_7() const { return ___N4_7; }
	inline int32_t* get_address_of_N4_7() { return &___N4_7; }
	inline void set_N4_7(int32_t value)
	{
		___N4_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
