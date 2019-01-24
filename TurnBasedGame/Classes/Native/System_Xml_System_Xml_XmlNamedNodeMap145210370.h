#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.IEnumerator
struct IEnumerator_t1466026749;
// System.Xml.XmlNode
struct XmlNode_t616554813;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNamedNodeMap
struct  XmlNamedNodeMap_t145210370  : public Il2CppObject
{
public:
	// System.Xml.XmlNode System.Xml.XmlNamedNodeMap::parent
	XmlNode_t616554813 * ___parent_1;
	// System.Collections.ArrayList System.Xml.XmlNamedNodeMap::nodeList
	ArrayList_t4252133567 * ___nodeList_2;
	// System.Boolean System.Xml.XmlNamedNodeMap::readOnly
	bool ___readOnly_3;

public:
	inline static int32_t get_offset_of_parent_1() { return static_cast<int32_t>(offsetof(XmlNamedNodeMap_t145210370, ___parent_1)); }
	inline XmlNode_t616554813 * get_parent_1() const { return ___parent_1; }
	inline XmlNode_t616554813 ** get_address_of_parent_1() { return &___parent_1; }
	inline void set_parent_1(XmlNode_t616554813 * value)
	{
		___parent_1 = value;
		Il2CppCodeGenWriteBarrier(&___parent_1, value);
	}

	inline static int32_t get_offset_of_nodeList_2() { return static_cast<int32_t>(offsetof(XmlNamedNodeMap_t145210370, ___nodeList_2)); }
	inline ArrayList_t4252133567 * get_nodeList_2() const { return ___nodeList_2; }
	inline ArrayList_t4252133567 ** get_address_of_nodeList_2() { return &___nodeList_2; }
	inline void set_nodeList_2(ArrayList_t4252133567 * value)
	{
		___nodeList_2 = value;
		Il2CppCodeGenWriteBarrier(&___nodeList_2, value);
	}

	inline static int32_t get_offset_of_readOnly_3() { return static_cast<int32_t>(offsetof(XmlNamedNodeMap_t145210370, ___readOnly_3)); }
	inline bool get_readOnly_3() const { return ___readOnly_3; }
	inline bool* get_address_of_readOnly_3() { return &___readOnly_3; }
	inline void set_readOnly_3(bool value)
	{
		___readOnly_3 = value;
	}
};

struct XmlNamedNodeMap_t145210370_StaticFields
{
public:
	// System.Collections.IEnumerator System.Xml.XmlNamedNodeMap::emptyEnumerator
	Il2CppObject * ___emptyEnumerator_0;

public:
	inline static int32_t get_offset_of_emptyEnumerator_0() { return static_cast<int32_t>(offsetof(XmlNamedNodeMap_t145210370_StaticFields, ___emptyEnumerator_0)); }
	inline Il2CppObject * get_emptyEnumerator_0() const { return ___emptyEnumerator_0; }
	inline Il2CppObject ** get_address_of_emptyEnumerator_0() { return &___emptyEnumerator_0; }
	inline void set_emptyEnumerator_0(Il2CppObject * value)
	{
		___emptyEnumerator_0 = value;
		Il2CppCodeGenWriteBarrier(&___emptyEnumerator_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
