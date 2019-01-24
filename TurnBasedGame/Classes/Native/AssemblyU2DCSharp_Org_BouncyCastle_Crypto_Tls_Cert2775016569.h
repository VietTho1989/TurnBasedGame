#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.Certificate
struct Certificate_t2775016569;
// Org.BouncyCastle.Asn1.X509.X509CertificateStructure[]
struct X509CertificateStructureU5BU5D_t3012599515;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.Certificate
struct  Certificate_t2775016569  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.X509.X509CertificateStructure[] Org.BouncyCastle.Crypto.Tls.Certificate::mCertificateList
	X509CertificateStructureU5BU5D_t3012599515* ___mCertificateList_1;

public:
	inline static int32_t get_offset_of_mCertificateList_1() { return static_cast<int32_t>(offsetof(Certificate_t2775016569, ___mCertificateList_1)); }
	inline X509CertificateStructureU5BU5D_t3012599515* get_mCertificateList_1() const { return ___mCertificateList_1; }
	inline X509CertificateStructureU5BU5D_t3012599515** get_address_of_mCertificateList_1() { return &___mCertificateList_1; }
	inline void set_mCertificateList_1(X509CertificateStructureU5BU5D_t3012599515* value)
	{
		___mCertificateList_1 = value;
		Il2CppCodeGenWriteBarrier(&___mCertificateList_1, value);
	}
};

struct Certificate_t2775016569_StaticFields
{
public:
	// Org.BouncyCastle.Crypto.Tls.Certificate Org.BouncyCastle.Crypto.Tls.Certificate::EmptyChain
	Certificate_t2775016569 * ___EmptyChain_0;

public:
	inline static int32_t get_offset_of_EmptyChain_0() { return static_cast<int32_t>(offsetof(Certificate_t2775016569_StaticFields, ___EmptyChain_0)); }
	inline Certificate_t2775016569 * get_EmptyChain_0() const { return ___EmptyChain_0; }
	inline Certificate_t2775016569 ** get_address_of_EmptyChain_0() { return &___EmptyChain_0; }
	inline void set_EmptyChain_0(Certificate_t2775016569 * value)
	{
		___EmptyChain_0 = value;
		Il2CppCodeGenWriteBarrier(&___EmptyChain_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
