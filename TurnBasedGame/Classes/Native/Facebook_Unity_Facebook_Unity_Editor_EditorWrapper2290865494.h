#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Facebook.Unity.IFacebookCallbackHandler
struct IFacebookCallbackHandler_t1053405458;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Editor.EditorWrapper
struct  EditorWrapper_t2290865494  : public Il2CppObject
{
public:
	// Facebook.Unity.IFacebookCallbackHandler Facebook.Unity.Editor.EditorWrapper::callbackHandler
	Il2CppObject * ___callbackHandler_0;

public:
	inline static int32_t get_offset_of_callbackHandler_0() { return static_cast<int32_t>(offsetof(EditorWrapper_t2290865494, ___callbackHandler_0)); }
	inline Il2CppObject * get_callbackHandler_0() const { return ___callbackHandler_0; }
	inline Il2CppObject ** get_address_of_callbackHandler_0() { return &___callbackHandler_0; }
	inline void set_callbackHandler_0(Il2CppObject * value)
	{
		___callbackHandler_0 = value;
		Il2CppCodeGenWriteBarrier(&___callbackHandler_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
