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
// System.Type
struct Type_t;
// System.Delegate
struct Delegate_t3022476291;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger/<HasSubscription>c__AnonStorey8
struct  U3CHasSubscriptionU3Ec__AnonStorey8_t180200627  : public Il2CppObject
{
public:
	// System.Object Foundation.Messenger/<HasSubscription>c__AnonStorey8::instance
	Il2CppObject * ___instance_0;
	// System.Type Foundation.Messenger/<HasSubscription>c__AnonStorey8::messageType
	Type_t * ___messageType_1;
	// System.Delegate Foundation.Messenger/<HasSubscription>c__AnonStorey8::handler
	Delegate_t3022476291 * ___handler_2;

public:
	inline static int32_t get_offset_of_instance_0() { return static_cast<int32_t>(offsetof(U3CHasSubscriptionU3Ec__AnonStorey8_t180200627, ___instance_0)); }
	inline Il2CppObject * get_instance_0() const { return ___instance_0; }
	inline Il2CppObject ** get_address_of_instance_0() { return &___instance_0; }
	inline void set_instance_0(Il2CppObject * value)
	{
		___instance_0 = value;
		Il2CppCodeGenWriteBarrier(&___instance_0, value);
	}

	inline static int32_t get_offset_of_messageType_1() { return static_cast<int32_t>(offsetof(U3CHasSubscriptionU3Ec__AnonStorey8_t180200627, ___messageType_1)); }
	inline Type_t * get_messageType_1() const { return ___messageType_1; }
	inline Type_t ** get_address_of_messageType_1() { return &___messageType_1; }
	inline void set_messageType_1(Type_t * value)
	{
		___messageType_1 = value;
		Il2CppCodeGenWriteBarrier(&___messageType_1, value);
	}

	inline static int32_t get_offset_of_handler_2() { return static_cast<int32_t>(offsetof(U3CHasSubscriptionU3Ec__AnonStorey8_t180200627, ___handler_2)); }
	inline Delegate_t3022476291 * get_handler_2() const { return ___handler_2; }
	inline Delegate_t3022476291 ** get_address_of_handler_2() { return &___handler_2; }
	inline void set_handler_2(Delegate_t3022476291 * value)
	{
		___handler_2 = value;
		Il2CppCodeGenWriteBarrier(&___handler_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
