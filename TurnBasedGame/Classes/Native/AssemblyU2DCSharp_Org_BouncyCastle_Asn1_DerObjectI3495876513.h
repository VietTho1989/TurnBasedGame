#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Object564283626.h"

// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Asn1.DerObjectIdentifier[]
struct DerObjectIdentifierU5BU5D_t1959811260;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerObjectIdentifier
struct  DerObjectIdentifier_t3495876513  : public Asn1Object_t564283626
{
public:
	// System.String Org.BouncyCastle.Asn1.DerObjectIdentifier::identifier
	String_t* ___identifier_2;
	// System.Byte[] Org.BouncyCastle.Asn1.DerObjectIdentifier::body
	ByteU5BU5D_t3397334013* ___body_3;

public:
	inline static int32_t get_offset_of_identifier_2() { return static_cast<int32_t>(offsetof(DerObjectIdentifier_t3495876513, ___identifier_2)); }
	inline String_t* get_identifier_2() const { return ___identifier_2; }
	inline String_t** get_address_of_identifier_2() { return &___identifier_2; }
	inline void set_identifier_2(String_t* value)
	{
		___identifier_2 = value;
		Il2CppCodeGenWriteBarrier(&___identifier_2, value);
	}

	inline static int32_t get_offset_of_body_3() { return static_cast<int32_t>(offsetof(DerObjectIdentifier_t3495876513, ___body_3)); }
	inline ByteU5BU5D_t3397334013* get_body_3() const { return ___body_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_body_3() { return &___body_3; }
	inline void set_body_3(ByteU5BU5D_t3397334013* value)
	{
		___body_3 = value;
		Il2CppCodeGenWriteBarrier(&___body_3, value);
	}
};

struct DerObjectIdentifier_t3495876513_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier[] Org.BouncyCastle.Asn1.DerObjectIdentifier::cache
	DerObjectIdentifierU5BU5D_t1959811260* ___cache_5;

public:
	inline static int32_t get_offset_of_cache_5() { return static_cast<int32_t>(offsetof(DerObjectIdentifier_t3495876513_StaticFields, ___cache_5)); }
	inline DerObjectIdentifierU5BU5D_t1959811260* get_cache_5() const { return ___cache_5; }
	inline DerObjectIdentifierU5BU5D_t1959811260** get_address_of_cache_5() { return &___cache_5; }
	inline void set_cache_5(DerObjectIdentifierU5BU5D_t1959811260* value)
	{
		___cache_5 = value;
		Il2CppCodeGenWriteBarrier(&___cache_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
