#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.String,System.Type>
struct Dictionary_2_t3218582488;
// System.Collections.Generic.Dictionary`2<System.String,System.Reflection.Assembly>
struct Dictionary_2_t1888224356;
// System.Collections.Generic.List`1<System.Reflection.Assembly>
struct List_1_t3637533522;
// System.AssemblyLoadEventHandler
struct AssemblyLoadEventHandler_t2169307382;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsTypeCache
struct  fsTypeCache_t3191728607  : public Il2CppObject
{
public:

public:
};

struct fsTypeCache_t3191728607_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Type> FullSerializer.Internal.fsTypeCache::_cachedTypes
	Dictionary_2_t3218582488 * ____cachedTypes_0;
	// System.Collections.Generic.Dictionary`2<System.String,System.Reflection.Assembly> FullSerializer.Internal.fsTypeCache::_assembliesByName
	Dictionary_2_t1888224356 * ____assembliesByName_1;
	// System.Collections.Generic.List`1<System.Reflection.Assembly> FullSerializer.Internal.fsTypeCache::_assembliesByIndex
	List_1_t3637533522 * ____assembliesByIndex_2;
	// System.AssemblyLoadEventHandler FullSerializer.Internal.fsTypeCache::<>f__mg$cache0
	AssemblyLoadEventHandler_t2169307382 * ___U3CU3Ef__mgU24cache0_3;

public:
	inline static int32_t get_offset_of__cachedTypes_0() { return static_cast<int32_t>(offsetof(fsTypeCache_t3191728607_StaticFields, ____cachedTypes_0)); }
	inline Dictionary_2_t3218582488 * get__cachedTypes_0() const { return ____cachedTypes_0; }
	inline Dictionary_2_t3218582488 ** get_address_of__cachedTypes_0() { return &____cachedTypes_0; }
	inline void set__cachedTypes_0(Dictionary_2_t3218582488 * value)
	{
		____cachedTypes_0 = value;
		Il2CppCodeGenWriteBarrier(&____cachedTypes_0, value);
	}

	inline static int32_t get_offset_of__assembliesByName_1() { return static_cast<int32_t>(offsetof(fsTypeCache_t3191728607_StaticFields, ____assembliesByName_1)); }
	inline Dictionary_2_t1888224356 * get__assembliesByName_1() const { return ____assembliesByName_1; }
	inline Dictionary_2_t1888224356 ** get_address_of__assembliesByName_1() { return &____assembliesByName_1; }
	inline void set__assembliesByName_1(Dictionary_2_t1888224356 * value)
	{
		____assembliesByName_1 = value;
		Il2CppCodeGenWriteBarrier(&____assembliesByName_1, value);
	}

	inline static int32_t get_offset_of__assembliesByIndex_2() { return static_cast<int32_t>(offsetof(fsTypeCache_t3191728607_StaticFields, ____assembliesByIndex_2)); }
	inline List_1_t3637533522 * get__assembliesByIndex_2() const { return ____assembliesByIndex_2; }
	inline List_1_t3637533522 ** get_address_of__assembliesByIndex_2() { return &____assembliesByIndex_2; }
	inline void set__assembliesByIndex_2(List_1_t3637533522 * value)
	{
		____assembliesByIndex_2 = value;
		Il2CppCodeGenWriteBarrier(&____assembliesByIndex_2, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_3() { return static_cast<int32_t>(offsetof(fsTypeCache_t3191728607_StaticFields, ___U3CU3Ef__mgU24cache0_3)); }
	inline AssemblyLoadEventHandler_t2169307382 * get_U3CU3Ef__mgU24cache0_3() const { return ___U3CU3Ef__mgU24cache0_3; }
	inline AssemblyLoadEventHandler_t2169307382 ** get_address_of_U3CU3Ef__mgU24cache0_3() { return &___U3CU3Ef__mgU24cache0_3; }
	inline void set_U3CU3Ef__mgU24cache0_3(AssemblyLoadEventHandler_t2169307382 * value)
	{
		___U3CU3Ef__mgU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__mgU24cache0_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
