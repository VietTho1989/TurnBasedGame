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

// Org.BouncyCastle.Asn1.X509.DistributionPointName
struct  DistributionPointName_t1765286135  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Encodable Org.BouncyCastle.Asn1.X509.DistributionPointName::name
	Asn1Encodable_t3447851422 * ___name_2;
	// System.Int32 Org.BouncyCastle.Asn1.X509.DistributionPointName::type
	int32_t ___type_3;

public:
	inline static int32_t get_offset_of_name_2() { return static_cast<int32_t>(offsetof(DistributionPointName_t1765286135, ___name_2)); }
	inline Asn1Encodable_t3447851422 * get_name_2() const { return ___name_2; }
	inline Asn1Encodable_t3447851422 ** get_address_of_name_2() { return &___name_2; }
	inline void set_name_2(Asn1Encodable_t3447851422 * value)
	{
		___name_2 = value;
		Il2CppCodeGenWriteBarrier(&___name_2, value);
	}

	inline static int32_t get_offset_of_type_3() { return static_cast<int32_t>(offsetof(DistributionPointName_t1765286135, ___type_3)); }
	inline int32_t get_type_3() const { return ___type_3; }
	inline int32_t* get_address_of_type_3() { return &___type_3; }
	inline void set_type_3(int32_t value)
	{
		___type_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
