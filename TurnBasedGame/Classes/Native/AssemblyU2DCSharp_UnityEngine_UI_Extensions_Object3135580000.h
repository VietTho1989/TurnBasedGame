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
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t309261261;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ObjectComponent
struct  ObjectComponent_t3135580000  : public Il2CppObject
{
public:
	// System.String UnityEngine.UI.Extensions.ObjectComponent::componentName
	String_t* ___componentName_0;
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> UnityEngine.UI.Extensions.ObjectComponent::fields
	Dictionary_2_t309261261 * ___fields_1;

public:
	inline static int32_t get_offset_of_componentName_0() { return static_cast<int32_t>(offsetof(ObjectComponent_t3135580000, ___componentName_0)); }
	inline String_t* get_componentName_0() const { return ___componentName_0; }
	inline String_t** get_address_of_componentName_0() { return &___componentName_0; }
	inline void set_componentName_0(String_t* value)
	{
		___componentName_0 = value;
		Il2CppCodeGenWriteBarrier(&___componentName_0, value);
	}

	inline static int32_t get_offset_of_fields_1() { return static_cast<int32_t>(offsetof(ObjectComponent_t3135580000, ___fields_1)); }
	inline Dictionary_2_t309261261 * get_fields_1() const { return ___fields_1; }
	inline Dictionary_2_t309261261 ** get_address_of_fields_1() { return &___fields_1; }
	inline void set_fields_1(Dictionary_2_t309261261 * value)
	{
		___fields_1 = value;
		Il2CppCodeGenWriteBarrier(&___fields_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
