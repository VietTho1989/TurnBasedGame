#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Mono.Xml.Schema.XsdKeyEntry
struct XsdKeyEntry_t3532015222;
// Mono.Xml.Schema.XsdIdentityField
struct XsdIdentityField_t2563516441;
// Mono.Xml.Schema.XsdAnySimpleType
struct XsdAnySimpleType_t1096449895;
// System.Object
struct Il2CppObject;
// Mono.Xml.Schema.XsdIdentityPath
struct XsdIdentityPath_t2037874;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdKeyEntryField
struct  XsdKeyEntryField_t3632833996  : public Il2CppObject
{
public:
	// Mono.Xml.Schema.XsdKeyEntry Mono.Xml.Schema.XsdKeyEntryField::entry
	XsdKeyEntry_t3532015222 * ___entry_0;
	// Mono.Xml.Schema.XsdIdentityField Mono.Xml.Schema.XsdKeyEntryField::field
	XsdIdentityField_t2563516441 * ___field_1;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntryField::FieldFound
	bool ___FieldFound_2;
	// System.Int32 Mono.Xml.Schema.XsdKeyEntryField::FieldLineNumber
	int32_t ___FieldLineNumber_3;
	// System.Int32 Mono.Xml.Schema.XsdKeyEntryField::FieldLinePosition
	int32_t ___FieldLinePosition_4;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntryField::FieldHasLineInfo
	bool ___FieldHasLineInfo_5;
	// Mono.Xml.Schema.XsdAnySimpleType Mono.Xml.Schema.XsdKeyEntryField::FieldType
	XsdAnySimpleType_t1096449895 * ___FieldType_6;
	// System.Object Mono.Xml.Schema.XsdKeyEntryField::Identity
	Il2CppObject * ___Identity_7;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntryField::IsXsiNil
	bool ___IsXsiNil_8;
	// System.Int32 Mono.Xml.Schema.XsdKeyEntryField::FieldFoundDepth
	int32_t ___FieldFoundDepth_9;
	// Mono.Xml.Schema.XsdIdentityPath Mono.Xml.Schema.XsdKeyEntryField::FieldFoundPath
	XsdIdentityPath_t2037874 * ___FieldFoundPath_10;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntryField::Consuming
	bool ___Consuming_11;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntryField::Consumed
	bool ___Consumed_12;

public:
	inline static int32_t get_offset_of_entry_0() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___entry_0)); }
	inline XsdKeyEntry_t3532015222 * get_entry_0() const { return ___entry_0; }
	inline XsdKeyEntry_t3532015222 ** get_address_of_entry_0() { return &___entry_0; }
	inline void set_entry_0(XsdKeyEntry_t3532015222 * value)
	{
		___entry_0 = value;
		Il2CppCodeGenWriteBarrier(&___entry_0, value);
	}

	inline static int32_t get_offset_of_field_1() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___field_1)); }
	inline XsdIdentityField_t2563516441 * get_field_1() const { return ___field_1; }
	inline XsdIdentityField_t2563516441 ** get_address_of_field_1() { return &___field_1; }
	inline void set_field_1(XsdIdentityField_t2563516441 * value)
	{
		___field_1 = value;
		Il2CppCodeGenWriteBarrier(&___field_1, value);
	}

	inline static int32_t get_offset_of_FieldFound_2() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldFound_2)); }
	inline bool get_FieldFound_2() const { return ___FieldFound_2; }
	inline bool* get_address_of_FieldFound_2() { return &___FieldFound_2; }
	inline void set_FieldFound_2(bool value)
	{
		___FieldFound_2 = value;
	}

	inline static int32_t get_offset_of_FieldLineNumber_3() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldLineNumber_3)); }
	inline int32_t get_FieldLineNumber_3() const { return ___FieldLineNumber_3; }
	inline int32_t* get_address_of_FieldLineNumber_3() { return &___FieldLineNumber_3; }
	inline void set_FieldLineNumber_3(int32_t value)
	{
		___FieldLineNumber_3 = value;
	}

	inline static int32_t get_offset_of_FieldLinePosition_4() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldLinePosition_4)); }
	inline int32_t get_FieldLinePosition_4() const { return ___FieldLinePosition_4; }
	inline int32_t* get_address_of_FieldLinePosition_4() { return &___FieldLinePosition_4; }
	inline void set_FieldLinePosition_4(int32_t value)
	{
		___FieldLinePosition_4 = value;
	}

	inline static int32_t get_offset_of_FieldHasLineInfo_5() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldHasLineInfo_5)); }
	inline bool get_FieldHasLineInfo_5() const { return ___FieldHasLineInfo_5; }
	inline bool* get_address_of_FieldHasLineInfo_5() { return &___FieldHasLineInfo_5; }
	inline void set_FieldHasLineInfo_5(bool value)
	{
		___FieldHasLineInfo_5 = value;
	}

	inline static int32_t get_offset_of_FieldType_6() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldType_6)); }
	inline XsdAnySimpleType_t1096449895 * get_FieldType_6() const { return ___FieldType_6; }
	inline XsdAnySimpleType_t1096449895 ** get_address_of_FieldType_6() { return &___FieldType_6; }
	inline void set_FieldType_6(XsdAnySimpleType_t1096449895 * value)
	{
		___FieldType_6 = value;
		Il2CppCodeGenWriteBarrier(&___FieldType_6, value);
	}

	inline static int32_t get_offset_of_Identity_7() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___Identity_7)); }
	inline Il2CppObject * get_Identity_7() const { return ___Identity_7; }
	inline Il2CppObject ** get_address_of_Identity_7() { return &___Identity_7; }
	inline void set_Identity_7(Il2CppObject * value)
	{
		___Identity_7 = value;
		Il2CppCodeGenWriteBarrier(&___Identity_7, value);
	}

	inline static int32_t get_offset_of_IsXsiNil_8() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___IsXsiNil_8)); }
	inline bool get_IsXsiNil_8() const { return ___IsXsiNil_8; }
	inline bool* get_address_of_IsXsiNil_8() { return &___IsXsiNil_8; }
	inline void set_IsXsiNil_8(bool value)
	{
		___IsXsiNil_8 = value;
	}

	inline static int32_t get_offset_of_FieldFoundDepth_9() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldFoundDepth_9)); }
	inline int32_t get_FieldFoundDepth_9() const { return ___FieldFoundDepth_9; }
	inline int32_t* get_address_of_FieldFoundDepth_9() { return &___FieldFoundDepth_9; }
	inline void set_FieldFoundDepth_9(int32_t value)
	{
		___FieldFoundDepth_9 = value;
	}

	inline static int32_t get_offset_of_FieldFoundPath_10() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___FieldFoundPath_10)); }
	inline XsdIdentityPath_t2037874 * get_FieldFoundPath_10() const { return ___FieldFoundPath_10; }
	inline XsdIdentityPath_t2037874 ** get_address_of_FieldFoundPath_10() { return &___FieldFoundPath_10; }
	inline void set_FieldFoundPath_10(XsdIdentityPath_t2037874 * value)
	{
		___FieldFoundPath_10 = value;
		Il2CppCodeGenWriteBarrier(&___FieldFoundPath_10, value);
	}

	inline static int32_t get_offset_of_Consuming_11() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___Consuming_11)); }
	inline bool get_Consuming_11() const { return ___Consuming_11; }
	inline bool* get_address_of_Consuming_11() { return &___Consuming_11; }
	inline void set_Consuming_11(bool value)
	{
		___Consuming_11 = value;
	}

	inline static int32_t get_offset_of_Consumed_12() { return static_cast<int32_t>(offsetof(XsdKeyEntryField_t3632833996, ___Consumed_12)); }
	inline bool get_Consumed_12() const { return ___Consumed_12; }
	inline bool* get_address_of_Consumed_12() { return &___Consumed_12; }
	inline void set_Consumed_12(bool value)
	{
		___Consumed_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
