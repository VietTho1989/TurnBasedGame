#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.BigInteger
struct BigInteger_t4268922522;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding
struct  ISO9796d1Encoding_t408740108  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::engine
	Il2CppObject * ___engine_4;
	// System.Boolean Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::forEncryption
	bool ___forEncryption_5;
	// System.Int32 Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::bitSize
	int32_t ___bitSize_6;
	// System.Int32 Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::padBits
	int32_t ___padBits_7;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::modulus
	BigInteger_t4268922522 * ___modulus_8;

public:
	inline static int32_t get_offset_of_engine_4() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108, ___engine_4)); }
	inline Il2CppObject * get_engine_4() const { return ___engine_4; }
	inline Il2CppObject ** get_address_of_engine_4() { return &___engine_4; }
	inline void set_engine_4(Il2CppObject * value)
	{
		___engine_4 = value;
		Il2CppCodeGenWriteBarrier(&___engine_4, value);
	}

	inline static int32_t get_offset_of_forEncryption_5() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108, ___forEncryption_5)); }
	inline bool get_forEncryption_5() const { return ___forEncryption_5; }
	inline bool* get_address_of_forEncryption_5() { return &___forEncryption_5; }
	inline void set_forEncryption_5(bool value)
	{
		___forEncryption_5 = value;
	}

	inline static int32_t get_offset_of_bitSize_6() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108, ___bitSize_6)); }
	inline int32_t get_bitSize_6() const { return ___bitSize_6; }
	inline int32_t* get_address_of_bitSize_6() { return &___bitSize_6; }
	inline void set_bitSize_6(int32_t value)
	{
		___bitSize_6 = value;
	}

	inline static int32_t get_offset_of_padBits_7() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108, ___padBits_7)); }
	inline int32_t get_padBits_7() const { return ___padBits_7; }
	inline int32_t* get_address_of_padBits_7() { return &___padBits_7; }
	inline void set_padBits_7(int32_t value)
	{
		___padBits_7 = value;
	}

	inline static int32_t get_offset_of_modulus_8() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108, ___modulus_8)); }
	inline BigInteger_t4268922522 * get_modulus_8() const { return ___modulus_8; }
	inline BigInteger_t4268922522 ** get_address_of_modulus_8() { return &___modulus_8; }
	inline void set_modulus_8(BigInteger_t4268922522 * value)
	{
		___modulus_8 = value;
		Il2CppCodeGenWriteBarrier(&___modulus_8, value);
	}
};

struct ISO9796d1Encoding_t408740108_StaticFields
{
public:
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::Sixteen
	BigInteger_t4268922522 * ___Sixteen_0;
	// Org.BouncyCastle.Math.BigInteger Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::Six
	BigInteger_t4268922522 * ___Six_1;
	// System.Byte[] Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::shadows
	ByteU5BU5D_t3397334013* ___shadows_2;
	// System.Byte[] Org.BouncyCastle.Crypto.Encodings.ISO9796d1Encoding::inverse
	ByteU5BU5D_t3397334013* ___inverse_3;

public:
	inline static int32_t get_offset_of_Sixteen_0() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108_StaticFields, ___Sixteen_0)); }
	inline BigInteger_t4268922522 * get_Sixteen_0() const { return ___Sixteen_0; }
	inline BigInteger_t4268922522 ** get_address_of_Sixteen_0() { return &___Sixteen_0; }
	inline void set_Sixteen_0(BigInteger_t4268922522 * value)
	{
		___Sixteen_0 = value;
		Il2CppCodeGenWriteBarrier(&___Sixteen_0, value);
	}

	inline static int32_t get_offset_of_Six_1() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108_StaticFields, ___Six_1)); }
	inline BigInteger_t4268922522 * get_Six_1() const { return ___Six_1; }
	inline BigInteger_t4268922522 ** get_address_of_Six_1() { return &___Six_1; }
	inline void set_Six_1(BigInteger_t4268922522 * value)
	{
		___Six_1 = value;
		Il2CppCodeGenWriteBarrier(&___Six_1, value);
	}

	inline static int32_t get_offset_of_shadows_2() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108_StaticFields, ___shadows_2)); }
	inline ByteU5BU5D_t3397334013* get_shadows_2() const { return ___shadows_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_shadows_2() { return &___shadows_2; }
	inline void set_shadows_2(ByteU5BU5D_t3397334013* value)
	{
		___shadows_2 = value;
		Il2CppCodeGenWriteBarrier(&___shadows_2, value);
	}

	inline static int32_t get_offset_of_inverse_3() { return static_cast<int32_t>(offsetof(ISO9796d1Encoding_t408740108_StaticFields, ___inverse_3)); }
	inline ByteU5BU5D_t3397334013* get_inverse_3() const { return ___inverse_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_inverse_3() { return &___inverse_3; }
	inline void set_inverse_3(ByteU5BU5D_t3397334013* value)
	{
		___inverse_3 = value;
		Il2CppCodeGenWriteBarrier(&___inverse_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
