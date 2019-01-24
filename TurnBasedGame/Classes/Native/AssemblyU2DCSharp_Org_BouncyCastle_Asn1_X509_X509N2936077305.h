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
// System.Boolean[]
struct BooleanU5BU5D_t3568034315;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Collections.IList
struct IList_t3321498491;
// Org.BouncyCastle.Asn1.X509.X509NameEntryConverter
struct X509NameEntryConverter_t1972691209;
// Org.BouncyCastle.Asn1.Asn1Sequence
struct Asn1Sequence_t54253652;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.X509Name
struct  X509Name_t2936077305  : public Asn1Encodable_t3447851422
{
public:
	// System.Collections.IList Org.BouncyCastle.Asn1.X509.X509Name::ordering
	Il2CppObject * ___ordering_41;
	// Org.BouncyCastle.Asn1.X509.X509NameEntryConverter Org.BouncyCastle.Asn1.X509.X509Name::converter
	X509NameEntryConverter_t1972691209 * ___converter_42;
	// System.Collections.IList Org.BouncyCastle.Asn1.X509.X509Name::values
	Il2CppObject * ___values_43;
	// System.Collections.IList Org.BouncyCastle.Asn1.X509.X509Name::added
	Il2CppObject * ___added_44;
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.X509.X509Name::seq
	Asn1Sequence_t54253652 * ___seq_45;

public:
	inline static int32_t get_offset_of_ordering_41() { return static_cast<int32_t>(offsetof(X509Name_t2936077305, ___ordering_41)); }
	inline Il2CppObject * get_ordering_41() const { return ___ordering_41; }
	inline Il2CppObject ** get_address_of_ordering_41() { return &___ordering_41; }
	inline void set_ordering_41(Il2CppObject * value)
	{
		___ordering_41 = value;
		Il2CppCodeGenWriteBarrier(&___ordering_41, value);
	}

	inline static int32_t get_offset_of_converter_42() { return static_cast<int32_t>(offsetof(X509Name_t2936077305, ___converter_42)); }
	inline X509NameEntryConverter_t1972691209 * get_converter_42() const { return ___converter_42; }
	inline X509NameEntryConverter_t1972691209 ** get_address_of_converter_42() { return &___converter_42; }
	inline void set_converter_42(X509NameEntryConverter_t1972691209 * value)
	{
		___converter_42 = value;
		Il2CppCodeGenWriteBarrier(&___converter_42, value);
	}

	inline static int32_t get_offset_of_values_43() { return static_cast<int32_t>(offsetof(X509Name_t2936077305, ___values_43)); }
	inline Il2CppObject * get_values_43() const { return ___values_43; }
	inline Il2CppObject ** get_address_of_values_43() { return &___values_43; }
	inline void set_values_43(Il2CppObject * value)
	{
		___values_43 = value;
		Il2CppCodeGenWriteBarrier(&___values_43, value);
	}

	inline static int32_t get_offset_of_added_44() { return static_cast<int32_t>(offsetof(X509Name_t2936077305, ___added_44)); }
	inline Il2CppObject * get_added_44() const { return ___added_44; }
	inline Il2CppObject ** get_address_of_added_44() { return &___added_44; }
	inline void set_added_44(Il2CppObject * value)
	{
		___added_44 = value;
		Il2CppCodeGenWriteBarrier(&___added_44, value);
	}

	inline static int32_t get_offset_of_seq_45() { return static_cast<int32_t>(offsetof(X509Name_t2936077305, ___seq_45)); }
	inline Asn1Sequence_t54253652 * get_seq_45() const { return ___seq_45; }
	inline Asn1Sequence_t54253652 ** get_address_of_seq_45() { return &___seq_45; }
	inline void set_seq_45(Asn1Sequence_t54253652 * value)
	{
		___seq_45 = value;
		Il2CppCodeGenWriteBarrier(&___seq_45, value);
	}
};

