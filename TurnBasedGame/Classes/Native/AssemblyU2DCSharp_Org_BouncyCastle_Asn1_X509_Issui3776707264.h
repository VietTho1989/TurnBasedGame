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
// Org.BouncyCastle.Asn1.Asn1Sequence
struct Asn1Sequence_t54253652;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint
struct  IssuingDistributionPoint_t3776707264  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.DistributionPointName Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_distributionPoint
	DistributionPointName_t1765286135 * ____distributionPoint_2;
	// System.Boolean Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_onlyContainsUserCerts
	bool ____onlyContainsUserCerts_3;
	// System.Boolean Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_onlyContainsCACerts
	bool ____onlyContainsCACerts_4;
	// Org.BouncyCastle.Asn1.X509.ReasonFlags Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_onlySomeReasons
	ReasonFlags_t677892991 * ____onlySomeReasons_5;
	// System.Boolean Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_indirectCRL
	bool ____indirectCRL_6;
	// System.Boolean Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::_onlyContainsAttributeCerts
	bool ____onlyContainsAttributeCerts_7;
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint::seq
	Asn1Sequence_t54253652 * ___seq_8;

public:
	inline static int32_t get_offset_of__distributionPoint_2() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____distributionPoint_2)); }
	inline DistributionPointName_t1765286135 * get__distributionPoint_2() const { return ____distributionPoint_2; }
	inline DistributionPointName_t1765286135 ** get_address_of__distributionPoint_2() { return &____distributionPoint_2; }
	inline void set__distributionPoint_2(DistributionPointName_t1765286135 * value)
	{
		____distributionPoint_2 = value;
		Il2CppCodeGenWriteBarrier(&____distributionPoint_2, value);
	}

	inline static int32_t get_offset_of__onlyContainsUserCerts_3() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____onlyContainsUserCerts_3)); }
	inline bool get__onlyContainsUserCerts_3() const { return ____onlyContainsUserCerts_3; }
	inline bool* get_address_of__onlyContainsUserCerts_3() { return &____onlyContainsUserCerts_3; }
	inline void set__onlyContainsUserCerts_3(bool value)
	{
		____onlyContainsUserCerts_3 = value;
	}

	inline static int32_t get_offset_of__onlyContainsCACerts_4() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____onlyContainsCACerts_4)); }
	inline bool get__onlyContainsCACerts_4() const { return ____onlyContainsCACerts_4; }
	inline bool* get_address_of__onlyContainsCACerts_4() { return &____onlyContainsCACerts_4; }
	inline void set__onlyContainsCACerts_4(bool value)
	{
		____onlyContainsCACerts_4 = value;
	}

	inline static int32_t get_offset_of__onlySomeReasons_5() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____onlySomeReasons_5)); }
	inline ReasonFlags_t677892991 * get__onlySomeReasons_5() const { return ____onlySomeReasons_5; }
	inline ReasonFlags_t677892991 ** get_address_of__onlySomeReasons_5() { return &____onlySomeReasons_5; }
	inline void set__onlySomeReasons_5(ReasonFlags_t677892991 * value)
	{
		____onlySomeReasons_5 = value;
		Il2CppCodeGenWriteBarrier(&____onlySomeReasons_5, value);
	}

	inline static int32_t get_offset_of__indirectCRL_6() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____indirectCRL_6)); }
	inline bool get__indirectCRL_6() const { return ____indirectCRL_6; }
	inline bool* get_address_of__indirectCRL_6() { return &____indirectCRL_6; }
	inline void set__indirectCRL_6(bool value)
	{
		____indirectCRL_6 = value;
	}

	inline static int32_t get_offset_of__onlyContainsAttributeCerts_7() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ____onlyContainsAttributeCerts_7)); }
	inline bool get__onlyContainsAttributeCerts_7() const { return ____onlyContainsAttributeCerts_7; }
	inline bool* get_address_of__onlyContainsAttributeCerts_7() { return &____onlyContainsAttributeCerts_7; }
	inline void set__onlyContainsAttributeCerts_7(bool value)
	{
		____onlyContainsAttributeCerts_7 = value;
	}

	inline static int32_t get_offset_of_seq_8() { return static_cast<int32_t>(offsetof(IssuingDistributionPoint_t3776707264, ___seq_8)); }
	inline Asn1Sequence_t54253652 * get_seq_8() const { return ___seq_8; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_8() { return &___seq_8; }
	inline void set_seq_8(Asn1Sequence_t54253652 * value)
	{
		___seq_8 = value;
		Il2CppCodeGenWriteBarrier(&___seq_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
