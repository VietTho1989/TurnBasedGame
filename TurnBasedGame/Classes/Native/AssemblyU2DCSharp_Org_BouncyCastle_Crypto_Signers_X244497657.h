#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IDictionary
struct IDictionary_t596158605;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
struct RsaKeyParameters_t3425534311;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.X931Signer
struct  X931Signer_t244497657  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.X931Signer::digest
	Il2CppObject * ___digest_10;
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Signers.X931Signer::cipher
	Il2CppObject * ___cipher_11;
	// Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters Org.BouncyCastle.Crypto.Signers.X931Signer::kParam
	RsaKeyParameters_t3425534311 * ___kParam_12;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.X931Signer::trailer
	int32_t ___trailer_13;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.X931Signer::keyBits
	int32_t ___keyBits_14;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.X931Signer::block
	ByteU5BU5D_t3397334013* ___block_15;

public:
	inline static int32_t get_offset_of_digest_10() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___digest_10)); }
	inline Il2CppObject * get_digest_10() const { return ___digest_10; }
	inline Il2CppObject ** get_address_of_digest_10() { return &___digest_10; }
	inline void set_digest_10(Il2CppObject * value)
	{
		___digest_10 = value;
		Il2CppCodeGenWriteBarrier(&___digest_10, value);
	}

	inline static int32_t get_offset_of_cipher_11() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___cipher_11)); }
	inline Il2CppObject * get_cipher_11() const { return ___cipher_11; }
	inline Il2CppObject ** get_address_of_cipher_11() { return &___cipher_11; }
	inline void set_cipher_11(Il2CppObject * value)
	{
		___cipher_11 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_11, value);
	}

	inline static int32_t get_offset_of_kParam_12() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___kParam_12)); }
	inline RsaKeyParameters_t3425534311 * get_kParam_12() const { return ___kParam_12; }
	inline RsaKeyParameters_t3425534311 ** get_address_of_kParam_12() { return &___kParam_12; }
	inline void set_kParam_12(RsaKeyParameters_t3425534311 * value)
	{
		___kParam_12 = value;
		Il2CppCodeGenWriteBarrier(&___kParam_12, value);
	}

	inline static int32_t get_offset_of_trailer_13() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___trailer_13)); }
	inline int32_t get_trailer_13() const { return ___trailer_13; }
	inline int32_t* get_address_of_trailer_13() { return &___trailer_13; }
	inline void set_trailer_13(int32_t value)
	{
		___trailer_13 = value;
	}

	inline static int32_t get_offset_of_keyBits_14() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___keyBits_14)); }
	inline int32_t get_keyBits_14() const { return ___keyBits_14; }
	inline int32_t* get_address_of_keyBits_14() { return &___keyBits_14; }
	inline void set_keyBits_14(int32_t value)
	{
		___keyBits_14 = value;
	}

	inline static int32_t get_offset_of_block_15() { return static_cast<int32_t>(offsetof(X931Signer_t244497657, ___block_15)); }
	inline ByteU5BU5D_t3397334013* get_block_15() const { return ___block_15; }
	inline ByteU5BU5D_t3397334013** get_address_of_block_15() { return &___block_15; }
	inline void set_block_15(ByteU5BU5D_t3397334013* value)
	{
		___block_15 = value;
		Il2CppCodeGenWriteBarrier(&___block_15, value);
	}
};

struct X931Signer_t244497657_StaticFields
{
public:
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Signers.X931Signer::trailerMap
	Il2CppObject * ___trailerMap_9;

public:
	inline static int32_t get_offset_of_trailerMap_9() { return static_cast<int32_t>(offsetof(X931Signer_t244497657_StaticFields, ___trailerMap_9)); }
	inline Il2CppObject * get_trailerMap_9() const { return ___trailerMap_9; }
	inline Il2CppObject ** get_address_of_trailerMap_9() { return &___trailerMap_9; }
	inline void set_trailerMap_9(Il2CppObject * value)
	{
		___trailerMap_9 = value;
		Il2CppCodeGenWriteBarrier(&___trailerMap_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
