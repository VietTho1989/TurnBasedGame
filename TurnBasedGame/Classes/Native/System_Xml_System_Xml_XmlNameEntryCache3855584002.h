#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Xml.XmlNameTable
struct XmlNameTable_t1345805268;
// System.Xml.XmlNameEntry
struct XmlNameEntry_t3745551716;
// System.Char[]
struct CharU5BU5D_t1328083999;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Xml.XmlNameEntryCache
struct  XmlNameEntryCache_t3855584002  : public Il2CppObject
{
public:
	// System.Collections.Hashtable System.Xml.XmlNameEntryCache::table
	Hashtable_t909839986 * ___table_0;
	// System.Xml.XmlNameTable System.Xml.XmlNameEntryCache::nameTable
	XmlNameTable_t1345805268 * ___nameTable_1;
	// System.Xml.XmlNameEntry System.Xml.XmlNameEntryCache::dummy
	XmlNameEntry_t3745551716 * ___dummy_2;
	// System.Char[] System.Xml.XmlNameEntryCache::cacheBuffer
	CharU5BU5D_t1328083999* ___cacheBuffer_3;

public:
	inline static int32_t get_offset_of_table_0() { return static_cast<int32_t>(offsetof(XmlNameEntryCache_t3855584002, ___table_0)); }
	inline Hashtable_t909839986 * get_table_0() const { return ___table_0; }
	inline Hashtable_t909839986 ** get_address_of_table_0() { return &___table_0; }
	inline void set_table_0(Hashtable_t909839986 * value)
	{
		___table_0 = value;
		Il2CppCodeGenWriteBarrier(&___table_0, value);
	}

	inline static int32_t get_offset_of_nameTable_1() { return static_cast<int32_t>(offsetof(XmlNameEntryCache_t3855584002, ___nameTable_1)); }
	inline XmlNameTable_t1345805268 * get_nameTable_1() const { return ___nameTable_1; }
	inline XmlNameTable_t1345805268 ** get_address_of_nameTable_1() { return &___nameTable_1; }
	inline void set_nameTable_1(XmlNameTable_t1345805268 * value)
	{
		___nameTable_1 = value;
		Il2CppCodeGenWriteBarrier(&___nameTable_1, value);
	}

	inline static int32_t get_offset_of_dummy_2() { return static_cast<int32_t>(offsetof(XmlNameEntryCache_t3855584002, ___dummy_2)); }
	inline XmlNameEntry_t3745551716 * get_dummy_2() const { return ___dummy_2; }
	inline XmlNameEntry_t3745551716 ** get_address_of_dummy_2() { return &___dummy_2; }
	inline void set_dummy_2(XmlNameEntry_t3745551716 * value)
	{
		___dummy_2 = value;
		Il2CppCodeGenWriteBarrier(&___dummy_2, value);
	}

	inline static int32_t get_offset_of_cacheBuffer_3() { return static_cast<int32_t>(offsetof(XmlNameEntryCache_t3855584002, ___cacheBuffer_3)); }
	inline CharU5BU5D_t1328083999* get_cacheBuffer_3() const { return ___cacheBuffer_3; }
	inline CharU5BU5D_t1328083999** get_address_of_cacheBuffer_3() { return &___cacheBuffer_3; }
	inline void set_cacheBuffer_3(CharU5BU5D_t1328083999* value)
	{
		___cacheBuffer_3 = value;
		Il2CppCodeGenWriteBarrier(&___cacheBuffer_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
