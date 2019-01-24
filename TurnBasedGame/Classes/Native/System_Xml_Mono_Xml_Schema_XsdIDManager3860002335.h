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
// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdIDManager
struct  XsdIDManager_t3860002335  : public Il2CppObject
{
public:
	// System.Collections.Hashtable Mono.Xml.Schema.XsdIDManager::idList
	Hashtable_t909839986 * ___idList_0;
	// System.Collections.ArrayList Mono.Xml.Schema.XsdIDManager::missingIDReferences
	ArrayList_t4252133567 * ___missingIDReferences_1;
	// System.String Mono.Xml.Schema.XsdIDManager::thisElementId
	String_t* ___thisElementId_2;

public:
	inline static int32_t get_offset_of_idList_0() { return static_cast<int32_t>(offsetof(XsdIDManager_t3860002335, ___idList_0)); }
	inline Hashtable_t909839986 * get_idList_0() const { return ___idList_0; }
	inline Hashtable_t909839986 ** get_address_of_idList_0() { return &___idList_0; }
	inline void set_idList_0(Hashtable_t909839986 * value)
	{
		___idList_0 = value;
		Il2CppCodeGenWriteBarrier(&___idList_0, value);
	}

	inline static int32_t get_offset_of_missingIDReferences_1() { return static_cast<int32_t>(offsetof(XsdIDManager_t3860002335, ___missingIDReferences_1)); }
	inline ArrayList_t4252133567 * get_missingIDReferences_1() const { return ___missingIDReferences_1; }
	inline ArrayList_t4252133567 ** get_address_of_missingIDReferences_1() { return &___missingIDReferences_1; }
	inline void set_missingIDReferences_1(ArrayList_t4252133567 * value)
	{
		___missingIDReferences_1 = value;
		Il2CppCodeGenWriteBarrier(&___missingIDReferences_1, value);
	}

	inline static int32_t get_offset_of_thisElementId_2() { return static_cast<int32_t>(offsetof(XsdIDManager_t3860002335, ___thisElementId_2)); }
	inline String_t* get_thisElementId_2() const { return ___thisElementId_2; }
	inline String_t** get_address_of_thisElementId_2() { return &___thisElementId_2; }
	inline void set_thisElementId_2(String_t* value)
	{
		___thisElementId_2 = value;
		Il2CppCodeGenWriteBarrier(&___thisElementId_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
