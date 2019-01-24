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
// System.Collections.IDictionary
struct IDictionary_t596158605;
// System.Collections.IList
struct IList_t3321498491;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.X509Extensions
struct  X509Extensions_t1384530060  : public Asn1Encodable_t3447851422
{
public:
	// System.Collections.IDictionary Org.BouncyCastle.Asn1.X509.X509Extensions::extensions
	Il2CppObject * ___extensions_33;
	// System.Collections.IList Org.BouncyCastle.Asn1.X509.X509Extensions::ordering
	Il2CppObject * ___ordering_34;

public:
	inline static int32_t get_offset_of_extensions_33() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060, ___extensions_33)); }
	inline Il2CppObject * get_extensions_33() const { return ___extensions_33; }
	inline Il2CppObject ** get_address_of_extensions_33() { return &___extensions_33; }
	inline void set_extensions_33(Il2CppObject * value)
	{
		___extensions_33 = value;
		Il2CppCodeGenWriteBarrier(&___extensions_33, value);
	}

	inline static int32_t get_offset_of_ordering_34() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060, ___ordering_34)); }
	inline Il2CppObject * get_ordering_34() const { return ___ordering_34; }
	inline Il2CppObject ** get_address_of_ordering_34() { return &___ordering_34; }
	inline void set_ordering_34(Il2CppObject * value)
	{
		___ordering_34 = value;
		Il2CppCodeGenWriteBarrier(&___ordering_34, value);
	}
};

struct X509Extensions_t1384530060_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::SubjectDirectoryAttributes
	DerObjectIdentifier_t3495876513 * ___SubjectDirectoryAttributes_2;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::SubjectKeyIdentifier
	DerObjectIdentifier_t3495876513 * ___SubjectKeyIdentifier_3;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::KeyUsage
	DerObjectIdentifier_t3495876513 * ___KeyUsage_4;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::PrivateKeyUsagePeriod
	DerObjectIdentifier_t3495876513 * ___PrivateKeyUsagePeriod_5;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::SubjectAlternativeName
	DerObjectIdentifier_t3495876513 * ___SubjectAlternativeName_6;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::IssuerAlternativeName
	DerObjectIdentifier_t3495876513 * ___IssuerAlternativeName_7;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::BasicConstraints
	DerObjectIdentifier_t3495876513 * ___BasicConstraints_8;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::CrlNumber
	DerObjectIdentifier_t3495876513 * ___CrlNumber_9;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::ReasonCode
	DerObjectIdentifier_t3495876513 * ___ReasonCode_10;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::InstructionCode
	DerObjectIdentifier_t3495876513 * ___InstructionCode_11;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::InvalidityDate
	DerObjectIdentifier_t3495876513 * ___InvalidityDate_12;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::DeltaCrlIndicator
	DerObjectIdentifier_t3495876513 * ___DeltaCrlIndicator_13;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::IssuingDistributionPoint
	DerObjectIdentifier_t3495876513 * ___IssuingDistributionPoint_14;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::CertificateIssuer
	DerObjectIdentifier_t3495876513 * ___CertificateIssuer_15;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::NameConstraints
	DerObjectIdentifier_t3495876513 * ___NameConstraints_16;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::CrlDistributionPoints
	DerObjectIdentifier_t3495876513 * ___CrlDistributionPoints_17;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::CertificatePolicies
	DerObjectIdentifier_t3495876513 * ___CertificatePolicies_18;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::PolicyMappings
	DerObjectIdentifier_t3495876513 * ___PolicyMappings_19;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::AuthorityKeyIdentifier
	DerObjectIdentifier_t3495876513 * ___AuthorityKeyIdentifier_20;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::PolicyConstraints
	DerObjectIdentifier_t3495876513 * ___PolicyConstraints_21;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::ExtendedKeyUsage
	DerObjectIdentifier_t3495876513 * ___ExtendedKeyUsage_22;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::FreshestCrl
	DerObjectIdentifier_t3495876513 * ___FreshestCrl_23;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::InhibitAnyPolicy
	DerObjectIdentifier_t3495876513 * ___InhibitAnyPolicy_24;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::AuthorityInfoAccess
	DerObjectIdentifier_t3495876513 * ___AuthorityInfoAccess_25;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::SubjectInfoAccess
	DerObjectIdentifier_t3495876513 * ___SubjectInfoAccess_26;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::LogoType
	DerObjectIdentifier_t3495876513 * ___LogoType_27;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::BiometricInfo
	DerObjectIdentifier_t3495876513 * ___BiometricInfo_28;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::QCStatements
	DerObjectIdentifier_t3495876513 * ___QCStatements_29;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::AuditIdentity
	DerObjectIdentifier_t3495876513 * ___AuditIdentity_30;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::NoRevAvail
	DerObjectIdentifier_t3495876513 * ___NoRevAvail_31;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Extensions::TargetInformation
	DerObjectIdentifier_t3495876513 * ___TargetInformation_32;

