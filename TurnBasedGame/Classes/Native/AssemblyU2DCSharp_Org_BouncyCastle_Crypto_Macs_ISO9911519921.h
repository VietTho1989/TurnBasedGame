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
// Org.BouncyCastle.Crypto.Parameters.KeyParameter
struct KeyParameter_t215653120;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac
struct  ISO9797Alg3Mac_t911519921  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::mac
	ByteU5BU5D_t3397334013* ___mac_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::buf
	ByteU5BU5D_t3397334013* ___buf_1;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::bufOff
	int32_t ___bufOff_2;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::cipher
	Il2CppObject * ___cipher_3;
	// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::padding
	Il2CppObject * ___padding_4;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::macSize
	int32_t ___macSize_5;
	// Org.BouncyCastle.Crypto.Parameters.KeyParameter Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::lastKey2
	KeyParameter_t215653120 * ___lastKey2_6;
	// Org.BouncyCastle.Crypto.Parameters.KeyParameter Org.BouncyCastle.Crypto.Macs.ISO9797Alg3Mac::lastKey3
	KeyParameter_t215653120 * ___lastKey3_7;

public:
	inline static int32_t get_offset_of_mac_0() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___mac_0)); }
	inline ByteU5BU5D_t3397334013* get_mac_0() const { return ___mac_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_mac_0() { return &___mac_0; }
	inline void set_mac_0(ByteU5BU5D_t3397334013* value)
	{
		___mac_0 = value;
		Il2CppCodeGenWriteBarrier(&___mac_0, value);
	}

	inline static int32_t get_offset_of_buf_1() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___buf_1)); }
	inline ByteU5BU5D_t3397334013* get_buf_1() const { return ___buf_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_1() { return &___buf_1; }
	inline void set_buf_1(ByteU5BU5D_t3397334013* value)
	{
		___buf_1 = value;
		Il2CppCodeGenWriteBarrier(&___buf_1, value);
	}

	inline static int32_t get_offset_of_bufOff_2() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___bufOff_2)); }
	inline int32_t get_bufOff_2() const { return ___bufOff_2; }
	inline int32_t* get_address_of_bufOff_2() { return &___bufOff_2; }
	inline void set_bufOff_2(int32_t value)
	{
		___bufOff_2 = value;
	}

	inline static int32_t get_offset_of_cipher_3() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___cipher_3)); }
	inline Il2CppObject * get_cipher_3() const { return ___cipher_3; }
	inline Il2CppObject ** get_address_of_cipher_3() { return &___cipher_3; }
	inline void set_cipher_3(Il2CppObject * value)
	{
		___cipher_3 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_3, value);
	}

	inline static int32_t get_offset_of_padding_4() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___padding_4)); }
	inline Il2CppObject * get_padding_4() const { return ___padding_4; }
	inline Il2CppObject ** get_address_of_padding_4() { return &___padding_4; }
	inline void set_padding_4(Il2CppObject * value)
	{
		___padding_4 = value;
		Il2CppCodeGenWriteBarrier(&___padding_4, value);
	}

	inline static int32_t get_offset_of_macSize_5() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___macSize_5)); }
	inline int32_t get_macSize_5() const { return ___macSize_5; }
	inline int32_t* get_address_of_macSize_5() { return &___macSize_5; }
	inline void set_macSize_5(int32_t value)
	{
		___macSize_5 = value;
	}

	inline static int32_t get_offset_of_lastKey2_6() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___lastKey2_6)); }
	inline KeyParameter_t215653120 * get_lastKey2_6() const { return ___lastKey2_6; }
	inline KeyParameter_t215653120 ** get_address_of_lastKey2_6() { return &___lastKey2_6; }
	inline void set_lastKey2_6(KeyParameter_t215653120 * value)
	{
		___lastKey2_6 = value;
		Il2CppCodeGenWriteBarrier(&___lastKey2_6, value);
	}

	inline static int32_t get_offset_of_lastKey3_7() { return static_cast<int32_t>(offsetof(ISO9797Alg3Mac_t911519921, ___lastKey3_7)); }
	inline KeyParameter_t215653120 * get_lastKey3_7() const { return ___lastKey3_7; }
	inline KeyParameter_t215653120 ** get_address_of_lastKey3_7() { return &___lastKey3_7; }
	inline void set_lastKey3_7(KeyParameter_t215653120 * value)
	{
		___lastKey3_7 = value;
		Il2CppCodeGenWriteBarrier(&___lastKey3_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
