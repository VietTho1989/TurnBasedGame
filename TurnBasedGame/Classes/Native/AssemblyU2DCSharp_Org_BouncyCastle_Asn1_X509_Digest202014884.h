#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.DigestInfo
struct  DigestInfo_t202014884  : public Asn1Encodable_t3447851422
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.X509.DigestInfo::digest
	ByteU5BU5D_t3397334013* ___digest_2;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.DigestInfo::algID
	AlgorithmIdentifier_t2670781410 * ___algID_3;

public:
	inline static int32_t get_offset_of_digest_2() { return static_cast<int32_t>(offsetof(DigestInfo_t202014884, ___digest_2)); }
	inline ByteU5BU5D_t3397334013* get_digest_2() const { return ___digest_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_digest_2() { return &___digest_2; }
	inline void set_digest_2(ByteU5BU5D_t3397334013* value)
	{
		___digest_2 = value;
		Il2CppCodeGenWriteBarrier(&___digest_2, value);
	}

	inline static int32_t get_offset_of_algID_3() { return static_cast<int32_t>(offsetof(DigestInfo_t202014884, ___algID_3)); }
	inline AlgorithmIdentifier_t2670781410 * get_algID_3() const { return ___algID_3; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_algID_3() { return &___algID_3; }
	inline void set_algID_3(AlgorithmIdentifier_t2670781410 * value)
	{
		___algID_3 = value;
		Il2CppCodeGenWriteBarrier(&___algID_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
