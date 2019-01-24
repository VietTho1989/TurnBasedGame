#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;
// FullSerializer.fsData
struct fsData_t2583805605;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsData
struct  fsData_t2583805605  : public Il2CppObject
{
public:
	// System.Object FullSerializer.fsData::_value
	Il2CppObject * ____value_0;

public:
	inline static int32_t get_offset_of__value_0() { return static_cast<int32_t>(offsetof(fsData_t2583805605, ____value_0)); }
	inline Il2CppObject * get__value_0() const { return ____value_0; }
	inline Il2CppObject ** get_address_of__value_0() { return &____value_0; }
	inline void set__value_0(Il2CppObject * value)
	{
		____value_0 = value;
		Il2CppCodeGenWriteBarrier(&____value_0, value);
	}
};

struct fsData_t2583805605_StaticFields
{
public:
	// FullSerializer.fsData FullSerializer.fsData::True
	fsData_t2583805605 * ___True_1;
	// FullSerializer.fsData FullSerializer.fsData::False
	fsData_t2583805605 * ___False_2;
	// FullSerializer.fsData FullSerializer.fsData::Null
	fsData_t2583805605 * ___Null_3;

public:
	inline static int32_t get_offset_of_True_1() { return static_cast<int32_t>(offsetof(fsData_t2583805605_StaticFields, ___True_1)); }
	inline fsData_t2583805605 * get_True_1() const { return ___True_1; }
	inline fsData_t2583805605 ** get_address_of_True_1() { return &___True_1; }
	inline void set_True_1(fsData_t2583805605 * value)
	{
		___True_1 = value;
		Il2CppCodeGenWriteBarrier(&___True_1, value);
	}

	inline static int32_t get_offset_of_False_2() { return static_cast<int32_t>(offsetof(fsData_t2583805605_StaticFields, ___False_2)); }
	inline fsData_t2583805605 * get_False_2() const { return ___False_2; }
	inline fsData_t2583805605 ** get_address_of_False_2() { return &___False_2; }
	inline void set_False_2(fsData_t2583805605 * value)
	{
		___False_2 = value;
		Il2CppCodeGenWriteBarrier(&___False_2, value);
	}

	inline static int32_t get_offset_of_Null_3() { return static_cast<int32_t>(offsetof(fsData_t2583805605_StaticFields, ___Null_3)); }
	inline fsData_t2583805605 * get_Null_3() const { return ___Null_3; }
	inline fsData_t2583805605 ** get_address_of_Null_3() { return &___Null_3; }
	inline void set_Null_3(fsData_t2583805605 * value)
	{
		___Null_3 = value;
		Il2CppCodeGenWriteBarrier(&___Null_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
