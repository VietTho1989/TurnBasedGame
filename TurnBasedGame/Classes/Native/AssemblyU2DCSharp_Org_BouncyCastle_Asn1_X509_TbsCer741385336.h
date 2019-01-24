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
// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;
// Org.BouncyCastle.Asn1.X509.X509Name
struct X509Name_t2936077305;
// Org.BouncyCastle.Asn1.X509.Time
struct Time_t2566907995;
// Org.BouncyCastle.Asn1.X509.X509Extensions
struct X509Extensions_t1384530060;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.TbsCertificateList
struct  TbsCertificateList_t741385336  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.TbsCertificateList::seq
	Asn1Sequence_t54253652 * ___seq_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.TbsCertificateList::version
	DerInteger_t967720487 * ___version_3;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.TbsCertificateList::signature
	AlgorithmIdentifier_t2670781410 * ___signature_4;
	// Org.BouncyCastle.Asn1.X509.X509Name Org.BouncyCastle.Asn1.X509.TbsCertificateList::issuer
	X509Name_t2936077305 * ___issuer_5;
	// Org.BouncyCastle.Asn1.X509.Time Org.BouncyCastle.Asn1.X509.TbsCertificateList::thisUpdate
	Time_t2566907995 * ___thisUpdate_6;
	// Org.BouncyCastle.Asn1.X509.Time Org.BouncyCastle.Asn1.X509.TbsCertificateList::nextUpdate
	Time_t2566907995 * ___nextUpdate_7;
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.TbsCertificateList::revokedCertificates
	Asn1Sequence_t54253652 * ___revokedCertificates_8;
	// Org.BouncyCastle.Asn1.X509.X509Extensions Org.BouncyCastle.Asn1.X509.TbsCertificateList::crlExtensions
	X509Extensions_t1384530060 * ___crlExtensions_9;

public:
	inline static int32_t get_offset_of_seq_2() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___seq_2)); }
	inline Asn1Sequence_t54253652 * get_seq_2() const { return ___seq_2; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_2() { return &___seq_2; }
	inline void set_seq_2(Asn1Sequence_t54253652 * value)
	{
		___seq_2 = value;
		Il2CppCodeGenWriteBarrier(&___seq_2, value);
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___version_3)); }
	inline DerInteger_t967720487 * get_version_3() const { return ___version_3; }
	inline DerInteger_t967720487 ** get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(DerInteger_t967720487 * value)
	{
		___version_3 = value;
		Il2CppCodeGenWriteBarrier(&___version_3, value);
	}

	inline static int32_t get_offset_of_signature_4() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___signature_4)); }
	inline AlgorithmIdentifier_t2670781410 * get_signature_4() const { return ___signature_4; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_signature_4() { return &___signature_4; }
	inline void set_signature_4(AlgorithmIdentifier_t2670781410 * value)
	{
		___signature_4 = value;
		Il2CppCodeGenWriteBarrier(&___signature_4, value);
	}

	inline static int32_t get_offset_of_issuer_5() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___issuer_5)); }
	inline X509Name_t2936077305 * get_issuer_5() const { return ___issuer_5; }
	inline X509Name_t2936077305 ** get_address_of_issuer_5() { return &___issuer_5; }
	inline void set_issuer_5(X509Name_t2936077305 * value)
	{
		___issuer_5 = value;
		Il2CppCodeGenWriteBarrier(&___issuer_5, value);
	}

	inline static int32_t get_offset_of_thisUpdate_6() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___thisUpdate_6)); }
	inline Time_t2566907995 * get_thisUpdate_6() const { return ___thisUpdate_6; }
	inline Time_t2566907995 ** get_address_of_thisUpdate_6() { return &___thisUpdate_6; }
	inline void set_thisUpdate_6(Time_t2566907995 * value)
	{
		___thisUpdate_6 = value;
		Il2CppCodeGenWriteBarrier(&___thisUpdate_6, value);
	}

	inline static int32_t get_offset_of_nextUpdate_7() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___nextUpdate_7)); }
	inline Time_t2566907995 * get_nextUpdate_7() const { return ___nextUpdate_7; }
	inline Time_t2566907995 ** get_address_of_nextUpdate_7() { return &___nextUpdate_7; }
	inline void set_nextUpdate_7(Time_t2566907995 * value)
	{
		___nextUpdate_7 = value;
		Il2CppCodeGenWriteBarrier(&___nextUpdate_7, value);
	}

	inline static int32_t get_offset_of_revokedCertificates_8() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___revokedCertificates_8)); }
	inline Asn1Sequence_t54253652 * get_revokedCertificates_8() const { return ___revokedCertificates_8; }
	inline Asn1Sequence_t54253652 ** get_address_of_revokedCertificates_8() { return &___revokedCertificates_8; }
	inline void set_revokedCertificates_8(Asn1Sequence_t54253652 * value)
	{
		___revokedCertificates_8 = value;
		Il2CppCodeGenWriteBarrier(&___revokedCertificates_8, value);
	}

	inline static int32_t get_offset_of_crlExtensions_9() { return static_cast<int32_t>(offsetof(TbsCertificateList_t741385336, ___crlExtensions_9)); }
	inline X509Extensions_t1384530060 * get_crlExtensions_9() const { return ___crlExtensions_9; }
	inline X509Extensions_t1384530060 ** get_address_of_crlExtensions_9() { return &___crlExtensions_9; }
	inline void set_crlExtensions_9(X509Extensions_t1384530060 * value)
	{
		___crlExtensions_9 = value;
		Il2CppCodeGenWriteBarrier(&___crlExtensions_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
