#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Http.AbstractHttp
struct  AbstractHttp_t2902004550  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.String> UnityImageLoader.Http.AbstractHttp::headers
	Dictionary_2_t3943999495 * ___headers_0;
	// System.Int32 UnityImageLoader.Http.AbstractHttp::connectTimeout
	int32_t ___connectTimeout_1;
	// System.Int32 UnityImageLoader.Http.AbstractHttp::requestTimeout
	int32_t ___requestTimeout_2;

public:
	inline static int32_t get_offset_of_headers_0() { return static_cast<int32_t>(offsetof(AbstractHttp_t2902004550, ___headers_0)); }
	inline Dictionary_2_t3943999495 * get_headers_0() const { return ___headers_0; }
	inline Dictionary_2_t3943999495 ** get_address_of_headers_0() { return &___headers_0; }
	inline void set_headers_0(Dictionary_2_t3943999495 * value)
	{
		___headers_0 = value;
		Il2CppCodeGenWriteBarrier(&___headers_0, value);
	}

	inline static int32_t get_offset_of_connectTimeout_1() { return static_cast<int32_t>(offsetof(AbstractHttp_t2902004550, ___connectTimeout_1)); }
	inline int32_t get_connectTimeout_1() const { return ___connectTimeout_1; }
	inline int32_t* get_address_of_connectTimeout_1() { return &___connectTimeout_1; }
	inline void set_connectTimeout_1(int32_t value)
	{
		___connectTimeout_1 = value;
	}

	inline static int32_t get_offset_of_requestTimeout_2() { return static_cast<int32_t>(offsetof(AbstractHttp_t2902004550, ___requestTimeout_2)); }
	inline int32_t get_requestTimeout_2() const { return ___requestTimeout_2; }
	inline int32_t* get_address_of_requestTimeout_2() { return &___requestTimeout_2; }
	inline void set_requestTimeout_2(int32_t value)
	{
		___requestTimeout_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
