#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Settings.FacebookSettings/UrlSchemes
struct  UrlSchemes_t2066630273  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<System.String> Facebook.Unity.Settings.FacebookSettings/UrlSchemes::list
	List_1_t1398341365 * ___list_0;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(UrlSchemes_t2066630273, ___list_0)); }
	inline List_1_t1398341365 * get_list_0() const { return ___list_0; }
	inline List_1_t1398341365 ** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(List_1_t1398341365 * value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier(&___list_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
