#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.VisualStatesBinder/StateValue
struct  StateValue_t4237807745 
{
public:
	// UnityEngine.GameObject Foundation.Databinding.VisualStatesBinder/StateValue::Target
	GameObject_t1756533147 * ___Target_0;
	// System.String Foundation.Databinding.VisualStatesBinder/StateValue::Value
	String_t* ___Value_1;

public:
	inline static int32_t get_offset_of_Target_0() { return static_cast<int32_t>(offsetof(StateValue_t4237807745, ___Target_0)); }
	inline GameObject_t1756533147 * get_Target_0() const { return ___Target_0; }
	inline GameObject_t1756533147 ** get_address_of_Target_0() { return &___Target_0; }
	inline void set_Target_0(GameObject_t1756533147 * value)
	{
		___Target_0 = value;
		Il2CppCodeGenWriteBarrier(&___Target_0, value);
	}

	inline static int32_t get_offset_of_Value_1() { return static_cast<int32_t>(offsetof(StateValue_t4237807745, ___Value_1)); }
	inline String_t* get_Value_1() const { return ___Value_1; }
	inline String_t** get_address_of_Value_1() { return &___Value_1; }
	inline void set_Value_1(String_t* value)
	{
		___Value_1 = value;
		Il2CppCodeGenWriteBarrier(&___Value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of Foundation.Databinding.VisualStatesBinder/StateValue
struct StateValue_t4237807745_marshaled_pinvoke
{
	GameObject_t1756533147 * ___Target_0;
	char* ___Value_1;
};
// Native definition for COM marshalling of Foundation.Databinding.VisualStatesBinder/StateValue
struct StateValue_t4237807745_marshaled_com
{
	GameObject_t1756533147 * ___Target_0;
	Il2CppChar* ___Value_1;
};
