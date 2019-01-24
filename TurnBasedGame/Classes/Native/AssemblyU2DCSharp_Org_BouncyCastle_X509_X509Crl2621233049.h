#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_X509_X509Extens1429324694.h"

// Org.BouncyCastle.Asn1.X509.CertificateList
struct CertificateList_t2288802675;
// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.X509.X509Crl
struct  X509Crl_t2621233049  : public X509ExtensionBase_t1429324694
{
public:
	// Org.BouncyCastle.Asn1.X509.CertificateList Org.BouncyCastle.X509.X509Crl::c
	CertificateList_t2288802675 * ___c_0;
	// System.String Org.BouncyCastle.X509.X509Crl::sigAlgName
	String_t* ___sigAlgName_1;
	// System.Byte[] Org.BouncyCastle.X509.X509Crl::sigAlgParams
	ByteU5BU5D_t3397334013* ___sigAlgParams_2;
	// System.Boolean Org.BouncyCastle.X509.X509Crl::isIndirect
	bool ___isIndirect_3;

public:
	inline static int32_t get_offset_of_c_0() { return static_cast<int32_t>(offsetof(X509Crl_t2621233049, ___c_0)); }
	inline CertificateList_t2288802675 * get_c_0() const { return ___c_0; }
	inline CertificateList_t2288802675 ** get_address_of_c_0() { return &___c_0; }
	inline void set_c_0(CertificateList_t2288802675 * value)
	{
		___c_0 = value;
		Il2CppCodeGenWriteBarrier(&___c_0, value);
	}

	inline static int32_t get_offset_of_sigAlgName_1() { return static_cast<int32_t>(offsetof(X509Crl_t2621233049, ___sigAlgName_1)); }
	inline String_t* get_sigAlgName_1() const { return ___sigAlgName_1; }
	inline String_t** get_address_of_sigAlgName_1() { return &___sigAlgName_1; }
	inline void set_sigAlgName_1(String_t* value)
	{
		___sigAlgName_1 = value;
		Il2CppCodeGenWriteBarrier(&___sigAlgName_1, value);
	}

	inline static int32_t get_offset_of_sigAlgParams_2() { return static_cast<int32_t>(offsetof(X509Crl_t2621233049, ___sigAlgParams_2)); }
	inline ByteU5BU5D_t3397334013* get_sigAlgParams_2() const { return ___sigAlgParams_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_sigAlgParams_2() { return &___sigAlgParams_2; }
	inline void set_sigAlgParams_2(ByteU5BU5D_t3397334013* value)
	{
		___sigAlgParams_2 = value;
		Il2CppCodeGenWriteBarrier(&___sigAlgParams_2, value);
	}

	inline static int32_t get_offset_of_isIndirect_3() { return static_cast<int32_t>(offsetof(X509Crl_t2621233049, ___isIndirect_3)); }
	inline bool get_isIndirect_3() const { return ___isIndirect_3; }
	inline bool* get_address_of_isIndirect_3() { return &___isIndirect_3; }
	inline void set_isIndirect_3(bool value)
	{
		___isIndirect_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
