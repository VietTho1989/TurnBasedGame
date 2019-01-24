#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Xml.XmlNode/EmptyNodeList
struct EmptyNodeList_t1718403287;
// System.Xml.XmlDocument
struct XmlDocument_t3649534162;
// System.Xml.XmlNode
struct XmlNode_t616554813;
// System.Xml.XmlNodeListChildren
struct XmlNodeListChildren_t2811458520;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNode
struct  XmlNode_t616554813  : public Il2CppObject
{
public:
	// System.Xml.XmlDocument System.Xml.XmlNode::ownerDocument
	XmlDocument_t3649534162 * ___ownerDocument_1;
	// System.Xml.XmlNode System.Xml.XmlNode::parentNode
	XmlNode_t616554813 * ___parentNode_2;
	// System.Xml.XmlNodeListChildren System.Xml.XmlNode::childNodes
	XmlNodeListChildren_t2811458520 * ___childNodes_3;

public:
	inline static int32_t get_offset_of_ownerDocument_1() { return static_cast<int32_t>(offsetof(XmlNode_t616554813, ___ownerDocument_1)); }
	inline XmlDocument_t3649534162 * get_ownerDocument_1() const { return ___ownerDocument_1; }
	inline XmlDocument_t3649534162 ** get_address_of_ownerDocument_1() { return &___ownerDocument_1; }
	inline void set_ownerDocument_1(XmlDocument_t3649534162 * value)
	{
		___ownerDocument_1 = value;
		Il2CppCodeGenWriteBarrier(&___ownerDocument_1, value);
	}

	inline static int32_t get_offset_of_parentNode_2() { return static_cast<int32_t>(offsetof(XmlNode_t616554813, ___parentNode_2)); }
	inline XmlNode_t616554813 * get_parentNode_2() const { return ___parentNode_2; }
	inline XmlNode_t616554813 ** get_address_of_parentNode_2() { return &___parentNode_2; }
	inline void set_parentNode_2(XmlNode_t616554813 * value)
	{
		___parentNode_2 = value;
		Il2CppCodeGenWriteBarrier(&___parentNode_2, value);
	}

	inline static int32_t get_offset_of_childNodes_3() { return static_cast<int32_t>(offsetof(XmlNode_t616554813, ___childNodes_3)); }
	inline XmlNodeListChildren_t2811458520 * get_childNodes_3() const { return ___childNodes_3; }
	inline XmlNodeListChildren_t2811458520 ** get_address_of_childNodes_3() { return &___childNodes_3; }
	inline void set_childNodes_3(XmlNodeListChildren_t2811458520 * value)
	{
		___childNodes_3 = value;
		Il2CppCodeGenWriteBarrier(&___childNodes_3, value);
	}
};

struct XmlNode_t616554813_StaticFields
{
public:
	// System.Xml.XmlNode/EmptyNodeList System.Xml.XmlNode::emptyList
	EmptyNodeList_t1718403287 * ___emptyList_0;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Xml.XmlNode::<>f__switch$map2B
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map2B_4;

public:
	inline static int32_t get_offset_of_emptyList_0() { return static_cast<int32_t>(offsetof(XmlNode_t616554813_StaticFields, ___emptyList_0)); }
	inline EmptyNodeList_t1718403287 * get_emptyList_0() const { return ___emptyList_0; }
	inline EmptyNodeList_t1718403287 ** get_address_of_emptyList_0() { return &___emptyList_0; }
	inline void set_emptyList_0(EmptyNodeList_t1718403287 * value)
	{
		___emptyList_0 = value;
		Il2CppCodeGenWriteBarrier(&___emptyList_0, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map2B_4() { return static_cast<int32_t>(offsetof(XmlNode_t616554813_StaticFields, ___U3CU3Ef__switchU24map2B_4)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map2B_4() const { return ___U3CU3Ef__switchU24map2B_4; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map2B_4() { return &___U3CU3Ef__switchU24map2B_4; }
	inline void set_U3CU3Ef__switchU24map2B_4(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map2B_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map2B_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
