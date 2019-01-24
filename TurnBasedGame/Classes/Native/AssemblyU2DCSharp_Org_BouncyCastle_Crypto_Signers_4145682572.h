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
// Org.BouncyCastle.Crypto.IDsa
struct IDsa_t2214093627;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Signers.DsaDigestSigner
struct  DsaDigestSigner_t4145682572  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Signers.DsaDigestSigner::digest
	Il2CppObject * ___digest_0;
	// Org.BouncyCastle.Crypto.IDsa Org.BouncyCastle.Crypto.Signers.DsaDigestSigner::dsaSigner
	Il2CppObject * ___dsaSigner_1;
	// System.Boolean Org.BouncyCastle.Crypto.Signers.DsaDigestSigner::forSigning
	bool ___forSigning_2;

public:
	inline static int32_t get_offset_of_digest_0() { return static_cast<int32_t>(offsetof(DsaDigestSigner_t4145682572, ___digest_0)); }
	inline Il2CppObject * get_digest_0() const { return ___digest_0; }
	inline Il2CppObject ** get_address_of_digest_0() { return &___digest_0; }
	inline void set_digest_0(Il2CppObject * value)
	{
		___digest_0 = value;
		Il2CppCodeGenWriteBarrier(&___digest_0, value);
	}

	inline static int32_t get_offset_of_dsaSigner_1() { return static_cast<int32_t>(offsetof(DsaDigestSigner_t4145682572, ___dsaSigner_1)); }
	inline Il2CppObject * get_dsaSigner_1() const { return ___dsaSigner_1; }
	inline Il2CppObject ** get_address_of_dsaSigner_1() { return &___dsaSigner_1; }
	inline void set_dsaSigner_1(Il2CppObject * value)
	{
		___dsaSigner_1 = value;
		Il2CppCodeGenWriteBarrier(&___dsaSigner_1, value);
	}

	inline static int32_t get_offset_of_forSigning_2() { return static_cast<int32_t>(offsetof(DsaDigestSigner_t4145682572, ___forSigning_2)); }
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
