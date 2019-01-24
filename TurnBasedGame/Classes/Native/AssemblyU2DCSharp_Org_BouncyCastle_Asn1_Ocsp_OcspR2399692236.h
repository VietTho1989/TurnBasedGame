#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Ocsp.OcspResponseStatus
struct OcspResponseStatus_t2886715370;
// Org.BouncyCastle.Asn1.Ocsp.ResponseBytes
struct ResponseBytes_t561211756;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Ocsp.OcspResponse
struct  OcspResponse_t2399692236  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Ocsp.OcspResponseStatus Org.BouncyCastle.Asn1.Ocsp.OcspResponse::responseStatus
	OcspResponseStatus_t2886715370 * ___responseStatus_2;
	// Org.BouncyCastle.Asn1.Ocsp.ResponseBytes Org.BouncyCastle.Asn1.Ocsp.OcspResponse::responseBytes
	ResponseBytes_t561211756 * ___responseBytes_3;

public:
	inline static int32_t get_offset_of_responseStatus_2() { return static_cast<int32_t>(offsetof(OcspResponse_t2399692236, ___responseStatus_2)); }
	inline OcspResponseStatus_t2886715370 * get_responseStatus_2() const { return ___responseStatus_2; }
	inline OcspResponseStatus_t2886715370 ** get_address_of_responseStatus_2() { return &___responseStatus_2; }
	inline void set_responseStatus_2(OcspResponseStatus_t2886715370 * value)
	{
		___responseStatus_2 = value;
		Il2CppCodeGenWriteBarrier(&___responseStatus_2, value);
	}

	inline static int32_t get_offset_of_responseBytes_3() { return static_cast<int32_t>(offsetof(OcspResponse_t2399692236, ___responseBytes_3)); }
	inline ResponseBytes_t561211756 * get_responseBytes_3() const { return ___responseBytes_3; }
	inline ResponseBytes_t561211756 ** get_address_of_responseBytes_3() { return &___responseBytes_3; }
	inline void set_responseBytes_3(ResponseBytes_t561211756 * value)
	{
		___responseBytes_3 = value;
		Il2CppCodeGenWriteBarrier(&___responseBytes_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
