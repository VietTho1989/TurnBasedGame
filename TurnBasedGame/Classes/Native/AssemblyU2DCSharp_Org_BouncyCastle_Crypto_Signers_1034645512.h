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
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer
struct  Iso9796d2Signer_t1034645512  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::digest
	Il2CppObject * ___digest_9;
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::cipher
	Il2CppObject * ___cipher_10;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::trailer
	int32_t ___trailer_11;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::keyBits
	int32_t ___keyBits_12;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::block
	ByteU5BU5D_t3397334013* ___block_13;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::mBuf
	ByteU5BU5D_t3397334013* ___mBuf_14;
	// System.Int32 Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::messageLength
	int32_t ___messageLength_15;
	// System.Boolean Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::fullMessage
	bool ___fullMessage_16;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::recoveredMessage
	ByteU5BU5D_t3397334013* ___recoveredMessage_17;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::preSig
	ByteU5BU5D_t3397334013* ___preSig_18;
	// System.Byte[] Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::preBlock
	ByteU5BU5D_t3397334013* ___preBlock_19;

public:
	inline static int32_t get_offset_of_digest_9() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___digest_9)); }
	inline Il2CppObject * get_digest_9() const { return ___digest_9; }
	inline Il2CppObject ** get_address_of_digest_9() { return &___digest_9; }
	inline void set_digest_9(Il2CppObject * value)
	{
		___digest_9 = value;
		Il2CppCodeGenWriteBarrier(&___digest_9, value);
	}

	inline static int32_t get_offset_of_cipher_10() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___cipher_10)); }
	inline Il2CppObject * get_cipher_10() const { return ___cipher_10; }
	inline Il2CppObject ** get_address_of_cipher_10() { return &___cipher_10; }
	inline void set_cipher_10(Il2CppObject * value)
	{
		___cipher_10 = value;
		Il2CppCodeGenWriteBarrier(&___cipher_10, value);
	}

	inline static int32_t get_offset_of_trailer_11() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___trailer_11)); }
	inline int32_t get_trailer_11() const { return ___trailer_11; }
	inline int32_t* get_address_of_trailer_11() { return &___trailer_11; }
	inline void set_trailer_11(int32_t value)
	{
		___trailer_11 = value;
	}

	inline static int32_t get_offset_of_keyBits_12() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___keyBits_12)); }
	inline int32_t get_keyBits_12() const { return ___keyBits_12; }
	inline int32_t* get_address_of_keyBits_12() { return &___keyBits_12; }
	inline void set_keyBits_12(int32_t value)
	{
		___keyBits_12 = value;
	}

	inline static int32_t get_offset_of_block_13() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___block_13)); }
	inline ByteU5BU5D_t3397334013* get_block_13() const { return ___block_13; }
	inline ByteU5BU5D_t3397334013** get_address_of_block_13() { return &___block_13; }
	inline void set_block_13(ByteU5BU5D_t3397334013* value)
	{
		___block_13 = value;
		Il2CppCodeGenWriteBarrier(&___block_13, value);
	}

	inline static int32_t get_offset_of_mBuf_14() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___mBuf_14)); }
	inline ByteU5BU5D_t3397334013* get_mBuf_14() const { return ___mBuf_14; }
	inline ByteU5BU5D_t3397334013** get_address_of_mBuf_14() { return &___mBuf_14; }
	inline void set_mBuf_14(ByteU5BU5D_t3397334013* value)
	{
		___mBuf_14 = value;
		Il2CppCodeGenWriteBarrier(&___mBuf_14, value);
	}

	inline static int32_t get_offset_of_messageLength_15() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___messageLength_15)); }
	inline int32_t get_messageLength_15() const { return ___messageLength_15; }
	inline int32_t* get_address_of_messageLength_15() { return &___messageLength_15; }
	inline void set_messageLength_15(int32_t value)
	{
		___messageLength_15 = value;
	}

	inline static int32_t get_offset_of_fullMessage_16() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___fullMessage_16)); }
	inline bool get_fullMessage_16() const { return ___fullMessage_16; }
	inline bool* get_address_of_fullMessage_16() { return &___fullMessage_16; }
	inline void set_fullMessage_16(bool value)
	{
		___fullMessage_16 = value;
	}

	inline static int32_t get_offset_of_recoveredMessage_17() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___recoveredMessage_17)); }
	inline ByteU5BU5D_t3397334013* get_recoveredMessage_17() const { return ___recoveredMessage_17; }
	inline ByteU5BU5D_t3397334013** get_address_of_recoveredMessage_17() { return &___recoveredMessage_17; }
	inline void set_recoveredMessage_17(ByteU5BU5D_t3397334013* value)
	{
		___recoveredMessage_17 = value;
		Il2CppCodeGenWriteBarrier(&___recoveredMessage_17, value);
	}

	inline static int32_t get_offset_of_preSig_18() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___preSig_18)); }
	inline ByteU5BU5D_t3397334013* get_preSig_18() const { return ___preSig_18; }
	inline ByteU5BU5D_t3397334013** get_address_of_preSig_18() { return &___preSig_18; }
	inline void set_preSig_18(ByteU5BU5D_t3397334013* value)
	{
		___preSig_18 = value;
		Il2CppCodeGenWriteBarrier(&___preSig_18, value);
	}

	inline static int32_t get_offset_of_preBlock_19() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512, ___preBlock_19)); }
	inline ByteU5BU5D_t3397334013* get_preBlock_19() const { return ___preBlock_19; }
	inline ByteU5BU5D_t3397334013** get_address_of_preBlock_19() { return &___preBlock_19; }
	inline void set_preBlock_19(ByteU5BU5D_t3397334013* value)
	{
		___preBlock_19 = value;
		Il2CppCodeGenWriteBarrier(&___preBlock_19, value);
	}
};

struct Iso9796d2Signer_t1034645512_StaticFields
{
public:
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer::trailerMap
	Il2CppObject * ___trailerMap_8;

public:
	inline static int32_t get_offset_of_trailerMap_8() { return static_cast<int32_t>(offsetof(Iso9796d2Signer_t1034645512_StaticFields, ___trailerMap_8)); }
	inline Il2CppObject * get_trailerMap_8() const { return ___trailerMap_8; }
	inline Il2CppObject ** get_address_of_trailerMap_8() { return &___trailerMap_8; }
	inline void set_trailerMap_8(Il2CppObject * value)
	{
		___trailerMap_8 = value;
		Il2CppCodeGenWriteBarrier(&___trailerMap_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