struct X509Name_t2936077305_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::C
	DerObjectIdentifier_t3495876513 * ___C_2;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::O
	DerObjectIdentifier_t3495876513 * ___O_3;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::OU
	DerObjectIdentifier_t3495876513 * ___OU_4;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::T
	DerObjectIdentifier_t3495876513 * ___T_5;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::CN
	DerObjectIdentifier_t3495876513 * ___CN_6;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Street
	DerObjectIdentifier_t3495876513 * ___Street_7;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::SerialNumber
	DerObjectIdentifier_t3495876513 * ___SerialNumber_8;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::L
	DerObjectIdentifier_t3495876513 * ___L_9;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::ST
	DerObjectIdentifier_t3495876513 * ___ST_10;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Surname
	DerObjectIdentifier_t3495876513 * ___Surname_11;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::GivenName
	DerObjectIdentifier_t3495876513 * ___GivenName_12;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Initials
	DerObjectIdentifier_t3495876513 * ___Initials_13;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Generation
	DerObjectIdentifier_t3495876513 * ___Generation_14;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::UniqueIdentifier
	DerObjectIdentifier_t3495876513 * ___UniqueIdentifier_15;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::BusinessCategory
	DerObjectIdentifier_t3495876513 * ___BusinessCategory_16;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::PostalCode
	DerObjectIdentifier_t3495876513 * ___PostalCode_17;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::DnQualifier
	DerObjectIdentifier_t3495876513 * ___DnQualifier_18;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Pseudonym
	DerObjectIdentifier_t3495876513 * ___Pseudonym_19;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::DateOfBirth
	DerObjectIdentifier_t3495876513 * ___DateOfBirth_20;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::PlaceOfBirth
	DerObjectIdentifier_t3495876513 * ___PlaceOfBirth_21;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Gender
	DerObjectIdentifier_t3495876513 * ___Gender_22;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::CountryOfCitizenship
	DerObjectIdentifier_t3495876513 * ___CountryOfCitizenship_23;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::CountryOfResidence
	DerObjectIdentifier_t3495876513 * ___CountryOfResidence_24;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::NameAtBirth
	DerObjectIdentifier_t3495876513 * ___NameAtBirth_25;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::PostalAddress
	DerObjectIdentifier_t3495876513 * ___PostalAddress_26;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::DmdName
	DerObjectIdentifier_t3495876513 * ___DmdName_27;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::TelephoneNumber
	DerObjectIdentifier_t3495876513 * ___TelephoneNumber_28;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::Name
	DerObjectIdentifier_t3495876513 * ___Name_29;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::EmailAddress
	DerObjectIdentifier_t3495876513 * ___EmailAddress_30;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::UnstructuredName
	DerObjectIdentifier_t3495876513 * ___UnstructuredName_31;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::UnstructuredAddress
	DerObjectIdentifier_t3495876513 * ___UnstructuredAddress_32;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::E
	DerObjectIdentifier_t3495876513 * ___E_33;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::DC
	DerObjectIdentifier_t3495876513 * ___DC_34;
	// Org.BouncyCastle.Asn1.DerObjectIdentifier Org.BouncyCastle.Asn1.X509.X509Name::UID
	DerObjectIdentifier_t3495876513 * ___UID_35;
	// System.Boolean[] Org.BouncyCastle.Asn1.X509.X509Name::defaultReverse
	BooleanU5BU5D_t3568034315* ___defaultReverse_36;
	// System.Collections.Hashtable Org.BouncyCastle.Asn1.X509.X509Name::DefaultSymbols
	Hashtable_t909839986 * ___DefaultSymbols_37;
	// System.Collections.Hashtable Org.BouncyCastle.Asn1.X509.X509Name::RFC2253Symbols
	Hashtable_t909839986 * ___RFC2253Symbols_38;
	// System.Collections.Hashtable Org.BouncyCastle.Asn1.X509.X509Name::RFC1779Symbols
	Hashtable_t909839986 * ___RFC1779Symbols_39;
	// System.Collections.Hashtable Org.BouncyCastle.Asn1.X509.X509Name::DefaultLookup
	Hashtable_t909839986 * ___DefaultLookup_40;

