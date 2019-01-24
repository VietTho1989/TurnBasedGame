#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Exception1927440687.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.AndroidJavaException
struct  AndroidJavaException_t3997329726  : public Exception_t1927440687
{
public:
	// System.String UnityEngine.AndroidJavaException::mJavaStackTrace
	String_t* ___mJavaStackTrace_11;

public:
	inline static int32_t get_offset_of_mJavaStackTrace_11() { return static_cast<int32_t>(offsetof(AndroidJavaException_t3997329726, ___mJavaStackTrace_11)); }
	inline String_t* get_mJavaStackTrace_11() const { return ___mJavaStackTrace_11; }
	inline String_t** get_address_of_mJavaStackTrace_11() { return &___mJavaStackTrace_11; }
	inline void set_mJavaStackTrace_11(String_t* value)
	{
		___mJavaStackTrace_11 = value;
		Il2CppCodeGenWriteBarrier(&___mJavaStackTrace_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
