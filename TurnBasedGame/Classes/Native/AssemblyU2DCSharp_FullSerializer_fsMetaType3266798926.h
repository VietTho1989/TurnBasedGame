#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Nullable_1_gen2088641033.h"

// System.Collections.Generic.Dictionary`2<FullSerializer.fsConfig,System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsMetaType>>
struct Dictionary_2_t1238777147;
// System.Type
struct Type_t;
// FullSerializer.Internal.fsMetaProperty[]
struct fsMetaPropertyU5BU5D_t4057973332;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsMetaType
struct  fsMetaType_t3266798926  : public Il2CppObject
{
public:
	// System.Type FullSerializer.fsMetaType::ReflectedType
	Type_t * ___ReflectedType_1;
	// FullSerializer.Internal.fsMetaProperty[] FullSerializer.fsMetaType::<Properties>k__BackingField
	fsMetaPropertyU5BU5D_t4057973332* ___U3CPropertiesU3Ek__BackingField_2;
	// System.Nullable`1<System.Boolean> FullSerializer.fsMetaType::_hasDefaultConstructorCache
	Nullable_1_t2088641033  ____hasDefaultConstructorCache_3;
	// System.Nullable`1<System.Boolean> FullSerializer.fsMetaType::_isDefaultConstructorPublicCache
	Nullable_1_t2088641033  ____isDefaultConstructorPublicCache_4;

public:
	inline static int32_t get_offset_of_ReflectedType_1() { return static_cast<int32_t>(offsetof(fsMetaType_t3266798926, ___ReflectedType_1)); }
	inline Type_t * get_ReflectedType_1() const { return ___ReflectedType_1; }
	inline Type_t ** get_address_of_ReflectedType_1() { return &___ReflectedType_1; }
	inline void set_ReflectedType_1(Type_t * value)
	{
		___ReflectedType_1 = value;
		Il2CppCodeGenWriteBarrier(&___ReflectedType_1, value);
	}

	inline static int32_t get_offset_of_U3CPropertiesU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(fsMetaType_t3266798926, ___U3CPropertiesU3Ek__BackingField_2)); }
	inline fsMetaPropertyU5BU5D_t4057973332* get_U3CPropertiesU3Ek__BackingField_2() const { return ___U3CPropertiesU3Ek__BackingField_2; }
	inline fsMetaPropertyU5BU5D_t4057973332** get_address_of_U3CPropertiesU3Ek__BackingField_2() { return &___U3CPropertiesU3Ek__BackingField_2; }
	inline void set_U3CPropertiesU3Ek__BackingField_2(fsMetaPropertyU5BU5D_t4057973332* value)
	{
		___U3CPropertiesU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CPropertiesU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of__hasDefaultConstructorCache_3() { return static_cast<int32_t>(offsetof(fsMetaType_t3266798926, ____hasDefaultConstructorCache_3)); }
	inline Nullable_1_t2088641033  get__hasDefaultConstructorCache_3() const { return ____hasDefaultConstructorCache_3; }
	inline Nullable_1_t2088641033 * get_address_of__hasDefaultConstructorCache_3() { return &____hasDefaultConstructorCache_3; }
	inline void set__hasDefaultConstructorCache_3(Nullable_1_t2088641033  value)
	{
		____hasDefaultConstructorCache_3 = value;
	}

	inline static int32_t get_offset_of__isDefaultConstructorPublicCache_4() { return static_cast<int32_t>(offsetof(fsMetaType_t3266798926, ____isDefaultConstructorPublicCache_4)); }
	inline Nullable_1_t2088641033  get__isDefaultConstructorPublicCache_4() const { return ____isDefaultConstructorPublicCache_4; }
	inline Nullable_1_t2088641033 * get_address_of__isDefaultConstructorPublicCache_4() { return &____isDefaultConstructorPublicCache_4; }
	inline void set__isDefaultConstructorPublicCache_4(Nullable_1_t2088641033  value)
	{
		____isDefaultConstructorPublicCache_4 = value;
	}
};

struct fsMetaType_t3266798926_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<FullSerializer.fsConfig,System.Collections.Generic.Dictionary`2<System.Type,FullSerializer.fsMetaType>> FullSerializer.fsMetaType::_configMetaTypes
	Dictionary_2_t1238777147 * ____configMetaTypes_0;

public:
	inline static int32_t get_offset_of__configMetaTypes_0() { return static_cast<int32_t>(offsetof(fsMetaType_t3266798926_StaticFields, ____configMetaTypes_0)); }
	inline Dictionary_2_t1238777147 * get__configMetaTypes_0() const { return ____configMetaTypes_0; }
	inline Dictionary_2_t1238777147 ** get_address_of__configMetaTypes_0() { return &____configMetaTypes_0; }
	inline void set__configMetaTypes_0(Dictionary_2_t1238777147 * value)
	{
		____configMetaTypes_0 = value;
		Il2CppCodeGenWriteBarrier(&____configMetaTypes_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
