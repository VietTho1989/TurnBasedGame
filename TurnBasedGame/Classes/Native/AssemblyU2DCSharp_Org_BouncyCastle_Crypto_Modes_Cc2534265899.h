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
// Org.BouncyCastle.Crypto.ICipherParameters
struct ICipherParameters_t3082042576;
// System.IO.MemoryStream
struct MemoryStream_t743994179;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.CcmBlockCipher
struct  CcmBlockCipher_t2534265899  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::cipher
	Il2CppObject * ___cipher_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::macBlock
	ByteU5BU5D_t3397334013* ___macBlock_2;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::forEncryption
	bool ___forEncryption_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::nonce
	ByteU5BU5D_t3397334013* ___nonce_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::initialAssociatedText
	ByteU5BU5D_t3397334013* ___initialAssociatedText_5;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::macSize
	int32_t ___macSize_6;
	// Org.BouncyCastle.Crypto.ICipherParameters Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::keyParam
	Il2CppObject * ___keyParam_7;
	// System.IO.MemoryStream Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::associatedText
	MemoryStream_t743994179 * ___associatedText_8;
	// System.IO.MemoryStream Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::data
	MemoryStream_t743994179 * ___data_9;

public:
	inline static int32_t get_offset_of_cipher_1() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___cipher_1)); }
	inline Il2CppObject * get_cipher_1() const { return ___cipher_1; }
	inline Il2CppObject ** get_address_of_cipher_1() { return &___cipher_1; }
	inline void set_cipher_1(Il2CppObject * value)
	{
		___cipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_1, value);
	}

	inline static int32_t get_offset_of_macBlock_2() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___macBlock_2)); }
	inline ByteU5BU5D_t3397334013* get_macBlock_2() const { return ___macBlock_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_macBlock_2() { return &___macBlock_2; }
	inline void set_macBlock_2(ByteU5BU5D_t3397334013* value)
	{
		___macBlock_2 = value;
		Il2CppCodeGenWriteBarrier(&___macBlock_2, value);
	}

	inline static int32_t get_offset_of_forEncryption_3() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___forEncryption_3)); }
	inline bool get_forEncryption_3() const { return ___forEncryption_3; }
	inline bool* get_address_of_forEncryption_3() { return &___forEncryption_3; }
	inline void set_forEncryption_3(bool value)
	{
		___forEncryption_3 = value;
	}

	inline static int32_t get_offset_of_nonce_4() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___nonce_4)); }
	inline ByteU5BU5D_t3397334013* get_nonce_4() const { return ___nonce_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_nonce_4() { return &___nonce_4; }
	inline void set_nonce_4(ByteU5BU5D_t3397334013* value)
	{
		___nonce_4 = value;
		Il2CppCodeGenWriteBarrier(&___nonce_4, value);
	}

	inline static int32_t get_offset_of_initialAssociatedText_5() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___initialAssociatedText_5)); }
	inline ByteU5BU5D_t3397334013* get_initialAssociatedText_5() const { return ___initialAssociatedText_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_initialAssociatedText_5() { return &___initialAssociatedText_5; }
	inline void set_initialAssociatedText_5(ByteU5BU5D_t3397334013* value)
	{
		___initialAssociatedText_5 = value;
		Il2CppCodeGenWriteBarrier(&___initialAssociatedText_5, value);
	}

	inline static int32_t get_offset_of_macSize_6() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___macSize_6)); }
	inline int32_t get_macSize_6() const { return ___macSize_6; }
	inline int32_t* get_address_of_macSize_6() { return &___macSize_6; }
	inline void set_macSize_6(int32_t value)
	{
		___macSize_6 = value;
	}

	inline static int32_t get_offset_of_keyParam_7() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___keyParam_7)); }
	inline Il2CppObject * get_keyParam_7() const { return ___keyParam_7; }
	inline Il2CppObject ** get_address_of_keyParam_7() { return &___keyParam_7; }
	inline void set_keyParam_7(Il2CppObject * value)
	{
		___keyParam_7 = value;
		Il2CppCodeGenWriteBarrier(&___keyParam_7, value);
	}

	inline static int32_t get_offset_of_associatedText_8() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___associatedText_8)); }
	inline MemoryStream_t743994179 * get_associatedText_8() const { return ___associatedText_8; }
	inline MemoryStream_t743994179 ** get_address_of_associatedText_8() { return &___associatedText_8; }
	inline void set_associatedText_8(MemoryStream_t743994179 * value)
	{
		___associatedText_8 = value;
		Il2CppCodeGenWriteBarrier(&___associatedText_8, value);
	}

	inline static int32_t get_offset_of_data_9() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899, ___data_9)); }
	inline MemoryStream_t743994179 * get_data_9() const { return ___data_9; }
	inline MemoryStream_t743994179 ** get_address_of_data_9() { return &___data_9; }
	inline void set_data_9(MemoryStream_t743994179 * value)
	{
		___data_9 = value;
		Il2CppCodeGenWriteBarrier(&___data_9, value);
	}
};

struct CcmBlockCipher_t2534265899_StaticFields
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Modes.CcmBlockCipher::BlockSize
	int32_t ___BlockSize_0;

public:
	inline static int32_t get_offset_of_BlockSize_0() { return static_cast<int32_t>(offsetof(CcmBlockCipher_t2534265899_StaticFields, ___BlockSize_0)); }
	inline int32_t get_BlockSize_0() const { return ___BlockSize_0; }
	inline int32_t* get_address_of_BlockSize_0() { return &___BlockSize_0; }
	inline void set_BlockSize_0(int32_t value)
	{
		___BlockSize_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
