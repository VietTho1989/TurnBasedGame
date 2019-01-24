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
// System.Byte[][]
struct ByteU5BU5DU5BU5D_t717853552;
// Org.BouncyCastle.Crypto.IBlockCipher
struct IBlockCipher_t916483717;
// System.Int16[]
struct Int16U5BU5D_t3104283263;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Digests.Gost3411Digest
struct  Gost3411Digest_t3607278510  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::H
	ByteU5BU5D_t3397334013* ___H_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::L
	ByteU5BU5D_t3397334013* ___L_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::M
	ByteU5BU5D_t3397334013* ___M_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::Sum
	ByteU5BU5D_t3397334013* ___Sum_4;
	// System.Byte[][] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::C
	ByteU5BU5DU5BU5D_t717853552* ___C_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::xBuf
	ByteU5BU5D_t3397334013* ___xBuf_6;
	// System.Int32 Org.BouncyCastle.Crypto.Digests.Gost3411Digest::xBufOff
	int32_t ___xBufOff_7;
	// System.UInt64 Org.BouncyCastle.Crypto.Digests.Gost3411Digest::byteCount
	uint64_t ___byteCount_8;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Digests.Gost3411Digest::cipher
	Il2CppObject * ___cipher_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::sBox
	ByteU5BU5D_t3397334013* ___sBox_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::K
	ByteU5BU5D_t3397334013* ___K_11;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::a
	ByteU5BU5D_t3397334013* ___a_12;
	// System.Int16[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::wS
	Int16U5BU5D_t3104283263* ___wS_13;
	// System.Int16[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::w_S
	Int16U5BU5D_t3104283263* ___w_S_14;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::S
	ByteU5BU5D_t3397334013* ___S_15;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::U
	ByteU5BU5D_t3397334013* ___U_16;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::V
	ByteU5BU5D_t3397334013* ___V_17;
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::W
	ByteU5BU5D_t3397334013* ___W_18;

