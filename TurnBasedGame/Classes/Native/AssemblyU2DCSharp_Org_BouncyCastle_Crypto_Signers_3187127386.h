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
// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;
// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// System.Collections.IDictionary
struct IDictionary_t596158605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.RsaDigestSigner
struct  RsaDigestSigner_t3187127386  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IAsymmetricBlockCipher Org.BouncyCastle.Crypto.Signers.RsaDigestSigner::rsaEngine
	Il2CppObject * ___rsaEngine_0;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Crypto.Signers.RsaDigestSigner::algId
	AlgorithmIdentifier_t2670781410 * ___algId_1;
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.RsaDigestSigner::digest
	Il2CppObject * ___digest_2;
	// System.Boolean Org.BouncyCastle.Crypto.Signers.RsaDigestSigner::forSigning
	bool ___forSigning_3;

public:
	inline static int32_t get_offset_of_rsaEngine_0() { return static_cast<int32_t>(offsetof(RsaDigestSigner_t3187127386, ___rsaEngine_0)); }
	inline Il2CppObject * get_rsaEngine_0() const { return ___rsaEngine_0; }
	inline Il2CppObject ** get_address_of_rsaEngine_0() { return &___rsaEngine_0; }
	inline void set_rsaEngine_0(Il2CppObject * value)
	{
		___rsaEngine_0 = value;
		Il2CppCodeGenWriteBarrier(&___rsaEngine_0, value);
	}

	inline static int32_t get_offset_of_algId_1() { return static_cast<int32_t>(offsetof(RsaDigestSigner_t3187127386, ___algId_1)); }
	inline AlgorithmIdentifier_t2670781410 * get_algId_1() const { return ___algId_1; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_algId_1() { return &___algId_1; }
	inline void set_algId_1(AlgorithmIdentifier_t2670781410 * value)
	{
		___algId_1 = value;
		Il2CppCodeGenWriteBarrier(&___algId_1, value);
	}

	inline static int32_t get_offset_of_digest_2() { return static_cast<int32_t>(offsetof(RsaDigestSigner_t3187127386, ___digest_2)); }
	inline Il2CppObject * get_digest_2() const { return ___digest_2; }
	inline Il2CppObject ** get_address_of_digest_2() { return &___digest_2; }
	inline void set_digest_2(Il2CppObject * value)
	{
		___digest_2 = value;
		Il2CppCodeGenWriteBarrier(&___digest_2, value);
	}

	inline static int32_t get_offset_of_forSigning_3() { return static_cast<int32_t>(offsetof(RsaDigestSigner_t3187127386, ___forSigning_3)); }
	inline bool get_forSigning_3() const { return ___forSigning_3; }
	inline bool* get_address_of_forSigning_3() { return &___forSigning_3; }
	inline void set_forSigning_3(bool value)
	{
		___forSigning_3 = value;
	}
};

struct RsaDigestSigner_t3187127386_StaticFields
{
public:
	// System.Collections.IDictionary Org.BouncyCastle.Crypto.Signers.RsaDigestSigner::oidMap
	Il2CppObject * ___oidMap_4;

public:
	inline static int32_t get_offset_of_oidMap_4() { return static_cast<int32_t>(offsetof(RsaDigestSigner_t3187127386_StaticFields, ___oidMap_4)); }
	inline Il2CppObject * get_oidMap_4() const { return ___oidMap_4; }
	inline Il2CppObject ** get_address_of_oidMap_4() { return &___oidMap_4; }
	inline void set_oidMap_4(Il2CppObject * value)
	{
		___oidMap_4 = value;
		Il2CppCodeGenWriteBarrier(&___oidMap_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
