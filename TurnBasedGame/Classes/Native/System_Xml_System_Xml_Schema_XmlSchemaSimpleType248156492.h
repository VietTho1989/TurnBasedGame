#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_Schema_XmlSchemaType1795078578.h"
#include "System_Xml_System_Xml_Schema_XmlSchemaDerivationMe3165007540.h"

// System.Xml.Schema.XmlSchemaSimpleType
struct XmlSchemaSimpleType_t248156492;
// System.Xml.Schema.XmlSchemaSimpleTypeContent
struct XmlSchemaSimpleTypeContent_t1606103299;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaSimpleType
struct  XmlSchemaSimpleType_t248156492  : public XmlSchemaType_t1795078578
{
public:
	// System.Xml.Schema.XmlSchemaSimpleTypeContent System.Xml.Schema.XmlSchemaSimpleType::content
	XmlSchemaSimpleTypeContent_t1606103299 * ___content_29;
	// System.Boolean System.Xml.Schema.XmlSchemaSimpleType::islocal
	bool ___islocal_30;
	// System.Boolean System.Xml.Schema.XmlSchemaSimpleType::recursed
	bool ___recursed_31;
	// System.Xml.Schema.XmlSchemaDerivationMethod System.Xml.Schema.XmlSchemaSimpleType::variety
	int32_t ___variety_32;

public:
	inline static int32_t get_offset_of_content_29() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492, ___content_29)); }
	inline XmlSchemaSimpleTypeContent_t1606103299 * get_content_29() const { return ___content_29; }
	inline XmlSchemaSimpleTypeContent_t1606103299 ** get_address_of_content_29() { return &___content_29; }
	inline void set_content_29(XmlSchemaSimpleTypeContent_t1606103299 * value)
	{
		___content_29 = value;
		Il2CppCodeGenWriteBarrier(&___content_29, value);
	}

	inline static int32_t get_offset_of_islocal_30() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492, ___islocal_30)); }
	inline bool get_islocal_30() const { return ___islocal_30; }
	inline bool* get_address_of_islocal_30() { return &___islocal_30; }
	inline void set_islocal_30(bool value)
	{
		___islocal_30 = value;
	}

	inline static int32_t get_offset_of_recursed_31() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492, ___recursed_31)); }
	inline bool get_recursed_31() const { return ___recursed_31; }
	inline bool* get_address_of_recursed_31() { return &___recursed_31; }
	inline void set_recursed_31(bool value)
	{
		___recursed_31 = value;
	}

	inline static int32_t get_offset_of_variety_32() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492, ___variety_32)); }
	inline int32_t get_variety_32() const { return ___variety_32; }
	inline int32_t* get_address_of_variety_32() { return &___variety_32; }
	inline void set_variety_32(int32_t value)
	{
		___variety_32 = value;
	}
};

