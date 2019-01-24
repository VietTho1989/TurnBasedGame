#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct DerObjectIdentifier_t3495876513;
// Org.BouncyCastle.Asn1.Asn1Encodable
struct Asn1Encodable_t3447851422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Pkcs.ContentInfo
struct  ContentInfo_t1565361645  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.Pkcs.ContentInfo::contentType
	DerObjectIdentifier_t3495876513 * ___contentType_2;
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.Pkcs.ContentInfo::content
	Asn1Encodable_t3447851422 * ___content_3;

public:
	inline static int32_t get_offset_of_contentType_2() { return static_cast<int32_t>(offsetof(ContentInfo_t1565361645, ___contentType_2)); }
	inline DerObjectIdentifier_t3495876513 * get_contentType_2() const { return ___contentType_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_contentType_2() { return &___contentType_2; }
	inline void set_contentType_2(DerObjectIdentifier_t3495876513 * value)
	{
		___contentType_2 = value;
		Il2CppCodeGenWriteBarrier(&___contentType_2, value);
	}

	inline static int32_t get_offset_of_content_3() { return static_cast<int32_t>(offsetof(ContentInfo_t1565361645, ___content_3)); }
	inline Asn1Encodable_t3447851422 * get_content_3() const { return ___content_3; }
	inline Asn1Encodable_t3447851422 ** get_address_of_content_3() { return &___content_3; }
	inline void set_content_3(Asn1Encodable_t3447851422 * value)
	{
		___content_3 = value;
		Il2CppCodeGenWriteBarrier(&___content_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
