#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Globalization_DateTimeStyles370343085.h"

// System.String[]
struct StringU5BU5D_t1642385972;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlConvert
struct  XmlConvert_t1936105738  : public Il2CppObject
{
public:

public:
};

struct XmlConvert_t1936105738_StaticFields
{
public:
	// System.String[] System.Xml.XmlConvert::datetimeFormats
	StringU5BU5D_t1642385972* ___datetimeFormats_0;
	// System.String[] System.Xml.XmlConvert::defaultDateTimeFormats
	StringU5BU5D_t1642385972* ___defaultDateTimeFormats_1;
	// System.String[] System.Xml.XmlConvert::roundtripDateTimeFormats
	StringU5BU5D_t1642385972* ___roundtripDateTimeFormats_2;
	// System.String[] System.Xml.XmlConvert::localDateTimeFormats
	StringU5BU5D_t1642385972* ___localDateTimeFormats_3;
	// System.String[] System.Xml.XmlConvert::utcDateTimeFormats
	StringU5BU5D_t1642385972* ___utcDateTimeFormats_4;
	// System.String[] System.Xml.XmlConvert::unspecifiedDateTimeFormats
	StringU5BU5D_t1642385972* ___unspecifiedDateTimeFormats_5;
	// System.Globalization.DateTimeStyles System.Xml.XmlConvert::_defaultStyle
	int32_t ____defaultStyle_6;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.XmlConvert::<>f__switch$map33
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map33_7;

public:
	inline static int32_t get_offset_of_datetimeFormats_0() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___datetimeFormats_0)); }
	inline StringU5BU5D_t1642385972* get_datetimeFormats_0() const { return ___datetimeFormats_0; }
	inline StringU5BU5D_t1642385972** get_address_of_datetimeFormats_0() { return &___datetimeFormats_0; }
	inline void set_datetimeFormats_0(StringU5BU5D_t1642385972* value)
	{
		___datetimeFormats_0 = value;
		Il2CppCodeGenWriteBarrier(&___datetimeFormats_0, value);
	}

	inline static int32_t get_offset_of_defaultDateTimeFormats_1() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___defaultDateTimeFormats_1)); }
	inline StringU5BU5D_t1642385972* get_defaultDateTimeFormats_1() const { return ___defaultDateTimeFormats_1; }
	inline StringU5BU5D_t1642385972** get_address_of_defaultDateTimeFormats_1() { return &___defaultDateTimeFormats_1; }
	inline void set_defaultDateTimeFormats_1(StringU5BU5D_t1642385972* value)
	{
		___defaultDateTimeFormats_1 = value;
		Il2CppCodeGenWriteBarrier(&___defaultDateTimeFormats_1, value);
	}

	inline static int32_t get_offset_of_roundtripDateTimeFormats_2() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___roundtripDateTimeFormats_2)); }
	inline StringU5BU5D_t1642385972* get_roundtripDateTimeFormats_2() const { return ___roundtripDateTimeFormats_2; }
	inline StringU5BU5D_t1642385972** get_address_of_roundtripDateTimeFormats_2() { return &___roundtripDateTimeFormats_2; }
	inline void set_roundtripDateTimeFormats_2(StringU5BU5D_t1642385972* value)
	{
		___roundtripDateTimeFormats_2 = value;
		Il2CppCodeGenWriteBarrier(&___roundtripDateTimeFormats_2, value);
	}

	inline static int32_t get_offset_of_localDateTimeFormats_3() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___localDateTimeFormats_3)); }
	inline StringU5BU5D_t1642385972* get_localDateTimeFormats_3() const { return ___localDateTimeFormats_3; }
	inline StringU5BU5D_t1642385972** get_address_of_localDateTimeFormats_3() { return &___localDateTimeFormats_3; }
	inline void set_localDateTimeFormats_3(StringU5BU5D_t1642385972* value)
	{
		___localDateTimeFormats_3 = value;
		Il2CppCodeGenWriteBarrier(&___localDateTimeFormats_3, value);
	}

	inline static int32_t get_offset_of_utcDateTimeFormats_4() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___utcDateTimeFormats_4)); }
	inline StringU5BU5D_t1642385972* get_utcDateTimeFormats_4() const { return ___utcDateTimeFormats_4; }
	inline StringU5BU5D_t1642385972** get_address_of_utcDateTimeFormats_4() { return &___utcDateTimeFormats_4; }
	inline void set_utcDateTimeFormats_4(StringU5BU5D_t1642385972* value)
	{
		___utcDateTimeFormats_4 = value;
		Il2CppCodeGenWriteBarrier(&___utcDateTimeFormats_4, value);
	}

	inline static int32_t get_offset_of_unspecifiedDateTimeFormats_5() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___unspecifiedDateTimeFormats_5)); }
	inline StringU5BU5D_t1642385972* get_unspecifiedDateTimeFormats_5() const { return ___unspecifiedDateTimeFormats_5; }
	inline StringU5BU5D_t1642385972** get_address_of_unspecifiedDateTimeFormats_5() { return &___unspecifiedDateTimeFormats_5; }
	inline void set_unspecifiedDateTimeFormats_5(StringU5BU5D_t1642385972* value)
	{
		___unspecifiedDateTimeFormats_5 = value;
		Il2CppCodeGenWriteBarrier(&___unspecifiedDateTimeFormats_5, value);
	}

	inline static int32_t get_offset_of__defaultStyle_6() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ____defaultStyle_6)); }
	inline int32_t get__defaultStyle_6() const { return ____defaultStyle_6; }
	inline int32_t* get_address_of__defaultStyle_6() { return &____defaultStyle_6; }
	inline void set__defaultStyle_6(int32_t value)
	{
		____defaultStyle_6 = value;
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map33_7() { return static_cast<int32_t>(offsetof(XmlConvert_t1936105738_StaticFields, ___U3CU3Ef__switchU24map33_7)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map33_7() const { return ___U3CU3Ef__switchU24map33_7; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map33_7() { return &___U3CU3Ef__switchU24map33_7; }
	inline void set_U3CU3Ef__switchU24map33_7(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map33_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map33_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
