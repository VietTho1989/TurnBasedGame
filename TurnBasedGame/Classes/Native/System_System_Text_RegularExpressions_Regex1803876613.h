#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Text_RegularExpressions_RegexOptions2418259727.h"

// System.Text.RegularExpressions.FactoryCache
struct FactoryCache_t2051534610;
// System.Text.RegularExpressions.IMachineFactory
struct IMachineFactory_t633643314;
// System.Collections.IDictionary
struct IDictionary_t596158605;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.String
struct String_t;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Text.RegularExpressions.RegexRunnerFactory
struct RegexRunnerFactory_t3902733837;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.RegularExpressions.Regex
struct  Regex_t1803876613  : public Il2CppObject
{
public:
	// System.Text.RegularExpressions.IMachineFactory System.Text.RegularExpressions.Regex::machineFactory
	Il2CppObject * ___machineFactory_2;
	// System.Collections.IDictionary System.Text.RegularExpressions.Regex::mapping
	Il2CppObject * ___mapping_3;
	// System.Int32 System.Text.RegularExpressions.Regex::group_count
	int32_t ___group_count_4;
	// System.Int32 System.Text.RegularExpressions.Regex::gap
	int32_t ___gap_5;
	// System.Boolean System.Text.RegularExpressions.Regex::refsInitialized
	bool ___refsInitialized_6;
	// System.String[] System.Text.RegularExpressions.Regex::group_names
	StringU5BU5D_t1642385972* ___group_names_7;
	// System.Int32[] System.Text.RegularExpressions.Regex::group_numbers
	Int32U5BU5D_t3030399641* ___group_numbers_8;
	// System.String System.Text.RegularExpressions.Regex::pattern
	String_t* ___pattern_9;
	// System.Text.RegularExpressions.RegexOptions System.Text.RegularExpressions.Regex::roptions
	int32_t ___roptions_10;
	// System.Collections.Hashtable System.Text.RegularExpressions.Regex::capnames
	Hashtable_t909839986 * ___capnames_11;
	// System.Collections.Hashtable System.Text.RegularExpressions.Regex::caps
	Hashtable_t909839986 * ___caps_12;
	// System.Text.RegularExpressions.RegexRunnerFactory System.Text.RegularExpressions.Regex::factory
	RegexRunnerFactory_t3902733837 * ___factory_13;
	// System.Int32 System.Text.RegularExpressions.Regex::capsize
	int32_t ___capsize_14;
	// System.String[] System.Text.RegularExpressions.Regex::capslist
	StringU5BU5D_t1642385972* ___capslist_15;

public:
	inline static int32_t get_offset_of_machineFactory_2() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___machineFactory_2)); }
	inline Il2CppObject * get_machineFactory_2() const { return ___machineFactory_2; }
	inline Il2CppObject ** get_address_of_machineFactory_2() { return &___machineFactory_2; }
	inline void set_machineFactory_2(Il2CppObject * value)
	{
		___machineFactory_2 = value;
		Il2CppCodeGenWriteBarrier(&___machineFactory_2, value);
	}

	inline static int32_t get_offset_of_mapping_3() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___mapping_3)); }
	inline Il2CppObject * get_mapping_3() const { return ___mapping_3; }
	inline Il2CppObject ** get_address_of_mapping_3() { return &___mapping_3; }
	inline void set_mapping_3(Il2CppObject * value)
	{
		___mapping_3 = value;
		Il2CppCodeGenWriteBarrier(&___mapping_3, value);
	}

	inline static int32_t get_offset_of_group_count_4() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___group_count_4)); }
	inline int32_t get_group_count_4() const { return ___group_count_4; }
	inline int32_t* get_address_of_group_count_4() { return &___group_count_4; }
	inline void set_group_count_4(int32_t value)
	{
		___group_count_4 = value;
	}

	inline static int32_t get_offset_of_gap_5() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___gap_5)); }
	inline int32_t get_gap_5() const { return ___gap_5; }
	inline int32_t* get_address_of_gap_5() { return &___gap_5; }
	inline void set_gap_5(int32_t value)
	{
		___gap_5 = value;
	}

	inline static int32_t get_offset_of_refsInitialized_6() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___refsInitialized_6)); }
	inline bool get_refsInitialized_6() const { return ___refsInitialized_6; }
	inline bool* get_address_of_refsInitialized_6() { return &___refsInitialized_6; }
	inline void set_refsInitialized_6(bool value)
	{
		___refsInitialized_6 = value;
	}

	inline static int32_t get_offset_of_group_names_7() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___group_names_7)); }
	inline StringU5BU5D_t1642385972* get_group_names_7() const { return ___group_names_7; }
	inline StringU5BU5D_t1642385972** get_address_of_group_names_7() { return &___group_names_7; }
	inline void set_group_names_7(StringU5BU5D_t1642385972* value)
	{
		___group_names_7 = value;
		Il2CppCodeGenWriteBarrier(&___group_names_7, value);
	}

	inline static int32_t get_offset_of_group_numbers_8() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___group_numbers_8)); }
	inline Int32U5BU5D_t3030399641* get_group_numbers_8() const { return ___group_numbers_8; }
	inline Int32U5BU5D_t3030399641** get_address_of_group_numbers_8() { return &___group_numbers_8; }
	inline void set_group_numbers_8(Int32U5BU5D_t3030399641* value)
	{
		___group_numbers_8 = value;
		Il2CppCodeGenWriteBarrier(&___group_numbers_8, value);
	}

	inline static int32_t get_offset_of_pattern_9() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___pattern_9)); }
	inline String_t* get_pattern_9() const { return ___pattern_9; }
	inline String_t** get_address_of_pattern_9() { return &___pattern_9; }
	inline void set_pattern_9(String_t* value)
	{
		___pattern_9 = value;
		Il2CppCodeGenWriteBarrier(&___pattern_9, value);
	}

	inline static int32_t get_offset_of_roptions_10() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___roptions_10)); }
	inline int32_t get_roptions_10() const { return ___roptions_10; }
	inline int32_t* get_address_of_roptions_10() { return &___roptions_10; }
	inline void set_roptions_10(int32_t value)
	{
		___roptions_10 = value;
	}

	inline static int32_t get_offset_of_capnames_11() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___capnames_11)); }
	inline Hashtable_t909839986 * get_capnames_11() const { return ___capnames_11; }
	inline Hashtable_t909839986 ** get_address_of_capnames_11() { return &___capnames_11; }
	inline void set_capnames_11(Hashtable_t909839986 * value)
	{
		___capnames_11 = value;
		Il2CppCodeGenWriteBarrier(&___capnames_11, value);
	}

	inline static int32_t get_offset_of_caps_12() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___caps_12)); }
	inline Hashtable_t909839986 * get_caps_12() const { return ___caps_12; }
	inline Hashtable_t909839986 ** get_address_of_caps_12() { return &___caps_12; }
	inline void set_caps_12(Hashtable_t909839986 * value)
	{
		___caps_12 = value;
		Il2CppCodeGenWriteBarrier(&___caps_12, value);
	}

	inline static int32_t get_offset_of_factory_13() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___factory_13)); }
	inline RegexRunnerFactory_t3902733837 * get_factory_13() const { return ___factory_13; }
	inline RegexRunnerFactory_t3902733837 ** get_address_of_factory_13() { return &___factory_13; }
	inline void set_factory_13(RegexRunnerFactory_t3902733837 * value)
	{
		___factory_13 = value;
		Il2CppCodeGenWriteBarrier(&___factory_13, value);
	}

	inline static int32_t get_offset_of_capsize_14() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___capsize_14)); }
	inline int32_t get_capsize_14() const { return ___capsize_14; }
	inline int32_t* get_address_of_capsize_14() { return &___capsize_14; }
	inline void set_capsize_14(int32_t value)
	{
		___capsize_14 = value;
	}

	inline static int32_t get_offset_of_capslist_15() { return static_cast<int32_t>(offsetof(Regex_t1803876613, ___capslist_15)); }
	inline StringU5BU5D_t1642385972* get_capslist_15() const { return ___capslist_15; }
	inline StringU5BU5D_t1642385972** get_address_of_capslist_15() { return &___capslist_15; }
	inline void set_capslist_15(StringU5BU5D_t1642385972* value)
	{
		___capslist_15 = value;
		Il2CppCodeGenWriteBarrier(&___capslist_15, value);
	}
};

struct Regex_t1803876613_StaticFields
{
public:
	// System.Text.RegularExpressions.FactoryCache System.Text.RegularExpressions.Regex::cache
	FactoryCache_t2051534610 * ___cache_0;
	// System.Boolean System.Text.RegularExpressions.Regex::old_rx
	bool ___old_rx_1;

public:
	inline static int32_t get_offset_of_cache_0() { return static_cast<int32_t>(offsetof(Regex_t1803876613_StaticFields, ___cache_0)); }
	inline FactoryCache_t2051534610 * get_cache_0() const { return ___cache_0; }
	inline FactoryCache_t2051534610 ** get_address_of_cache_0() { return &___cache_0; }
	inline void set_cache_0(FactoryCache_t2051534610 * value)
	{
		___cache_0 = value;
		Il2CppCodeGenWriteBarrier(&___cache_0, value);
	}

	inline static int32_t get_offset_of_old_rx_1() { return static_cast<int32_t>(offsetof(Regex_t1803876613_StaticFields, ___old_rx_1)); }
	inline bool get_old_rx_1() const { return ___old_rx_1; }
	inline bool* get_address_of_old_rx_1() { return &___old_rx_1; }
	inline void set_old_rx_1(bool value)
	{
		___old_rx_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
