#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.Serialization.TypeTranslator
struct  TypeTranslator_t1077722680  : public Il2CppObject
{
public:

public:
};

struct TypeTranslator_t1077722680_StaticFields
{
public:
	// System.Collections.Hashtable System.Xml.Serialization.TypeTranslator::nameCache
	Hashtable_t909839986 * ___nameCache_0;
	// System.Collections.Hashtable System.Xml.Serialization.TypeTranslator::primitiveTypes
	Hashtable_t909839986 * ___primitiveTypes_1;
	// System.Collections.Hashtable System.Xml.Serialization.TypeTranslator::primitiveArrayTypes
	Hashtable_t909839986 * ___primitiveArrayTypes_2;
	// System.Collections.Hashtable System.Xml.Serialization.TypeTranslator::nullableTypes
	Hashtable_t909839986 * ___nullableTypes_3;

public:
	inline static int32_t get_offset_of_nameCache_0() { return static_cast<int32_t>(offsetof(TypeTranslator_t1077722680_StaticFields, ___nameCache_0)); }
	inline Hashtable_t909839986 * get_nameCache_0() const { return ___nameCache_0; }
	inline Hashtable_t909839986 ** get_address_of_nameCache_0() { return &___nameCache_0; }
	inline void set_nameCache_0(Hashtable_t909839986 * value)
	{
		___nameCache_0 = value;
		Il2CppCodeGenWriteBarrier(&___nameCache_0, value);
	}

	inline static int32_t get_offset_of_primitiveTypes_1() { return static_cast<int32_t>(offsetof(TypeTranslator_t1077722680_StaticFields, ___primitiveTypes_1)); }
	inline Hashtable_t909839986 * get_primitiveTypes_1() const { return ___primitiveTypes_1; }
	inline Hashtable_t909839986 ** get_address_of_primitiveTypes_1() { return &___primitiveTypes_1; }
	inline void set_primitiveTypes_1(Hashtable_t909839986 * value)
	{
		___primitiveTypes_1 = value;
		Il2CppCodeGenWriteBarrier(&___primitiveTypes_1, value);
	}

	inline static int32_t get_offset_of_primitiveArrayTypes_2() { return static_cast<int32_t>(offsetof(TypeTranslator_t1077722680_StaticFields, ___primitiveArrayTypes_2)); }
	inline Hashtable_t909839986 * get_primitiveArrayTypes_2() const { return ___primitiveArrayTypes_2; }
	inline Hashtable_t909839986 ** get_address_of_primitiveArrayTypes_2() { return &___primitiveArrayTypes_2; }
	inline void set_primitiveArrayTypes_2(Hashtable_t909839986 * value)
	{
		___primitiveArrayTypes_2 = value;
		Il2CppCodeGenWriteBarrier(&___primitiveArrayTypes_2, value);
	}

	inline static int32_t get_offset_of_nullableTypes_3() { return static_cast<int32_t>(offsetof(TypeTranslator_t1077722680_StaticFields, ___nullableTypes_3)); }
	inline Hashtable_t909839986 * get_nullableTypes_3() const { return ___nullableTypes_3; }
	inline Hashtable_t909839986 ** get_address_of_nullableTypes_3() { return &___nullableTypes_3; }
	inline void set_nullableTypes_3(Hashtable_t909839986 * value)
	{
		___nullableTypes_3 = value;
		Il2CppCodeGenWriteBarrier(&___nullableTypes_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
