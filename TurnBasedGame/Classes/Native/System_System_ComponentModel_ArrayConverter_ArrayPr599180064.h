#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_ComponentModel_PropertyDescriptor4250402154.h"

// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.ArrayConverter/ArrayPropertyDescriptor
struct  ArrayPropertyDescriptor_t599180064  : public PropertyDescriptor_t4250402154
{
public:
	// System.Int32 System.ComponentModel.ArrayConverter/ArrayPropertyDescriptor::index
	int32_t ___index_3;
	// System.Type System.ComponentModel.ArrayConverter/ArrayPropertyDescriptor::array_type
	Type_t * ___array_type_4;

public:
	inline static int32_t get_offset_of_index_3() { return static_cast<int32_t>(offsetof(ArrayPropertyDescriptor_t599180064, ___index_3)); }
	inline int32_t get_index_3() const { return ___index_3; }
	inline int32_t* get_address_of_index_3() { return &___index_3; }
	inline void set_index_3(int32_t value)
	{
		___index_3 = value;
	}

	inline static int32_t get_offset_of_array_type_4() { return static_cast<int32_t>(offsetof(ArrayPropertyDescriptor_t599180064, ___array_type_4)); }
	inline Type_t * get_array_type_4() const { return ___array_type_4; }
	inline Type_t ** get_address_of_array_type_4() { return &___array_type_4; }
	inline void set_array_type_4(Type_t * value)
	{
		___array_type_4 = value;
		Il2CppCodeGenWriteBarrier(&___array_type_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
