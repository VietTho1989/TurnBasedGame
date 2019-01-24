#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Attribute[]
struct AttributeU5BU5D_t4255796347;
// System.ComponentModel.AttributeCollection
struct AttributeCollection_t1925812292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.MemberDescriptor
struct  MemberDescriptor_t3749827553  : public Il2CppObject
{
public:
	// System.String System.ComponentModel.MemberDescriptor::name
	String_t* ___name_0;
	// System.Attribute[] System.ComponentModel.MemberDescriptor::attrs
	AttributeU5BU5D_t4255796347* ___attrs_1;
	// System.ComponentModel.AttributeCollection System.ComponentModel.MemberDescriptor::attrCollection
	AttributeCollection_t1925812292 * ___attrCollection_2;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(MemberDescriptor_t3749827553, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_attrs_1() { return static_cast<int32_t>(offsetof(MemberDescriptor_t3749827553, ___attrs_1)); }
	inline AttributeU5BU5D_t4255796347* get_attrs_1() const { return ___attrs_1; }
	inline AttributeU5BU5D_t4255796347** get_address_of_attrs_1() { return &___attrs_1; }
	inline void set_attrs_1(AttributeU5BU5D_t4255796347* value)
	{
		___attrs_1 = value;
		Il2CppCodeGenWriteBarrier(&___attrs_1, value);
	}

	inline static int32_t get_offset_of_attrCollection_2() { return static_cast<int32_t>(offsetof(MemberDescriptor_t3749827553, ___attrCollection_2)); }
	inline AttributeCollection_t1925812292 * get_attrCollection_2() const { return ___attrCollection_2; }
	inline AttributeCollection_t1925812292 ** get_address_of_attrCollection_2() { return &___attrCollection_2; }
	inline void set_attrCollection_2(AttributeCollection_t1925812292 * value)
	{
		___attrCollection_2 = value;
		Il2CppCodeGenWriteBarrier(&___attrCollection_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
