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
// System.Xml.NameTable/Entry
struct Entry_t2583369454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.NameTable/Entry
struct  Entry_t2583369454  : public Il2CppObject
{
public:
	// System.String System.Xml.NameTable/Entry::str
	String_t* ___str_0;
	// System.Int32 System.Xml.NameTable/Entry::hash
	int32_t ___hash_1;
	// System.Int32 System.Xml.NameTable/Entry::len
	int32_t ___len_2;
	// System.Xml.NameTable/Entry System.Xml.NameTable/Entry::next
	Entry_t2583369454 * ___next_3;

public:
	inline static int32_t get_offset_of_str_0() { return static_cast<int32_t>(offsetof(Entry_t2583369454, ___str_0)); }
	inline String_t* get_str_0() const { return ___str_0; }
	inline String_t** get_address_of_str_0() { return &___str_0; }
	inline void set_str_0(String_t* value)
	{
		___str_0 = value;
		Il2CppCodeGenWriteBarrier(&___str_0, value);
	}

	inline static int32_t get_offset_of_hash_1() { return static_cast<int32_t>(offsetof(Entry_t2583369454, ___hash_1)); }
	inline int32_t get_hash_1() const { return ___hash_1; }
	inline int32_t* get_address_of_hash_1() { return &___hash_1; }
	inline void set_hash_1(int32_t value)
	{
		___hash_1 = value;
	}

	inline static int32_t get_offset_of_len_2() { return static_cast<int32_t>(offsetof(Entry_t2583369454, ___len_2)); }
	inline int32_t get_len_2() const { return ___len_2; }
	inline int32_t* get_address_of_len_2() { return &___len_2; }
	inline void set_len_2(int32_t value)
	{
		___len_2 = value;
	}

	inline static int32_t get_offset_of_next_3() { return static_cast<int32_t>(offsetof(Entry_t2583369454, ___next_3)); }
	inline Entry_t2583369454 * get_next_3() const { return ___next_3; }
	inline Entry_t2583369454 ** get_address_of_next_3() { return &___next_3; }
	inline void set_next_3(Entry_t2583369454 * value)
	{
		___next_3 = value;
		Il2CppCodeGenWriteBarrier(&___next_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
