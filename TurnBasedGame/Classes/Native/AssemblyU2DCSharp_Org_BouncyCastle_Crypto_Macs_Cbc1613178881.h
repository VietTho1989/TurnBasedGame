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
// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding
struct IBlockCipherPadding_t1136805358;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac
struct  CbcBlockCipherMac_t1613178881  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac::buf
	ByteU5BU5D_t3397334013* ___buf_0;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac::bufOff
	int32_t ___bufOff_1;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac::cipher
	Il2CppObject * ___cipher_2;
	// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac::padding
	Il2CppObject * ___padding_3;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac::macSize
	int32_t ___macSize_4;

public:
	inline static int32_t get_offset_of_buf_0() { return static_cast<int32_t>(offsetof(CbcBlockCipherMac_t1613178881, ___buf_0)); }
	inline ByteU5BU5D_t3397334013* get_buf_0() const { return ___buf_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_0() { return &___buf_0; }
	inline void set_buf_0(ByteU5BU5D_t3397334013* value)
	{
		___buf_0 = value;
		Il2CppCodeGenWriteBarrier(&___buf_0, value);
	}

	inline static int32_t get_offset_of_bufOff_1() { return static_cast<int32_t>(offsetof(CbcBlockCipherMac_t1613178881, ___bufOff_1)); }
	inline int32_t get_bufOff_1() const { return ___bufOff_1; }
	inline int32_t* get_address_of_bufOff_1() { return &___bufOff_1; }
	inline void set_bufOff_1(int32_t value)
	{
		___bufOff_1 = value;
	}

	inline static int32_t get_offset_of_cipher_2() { return static_cast<int32_t>(offsetof(CbcBlockCipherMac_t1613178881, ___cipher_2)); }
	inline Il2CppObject * get_cipher_2() const { return ___cipher_2; }
	inline Il2CppObject ** get_address_of_cipher_2() { return &___cipher_2; }
	inline void set_cipher_2(Il2CppObject * value)
	{
		___cipher_2 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_2, value);
	}

	inline static int32_t get_offset_of_padding_3() { return static_cast<int32_t>(offsetof(CbcBlockCipherMac_t1613178881, ___padding_3)); }
	inline Il2CppObject * get_padding_3() const { return ___padding_3; }
	inline Il2CppObject ** get_address_of_padding_3() { return &___padding_3; }
	inline void set_padding_3(Il2CppObject * value)
	{
		___padding_3 = value;
		Il2CppCodeGenWriteBarrier(&___padding_3, value);
	}

	inline static int32_t get_offset_of_macSize_4() { return static_cast<int32_t>(offsetof(CbcBlockCipherMac_t1613178881, ___macSize_4)); }
	inline int32_t get_macSize_4() const { return ___macSize_4; }
	inline int32_t* get_address_of_macSize_4() { return &___macSize_4; }
	inline void set_macSize_4(int32_t value)
	{
		___macSize_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
