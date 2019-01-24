#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.Delegate
struct Delegate_t3022476291;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger/Subscription
struct  Subscription_t2495419740  : public Il2CppObject
{
public:
	// System.Type Foundation.Messenger/Subscription::MessageType
	Type_t * ___MessageType_0;
	// System.Delegate Foundation.Messenger/Subscription::Handler
	Delegate_t3022476291 * ___Handler_1;
	// System.Object Foundation.Messenger/Subscription::Instance
	Il2CppObject * ___Instance_2;

public:
	inline static int32_t get_offset_of_MessageType_0() { return static_cast<int32_t>(offsetof(Subscription_t2495419740, ___MessageType_0)); }
	inline Type_t * get_MessageType_0() const { return ___MessageType_0; }
	inline Type_t ** get_address_of_MessageType_0() { return &___MessageType_0; }
	inline void set_MessageType_0(Type_t * value)
	{
		___MessageType_0 = value;
		Il2CppCodeGenWriteBarrier(&___MessageType_0, value);
	}

	inline static int32_t get_offset_of_Handler_1() { return static_cast<int32_t>(offsetof(Subscription_t2495419740, ___Handler_1)); }
	inline Delegate_t3022476291 * get_Handler_1() const { return ___Handler_1; }
	inline Delegate_t3022476291 ** get_address_of_Handler_1() { return &___Handler_1; }
	inline void set_Handler_1(Delegate_t3022476291 * value)
	{
		___Handler_1 = value;
		Il2CppCodeGenWriteBarrier(&___Handler_1, value);
	}

	inline static int32_t get_offset_of_Instance_2() { return static_cast<int32_t>(offsetof(Subscription_t2495419740, ___Instance_2)); }
	inline Il2CppObject * get_Instance_2() const { return ___Instance_2; }
	inline Il2CppObject ** get_address_of_Instance_2() { return &___Instance_2; }
	inline void set_Instance_2(Il2CppObject * value)
	{
		___Instance_2 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
