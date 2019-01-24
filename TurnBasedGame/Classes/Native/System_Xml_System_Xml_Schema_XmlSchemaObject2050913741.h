#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Guid2533601593.h"

// System.String
struct String_t;
// System.Xml.Serialization.XmlSerializerNamespaces
struct XmlSerializerNamespaces_t3063656491;
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Xml.Schema.XmlSchemaObject
struct XmlSchemaObject_t2050913741;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Schema.XmlSchemaObject
struct  XmlSchemaObject_t2050913741  : public Il2CppObject
{
public:
	// System.Int32 System.Xml.Schema.XmlSchemaObject::lineNumber
	int32_t ___lineNumber_0;
	// System.Int32 System.Xml.Schema.XmlSchemaObject::linePosition
	int32_t ___linePosition_1;
	// System.String System.Xml.Schema.XmlSchemaObject::sourceUri
	String_t* ___sourceUri_2;
	// System.Xml.Serialization.XmlSerializerNamespaces System.Xml.Schema.XmlSchemaObject::namespaces
	XmlSerializerNamespaces_t3063656491 * ___namespaces_3;
	// System.Collections.ArrayList System.Xml.Schema.XmlSchemaObject::unhandledAttributeList
	ArrayList_t4252133567 * ___unhandledAttributeList_4;
	// System.Boolean System.Xml.Schema.XmlSchemaObject::isCompiled
	bool ___isCompiled_5;
	// System.Int32 System.Xml.Schema.XmlSchemaObject::errorCount
	int32_t ___errorCount_6;
	// System.Guid System.Xml.Schema.XmlSchemaObject::CompilationId
	Guid_t  ___CompilationId_7;
	// System.Guid System.Xml.Schema.XmlSchemaObject::ValidationId
	Guid_t  ___ValidationId_8;
	// System.Boolean System.Xml.Schema.XmlSchemaObject::isRedefineChild
	bool ___isRedefineChild_9;
	// System.Boolean System.Xml.Schema.XmlSchemaObject::isRedefinedComponent
	bool ___isRedefinedComponent_10;
	// System.Xml.Schema.XmlSchemaObject System.Xml.Schema.XmlSchemaObject::redefinedObject
	XmlSchemaObject_t2050913741 * ___redefinedObject_11;
	// System.Xml.Schema.XmlSchemaObject System.Xml.Schema.XmlSchemaObject::parent
	XmlSchemaObject_t2050913741 * ___parent_12;

public:
	inline static int32_t get_offset_of_lineNumber_0() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___lineNumber_0)); }
	inline int32_t get_lineNumber_0() const { return ___lineNumber_0; }
	inline int32_t* get_address_of_lineNumber_0() { return &___lineNumber_0; }
	inline void set_lineNumber_0(int32_t value)
	{
		___lineNumber_0 = value;
	}

	inline static int32_t get_offset_of_linePosition_1() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___linePosition_1)); }
	inline int32_t get_linePosition_1() const { return ___linePosition_1; }
	inline int32_t* get_address_of_linePosition_1() { return &___linePosition_1; }
	inline void set_linePosition_1(int32_t value)
	{
		___linePosition_1 = value;
	}

	inline static int32_t get_offset_of_sourceUri_2() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___sourceUri_2)); }
	inline String_t* get_sourceUri_2() const { return ___sourceUri_2; }
	inline String_t** get_address_of_sourceUri_2() { return &___sourceUri_2; }
	inline void set_sourceUri_2(String_t* value)
	{
		___sourceUri_2 = value;
		Il2CppCodeGenWriteBarrier(&___sourceUri_2, value);
	}

	inline static int32_t get_offset_of_namespaces_3() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___namespaces_3)); }
	inline XmlSerializerNamespaces_t3063656491 * get_namespaces_3() const { return ___namespaces_3; }
	inline XmlSerializerNamespaces_t3063656491 ** get_address_of_namespaces_3() { return &___namespaces_3; }
	inline void set_namespaces_3(XmlSerializerNamespaces_t3063656491 * value)
	{
		___namespaces_3 = value;
		Il2CppCodeGenWriteBarrier(&___namespaces_3, value);
	}

	inline static int32_t get_offset_of_unhandledAttributeList_4() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___unhandledAttributeList_4)); }
	inline ArrayList_t4252133567 * get_unhandledAttributeList_4() const { return ___unhandledAttributeList_4; }
	inline ArrayList_t4252133567 ** get_address_of_unhandledAttributeList_4() { return &___unhandledAttributeList_4; }
	inline void set_unhandledAttributeList_4(ArrayList_t4252133567 * value)
	{
		___unhandledAttributeList_4 = value;
		Il2CppCodeGenWriteBarrier(&___unhandledAttributeList_4, value);
	}

	inline static int32_t get_offset_of_isCompiled_5() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___isCompiled_5)); }
	inline bool get_isCompiled_5() const { return ___isCompiled_5; }
	inline bool* get_address_of_isCompiled_5() { return &___isCompiled_5; }
	inline void set_isCompiled_5(bool value)
	{
		___isCompiled_5 = value;
	}

	inline static int32_t get_offset_of_errorCount_6() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___errorCount_6)); }
	inline int32_t get_errorCount_6() const { return ___errorCount_6; }
	inline int32_t* get_address_of_errorCount_6() { return &___errorCount_6; }
	inline void set_errorCount_6(int32_t value)
	{
		___errorCount_6 = value;
	}

	inline static int32_t get_offset_of_CompilationId_7() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___CompilationId_7)); }
	inline Guid_t  get_CompilationId_7() const { return ___CompilationId_7; }
	inline Guid_t * get_address_of_CompilationId_7() { return &___CompilationId_7; }
	inline void set_CompilationId_7(Guid_t  value)
	{
		___CompilationId_7 = value;
	}

	inline static int32_t get_offset_of_ValidationId_8() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___ValidationId_8)); }
	inline Guid_t  get_ValidationId_8() const { return ___ValidationId_8; }
	inline Guid_t * get_address_of_ValidationId_8() { return &___ValidationId_8; }
	inline void set_ValidationId_8(Guid_t  value)
	{
		___ValidationId_8 = value;
	}

	inline static int32_t get_offset_of_isRedefineChild_9() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___isRedefineChild_9)); }
	inline bool get_isRedefineChild_9() const { return ___isRedefineChild_9; }
	inline bool* get_address_of_isRedefineChild_9() { return &___isRedefineChild_9; }
	inline void set_isRedefineChild_9(bool value)
	{
		___isRedefineChild_9 = value;
	}

	inline static int32_t get_offset_of_isRedefinedComponent_10() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___isRedefinedComponent_10)); }
	inline bool get_isRedefinedComponent_10() const { return ___isRedefinedComponent_10; }
	inline bool* get_address_of_isRedefinedComponent_10() { return &___isRedefinedComponent_10; }
	inline void set_isRedefinedComponent_10(bool value)
	{
		___isRedefinedComponent_10 = value;
	}

	inline static int32_t get_offset_of_redefinedObject_11() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___redefinedObject_11)); }
	inline XmlSchemaObject_t2050913741 * get_redefinedObject_11() const { return ___redefinedObject_11; }
	inline XmlSchemaObject_t2050913741 ** get_address_of_redefinedObject_11() { return &___redefinedObject_11; }
	inline void set_redefinedObject_11(XmlSchemaObject_t2050913741 * value)
	{
		___redefinedObject_11 = value;
		Il2CppCodeGenWriteBarrier(&___redefinedObject_11, value);
	}

	inline static int32_t get_offset_of_parent_12() { return static_cast<int32_t>(offsetof(XmlSchemaObject_t2050913741, ___parent_12)); }
	inline XmlSchemaObject_t2050913741 * get_parent_12() const { return ___parent_12; }
	inline XmlSchemaObject_t2050913741 ** get_address_of_parent_12() { return &___parent_12; }
	inline void set_parent_12(XmlSchemaObject_t2050913741 * value)
	{
		___parent_12 = value;
		Il2CppCodeGenWriteBarrier(&___parent_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
