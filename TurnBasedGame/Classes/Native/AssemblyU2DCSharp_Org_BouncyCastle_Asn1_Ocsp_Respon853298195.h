#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1Encodable
struct Asn1Encodable_t3447851422;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Ocsp.ResponderID
struct  ResponderID_t853298195  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.Ocsp.ResponderID::id
	Asn1Encodable_t3447851422 * ___id_2;

public:
	inline static int32_t get_offset_of_id_2() { return static_cast<int32_t>(offsetof(ResponderID_t853298195, ___id_2)); }
	inline Asn1Encodable_t3447851422 * get_id_2() const { return ___id_2; }
	inline Asn1Encodable_t3447851422 ** get_address_of_id_2() { return &___id_2; }
	inline void set_id_2(Asn1Encodable_t3447851422 * value)
	{
		___id_2 = value;
		Il2CppCodeGenWriteBarrier(&___id_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
