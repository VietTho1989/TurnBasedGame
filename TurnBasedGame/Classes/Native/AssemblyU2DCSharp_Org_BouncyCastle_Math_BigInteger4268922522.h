#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[][]
struct Int32U5BU5DU5BU5D_t3750818532;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Math.BigInteger[]
struct BigIntegerU5BU5D_t431507903;
// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// System.Random
struct Random_t1044426839;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.BigInteger
struct  BigInteger_t4268922522  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Math.BigInteger::magnitude
	Int32U5BU5D_t3030399641* ___magnitude_30;
	// System.Int32 Org.BouncyCastle.Math.BigInteger::sign
	int32_t ___sign_31;
	// System.Int32 Org.BouncyCastle.Math.BigInteger::nBits
	int32_t ___nBits_32;
	// System.Int32 Org.BouncyCastle.Math.BigInteger::nBitLength
	int32_t ___nBitLength_33;
	// System.Int32 Org.BouncyCastle.Math.BigInteger::mQuote
	int32_t ___mQuote_34;

public:
	inline static int32_t get_offset_of_magnitude_30() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522, ___magnitude_30)); }
	inline Int32U5BU5D_t3030399641* get_magnitude_30() const { return ___magnitude_30; }
	inline Int32U5BU5D_t3030399641** get_address_of_magnitude_30() { return &___magnitude_30; }
	inline void set_magnitude_30(Int32U5BU5D_t3030399641* value)
	{
		___magnitude_30 = value;
		Il2CppCodeGenWriteBarrier(&___magnitude_30, value);
	}

	inline static int32_t get_offset_of_sign_31() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522, ___sign_31)); }
	inline int32_t get_sign_31() const { return ___sign_31; }
	inline int32_t* get_address_of_sign_31() { return &___sign_31; }
	inline void set_sign_31(int32_t value)
	{
		___sign_31 = value;
	}

	inline static int32_t get_offset_of_nBits_32() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522, ___nBits_32)); }
	inline int32_t get_nBits_32() const { return ___nBits_32; }
	inline int32_t* get_address_of_nBits_32() { return &___nBits_32; }
	inline void set_nBits_32(int32_t value)
	{
		___nBits_32 = value;
	}

	inline static int32_t get_offset_of_nBitLength_33() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522, ___nBitLength_33)); }
	inline int32_t get_nBitLength_33() const { return ___nBitLength_33; }
	inline int32_t* get_address_of_nBitLength_33() { return &___nBitLength_33; }
	inline void set_nBitLength_33(int32_t value)
	{
		___nBitLength_33 = value;
	}

	inline static int32_t get_offset_of_mQuote_34() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522, ___mQuote_34)); }
	inline int32_t get_mQuote_34() const { return ___mQuote_34; }
	inline int32_t* get_address_of_mQuote_34() { return &___mQuote_34; }
	inline void set_mQuote_34(int32_t value)
	{
		___mQuote_34 = value;
	}
};

