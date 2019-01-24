#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Char[]
struct CharU5BU5D_t1328083999;
// System.String
struct String_t;
// System.Configuration.Configuration
struct Configuration_t3335372970;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationLocation
struct  ConfigurationLocation_t1895107553  : public Il2CppObject
{
public:
	// System.String System.Configuration.ConfigurationLocation::path
	String_t* ___path_1;
	// System.Configuration.Configuration System.Configuration.ConfigurationLocation::configuration
	Configuration_t3335372970 * ___configuration_2;
	// System.Configuration.Configuration System.Configuration.ConfigurationLocation::parent
	Configuration_t3335372970 * ___parent_3;
	// System.String System.Configuration.ConfigurationLocation::xmlContent
	String_t* ___xmlContent_4;
	// System.Boolean System.Configuration.ConfigurationLocation::parentResolved
	bool ___parentResolved_5;
	// System.Boolean System.Configuration.ConfigurationLocation::allowOverride
	bool ___allowOverride_6;

public:
	inline static int32_t get_offset_of_path_1() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___path_1)); }
	inline String_t* get_path_1() const { return ___path_1; }
	inline String_t** get_address_of_path_1() { return &___path_1; }
	inline void set_path_1(String_t* value)
	{
		___path_1 = value;
		Il2CppCodeGenWriteBarrier(&___path_1, value);
	}

	inline static int32_t get_offset_of_configuration_2() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___configuration_2)); }
	inline Configuration_t3335372970 * get_configuration_2() const { return ___configuration_2; }
	inline Configuration_t3335372970 ** get_address_of_configuration_2() { return &___configuration_2; }
	inline void set_configuration_2(Configuration_t3335372970 * value)
	{
		___configuration_2 = value;
		Il2CppCodeGenWriteBarrier(&___configuration_2, value);
	}

	inline static int32_t get_offset_of_parent_3() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___parent_3)); }
	inline Configuration_t3335372970 * get_parent_3() const { return ___parent_3; }
	inline Configuration_t3335372970 ** get_address_of_parent_3() { return &___parent_3; }
	inline void set_parent_3(Configuration_t3335372970 * value)
	{
		___parent_3 = value;
		Il2CppCodeGenWriteBarrier(&___parent_3, value);
	}

	inline static int32_t get_offset_of_xmlContent_4() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___xmlContent_4)); }
	inline String_t* get_xmlContent_4() const { return ___xmlContent_4; }
	inline String_t** get_address_of_xmlContent_4() { return &___xmlContent_4; }
	inline void set_xmlContent_4(String_t* value)
	{
		___xmlContent_4 = value;
		Il2CppCodeGenWriteBarrier(&___xmlContent_4, value);
	}

	inline static int32_t get_offset_of_parentResolved_5() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___parentResolved_5)); }
	inline bool get_parentResolved_5() const { return ___parentResolved_5; }
	inline bool* get_address_of_parentResolved_5() { return &___parentResolved_5; }
	inline void set_parentResolved_5(bool value)
	{
		___parentResolved_5 = value;
	}

	inline static int32_t get_offset_of_allowOverride_6() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553, ___allowOverride_6)); }
	inline bool get_allowOverride_6() const { return ___allowOverride_6; }
	inline bool* get_address_of_allowOverride_6() { return &___allowOverride_6; }
	inline void set_allowOverride_6(bool value)
	{
		___allowOverride_6 = value;
	}
};

struct ConfigurationLocation_t1895107553_StaticFields
{
public:
	// System.Char[] System.Configuration.ConfigurationLocation::pathTrimChars
	CharU5BU5D_t1328083999* ___pathTrimChars_0;

public:
	inline static int32_t get_offset_of_pathTrimChars_0() { return static_cast<int32_t>(offsetof(ConfigurationLocation_t1895107553_StaticFields, ___pathTrimChars_0)); }
	inline CharU5BU5D_t1328083999* get_pathTrimChars_0() const { return ___pathTrimChars_0; }
	inline CharU5BU5D_t1328083999** get_address_of_pathTrimChars_0() { return &___pathTrimChars_0; }
	inline void set_pathTrimChars_0(CharU5BU5D_t1328083999* value)
	{
		___pathTrimChars_0 = value;
		Il2CppCodeGenWriteBarrier(&___pathTrimChars_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
