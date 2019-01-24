#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AssemblyU2DCSharp_FullSerializer_Internal_fsVersion654750358.h"
#include "AssemblyU2DCSharp_FullSerializer_Internal_fsOption_972008496.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsOption`1<FullSerializer.Internal.fsVersionedType>
struct  fsOption_1_t972008496 
{
public:
	// System.Boolean FullSerializer.Internal.fsOption`1::_hasValue
	bool ____hasValue_0;
	// T FullSerializer.Internal.fsOption`1::_value
	fsVersionedType_t654750358  ____value_1;

public:
	inline static int32_t get_offset_of__hasValue_0() { return static_cast<int32_t>(offsetof(fsOption_1_t972008496, ____hasValue_0)); }
	inline bool get__hasValue_0() const { return ____hasValue_0; }
	inline bool* get_address_of__hasValue_0() { return &____hasValue_0; }
	inline void set__hasValue_0(bool value)
	{
		____hasValue_0 = value;
	}

	inline static int32_t get_offset_of__value_1() { return static_cast<int32_t>(offsetof(fsOption_1_t972008496, ____value_1)); }
	inline fsVersionedType_t654750358  get__value_1() const { return ____value_1; }
	inline fsVersionedType_t654750358 * get_address_of__value_1() { return &____value_1; }
	inline void set__value_1(fsVersionedType_t654750358  value)
	{
		____value_1 = value;
	}
};

struct fsOption_1_t972008496_StaticFields
{
public:
	// FullSerializer.Internal.fsOption`1<T> FullSerializer.Internal.fsOption`1::Empty
	fsOption_1_t972008496  ___Empty_2;

public:
	inline static int32_t get_offset_of_Empty_2() { return static_cast<int32_t>(offsetof(fsOption_1_t972008496_StaticFields, ___Empty_2)); }
	inline fsOption_1_t972008496  get_Empty_2() const { return ___Empty_2; }
	inline fsOption_1_t972008496 * get_address_of_Empty_2() { return &___Empty_2; }
	inline void set_Empty_2(fsOption_1_t972008496  value)
	{
		___Empty_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
