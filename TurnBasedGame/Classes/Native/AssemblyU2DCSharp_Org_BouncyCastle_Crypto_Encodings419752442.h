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
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Encodings.OaepEncoding
struct  OaepEncoding_t419752442  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Encodings.OaepEncoding::defHash
	ByteU5BU5D_t3397334013* ___defHash_0;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Encodings.OaepEncoding::hash
	Il2CppObject * ___hash_1;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Encodings.OaepEncoding::mgf1Hash
	Il2CppObject * ___mgf1Hash_2;
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Encodings.OaepEncoding::engine
	Il2CppObject * ___engine_3;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Encodings.OaepEncoding::random
	SecureRandom_t3117234712 * ___random_4;
	// System.Boolean Org.BouncyCastle.Crypto.Encodings.OaepEncoding::forEncryption
	bool ___forEncryption_5;

public:
	inline static int32_t get_offset_of_defHash_0() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___defHash_0)); }
	inline ByteU5BU5D_t3397334013* get_defHash_0() const { return ___defHash_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_defHash_0() { return &___defHash_0; }
	inline void set_defHash_0(ByteU5BU5D_t3397334013* value)
	{
		___defHash_0 = value;
		Il2CppCodeGenWriteBarrier(&___defHash_0, value);
	}

	inline static int32_t get_offset_of_hash_1() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___hash_1)); }
	inline Il2CppObject * get_hash_1() const { return ___hash_1; }
	inline Il2CppObject ** get_address_of_hash_1() { return &___hash_1; }
	inline void set_hash_1(Il2CppObject * value)
	{
		___hash_1 = value;
		Il2CppCodeGenWriteBarrier(&___hash_1, value);
	}

	inline static int32_t get_offset_of_mgf1Hash_2() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___mgf1Hash_2)); }
	inline Il2CppObject * get_mgf1Hash_2() const { return ___mgf1Hash_2; }
	inline Il2CppObject ** get_address_of_mgf1Hash_2() { return &___mgf1Hash_2; }
	inline void set_mgf1Hash_2(Il2CppObject * value)
	{
		___mgf1Hash_2 = value;
		Il2CppCodeGenWriteBarrier(&___mgf1Hash_2, value);
	}

	inline static int32_t get_offset_of_engine_3() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___engine_3)); }
	inline Il2CppObject * get_engine_3() const { return ___engine_3; }
	inline Il2CppObject ** get_address_of_engine_3() { return &___engine_3; }
	inline void set_engine_3(Il2CppObject * value)
	{
		___engine_3 = value;
		Il2CppCodeGenWriteBarrier(&___engine_3, value);
	}

	inline static int32_t get_offset_of_random_4() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___random_4)); }
	inline SecureRandom_t3117234712 * get_random_4() const { return ___random_4; }
	inline SecureRandom_t3117234712 ** get_address_of_random_4() { return &___random_4; }
	inline void set_random_4(SecureRandom_t3117234712 * value)
	{
		___random_4 = value;
		Il2CppCodeGenWriteBarrier(&___random_4, value);
	}

	inline static int32_t get_offset_of_forEncryption_5() { return static_cast<int32_t>(offsetof(OaepEncoding_t419752442, ___forEncryption_5)); }
	inline bool get_forEncryption_5() const { return ___forEncryption_5; }
	inline bool* get_address_of_forEncryption_5() { return &___forEncryption_5; }
	inline void set_forEncryption_5(bool value)
	{
		___forEncryption_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
