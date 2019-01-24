#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_Configuration_ConfigurationException3814184945.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationErrorsException
struct  ConfigurationErrorsException_t1362721126  : public ConfigurationException_t3814184945
{
public:
	// System.String System.Configuration.ConfigurationErrorsException::filename
	String_t* ___filename_13;
	// System.Int32 System.Configuration.ConfigurationErrorsException::line
	int32_t ___line_14;

public:
	inline static int32_t get_offset_of_filename_13() { return static_cast<int32_t>(offsetof(ConfigurationErrorsException_t1362721126, ___filename_13)); }
	inline String_t* get_filename_13() const { return ___filename_13; }
	inline String_t** get_address_of_filename_13() { return &___filename_13; }
	inline void set_filename_13(String_t* value)
	{
		___filename_13 = value;
		Il2CppCodeGenWriteBarrier(&___filename_13, value);
	}

	inline static int32_t get_offset_of_line_14() { return static_cast<int32_t>(offsetof(ConfigurationErrorsException_t1362721126, ___line_14)); }
	inline int32_t get_line_14() const { return ___line_14; }
	inline int32_t* get_address_of_line_14() { return &___line_14; }
	inline void set_line_14(int32_t value)
	{
		___line_14 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
