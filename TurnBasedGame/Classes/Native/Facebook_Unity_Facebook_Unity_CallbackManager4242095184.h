#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IDictionary`2<System.String,System.Object>
struct IDictionary_2_t2603311978;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.CallbackManager
struct  CallbackManager_t4242095184  : public Il2CppObject
{
public:
	// System.Collections.Generic.IDictionary`2<System.String,System.Object> Facebook.Unity.CallbackManager::facebookDelegates
	Il2CppObject* ___facebookDelegates_0;
	// System.Int32 Facebook.Unity.CallbackManager::nextAsyncId
	int32_t ___nextAsyncId_1;

public:
	inline static int32_t get_offset_of_facebookDelegates_0() { return static_cast<int32_t>(offsetof(CallbackManager_t4242095184, ___facebookDelegates_0)); }
	inline Il2CppObject* get_facebookDelegates_0() const { return ___facebookDelegates_0; }
	inline Il2CppObject** get_address_of_facebookDelegates_0() { return &___facebookDelegates_0; }
	inline void set_facebookDelegates_0(Il2CppObject* value)
	{
		___facebookDelegates_0 = value;
		Il2CppCodeGenWriteBarrier(&___facebookDelegates_0, value);
	}

	inline static int32_t get_offset_of_nextAsyncId_1() { return static_cast<int32_t>(offsetof(CallbackManager_t4242095184, ___nextAsyncId_1)); }
	inline int32_t get_nextAsyncId_1() const { return ___nextAsyncId_1; }
	inline int32_t* get_address_of_nextAsyncId_1() { return &___nextAsyncId_1; }
	inline void set_nextAsyncId_1(int32_t value)
	{
		___nextAsyncId_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
