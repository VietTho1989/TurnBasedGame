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
// Org.BouncyCastle.Crypto.Modes.Gcm.IGcmMultiplier
struct IGcmMultiplier_t3661509793;
// Org.BouncyCastle.Crypto.Modes.Gcm.IGcmExponentiator
struct IGcmExponentiator_t1580776532;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.GcmBlockCipher
struct  GcmBlockCipher_t1966957103  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::cipher
	Il2CppObject * ___cipher_1;
	// Org.BouncyCastle.Crypto.Modes.Gcm.IGcmMultiplier Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::multiplier
	Il2CppObject * ___multiplier_2;
	// Org.BouncyCastle.Crypto.Modes.Gcm.IGcmExponentiator Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::exp
	Il2CppObject * ___exp_3;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::forEncryption
	bool ___forEncryption_4;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::macSize
	int32_t ___macSize_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::nonce
	ByteU5BU5D_t3397334013* ___nonce_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::initialAssociatedText
	ByteU5BU5D_t3397334013* ___initialAssociatedText_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::H
	ByteU5BU5D_t3397334013* ___H_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::J0
	ByteU5BU5D_t3397334013* ___J0_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::bufBlock
	ByteU5BU5D_t3397334013* ___bufBlock_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::macBlock
	ByteU5BU5D_t3397334013* ___macBlock_11;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::S
	ByteU5BU5D_t3397334013* ___S_12;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::S_at
	ByteU5BU5D_t3397334013* ___S_at_13;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::S_atPre
	ByteU5BU5D_t3397334013* ___S_atPre_14;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::counter
	ByteU5BU5D_t3397334013* ___counter_15;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::bufOff
	int32_t ___bufOff_16;
	// System.UInt64 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::totalLength
	uint64_t ___totalLength_17;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::atBlock
	ByteU5BU5D_t3397334013* ___atBlock_18;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::atBlockPos
	int32_t ___atBlockPos_19;
	// System.UInt64 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::atLength
	uint64_t ___atLength_20;
	// System.UInt64 Org.BouncyCastle.Crypto.Modes.GcmBlockCipher::atLengthPre
	uint64_t ___atLengthPre_21;