public:
	inline static int32_t get_offset_of_C_2() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___C_2)); }
	inline DerObjectIdentifier_t3495876513 * get_C_2() const { return ___C_2; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_C_2() { return &___C_2; }
	inline void set_C_2(DerObjectIdentifier_t3495876513 * value)
	{
		___C_2 = value;
		Il2CppCodeGenWriteBarrier(&___C_2, value);
	}

	inline static int32_t get_offset_of_O_3() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___O_3)); }
	inline DerObjectIdentifier_t3495876513 * get_O_3() const { return ___O_3; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_O_3() { return &___O_3; }
	inline void set_O_3(DerObjectIdentifier_t3495876513 * value)
	{
		___O_3 = value;
		Il2CppCodeGenWriteBarrier(&___O_3, value);
	}

	inline static int32_t get_offset_of_OU_4() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___OU_4)); }
	inline DerObjectIdentifier_t3495876513 * get_OU_4() const { return ___OU_4; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_OU_4() { return &___OU_4; }
	inline void set_OU_4(DerObjectIdentifier_t3495876513 * value)
	{
		___OU_4 = value;
		Il2CppCodeGenWriteBarrier(&___OU_4, value);
	}

	inline static int32_t get_offset_of_T_5() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___T_5)); }
	inline DerObjectIdentifier_t3495876513 * get_T_5() const { return ___T_5; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_T_5() { return &___T_5; }
	inline void set_T_5(DerObjectIdentifier_t3495876513 * value)
	{
		___T_5 = value;
		Il2CppCodeGenWriteBarrier(&___T_5, value);
	}

	inline static int32_t get_offset_of_CN_6() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___CN_6)); }
	inline DerObjectIdentifier_t3495876513 * get_CN_6() const { return ___CN_6; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CN_6() { return &___CN_6; }
	inline void set_CN_6(DerObjectIdentifier_t3495876513 * value)
	{
		___CN_6 = value;
		Il2CppCodeGenWriteBarrier(&___CN_6, value);
	}

	inline static int32_t get_offset_of_Street_7() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Street_7)); }
	inline DerObjectIdentifier_t3495876513 * get_Street_7() const { return ___Street_7; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Street_7() { return &___Street_7; }
	inline void set_Street_7(DerObjectIdentifier_t3495876513 * value)
	{
		___Street_7 = value;
		Il2CppCodeGenWriteBarrier(&___Street_7, value);
	}

	inline static int32_t get_offset_of_SerialNumber_8() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___SerialNumber_8)); }
	inline DerObjectIdentifier_t3495876513 * get_SerialNumber_8() const { return ___SerialNumber_8; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_SerialNumber_8() { return &___SerialNumber_8; }
	inline void set_SerialNumber_8(DerObjectIdentifier_t3495876513 * value)
	{
		___SerialNumber_8 = value;
		Il2CppCodeGenWriteBarrier(&___SerialNumber_8, value);
	}

	inline static int32_t get_offset_of_L_9() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___L_9)); }
	inline DerObjectIdentifier_t3495876513 * get_L_9() const { return ___L_9; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_L_9() { return &___L_9; }
	inline void set_L_9(DerObjectIdentifier_t3495876513 * value)
	{
		___L_9 = value;
		Il2CppCodeGenWriteBarrier(&___L_9, value);
	}

	inline static int32_t get_offset_of_ST_10() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___ST_10)); }
	inline DerObjectIdentifier_t3495876513 * get_ST_10() const { return ___ST_10; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_ST_10() { return &___ST_10; }
	inline void set_ST_10(DerObjectIdentifier_t3495876513 * value)
	{
		___ST_10 = value;
		Il2CppCodeGenWriteBarrier(&___ST_10, value);
	}

	inline static int32_t get_offset_of_Surname_11() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Surname_11)); }
	inline DerObjectIdentifier_t3495876513 * get_Surname_11() const { return ___Surname_11; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Surname_11() { return &___Surname_11; }
	inline void set_Surname_11(DerObjectIdentifier_t3495876513 * value)
	{
		___Surname_11 = value;
		Il2CppCodeGenWriteBarrier(&___Surname_11, value);
	}

	inline static int32_t get_offset_of_GivenName_12() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___GivenName_12)); }
	inline DerObjectIdentifier_t3495876513 * get_GivenName_12() const { return ___GivenName_12; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_GivenName_12() { return &___GivenName_12; }
	inline void set_GivenName_12(DerObjectIdentifier_t3495876513 * value)
	{
		___GivenName_12 = value;
		Il2CppCodeGenWriteBarrier(&___GivenName_12, value);
	}

	inline static int32_t get_offset_of_Initials_13() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Initials_13)); }
	inline DerObjectIdentifier_t3495876513 * get_Initials_13() const { return ___Initials_13; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Initials_13() { return &___Initials_13; }
	inline void set_Initials_13(DerObjectIdentifier_t3495876513 * value)
	{
		___Initials_13 = value;
		Il2CppCodeGenWriteBarrier(&___Initials_13, value);
	}

	inline static int32_t get_offset_of_Generation_14() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Generation_14)); }
	inline DerObjectIdentifier_t3495876513 * get_Generation_14() const { return ___Generation_14; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Generation_14() { return &___Generation_14; }
	inline void set_Generation_14(DerObjectIdentifier_t3495876513 * value)
	{
		___Generation_14 = value;
		Il2CppCodeGenWriteBarrier(&___Generation_14, value);
	}

	inline static int32_t get_offset_of_UniqueIdentifier_15() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___UniqueIdentifier_15)); }
	inline DerObjectIdentifier_t3495876513 * get_UniqueIdentifier_15() const { return ___UniqueIdentifier_15; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_UniqueIdentifier_15() { return &___UniqueIdentifier_15; }
	inline void set_UniqueIdentifier_15(DerObjectIdentifier_t3495876513 * value)
	{
		___UniqueIdentifier_15 = value;
		Il2CppCodeGenWriteBarrier(&___UniqueIdentifier_15, value);
	}

	inline static int32_t get_offset_of_BusinessCategory_16() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___BusinessCategory_16)); }
	inline DerObjectIdentifier_t3495876513 * get_BusinessCategory_16() const { return ___BusinessCategory_16; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_BusinessCategory_16() { return &___BusinessCategory_16; }
	inline void set_BusinessCategory_16(DerObjectIdentifier_t3495876513 * value)
	{
		___BusinessCategory_16 = value;
		Il2CppCodeGenWriteBarrier(&___BusinessCategory_16, value);
	}

	inline static int32_t get_offset_of_PostalCode_17() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___PostalCode_17)); }
	inline DerObjectIdentifier_t3495876513 * get_PostalCode_17() const { return ___PostalCode_17; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PostalCode_17() { return &___PostalCode_17; }
	inline void set_PostalCode_17(DerObjectIdentifier_t3495876513 * value)
	{
		___PostalCode_17 = value;
		Il2CppCodeGenWriteBarrier(&___PostalCode_17, value);
	}

	inline static int32_t get_offset_of_DnQualifier_18() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DnQualifier_18)); }
	inline DerObjectIdentifier_t3495876513 * get_DnQualifier_18() const { return ___DnQualifier_18; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_DnQualifier_18() { return &___DnQualifier_18; }
	inline void set_DnQualifier_18(DerObjectIdentifier_t3495876513 * value)
	{
		___DnQualifier_18 = value;
		Il2CppCodeGenWriteBarrier(&___DnQualifier_18, value);
	}

	inline static int32_t get_offset_of_Pseudonym_19() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Pseudonym_19)); }
	inline DerObjectIdentifier_t3495876513 * get_Pseudonym_19() const { return ___Pseudonym_19; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Pseudonym_19() { return &___Pseudonym_19; }
	inline void set_Pseudonym_19(DerObjectIdentifier_t3495876513 * value)
	{
		___Pseudonym_19 = value;
		Il2CppCodeGenWriteBarrier(&___Pseudonym_19, value);
	}

	inline static int32_t get_offset_of_DateOfBirth_20() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DateOfBirth_20)); }
	inline DerObjectIdentifier_t3495876513 * get_DateOfBirth_20() const { return ___DateOfBirth_20; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_DateOfBirth_20() { return &___DateOfBirth_20; }
	inline void set_DateOfBirth_20(DerObjectIdentifier_t3495876513 * value)
	{
		___DateOfBirth_20 = value;
		Il2CppCodeGenWriteBarrier(&___DateOfBirth_20, value);
	}

	inline static int32_t get_offset_of_PlaceOfBirth_21() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___PlaceOfBirth_21)); }
	inline DerObjectIdentifier_t3495876513 * get_PlaceOfBirth_21() const { return ___PlaceOfBirth_21; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PlaceOfBirth_21() { return &___PlaceOfBirth_21; }
	inline void set_PlaceOfBirth_21(DerObjectIdentifier_t3495876513 * value)
	{
		___PlaceOfBirth_21 = value;
		Il2CppCodeGenWriteBarrier(&___PlaceOfBirth_21, value);
	}

	inline static int32_t get_offset_of_Gender_22() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Gender_22)); }
	inline DerObjectIdentifier_t3495876513 * get_Gender_22() const { return ___Gender_22; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Gender_22() { return &___Gender_22; }
	inline void set_Gender_22(DerObjectIdentifier_t3495876513 * value)
	{
		___Gender_22 = value;
		Il2CppCodeGenWriteBarrier(&___Gender_22, value);
	}

	inline static int32_t get_offset_of_CountryOfCitizenship_23() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___CountryOfCitizenship_23)); }
	inline DerObjectIdentifier_t3495876513 * get_CountryOfCitizenship_23() const { return ___CountryOfCitizenship_23; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CountryOfCitizenship_23() { return &___CountryOfCitizenship_23; }
	inline void set_CountryOfCitizenship_23(DerObjectIdentifier_t3495876513 * value)
	{
		___CountryOfCitizenship_23 = value;
		Il2CppCodeGenWriteBarrier(&___CountryOfCitizenship_23, value);
	}

	inline static int32_t get_offset_of_CountryOfResidence_24() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___CountryOfResidence_24)); }
	inline DerObjectIdentifier_t3495876513 * get_CountryOfResidence_24() const { return ___CountryOfResidence_24; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_CountryOfResidence_24() { return &___CountryOfResidence_24; }
	inline void set_CountryOfResidence_24(DerObjectIdentifier_t3495876513 * value)
	{
		___CountryOfResidence_24 = value;
		Il2CppCodeGenWriteBarrier(&___CountryOfResidence_24, value);
	}

	inline static int32_t get_offset_of_NameAtBirth_25() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___NameAtBirth_25)); }
	inline DerObjectIdentifier_t3495876513 * get_NameAtBirth_25() const { return ___NameAtBirth_25; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_NameAtBirth_25() { return &___NameAtBirth_25; }
	inline void set_NameAtBirth_25(DerObjectIdentifier_t3495876513 * value)
	{
		___NameAtBirth_25 = value;
		Il2CppCodeGenWriteBarrier(&___NameAtBirth_25, value);
	}

	inline static int32_t get_offset_of_PostalAddress_26() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___PostalAddress_26)); }
	inline DerObjectIdentifier_t3495876513 * get_PostalAddress_26() const { return ___PostalAddress_26; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_PostalAddress_26() { return &___PostalAddress_26; }
	inline void set_PostalAddress_26(DerObjectIdentifier_t3495876513 * value)
	{
		___PostalAddress_26 = value;
		Il2CppCodeGenWriteBarrier(&___PostalAddress_26, value);
	}

	inline static int32_t get_offset_of_DmdName_27() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DmdName_27)); }
	inline DerObjectIdentifier_t3495876513 * get_DmdName_27() const { return ___DmdName_27; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_DmdName_27() { return &___DmdName_27; }
	inline void set_DmdName_27(DerObjectIdentifier_t3495876513 * value)
	{
		___DmdName_27 = value;
		Il2CppCodeGenWriteBarrier(&___DmdName_27, value);
	}

	inline static int32_t get_offset_of_TelephoneNumber_28() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___TelephoneNumber_28)); }
	inline DerObjectIdentifier_t3495876513 * get_TelephoneNumber_28() const { return ___TelephoneNumber_28; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_TelephoneNumber_28() { return &___TelephoneNumber_28; }
	inline void set_TelephoneNumber_28(DerObjectIdentifier_t3495876513 * value)
	{
		___TelephoneNumber_28 = value;
		Il2CppCodeGenWriteBarrier(&___TelephoneNumber_28, value);
	}

	inline static int32_t get_offset_of_Name_29() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___Name_29)); }
	inline DerObjectIdentifier_t3495876513 * get_Name_29() const { return ___Name_29; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_Name_29() { return &___Name_29; }
	inline void set_Name_29(DerObjectIdentifier_t3495876513 * value)
	{
		___Name_29 = value;
		Il2CppCodeGenWriteBarrier(&___Name_29, value);
	}

	inline static int32_t get_offset_of_EmailAddress_30() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___EmailAddress_30)); }
	inline DerObjectIdentifier_t3495876513 * get_EmailAddress_30() const { return ___EmailAddress_30; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_EmailAddress_30() { return &___EmailAddress_30; }
	inline void set_EmailAddress_30(DerObjectIdentifier_t3495876513 * value)
	{
		___EmailAddress_30 = value;
		Il2CppCodeGenWriteBarrier(&___EmailAddress_30, value);
	}

	inline static int32_t get_offset_of_UnstructuredName_31() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___UnstructuredName_31)); }
	inline DerObjectIdentifier_t3495876513 * get_UnstructuredName_31() const { return ___UnstructuredName_31; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_UnstructuredName_31() { return &___UnstructuredName_31; }
	inline void set_UnstructuredName_31(DerObjectIdentifier_t3495876513 * value)
	{
		___UnstructuredName_31 = value;
		Il2CppCodeGenWriteBarrier(&___UnstructuredName_31, value);
	}

	inline static int32_t get_offset_of_UnstructuredAddress_32() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___UnstructuredAddress_32)); }
	inline DerObjectIdentifier_t3495876513 * get_UnstructuredAddress_32() const { return ___UnstructuredAddress_32; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_UnstructuredAddress_32() { return &___UnstructuredAddress_32; }
	inline void set_UnstructuredAddress_32(DerObjectIdentifier_t3495876513 * value)
	{
		___UnstructuredAddress_32 = value;
		Il2CppCodeGenWriteBarrier(&___UnstructuredAddress_32, value);
	}

	inline static int32_t get_offset_of_E_33() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___E_33)); }
	inline DerObjectIdentifier_t3495876513 * get_E_33() const { return ___E_33; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_E_33() { return &___E_33; }
	inline void set_E_33(DerObjectIdentifier_t3495876513 * value)
	{
		___E_33 = value;
		Il2CppCodeGenWriteBarrier(&___E_33, value);
	}

	inline static int32_t get_offset_of_DC_34() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DC_34)); }
	inline DerObjectIdentifier_t3495876513 * get_DC_34() const { return ___DC_34; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_DC_34() { return &___DC_34; }
	inline void set_DC_34(DerObjectIdentifier_t3495876513 * value)
	{
		___DC_34 = value;
		Il2CppCodeGenWriteBarrier(&___DC_34, value);
	}

	inline static int32_t get_offset_of_UID_35() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___UID_35)); }
	inline DerObjectIdentifier_t3495876513 * get_UID_35() const { return ___UID_35; }
	inline DerObjectIdentifier_t3495876513 ** get_address_of_UID_35() { return &___UID_35; }
	inline void set_UID_35(DerObjectIdentifier_t3495876513 * value)
	{
		___UID_35 = value;
		Il2CppCodeGenWriteBarrier(&___UID_35, value);
	}

	inline static int32_t get_offset_of_defaultReverse_36() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___defaultReverse_36)); }
	inline BooleanU5BU5D_t3568034315* get_defaultReverse_36() const { return ___defaultReverse_36; }
	inline BooleanU5BU5D_t3568034315** get_address_of_defaultReverse_36() { return &___defaultReverse_36; }
	inline void set_defaultReverse_36(BooleanU5BU5D_t3568034315* value)
	{
		___defaultReverse_36 = value;
		Il2CppCodeGenWriteBarrier(&___defaultReverse_36, value);
	}

	inline static int32_t get_offset_of_DefaultSymbols_37() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DefaultSymbols_37)); }
	inline Hashtable_t909839986 * get_DefaultSymbols_37() const { return ___DefaultSymbols_37; }
	inline Hashtable_t909839986 ** get_address_of_DefaultSymbols_37() { return &___DefaultSymbols_37; }
	inline void set_DefaultSymbols_37(Hashtable_t909839986 * value)
	{
		___DefaultSymbols_37 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultSymbols_37, value);
	}

	inline static int32_t get_offset_of_RFC2253Symbols_38() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___RFC2253Symbols_38)); }
	inline Hashtable_t909839986 * get_RFC2253Symbols_38() const { return ___RFC2253Symbols_38; }
	inline Hashtable_t909839986 ** get_address_of_RFC2253Symbols_38() { return &___RFC2253Symbols_38; }
	inline void set_RFC2253Symbols_38(Hashtable_t909839986 * value)
	{
		___RFC2253Symbols_38 = value;
		Il2CppCodeGenWriteBarrier(&___RFC2253Symbols_38, value);
	}

	inline static int32_t get_offset_of_RFC1779Symbols_39() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___RFC1779Symbols_39)); }
	inline Hashtable_t909839986 * get_RFC1779Symbols_39() const { return ___RFC1779Symbols_39; }
	inline Hashtable_t909839986 ** get_address_of_RFC1779Symbols_39() { return &___RFC1779Symbols_39; }
	inline void set_RFC1779Symbols_39(Hashtable_t909839986 * value)
	{
		___RFC1779Symbols_39 = value;
		Il2CppCodeGenWriteBarrier(&___RFC1779Symbols_39, value);
	}

	inline static int32_t get_offset_of_DefaultLookup_40() { return static_cast<int32_t>(offsetof(X509Name_t2936077305_StaticFields, ___DefaultLookup_40)); }
	inline Hashtable_t909839986 * get_DefaultLookup_40() const { return ___DefaultLookup_40; }
	inline Hashtable_t909839986 ** get_address_of_DefaultLookup_40() { return &___DefaultLookup_40; }
	inline void set_DefaultLookup_40(Hashtable_t909839986 * value)
	{
		___DefaultLookup_40 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultLookup_40, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
