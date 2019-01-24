#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Configuration_System_Configuration_Configura131834733.h"

// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Configuration.ConfigurationElement
struct ConfigurationElement_t1776195828;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationLockCollection
struct  ConfigurationLockCollection_t1011762925  : public Il2CppObject
{
public:
	// System.Collections.ArrayList System.Configuration.ConfigurationLockCollection::names
	ArrayList_t4252133567 * ___names_0;
	// System.Configuration.ConfigurationElement System.Configuration.ConfigurationLockCollection::element
	ConfigurationElement_t1776195828 * ___element_1;
	// System.Configuration.ConfigurationLockType System.Configuration.ConfigurationLockCollection::lockType
	int32_t ___lockType_2;
	// System.Boolean System.Configuration.ConfigurationLockCollection::is_modified
	bool ___is_modified_3;
	// System.Collections.Hashtable System.Configuration.ConfigurationLockCollection::valid_name_hash
	Hashtable_t909839986 * ___valid_name_hash_4;
	// System.String System.Configuration.ConfigurationLockCollection::valid_names
	String_t* ___valid_names_5;

public:
	inline static int32_t get_offset_of_names_0() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___names_0)); }
	inline ArrayList_t4252133567 * get_names_0() const { return ___names_0; }
	inline ArrayList_t4252133567 ** get_address_of_names_0() { return &___names_0; }
	inline void set_names_0(ArrayList_t4252133567 * value)
	{
		___names_0 = value;
		Il2CppCodeGenWriteBarrier(&___names_0, value);
	}

	inline static int32_t get_offset_of_element_1() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___element_1)); }
	inline ConfigurationElement_t1776195828 * get_element_1() const { return ___element_1; }
	inline ConfigurationElement_t1776195828 ** get_address_of_element_1() { return &___element_1; }
	inline void set_element_1(ConfigurationElement_t1776195828 * value)
	{
		___element_1 = value;
		Il2CppCodeGenWriteBarrier(&___element_1, value);
	}

	inline static int32_t get_offset_of_lockType_2() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___lockType_2)); }
	inline int32_t get_lockType_2() const { return ___lockType_2; }
	inline int32_t* get_address_of_lockType_2() { return &___lockType_2; }
	inline void set_lockType_2(int32_t value)
	{
		___lockType_2 = value;
	}

	inline static int32_t get_offset_of_is_modified_3() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___is_modified_3)); }
	inline bool get_is_modified_3() const { return ___is_modified_3; }
	inline bool* get_address_of_is_modified_3() { return &___is_modified_3; }
	inline void set_is_modified_3(bool value)
	{
		___is_modified_3 = value;
	}

	inline static int32_t get_offset_of_valid_name_hash_4() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___valid_name_hash_4)); }
	inline Hashtable_t909839986 * get_valid_name_hash_4() const { return ___valid_name_hash_4; }
	inline Hashtable_t909839986 ** get_address_of_valid_name_hash_4() { return &___valid_name_hash_4; }
	inline void set_valid_name_hash_4(Hashtable_t909839986 * value)
	{
		___valid_name_hash_4 = value;
		Il2CppCodeGenWriteBarrier(&___valid_name_hash_4, value);
	}

	inline static int32_t get_offset_of_valid_names_5() { return static_cast<int32_t>(offsetof(ConfigurationLockCollection_t1011762925, ___valid_names_5)); }
	inline String_t* get_valid_names_5() const { return ___valid_names_5; }
	inline String_t** get_address_of_valid_names_5() { return &___valid_names_5; }
	inline void set_valid_names_5(String_t* value)
	{
		___valid_names_5 = value;
		Il2CppCodeGenWriteBarrier(&___valid_names_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
