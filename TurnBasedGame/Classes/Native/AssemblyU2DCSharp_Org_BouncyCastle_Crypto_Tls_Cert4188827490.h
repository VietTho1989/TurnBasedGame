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
// System.Collections.IList
struct IList_t3321498491;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.CertificateRequest
struct  CertificateRequest_t4188827490  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Crypto.Tls.CertificateRequest::mCertificateTypes
	ByteU5BU5D_t3397334013* ___mCertificateTypes_0;
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.CertificateRequest::mSupportedSignatureAlgorithms
	Il2CppObject * ___mSupportedSignatureAlgorithms_1;
	// System.Collections.IList Org.BouncyCastle.Crypto.Tls.CertificateRequest::mCertificateAuthorities
	Il2CppObject * ___mCertificateAuthorities_2;

public:
	inline static int32_t get_offset_of_mCertificateTypes_0() { return static_cast<int32_t>(offsetof(CertificateRequest_t4188827490, ___mCertificateTypes_0)); }
	inline ByteU5BU5D_t3397334013* get_mCertificateTypes_0() const { return ___mCertificateTypes_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_mCertificateTypes_0() { return &___mCertificateTypes_0; }
	inline void set_mCertificateTypes_0(ByteU5BU5D_t3397334013* value)
	{
		___mCertificateTypes_0 = value;
		Il2CppCodeGenWriteBarrier(&___mCertificateTypes_0, value);
	}

	inline static int32_t get_offset_of_mSupportedSignatureAlgorithms_1() { return static_cast<int32_t>(offsetof(CertificateRequest_t4188827490, ___mSupportedSignatureAlgorithms_1)); }
	inline Il2CppObject * get_mSupportedSignatureAlgorithms_1() const { return ___mSupportedSignatureAlgorithms_1; }
	inline Il2CppObject ** get_address_of_mSupportedSignatureAlgorithms_1() { return &___mSupportedSignatureAlgorithms_1; }
	inline void set_mSupportedSignatureAlgorithms_1(Il2CppObject * value)
	{
		___mSupportedSignatureAlgorithms_1 = value;
		Il2CppCodeGenWriteBarrier(&___mSupportedSignatureAlgorithms_1, value);
	}

	inline static int32_t get_offset_of_mCertificateAuthorities_2() { return static_cast<int32_t>(offsetof(CertificateRequest_t4188827490, ___mCertificateAuthorities_2)); }
	inline Il2CppObject * get_mCertificateAuthorities_2() const { return ___mCertificateAuthorities_2; }
	inline Il2CppObject ** get_address_of_mCertificateAuthorities_2() { return &___mCertificateAuthorities_2; }
	inline void set_mCertificateAuthorities_2(Il2CppObject * value)
	{
		___mCertificateAuthorities_2 = value;
		Il2CppCodeGenWriteBarrier(&___mCertificateAuthorities_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
