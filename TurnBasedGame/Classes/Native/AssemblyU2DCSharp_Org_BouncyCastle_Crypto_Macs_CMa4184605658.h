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

// Org.BouncyCastle.Crypto.Macs.CMac
struct  CMac_t4184605658  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::ZEROES
	ByteU5BU5D_t3397334013* ___ZEROES_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::mac
	ByteU5BU5D_t3397334013* ___mac_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::buf
	ByteU5BU5D_t3397334013* ___buf_4;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CMac::bufOff
	int32_t ___bufOff_5;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Macs.CMac::cipher
	Il2CppObject * ___cipher_6;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CMac::macSize
	int32_t ___macSize_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::L
	ByteU5BU5D_t3397334013* ___L_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::Lu
	ByteU5BU5D_t3397334013* ___Lu_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CMac::Lu2
	ByteU5BU5D_t3397334013* ___Lu2_10;

public:
	inline static int32_t get_offset_of_ZEROES_2() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___ZEROES_2)); }
	inline ByteU5BU5D_t3397334013* get_ZEROES_2() const { return ___ZEROES_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_ZEROES_2() { return &___ZEROES_2; }
	inline void set_ZEROES_2(ByteU5BU5D_t3397334013* value)
	{
		___ZEROES_2 = value;
		Il2CppCodeGenWriteBarrier(&___ZEROES_2, value);
	}

	inline static int32_t get_offset_of_mac_3() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___mac_3)); }
	inline ByteU5BU5D_t3397334013* get_mac_3() const { return ___mac_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_mac_3() { return &___mac_3; }
	inline void set_mac_3(ByteU5BU5D_t3397334013* value)
	{
		___mac_3 = value;
		Il2CppCodeGenWriteBarrier(&___mac_3, value);
	}

	inline static int32_t get_offset_of_buf_4() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___buf_4)); }
	inline ByteU5BU5D_t3397334013* get_buf_4() const { return ___buf_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_buf_4() { return &___buf_4; }
	inline void set_buf_4(ByteU5BU5D_t3397334013* value)
	{
		___buf_4 = value;
		Il2CppCodeGenWriteBarrier(&___buf_4, value);
	}

	inline static int32_t get_offset_of_bufOff_5() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___bufOff_5)); }
	inline int32_t get_bufOff_5() const { return ___bufOff_5; }
	inline int32_t* get_address_of_bufOff_5() { return &___bufOff_5; }
	inline void set_bufOff_5(int32_t value)
	{
		___bufOff_5 = value;
	}

	inline static int32_t get_offset_of_cipher_6() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___cipher_6)); }
	inline Il2CppObject * get_cipher_6() const { return ___cipher_6; }
	inline Il2CppObject ** get_address_of_cipher_6() { return &___cipher_6; }
	inline void set_cipher_6(Il2CppObject * value)
	{
		___cipher_6 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_6, value);
	}

	inline static int32_t get_offset_of_macSize_7() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___macSize_7)); }
	inline int32_t get_macSize_7() const { return ___macSize_7; }
	inline int32_t* get_address_of_macSize_7() { return &___macSize_7; }
	inline void set_macSize_7(int32_t value)
	{
		___macSize_7 = value;
	}

	inline static int32_t get_offset_of_L_8() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___L_8)); }
	inline ByteU5BU5D_t3397334013* get_L_8() const { return ___L_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_L_8() { return &___L_8; }
	inline void set_L_8(ByteU5BU5D_t3397334013* value)
	{
		___L_8 = value;
		Il2CppCodeGenWriteBarrier(&___L_8, value);
	}

	inline static int32_t get_offset_of_Lu_9() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___Lu_9)); }
	inline ByteU5BU5D_t3397334013* get_Lu_9() const { return ___Lu_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_Lu_9() { return &___Lu_9; }
	inline void set_Lu_9(ByteU5BU5D_t3397334013* value)
	{
		___Lu_9 = value;
		Il2CppCodeGenWriteBarrier(&___Lu_9, value);
	}

	inline static int32_t get_offset_of_Lu2_10() { return static_cast<int32_t>(offsetof(CMac_t4184605658, ___Lu2_10)); }
	inline ByteU5BU5D_t3397334013* get_Lu2_10() const { return ___Lu2_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_Lu2_10() { return &___Lu2_10; }
	inline void set_Lu2_10(ByteU5BU5D_t3397334013* value)
	{
		___Lu2_10 = value;
		Il2CppCodeGenWriteBarrier(&___Lu2_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
