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

// System.Net.CookieParser
struct  CookieParser_t1405985527  : public Il2CppObject
{
public:
	// System.String System.Net.CookieParser::header
	String_t* ___header_0;
	// System.Int32 System.Net.CookieParser::pos
	int32_t ___pos_1;
	// System.Int32 System.Net.CookieParser::length
	int32_t ___length_2;

public:
	inline static int32_t get_offset_of_header_0() { return static_cast<int32_t>(offsetof(CookieParser_t1405985527, ___header_0)); }
	inline String_t* get_header_0() const { return ___header_0; }
	inline String_t** get_address_of_header_0() { return &___header_0; }
	inline void set_header_0(String_t* value)
	{
		___header_0 = value;
		Il2CppCodeGenWriteBarrier(&___header_0, value);
	}

	inline static int32_t get_offset_of_pos_1() { return static_cast<int32_t>(offsetof(CookieParser_t1405985527, ___pos_1)); }
	inline int32_t get_pos_1() const { return ___pos_1; }
	inline int32_t* get_address_of_pos_1() { return &___pos_1; }
	inline void set_pos_1(int32_t value)
	{
		___pos_1 = value;
	}

	inline static int32_t get_offset_of_length_2() { return static_cast<int32_t>(offsetof(CookieParser_t1405985527, ___length_2)); }
	inline int32_t get_length_2() const { return ___length_2; }
	inline int32_t* get_address_of_length_2() { return &___length_2; }
	inline void set_length_2(int32_t value)
	{
		___length_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
