#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.ComponentModel.AttributeCollection
struct AttributeCollection_t1925812292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.AttributeCollection
struct  AttributeCollection_t1925812292  : public Il2CppObject
{
public:
	// System.Collections.ArrayList System.ComponentModel.AttributeCollection::attrList
	ArrayList_t4252133567 * ___attrList_0;

public:
	inline static int32_t get_offset_of_attrList_0() { return static_cast<int32_t>(offsetof(AttributeCollection_t1925812292, ___attrList_0)); }
	inline ArrayList_t4252133567 * get_attrList_0() const { return ___attrList_0; }
	inline ArrayList_t4252133567 ** get_address_of_attrList_0() { return &___attrList_0; }
	inline void set_attrList_0(ArrayList_t4252133567 * value)
	{
		___attrList_0 = value;
		Il2CppCodeGenWriteBarrier(&___attrList_0, value);
	}
};

struct AttributeCollection_t1925812292_StaticFields
{
public:
	// System.ComponentModel.AttributeCollection System.ComponentModel.AttributeCollection::Empty
	AttributeCollection_t1925812292 * ___Empty_1;

public:
	inline static int32_t get_offset_of_Empty_1() { return static_cast<int32_t>(offsetof(AttributeCollection_t1925812292_StaticFields, ___Empty_1)); }
	inline AttributeCollection_t1925812292 * get_Empty_1() const { return ___Empty_1; }
	inline AttributeCollection_t1925812292 ** get_address_of_Empty_1() { return &___Empty_1; }
	inline void set_Empty_1(AttributeCollection_t1925812292 * value)
	{
		___Empty_1 = value;
		Il2CppCodeGenWriteBarrier(&___Empty_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