public:
	inline static int32_t get_offset_of_SubjectDirectoryAttributes_2() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___SubjectDirectoryAttributes_2)); }
	inline DerObjectIdentifier_t3495876513 * get_SubjectDirectoryAttributes_2() const { return ___SubjectDirectoryAttributes_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_SubjectDirectoryAttributes_2() { return &___SubjectDirectoryAttributes_2; }
	inline void set_SubjectDirectoryAttributes_2(DerObjectIdentifier_t3495876513 * value)
	{
		___SubjectDirectoryAttributes_2 = value;
		Il2CppCodeGenWriteBarrier(&___SubjectDirectoryAttributes_2, value);
	}

	inline static int32_t get_offset_of_SubjectKeyIdentifier_3() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___SubjectKeyIdentifier_3)); }
	inline DerObjectIdentifier_t3495876513 * get_SubjectKeyIdentifier_3() const { return ___SubjectKeyIdentifier_3; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_SubjectKeyIdentifier_3() { return &___SubjectKeyIdentifier_3; }
	inline void set_SubjectKeyIdentifier_3(DerObjectIdentifier_t3495876513 * value)
	{
		___SubjectKeyIdentifier_3 = value;
		Il2CppCodeGenWriteBarrier(&___SubjectKeyIdentifier_3, value);
	}

	inline static int32_t get_offset_of_KeyUsage_4() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___KeyUsage_4)); }
	inline DerObjectIdentifier_t3495876513 * get_KeyUsage_4() const { return ___KeyUsage_4; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_KeyUsage_4() { return &___KeyUsage_4; }
	inline void set_KeyUsage_4(DerObjectIdentifier_t3495876513 * value)
	{
		___KeyUsage_4 = value;
		Il2CppCodeGenWriteBarrier(&___KeyUsage_4, value);
	}

	inline static int32_t get_offset_of_PrivateKeyUsagePeriod_5() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___PrivateKeyUsagePeriod_5)); }
	inline DerObjectIdentifier_t3495876513 * get_PrivateKeyUsagePeriod_5() const { return ___PrivateKeyUsagePeriod_5; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PrivateKeyUsagePeriod_5() { return &___PrivateKeyUsagePeriod_5; }
	inline void set_PrivateKeyUsagePeriod_5(DerObjectIdentifier_t3495876513 * value)
	{
		___PrivateKeyUsagePeriod_5 = value;
		Il2CppCodeGenWriteBarrier(&___PrivateKeyUsagePeriod_5, value);
	}

	inline static int32_t get_offset_of_SubjectAlternativeName_6() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___SubjectAlternativeName_6)); }
	inline DerObjectIdentifier_t3495876513 * get_SubjectAlternativeName_6() const { return ___SubjectAlternativeName_6; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_SubjectAlternativeName_6() { return &___SubjectAlternativeName_6; }
	inline void set_SubjectAlternativeName_6(DerObjectIdentifier_t3495876513 * value)
	{
		___SubjectAlternativeName_6 = value;
		Il2CppCodeGenWriteBarrier(&___SubjectAlternativeName_6, value);
	}

	inline static int32_t get_offset_of_IssuerAlternativeName_7() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___IssuerAlternativeName_7)); }
	inline DerObjectIdentifier_t3495876513 * get_IssuerAlternativeName_7() const { return ___IssuerAlternativeName_7; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_IssuerAlternativeName_7() { return &___IssuerAlternativeName_7; }
	inline void set_IssuerAlternativeName_7(DerObjectIdentifier_t3495876513 * value)
	{
		___IssuerAlternativeName_7 = value;
		Il2CppCodeGenWriteBarrier(&___IssuerAlternativeName_7, value);
	}

	inline static int32_t get_offset_of_BasicConstraints_8() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___BasicConstraints_8)); }
	inline DerObjectIdentifier_t3495876513 * get_BasicConstraints_8() const { return ___BasicConstraints_8; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_BasicConstraints_8() { return &___BasicConstraints_8; }
	inline void set_BasicConstraints_8(DerObjectIdentifier_t3495876513 * value)
	{
		___BasicConstraints_8 = value;
		Il2CppCodeGenWriteBarrier(&___BasicConstraints_8, value);
	}

	inline static int32_t get_offset_of_CrlNumber_9() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___CrlNumber_9)); }
	inline DerObjectIdentifier_t3495876513 * get_CrlNumber_9() const { return ___CrlNumber_9; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CrlNumber_9() { return &___CrlNumber_9; }
	inline void set_CrlNumber_9(DerObjectIdentifier_t3495876513 * value)
	{
		___CrlNumber_9 = value;
		Il2CppCodeGenWriteBarrier(&___CrlNumber_9, value);
	}

	inline static int32_t get_offset_of_ReasonCode_10() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___ReasonCode_10)); }
	inline DerObjectIdentifier_t3495876513 * get_ReasonCode_10() const { return ___ReasonCode_10; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_ReasonCode_10() { return &___ReasonCode_10; }
	inline void set_ReasonCode_10(DerObjectIdentifier_t3495876513 * value)
	{
		___ReasonCode_10 = value;
		Il2CppCodeGenWriteBarrier(&___ReasonCode_10, value);
	}

	inline static int32_t get_offset_of_InstructionCode_11() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___InstructionCode_11)); }
	inline DerObjectIdentifier_t3495876513 * get_InstructionCode_11() const { return ___InstructionCode_11; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_InstructionCode_11() { return &___InstructionCode_11; }
	inline void set_InstructionCode_11(DerObjectIdentifier_t3495876513 * value)
	{
		___InstructionCode_11 = value;
		Il2CppCodeGenWriteBarrier(&___InstructionCode_11, value);
	}

	inline static int32_t get_offset_of_InvalidityDate_12() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___InvalidityDate_12)); }
	inline DerObjectIdentifier_t3495876513 * get_InvalidityDate_12() const { return ___InvalidityDate_12; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_InvalidityDate_12() { return &___InvalidityDate_12; }
	inline void set_InvalidityDate_12(DerObjectIdentifier_t3495876513 * value)
	{
		___InvalidityDate_12 = value;
		Il2CppCodeGenWriteBarrier(&___InvalidityDate_12, value);
	}

	inline static int32_t get_offset_of_DeltaCrlIndicator_13() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___DeltaCrlIndicator_13)); }
	inline DerObjectIdentifier_t3495876513 * get_DeltaCrlIndicator_13() const { return ___DeltaCrlIndicator_13; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_DeltaCrlIndicator_13() { return &___DeltaCrlIndicator_13; }
	inline void set_DeltaCrlIndicator_13(DerObjectIdentifier_t3495876513 * value)
	{
		___DeltaCrlIndicator_13 = value;
		Il2CppCodeGenWriteBarrier(&___DeltaCrlIndicator_13, value);
	}

	inline static int32_t get_offset_of_IssuingDistributionPoint_14() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___IssuingDistributionPoint_14)); }
	inline DerObjectIdentifier_t3495876513 * get_IssuingDistributionPoint_14() const { return ___IssuingDistributionPoint_14; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_IssuingDistributionPoint_14() { return &___IssuingDistributionPoint_14; }
	inline void set_IssuingDistributionPoint_14(DerObjectIdentifier_t3495876513 * value)
	{
		___IssuingDistributionPoint_14 = value;
		Il2CppCodeGenWriteBarrier(&___IssuingDistributionPoint_14, value);
	}

	inline static int32_t get_offset_of_CertificateIssuer_15() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___CertificateIssuer_15)); }
	inline DerObjectIdentifier_t3495876513 * get_CertificateIssuer_15() const { return ___CertificateIssuer_15; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CertificateIssuer_15() { return &___CertificateIssuer_15; }
	inline void set_CertificateIssuer_15(DerObjectIdentifier_t3495876513 * value)
	{
		___CertificateIssuer_15 = value;
		Il2CppCodeGenWriteBarrier(&___CertificateIssuer_15, value);
	}

	inline static int32_t get_offset_of_NameConstraints_16() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___NameConstraints_16)); }
	inline DerObjectIdentifier_t3495876513 * get_NameConstraints_16() const { return ___NameConstraints_16; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_NameConstraints_16() { return &___NameConstraints_16; }
	inline void set_NameConstraints_16(DerObjectIdentifier_t3495876513 * value)
	{
		___NameConstraints_16 = value;
		Il2CppCodeGenWriteBarrier(&___NameConstraints_16, value);
	}

	inline static int32_t get_offset_of_CrlDistributionPoints_17() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___CrlDistributionPoints_17)); }
	inline DerObjectIdentifier_t3495876513 * get_CrlDistributionPoints_17() const { return ___CrlDistributionPoints_17; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CrlDistributionPoints_17() { return &___CrlDistributionPoints_17; }
	inline void set_CrlDistributionPoints_17(DerObjectIdentifier_t3495876513 * value)
	{
		___CrlDistributionPoints_17 = value;
		Il2CppCodeGenWriteBarrier(&___CrlDistributionPoints_17, value);
	}

	inline static int32_t get_offset_of_CertificatePolicies_18() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___CertificatePolicies_18)); }
	inline DerObjectIdentifier_t3495876513 * get_CertificatePolicies_18() const { return ___CertificatePolicies_18; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CertificatePolicies_18() { return &___CertificatePolicies_18; }
	inline void set_CertificatePolicies_18(DerObjectIdentifier_t3495876513 * value)
	{
		___CertificatePolicies_18 = value;
		Il2CppCodeGenWriteBarrier(&___CertificatePolicies_18, value);
	}

	inline static int32_t get_offset_of_PolicyMappings_19() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___PolicyMappings_19)); }
	inline DerObjectIdentifier_t3495876513 * get_PolicyMappings_19() const { return ___PolicyMappings_19; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PolicyMappings_19() { return &___PolicyMappings_19; }
	inline void set_PolicyMappings_19(DerObjectIdentifier_t3495876513 * value)
	{
		___PolicyMappings_19 = value;
		Il2CppCodeGenWriteBarrier(&___PolicyMappings_19, value);
	}

	inline static int32_t get_offset_of_AuthorityKeyIdentifier_20() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___AuthorityKeyIdentifier_20)); }
	inline DerObjectIdentifier_t3495876513 * get_AuthorityKeyIdentifier_20() const { return ___AuthorityKeyIdentifier_20; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_AuthorityKeyIdentifier_20() { return &___AuthorityKeyIdentifier_20; }
	inline void set_AuthorityKeyIdentifier_20(DerObjectIdentifier_t3495876513 * value)
	{
		___AuthorityKeyIdentifier_20 = value;
		Il2CppCodeGenWriteBarrier(&___AuthorityKeyIdentifier_20, value);
	}

	inline static int32_t get_offset_of_PolicyConstraints_21() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___PolicyConstraints_21)); }
	inline DerObjectIdentifier_t3495876513 * get_PolicyConstraints_21() const { return ___PolicyConstraints_21; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PolicyConstraints_21() { return &___PolicyConstraints_21; }
	inline void set_PolicyConstraints_21(DerObjectIdentifier_t3495876513 * value)
	{
		___PolicyConstraints_21 = value;
		Il2CppCodeGenWriteBarrier(&___PolicyConstraints_21, value);
	}

	inline static int32_t get_offset_of_ExtendedKeyUsage_22() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___ExtendedKeyUsage_22)); }
	inline DerObjectIdentifier_t3495876513 * get_ExtendedKeyUsage_22() const { return ___ExtendedKeyUsage_22; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_ExtendedKeyUsage_22() { return &___ExtendedKeyUsage_22; }
	inline void set_ExtendedKeyUsage_22(DerObjectIdentifier_t3495876513 * value)
	{
		___ExtendedKeyUsage_22 = value;
		Il2CppCodeGenWriteBarrier(&___ExtendedKeyUsage_22, value);
	}

	inline static int32_t get_offset_of_FreshestCrl_23() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___FreshestCrl_23)); }
	inline DerObjectIdentifier_t3495876513 * get_FreshestCrl_23() const { return ___FreshestCrl_23; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_FreshestCrl_23() { return &___FreshestCrl_23; }
	inline void set_FreshestCrl_23(DerObjectIdentifier_t3495876513 * value)
	{
		___FreshestCrl_23 = value;
		Il2CppCodeGenWriteBarrier(&___FreshestCrl_23, value);
	}

	inline static int32_t get_offset_of_InhibitAnyPolicy_24() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___InhibitAnyPolicy_24)); }
	inline DerObjectIdentifier_t3495876513 * get_InhibitAnyPolicy_24() const { return ___InhibitAnyPolicy_24; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_InhibitAnyPolicy_24() { return &___InhibitAnyPolicy_24; }
	inline void set_InhibitAnyPolicy_24(DerObjectIdentifier_t3495876513 * value)
	{
		___InhibitAnyPolicy_24 = value;
		Il2CppCodeGenWriteBarrier(&___InhibitAnyPolicy_24, value);
	}

	inline static int32_t get_offset_of_AuthorityInfoAccess_25() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___AuthorityInfoAccess_25)); }
	inline DerObjectIdentifier_t3495876513 * get_AuthorityInfoAccess_25() const { return ___AuthorityInfoAccess_25; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_AuthorityInfoAccess_25() { return &___AuthorityInfoAccess_25; }
	inline void set_AuthorityInfoAccess_25(DerObjectIdentifier_t3495876513 * value)
	{
		___AuthorityInfoAccess_25 = value;
		Il2CppCodeGenWriteBarrier(&___AuthorityInfoAccess_25, value);
	}

	inline static int32_t get_offset_of_SubjectInfoAccess_26() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___SubjectInfoAccess_26)); }
	inline DerObjectIdentifier_t3495876513 * get_SubjectInfoAccess_26() const { return ___SubjectInfoAccess_26; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_SubjectInfoAccess_26() { return &___SubjectInfoAccess_26; }
	inline void set_SubjectInfoAccess_26(DerObjectIdentifier_t3495876513 * value)
	{
		___SubjectInfoAccess_26 = value;
		Il2CppCodeGenWriteBarrier(&___SubjectInfoAccess_26, value);
	}

	inline static int32_t get_offset_of_LogoType_27() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___LogoType_27)); }
	inline DerObjectIdentifier_t3495876513 * get_LogoType_27() const { return ___LogoType_27; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_LogoType_27() { return &___LogoType_27; }
	inline void set_LogoType_27(DerObjectIdentifier_t3495876513 * value)
	{
		___LogoType_27 = value;
		Il2CppCodeGenWriteBarrier(&___LogoType_27, value);
	}

	inline static int32_t get_offset_of_BiometricInfo_28() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___BiometricInfo_28)); }
	inline DerObjectIdentifier_t3495876513 * get_BiometricInfo_28() const { return ___BiometricInfo_28; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_BiometricInfo_28() { return &___BiometricInfo_28; }
	inline void set_BiometricInfo_28(DerObjectIdentifier_t3495876513 * value)
	{
		___BiometricInfo_28 = value;
		Il2CppCodeGenWriteBarrier(&___BiometricInfo_28, value);
	}

	inline static int32_t get_offset_of_QCStatements_29() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___QCStatements_29)); }
	inline DerObjectIdentifier_t3495876513 * get_QCStatements_29() const { return ___QCStatements_29; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_QCStatements_29() { return &___QCStatements_29; }
	inline void set_QCStatements_29(DerObjectIdentifier_t3495876513 * value)
	{
		___QCStatements_29 = value;
		Il2CppCodeGenWriteBarrier(&___QCStatements_29, value);
	}

	inline static int32_t get_offset_of_AuditIdentity_30() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___AuditIdentity_30)); }
	inline DerObjectIdentifier_t3495876513 * get_AuditIdentity_30() const { return ___AuditIdentity_30; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_AuditIdentity_30() { return &___AuditIdentity_30; }
	inline void set_AuditIdentity_30(DerObjectIdentifier_t3495876513 * value)
	{
		___AuditIdentity_30 = value;
		Il2CppCodeGenWriteBarrier(&___AuditIdentity_30, value);
	}

	inline static int32_t get_offset_of_NoRevAvail_31() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___NoRevAvail_31)); }
	inline DerObjectIdentifier_t3495876513 * get_NoRevAvail_31() const { return ___NoRevAvail_31; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_NoRevAvail_31() { return &___NoRevAvail_31; }
	inline void set_NoRevAvail_31(DerObjectIdentifier_t3495876513 * value)
	{
		___NoRevAvail_31 = value;
		Il2CppCodeGenWriteBarrier(&___NoRevAvail_31, value);
	}

	inline static int32_t get_offset_of_TargetInformation_32() { return static_cast<int32_t>(offsetof(X509Extensions_t1384530060_StaticFields, ___TargetInformation_32)); }
	inline DerObjectIdentifier_t3495876513 * get_TargetInformation_32() const { return ___TargetInformation_32; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_TargetInformation_32() { return &___TargetInformation_32; }
	inline void set_TargetInformation_32(DerObjectIdentifier_t3495876513 * value)
	{
		___TargetInformation_32 = value;
		Il2CppCodeGenWriteBarrier(&___TargetInformation_32, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
