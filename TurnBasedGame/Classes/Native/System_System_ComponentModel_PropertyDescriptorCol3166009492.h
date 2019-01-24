#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.ComponentModel.PropertyDescriptorCollection
struct PropertyDescriptorCollection_t3166009492;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.PropertyDescriptorCollection
struct  PropertyDescriptorCollection_t3166009492  : public Il2CppObject
{
public:
	// System.Collections.ArrayList System.ComponentModel.PropertyDescriptorCollection::properties
	ArrayList_t4252133567 * ___properties_1;
	// System.Boolean System.ComponentModel.PropertyDescriptorCollection::readOnly
	bool ___readOnly_2;

public:
	inline static int32_t get_offset_of_properties_1() { return static_cast<int32_t>(offsetof(PropertyDescriptorCollection_t3166009492, ___properties_1)); }
	inline ArrayList_t4252133567 * get_properties_1() const { return ___properties_1; }
	inline ArrayList_t4252133567 ** get_address_of_properties_1() { return &___properties_1; }
	inline void set_properties_1(ArrayList_t4252133567 * value)
	{
		___properties_1 = value;
		Il2CppCodeGenWriteBarrier(&___properties_1, value);
	}

	inline static int32_t get_offset_of_readOnly_2() { return static_cast<int32_t>(offsetof(PropertyDescriptorCollection_t3166009492, ___readOnly_2)); }
	inline bool get_readOnly_2() const { return ___readOnly_2; }
	inline bool* get_address_of_readOnly_2() { return &___readOnly_2; }
	inline void set_readOnly_2(bool value)
	{
		___readOnly_2 = value;
	}
};

struct PropertyDescriptorCollection_t3166009492_StaticFields
{
public:
	// System.ComponentModel.PropertyDescriptorCollection System.ComponentModel.PropertyDescriptorCollection::Empty
	PropertyDescriptorCollection_t3166009492 * ___Empty_0;

public:
	inline static int32_t get_offset_of_Empty_0() { return static_cast<int32_t>(offsetof(PropertyDescriptorCollection_t3166009492_StaticFields, ___Empty_0)); }
	inline PropertyDescriptorCollection_t3166009492 * get_Empty_0() const { return ___Empty_0; }
	inline PropertyDescriptorCollection_t3166009492 ** get_address_of_Empty_0() { return &___Empty_0; }
	inline void set_Empty_0(PropertyDescriptorCollection_t3166009492 * value)
	{
		___Empty_0 = value;
		Il2CppCodeGenWriteBarrier(&___Empty_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
