#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Net_FtpStatusCode1448112771.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FtpStatus
struct  FtpStatus_t3714482970  : public Il2CppObject
{
public:
	// System.Net.FtpStatusCode System.Net.FtpStatus::statusCode
	int32_t ___statusCode_0;
	// System.String System.Net.FtpStatus::statusDescription
	String_t* ___statusDescription_1;

public:
	inline static int32_t get_offset_of_statusCode_0() { return static_cast<int32_t>(offsetof(FtpStatus_t3714482970, ___statusCode_0)); }
	inline int32_t get_statusCode_0() const { return ___statusCode_0; }
	inline int32_t* get_address_of_statusCode_0() { return &___statusCode_0; }
	inline void set_statusCode_0(int32_t value)
	{
		___statusCode_0 = value;
	}

	inline static int32_t get_offset_of_statusDescription_1() { return static_cast<int32_t>(offsetof(FtpStatus_t3714482970, ___statusDescription_1)); }
	inline String_t* get_statusDescription_1() const { return ___statusDescription_1; }
	inline String_t** get_address_of_statusDescription_1() { return &___statusDescription_1; }
	inline void set_statusDescription_1(String_t* value)
	{
		___statusDescription_1 = value;
		Il2CppCodeGenWriteBarrier(&___statusDescription_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
