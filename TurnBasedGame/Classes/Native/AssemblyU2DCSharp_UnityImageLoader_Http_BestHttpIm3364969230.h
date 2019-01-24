#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityImageLoader.Http.AbstractHttp/OnResponseDelegate
struct OnResponseDelegate_t3960097161;
// UnityImageLoader.Http.BestHttpImpl
struct BestHttpImpl_t43057110;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Http.BestHttpImpl/<Post>c__AnonStorey1
struct  U3CPostU3Ec__AnonStorey1_t3364969230  : public Il2CppObject
{
public:
	// UnityImageLoader.Http.AbstractHttp/OnResponseDelegate UnityImageLoader.Http.BestHttpImpl/<Post>c__AnonStorey1::callback
	OnResponseDelegate_t3960097161 * ___callback_0;
	// UnityImageLoader.Http.BestHttpImpl UnityImageLoader.Http.BestHttpImpl/<Post>c__AnonStorey1::$this
	BestHttpImpl_t43057110 * ___U24this_1;

public:
	inline static int32_t get_offset_of_callback_0() { return static_cast<int32_t>(offsetof(U3CPostU3Ec__AnonStorey1_t3364969230, ___callback_0)); }
	inline OnResponseDelegate_t3960097161 * get_callback_0() const { return ___callback_0; }
	inline OnResponseDelegate_t3960097161 ** get_address_of_callback_0() { return &___callback_0; }
	inline void set_callback_0(OnResponseDelegate_t3960097161 * value)
	{
		___callback_0 = value;
		Il2CppCodeGenWriteBarrier(&___callback_0, value);
	}

	inline static int32_t get_offset_of_U24this_1() { return static_cast<int32_t>(offsetof(U3CPostU3Ec__AnonStorey1_t3364969230, ___U24this_1)); }
	inline BestHttpImpl_t43057110 * get_U24this_1() const { return ___U24this_1; }
	inline BestHttpImpl_t43057110 ** get_address_of_U24this_1() { return &___U24this_1; }
	inline void set_U24this_1(BestHttpImpl_t43057110 * value)
	{
		___U24this_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