public:
	inline static int32_t get_offset_of_cipher_1() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___cipher_1)); }
	inline Il2CppObject * get_cipher_1() const { return ___cipher_1; }
	inline Il2CppObject ** get_address_of_cipher_1() { return &___cipher_1; }
	inline void set_cipher_1(Il2CppObject * value)
	{
		___cipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_1, value);
	}

	inline static int32_t get_offset_of_multiplier_2() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___multiplier_2)); }
	inline Il2CppObject * get_multiplier_2() const { return ___multiplier_2; }
	inline Il2CppObject ** get_address_of_multiplier_2() { return &___multiplier_2; }
	inline void set_multiplier_2(Il2CppObject * value)
	{
		___multiplier_2 = value;
		Il2CppCodeGenWriteBarrier(&___multiplier_2, value);
	}

	inline static int32_t get_offset_of_exp_3() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___exp_3)); }
	inline Il2CppObject * get_exp_3() const { return ___exp_3; }
	inline Il2CppObject ** get_address_of_exp_3() { return &___exp_3; }
	inline void set_exp_3(Il2CppObject * value)
	{
		___exp_3 = value;
		Il2CppCodeGenWriteBarrier(&___exp_3, value);
	}

	inline static int32_t get_offset_of_forEncryption_4() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___forEncryption_4)); }
	inline bool get_forEncryption_4() const { return ___forEncryption_4; }
	inline bool* get_address_of_forEncryption_4() { return &___forEncryption_4; }
	inline void set_forEncryption_4(bool value)
	{
		___forEncryption_4 = value;
	}

	inline static int32_t get_offset_of_macSize_5() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___macSize_5)); }
	inline int32_t get_macSize_5() const { return ___macSize_5; }
	inline int32_t* get_address_of_macSize_5() { return &___macSize_5; }
	inline void set_macSize_5(int32_t value)
	{
		___macSize_5 = value;
	}

	inline static int32_t get_offset_of_nonce_6() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___nonce_6)); }
	inline ByteU5BU5D_t3397334013* get_nonce_6() const { return ___nonce_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_nonce_6() { return &___nonce_6; }
	inline void set_nonce_6(ByteU5BU5D_t3397334013* value)
	{
		___nonce_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonce_6, value);
	}

	inline static int32_t get_offset_of_initialAssociatedText_7() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___initialAssociatedText_7)); }
	inline ByteU5BU5D_t3397334013* get_initialAssociatedText_7() const { return ___initialAssociatedText_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_initialAssociatedText_7() { return &___initialAssociatedText_7; }
	inline void set_initialAssociatedText_7(ByteU5BU5D_t3397334013* value)
	{
		___initialAssociatedText_7 = value;
		Il2CppCodeGenWriteBarrier(&___initialAssociatedText_7, value);
	}

	inline static int32_t get_offset_of_H_8() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___H_8)); }
	inline ByteU5BU5D_t3397334013* get_H_8() const { return ___H_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_H_8() { return &___H_8; }
	inline void set_H_8(ByteU5BU5D_t3397334013* value)
	{
		___H_8 = value;
		Il2CppCodeGenWriteBarrier(&___H_8, value);
	}

	inline static int32_t get_offset_of_J0_9() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___J0_9)); }
	inline ByteU5BU5D_t3397334013* get_J0_9() const { return ___J0_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_J0_9() { return &___J0_9; }
	inline void set_J0_9(ByteU5BU5D_t3397334013* value)
	{
		___J0_9 = value;
		Il2CppCodeGenWriteBarrier(&___J0_9, value);
	}

	inline static int32_t get_offset_of_bufBlock_10() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___bufBlock_10)); }
	inline ByteU5BU5D_t3397334013* get_bufBlock_10() const { return ___bufBlock_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_bufBlock_10() { return &___bufBlock_10; }
	inline void set_bufBlock_10(ByteU5BU5D_t3397334013* value)
	{
		___bufBlock_10 = value;
		Il2CppCodeGenWriteBarrier(&___bufBlock_10, value);
	}

	inline static int32_t get_offset_of_macBlock_11() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___macBlock_11)); }
	inline ByteU5BU5D_t3397334013* get_macBlock_11() const { return ___macBlock_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_macBlock_11() { return &___macBlock_11; }
	inline void set_macBlock_11(ByteU5BU5D_t3397334013* value)
	{
		___macBlock_11 = value;
		Il2CppCodeGenWriteBarrier(&___macBlock_11, value);
	}

	inline static int32_t get_offset_of_S_12() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___S_12)); }
	inline ByteU5BU5D_t3397334013* get_S_12() const { return ___S_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_12() { return &___S_12; }
	inline void set_S_12(ByteU5BU5D_t3397334013* value)
	{
		___S_12 = value;
		Il2CppCodeGenWriteBarrier(&___S_12, value);
	}

	inline static int32_t get_offset_of_S_at_13() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___S_at_13)); }
	inline ByteU5BU5D_t3397334013* get_S_at_13() const { return ___S_at_13; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_at_13() { return &___S_at_13; }
	inline void set_S_at_13(ByteU5BU5D_t3397334013* value)
	{
		___S_at_13 = value;
		Il2CppCodeGenWriteBarrier(&___S_at_13, value);
	}

	inline static int32_t get_offset_of_S_atPre_14() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___S_atPre_14)); }
	inline ByteU5BU5D_t3397334013* get_S_atPre_14() const { return ___S_atPre_14; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_atPre_14() { return &___S_atPre_14; }
	inline void set_S_atPre_14(ByteU5BU5D_t3397334013* value)
	{
		___S_atPre_14 = value;
		Il2CppCodeGenWriteBarrier(&___S_atPre_14, value);
	}

	inline static int32_t get_offset_of_counter_15() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___counter_15)); }
	inline ByteU5BU5D_t3397334013* get_counter_15() const { return ___counter_15; }
	inline ByteU5BU5D_t3397334013** get_address_of_counter_15() { return &___counter_15; }
	inline void set_counter_15(ByteU5BU5D_t3397334013* value)
	{
		___counter_15 = value;
		Il2CppCodeGenWriteBarrier(&___counter_15, value);
	}

	inline static int32_t get_offset_of_bufOff_16() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___bufOff_16)); }
	inline int32_t get_bufOff_16() const { return ___bufOff_16; }
	inline int32_t* get_address_of_bufOff_16() { return &___bufOff_16; }
	inline void set_bufOff_16(int32_t value)
	{
		___bufOff_16 = value;
	}

	inline static int32_t get_offset_of_totalLength_17() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___totalLength_17)); }
	inline uint64_t get_totalLength_17() const { return ___totalLength_17; }
	inline uint64_t* get_address_of_totalLength_17() { return &___totalLength_17; }
	inline void set_totalLength_17(uint64_t value)
	{
		___totalLength_17 = value;
	}

	inline static int32_t get_offset_of_atBlock_18() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___atBlock_18)); }
	inline ByteU5BU5D_t3397334013* get_atBlock_18() const { return ___atBlock_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_atBlock_18() { return &___atBlock_18; }
	inline void set_atBlock_18(ByteU5BU5D_t3397334013* value)
	{
		___atBlock_18 = value;
		Il2CppCodeGenWriteBarrier(&___atBlock_18, value);
	}

	inline static int32_t get_offset_of_atBlockPos_19() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___atBlockPos_19)); }
	inline int32_t get_atBlockPos_19() const { return ___atBlockPos_19; }
	inline int32_t* get_address_of_atBlockPos_19() { return &___atBlockPos_19; }
	inline void set_atBlockPos_19(int32_t value)
	{
		___atBlockPos_19 = value;
	}

	inline static int32_t get_offset_of_atLength_20() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___atLength_20)); }
	inline uint64_t get_atLength_20() const { return ___atLength_20; }
	inline uint64_t* get_address_of_atLength_20() { return &___atLength_20; }
	inline void set_atLength_20(uint64_t value)
	{
		___atLength_20 = value;
	}

	inline static int32_t get_offset_of_atLengthPre_21() { return static_cast<int32_t>(offsetof(GcmBlockCipher_t1966957103, ___atLengthPre_21)); }
	inline uint64_t get_atLengthPre_21() const { return ___atLengthPre_21; }
	inline uint64_t* get_address_of_atLengthPre_21() { return &___atLengthPre_21; }
	inline void set_atLengthPre_21(uint64_t value)
	{
		___atLengthPre_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
