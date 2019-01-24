#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Xml.IHasXmlChildNode
struct IHasXmlChildNode_t2048545686;
// System.Xml.XmlLinkedNode
struct XmlLinkedNode_t1287616130;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNodeListChildren/Enumerator
struct  Enumerator_t569056069  : public Il2CppObject
{
public:
	// System.Xml.IHasXmlChildNode System.Xml.XmlNodeListChildren/Enumerator::parent
	Il2CppObject * ___parent_0;
	// System.Xml.XmlLinkedNode System.Xml.XmlNodeListChildren/Enumerator::currentChild
	XmlLinkedNode_t1287616130 * ___currentChild_1;
	// System.Boolean System.Xml.XmlNodeListChildren/Enumerator::passedLastNode
	bool ___passedLastNode_2;

public:
	inline static int32_t get_offset_of_parent_0() { return static_cast<int32_t>(offsetof(Enumerator_t569056069, ___parent_0)); }
	inline Il2CppObject * get_parent_0() const { return ___parent_0; }
	inline Il2CppObject ** get_address_of_parent_0() { return &___parent_0; }
	inline void set_parent_0(Il2CppObject * value)
	{
		___parent_0 = value;
		Il2CppCodeGenWriteBarrier(&___parent_0, value);
	}

	inline static int32_t get_offset_of_currentChild_1() { return static_cast<int32_t>(offsetof(Enumerator_t569056069, ___currentChild_1)); }
	inline XmlLinkedNode_t1287616130 * get_currentChild_1() const { return ___currentChild_1; }
	inline XmlLinkedNode_t1287616130 ** get_address_of_currentChild_1() { return &___currentChild_1; }
	inline void set_currentChild_1(XmlLinkedNode_t1287616130 * value)
	{
		___currentChild_1 = value;
		Il2CppCodeGenWriteBarrier(&___currentChild_1, value);
	}

	inline static int32_t get_offset_of_passedLastNode_2() { return static_cast<int32_t>(offsetof(Enumerator_t569056069, ___passedLastNode_2)); }
	inline bool get_passedLastNode_2() const { return ___passedLastNode_2; }
	inline bool* get_address_of_passedLastNode_2() { return &___passedLastNode_2; }
	inline void set_passedLastNode_2(bool value)
	{
		___passedLastNode_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