struct BigInteger_t4268922522_StaticFields
{
public:
	// System.Int32[][] Org.BouncyCastle.Math.BigInteger::primeLists
	Int32U5BU5DU5BU5D_t3750818532* ___primeLists_0;
	// System.Int32[] Org.BouncyCastle.Math.BigInteger::primeProducts
	Int32U5BU5D_t3030399641* ___primeProducts_1;
	// System.Int32[] Org.BouncyCastle.Math.BigInteger::ZeroMagnitude
	Int32U5BU5D_t3030399641* ___ZeroMagnitude_4;
	// System.Byte[] Org.BouncyCastle.Math.BigInteger::ZeroEncoding
	ByteU5BU5D_t3397334013* ___ZeroEncoding_5;
	// Org.BouncyCastle.Math.BigInteger[] Org.BouncyCastle.Math.BigInteger::SMALL_CONSTANTS
	BigIntegerU5BU5D_t431507903* ___SMALL_CONSTANTS_6;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::Zero
	BigInteger_t4268922522 * ___Zero_7;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::One
	BigInteger_t4268922522 * ___One_8;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::Two
	BigInteger_t4268922522 * ___Two_9;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::Three
	BigInteger_t4268922522 * ___Three_10;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::Ten
	BigInteger_t4268922522 * ___Ten_11;
	// System.Byte[] Org.BouncyCastle.Math.BigInteger::BitLengthTable
	ByteU5BU5D_t3397334013* ___BitLengthTable_12;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix2
	BigInteger_t4268922522 * ___radix2_17;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix2E
	BigInteger_t4268922522 * ___radix2E_18;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix8
	BigInteger_t4268922522 * ___radix8_19;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix8E
	BigInteger_t4268922522 * ___radix8E_20;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix10
	BigInteger_t4268922522 * ___radix10_21;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix10E
	BigInteger_t4268922522 * ___radix10E_22;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix16
	BigInteger_t4268922522 * ___radix16_23;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Math.BigInteger::radix16E
	BigInteger_t4268922522 * ___radix16E_24;
	// System.Random Org.BouncyCastle.Math.BigInteger::RandomSource
	Random_t1044426839 * ___RandomSource_25;
	// System.Int32[] Org.BouncyCastle.Math.BigInteger::ExpWindowThresholds
	Int32U5BU5D_t3030399641* ___ExpWindowThresholds_26;

public:
	inline static int32_t get_offset_of_primeLists_0() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___primeLists_0)); }
	inline Int32U5BU5DU5BU5D_t3750818532* get_primeLists_0() const { return ___primeLists_0; }
	inline Int32U5BU5DU5BU5D_t3750818532** get_address_of_primeLists_0() { return &___primeLists_0; }
	inline void set_primeLists_0(Int32U5BU5DU5BU5D_t3750818532* value)
	{
		___primeLists_0 = value;
		Il2CppCodeGenWriteBarrier(&___primeLists_0, value);
	}

	inline static int32_t get_offset_of_primeProducts_1() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___primeProducts_1)); }
	inline Int32U5BU5D_t3030399641* get_primeProducts_1() const { return ___primeProducts_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_primeProducts_1() { return &___primeProducts_1; }
	inline void set_primeProducts_1(Int32U5BU5D_t3030399641* value)
	{
		___primeProducts_1 = value;
		Il2CppCodeGenWriteBarrier(&___primeProducts_1, value);
	}

	inline static int32_t get_offset_of_ZeroMagnitude_4() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___ZeroMagnitude_4)); }
	inline Int32U5BU5D_t3030399641* get_ZeroMagnitude_4() const { return ___ZeroMagnitude_4; }
	inline Int32U5BU5D_t3030399641** get_address_of_ZeroMagnitude_4() { return &___ZeroMagnitude_4; }
	inline void set_ZeroMagnitude_4(Int32U5BU5D_t3030399641* value)
	{
		___ZeroMagnitude_4 = value;
		Il2CppCodeGenWriteBarrier(&___ZeroMagnitude_4, value);
	}

	inline static int32_t get_offset_of_ZeroEncoding_5() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___ZeroEncoding_5)); }
	inline ByteU5BU5D_t3397334013* get_ZeroEncoding_5() const { return ___ZeroEncoding_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_ZeroEncoding_5() { return &___ZeroEncoding_5; }
	inline void set_ZeroEncoding_5(ByteU5BU5D_t3397334013* value)
	{
		___ZeroEncoding_5 = value;
		Il2CppCodeGenWriteBarrier(&___ZeroEncoding_5, value);
	}

	inline static int32_t get_offset_of_SMALL_CONSTANTS_6() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___SMALL_CONSTANTS_6)); }
	inline BigIntegerU5BU5D_t431507903* get_SMALL_CONSTANTS_6() const { return ___SMALL_CONSTANTS_6; }
	inline BigIntegerU5BU5D_t431507903** get_address_of_SMALL_CONSTANTS_6() { return &___SMALL_CONSTANTS_6; }
	inline void set_SMALL_CONSTANTS_6(BigIntegerU5BU5D_t431507903* value)
	{
		___SMALL_CONSTANTS_6 = value;
		Il2CppCodeGenWriteBarrier(&___SMALL_CONSTANTS_6, value);
	}

	inline static int32_t get_offset_of_Zero_7() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___Zero_7)); }
	inline BigInteger_t4268922522 * get_Zero_7() const { return ___Zero_7; }
	inline BigInteger_t4268922522 ** get_address_of_Zero_7() { return &___Zero_7; }
	inline void set_Zero_7(BigInteger_t4268922522 * value)
	{
		___Zero_7 = value;
		Il2CppCodeGenWriteBarrier(&___Zero_7, value);
	}

	inline static int32_t get_offset_of_One_8() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___One_8)); }
	inline BigInteger_t4268922522 * get_One_8() const { return ___One_8; }
	inline BigInteger_t4268922522 ** get_address_of_One_8() { return &___One_8; }
	inline void set_One_8(BigInteger_t4268922522 * value)
	{
		___One_8 = value;
		Il2CppCodeGenWriteBarrier(&___One_8, value);
	}

	inline static int32_t get_offset_of_Two_9() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___Two_9)); }
	inline BigInteger_t4268922522 * get_Two_9() const { return ___Two_9; }
	inline BigInteger_t4268922522 ** get_address_of_Two_9() { return &___Two_9; }
	inline void set_Two_9(BigInteger_t4268922522 * value)
	{
		___Two_9 = value;
		Il2CppCodeGenWriteBarrier(&___Two_9, value);
	}

	inline static int32_t get_offset_of_Three_10() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___Three_10)); }
	inline BigInteger_t4268922522 * get_Three_10() const { return ___Three_10; }
	inline BigInteger_t4268922522 ** get_address_of_Three_10() { return &___Three_10; }
	inline void set_Three_10(BigInteger_t4268922522 * value)
	{
		___Three_10 = value;
		Il2CppCodeGenWriteBarrier(&___Three_10, value);
	}

	inline static int32_t get_offset_of_Ten_11() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___Ten_11)); }
	inline BigInteger_t4268922522 * get_Ten_11() const { return ___Ten_11; }
	inline BigInteger_t4268922522 ** get_address_of_Ten_11() { return &___Ten_11; }
	inline void set_Ten_11(BigInteger_t4268922522 * value)
	{
		___Ten_11 = value;
		Il2CppCodeGenWriteBarrier(&___Ten_11, value);
	}

	inline static int32_t get_offset_of_BitLengthTable_12() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___BitLengthTable_12)); }
	inline ByteU5BU5D_t3397334013* get_BitLengthTable_12() const { return ___BitLengthTable_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_BitLengthTable_12() { return &___BitLengthTable_12; }
	inline void set_BitLengthTable_12(ByteU5BU5D_t3397334013* value)
	{
		___BitLengthTable_12 = value;
		Il2CppCodeGenWriteBarrier(&___BitLengthTable_12, value);
	}

	inline static int32_t get_offset_of_radix2_17() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix2_17)); }
	inline BigInteger_t4268922522 * get_radix2_17() const { return ___radix2_17; }
	inline BigInteger_t4268922522 ** get_address_of_radix2_17() { return &___radix2_17; }
	inline void set_radix2_17(BigInteger_t4268922522 * value)
	{
		___radix2_17 = value;
		Il2CppCodeGenWriteBarrier(&___radix2_17, value);
	}

	inline static int32_t get_offset_of_radix2E_18() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix2E_18)); }
	inline BigInteger_t4268922522 * get_radix2E_18() const { return ___radix2E_18; }
	inline BigInteger_t4268922522 ** get_address_of_radix2E_18() { return &___radix2E_18; }
	inline void set_radix2E_18(BigInteger_t4268922522 * value)
	{
		___radix2E_18 = value;
		Il2CppCodeGenWriteBarrier(&___radix2E_18, value);
	}

	inline static int32_t get_offset_of_radix8_19() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix8_19)); }
	inline BigInteger_t4268922522 * get_radix8_19() const { return ___radix8_19; }
	inline BigInteger_t4268922522 ** get_address_of_radix8_19() { return &___radix8_19; }
	inline void set_radix8_19(BigInteger_t4268922522 * value)
	{
		___radix8_19 = value;
		Il2CppCodeGenWriteBarrier(&___radix8_19, value);
	}

	inline static int32_t get_offset_of_radix8E_20() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix8E_20)); }
	inline BigInteger_t4268922522 * get_radix8E_20() const { return ___radix8E_20; }
	inline BigInteger_t4268922522 ** get_address_of_radix8E_20() { return &___radix8E_20; }
	inline void set_radix8E_20(BigInteger_t4268922522 * value)
	{
		___radix8E_20 = value;
		Il2CppCodeGenWriteBarrier(&___radix8E_20, value);
	}

	inline static int32_t get_offset_of_radix10_21() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix10_21)); }
	inline BigInteger_t4268922522 * get_radix10_21() const { return ___radix10_21; }
	inline BigInteger_t4268922522 ** get_address_of_radix10_21() { return &___radix10_21; }
	inline void set_radix10_21(BigInteger_t4268922522 * value)
	{
		___radix10_21 = value;
		Il2CppCodeGenWriteBarrier(&___radix10_21, value);
	}

	inline static int32_t get_offset_of_radix10E_22() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix10E_22)); }
	inline BigInteger_t4268922522 * get_radix10E_22() const { return ___radix10E_22; }
	inline BigInteger_t4268922522 ** get_address_of_radix10E_22() { return &___radix10E_22; }
	inline void set_radix10E_22(BigInteger_t4268922522 * value)
	{
		___radix10E_22 = value;
		Il2CppCodeGenWriteBarrier(&___radix10E_22, value);
	}

	inline static int32_t get_offset_of_radix16_23() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix16_23)); }
	inline BigInteger_t4268922522 * get_radix16_23() const { return ___radix16_23; }
	inline BigInteger_t4268922522 ** get_address_of_radix16_23() { return &___radix16_23; }
	inline void set_radix16_23(BigInteger_t4268922522 * value)
	{
		___radix16_23 = value;
		Il2CppCodeGenWriteBarrier(&___radix16_23, value);
	}

	inline static int32_t get_offset_of_radix16E_24() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___radix16E_24)); }
	inline BigInteger_t4268922522 * get_radix16E_24() const { return ___radix16E_24; }
	inline BigInteger_t4268922522 ** get_address_of_radix16E_24() { return &___radix16E_24; }
	inline void set_radix16E_24(BigInteger_t4268922522 * value)
	{
		___radix16E_24 = value;
		Il2CppCodeGenWriteBarrier(&___radix16E_24, value);
	}

	inline static int32_t get_offset_of_RandomSource_25() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___RandomSource_25)); }
	inline Random_t1044426839 * get_RandomSource_25() const { return ___RandomSource_25; }
	inline Random_t1044426839 ** get_address_of_RandomSource_25() { return &___RandomSource_25; }
	inline void set_RandomSource_25(Random_t1044426839 * value)
	{
		___RandomSource_25 = value;
		Il2CppCodeGenWriteBarrier(&___RandomSource_25, value);
	}

	inline static int32_t get_offset_of_ExpWindowThresholds_26() { return static_cast<int32_t>(offsetof(BigInteger_t4268922522_StaticFields, ___ExpWindowThresholds_26)); }
	inline Int32U5BU5D_t3030399641* get_ExpWindowThresholds_26() const { return ___ExpWindowThresholds_26; }
	inline Int32U5BU5D_t3030399641** get_address_of_ExpWindowThresholds_26() { return &___ExpWindowThresholds_26; }
	inline void set_ExpWindowThresholds_26(Int32U5BU5D_t3030399641* value)
	{
		___ExpWindowThresholds_26 = value;
		Il2CppCodeGenWriteBarrier(&___ExpWindowThresholds_26, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
