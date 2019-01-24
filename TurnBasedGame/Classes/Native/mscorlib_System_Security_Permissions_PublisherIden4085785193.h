#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_CodeAccessPermission3468021764.h"

// System.Security.Cryptography.X509Certificates.X509Certificate
struct X509Certificate_t283079845;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Permissions.PublisherIdentityPermission
struct  PublisherIdentityPermission_t4085785193  : public CodeAccessPermission_t3468021764
{
public:
	// System.Security.Cryptography.X509Certificates.X509Certificate System.Security.Permissions.PublisherIdentityPermission::x509
	X509Certificate_t283079845 * ___x509_0;

public:
	inline static int32_t get_offset_of_x509_0() { return static_cast<int32_t>(offsetof(PublisherIdentityPermission_t4085785193, ___x509_0)); }
	inline X509Certificate_t283079845 * get_x509_0() const { return ___x509_0; }
	inline X509Certificate_t283079845 ** get_address_of_x509_0() { return &___x509_0; }
	inline void set_x509_0(X509Certificate_t283079845 * value)
	{
		___x509_0 = value;
		Il2CppCodeGenWriteBarrier(&___x509_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
