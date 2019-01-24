#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Object
struct Il2CppObject;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Databinding.ObservableMessage
struct  ObservableMessage_t2819695798  : public Il2CppObject
{
public:
	// System.Object Foundation.Databinding.ObservableMessage::Sender
	Il2CppObject * ___Sender_0;
	// System.String Foundation.Databinding.ObservableMessage::Name
	String_t* ___Name_1;
	// System.Object Foundation.Databinding.ObservableMessage::Value
	Il2CppObject * ___Value_2;

public:
	inline static int32_t get_offset_of_Sender_0() { return static_cast<int32_t>(offsetof(ObservableMessage_t2819695798, ___Sender_0)); }
	inline Il2CppObject * get_Sender_0() const { return ___Sender_0; }
	inline Il2CppObject ** get_address_of_Sender_0() { return &___Sender_0; }
	inline void set_Sender_0(Il2CppObject * value)
	{
		___Sender_0 = value;
		Il2CppCodeGenWriteBarrier(&___Sender_0, value);
	}

	inline static int32_t get_offset_of_Name_1() { return static_cast<int32_t>(offsetof(ObservableMessage_t2819695798, ___Name_1)); }
	inline String_t* get_Name_1() const { return ___Name_1; }
	inline String_t** get_address_of_Name_1() { return &___Name_1; }
	inline void set_Name_1(String_t* value)
	{
		___Name_1 = value;
		Il2CppCodeGenWriteBarrier(&___Name_1, value);
	}

	inline static int32_t get_offset_of_Value_2() { return static_cast<int32_t>(offsetof(ObservableMessage_t2819695798, ___Value_2)); }
	inline Il2CppObject * get_Value_2() const { return ___Value_2; }
	inline Il2CppObject ** get_address_of_Value_2() { return &___Value_2; }
	inline void set_Value_2(Il2CppObject * value)
	{
		___Value_2 = value;
		Il2CppCodeGenWriteBarrier(&___Value_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
