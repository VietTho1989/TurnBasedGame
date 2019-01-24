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
// Mono.Security.X509.X509CertificateCollection
struct X509CertificateCollection_t3592472865;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.X509.X509Store
struct  X509Store_t4028973563  : public Il2CppObject
{
public:
	// System.String Mono.Security.X509.X509Store::_storePath
	String_t* ____storePath_0;
	// Mono.Security.X509.X509CertificateCollection Mono.Security.X509.X509Store::_certificates
	X509CertificateCollection_t3592472865 * ____certificates_1;
	// System.Boolean Mono.Security.X509.X509Store::_crl
	bool ____crl_2;

public:
	inline static int32_t get_offset_of__storePath_0() { return static_cast<int32_t>(offsetof(X509Store_t4028973563, ____storePath_0)); }
	inline String_t* get__storePath_0() const { return ____storePath_0; }
	inline String_t** get_address_of__storePath_0() { return &____storePath_0; }
	inline void set__storePath_0(String_t* value)
	{
		____storePath_0 = value;
		Il2CppCodeGenWriteBarrier(&____storePath_0, value);
	}

	inline static int32_t get_offset_of__certificates_1() { return static_cast<int32_t>(offsetof(X509Store_t4028973563, ____certificates_1)); }
	inline X509CertificateCollection_t3592472865 * get__certificates_1() const { return ____certificates_1; }
	inline X509CertificateCollection_t3592472865 ** get_address_of__certificates_1() { return &____certificates_1; }
	inline void set__certificates_1(X509CertificateCollection_t3592472865 * value)
	{
		____certificates_1 = value;
		Il2CppCodeGenWriteBarrier(&____certificates_1, value);
	}

	inline static int32_t get_offset_of__crl_2() { return static_cast<int32_t>(offsetof(X509Store_t4028973563, ____crl_2)); }
	inline bool get__crl_2() const { return ____crl_2; }
	inline bool* get_address_of__crl_2() { return &____crl_2; }
	inline void set__crl_2(bool value)
	{
		____crl_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
