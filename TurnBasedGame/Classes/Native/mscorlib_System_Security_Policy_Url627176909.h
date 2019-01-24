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

// System.Security.Policy.Url
struct  Url_t627176909  : public Il2CppObject
{
public:
	// System.String System.Security.Policy.Url::origin_url
	String_t* ___origin_url_0;

public:
	inline static int32_t get_offset_of_origin_url_0() { return static_cast<int32_t>(offsetof(Url_t627176909, ___origin_url_0)); }
	inline String_t* get_origin_url_0() const { return ___origin_url_0; }
	inline String_t** get_address_of_origin_url_0() { return &___origin_url_0; }
	inline void set_origin_url_0(String_t* value)
	{
		___origin_url_0 = value;
		Il2CppCodeGenWriteBarrier(&___origin_url_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
