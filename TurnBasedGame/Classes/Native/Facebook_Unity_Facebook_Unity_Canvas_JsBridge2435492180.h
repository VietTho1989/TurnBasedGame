#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler
struct ICanvasFacebookCallbackHandler_t583361118;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Canvas.JsBridge
struct  JsBridge_t2435492180  : public MonoBehaviour_t1158329972
{
public:
	// Facebook.Unity.Canvas.ICanvasFacebookCallbackHandler Facebook.Unity.Canvas.JsBridge::facebook
	Il2CppObject * ___facebook_2;

public:
	inline static int32_t get_offset_of_facebook_2() { return static_cast<int32_t>(offsetof(JsBridge_t2435492180, ___facebook_2)); }
	inline Il2CppObject * get_facebook_2() const { return ___facebook_2; }
	inline Il2CppObject ** get_address_of_facebook_2() { return &___facebook_2; }
	inline void set_facebook_2(Il2CppObject * value)
	{
		___facebook_2 = value;
		Il2CppCodeGenWriteBarrier(&___facebook_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
