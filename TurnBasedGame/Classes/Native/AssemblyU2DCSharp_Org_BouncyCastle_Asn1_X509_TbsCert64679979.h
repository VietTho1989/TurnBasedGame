#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IEnumerable
struct IEnumerable_t2911409499;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.TbsCertificateList/RevokedCertificatesEnumeration
struct  RevokedCertificatesEnumeration_t64679979  : public Il2CppObject
{
public:
	// System.Collections.IEnumerable Org.BouncyCastle.Asn1.X509.TbsCertificateList/RevokedCertificatesEnumeration::en
	Il2CppObject * ___en_0;

public:
	inline static int32_t get_offset_of_en_0() { return static_cast<int32_t>(offsetof(RevokedCertificatesEnumeration_t64679979, ___en_0)); }
	inline Il2CppObject * get_en_0() const { return ___en_0; }
	inline Il2CppObject ** get_address_of_en_0() { return &___en_0; }
	inline void set_en_0(Il2CppObject * value)
	{
		___en_0 = value;
		Il2CppCodeGenWriteBarrier(&___en_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
