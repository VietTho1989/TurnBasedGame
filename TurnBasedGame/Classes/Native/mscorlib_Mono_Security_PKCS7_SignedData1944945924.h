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
// Mono.Security.PKCS7/ContentInfo
struct ContentInfo_t1443605387;
// Mono.Security.X509.X509CertificateCollection
struct X509CertificateCollection_t3592472865;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// Mono.Security.PKCS7/SignerInfo
struct SignerInfo_t1683925522;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.PKCS7/SignedData
struct  SignedData_t1944945924  : public Il2CppObject
{
public:
	// System.Byte Mono.Security.PKCS7/SignedData::version
	uint8_t ___version_0;
	// System.String Mono.Security.PKCS7/SignedData::hashAlgorithm
	String_t* ___hashAlgorithm_1;
	// Mono.Security.PKCS7/ContentInfo Mono.Security.PKCS7/SignedData::contentInfo
	ContentInfo_t1443605387 * ___contentInfo_2;
	// Mono.Security.X509.X509CertificateCollection Mono.Security.PKCS7/SignedData::certs
	X509CertificateCollection_t3592472865 * ___certs_3;
	// System.Collections.ArrayList Mono.Security.PKCS7/SignedData::crls
	ArrayList_t4252133567 * ___crls_4;
	// Mono.Security.PKCS7/SignerInfo Mono.Security.PKCS7/SignedData::signerInfo
	SignerInfo_t1683925522 * ___signerInfo_5;
	// System.Boolean Mono.Security.PKCS7/SignedData::mda
	bool ___mda_6;

public:
	inline static int32_t get_offset_of_version_0() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___version_0)); }
	inline uint8_t get_version_0() const { return ___version_0; }
	inline uint8_t* get_address_of_version_0() { return &___version_0; }
	inline void set_version_0(uint8_t value)
	{
		___version_0 = value;
	}

	inline static int32_t get_offset_of_hashAlgorithm_1() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___hashAlgorithm_1)); }
	inline String_t* get_hashAlgorithm_1() const { return ___hashAlgorithm_1; }
	inline String_t** get_address_of_hashAlgorithm_1() { return &___hashAlgorithm_1; }
	inline void set_hashAlgorithm_1(String_t* value)
	{
		___hashAlgorithm_1 = value;
		Il2CppCodeGenWriteBarrier(&___hashAlgorithm_1, value);
	}

	inline static int32_t get_offset_of_contentInfo_2() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___contentInfo_2)); }
	inline ContentInfo_t1443605387 * get_contentInfo_2() const { return ___contentInfo_2; }
	inline ContentInfo_t1443605387 ** get_address_of_contentInfo_2() { return &___contentInfo_2; }
	inline void set_contentInfo_2(ContentInfo_t1443605387 * value)
	{
		___contentInfo_2 = value;
		Il2CppCodeGenWriteBarrier(&___contentInfo_2, value);
	}

	inline static int32_t get_offset_of_certs_3() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___certs_3)); }
	inline X509CertificateCollection_t3592472865 * get_certs_3() const { return ___certs_3; }
	inline X509CertificateCollection_t3592472865 ** get_address_of_certs_3() { return &___certs_3; }
	inline void set_certs_3(X509CertificateCollection_t3592472865 * value)
	{
		___certs_3 = value;
		Il2CppCodeGenWriteBarrier(&___certs_3, value);
	}

	inline static int32_t get_offset_of_crls_4() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___crls_4)); }
	inline ArrayList_t4252133567 * get_crls_4() const { return ___crls_4; }
	inline ArrayList_t4252133567 ** get_address_of_crls_4() { return &___crls_4; }
	inline void set_crls_4(ArrayList_t4252133567 * value)
	{
		___crls_4 = value;
		Il2CppCodeGenWriteBarrier(&___crls_4, value);
	}

	inline static int32_t get_offset_of_signerInfo_5() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___signerInfo_5)); }
	inline SignerInfo_t1683925522 * get_signerInfo_5() const { return ___signerInfo_5; }
	inline SignerInfo_t1683925522 ** get_address_of_signerInfo_5() { return &___signerInfo_5; }
	inline void set_signerInfo_5(SignerInfo_t1683925522 * value)
	{
		___signerInfo_5 = value;
		Il2CppCodeGenWriteBarrier(&___signerInfo_5, value);
	}

	inline static int32_t get_offset_of_mda_6() { return static_cast<int32_t>(offsetof(SignedData_t1944945924, ___mda_6)); }
	inline bool get_mda_6() const { return ___mda_6; }
	inline bool* get_address_of_mda_6() { return &___mda_6; }
	inline void set_mda_6(bool value)
	{
		___mda_6 = value;
	}
};

struct SignedData_t1944945924_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Security.PKCS7/SignedData::<>f__switch$map5
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map5_7;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map5_7() { return static_cast<int32_t>(offsetof(SignedData_t1944945924_StaticFields, ___U3CU3Ef__switchU24map5_7)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map5_7() const { return ___U3CU3Ef__switchU24map5_7; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map5_7() { return &___U3CU3Ef__switchU24map5_7; }
	inline void set_U3CU3Ef__switchU24map5_7(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map5_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map5_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
