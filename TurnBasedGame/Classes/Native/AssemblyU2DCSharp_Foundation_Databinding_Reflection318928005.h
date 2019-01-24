#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.Reflection.MemberInfo[]
struct MemberInfoU5BU5D_t4238939941;
// System.Collections.Generic.Dictionary`2<System.Type,Foundation.Databinding.ReflectionCache>
struct Dictionary_2_t2256285902;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ReflectionCache
struct  ReflectionCache_t318928005  : public Il2CppObject
{
public:
	// System.Type Foundation.Databinding.ReflectionCache::Type
	Type_t * ___Type_0;
	// System.Reflection.MemberInfo[] Foundation.Databinding.ReflectionCache::Members
	MemberInfoU5BU5D_t4238939941* ___Members_1;

public:
	inline static int32_t get_offset_of_Type_0() { return static_cast<int32_t>(offsetof(ReflectionCache_t318928005, ___Type_0)); }
	inline Type_t * get_Type_0() const { return ___Type_0; }
	inline Type_t ** get_address_of_Type_0() { return &___Type_0; }
	inline void set_Type_0(Type_t * value)
	{
		___Type_0 = value;
		Il2CppCodeGenWriteBarrier(&___Type_0, value);
	}

	inline static int32_t get_offset_of_Members_1() { return static_cast<int32_t>(offsetof(ReflectionCache_t318928005, ___Members_1)); }
	inline MemberInfoU5BU5D_t4238939941* get_Members_1() const { return ___Members_1; }
	inline MemberInfoU5BU5D_t4238939941** get_address_of_Members_1() { return &___Members_1; }
	inline void set_Members_1(MemberInfoU5BU5D_t4238939941* value)
	{
		___Members_1 = value;
		Il2CppCodeGenWriteBarrier(&___Members_1, value);
	}
};

struct ReflectionCache_t318928005_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.Type,Foundation.Databinding.ReflectionCache> Foundation.Databinding.ReflectionCache::Cache
	Dictionary_2_t2256285902 * ___Cache_2;

public:
	inline static int32_t get_offset_of_Cache_2() { return static_cast<int32_t>(offsetof(ReflectionCache_t318928005_StaticFields, ___Cache_2)); }
	inline Dictionary_2_t2256285902 * get_Cache_2() const { return ___Cache_2; }
	inline Dictionary_2_t2256285902 ** get_address_of_Cache_2() { return &___Cache_2; }
	inline void set_Cache_2(Dictionary_2_t2256285902 * value)
	{
		___Cache_2 = value;
		Il2CppCodeGenWriteBarrier(&___Cache_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
