#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<UnityEngine.GameObject,System.Collections.Generic.List`1<System.Action`1<System.Object>>>
struct Dictionary_2_t895747957;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.ObjectMessage`1<System.Object>
struct  ObjectMessage_1_t2122909565  : public Il2CppObject
{
public:

public:
};

struct ObjectMessage_1_t2122909565_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<UnityEngine.GameObject,System.Collections.Generic.List`1<System.Action`1<T>>> Foundation.ObjectMessage`1::Messenger
	Dictionary_2_t895747957 * ___Messenger_0;

public:
	inline static int32_t get_offset_of_Messenger_0() { return static_cast<int32_t>(offsetof(ObjectMessage_1_t2122909565_StaticFields, ___Messenger_0)); }
	inline Dictionary_2_t895747957 * get_Messenger_0() const { return ___Messenger_0; }
	inline Dictionary_2_t895747957 ** get_address_of_Messenger_0() { return &___Messenger_0; }
	inline void set_Messenger_0(Dictionary_2_t895747957 * value)
	{
		___Messenger_0 = value;
		Il2CppCodeGenWriteBarrier(&___Messenger_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
