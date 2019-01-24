#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// DataIdentity/MySByte/SByteConvert
struct SByteConvert_t2163993347;
// DataIdentity/MySByte/MySByteConvert
struct MySByteConvert_t3861120819;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// DataIdentity/MySByte
struct  MySByte_t1156310708 
{
public:
	// System.SByte DataIdentity/MySByte::value
	int8_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(MySByte_t1156310708, ___value_0)); }
	inline int8_t get_value_0() const { return ___value_0; }
	inline int8_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(int8_t value)
	{
		___value_0 = value;
	}
};

struct MySByte_t1156310708_StaticFields
{
public:
	// DataIdentity/MySByte/SByteConvert DataIdentity/MySByte::sbyteConvert
	SByteConvert_t2163993347 * ___sbyteConvert_1;
	// DataIdentity/MySByte/MySByteConvert DataIdentity/MySByte::mySByteConvert
	MySByteConvert_t3861120819 * ___mySByteConvert_2;

public:
	inline static int32_t get_offset_of_sbyteConvert_1() { return static_cast<int32_t>(offsetof(MySByte_t1156310708_StaticFields, ___sbyteConvert_1)); }
	inline SByteConvert_t2163993347 * get_sbyteConvert_1() const { return ___sbyteConvert_1; }
	inline SByteConvert_t2163993347 ** get_address_of_sbyteConvert_1() { return &___sbyteConvert_1; }
	inline void set_sbyteConvert_1(SByteConvert_t2163993347 * value)
	{
		___sbyteConvert_1 = value;
		Il2CppCodeGenWriteBarrier(&___sbyteConvert_1, value);
	}

	inline static int32_t get_offset_of_mySByteConvert_2() { return static_cast<int32_t>(offsetof(MySByte_t1156310708_StaticFields, ___mySByteConvert_2)); }
	inline MySByteConvert_t3861120819 * get_mySByteConvert_2() const { return ___mySByteConvert_2; }
	inline MySByteConvert_t3861120819 ** get_address_of_mySByteConvert_2() { return &___mySByteConvert_2; }
	inline void set_mySByteConvert_2(MySByteConvert_t3861120819 * value)
	{
		___mySByteConvert_2 = value;
		Il2CppCodeGenWriteBarrier(&___mySByteConvert_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