public:
	inline static int32_t get_offset_of_H_1() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___H_1)); }
	inline ByteU5BU5D_t3397334013* get_H_1() const { return ___H_1; }
	inline ByteU5BU5D_t3397334013** get_address_of_H_1() { return &___H_1; }
	inline void set_H_1(ByteU5BU5D_t3397334013* value)
	{
		___H_1 = value;
		Il2CppCodeGenWriteBarrier(&___H_1, value);
	}

	inline static int32_t get_offset_of_L_2() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___L_2)); }
	inline ByteU5BU5D_t3397334013* get_L_2() const { return ___L_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_L_2() { return &___L_2; }
	inline void set_L_2(ByteU5BU5D_t3397334013* value)
	{
		___L_2 = value;
		Il2CppCodeGenWriteBarrier(&___L_2, value);
	}

	inline static int32_t get_offset_of_M_3() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___M_3)); }
	inline ByteU5BU5D_t3397334013* get_M_3() const { return ___M_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_M_3() { return &___M_3; }
	inline void set_M_3(ByteU5BU5D_t3397334013* value)
	{
		___M_3 = value;
		Il2CppCodeGenWriteBarrier(&___M_3, value);
	}

	inline static int32_t get_offset_of_Sum_4() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___Sum_4)); }
	inline ByteU5BU5D_t3397334013* get_Sum_4() const { return ___Sum_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_Sum_4() { return &___Sum_4; }
	inline void set_Sum_4(ByteU5BU5D_t3397334013* value)
	{
		___Sum_4 = value;
		Il2CppCodeGenWriteBarrier(&___Sum_4, value);
	}

	inline static int32_t get_offset_of_C_5() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___C_5)); }
	inline ByteU5BU5DU5BU5D_t717853552* get_C_5() const { return ___C_5; }
	inline ByteU5BU5DU5BU5D_t717853552** get_address_of_C_5() { return &___C_5; }
	inline void set_C_5(ByteU5BU5DU5BU5D_t717853552* value)
	{
		___C_5 = value;
		Il2CppCodeGenWriteBarrier(&___C_5, value);
	}

	inline static int32_t get_offset_of_xBuf_6() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___xBuf_6)); }
	inline ByteU5BU5D_t3397334013* get_xBuf_6() const { return ___xBuf_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_xBuf_6() { return &___xBuf_6; }
	inline void set_xBuf_6(ByteU5BU5D_t3397334013* value)
	{
		___xBuf_6 = value;
		Il2CppCodeGenWriteBarrier(&___xBuf_6, value);
	}

	inline static int32_t get_offset_of_xBufOff_7() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___xBufOff_7)); }
	inline int32_t get_xBufOff_7() const { return ___xBufOff_7; }
	inline int32_t* get_address_of_xBufOff_7() { return &___xBufOff_7; }
	inline void set_xBufOff_7(int32_t value)
	{
		___xBufOff_7 = value;
	}

	inline static int32_t get_offset_of_byteCount_8() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___byteCount_8)); }
	inline uint64_t get_byteCount_8() const { return ___byteCount_8; }
	inline uint64_t* get_address_of_byteCount_8() { return &___byteCount_8; }
	inline void set_byteCount_8(uint64_t value)
	{
		___byteCount_8 = value;
	}

	inline static int32_t get_offset_of_cipher_9() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___cipher_9)); }
	inline Il2CppObject * get_cipher_9() const { return ___cipher_9; }
	inline Il2CppObject ** get_address_of_cipher_9() { return &___cipher_9; }
	inline void set_cipher_9(Il2CppObject * value)
	{
		___cipher_9 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_9, value);
	}

	inline static int32_t get_offset_of_sBox_10() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___sBox_10)); }
	inline ByteU5BU5D_t3397334013* get_sBox_10() const { return ___sBox_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_sBox_10() { return &___sBox_10; }
	inline void set_sBox_10(ByteU5BU5D_t3397334013* value)
	{
		___sBox_10 = value;
		Il2CppCodeGenWriteBarrier(&___sBox_10, value);
	}

	inline static int32_t get_offset_of_K_11() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___K_11)); }
	inline ByteU5BU5D_t3397334013* get_K_11() const { return ___K_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_K_11() { return &___K_11; }
	inline void set_K_11(ByteU5BU5D_t3397334013* value)
	{
		___K_11 = value;
		Il2CppCodeGenWriteBarrier(&___K_11, value);
	}

	inline static int32_t get_offset_of_a_12() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___a_12)); }
	inline ByteU5BU5D_t3397334013* get_a_12() const { return ___a_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_a_12() { return &___a_12; }
	inline void set_a_12(ByteU5BU5D_t3397334013* value)
	{
		___a_12 = value;
		Il2CppCodeGenWriteBarrier(&___a_12, value);
	}

	inline static int32_t get_offset_of_wS_13() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___wS_13)); }
	inline Int16U5BU5D_t3104283263* get_wS_13() const { return ___wS_13; }
	inline Int16U5BU5D_t3104283263** get_address_of_wS_13() { return &___wS_13; }
	inline void set_wS_13(Int16U5BU5D_t3104283263* value)
	{
		___wS_13 = value;
		Il2CppCodeGenWriteBarrier(&___wS_13, value);
	}

	inline static int32_t get_offset_of_w_S_14() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___w_S_14)); }
	inline Int16U5BU5D_t3104283263* get_w_S_14() const { return ___w_S_14; }
	inline Int16U5BU5D_t3104283263** get_address_of_w_S_14() { return &___w_S_14; }
	inline void set_w_S_14(Int16U5BU5D_t3104283263* value)
	{
		___w_S_14 = value;
		Il2CppCodeGenWriteBarrier(&___w_S_14, value);
	}

	inline static int32_t get_offset_of_S_15() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___S_15)); }
	inline ByteU5BU5D_t3397334013* get_S_15() const { return ___S_15; }
	inline ByteU5BU5D_t3397334013** get_address_of_S_15() { return &___S_15; }
	inline void set_S_15(ByteU5BU5D_t3397334013* value)
	{
		___S_15 = value;
		Il2CppCodeGenWriteBarrier(&___S_15, value);
	}

	inline static int32_t get_offset_of_U_16() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___U_16)); }
	inline ByteU5BU5D_t3397334013* get_U_16() const { return ___U_16; }
	inline ByteU5BU5D_t3397334013** get_address_of_U_16() { return &___U_16; }
	inline void set_U_16(ByteU5BU5D_t3397334013* value)
	{
		___U_16 = value;
		Il2CppCodeGenWriteBarrier(&___U_16, value);
	}

	inline static int32_t get_offset_of_V_17() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___V_17)); }
	inline ByteU5BU5D_t3397334013* get_V_17() const { return ___V_17; }
	inline ByteU5BU5D_t3397334013** get_address_of_V_17() { return &___V_17; }
	inline void set_V_17(ByteU5BU5D_t3397334013* value)
	{
		___V_17 = value;
		Il2CppCodeGenWriteBarrier(&___V_17, value);
	}

	inline static int32_t get_offset_of_W_18() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510, ___W_18)); }
	inline ByteU5BU5D_t3397334013* get_W_18() const { return ___W_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_W_18() { return &___W_18; }
	inline void set_W_18(ByteU5BU5D_t3397334013* value)
	{
		___W_18 = value;
		Il2CppCodeGenWriteBarrier(&___W_18, value);
	}
};

struct Gost3411Digest_t3607278510_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Digests.Gost3411Digest::C2
	ByteU5BU5D_t3397334013* ___C2_19;

public:
	inline static int32_t get_offset_of_C2_19() { return static_cast<int32_t>(offsetof(Gost3411Digest_t3607278510_StaticFields, ___C2_19)); }
	inline ByteU5BU5D_t3397334013* get_C2_19() const { return ___C2_19; }
	inline ByteU5BU5D_t3397334013** get_address_of_C2_19() { return &___C2_19; }
	inline void set_C2_19(ByteU5BU5D_t3397334013* value)
	{
		___C2_19 = value;
		Il2CppCodeGenWriteBarrier(&___C2_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
