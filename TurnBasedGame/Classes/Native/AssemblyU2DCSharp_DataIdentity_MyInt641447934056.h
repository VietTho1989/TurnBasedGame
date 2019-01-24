#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// DataIdentity/MyInt64/LongConvert
struct LongConvert_t894413374;
// DataIdentity/MyInt64/MyInt64Convert
struct MyInt64Convert_t1069542835;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DataIdentity/MyInt64
struct  MyInt64_t1447934056 
{
public:
	// System.Int64 DataIdentity/MyInt64::value
	int64_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(MyInt64_t1447934056, ___value_0)); }
	inline int64_t get_value_0() const { return ___value_0; }
	inline int64_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int64_t value)
	{
		___value_0 = value;
	}
};

struct MyInt64_t1447934056_StaticFields
{
public:
	// DataIdentity/MyInt64/LongConvert DataIdentity/MyInt64::longConvert
	LongConvert_t894413374 * ___longConvert_1;
	// DataIdentity/MyInt64/MyInt64Convert DataIdentity/MyInt64::myInt64Convert
	MyInt64Convert_t1069542835 * ___myInt64Convert_2;

public:
	inline static int32_t get_offset_of_longConvert_1() { return static_cast<int32_t>(offsetof(MyInt64_t1447934056_StaticFields, ___longConvert_1)); }
	inline LongConvert_t894413374 * get_longConvert_1() const { return ___longConvert_1; }
	inline LongConvert_t894413374 ** get_address_of_longConvert_1() { return &___longConvert_1; }
	inline void set_longConvert_1(LongConvert_t894413374 * value)
	{
		___longConvert_1 = value;
		Il2CppCodeGenWriteBarrier(&___longConvert_1, value);
	}

	inline static int32_t get_offset_of_myInt64Convert_2() { return static_cast<int32_t>(offsetof(MyInt64_t1447934056_StaticFields, ___myInt64Convert_2)); }
	inline MyInt64Convert_t1069542835 * get_myInt64Convert_2() const { return ___myInt64Convert_2; }
	inline MyInt64Convert_t1069542835 ** get_address_of_myInt64Convert_2() { return &___myInt64Convert_2; }
	inline void set_myInt64Convert_2(MyInt64Convert_t1069542835 * value)
	{
		___myInt64Convert_2 = value;
		Il2CppCodeGenWriteBarrier(&___myInt64Convert_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
