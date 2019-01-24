#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// DataIdentity/MyUInt64/ULongConvert
struct ULongConvert_t2045088064;
// DataIdentity/MyUInt64/MyUInt64Convert
struct MyUInt64Convert_t4045192155;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DataIdentity/MyUInt64
struct  MyUInt64_t3550747915 
{
public:
	// System.UInt64 DataIdentity/MyUInt64::value
	uint64_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(MyUInt64_t3550747915, ___value_0)); }
	inline uint64_t get_value_0() const { return ___value_0; }
	inline uint64_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(uint64_t value)
	{
		___value_0 = value;
	}
};

struct MyUInt64_t3550747915_StaticFields
{
public:
	// DataIdentity/MyUInt64/ULongConvert DataIdentity/MyUInt64::uLongConvert
	ULongConvert_t2045088064 * ___uLongConvert_1;
	// DataIdentity/MyUInt64/MyUInt64Convert DataIdentity/MyUInt64::myUInt64Convert
	MyUInt64Convert_t4045192155 * ___myUInt64Convert_2;

public:
	inline static int32_t get_offset_of_uLongConvert_1() { return static_cast<int32_t>(offsetof(MyUInt64_t3550747915_StaticFields, ___uLongConvert_1)); }
	inline ULongConvert_t2045088064 * get_uLongConvert_1() const { return ___uLongConvert_1; }
	inline ULongConvert_t2045088064 ** get_address_of_uLongConvert_1() { return &___uLongConvert_1; }
	inline void set_uLongConvert_1(ULongConvert_t2045088064 * value)
	{
		___uLongConvert_1 = value;
		Il2CppCodeGenWriteBarrier(&___uLongConvert_1, value);
	}

	inline static int32_t get_offset_of_myUInt64Convert_2() { return static_cast<int32_t>(offsetof(MyUInt64_t3550747915_StaticFields, ___myUInt64Convert_2)); }
	inline MyUInt64Convert_t4045192155 * get_myUInt64Convert_2() const { return ___myUInt64Convert_2; }
	inline MyUInt64Convert_t4045192155 ** get_address_of_myUInt64Convert_2() { return &___myUInt64Convert_2; }
	inline void set_myUInt64Convert_2(MyUInt64Convert_t4045192155 * value)
	{
		___myUInt64Convert_2 = value;
		Il2CppCodeGenWriteBarrier(&___myUInt64Convert_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
