#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Xml.XmlQualifiedName
struct XmlQualifiedName_t1944712516;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlQualifiedName
struct  XmlQualifiedName_t1944712516  : public Il2CppObject
{
public:
	// System.String System.Xml.XmlQualifiedName::name
	String_t* ___name_1;
	// System.String System.Xml.XmlQualifiedName::ns
	String_t* ___ns_2;
	// System.Int32 System.Xml.XmlQualifiedName::hash
	int32_t ___hash_3;

public:
	inline static int32_t get_offset_of_name_1() { return static_cast<int32_t>(offsetof(XmlQualifiedName_t1944712516, ___name_1)); }
	inline String_t* get_name_1() const { return ___name_1; }
	inline String_t** get_address_of_name_1() { return &___name_1; }
	inline void set_name_1(String_t* value)
	{
		___name_1 = value;
		Il2CppCodeGenWriteBarrier(&___name_1, value);
	}

	inline static int32_t get_offset_of_ns_2() { return static_cast<int32_t>(offsetof(XmlQualifiedName_t1944712516, ___ns_2)); }
	inline String_t* get_ns_2() const { return ___ns_2; }
	inline String_t** get_address_of_ns_2() { return &___ns_2; }
	inline void set_ns_2(String_t* value)
	{
		___ns_2 = value;
		Il2CppCodeGenWriteBarrier(&___ns_2, value);
	}

	inline static int32_t get_offset_of_hash_3() { return static_cast<int32_t>(offsetof(XmlQualifiedName_t1944712516, ___hash_3)); }
	inline int32_t get_hash_3() const { return ___hash_3; }
	inline int32_t* get_address_of_hash_3() { return &___hash_3; }
	inline void set_hash_3(int32_t value)
	{
		___hash_3 = value;
	}
};

struct XmlQualifiedName_t1944712516_StaticFields
{
public:
	// System.Xml.XmlQualifiedName System.Xml.XmlQualifiedName::Empty
	XmlQualifiedName_t1944712516 * ___Empty_0;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(XmlQualifiedName_t1944712516_StaticFields, ___Empty_0)); }
	inline XmlQualifiedName_t1944712516 * get_Empty_0() const { return ___Empty_0; }
	inline XmlQualifiedName_t1944712516 ** get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(XmlQualifiedName_t1944712516 * value)
	{
		___Empty_0 = value;
		Il2CppCodeGenWriteBarrier(&___Empty_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
