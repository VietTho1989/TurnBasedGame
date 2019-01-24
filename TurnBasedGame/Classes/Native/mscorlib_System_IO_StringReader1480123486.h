#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_TextReader1561828458.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.StringReader
struct  StringReader_t1480123486  : public TextReader_t1561828458
{
public:
	// System.String System.IO.StringReader::source
	String_t* ___source_2;
	// System.Int32 System.IO.StringReader::nextChar
	int32_t ___nextChar_3;
	// System.Int32 System.IO.StringReader::sourceLength
	int32_t ___sourceLength_4;

public:
	inline static int32_t get_offset_of_source_2() { return static_cast<int32_t>(offsetof(StringReader_t1480123486, ___source_2)); }
	inline String_t* get_source_2() const { return ___source_2; }
	inline String_t** get_address_of_source_2() { return &___source_2; }
	inline void set_source_2(String_t* value)
	{
		___source_2 = value;
		Il2CppCodeGenWriteBarrier(&___source_2, value);
	}

	inline static int32_t get_offset_of_nextChar_3() { return static_cast<int32_t>(offsetof(StringReader_t1480123486, ___nextChar_3)); }
	inline int32_t get_nextChar_3() const { return ___nextChar_3; }
	inline int32_t* get_address_of_nextChar_3() { return &___nextChar_3; }
	inline void set_nextChar_3(int32_t value)
	{
		___nextChar_3 = value;
	}

	inline static int32_t get_offset_of_sourceLength_4() { return static_cast<int32_t>(offsetof(StringReader_t1480123486, ___sourceLength_4)); }
	inline int32_t get_sourceLength_4() const { return ___sourceLength_4; }
	inline int32_t* get_address_of_sourceLength_4() { return &___sourceLength_4; }
	inline void set_sourceLength_4(int32_t value)
	{
		___sourceLength_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
