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
// Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher
struct MacCFBBlockCipher_t3850993954;
// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding
struct IBlockCipherPadding_t1136805358;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac
struct  CfbBlockCipherMac_t471961930  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::mac
	ByteU5BU5D_t3397334013* ___mac_0;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::Buffer
	ByteU5BU5D_t3397334013* ___Buffer_1;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::bufOff
	int32_t ___bufOff_2;
	// Org.BouncyCastle.Crypto.Macs.MacCFBBlockCipher Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::cipher
	MacCFBBlockCipher_t3850993954 * ___cipher_3;
	// Org.BouncyCastle.Crypto.Paddings.IBlockCipherPadding Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::padding
	Il2CppObject * ___padding_4;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.CfbBlockCipherMac::macSize
	int32_t ___macSize_5;

public:
	inline static int32_t get_offset_of_mac_0() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___mac_0)); }
	inline ByteU5BU5D_t3397334013* get_mac_0() const { return ___mac_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_mac_0() { return &___mac_0; }
	inline void set_mac_0(ByteU5BU5D_t3397334013* value)
	{
		___mac_0 = value;
		Il2CppCodeGenWriteBarrier(&___mac_0, value);
	}

	inline static int32_t get_offset_of_Buffer_1() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___Buffer_1)); }
	inline ByteU5BU5D_t3397334013* get_Buffer_1() const { return ___Buffer_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_Buffer_1() { return &___Buffer_1; }
	inline void set_Buffer_1(ByteU5BU5D_t3397334013* value)
	{
		___Buffer_1 = value;
		Il2CppCodeGenWriteBarrier(&___Buffer_1, value);
	}

	inline static int32_t get_offset_of_bufOff_2() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___bufOff_2)); }
	inline int32_t get_bufOff_2() const { return ___bufOff_2; }
	inline int32_t* get_address_of_bufOff_2() { return &___bufOff_2; }
	inline void set_bufOff_2(int32_t value)
	{
		___bufOff_2 = value;
	}

	inline static int32_t get_offset_of_cipher_3() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___cipher_3)); }
	inline MacCFBBlockCipher_t3850993954 * get_cipher_3() const { return ___cipher_3; }
	inline MacCFBBlockCipher_t3850993954 ** get_address_of_cipher_3() { return &___cipher_3; }
	inline void set_cipher_3(MacCFBBlockCipher_t3850993954 * value)
	{
		___cipher_3 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_3, value);
	}

	inline static int32_t get_offset_of_padding_4() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___padding_4)); }
	inline Il2CppObject * get_padding_4() const { return ___padding_4; }
	inline Il2CppObject ** get_address_of_padding_4() { return &___padding_4; }
	inline void set_padding_4(Il2CppObject * value)
	{
		___padding_4 = value;
		Il2CppCodeGenWriteBarrier(&___padding_4, value);
	}

	inline static int32_t get_offset_of_macSize_5() { return static_cast<int32_t>(offsetof(CfbBlockCipherMac_t471961930, ___macSize_5)); }
	inline int32_t get_macSize_5() const { return ___macSize_5; }
	inline int32_t* get_address_of_macSize_5() { return &___macSize_5; }
	inline void set_macSize_5(int32_t value)
	{
		___macSize_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
