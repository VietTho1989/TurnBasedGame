#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.Field.IFiniteField
struct IFiniteField_t3190882390;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.Field.FiniteFields
struct  FiniteFields_t239290640  : public Il2CppObject
{
public:

public:
};

struct FiniteFields_t239290640_StaticFields
{
public:
	// Org.BouncyCastle.Math.Field.IFiniteField Org.BouncyCastle.Math.Field.FiniteFields::GF_2
	Il2CppObject * ___GF_2_0;
	// Org.BouncyCastle.Math.Field.IFiniteField Org.BouncyCastle.Math.Field.FiniteFields::GF_3
	Il2CppObject * ___GF_3_1;

public:
	inline static int32_t get_offset_of_GF_2_0() { return static_cast<int32_t>(offsetof(FiniteFields_t239290640_StaticFields, ___GF_2_0)); }
	inline Il2CppObject * get_GF_2_0() const { return ___GF_2_0; }
	inline Il2CppObject ** get_address_of_GF_2_0() { return &___GF_2_0; }
	inline void set_GF_2_0(Il2CppObject * value)
	{
		___GF_2_0 = value;
		Il2CppCodeGenWriteBarrier(&___GF_2_0, value);
	}

	inline static int32_t get_offset_of_GF_3_1() { return static_cast<int32_t>(offsetof(FiniteFields_t239290640_StaticFields, ___GF_3_1)); }
	inline Il2CppObject * get_GF_3_1() const { return ___GF_3_1; }
	inline Il2CppObject ** get_address_of_GF_3_1() { return &___GF_3_1; }
	inline void set_GF_3_1(Il2CppObject * value)
	{
		___GF_3_1 = value;
		Il2CppCodeGenWriteBarrier(&___GF_3_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