struct XmlSchemaSimpleType_t248156492_StaticFields
{
public:
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::schemaLocationType
	XmlSchemaSimpleType_t248156492 * ___schemaLocationType_28;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsAnySimpleType
	XmlSchemaSimpleType_t248156492 * ___XsAnySimpleType_33;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsString
	XmlSchemaSimpleType_t248156492 * ___XsString_34;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsBoolean
	XmlSchemaSimpleType_t248156492 * ___XsBoolean_35;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsDecimal
	XmlSchemaSimpleType_t248156492 * ___XsDecimal_36;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsFloat
	XmlSchemaSimpleType_t248156492 * ___XsFloat_37;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsDouble
	XmlSchemaSimpleType_t248156492 * ___XsDouble_38;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsDuration
	XmlSchemaSimpleType_t248156492 * ___XsDuration_39;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsDateTime
	XmlSchemaSimpleType_t248156492 * ___XsDateTime_40;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsTime
	XmlSchemaSimpleType_t248156492 * ___XsTime_41;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsDate
	XmlSchemaSimpleType_t248156492 * ___XsDate_42;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsGYearMonth
	XmlSchemaSimpleType_t248156492 * ___XsGYearMonth_43;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsGYear
	XmlSchemaSimpleType_t248156492 * ___XsGYear_44;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsGMonthDay
	XmlSchemaSimpleType_t248156492 * ___XsGMonthDay_45;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsGDay
	XmlSchemaSimpleType_t248156492 * ___XsGDay_46;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsGMonth
	XmlSchemaSimpleType_t248156492 * ___XsGMonth_47;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsHexBinary
	XmlSchemaSimpleType_t248156492 * ___XsHexBinary_48;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsBase64Binary
	XmlSchemaSimpleType_t248156492 * ___XsBase64Binary_49;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsAnyUri
	XmlSchemaSimpleType_t248156492 * ___XsAnyUri_50;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsQName
	XmlSchemaSimpleType_t248156492 * ___XsQName_51;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNotation
	XmlSchemaSimpleType_t248156492 * ___XsNotation_52;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNormalizedString
	XmlSchemaSimpleType_t248156492 * ___XsNormalizedString_53;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsToken
	XmlSchemaSimpleType_t248156492 * ___XsToken_54;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsLanguage
	XmlSchemaSimpleType_t248156492 * ___XsLanguage_55;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNMToken
	XmlSchemaSimpleType_t248156492 * ___XsNMToken_56;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNMTokens
	XmlSchemaSimpleType_t248156492 * ___XsNMTokens_57;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsName
	XmlSchemaSimpleType_t248156492 * ___XsName_58;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNCName
	XmlSchemaSimpleType_t248156492 * ___XsNCName_59;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsID
	XmlSchemaSimpleType_t248156492 * ___XsID_60;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsIDRef
	XmlSchemaSimpleType_t248156492 * ___XsIDRef_61;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsIDRefs
	XmlSchemaSimpleType_t248156492 * ___XsIDRefs_62;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsEntity
	XmlSchemaSimpleType_t248156492 * ___XsEntity_63;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsEntities
	XmlSchemaSimpleType_t248156492 * ___XsEntities_64;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsInteger
	XmlSchemaSimpleType_t248156492 * ___XsInteger_65;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNonPositiveInteger
	XmlSchemaSimpleType_t248156492 * ___XsNonPositiveInteger_66;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNegativeInteger
	XmlSchemaSimpleType_t248156492 * ___XsNegativeInteger_67;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsLong
	XmlSchemaSimpleType_t248156492 * ___XsLong_68;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsInt
	XmlSchemaSimpleType_t248156492 * ___XsInt_69;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsShort
	XmlSchemaSimpleType_t248156492 * ___XsShort_70;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsByte
	XmlSchemaSimpleType_t248156492 * ___XsByte_71;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsNonNegativeInteger
	XmlSchemaSimpleType_t248156492 * ___XsNonNegativeInteger_72;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsUnsignedLong
	XmlSchemaSimpleType_t248156492 * ___XsUnsignedLong_73;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsUnsignedInt
	XmlSchemaSimpleType_t248156492 * ___XsUnsignedInt_74;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsUnsignedShort
	XmlSchemaSimpleType_t248156492 * ___XsUnsignedShort_75;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsUnsignedByte
	XmlSchemaSimpleType_t248156492 * ___XsUnsignedByte_76;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XsPositiveInteger
	XmlSchemaSimpleType_t248156492 * ___XsPositiveInteger_77;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XdtUntypedAtomic
	XmlSchemaSimpleType_t248156492 * ___XdtUntypedAtomic_78;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XdtAnyAtomicType
	XmlSchemaSimpleType_t248156492 * ___XdtAnyAtomicType_79;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XdtYearMonthDuration
	XmlSchemaSimpleType_t248156492 * ___XdtYearMonthDuration_80;
	// System.Xml.Schema.XmlSchemaSimpleType System.Xml.Schema.XmlSchemaSimpleType::XdtDayTimeDuration
	XmlSchemaSimpleType_t248156492 * ___XdtDayTimeDuration_81;

public:
	inline static int32_t get_offset_of_schemaLocationType_28() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___schemaLocationType_28)); }
	inline XmlSchemaSimpleType_t248156492 * get_schemaLocationType_28() const { return ___schemaLocationType_28; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_schemaLocationType_28() { return &___schemaLocationType_28; }
	inline void set_schemaLocationType_28(XmlSchemaSimpleType_t248156492 * value)
	{
		___schemaLocationType_28 = value;
		Il2CppCodeGenWriteBarrier(&___schemaLocationType_28, value);
	}

	inline static int32_t get_offset_of_XsAnySimpleType_33() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsAnySimpleType_33)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsAnySimpleType_33() const { return ___XsAnySimpleType_33; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsAnySimpleType_33() { return &___XsAnySimpleType_33; }
	inline void set_XsAnySimpleType_33(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsAnySimpleType_33 = value;
		Il2CppCodeGenWriteBarrier(&___XsAnySimpleType_33, value);
	}

	inline static int32_t get_offset_of_XsString_34() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsString_34)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsString_34() const { return ___XsString_34; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsString_34() { return &___XsString_34; }
	inline void set_XsString_34(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsString_34 = value;
		Il2CppCodeGenWriteBarrier(&___XsString_34, value);
	}

	inline static int32_t get_offset_of_XsBoolean_35() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsBoolean_35)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsBoolean_35() const { return ___XsBoolean_35; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsBoolean_35() { return &___XsBoolean_35; }
	inline void set_XsBoolean_35(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsBoolean_35 = value;
		Il2CppCodeGenWriteBarrier(&___XsBoolean_35, value);
	}

	inline static int32_t get_offset_of_XsDecimal_36() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsDecimal_36)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsDecimal_36() const { return ___XsDecimal_36; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsDecimal_36() { return &___XsDecimal_36; }
	inline void set_XsDecimal_36(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsDecimal_36 = value;
		Il2CppCodeGenWriteBarrier(&___XsDecimal_36, value);
	}

	inline static int32_t get_offset_of_XsFloat_37() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsFloat_37)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsFloat_37() const { return ___XsFloat_37; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsFloat_37() { return &___XsFloat_37; }
	inline void set_XsFloat_37(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsFloat_37 = value;
		Il2CppCodeGenWriteBarrier(&___XsFloat_37, value);
	}

	inline static int32_t get_offset_of_XsDouble_38() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsDouble_38)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsDouble_38() const { return ___XsDouble_38; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsDouble_38() { return &___XsDouble_38; }
	inline void set_XsDouble_38(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsDouble_38 = value;
		Il2CppCodeGenWriteBarrier(&___XsDouble_38, value);
	}

	inline static int32_t get_offset_of_XsDuration_39() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsDuration_39)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsDuration_39() const { return ___XsDuration_39; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsDuration_39() { return &___XsDuration_39; }
	inline void set_XsDuration_39(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsDuration_39 = value;
		Il2CppCodeGenWriteBarrier(&___XsDuration_39, value);
	}

	inline static int32_t get_offset_of_XsDateTime_40() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsDateTime_40)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsDateTime_40() const { return ___XsDateTime_40; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsDateTime_40() { return &___XsDateTime_40; }
	inline void set_XsDateTime_40(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsDateTime_40 = value;
		Il2CppCodeGenWriteBarrier(&___XsDateTime_40, value);
	}

	inline static int32_t get_offset_of_XsTime_41() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsTime_41)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsTime_41() const { return ___XsTime_41; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsTime_41() { return &___XsTime_41; }
	inline void set_XsTime_41(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsTime_41 = value;
		Il2CppCodeGenWriteBarrier(&___XsTime_41, value);
	}

	inline static int32_t get_offset_of_XsDate_42() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsDate_42)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsDate_42() const { return ___XsDate_42; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsDate_42() { return &___XsDate_42; }
	inline void set_XsDate_42(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsDate_42 = value;
		Il2CppCodeGenWriteBarrier(&___XsDate_42, value);
	}

	inline static int32_t get_offset_of_XsGYearMonth_43() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsGYearMonth_43)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsGYearMonth_43() const { return ___XsGYearMonth_43; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsGYearMonth_43() { return &___XsGYearMonth_43; }
	inline void set_XsGYearMonth_43(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsGYearMonth_43 = value;
		Il2CppCodeGenWriteBarrier(&___XsGYearMonth_43, value);
	}

	inline static int32_t get_offset_of_XsGYear_44() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsGYear_44)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsGYear_44() const { return ___XsGYear_44; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsGYear_44() { return &___XsGYear_44; }
	inline void set_XsGYear_44(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsGYear_44 = value;
		Il2CppCodeGenWriteBarrier(&___XsGYear_44, value);
	}

	inline static int32_t get_offset_of_XsGMonthDay_45() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsGMonthDay_45)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsGMonthDay_45() const { return ___XsGMonthDay_45; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsGMonthDay_45() { return &___XsGMonthDay_45; }
	inline void set_XsGMonthDay_45(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsGMonthDay_45 = value;
		Il2CppCodeGenWriteBarrier(&___XsGMonthDay_45, value);
	}

	inline static int32_t get_offset_of_XsGDay_46() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsGDay_46)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsGDay_46() const { return ___XsGDay_46; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsGDay_46() { return &___XsGDay_46; }
	inline void set_XsGDay_46(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsGDay_46 = value;
		Il2CppCodeGenWriteBarrier(&___XsGDay_46, value);
	}

	inline static int32_t get_offset_of_XsGMonth_47() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsGMonth_47)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsGMonth_47() const { return ___XsGMonth_47; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsGMonth_47() { return &___XsGMonth_47; }
	inline void set_XsGMonth_47(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsGMonth_47 = value;
		Il2CppCodeGenWriteBarrier(&___XsGMonth_47, value);
	}

	inline static int32_t get_offset_of_XsHexBinary_48() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsHexBinary_48)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsHexBinary_48() const { return ___XsHexBinary_48; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsHexBinary_48() { return &___XsHexBinary_48; }
	inline void set_XsHexBinary_48(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsHexBinary_48 = value;
		Il2CppCodeGenWriteBarrier(&___XsHexBinary_48, value);
	}

	inline static int32_t get_offset_of_XsBase64Binary_49() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsBase64Binary_49)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsBase64Binary_49() const { return ___XsBase64Binary_49; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsBase64Binary_49() { return &___XsBase64Binary_49; }
	inline void set_XsBase64Binary_49(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsBase64Binary_49 = value;
		Il2CppCodeGenWriteBarrier(&___XsBase64Binary_49, value);
	}

	inline static int32_t get_offset_of_XsAnyUri_50() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsAnyUri_50)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsAnyUri_50() const { return ___XsAnyUri_50; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsAnyUri_50() { return &___XsAnyUri_50; }
	inline void set_XsAnyUri_50(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsAnyUri_50 = value;
		Il2CppCodeGenWriteBarrier(&___XsAnyUri_50, value);
	}

	inline static int32_t get_offset_of_XsQName_51() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsQName_51)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsQName_51() const { return ___XsQName_51; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsQName_51() { return &___XsQName_51; }
	inline void set_XsQName_51(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsQName_51 = value;
		Il2CppCodeGenWriteBarrier(&___XsQName_51, value);
	}

	inline static int32_t get_offset_of_XsNotation_52() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNotation_52)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNotation_52() const { return ___XsNotation_52; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNotation_52() { return &___XsNotation_52; }
	inline void set_XsNotation_52(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNotation_52 = value;
		Il2CppCodeGenWriteBarrier(&___XsNotation_52, value);
	}

	inline static int32_t get_offset_of_XsNormalizedString_53() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNormalizedString_53)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNormalizedString_53() const { return ___XsNormalizedString_53; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNormalizedString_53() { return &___XsNormalizedString_53; }
	inline void set_XsNormalizedString_53(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNormalizedString_53 = value;
		Il2CppCodeGenWriteBarrier(&___XsNormalizedString_53, value);
	}

	inline static int32_t get_offset_of_XsToken_54() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsToken_54)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsToken_54() const { return ___XsToken_54; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsToken_54() { return &___XsToken_54; }
	inline void set_XsToken_54(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsToken_54 = value;
		Il2CppCodeGenWriteBarrier(&___XsToken_54, value);
	}

	inline static int32_t get_offset_of_XsLanguage_55() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsLanguage_55)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsLanguage_55() const { return ___XsLanguage_55; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsLanguage_55() { return &___XsLanguage_55; }
	inline void set_XsLanguage_55(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsLanguage_55 = value;
		Il2CppCodeGenWriteBarrier(&___XsLanguage_55, value);
	}

	inline static int32_t get_offset_of_XsNMToken_56() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNMToken_56)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNMToken_56() const { return ___XsNMToken_56; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNMToken_56() { return &___XsNMToken_56; }
	inline void set_XsNMToken_56(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNMToken_56 = value;
		Il2CppCodeGenWriteBarrier(&___XsNMToken_56, value);
	}

	inline static int32_t get_offset_of_XsNMTokens_57() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNMTokens_57)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNMTokens_57() const { return ___XsNMTokens_57; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNMTokens_57() { return &___XsNMTokens_57; }
	inline void set_XsNMTokens_57(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNMTokens_57 = value;
		Il2CppCodeGenWriteBarrier(&___XsNMTokens_57, value);
	}

	inline static int32_t get_offset_of_XsName_58() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsName_58)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsName_58() const { return ___XsName_58; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsName_58() { return &___XsName_58; }
	inline void set_XsName_58(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsName_58 = value;
		Il2CppCodeGenWriteBarrier(&___XsName_58, value);
	}

	inline static int32_t get_offset_of_XsNCName_59() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNCName_59)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNCName_59() const { return ___XsNCName_59; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNCName_59() { return &___XsNCName_59; }
	inline void set_XsNCName_59(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNCName_59 = value;
		Il2CppCodeGenWriteBarrier(&___XsNCName_59, value);
	}

	inline static int32_t get_offset_of_XsID_60() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsID_60)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsID_60() const { return ___XsID_60; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsID_60() { return &___XsID_60; }
	inline void set_XsID_60(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsID_60 = value;
		Il2CppCodeGenWriteBarrier(&___XsID_60, value);
	}

	inline static int32_t get_offset_of_XsIDRef_61() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsIDRef_61)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsIDRef_61() const { return ___XsIDRef_61; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsIDRef_61() { return &___XsIDRef_61; }
	inline void set_XsIDRef_61(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsIDRef_61 = value;
		Il2CppCodeGenWriteBarrier(&___XsIDRef_61, value);
	}

	inline static int32_t get_offset_of_XsIDRefs_62() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsIDRefs_62)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsIDRefs_62() const { return ___XsIDRefs_62; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsIDRefs_62() { return &___XsIDRefs_62; }
	inline void set_XsIDRefs_62(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsIDRefs_62 = value;
		Il2CppCodeGenWriteBarrier(&___XsIDRefs_62, value);
	}

	inline static int32_t get_offset_of_XsEntity_63() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsEntity_63)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsEntity_63() const { return ___XsEntity_63; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsEntity_63() { return &___XsEntity_63; }
	inline void set_XsEntity_63(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsEntity_63 = value;
		Il2CppCodeGenWriteBarrier(&___XsEntity_63, value);
	}

	inline static int32_t get_offset_of_XsEntities_64() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsEntities_64)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsEntities_64() const { return ___XsEntities_64; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsEntities_64() { return &___XsEntities_64; }
	inline void set_XsEntities_64(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsEntities_64 = value;
		Il2CppCodeGenWriteBarrier(&___XsEntities_64, value);
	}

	inline static int32_t get_offset_of_XsInteger_65() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsInteger_65)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsInteger_65() const { return ___XsInteger_65; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsInteger_65() { return &___XsInteger_65; }
	inline void set_XsInteger_65(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsInteger_65 = value;
		Il2CppCodeGenWriteBarrier(&___XsInteger_65, value);
	}

	inline static int32_t get_offset_of_XsNonPositiveInteger_66() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNonPositiveInteger_66)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNonPositiveInteger_66() const { return ___XsNonPositiveInteger_66; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNonPositiveInteger_66() { return &___XsNonPositiveInteger_66; }
	inline void set_XsNonPositiveInteger_66(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNonPositiveInteger_66 = value;
		Il2CppCodeGenWriteBarrier(&___XsNonPositiveInteger_66, value);
	}

	inline static int32_t get_offset_of_XsNegativeInteger_67() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNegativeInteger_67)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNegativeInteger_67() const { return ___XsNegativeInteger_67; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNegativeInteger_67() { return &___XsNegativeInteger_67; }
	inline void set_XsNegativeInteger_67(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNegativeInteger_67 = value;
		Il2CppCodeGenWriteBarrier(&___XsNegativeInteger_67, value);
	}

	inline static int32_t get_offset_of_XsLong_68() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsLong_68)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsLong_68() const { return ___XsLong_68; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsLong_68() { return &___XsLong_68; }
	inline void set_XsLong_68(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsLong_68 = value;
		Il2CppCodeGenWriteBarrier(&___XsLong_68, value);
	}

	inline static int32_t get_offset_of_XsInt_69() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsInt_69)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsInt_69() const { return ___XsInt_69; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsInt_69() { return &___XsInt_69; }
	inline void set_XsInt_69(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsInt_69 = value;
		Il2CppCodeGenWriteBarrier(&___XsInt_69, value);
	}

	inline static int32_t get_offset_of_XsShort_70() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsShort_70)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsShort_70() const { return ___XsShort_70; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsShort_70() { return &___XsShort_70; }
	inline void set_XsShort_70(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsShort_70 = value;
		Il2CppCodeGenWriteBarrier(&___XsShort_70, value);
	}

	inline static int32_t get_offset_of_XsByte_71() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsByte_71)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsByte_71() const { return ___XsByte_71; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsByte_71() { return &___XsByte_71; }
	inline void set_XsByte_71(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsByte_71 = value;
		Il2CppCodeGenWriteBarrier(&___XsByte_71, value);
	}

	inline static int32_t get_offset_of_XsNonNegativeInteger_72() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsNonNegativeInteger_72)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsNonNegativeInteger_72() const { return ___XsNonNegativeInteger_72; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsNonNegativeInteger_72() { return &___XsNonNegativeInteger_72; }
	inline void set_XsNonNegativeInteger_72(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsNonNegativeInteger_72 = value;
		Il2CppCodeGenWriteBarrier(&___XsNonNegativeInteger_72, value);
	}

	inline static int32_t get_offset_of_XsUnsignedLong_73() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsUnsignedLong_73)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsUnsignedLong_73() const { return ___XsUnsignedLong_73; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsUnsignedLong_73() { return &___XsUnsignedLong_73; }
	inline void set_XsUnsignedLong_73(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsUnsignedLong_73 = value;
		Il2CppCodeGenWriteBarrier(&___XsUnsignedLong_73, value);
	}

	inline static int32_t get_offset_of_XsUnsignedInt_74() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsUnsignedInt_74)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsUnsignedInt_74() const { return ___XsUnsignedInt_74; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsUnsignedInt_74() { return &___XsUnsignedInt_74; }
	inline void set_XsUnsignedInt_74(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsUnsignedInt_74 = value;
		Il2CppCodeGenWriteBarrier(&___XsUnsignedInt_74, value);
	}

	inline static int32_t get_offset_of_XsUnsignedShort_75() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsUnsignedShort_75)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsUnsignedShort_75() const { return ___XsUnsignedShort_75; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsUnsignedShort_75() { return &___XsUnsignedShort_75; }
	inline void set_XsUnsignedShort_75(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsUnsignedShort_75 = value;
		Il2CppCodeGenWriteBarrier(&___XsUnsignedShort_75, value);
	}

	inline static int32_t get_offset_of_XsUnsignedByte_76() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsUnsignedByte_76)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsUnsignedByte_76() const { return ___XsUnsignedByte_76; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsUnsignedByte_76() { return &___XsUnsignedByte_76; }
	inline void set_XsUnsignedByte_76(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsUnsignedByte_76 = value;
		Il2CppCodeGenWriteBarrier(&___XsUnsignedByte_76, value);
	}

	inline static int32_t get_offset_of_XsPositiveInteger_77() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XsPositiveInteger_77)); }
	inline XmlSchemaSimpleType_t248156492 * get_XsPositiveInteger_77() const { return ___XsPositiveInteger_77; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XsPositiveInteger_77() { return &___XsPositiveInteger_77; }
	inline void set_XsPositiveInteger_77(XmlSchemaSimpleType_t248156492 * value)
	{
		___XsPositiveInteger_77 = value;
		Il2CppCodeGenWriteBarrier(&___XsPositiveInteger_77, value);
	}

	inline static int32_t get_offset_of_XdtUntypedAtomic_78() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XdtUntypedAtomic_78)); }
	inline XmlSchemaSimpleType_t248156492 * get_XdtUntypedAtomic_78() const { return ___XdtUntypedAtomic_78; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XdtUntypedAtomic_78() { return &___XdtUntypedAtomic_78; }
	inline void set_XdtUntypedAtomic_78(XmlSchemaSimpleType_t248156492 * value)
	{
		___XdtUntypedAtomic_78 = value;
		Il2CppCodeGenWriteBarrier(&___XdtUntypedAtomic_78, value);
	}

	inline static int32_t get_offset_of_XdtAnyAtomicType_79() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XdtAnyAtomicType_79)); }
	inline XmlSchemaSimpleType_t248156492 * get_XdtAnyAtomicType_79() const { return ___XdtAnyAtomicType_79; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XdtAnyAtomicType_79() { return &___XdtAnyAtomicType_79; }
	inline void set_XdtAnyAtomicType_79(XmlSchemaSimpleType_t248156492 * value)
	{
		___XdtAnyAtomicType_79 = value;
		Il2CppCodeGenWriteBarrier(&___XdtAnyAtomicType_79, value);
	}

	inline static int32_t get_offset_of_XdtYearMonthDuration_80() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XdtYearMonthDuration_80)); }
	inline XmlSchemaSimpleType_t248156492 * get_XdtYearMonthDuration_80() const { return ___XdtYearMonthDuration_80; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XdtYearMonthDuration_80() { return &___XdtYearMonthDuration_80; }
	inline void set_XdtYearMonthDuration_80(XmlSchemaSimpleType_t248156492 * value)
	{
		___XdtYearMonthDuration_80 = value;
		Il2CppCodeGenWriteBarrier(&___XdtYearMonthDuration_80, value);
	}

	inline static int32_t get_offset_of_XdtDayTimeDuration_81() { return static_cast<int32_t>(offsetof(XmlSchemaSimpleType_t248156492_StaticFields, ___XdtDayTimeDuration_81)); }
	inline XmlSchemaSimpleType_t248156492 * get_XdtDayTimeDuration_81() const { return ___XdtDayTimeDuration_81; }
	inline XmlSchemaSimpleType_t248156492 ** get_address_of_XdtDayTimeDuration_81() { return &___XdtDayTimeDuration_81; }
	inline void set_XdtDayTimeDuration_81(XmlSchemaSimpleType_t248156492 * value)
	{
		___XdtDayTimeDuration_81 = value;
		Il2CppCodeGenWriteBarrier(&___XdtDayTimeDuration_81, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
