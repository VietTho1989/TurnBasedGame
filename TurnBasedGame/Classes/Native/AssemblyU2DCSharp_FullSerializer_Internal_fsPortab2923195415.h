#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Reflection_BindingFlags1082350898.h"

// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Collections.Generic.IDictionary`2<FullSerializer.Internal.fsPortableReflection/AttributeQuery,System.Attribute>
struct IDictionary_2_t2678704838;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsPortableReflection
struct  fsPortableReflection_t2923195415  : public Il2CppObject
{
public:

public:
};

struct fsPortableReflection_t2923195415_StaticFields
{
public:
	// System.Type[] FullSerializer.Internal.fsPortableReflection::EmptyTypes
	TypeU5BU5D_t1664964607* ___EmptyTypes_0;
	// System.Collections.Generic.IDictionary`2<FullSerializer.Internal.fsPortableReflection/AttributeQuery,System.Attribute> FullSerializer.Internal.fsPortableReflection::_cachedAttributeQueries
	Il2CppObject* ____cachedAttributeQueries_1;
	// System.Reflection.BindingFlags FullSerializer.Internal.fsPortableReflection::DeclaredFlags
	int32_t ___DeclaredFlags_2;

public:
	inline static int32_t get_offset_of_EmptyTypes_0() { return static_cast<int32_t>(offsetof(fsPortableReflection_t2923195415_StaticFields, ___EmptyTypes_0)); }
	inline TypeU5BU5D_t1664964607* get_EmptyTypes_0() const { return ___EmptyTypes_0; }
	inline TypeU5BU5D_t1664964607** get_address_of_EmptyTypes_0() { return &___EmptyTypes_0; }
	inline void set_EmptyTypes_0(TypeU5BU5D_t1664964607* value)
	{
		___EmptyTypes_0 = value;
		Il2CppCodeGenWriteBarrier(&___EmptyTypes_0, value);
	}

	inline static int32_t get_offset_of__cachedAttributeQueries_1() { return static_cast<int32_t>(offsetof(fsPortableReflection_t2923195415_StaticFields, ____cachedAttributeQueries_1)); }
	inline Il2CppObject* get__cachedAttributeQueries_1() const { return ____cachedAttributeQueries_1; }
	inline Il2CppObject** get_address_of__cachedAttributeQueries_1() { return &____cachedAttributeQueries_1; }
	inline void set__cachedAttributeQueries_1(Il2CppObject* value)
	{
		____cachedAttributeQueries_1 = value;
		Il2CppCodeGenWriteBarrier(&____cachedAttributeQueries_1, value);
	}

	inline static int32_t get_offset_of_DeclaredFlags_2() { return static_cast<int32_t>(offsetof(fsPortableReflection_t2923195415_StaticFields, ___DeclaredFlags_2)); }
	inline int32_t get_DeclaredFlags_2() const { return ___DeclaredFlags_2; }
	inline int32_t* get_address_of_DeclaredFlags_2() { return &___DeclaredFlags_2; }
	inline void set_DeclaredFlags_2(int32_t value)
	{
		___DeclaredFlags_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
