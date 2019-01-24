#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.IO.StringReader
struct StringReader_t1480123486;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.MiniJSON.Json/Parser
struct  Parser_t3380793361  : public Il2CppObject
{
public:
	// System.IO.StringReader Facebook.MiniJSON.Json/Parser::json
	StringReader_t1480123486 * ___json_0;

public:
	inline static int32_t get_offset_of_json_0() { return static_cast<int32_t>(offsetof(Parser_t3380793361, ___json_0)); }
	inline StringReader_t1480123486 * get_json_0() const { return ___json_0; }
	inline StringReader_t1480123486 ** get_address_of_json_0() { return &___json_0; }
	inline void set_json_0(StringReader_t1480123486 * value)
	{
		___json_0 = value;
		Il2CppCodeGenWriteBarrier(&___json_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
