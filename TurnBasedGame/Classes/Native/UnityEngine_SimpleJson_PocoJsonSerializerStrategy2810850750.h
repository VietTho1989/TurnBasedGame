#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IDictionary`2<System.Type,SimpleJson.Reflection.ReflectionUtils/ConstructorDelegate>
struct IDictionary_2_t3020485177;
// System.Collections.Generic.IDictionary`2<System.Type,System.Collections.Generic.IDictionary`2<System.String,SimpleJson.Reflection.ReflectionUtils/GetDelegate>>
struct IDictionary_2_t202585634;
// System.Collections.Generic.IDictionary`2<System.Type,System.Collections.Generic.IDictionary`2<System.String,System.Collections.Generic.KeyValuePair`2<System.Type,SimpleJson.Reflection.ReflectionUtils/SetDelegate>>>
struct IDictionary_2_t3751372229;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.String[]
struct StringU5BU5D_t1642385972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SimpleJson.PocoJsonSerializerStrategy
struct  PocoJsonSerializerStrategy_t2810850750  : public Il2CppObject
{
public:
	// System.Collections.Generic.IDictionary`2<System.Type,SimpleJson.Reflection.ReflectionUtils/ConstructorDelegate> SimpleJson.PocoJsonSerializerStrategy::ConstructorCache
	Il2CppObject* ___ConstructorCache_0;
	// System.Collections.Generic.IDictionary`2<System.Type,System.Collections.Generic.IDictionary`2<System.String,SimpleJson.Reflection.ReflectionUtils/GetDelegate>> SimpleJson.PocoJsonSerializerStrategy::GetCache
	Il2CppObject* ___GetCache_1;
	// System.Collections.Generic.IDictionary`2<System.Type,System.Collections.Generic.IDictionary`2<System.String,System.Collections.Generic.KeyValuePair`2<System.Type,SimpleJson.Reflection.ReflectionUtils/SetDelegate>>> SimpleJson.PocoJsonSerializerStrategy::SetCache
	Il2CppObject* ___SetCache_2;

public:
	inline static int32_t get_offset_of_ConstructorCache_0() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750, ___ConstructorCache_0)); }
	inline Il2CppObject* get_ConstructorCache_0() const { return ___ConstructorCache_0; }
	inline Il2CppObject** get_address_of_ConstructorCache_0() { return &___ConstructorCache_0; }
	inline void set_ConstructorCache_0(Il2CppObject* value)
	{
		___ConstructorCache_0 = value;
		Il2CppCodeGenWriteBarrier(&___ConstructorCache_0, value);
	}

	inline static int32_t get_offset_of_GetCache_1() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750, ___GetCache_1)); }
	inline Il2CppObject* get_GetCache_1() const { return ___GetCache_1; }
	inline Il2CppObject** get_address_of_GetCache_1() { return &___GetCache_1; }
	inline void set_GetCache_1(Il2CppObject* value)
	{
		___GetCache_1 = value;
		Il2CppCodeGenWriteBarrier(&___GetCache_1, value);
	}

	inline static int32_t get_offset_of_SetCache_2() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750, ___SetCache_2)); }
	inline Il2CppObject* get_SetCache_2() const { return ___SetCache_2; }
	inline Il2CppObject** get_address_of_SetCache_2() { return &___SetCache_2; }
	inline void set_SetCache_2(Il2CppObject* value)
	{
		___SetCache_2 = value;
		Il2CppCodeGenWriteBarrier(&___SetCache_2, value);
	}
};

struct PocoJsonSerializerStrategy_t2810850750_StaticFields
{
public:
	// System.Type[] SimpleJson.PocoJsonSerializerStrategy::EmptyTypes
	TypeU5BU5D_t1664964607* ___EmptyTypes_3;
	// System.Type[] SimpleJson.PocoJsonSerializerStrategy::ArrayConstructorParameterTypes
	TypeU5BU5D_t1664964607* ___ArrayConstructorParameterTypes_4;
	// System.String[] SimpleJson.PocoJsonSerializerStrategy::Iso8601Format
	StringU5BU5D_t1642385972* ___Iso8601Format_5;

public:
	inline static int32_t get_offset_of_EmptyTypes_3() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750_StaticFields, ___EmptyTypes_3)); }
	inline TypeU5BU5D_t1664964607* get_EmptyTypes_3() const { return ___EmptyTypes_3; }
	inline TypeU5BU5D_t1664964607** get_address_of_EmptyTypes_3() { return &___EmptyTypes_3; }
	inline void set_EmptyTypes_3(TypeU5BU5D_t1664964607* value)
	{
		___EmptyTypes_3 = value;
		Il2CppCodeGenWriteBarrier(&___EmptyTypes_3, value);
	}

	inline static int32_t get_offset_of_ArrayConstructorParameterTypes_4() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750_StaticFields, ___ArrayConstructorParameterTypes_4)); }
	inline TypeU5BU5D_t1664964607* get_ArrayConstructorParameterTypes_4() const { return ___ArrayConstructorParameterTypes_4; }
	inline TypeU5BU5D_t1664964607** get_address_of_ArrayConstructorParameterTypes_4() { return &___ArrayConstructorParameterTypes_4; }
	inline void set_ArrayConstructorParameterTypes_4(TypeU5BU5D_t1664964607* value)
	{
		___ArrayConstructorParameterTypes_4 = value;
		Il2CppCodeGenWriteBarrier(&___ArrayConstructorParameterTypes_4, value);
	}

	inline static int32_t get_offset_of_Iso8601Format_5() { return static_cast<int32_t>(offsetof(PocoJsonSerializerStrategy_t2810850750_StaticFields, ___Iso8601Format_5)); }
	inline StringU5BU5D_t1642385972* get_Iso8601Format_5() const { return ___Iso8601Format_5; }
	inline StringU5BU5D_t1642385972** get_address_of_Iso8601Format_5() { return &___Iso8601Format_5; }
	inline void set_Iso8601Format_5(StringU5BU5D_t1642385972* value)
	{
		___Iso8601Format_5 = value;
		Il2CppCodeGenWriteBarrier(&___Iso8601Format_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
