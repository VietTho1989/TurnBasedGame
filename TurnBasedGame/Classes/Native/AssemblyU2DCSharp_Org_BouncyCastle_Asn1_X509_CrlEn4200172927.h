#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.Asn1Sequence
struct Asn1Sequence_t54253652;
// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;
// Org.BouncyCastle.Asn1.X509.Time
struct Time_t2566907995;
// Org.BouncyCastle.Asn1.X509.X509Extensions
struct X509Extensions_t1384530060;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.CrlEntry
struct  CrlEntry_t4200172927  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.CrlEntry::seq
	Asn1Sequence_t54253652 * ___seq_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.CrlEntry::userCertificate
	DerInteger_t967720487 * ___userCertificate_3;
	// Org.BouncyCastle.Asn1.X509.Time Org.BouncyCastle.Asn1.X509.CrlEntry::revocationDate
	Time_t2566907995 * ___revocationDate_4;
	// Org.BouncyCastle.Asn1.X509.X509Extensions Org.BouncyCastle.Asn1.X509.CrlEntry::crlEntryExtensions
	X509Extensions_t1384530060 * ___crlEntryExtensions_5;

public:
	inline static int32_t get_offset_of_seq_2() { return static_cast<int32_t>(offsetof(CrlEntry_t4200172927, ___seq_2)); }
	inline Asn1Sequence_t54253652 * get_seq_2() const { return ___seq_2; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_2() { return &___seq_2; }
	inline void set_seq_2(Asn1Sequence_t54253652 * value)
	{
		___seq_2 = value;
		Il2CppCodeGenWriteBarrier(&___seq_2, value);
	}

	inline static int32_t get_offset_of_userCertificate_3() { return static_cast<int32_t>(offsetof(CrlEntry_t4200172927, ___userCertificate_3)); }
	inline DerInteger_t967720487 * get_userCertificate_3() const { return ___userCertificate_3; }
	inline DerInteger_t967720487 ** get_address_of_userCertificate_3() { return &___userCertificate_3; }
	inline void set_userCertificate_3(DerInteger_t967720487 * value)
	{
		___userCertificate_3 = value;
		Il2CppCodeGenWriteBarrier(&___userCertificate_3, value);
	}

	inline static int32_t get_offset_of_revocationDate_4() { return static_cast<int32_t>(offsetof(CrlEntry_t4200172927, ___revocationDate_4)); }
	inline Time_t2566907995 * get_revocationDate_4() const { return ___revocationDate_4; }
	inline Time_t2566907995 ** get_address_of_revocationDate_4() { return &___revocationDate_4; }
	inline void set_revocationDate_4(Time_t2566907995 * value)
	{
		___revocationDate_4 = value;
		Il2CppCodeGenWriteBarrier(&___revocationDate_4, value);
	}

	inline static int32_t get_offset_of_crlEntryExtensions_5() { return static_cast<int32_t>(offsetof(CrlEntry_t4200172927, ___crlEntryExtensions_5)); }
	inline X509Extensions_t1384530060 * get_crlEntryExtensions_5() const { return ___crlEntryExtensions_5; }
	inline X509Extensions_t1384530060 ** get_address_of_crlEntryExtensions_5() { return &___crlEntryExtensions_5; }
	inline void set_crlEntryExtensions_5(X509Extensions_t1384530060 * value)
	{
		___crlEntryExtensions_5 = value;
		Il2CppCodeGenWriteBarrier(&___crlEntryExtensions_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
