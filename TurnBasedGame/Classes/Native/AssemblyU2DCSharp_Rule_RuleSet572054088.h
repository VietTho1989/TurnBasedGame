#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[0...,0...]
struct ByteU5BU2CU5D_t3397334014;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rule.RuleSet
struct  RuleSet_t572054088  : public Il2CppObject
{
public:
	// System.Byte[0...,0...] Rule.RuleSet::matrix
	ByteU5BU2CU5D_t3397334014* ___matrix_0;
	// System.Byte Rule.RuleSet::x
	uint8_t ___x_1;
	// System.Byte Rule.RuleSet::y
	uint8_t ___y_2;
	// System.Byte Rule.RuleSet::otherKing
	uint8_t ___otherKing_3;

public:
	inline static int32_t get_offset_of_matrix_0() { return static_cast<int32_t>(offsetof(RuleSet_t572054088, ___matrix_0)); }
	inline ByteU5BU2CU5D_t3397334014* get_matrix_0() const { return ___matrix_0; }
	inline ByteU5BU2CU5D_t3397334014** get_address_of_matrix_0() { return &___matrix_0; }
	inline void set_matrix_0(ByteU5BU2CU5D_t3397334014* value)
	{
		___matrix_0 = value;
		Il2CppCodeGenWriteBarrier(&___matrix_0, value);
	}

	inline static int32_t get_offset_of_x_1() { return static_cast<int32_t>(offsetof(RuleSet_t572054088, ___x_1)); }
	inline uint8_t get_x_1() const { return ___x_1; }
	inline uint8_t* get_address_of_x_1() { return &___x_1; }
	inline void set_x_1(uint8_t value)
	{
		___x_1 = value;
	}

	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(RuleSet_t572054088, ___y_2)); }
	inline uint8_t get_y_2() const { return ___y_2; }
	inline uint8_t* get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(uint8_t value)
	{
		___y_2 = value;
	}

	inline static int32_t get_offset_of_otherKing_3() { return static_cast<int32_t>(offsetof(RuleSet_t572054088, ___otherKing_3)); }
	inline uint8_t get_otherKing_3() const { return ___otherKing_3; }
	inline uint8_t* get_address_of_otherKing_3() { return &___otherKing_3; }
	inline void set_otherKing_3(uint8_t value)
	{
		___otherKing_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
