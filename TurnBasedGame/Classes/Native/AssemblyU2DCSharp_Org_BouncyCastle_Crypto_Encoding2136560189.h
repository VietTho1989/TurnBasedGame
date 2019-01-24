#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Boolean[]
struct BooleanU5BU5D_t3568034315;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding
struct  Pkcs1Encoding_t2136560189  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::random
	SecureRandom_t3117234712 * ___random_3;
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::engine
	Il2CppObject * ___engine_4;
	// System.Boolean Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::forEncryption
	bool ___forEncryption_5;
	// System.Boolean Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::forPrivateKey
	bool ___forPrivateKey_6;
	// System.Boolean Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::useStrictLength
	bool ___useStrictLength_7;
	// System.Int32 Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::pLen
	int32_t ___pLen_8;
	// System.Byte[] Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::fallback
	ByteU5BU5D_t3397334013* ___fallback_9;

public:
	inline static int32_t get_offset_of_random_3() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___random_3)); }
	inline SecureRandom_t3117234712 * get_random_3() const { return ___random_3; }
	inline SecureRandom_t3117234712 ** get_address_of_random_3() { return &___random_3; }
	inline void set_random_3(SecureRandom_t3117234712 * value)
	{
		___random_3 = value;
		Il2CppCodeGenWriteBarrier(&___random_3, value);
	}

	inline static int32_t get_offset_of_engine_4() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___engine_4)); }
	inline Il2CppObject * get_engine_4() const { return ___engine_4; }
	inline Il2CppObject ** get_address_of_engine_4() { return &___engine_4; }
	inline void set_engine_4(Il2CppObject * value)
	{
		___engine_4 = value;
		Il2CppCodeGenWriteBarrier(&___engine_4, value);
	}

	inline static int32_t get_offset_of_forEncryption_5() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___forEncryption_5)); }
	inline bool get_forEncryption_5() const { return ___forEncryption_5; }
	inline bool* get_address_of_forEncryption_5() { return &___forEncryption_5; }
	inline void set_forEncryption_5(bool value)
	{
		___forEncryption_5 = value;
	}

	inline static int32_t get_offset_of_forPrivateKey_6() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___forPrivateKey_6)); }
	inline bool get_forPrivateKey_6() const { return ___forPrivateKey_6; }
	inline bool* get_address_of_forPrivateKey_6() { return &___forPrivateKey_6; }
	inline void set_forPrivateKey_6(bool value)
	{
		___forPrivateKey_6 = value;
	}

	inline static int32_t get_offset_of_useStrictLength_7() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___useStrictLength_7)); }
	inline bool get_useStrictLength_7() const { return ___useStrictLength_7; }
	inline bool* get_address_of_useStrictLength_7() { return &___useStrictLength_7; }
	inline void set_useStrictLength_7(bool value)
	{
		___useStrictLength_7 = value;
	}

	inline static int32_t get_offset_of_pLen_8() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___pLen_8)); }
	inline int32_t get_pLen_8() const { return ___pLen_8; }
	inline int32_t* get_address_of_pLen_8() { return &___pLen_8; }
	inline void set_pLen_8(int32_t value)
	{
		___pLen_8 = value;
	}

	inline static int32_t get_offset_of_fallback_9() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189, ___fallback_9)); }
	inline ByteU5BU5D_t3397334013* get_fallback_9() const { return ___fallback_9; }
	inline ByteU5BU5D_t3397334013** get_address_of_fallback_9() { return &___fallback_9; }
	inline void set_fallback_9(ByteU5BU5D_t3397334013* value)
	{
		___fallback_9 = value;
		Il2CppCodeGenWriteBarrier(&___fallback_9, value);
	}
};

struct Pkcs1Encoding_t2136560189_StaticFields
{
public:
	// System.Boolean[] Org.BouncyCastle.Crypto.Encodings.Pkcs1Encoding::strictLengthEnabled
	BooleanU5BU5D_t3568034315* ___strictLengthEnabled_2;

public:
	inline static int32_t get_offset_of_strictLengthEnabled_2() { return static_cast<int32_t>(offsetof(Pkcs1Encoding_t2136560189_StaticFields, ___strictLengthEnabled_2)); }
	inline BooleanU5BU5D_t3568034315* get_strictLengthEnabled_2() const { return ___strictLengthEnabled_2; }
	inline BooleanU5BU5D_t3568034315** get_address_of_strictLengthEnabled_2() { return &___strictLengthEnabled_2; }
	inline void set_strictLengthEnabled_2(BooleanU5BU5D_t3568034315* value)
	{
		___strictLengthEnabled_2 = value;
		Il2CppCodeGenWriteBarrier(&___strictLengthEnabled_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
