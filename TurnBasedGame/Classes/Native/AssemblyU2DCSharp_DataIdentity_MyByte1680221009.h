#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// DataIdentity/MyByte/ByteConvert
struct ByteConvert_t173568335;
// DataIdentity/MyByte/MyByteConvert
struct MyByteConvert_t3207847287;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DataIdentity/MyByte
struct  MyByte_t1680221009 
{
public:
	// System.Byte DataIdentity/MyByte::value
	uint8_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(MyByte_t1680221009, ___value_0)); }
	inline uint8_t get_value_0() const { return ___value_0; }
	inline uint8_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(uint8_t value)
	{
		___value_0 = value;
	}
};

struct MyByte_t1680221009_StaticFields
{
public:
	// DataIdentity/MyByte/ByteConvert DataIdentity/MyByte::byteConvert
	ByteConvert_t173568335 * ___byteConvert_1;
	// DataIdentity/MyByte/MyByteConvert DataIdentity/MyByte::myByteConvert
	MyByteConvert_t3207847287 * ___myByteConvert_2;

public:
	inline static int32_t get_offset_of_byteConvert_1() { return static_cast<int32_t>(offsetof(MyByte_t1680221009_StaticFields, ___byteConvert_1)); }
	inline ByteConvert_t173568335 * get_byteConvert_1() const { return ___byteConvert_1; }
	inline ByteConvert_t173568335 ** get_address_of_byteConvert_1() { return &___byteConvert_1; }
	inline void set_byteConvert_1(ByteConvert_t173568335 * value)
	{
		___byteConvert_1 = value;
		Il2CppCodeGenWriteBarrier(&___byteConvert_1, value);
	}

	inline static int32_t get_offset_of_myByteConvert_2() { return static_cast<int32_t>(offsetof(MyByte_t1680221009_StaticFields, ___myByteConvert_2)); }
	inline MyByteConvert_t3207847287 * get_myByteConvert_2() const { return ___myByteConvert_2; }
	inline MyByteConvert_t3207847287 ** get_address_of_myByteConvert_2() { return &___myByteConvert_2; }
	inline void set_myByteConvert_2(MyByteConvert_t3207847287 * value)
	{
		___myByteConvert_2 = value;
		Il2CppCodeGenWriteBarrier(&___myByteConvert_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
