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
// Org.BouncyCastle.Asn1.Asn1OctetString
struct Asn1OctetString_t1486532927;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Ocsp.ResponseBytes
struct  ResponseBytes_t561211756  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.Ocsp.ResponseBytes::responseType
	DerObjectIdentifier_t3495876513 * ___responseType_2;
	// Org.BouncyCastle.Asn1.Asn1OctetString Org.BouncyCastle.Asn1.Ocsp.ResponseBytes::response
	Asn1OctetString_t1486532927 * ___response_3;

public:
	inline static int32_t get_offset_of_responseType_2() { return static_cast<int32_t>(offsetof(ResponseBytes_t561211756, ___responseType_2)); }
	inline DerObjectIdentifier_t3495876513 * get_responseType_2() const { return ___responseType_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_responseType_2() { return &___responseType_2; }
	inline void set_responseType_2(DerObjectIdentifier_t3495876513 * value)
	{
		___responseType_2 = value;
		Il2CppCodeGenWriteBarrier(&___responseType_2, value);
	}

	inline static int32_t get_offset_of_response_3() { return static_cast<int32_t>(offsetof(ResponseBytes_t561211756, ___response_3)); }
	inline Asn1OctetString_t1486532927 * get_response_3() const { return ___response_3; }
	inline Asn1OctetString_t1486532927 ** get_address_of_response_3() { return &___response_3; }
	inline void set_response_3(Asn1OctetString_t1486532927 * value)
	{
		___response_3 = value;
		Il2CppCodeGenWriteBarrier(&___response_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
