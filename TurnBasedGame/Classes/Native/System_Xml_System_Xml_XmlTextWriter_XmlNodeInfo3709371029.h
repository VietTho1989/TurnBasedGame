#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Xml_System_Xml_XmlSpace2880376877.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlTextWriter/XmlNodeInfo
struct  XmlNodeInfo_t3709371029  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlTextWriter/XmlNodeInfo::Prefix
	String_t* ___Prefix_0;
	// System.String System.Xml.XmlTextWriter/XmlNodeInfo::LocalName
	String_t* ___LocalName_1;
	// System.String System.Xml.XmlTextWriter/XmlNodeInfo::NS
	String_t* ___NS_2;
	// System.Boolean System.Xml.XmlTextWriter/XmlNodeInfo::HasSimple
	bool ___HasSimple_3;
	// System.Boolean System.Xml.XmlTextWriter/XmlNodeInfo::HasElements
	bool ___HasElements_4;
	// System.String System.Xml.XmlTextWriter/XmlNodeInfo::XmlLang
	String_t* ___XmlLang_5;
	// System.Xml.XmlSpace System.Xml.XmlTextWriter/XmlNodeInfo::XmlSpace
	int32_t ___XmlSpace_6;

public:
	inline static int32_t get_offset_of_Prefix_0() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___Prefix_0)); }
	inline String_t* get_Prefix_0() const { return ___Prefix_0; }
	inline String_t** get_address_of_Prefix_0() { return &___Prefix_0; }
	inline void set_Prefix_0(String_t* value)
	{
		___Prefix_0 = value;
		Il2CppCodeGenWriteBarrier(&___Prefix_0, value);
	}

	inline static int32_t get_offset_of_LocalName_1() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___LocalName_1)); }
	inline String_t* get_LocalName_1() const { return ___LocalName_1; }
	inline String_t** get_address_of_LocalName_1() { return &___LocalName_1; }
	inline void set_LocalName_1(String_t* value)
	{
		___LocalName_1 = value;
		Il2CppCodeGenWriteBarrier(&___LocalName_1, value);
	}

	inline static int32_t get_offset_of_NS_2() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___NS_2)); }
	inline String_t* get_NS_2() const { return ___NS_2; }
	inline String_t** get_address_of_NS_2() { return &___NS_2; }
	inline void set_NS_2(String_t* value)
	{
		___NS_2 = value;
		Il2CppCodeGenWriteBarrier(&___NS_2, value);
	}

	inline static int32_t get_offset_of_HasSimple_3() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___HasSimple_3)); }
	inline bool get_HasSimple_3() const { return ___HasSimple_3; }
	inline bool* get_address_of_HasSimple_3() { return &___HasSimple_3; }
	inline void set_HasSimple_3(bool value)
	{
		___HasSimple_3 = value;
	}

	inline static int32_t get_offset_of_HasElements_4() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___HasElements_4)); }
	inline bool get_HasElements_4() const { return ___HasElements_4; }
	inline bool* get_address_of_HasElements_4() { return &___HasElements_4; }
	inline void set_HasElements_4(bool value)
	{
		___HasElements_4 = value;
	}

	inline static int32_t get_offset_of_XmlLang_5() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___XmlLang_5)); }
	inline String_t* get_XmlLang_5() const { return ___XmlLang_5; }
	inline String_t** get_address_of_XmlLang_5() { return &___XmlLang_5; }
	inline void set_XmlLang_5(String_t* value)
	{
		___XmlLang_5 = value;
		Il2CppCodeGenWriteBarrier(&___XmlLang_5, value);
	}

	inline static int32_t get_offset_of_XmlSpace_6() { return static_cast<int32_t>(offsetof(XmlNodeInfo_t3709371029, ___XmlSpace_6)); }
	inline int32_t get_XmlSpace_6() const { return ___XmlSpace_6; }
	inline int32_t* get_address_of_XmlSpace_6() { return &___XmlSpace_6; }
	inline void set_XmlSpace_6(int32_t value)
	{
		___XmlSpace_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
