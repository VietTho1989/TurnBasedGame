#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_SystemException3877406272.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationException
struct  ConfigurationException_t3814184945  : public SystemException_t3877406272
{
public:
	// System.String System.Configuration.ConfigurationException::filename
	String_t* ___filename_11;
	// System.Int32 System.Configuration.ConfigurationException::line
	int32_t ___line_12;

public:
	inline static int32_t get_offset_of_filename_11() { return static_cast<int32_t>(offsetof(ConfigurationException_t3814184945, ___filename_11)); }
	inline String_t* get_filename_11() const { return ___filename_11; }
	inline String_t** get_address_of_filename_11() { return &___filename_11; }
	inline void set_filename_11(String_t* value)
	{
		___filename_11 = value;
		Il2CppCodeGenWriteBarrier(&___filename_11, value);
	}

	inline static int32_t get_offset_of_line_12() { return static_cast<int32_t>(offsetof(ConfigurationException_t3814184945, ___line_12)); }
	inline int32_t get_line_12() const { return ___line_12; }
	inline int32_t* get_address_of_line_12() { return &___line_12; }
	inline void set_line_12(int32_t value)
	{
		___line_12 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
