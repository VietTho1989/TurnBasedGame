#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher
struct IAsymmetricBlockCipher_t1189117395;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.GenericSigner
struct  GenericSigner_t601621931  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Signers.GenericSigner::engine
	Il2CppObject * ___engine_0;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.GenericSigner::digest
	Il2CppObject * ___digest_1;
	// System.Boolean Org.BouncyCastle.Crypto.Signers.GenericSigner::forSigning
	bool ___forSigning_2;

public:
	inline static int32_t get_offset_of_engine_0() { return static_cast<int32_t>(offsetof(GenericSigner_t601621931, ___engine_0)); }
	inline Il2CppObject * get_engine_0() const { return ___engine_0; }
	inline Il2CppObject ** get_address_of_engine_0() { return &___engine_0; }
	inline void set_engine_0(Il2CppObject * value)
	{
		___engine_0 = value;
		Il2CppCodeGenWriteBarrier(&___engine_0, value);
	}

	inline static int32_t get_offset_of_digest_1() { return static_cast<int32_t>(offsetof(GenericSigner_t601621931, ___digest_1)); }
	inline Il2CppObject * get_digest_1() const { return ___digest_1; }
	inline Il2CppObject ** get_address_of_digest_1() { return &___digest_1; }
	inline void set_digest_1(Il2CppObject * value)
	{
		___digest_1 = value;
		Il2CppCodeGenWriteBarrier(&___digest_1, value);
	}

	inline static int32_t get_offset_of_forSigning_2() { return static_cast<int32_t>(offsetof(GenericSigner_t601621931, ___forSigning_2)); }
	inline bool get_forSigning_2() const { return ___forSigning_2; }
	inline bool* get_address_of_forSigning_2() { return &___forSigning_2; }
	inline void set_forSigning_2(bool value)
	{
		___forSigning_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
