#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"
#include "System_Xml_System_Xml_XmlNodeChangedAction1188489541.h"

// System.Xml.XmlNode
struct XmlNode_t616554813;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNodeChangedEventArgs
struct  XmlNodeChangedEventArgs_t4036174778  : public EventArgs_t3289624707
{
public:
	// System.Xml.XmlNode System.Xml.XmlNodeChangedEventArgs::_oldParent
	XmlNode_t616554813 * ____oldParent_1;
	// System.Xml.XmlNode System.Xml.XmlNodeChangedEventArgs::_newParent
	XmlNode_t616554813 * ____newParent_2;
	// System.Xml.XmlNodeChangedAction System.Xml.XmlNodeChangedEventArgs::_action
	int32_t ____action_3;
	// System.Xml.XmlNode System.Xml.XmlNodeChangedEventArgs::_node
	XmlNode_t616554813 * ____node_4;
	// System.String System.Xml.XmlNodeChangedEventArgs::_oldValue
	String_t* ____oldValue_5;
	// System.String System.Xml.XmlNodeChangedEventArgs::_newValue
	String_t* ____newValue_6;

public:
	inline static int32_t get_offset_of__oldParent_1() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____oldParent_1)); }
	inline XmlNode_t616554813 * get__oldParent_1() const { return ____oldParent_1; }
	inline XmlNode_t616554813 ** get_address_of__oldParent_1() { return &____oldParent_1; }
	inline void set__oldParent_1(XmlNode_t616554813 * value)
	{
		____oldParent_1 = value;
		Il2CppCodeGenWriteBarrier(&____oldParent_1, value);
	}

	inline static int32_t get_offset_of__newParent_2() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____newParent_2)); }
	inline XmlNode_t616554813 * get__newParent_2() const { return ____newParent_2; }
	inline XmlNode_t616554813 ** get_address_of__newParent_2() { return &____newParent_2; }
	inline void set__newParent_2(XmlNode_t616554813 * value)
	{
		____newParent_2 = value;
		Il2CppCodeGenWriteBarrier(&____newParent_2, value);
	}

	inline static int32_t get_offset_of__action_3() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____action_3)); }
	inline int32_t get__action_3() const { return ____action_3; }
	inline int32_t* get_address_of__action_3() { return &____action_3; }
	inline void set__action_3(int32_t value)
	{
		____action_3 = value;
	}

	inline static int32_t get_offset_of__node_4() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____node_4)); }
	inline XmlNode_t616554813 * get__node_4() const { return ____node_4; }
	inline XmlNode_t616554813 ** get_address_of__node_4() { return &____node_4; }
	inline void set__node_4(XmlNode_t616554813 * value)
	{
		____node_4 = value;
		Il2CppCodeGenWriteBarrier(&____node_4, value);
	}

	inline static int32_t get_offset_of__oldValue_5() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____oldValue_5)); }
	inline String_t* get__oldValue_5() const { return ____oldValue_5; }
	inline String_t** get_address_of__oldValue_5() { return &____oldValue_5; }
	inline void set__oldValue_5(String_t* value)
	{
		____oldValue_5 = value;
		Il2CppCodeGenWriteBarrier(&____oldValue_5, value);
	}

	inline static int32_t get_offset_of__newValue_6() { return static_cast<int32_t>(offsetof(XmlNodeChangedEventArgs_t4036174778, ____newValue_6)); }
	inline String_t* get__newValue_6() const { return ____newValue_6; }
	inline String_t** get_address_of__newValue_6() { return &____newValue_6; }
	inline void set__newValue_6(String_t* value)
	{
		____newValue_6 = value;
		Il2CppCodeGenWriteBarrier(&____newValue_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
