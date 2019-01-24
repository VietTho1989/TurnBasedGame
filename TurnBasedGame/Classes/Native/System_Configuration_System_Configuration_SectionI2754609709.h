#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Configuration_System_Configuration_Configur3250313246.h"
#include "System_Configuration_System_Configuration_Configur3860111898.h"

// System.Configuration.ConfigurationSection
struct ConfigurationSection_t2600766927;
// System.String
struct String_t;
// System.Configuration.ProtectedConfigurationProvider
struct ProtectedConfigurationProvider_t3971982415;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.SectionInformation
struct  SectionInformation_t2754609709  : public Il2CppObject
{
public:
	// System.Configuration.ConfigurationSection System.Configuration.SectionInformation::parent
	ConfigurationSection_t2600766927 * ___parent_0;
	// System.Configuration.ConfigurationAllowDefinition System.Configuration.SectionInformation::allow_definition
	int32_t ___allow_definition_1;
	// System.Configuration.ConfigurationAllowExeDefinition System.Configuration.SectionInformation::allow_exe_definition
	int32_t ___allow_exe_definition_2;
	// System.Boolean System.Configuration.SectionInformation::allow_location
	bool ___allow_location_3;
	// System.Boolean System.Configuration.SectionInformation::allow_override
	bool ___allow_override_4;
	// System.Boolean System.Configuration.SectionInformation::inherit_on_child_apps
	bool ___inherit_on_child_apps_5;
	// System.Boolean System.Configuration.SectionInformation::restart_on_external_changes
	bool ___restart_on_external_changes_6;
	// System.Boolean System.Configuration.SectionInformation::require_permission
	bool ___require_permission_7;
	// System.String System.Configuration.SectionInformation::config_source
	String_t* ___config_source_8;
	// System.String System.Configuration.SectionInformation::name
	String_t* ___name_9;
	// System.String System.Configuration.SectionInformation::raw_xml
	String_t* ___raw_xml_10;
	// System.Configuration.ProtectedConfigurationProvider System.Configuration.SectionInformation::protection_provider
	ProtectedConfigurationProvider_t3971982415 * ___protection_provider_11;
	// System.String System.Configuration.SectionInformation::<ConfigFilePath>k__BackingField
	String_t* ___U3CConfigFilePathU3Ek__BackingField_12;

public:
	inline static int32_t get_offset_of_parent_0() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___parent_0)); }
	inline ConfigurationSection_t2600766927 * get_parent_0() const { return ___parent_0; }
	inline ConfigurationSection_t2600766927 ** get_address_of_parent_0() { return &___parent_0; }
	inline void set_parent_0(ConfigurationSection_t2600766927 * value)
	{
		___parent_0 = value;
		Il2CppCodeGenWriteBarrier(&___parent_0, value);
	}

	inline static int32_t get_offset_of_allow_definition_1() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___allow_definition_1)); }
	inline int32_t get_allow_definition_1() const { return ___allow_definition_1; }
	inline int32_t* get_address_of_allow_definition_1() { return &___allow_definition_1; }
	inline void set_allow_definition_1(int32_t value)
	{
		___allow_definition_1 = value;
	}

	inline static int32_t get_offset_of_allow_exe_definition_2() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___allow_exe_definition_2)); }
	inline int32_t get_allow_exe_definition_2() const { return ___allow_exe_definition_2; }
	inline int32_t* get_address_of_allow_exe_definition_2() { return &___allow_exe_definition_2; }
	inline void set_allow_exe_definition_2(int32_t value)
	{
		___allow_exe_definition_2 = value;
	}

	inline static int32_t get_offset_of_allow_location_3() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___allow_location_3)); }
	inline bool get_allow_location_3() const { return ___allow_location_3; }
	inline bool* get_address_of_allow_location_3() { return &___allow_location_3; }
	inline void set_allow_location_3(bool value)
	{
		___allow_location_3 = value;
	}

	inline static int32_t get_offset_of_allow_override_4() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___allow_override_4)); }
	inline bool get_allow_override_4() const { return ___allow_override_4; }
	inline bool* get_address_of_allow_override_4() { return &___allow_override_4; }
	inline void set_allow_override_4(bool value)
	{
		___allow_override_4 = value;
	}

	inline static int32_t get_offset_of_inherit_on_child_apps_5() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___inherit_on_child_apps_5)); }
	inline bool get_inherit_on_child_apps_5() const { return ___inherit_on_child_apps_5; }
	inline bool* get_address_of_inherit_on_child_apps_5() { return &___inherit_on_child_apps_5; }
	inline void set_inherit_on_child_apps_5(bool value)
	{
		___inherit_on_child_apps_5 = value;
	}

	inline static int32_t get_offset_of_restart_on_external_changes_6() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___restart_on_external_changes_6)); }
	inline bool get_restart_on_external_changes_6() const { return ___restart_on_external_changes_6; }
	inline bool* get_address_of_restart_on_external_changes_6() { return &___restart_on_external_changes_6; }
	inline void set_restart_on_external_changes_6(bool value)
	{
		___restart_on_external_changes_6 = value;
	}

	inline static int32_t get_offset_of_require_permission_7() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___require_permission_7)); }
	inline bool get_require_permission_7() const { return ___require_permission_7; }
	inline bool* get_address_of_require_permission_7() { return &___require_permission_7; }
	inline void set_require_permission_7(bool value)
	{
		___require_permission_7 = value;
	}

	inline static int32_t get_offset_of_config_source_8() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___config_source_8)); }
	inline String_t* get_config_source_8() const { return ___config_source_8; }
	inline String_t** get_address_of_config_source_8() { return &___config_source_8; }
	inline void set_config_source_8(String_t* value)
	{
		___config_source_8 = value;
		Il2CppCodeGenWriteBarrier(&___config_source_8, value);
	}

	inline static int32_t get_offset_of_name_9() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___name_9)); }
	inline String_t* get_name_9() const { return ___name_9; }
	inline String_t** get_address_of_name_9() { return &___name_9; }
	inline void set_name_9(String_t* value)
	{
		___name_9 = value;
		Il2CppCodeGenWriteBarrier(&___name_9, value);
	}

	inline static int32_t get_offset_of_raw_xml_10() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___raw_xml_10)); }
	inline String_t* get_raw_xml_10() const { return ___raw_xml_10; }
	inline String_t** get_address_of_raw_xml_10() { return &___raw_xml_10; }
	inline void set_raw_xml_10(String_t* value)
	{
		___raw_xml_10 = value;
		Il2CppCodeGenWriteBarrier(&___raw_xml_10, value);
	}

	inline static int32_t get_offset_of_protection_provider_11() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___protection_provider_11)); }
	inline ProtectedConfigurationProvider_t3971982415 * get_protection_provider_11() const { return ___protection_provider_11; }
	inline ProtectedConfigurationProvider_t3971982415 ** get_address_of_protection_provider_11() { return &___protection_provider_11; }
	inline void set_protection_provider_11(ProtectedConfigurationProvider_t3971982415 * value)
	{
		___protection_provider_11 = value;
		Il2CppCodeGenWriteBarrier(&___protection_provider_11, value);
	}

	inline static int32_t get_offset_of_U3CConfigFilePathU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(SectionInformation_t2754609709, ___U3CConfigFilePathU3Ek__BackingField_12)); }
	inline String_t* get_U3CConfigFilePathU3Ek__BackingField_12() const { return ___U3CConfigFilePathU3Ek__BackingField_12; }
	inline String_t** get_address_of_U3CConfigFilePathU3Ek__BackingField_12() { return &___U3CConfigFilePathU3Ek__BackingField_12; }
	inline void set_U3CConfigFilePathU3Ek__BackingField_12(String_t* value)
	{
		___U3CConfigFilePathU3Ek__BackingField_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CConfigFilePathU3Ek__BackingField_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
