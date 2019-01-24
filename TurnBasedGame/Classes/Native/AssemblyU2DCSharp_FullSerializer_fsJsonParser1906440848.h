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
// System.Text.StringBuilder
struct StringBuilder_t1221177846;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsJsonParser
struct  fsJsonParser_t1906440848  : public Il2CppObject
{
public:
	// System.Int32 FullSerializer.fsJsonParser::_start
	int32_t ____start_0;
	// System.String FullSerializer.fsJsonParser::_input
	String_t* ____input_1;
	// System.Text.StringBuilder FullSerializer.fsJsonParser::_cachedStringBuilder
	StringBuilder_t1221177846 * ____cachedStringBuilder_2;

public:
	inline static int32_t get_offset_of__start_0() { return static_cast<int32_t>(offsetof(fsJsonParser_t1906440848, ____start_0)); }
	inline int32_t get__start_0() const { return ____start_0; }
	inline int32_t* get_address_of__start_0() { return &____start_0; }
	inline void set__start_0(int32_t value)
	{
		____start_0 = value;
	}

	inline static int32_t get_offset_of__input_1() { return static_cast<int32_t>(offsetof(fsJsonParser_t1906440848, ____input_1)); }
	inline String_t* get__input_1() const { return ____input_1; }
	inline String_t** get_address_of__input_1() { return &____input_1; }
	inline void set__input_1(String_t* value)
	{
		____input_1 = value;
		Il2CppCodeGenWriteBarrier(&____input_1, value);
	}

	inline static int32_t get_offset_of__cachedStringBuilder_2() { return static_cast<int32_t>(offsetof(fsJsonParser_t1906440848, ____cachedStringBuilder_2)); }
	inline StringBuilder_t1221177846 * get__cachedStringBuilder_2() const { return ____cachedStringBuilder_2; }
	inline StringBuilder_t1221177846 ** get_address_of__cachedStringBuilder_2() { return &____cachedStringBuilder_2; }
	inline void set__cachedStringBuilder_2(StringBuilder_t1221177846 * value)
	{
		____cachedStringBuilder_2 = value;
		Il2CppCodeGenWriteBarrier(&____cachedStringBuilder_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
