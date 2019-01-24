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
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;
// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.String>,System.String>
struct Func_2_t4206299577;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Peregrine.Engine.CommandEvent
struct  CommandEvent_t1920976071  : public Il2CppObject
{
public:
	// System.Int32 Peregrine.Engine.CommandEvent::Sequence
	int32_t ___Sequence_0;
	// System.String Peregrine.Engine.CommandEvent::AggregateId
	String_t* ___AggregateId_1;
	// System.String Peregrine.Engine.CommandEvent::Name
	String_t* ___Name_2;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> Peregrine.Engine.CommandEvent::Properties
	Dictionary_2_t3943999495 * ___Properties_3;

public:
	inline static int32_t get_offset_of_Sequence_0() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071, ___Sequence_0)); }
	inline int32_t get_Sequence_0() const { return ___Sequence_0; }
	inline int32_t* get_address_of_Sequence_0() { return &___Sequence_0; }
	inline void set_Sequence_0(int32_t value)
	{
		___Sequence_0 = value;
	}

	inline static int32_t get_offset_of_AggregateId_1() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071, ___AggregateId_1)); }
	inline String_t* get_AggregateId_1() const { return ___AggregateId_1; }
	inline String_t** get_address_of_AggregateId_1() { return &___AggregateId_1; }
	inline void set_AggregateId_1(String_t* value)
	{
		___AggregateId_1 = value;
		Il2CppCodeGenWriteBarrier(&___AggregateId_1, value);
	}

	inline static int32_t get_offset_of_Name_2() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071, ___Name_2)); }
	inline String_t* get_Name_2() const { return ___Name_2; }
	inline String_t** get_address_of_Name_2() { return &___Name_2; }
	inline void set_Name_2(String_t* value)
	{
		___Name_2 = value;
		Il2CppCodeGenWriteBarrier(&___Name_2, value);
	}

	inline static int32_t get_offset_of_Properties_3() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071, ___Properties_3)); }
	inline Dictionary_2_t3943999495 * get_Properties_3() const { return ___Properties_3; }
	inline Dictionary_2_t3943999495 ** get_address_of_Properties_3() { return &___Properties_3; }
	inline void set_Properties_3(Dictionary_2_t3943999495 * value)
	{
		___Properties_3 = value;
		Il2CppCodeGenWriteBarrier(&___Properties_3, value);
	}
};

struct CommandEvent_t1920976071_StaticFields
{
public:
	// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.String>,System.String> Peregrine.Engine.CommandEvent::<>f__am$cache0
	Func_2_t4206299577 * ___U3CU3Ef__amU24cache0_4;
	// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.String>,System.String> Peregrine.Engine.CommandEvent::<>f__am$cache1
	Func_2_t4206299577 * ___U3CU3Ef__amU24cache1_5;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_4() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071_StaticFields, ___U3CU3Ef__amU24cache0_4)); }
	inline Func_2_t4206299577 * get_U3CU3Ef__amU24cache0_4() const { return ___U3CU3Ef__amU24cache0_4; }
	inline Func_2_t4206299577 ** get_address_of_U3CU3Ef__amU24cache0_4() { return &___U3CU3Ef__amU24cache0_4; }
	inline void set_U3CU3Ef__amU24cache0_4(Func_2_t4206299577 * value)
	{
		___U3CU3Ef__amU24cache0_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_4, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_5() { return static_cast<int32_t>(offsetof(CommandEvent_t1920976071_StaticFields, ___U3CU3Ef__amU24cache1_5)); }
	inline Func_2_t4206299577 * get_U3CU3Ef__amU24cache1_5() const { return ___U3CU3Ef__amU24cache1_5; }
	inline Func_2_t4206299577 ** get_address_of_U3CU3Ef__amU24cache1_5() { return &___U3CU3Ef__amU24cache1_5; }
	inline void set_U3CU3Ef__amU24cache1_5(Func_2_t4206299577 * value)
	{
		___U3CU3Ef__amU24cache1_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
