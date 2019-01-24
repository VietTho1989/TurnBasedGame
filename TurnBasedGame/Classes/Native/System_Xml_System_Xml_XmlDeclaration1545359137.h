#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlLinkedNode1287616130.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlDeclaration
struct  XmlDeclaration_t1545359137  : public XmlLinkedNode_t1287616130
{
public:
	// System.String System.Xml.XmlDeclaration::encoding
	String_t* ___encoding_6;
	// System.String System.Xml.XmlDeclaration::standalone
	String_t* ___standalone_7;
	// System.String System.Xml.XmlDeclaration::version
	String_t* ___version_8;

public:
	inline static int32_t get_offset_of_encoding_6() { return static_cast<int32_t>(offsetof(XmlDeclaration_t1545359137, ___encoding_6)); }
	inline String_t* get_encoding_6() const { return ___encoding_6; }
	inline String_t** get_address_of_encoding_6() { return &___encoding_6; }
	inline void set_encoding_6(String_t* value)
	{
		___encoding_6 = value;
		Il2CppCodeGenWriteBarrier(&___encoding_6, value);
	}

	inline static int32_t get_offset_of_standalone_7() { return static_cast<int32_t>(offsetof(XmlDeclaration_t1545359137, ___standalone_7)); }
	inline String_t* get_standalone_7() const { return ___standalone_7; }
	inline String_t** get_address_of_standalone_7() { return &___standalone_7; }
	inline void set_standalone_7(String_t* value)
	{
		___standalone_7 = value;
		Il2CppCodeGenWriteBarrier(&___standalone_7, value);
	}

	inline static int32_t get_offset_of_version_8() { return static_cast<int32_t>(offsetof(XmlDeclaration_t1545359137, ___version_8)); }
	inline String_t* get_version_8() const { return ___version_8; }
	inline String_t** get_address_of_version_8() { return &___version_8; }
	inline void set_version_8(String_t* value)
	{
		___version_8 = value;
		Il2CppCodeGenWriteBarrier(&___version_8, value);
	}
};

struct XmlDeclaration_t1545359137_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.XmlDeclaration::<>f__switch$map30
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map30_9;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map30_9() { return static_cast<int32_t>(offsetof(XmlDeclaration_t1545359137_StaticFields, ___U3CU3Ef__switchU24map30_9)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map30_9() const { return ___U3CU3Ef__switchU24map30_9; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map30_9() { return &___U3CU3Ef__switchU24map30_9; }
	inline void set_U3CU3Ef__switchU24map30_9(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map30_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map30_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
