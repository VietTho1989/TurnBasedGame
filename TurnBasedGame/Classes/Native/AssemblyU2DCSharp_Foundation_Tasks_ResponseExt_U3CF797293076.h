#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Action`1<Foundation.Tasks.Response`1<Foundation.Server.Api.GameScore[]>>
struct Action_1_t783557394;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Tasks.ResponseExt/<FromJsonResponse>c__AnonStorey1`1<Foundation.Server.Api.GameScore[]>
struct  U3CFromJsonResponseU3Ec__AnonStorey1_1_t797293076  : public Il2CppObject
{
public:
	// System.Action`1<Foundation.Tasks.Response`1<T>> Foundation.Tasks.ResponseExt/<FromJsonResponse>c__AnonStorey1`1::callback
	Action_1_t783557394 * ___callback_0;

public:
	inline static int32_t get_offset_of_callback_0() { return static_cast<int32_t>(offsetof(U3CFromJsonResponseU3Ec__AnonStorey1_1_t797293076, ___callback_0)); }
	inline Action_1_t783557394 * get_callback_0() const { return ___callback_0; }
	inline Action_1_t783557394 ** get_address_of_callback_0() { return &___callback_0; }
	inline void set_callback_0(Action_1_t783557394 * value)
	{
		___callback_0 = value;
		Il2CppCodeGenWriteBarrier(&___callback_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
