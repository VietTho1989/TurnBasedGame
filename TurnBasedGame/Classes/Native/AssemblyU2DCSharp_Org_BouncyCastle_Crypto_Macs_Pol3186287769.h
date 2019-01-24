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

// Org.BouncyCastle.Crypto.Macs.Poly1305
struct  Poly1305_t3186287769  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Macs.Poly1305::cipher
	Il2CppObject * ___cipher_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.Poly1305::singleByte
	ByteU5BU5D_t3397334013* ___singleByte_2;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::r0
	uint32_t ___r0_3;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::r1
	uint32_t ___r1_4;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::r2
	uint32_t ___r2_5;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::r3
	uint32_t ___r3_6;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::r4
	uint32_t ___r4_7;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::s1
	uint32_t ___s1_8;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::s2
	uint32_t ___s2_9;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::s3
	uint32_t ___s3_10;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::s4
	uint32_t ___s4_11;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::k0
	uint32_t ___k0_12;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::k1
	uint32_t ___k1_13;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::k2
	uint32_t ___k2_14;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::k3
	uint32_t ___k3_15;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.Poly1305::currentBlock
	ByteU5BU5D_t3397334013* ___currentBlock_16;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.Poly1305::currentBlockOffset
	int32_t ___currentBlockOffset_17;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::h0
	uint32_t ___h0_18;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::h1
	uint32_t ___h1_19;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::h2
	uint32_t ___h2_20;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::h3
	uint32_t ___h3_21;
	// System.UInt32 Org.BouncyCastle.Crypto.Macs.Poly1305::h4
	uint32_t ___h4_22;

