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
// Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo
struct SubjectPublicKeyInfo_t3547422518;
// Org.BouncyCastle.Asn1.DerBitString
struct DerBitString_t2717907355;
// Org.BouncyCastle.Asn1.X509.X509Extensions
struct X509Extensions_t1384530060;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.TbsCertificateStructure
struct  TbsCertificateStructure_t1391133771  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::seq
	Asn1Sequence_t54253652 * ___seq_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::version
	DerInteger_t967720487 * ___version_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::serialNumber
	DerInteger_t967720487 * ___serialNumber_4;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::signature
	AlgorithmIdentifier_t2670781410 * ___signature_5;
	// Org.BouncyCastle.Asn1.X509.X509Name Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::issuer
	X509Name_t2936077305 * ___issuer_6;
	// Org.BouncyCastle.Asn1.X509.Time Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::startDate
	Time_t2566907995 * ___startDate_7;
	// Org.BouncyCastle.Asn1.X509.Time Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::endDate
	Time_t2566907995 * ___endDate_8;
	// Org.BouncyCastle.Asn1.X509.X509Name Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::subject
	X509Name_t2936077305 * ___subject_9;
	// Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::subjectPublicKeyInfo
	SubjectPublicKeyInfo_t3547422518 * ___subjectPublicKeyInfo_10;
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::issuerUniqueID
	DerBitString_t2717907355 * ___issuerUniqueID_11;
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::subjectUniqueID
	DerBitString_t2717907355 * ___subjectUniqueID_12;
	// Org.BouncyCastle.Asn1.X509.X509Extensions Org.BouncyCastle.Asn1.X509.TbsCertificateStructure::extensions
	X509Extensions_t1384530060 * ___extensions_13;

public:
	inline static int32_t get_offset_of_seq_2() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___seq_2)); }
	inline Asn1Sequence_t54253652 * get_seq_2() const { return ___seq_2; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_2() { return &___seq_2; }
	inline void set_seq_2(Asn1Sequence_t54253652 * value)
	{
		___seq_2 = value;
		Il2CppCodeGenWriteBarrier(&___seq_2, value);
	}

	inline static int32_t get_offset_of_version_3() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___version_3)); }
	inline DerInteger_t967720487 * get_version_3() const { return ___version_3; }
	inline DerInteger_t967720487 ** get_address_of_version_3() { return &___version_3; }
	inline void set_version_3(DerInteger_t967720487 * value)
	{
		___version_3 = value;
		Il2CppCodeGenWriteBarrier(&___version_3, value);
	}

	inline static int32_t get_offset_of_serialNumber_4() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___serialNumber_4)); }
	inline DerInteger_t967720487 * get_serialNumber_4() const { return ___serialNumber_4; }
	inline DerInteger_t967720487 ** get_address_of_serialNumber_4() { return &___serialNumber_4; }
	inline void set_serialNumber_4(DerInteger_t967720487 * value)
	{
		___serialNumber_4 = value;
		Il2CppCodeGenWriteBarrier(&___serialNumber_4, value);
	}

	inline static int32_t get_offset_of_signature_5() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___signature_5)); }
	inline AlgorithmIdentifier_t2670781410 * get_signature_5() const { return ___signature_5; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_signature_5() { return &___signature_5; }
	inline void set_signature_5(AlgorithmIdentifier_t2670781410 * value)
	{
		___signature_5 = value;
		Il2CppCodeGenWriteBarrier(&___signature_5, value);
	}

	inline static int32_t get_offset_of_issuer_6() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___issuer_6)); }
	inline X509Name_t2936077305 * get_issuer_6() const { return ___issuer_6; }
	inline X509Name_t2936077305 ** get_address_of_issuer_6() { return &___issuer_6; }
	inline void set_issuer_6(X509Name_t2936077305 * value)
	{
		___issuer_6 = value;
		Il2CppCodeGenWriteBarrier(&___issuer_6, value);
	}

	inline static int32_t get_offset_of_startDate_7() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___startDate_7)); }
	inline Time_t2566907995 * get_startDate_7() const { return ___startDate_7; }
	inline Time_t2566907995 ** get_address_of_startDate_7() { return &___startDate_7; }
	inline void set_startDate_7(Time_t2566907995 * value)
	{
		___startDate_7 = value;
		Il2CppCodeGenWriteBarrier(&___startDate_7, value);
	}

	inline static int32_t get_offset_of_endDate_8() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___endDate_8)); }
	inline Time_t2566907995 * get_endDate_8() const { return ___endDate_8; }
	inline Time_t2566907995 ** get_address_of_endDate_8() { return &___endDate_8; }
	inline void set_endDate_8(Time_t2566907995 * value)
	{
		___endDate_8 = value;
		Il2CppCodeGenWriteBarrier(&___endDate_8, value);
	}

	inline static int32_t get_offset_of_subject_9() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___subject_9)); }
	inline X509Name_t2936077305 * get_subject_9() const { return ___subject_9; }
	inline X509Name_t2936077305 ** get_address_of_subject_9() { return &___subject_9; }
	inline void set_subject_9(X509Name_t2936077305 * value)
	{
		___subject_9 = value;
		Il2CppCodeGenWriteBarrier(&___subject_9, value);
	}

	inline static int32_t get_offset_of_subjectPublicKeyInfo_10() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___subjectPublicKeyInfo_10)); }
	inline SubjectPublicKeyInfo_t3547422518 * get_subjectPublicKeyInfo_10() const { return ___subjectPublicKeyInfo_10; }
	inline SubjectPublicKeyInfo_t3547422518 ** get_address_of_subjectPublicKeyInfo_10() { return &___subjectPublicKeyInfo_10; }
	inline void set_subjectPublicKeyInfo_10(SubjectPublicKeyInfo_t3547422518 * value)
	{
		___subjectPublicKeyInfo_10 = value;
		Il2CppCodeGenWriteBarrier(&___subjectPublicKeyInfo_10, value);
	}

	inline static int32_t get_offset_of_issuerUniqueID_11() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___issuerUniqueID_11)); }
	inline DerBitString_t2717907355 * get_issuerUniqueID_11() const { return ___issuerUniqueID_11; }
	inline DerBitString_t2717907355 ** get_address_of_issuerUniqueID_11() { return &___issuerUniqueID_11; }
	inline void set_issuerUniqueID_11(DerBitString_t2717907355 * value)
	{
		___issuerUniqueID_11 = value;
		Il2CppCodeGenWriteBarrier(&___issuerUniqueID_11, value);
	}

	inline static int32_t get_offset_of_subjectUniqueID_12() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___subjectUniqueID_12)); }
	inline DerBitString_t2717907355 * get_subjectUniqueID_12() const { return ___subjectUniqueID_12; }
	inline DerBitString_t2717907355 ** get_address_of_subjectUniqueID_12() { return &___subjectUniqueID_12; }
	inline void set_subjectUniqueID_12(DerBitString_t2717907355 * value)
	{
		___subjectUniqueID_12 = value;
		Il2CppCodeGenWriteBarrier(&___subjectUniqueID_12, value);
	}

	inline static int32_t get_offset_of_extensions_13() { return static_cast<int32_t>(offsetof(TbsCertificateStructure_t1391133771, ___extensions_13)); }
	inline X509Extensions_t1384530060 * get_extensions_13() const { return ___extensions_13; }
	inline X509Extensions_t1384530060 ** get_address_of_extensions_13() { return &___extensions_13; }
	inline void set_extensions_13(X509Extensions_t1384530060 * value)
	{
		___extensions_13 = value;
		Il2CppCodeGenWriteBarrier(&___extensions_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
