#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X509.DistributionPointName
struct DistributionPointName_t1765286135;
// Org.BouncyCastle.Asn1.X509.ReasonFlags
struct ReasonFlags_t677892991;
// Org.BouncyCastle.Asn1.X509.GeneralNames
struct GeneralNames_t1290955016;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.DistributionPoint
struct  DistributionPoint_t769724552  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.DistributionPointName Org.BouncyCastle.Asn1.X509.DistributionPoint::distributionPoint
	DistributionPointName_t1765286135 * ___distributionPoint_2;
	// Org.BouncyCastle.Asn1.X509.ReasonFlags Org.BouncyCastle.Asn1.X509.DistributionPoint::reasons
	ReasonFlags_t677892991 * ___reasons_3;
	// Org.BouncyCastle.Asn1.X509.GeneralNames Org.BouncyCastle.Asn1.X509.DistributionPoint::cRLIssuer
	GeneralNames_t1290955016 * ___cRLIssuer_4;

public:
	inline static int32_t get_offset_of_distributionPoint_2() { return static_cast<int32_t>(offsetof(DistributionPoint_t769724552, ___distributionPoint_2)); }
	inline DistributionPointName_t1765286135 * get_distributionPoint_2() const { return ___distributionPoint_2; }
	inline DistributionPointName_t1765286135 ** get_address_of_distributionPoint_2() { return &___distributionPoint_2; }
	inline void set_distributionPoint_2(DistributionPointName_t1765286135 * value)
	{
		___distributionPoint_2 = value;
		Il2CppCodeGenWriteBarrier(&___distributionPoint_2, value);
	}

	inline static int32_t get_offset_of_reasons_3() { return static_cast<int32_t>(offsetof(DistributionPoint_t769724552, ___reasons_3)); }
	inline ReasonFlags_t677892991 * get_reasons_3() const { return ___reasons_3; }
	inline ReasonFlags_t677892991 ** get_address_of_reasons_3() { return &___reasons_3; }
	inline void set_reasons_3(ReasonFlags_t677892991 * value)
	{
		___reasons_3 = value;
		Il2CppCodeGenWriteBarrier(&___reasons_3, value);
	}

	inline static int32_t get_offset_of_cRLIssuer_4() { return static_cast<int32_t>(offsetof(DistributionPoint_t769724552, ___cRLIssuer_4)); }
	inline GeneralNames_t1290955016 * get_cRLIssuer_4() const { return ___cRLIssuer_4; }
	inline GeneralNames_t1290955016 ** get_address_of_cRLIssuer_4() { return &___cRLIssuer_4; }
	inline void set_cRLIssuer_4(GeneralNames_t1290955016 * value)
	{
		___cRLIssuer_4 = value;
		Il2CppCodeGenWriteBarrier(&___cRLIssuer_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
