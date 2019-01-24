#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Cache.AbstractDiscCache
struct  AbstractDiscCache_t3695984079  : public Il2CppObject
{
public:
	// System.String UnityImageLoader.Cache.AbstractDiscCache::cachePath
	String_t* ___cachePath_0;

public:
	inline static int32_t get_offset_of_cachePath_0() { return static_cast<int32_t>(offsetof(AbstractDiscCache_t3695984079, ___cachePath_0)); }
	inline String_t* get_cachePath_0() const { return ___cachePath_0; }
	inline String_t** get_address_of_cachePath_0() { return &___cachePath_0; }
	inline void set_cachePath_0(String_t* value)
	{
		___cachePath_0 = value;
		Il2CppCodeGenWriteBarrier(&___cachePath_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
