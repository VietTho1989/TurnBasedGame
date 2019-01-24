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
// System.Collections.IList
struct IList_t3321498491;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Modes.OcbBlockCipher
struct  OcbBlockCipher_t427870536  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::hashCipher
	Il2CppObject * ___hashCipher_1;
	// Org.BouncyCastle.Crypto.IBlockCipher Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::mainCipher
	Il2CppObject * ___mainCipher_2;
	// System.Boolean Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::forEncryption
	bool ___forEncryption_3;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::macSize
	int32_t ___macSize_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::initialAssociatedText
	ByteU5BU5D_t3397334013* ___initialAssociatedText_5;
	// System.Collections.IList Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::L
	Il2CppObject * ___L_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::L_Asterisk
	ByteU5BU5D_t3397334013* ___L_Asterisk_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::L_Dollar
	ByteU5BU5D_t3397334013* ___L_Dollar_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::KtopInput
	ByteU5BU5D_t3397334013* ___KtopInput_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::Stretch
	ByteU5BU5D_t3397334013* ___Stretch_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::OffsetMAIN_0
	ByteU5BU5D_t3397334013* ___OffsetMAIN_0_11;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::hashBlock
	ByteU5BU5D_t3397334013* ___hashBlock_12;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::mainBlock
	ByteU5BU5D_t3397334013* ___mainBlock_13;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::hashBlockPos
	int32_t ___hashBlockPos_14;
	// System.Int32 Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::mainBlockPos
	int32_t ___mainBlockPos_15;
	// System.Int64 Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::hashBlockCount
	int64_t ___hashBlockCount_16;
	// System.Int64 Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::mainBlockCount
	int64_t ___mainBlockCount_17;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::OffsetHASH
	ByteU5BU5D_t3397334013* ___OffsetHASH_18;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::Sum
	ByteU5BU5D_t3397334013* ___Sum_19;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::OffsetMAIN
	ByteU5BU5D_t3397334013* ___OffsetMAIN_20;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::Checksum
	ByteU5BU5D_t3397334013* ___Checksum_21;
	// System.Byte[] Org.BouncyCastle.Crypto.Modes.OcbBlockCipher::macBlock
	ByteU5BU5D_t3397334013* ___macBlock_22;

