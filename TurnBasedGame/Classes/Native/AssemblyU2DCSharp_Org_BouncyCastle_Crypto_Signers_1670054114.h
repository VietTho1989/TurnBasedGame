#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// Org.BouncyCastle.Security.SecureRandom
struct SecureRandom_t3117234712;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.PssSigner
struct  PssSigner_t1670054114  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.PssSigner::contentDigest1
	Il2CppObject * ___contentDigest1_1;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.PssSigner::contentDigest2
	Il2CppObject * ___contentDigest2_2;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.PssSigner::mgfDigest
	Il2CppObject * ___mgfDigest_3;
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Signers.PssSigner::cipher
	Il2CppObject * ___cipher_4;
	// Org.BouncyCastle.Security.SecureRandom Org.BouncyCastle.Crypto.Signers.PssSigner::random
	SecureRandom_t3117234712 * ___random_5;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.PssSigner::hLen
	int32_t ___hLen_6;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.PssSigner::mgfhLen
	int32_t ___mgfhLen_7;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.PssSigner::sLen
	int32_t ___sLen_8;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.PssSigner::emBits
	int32_t ___emBits_9;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.PssSigner::salt
	ByteU5BU5D_t3397334013* ___salt_10;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.PssSigner::mDash
	ByteU5BU5D_t3397334013* ___mDash_11;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.PssSigner::block
	ByteU5BU5D_t3397334013* ___block_12;
	// System.Byte Org.BouncyCastle.Crypto.Signers.PssSigner::trailer
	uint8_t ___trailer_13;

public:
	inline static int32_t get_offset_of_contentDigest1_1() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___contentDigest1_1)); }
	inline Il2CppObject * get_contentDigest1_1() const { return ___contentDigest1_1; }
	inline Il2CppObject ** get_address_of_contentDigest1_1() { return &___contentDigest1_1; }
	inline void set_contentDigest1_1(Il2CppObject * value)
	{
		___contentDigest1_1 = value;
		Il2CppCodeGenWriteBarrier(&___contentDigest1_1, value);
	}

	inline static int32_t get_offset_of_contentDigest2_2() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___contentDigest2_2)); }
	inline Il2CppObject * get_contentDigest2_2() const { return ___contentDigest2_2; }
	inline Il2CppObject ** get_address_of_contentDigest2_2() { return &___contentDigest2_2; }
	inline void set_contentDigest2_2(Il2CppObject * value)
	{
		___contentDigest2_2 = value;
		Il2CppCodeGenWriteBarrier(&___contentDigest2_2, value);
	}

	inline static int32_t get_offset_of_mgfDigest_3() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___mgfDigest_3)); }
	inline Il2CppObject * get_mgfDigest_3() const { return ___mgfDigest_3; }
	inline Il2CppObject ** get_address_of_mgfDigest_3() { return &___mgfDigest_3; }
	inline void set_mgfDigest_3(Il2CppObject * value)
	{
		___mgfDigest_3 = value;
		Il2CppCodeGenWriteBarrier(&___mgfDigest_3, value);
	}

	inline static int32_t get_offset_of_cipher_4() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___cipher_4)); }
	inline Il2CppObject * get_cipher_4() const { return ___cipher_4; }
	inline Il2CppObject ** get_address_of_cipher_4() { return &___cipher_4; }
	inline void set_cipher_4(Il2CppObject * value)
	{
		___cipher_4 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_4, value);
	}

	inline static int32_t get_offset_of_random_5() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___random_5)); }
	inline SecureRandom_t3117234712 * get_random_5() const { return ___random_5; }
	inline SecureRandom_t3117234712 ** get_address_of_random_5() { return &___random_5; }
	inline void set_random_5(SecureRandom_t3117234712 * value)
	{
		___random_5 = value;
		Il2CppCodeGenWriteBarrier(&___random_5, value);
	}

	inline static int32_t get_offset_of_hLen_6() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___hLen_6)); }
	inline int32_t get_hLen_6() const { return ___hLen_6; }
	inline int32_t* get_address_of_hLen_6() { return &___hLen_6; }
	inline void set_hLen_6(int32_t value)
	{
		___hLen_6 = value;
	}

	inline static int32_t get_offset_of_mgfhLen_7() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___mgfhLen_7)); }
	inline int32_t get_mgfhLen_7() const { return ___mgfhLen_7; }
	inline int32_t* get_address_of_mgfhLen_7() { return &___mgfhLen_7; }
	inline void set_mgfhLen_7(int32_t value)
	{
		___mgfhLen_7 = value;
	}

	inline static int32_t get_offset_of_sLen_8() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___sLen_8)); }
	inline int32_t get_sLen_8() const { return ___sLen_8; }
	inline int32_t* get_address_of_sLen_8() { return &___sLen_8; }
	inline void set_sLen_8(int32_t value)
	{
		___sLen_8 = value;
	}

	inline static int32_t get_offset_of_emBits_9() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___emBits_9)); }
	inline int32_t get_emBits_9() const { return ___emBits_9; }
	inline int32_t* get_address_of_emBits_9() { return &___emBits_9; }
	inline void set_emBits_9(int32_t value)
	{
		___emBits_9 = value;
	}

	inline static int32_t get_offset_of_salt_10() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___salt_10)); }
	inline ByteU5BU5D_t3397334013* get_salt_10() const { return ___salt_10; }
	inline ByteU5BU5D_t3397334013** get_address_of_salt_10() { return &___salt_10; }
	inline void set_salt_10(ByteU5BU5D_t3397334013* value)
	{
		___salt_10 = value;
		Il2CppCodeGenWriteBarrier(&___salt_10, value);
	}

	inline static int32_t get_offset_of_mDash_11() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___mDash_11)); }
	inline ByteU5BU5D_t3397334013* get_mDash_11() const { return ___mDash_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_mDash_11() { return &___mDash_11; }
	inline void set_mDash_11(ByteU5BU5D_t3397334013* value)
	{
		___mDash_11 = value;
		Il2CppCodeGenWriteBarrier(&___mDash_11, value);
	}

	inline static int32_t get_offset_of_block_12() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___block_12)); }
	inline ByteU5BU5D_t3397334013* get_block_12() const { return ___block_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_block_12() { return &___block_12; }
	inline void set_block_12(ByteU5BU5D_t3397334013* value)
	{
		___block_12 = value;
		Il2CppCodeGenWriteBarrier(&___block_12, value);
	}

	inline static int32_t get_offset_of_trailer_13() { return static_cast<int32_t>(offsetof(PssSigner_t1670054114, ___trailer_13)); }
	inline uint8_t get_trailer_13() const { return ___trailer_13; }
	inline uint8_t* get_address_of_trailer_13() { return &___trailer_13; }
	inline void set_trailer_13(uint8_t value)
	{
		___trailer_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
