#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Modes.SicBlockCipher
struct SicBlockCipher_t3693949395;
// Org.BouncyCastle.Crypto.IMac
struct IMac_t2321756708;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.EaxBlockCipher
struct  EaxBlockCipher_t1200038734  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Modes.SicBlockCipher Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::cipher
	SicBlockCipher_t3693949395 * ___cipher_0;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::forEncryption
	bool ___forEncryption_1;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::blockSize
	int32_t ___blockSize_2;
	// Org.BouncyCastle.Crypto.IMac Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::mac
	Il2CppObject * ___mac_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::nonceMac
	ByteU5BU5D_t3397334013* ___nonceMac_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::associatedTextMac
	ByteU5BU5D_t3397334013* ___associatedTextMac_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::macBlock
	ByteU5BU5D_t3397334013* ___macBlock_6;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::macSize
	int32_t ___macSize_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::bufBlock
	ByteU5BU5D_t3397334013* ___bufBlock_8;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::bufOff
	int32_t ___bufOff_9;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::cipherInitialized
	bool ___cipherInitialized_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.EaxBlockCipher::initialAssociatedText
	ByteU5BU5D_t3397334013* ___initialAssociatedText_11;

public:
	inline static int32_t get_offset_of_cipher_0() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___cipher_0)); }
	inline SicBlockCipher_t3693949395 * get_cipher_0() const { return ___cipher_0; }
	inline SicBlockCipher_t3693949395 ** get_address_of_cipher_0() { return &___cipher_0; }
	inline void set_cipher_0(SicBlockCipher_t3693949395 * value)
	{
		___cipher_0 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_0, value);
	}

	inline static int32_t get_offset_of_forEncryption_1() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___forEncryption_1)); }
	inline bool get_forEncryption_1() const { return ___forEncryption_1; }
	inline bool* get_address_of_forEncryption_1() { return &___forEncryption_1; }
	inline void set_forEncryption_1(bool value)
	{
		___forEncryption_1 = value;
	}

	inline static int32_t get_offset_of_blockSize_2() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___blockSize_2)); }
	inline int32_t get_blockSize_2() const { return ___blockSize_2; }
	inline int32_t* get_address_of_blockSize_2() { return &___blockSize_2; }
	inline void set_blockSize_2(int32_t value)
	{
		___blockSize_2 = value;
	}

	inline static int32_t get_offset_of_mac_3() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___mac_3)); }
	inline Il2CppObject * get_mac_3() const { return ___mac_3; }
	inline Il2CppObject ** get_address_of_mac_3() { return &___mac_3; }
	inline void set_mac_3(Il2CppObject * value)
	{
		___mac_3 = value;
		Il2CppCodeGenWriteBarrier(&___mac_3, value);
	}

	inline static int32_t get_offset_of_nonceMac_4() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___nonceMac_4)); }
	inline ByteU5BU5D_t3397334013* get_nonceMac_4() const { return ___nonceMac_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_nonceMac_4() { return &___nonceMac_4; }
	inline void set_nonceMac_4(ByteU5BU5D_t3397334013* value)
	{
		___nonceMac_4 = value;
		Il2CppCodeGenWriteBarrier(&___nonceMac_4, value);
	}

	inline static int32_t get_offset_of_associatedTextMac_5() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___associatedTextMac_5)); }
	inline ByteU5BU5D_t3397334013* get_associatedTextMac_5() const { return ___associatedTextMac_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_associatedTextMac_5() { return &___associatedTextMac_5; }
	inline void set_associatedTextMac_5(ByteU5BU5D_t3397334013* value)
	{
		___associatedTextMac_5 = value;
		Il2CppCodeGenWriteBarrier(&___associatedTextMac_5, value);
	}

	inline static int32_t get_offset_of_macBlock_6() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___macBlock_6)); }
	inline ByteU5BU5D_t3397334013* get_macBlock_6() const { return ___macBlock_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_macBlock_6() { return &___macBlock_6; }
	inline void set_macBlock_6(ByteU5BU5D_t3397334013* value)
	{
		___macBlock_6 = value;
		Il2CppCodeGenWriteBarrier(&___macBlock_6, value);
	}

	inline static int32_t get_offset_of_macSize_7() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___macSize_7)); }
	inline int32_t get_macSize_7() const { return ___macSize_7; }
	inline int32_t* get_address_of_macSize_7() { return &___macSize_7; }
	inline void set_macSize_7(int32_t value)
	{
		___macSize_7 = value;
	}

	inline static int32_t get_offset_of_bufBlock_8() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___bufBlock_8)); }
	inline ByteU5BU5D_t3397334013* get_bufBlock_8() const { return ___bufBlock_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_bufBlock_8() { return &___bufBlock_8; }
	inline void set_bufBlock_8(ByteU5BU5D_t3397334013* value)
	{
		___bufBlock_8 = value;
		Il2CppCodeGenWriteBarrier(&___bufBlock_8, value);
	}

	inline static int32_t get_offset_of_bufOff_9() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___bufOff_9)); }
	inline int32_t get_bufOff_9() const { return ___bufOff_9; }
	inline int32_t* get_address_of_bufOff_9() { return &___bufOff_9; }
	inline void set_bufOff_9(int32_t value)
	{
		___bufOff_9 = value;
	}

	inline static int32_t get_offset_of_cipherInitialized_10() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___cipherInitialized_10)); }
	inline bool get_cipherInitialized_10() const { return ___cipherInitialized_10; }
	inline bool* get_address_of_cipherInitialized_10() { return &___cipherInitialized_10; }
	inline void set_cipherInitialized_10(bool value)
	{
		___cipherInitialized_10 = value;
	}

	inline static int32_t get_offset_of_initialAssociatedText_11() { return static_cast<int32_t>(offsetof(EaxBlockCipher_t1200038734, ___initialAssociatedText_11)); }
	inline ByteU5BU5D_t3397334013* get_initialAssociatedText_11() const { return ___initialAssociatedText_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_initialAssociatedText_11() { return &___initialAssociatedText_11; }
	inline void set_initialAssociatedText_11(ByteU5BU5D_t3397334013* value)
	{
		___initialAssociatedText_11 = value;
		Il2CppCodeGenWriteBarrier(&___initialAssociatedText_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
