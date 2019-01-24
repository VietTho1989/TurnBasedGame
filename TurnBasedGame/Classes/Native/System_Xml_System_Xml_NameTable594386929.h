#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Xml_System_Xml_XmlNameTable1345805268.h"

// System.Xml.NameTable/Entry[]
struct EntryU5BU5D_t180042139;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.NameTable
struct  NameTable_t594386929  : public XmlNameTable_t1345805268
{
public:
	// System.Int32 System.Xml.NameTable::count
	int32_t ___count_0;
	// System.Xml.NameTable/Entry[] System.Xml.NameTable::buckets
	EntryU5BU5D_t180042139* ___buckets_1;
	// System.Int32 System.Xml.NameTable::size
	int32_t ___size_2;

public:
	inline static int32_t get_offset_of_count_0() { return static_cast<int32_t>(offsetof(NameTable_t594386929, ___count_0)); }
	inline int32_t get_count_0() const { return ___count_0; }
	inline int32_t* get_address_of_count_0() { return &___count_0; }
	inline void set_count_0(int32_t value)
	{
		___count_0 = value;
	}

	inline static int32_t get_offset_of_buckets_1() { return static_cast<int32_t>(offsetof(NameTable_t594386929, ___buckets_1)); }
	inline EntryU5BU5D_t180042139* get_buckets_1() const { return ___buckets_1; }
	inline EntryU5BU5D_t180042139** get_address_of_buckets_1() { return &___buckets_1; }
	inline void set_buckets_1(EntryU5BU5D_t180042139* value)
	{
		___buckets_1 = value;
		Il2CppCodeGenWriteBarrier(&___buckets_1, value);
	}

	inline static int32_t get_offset_of_size_2() { return static_cast<int32_t>(offsetof(NameTable_t594386929, ___size_2)); }
	inline int32_t get_size_2() const { return ___size_2; }
	inline int32_t* get_address_of_size_2() { return &___size_2; }
	inline void set_size_2(int32_t value)
	{
		___size_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