public:
	inline static int32_t get_offset_of_hashCipher_1() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___hashCipher_1)); }
	inline Il2CppObject * get_hashCipher_1() const { return ___hashCipher_1; }
	inline Il2CppObject ** get_address_of_hashCipher_1() { return &___hashCipher_1; }
	inline void set_hashCipher_1(Il2CppObject * value)
	{
		___hashCipher_1 = value;
		Il2CppCodeGenWriteBarrier(&___hashCipher_1, value);
	}

	inline static int32_t get_offset_of_mainCipher_2() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___mainCipher_2)); }
	inline Il2CppObject * get_mainCipher_2() const { return ___mainCipher_2; }
	inline Il2CppObject ** get_address_of_mainCipher_2() { return &___mainCipher_2; }
	inline void set_mainCipher_2(Il2CppObject * value)
	{
		___mainCipher_2 = value;
		Il2CppCodeGenWriteBarrier(&___mainCipher_2, value);
	}

	inline static int32_t get_offset_of_forEncryption_3() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___forEncryption_3)); }
	inline bool get_forEncryption_3() const { return ___forEncryption_3; }
	inline bool* get_address_of_forEncryption_3() { return &___forEncryption_3; }
	inline void set_forEncryption_3(bool value)
	{
		___forEncryption_3 = value;
	}

	inline static int32_t get_offset_of_macSize_4() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___macSize_4)); }
	inline int32_t get_macSize_4() const { return ___macSize_4; }
	inline int32_t* get_address_of_macSize_4() { return &___macSize_4; }
	inline void set_macSize_4(int32_t value)
	{
		___macSize_4 = value;
	}

	inline static int32_t get_offset_of_initialAssociatedText_5() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___initialAssociatedText_5)); }
	inline ByteU5BU5D_t3397334013* get_initialAssociatedText_5() const { return ___initialAssociatedText_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_initialAssociatedText_5() { return &___initialAssociatedText_5; }
	inline void set_initialAssociatedText_5(ByteU5BU5D_t3397334013* value)
	{
		___initialAssociatedText_5 = value;
		Il2CppCodeGenWriteBarrier(&___initialAssociatedText_5, value);
	}

	inline static int32_t get_offset_of_L_6() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___L_6)); }
	inline Il2CppObject * get_L_6() const { return ___L_6; }
	inline Il2CppObject ** get_address_of_L_6() { return &___L_6; }
	inline void set_L_6(Il2CppObject * value)
	{
		___L_6 = value;
		Il2CppCodeGenWriteBarrier(&___L_6, value);
	}

	inline static int32_t get_offset_of_L_Asterisk_7() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___L_Asterisk_7)); }
	inline ByteU5BU5D_t3397334013* get_L_Asterisk_7() const { return ___L_Asterisk_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_L_Asterisk_7() { return &___L_Asterisk_7; }
	inline void set_L_Asterisk_7(ByteU5BU5D_t3397334013* value)
	{
		___L_Asterisk_7 = value;
		Il2CppCodeGenWriteBarrier(&___L_Asterisk_7, value);
	}

	inline static int32_t get_offset_of_L_Dollar_8() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___L_Dollar_8)); }
	inline ByteU5BU5D_t3397334013* get_L_Dollar_8() const { return ___L_Dollar_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_L_Dollar_8() { return &___L_Dollar_8; }
	inline void set_L_Dollar_8(ByteU5BU5D_t3397334013* value)
	{
		___L_Dollar_8 = value;
		Il2CppCodeGenWriteBarrier(&___L_Dollar_8, value);
	}

	inline static int32_t get_offset_of_KtopInput_9() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___KtopInput_9)); }
	inline ByteU5BU5D_t3397334013* get_KtopInput_9() const { return ___KtopInput_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_KtopInput_9() { return &___KtopInput_9; }
	inline void set_KtopInput_9(ByteU5BU5D_t3397334013* value)
	{
		___KtopInput_9 = value;
		Il2CppCodeGenWriteBarrier(&___KtopInput_9, value);
	}

	inline static int32_t get_offset_of_Stretch_10() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___Stretch_10)); }
	inline ByteU5BU5D_t3397334013* get_Stretch_10() const { return ___Stretch_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_Stretch_10() { return &___Stretch_10; }
	inline void set_Stretch_10(ByteU5BU5D_t3397334013* value)
	{
		___Stretch_10 = value;
		Il2CppCodeGenWriteBarrier(&___Stretch_10, value);
	}

	inline static int32_t get_offset_of_OffsetMAIN_0_11() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___OffsetMAIN_0_11)); }
	inline ByteU5BU5D_t3397334013* get_OffsetMAIN_0_11() const { return ___OffsetMAIN_0_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_OffsetMAIN_0_11() { return &___OffsetMAIN_0_11; }
	inline void set_OffsetMAIN_0_11(ByteU5BU5D_t3397334013* value)
	{
		___OffsetMAIN_0_11 = value;
		Il2CppCodeGenWriteBarrier(&___OffsetMAIN_0_11, value);
	}

	inline static int32_t get_offset_of_hashBlock_12() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___hashBlock_12)); }
	inline ByteU5BU5D_t3397334013* get_hashBlock_12() const { return ___hashBlock_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_hashBlock_12() { return &___hashBlock_12; }
	inline void set_hashBlock_12(ByteU5BU5D_t3397334013* value)
	{
		___hashBlock_12 = value;
		Il2CppCodeGenWriteBarrier(&___hashBlock_12, value);
	}

	inline static int32_t get_offset_of_mainBlock_13() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___mainBlock_13)); }
	inline ByteU5BU5D_t3397334013* get_mainBlock_13() const { return ___mainBlock_13; }
	inline ByteU5BU5D_t3397334013** get_address_of_mainBlock_13() { return &___mainBlock_13; }
	inline void set_mainBlock_13(ByteU5BU5D_t3397334013* value)
	{
		___mainBlock_13 = value;
		Il2CppCodeGenWriteBarrier(&___mainBlock_13, value);
	}

	inline static int32_t get_offset_of_hashBlockPos_14() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___hashBlockPos_14)); }
	inline int32_t get_hashBlockPos_14() const { return ___hashBlockPos_14; }
	inline int32_t* get_address_of_hashBlockPos_14() { return &___hashBlockPos_14; }
	inline void set_hashBlockPos_14(int32_t value)
	{
		___hashBlockPos_14 = value;
	}

	inline static int32_t get_offset_of_mainBlockPos_15() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___mainBlockPos_15)); }
	inline int32_t get_mainBlockPos_15() const { return ___mainBlockPos_15; }
	inline int32_t* get_address_of_mainBlockPos_15() { return &___mainBlockPos_15; }
	inline void set_mainBlockPos_15(int32_t value)
	{
		___mainBlockPos_15 = value;
	}

	inline static int32_t get_offset_of_hashBlockCount_16() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___hashBlockCount_16)); }
	inline int64_t get_hashBlockCount_16() const { return ___hashBlockCount_16; }
	inline int64_t* get_address_of_hashBlockCount_16() { return &___hashBlockCount_16; }
	inline void set_hashBlockCount_16(int64_t value)
	{
		___hashBlockCount_16 = value;
	}

	inline static int32_t get_offset_of_mainBlockCount_17() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___mainBlockCount_17)); }
	inline int64_t get_mainBlockCount_17() const { return ___mainBlockCount_17; }
	inline int64_t* get_address_of_mainBlockCount_17() { return &___mainBlockCount_17; }
	inline void set_mainBlockCount_17(int64_t value)
	{
		___mainBlockCount_17 = value;
	}

	inline static int32_t get_offset_of_OffsetHASH_18() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___OffsetHASH_18)); }
	inline ByteU5BU5D_t3397334013* get_OffsetHASH_18() const { return ___OffsetHASH_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_OffsetHASH_18() { return &___OffsetHASH_18; }
	inline void set_OffsetHASH_18(ByteU5BU5D_t3397334013* value)
	{
		___OffsetHASH_18 = value;
		Il2CppCodeGenWriteBarrier(&___OffsetHASH_18, value);
	}

	inline static int32_t get_offset_of_Sum_19() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___Sum_19)); }
	inline ByteU5BU5D_t3397334013* get_Sum_19() const { return ___Sum_19; }
	inline ByteU5BU5D_t3397334013** get_address_of_Sum_19() { return &___Sum_19; }
	inline void set_Sum_19(ByteU5BU5D_t3397334013* value)
	{
		___Sum_19 = value;
		Il2CppCodeGenWriteBarrier(&___Sum_19, value);
	}

	inline static int32_t get_offset_of_OffsetMAIN_20() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___OffsetMAIN_20)); }
	inline ByteU5BU5D_t3397334013* get_OffsetMAIN_20() const { return ___OffsetMAIN_20; }
	inline ByteU5BU5D_t3397334013** get_address_of_OffsetMAIN_20() { return &___OffsetMAIN_20; }
	inline void set_OffsetMAIN_20(ByteU5BU5D_t3397334013* value)
	{
		___OffsetMAIN_20 = value;
		Il2CppCodeGenWriteBarrier(&___OffsetMAIN_20, value);
	}

	inline static int32_t get_offset_of_Checksum_21() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___Checksum_21)); }
	inline ByteU5BU5D_t3397334013* get_Checksum_21() const { return ___Checksum_21; }
	inline ByteU5BU5D_t3397334013** get_address_of_Checksum_21() { return &___Checksum_21; }
	inline void set_Checksum_21(ByteU5BU5D_t3397334013* value)
	{
		___Checksum_21 = value;
		Il2CppCodeGenWriteBarrier(&___Checksum_21, value);
	}

	inline static int32_t get_offset_of_macBlock_22() { return static_cast<int32_t>(offsetof(OcbBlockCipher_t427870536, ___macBlock_22)); }
	inline ByteU5BU5D_t3397334013* get_macBlock_22() const { return ___macBlock_22; }
	inline ByteU5BU5D_t3397334013** get_address_of_macBlock_22() { return &___macBlock_22; }
	inline void set_macBlock_22(ByteU5BU5D_t3397334013* value)
	{
		___macBlock_22 = value;
		Il2CppCodeGenWriteBarrier(&___macBlock_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