public:
	inline static int32_t get_offset_of_cipher_1() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___cipher_1)); }
	inline Il2CppObject * get_cipher_1() const { return ___cipher_1; }
	inline Il2CppObject ** get_address_of_cipher_1() { return &___cipher_1; }
	inline void set_cipher_1(Il2CppObject * value)
	{
		___cipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_1, value);
	}

	inline static int32_t get_offset_of_singleByte_2() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___singleByte_2)); }
	inline ByteU5BU5D_t3397334013* get_singleByte_2() const { return ___singleByte_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_singleByte_2() { return &___singleByte_2; }
	inline void set_singleByte_2(ByteU5BU5D_t3397334013* value)
	{
		___singleByte_2 = value;
		Il2CppCodeGenWriteBarrier(&___singleByte_2, value);
	}

	inline static int32_t get_offset_of_r0_3() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___r0_3)); }
	inline uint32_t get_r0_3() const { return ___r0_3; }
	inline uint32_t* get_address_of_r0_3() { return &___r0_3; }
	inline void set_r0_3(uint32_t value)
	{
		___r0_3 = value;
	}

	inline static int32_t get_offset_of_r1_4() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___r1_4)); }
	inline uint32_t get_r1_4() const { return ___r1_4; }
	inline uint32_t* get_address_of_r1_4() { return &___r1_4; }
	inline void set_r1_4(uint32_t value)
	{
		___r1_4 = value;
	}

	inline static int32_t get_offset_of_r2_5() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___r2_5)); }
	inline uint32_t get_r2_5() const { return ___r2_5; }
	inline uint32_t* get_address_of_r2_5() { return &___r2_5; }
	inline void set_r2_5(uint32_t value)
	{
		___r2_5 = value;
	}

	inline static int32_t get_offset_of_r3_6() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___r3_6)); }
	inline uint32_t get_r3_6() const { return ___r3_6; }
	inline uint32_t* get_address_of_r3_6() { return &___r3_6; }
	inline void set_r3_6(uint32_t value)
	{
		___r3_6 = value;
	}

	inline static int32_t get_offset_of_r4_7() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___r4_7)); }
	inline uint32_t get_r4_7() const { return ___r4_7; }
	inline uint32_t* get_address_of_r4_7() { return &___r4_7; }
	inline void set_r4_7(uint32_t value)
	{
		___r4_7 = value;
	}

	inline static int32_t get_offset_of_s1_8() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___s1_8)); }
	inline uint32_t get_s1_8() const { return ___s1_8; }
	inline uint32_t* get_address_of_s1_8() { return &___s1_8; }
	inline void set_s1_8(uint32_t value)
	{
		___s1_8 = value;
	}

	inline static int32_t get_offset_of_s2_9() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___s2_9)); }
	inline uint32_t get_s2_9() const { return ___s2_9; }
	inline uint32_t* get_address_of_s2_9() { return &___s2_9; }
	inline void set_s2_9(uint32_t value)
	{
		___s2_9 = value;
	}

	inline static int32_t get_offset_of_s3_10() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___s3_10)); }
	inline uint32_t get_s3_10() const { return ___s3_10; }
	inline uint32_t* get_address_of_s3_10() { return &___s3_10; }
	inline void set_s3_10(uint32_t value)
	{
		___s3_10 = value;
	}

	inline static int32_t get_offset_of_s4_11() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___s4_11)); }
	inline uint32_t get_s4_11() const { return ___s4_11; }
	inline uint32_t* get_address_of_s4_11() { return &___s4_11; }
	inline void set_s4_11(uint32_t value)
	{
		___s4_11 = value;
	}

	inline static int32_t get_offset_of_k0_12() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___k0_12)); }
	inline uint32_t get_k0_12() const { return ___k0_12; }
	inline uint32_t* get_address_of_k0_12() { return &___k0_12; }
	inline void set_k0_12(uint32_t value)
	{
		___k0_12 = value;
	}

	inline static int32_t get_offset_of_k1_13() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___k1_13)); }
	inline uint32_t get_k1_13() const { return ___k1_13; }
	inline uint32_t* get_address_of_k1_13() { return &___k1_13; }
	inline void set_k1_13(uint32_t value)
	{
		___k1_13 = value;
	}

	inline static int32_t get_offset_of_k2_14() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___k2_14)); }
	inline uint32_t get_k2_14() const { return ___k2_14; }
	inline uint32_t* get_address_of_k2_14() { return &___k2_14; }
	inline void set_k2_14(uint32_t value)
	{
		___k2_14 = value;
	}

	inline static int32_t get_offset_of_k3_15() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___k3_15)); }
	inline uint32_t get_k3_15() const { return ___k3_15; }
	inline uint32_t* get_address_of_k3_15() { return &___k3_15; }
	inline void set_k3_15(uint32_t value)
	{
		___k3_15 = value;
	}

	inline static int32_t get_offset_of_currentBlock_16() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___currentBlock_16)); }
	inline ByteU5BU5D_t3397334013* get_currentBlock_16() const { return ___currentBlock_16; }
	inline ByteU5BU5D_t3397334013** get_address_of_currentBlock_16() { return &___currentBlock_16; }
	inline void set_currentBlock_16(ByteU5BU5D_t3397334013* value)
	{
		___currentBlock_16 = value;
		Il2CppCodeGenWriteBarrier(&___currentBlock_16, value);
	}

	inline static int32_t get_offset_of_currentBlockOffset_17() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___currentBlockOffset_17)); }
	inline int32_t get_currentBlockOffset_17() const { return ___currentBlockOffset_17; }
	inline int32_t* get_address_of_currentBlockOffset_17() { return &___currentBlockOffset_17; }
	inline void set_currentBlockOffset_17(int32_t value)
	{
		___currentBlockOffset_17 = value;
	}

	inline static int32_t get_offset_of_h0_18() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___h0_18)); }
	inline uint32_t get_h0_18() const { return ___h0_18; }
	inline uint32_t* get_address_of_h0_18() { return &___h0_18; }
	inline void set_h0_18(uint32_t value)
	{
		___h0_18 = value;
	}

	inline static int32_t get_offset_of_h1_19() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___h1_19)); }
	inline uint32_t get_h1_19() const { return ___h1_19; }
	inline uint32_t* get_address_of_h1_19() { return &___h1_19; }
	inline void set_h1_19(uint32_t value)
	{
		___h1_19 = value;
	}

	inline static int32_t get_offset_of_h2_20() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___h2_20)); }
	inline uint32_t get_h2_20() const { return ___h2_20; }
	inline uint32_t* get_address_of_h2_20() { return &___h2_20; }
	inline void set_h2_20(uint32_t value)
	{
		___h2_20 = value;
	}

	inline static int32_t get_offset_of_h3_21() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___h3_21)); }
	inline uint32_t get_h3_21() const { return ___h3_21; }
	inline uint32_t* get_address_of_h3_21() { return &___h3_21; }
	inline void set_h3_21(uint32_t value)
	{
		___h3_21 = value;
	}

	inline static int32_t get_offset_of_h4_22() { return static_cast<int32_t>(offsetof(Poly1305_t3186287769, ___h4_22)); }
	inline uint32_t get_h4_22() const { return ___h4_22; }
	inline uint32_t* get_address_of_h4_22() { return &___h4_22; }
	inline void set_h4_22(uint32_t value)
	{
		___h4_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
