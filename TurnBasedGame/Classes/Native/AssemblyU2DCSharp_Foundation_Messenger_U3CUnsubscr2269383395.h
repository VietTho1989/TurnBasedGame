#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Delegate
struct Delegate_t3022476291;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Messenger/<Unsubscribe>c__AnonStorey2
struct  U3CUnsubscribeU3Ec__AnonStorey2_t2269383395  : public Il2CppObject
{
public:
	// System.Delegate Foundation.Messenger/<Unsubscribe>c__AnonStorey2::handler
	Delegate_t3022476291 * ___handler_0;

public:
	inline static int32_t get_offset_of_handler_0() { return static_cast<int32_t>(offsetof(U3CUnsubscribeU3Ec__AnonStorey2_t2269383395, ___handler_0)); }
	inline Delegate_t3022476291 * get_handler_0() const { return ___handler_0; }
	inline Delegate_t3022476291 ** get_address_of_handler_0() { return &___handler_0; }
	inline void set_handler_0(Delegate_t3022476291 * value)
	{
		___handler_0 = value;
		Il2CppCodeGenWriteBarrier(&___handler_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
