#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Configuration.Configuration
struct Configuration_t3335372970;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.String
struct String_t;
// System.Configuration.ConfigurationSectionGroup
struct ConfigurationSectionGroup_t2230982736;
// System.Configuration.ConfigurationLocationCollection
struct ConfigurationLocationCollection_t1903842989;
// System.Configuration.SectionGroupInfo
struct SectionGroupInfo_t2346323570;
// System.Configuration.Internal.IConfigSystem
struct IConfigSystem_t2950865222;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.Configuration
struct  Configuration_t3335372970  : public Il2CppObject
{
public:
	// System.Configuration.Configuration System.Configuration.Configuration::parent
	Configuration_t3335372970 * ___parent_0;
	// System.Collections.Hashtable System.Configuration.Configuration::elementData
	Hashtable_t909839986 * ___elementData_1;
	// System.String System.Configuration.Configuration::streamName
	String_t* ___streamName_2;
	// System.Configuration.ConfigurationSectionGroup System.Configuration.Configuration::rootSectionGroup
	ConfigurationSectionGroup_t2230982736 * ___rootSectionGroup_3;
	// System.Configuration.ConfigurationLocationCollection System.Configuration.Configuration::locations
	ConfigurationLocationCollection_t1903842989 * ___locations_4;
	// System.Configuration.SectionGroupInfo System.Configuration.Configuration::rootGroup
	SectionGroupInfo_t2346323570 * ___rootGroup_5;
	// System.Configuration.Internal.IConfigSystem System.Configuration.Configuration::system
	Il2CppObject * ___system_6;
	// System.Boolean System.Configuration.Configuration::hasFile
	bool ___hasFile_7;
	// System.String System.Configuration.Configuration::rootNamespace
	String_t* ___rootNamespace_8;
	// System.String System.Configuration.Configuration::configPath
	String_t* ___configPath_9;
	// System.String System.Configuration.Configuration::locationConfigPath
	String_t* ___locationConfigPath_10;
	// System.String System.Configuration.Configuration::locationSubPath
	String_t* ___locationSubPath_11;

public:
	inline static int32_t get_offset_of_parent_0() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___parent_0)); }
	inline Configuration_t3335372970 * get_parent_0() const { return ___parent_0; }
	inline Configuration_t3335372970 ** get_address_of_parent_0() { return &___parent_0; }
	inline void set_parent_0(Configuration_t3335372970 * value)
	{
		___parent_0 = value;
		Il2CppCodeGenWriteBarrier(&___parent_0, value);
	}

	inline static int32_t get_offset_of_elementData_1() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___elementData_1)); }
	inline Hashtable_t909839986 * get_elementData_1() const { return ___elementData_1; }
	inline Hashtable_t909839986 ** get_address_of_elementData_1() { return &___elementData_1; }
	inline void set_elementData_1(Hashtable_t909839986 * value)
	{
		___elementData_1 = value;
		Il2CppCodeGenWriteBarrier(&___elementData_1, value);
	}

	inline static int32_t get_offset_of_streamName_2() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___streamName_2)); }
	inline String_t* get_streamName_2() const { return ___streamName_2; }
	inline String_t** get_address_of_streamName_2() { return &___streamName_2; }
	inline void set_streamName_2(String_t* value)
	{
		___streamName_2 = value;
		Il2CppCodeGenWriteBarrier(&___streamName_2, value);
	}

	inline static int32_t get_offset_of_rootSectionGroup_3() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___rootSectionGroup_3)); }
	inline ConfigurationSectionGroup_t2230982736 * get_rootSectionGroup_3() const { return ___rootSectionGroup_3; }
	inline ConfigurationSectionGroup_t2230982736 ** get_address_of_rootSectionGroup_3() { return &___rootSectionGroup_3; }
	inline void set_rootSectionGroup_3(ConfigurationSectionGroup_t2230982736 * value)
	{
		___rootSectionGroup_3 = value;
		Il2CppCodeGenWriteBarrier(&___rootSectionGroup_3, value);
	}

	inline static int32_t get_offset_of_locations_4() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___locations_4)); }
	inline ConfigurationLocationCollection_t1903842989 * get_locations_4() const { return ___locations_4; }
	inline ConfigurationLocationCollection_t1903842989 ** get_address_of_locations_4() { return &___locations_4; }
	inline void set_locations_4(ConfigurationLocationCollection_t1903842989 * value)
	{
		___locations_4 = value;
		Il2CppCodeGenWriteBarrier(&___locations_4, value);
	}

	inline static int32_t get_offset_of_rootGroup_5() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___rootGroup_5)); }
	inline SectionGroupInfo_t2346323570 * get_rootGroup_5() const { return ___rootGroup_5; }
	inline SectionGroupInfo_t2346323570 ** get_address_of_rootGroup_5() { return &___rootGroup_5; }
	inline void set_rootGroup_5(SectionGroupInfo_t2346323570 * value)
	{
		___rootGroup_5 = value;
		Il2CppCodeGenWriteBarrier(&___rootGroup_5, value);
	}

	inline static int32_t get_offset_of_system_6() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___system_6)); }
	inline Il2CppObject * get_system_6() const { return ___system_6; }
	inline Il2CppObject ** get_address_of_system_6() { return &___system_6; }
	inline void set_system_6(Il2CppObject * value)
	{
		___system_6 = value;
		Il2CppCodeGenWriteBarrier(&___system_6, value);
	}

	inline static int32_t get_offset_of_hasFile_7() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___hasFile_7)); }
	inline bool get_hasFile_7() const { return ___hasFile_7; }
	inline bool* get_address_of_hasFile_7() { return &___hasFile_7; }
	inline void set_hasFile_7(bool value)
	{
		___hasFile_7 = value;
	}

	inline static int32_t get_offset_of_rootNamespace_8() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___rootNamespace_8)); }
	inline String_t* get_rootNamespace_8() const { return ___rootNamespace_8; }
	inline String_t** get_address_of_rootNamespace_8() { return &___rootNamespace_8; }
	inline void set_rootNamespace_8(String_t* value)
	{
		___rootNamespace_8 = value;
		Il2CppCodeGenWriteBarrier(&___rootNamespace_8, value);
	}

	inline static int32_t get_offset_of_configPath_9() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___configPath_9)); }
	inline String_t* get_configPath_9() const { return ___configPath_9; }
	inline String_t** get_address_of_configPath_9() { return &___configPath_9; }
	inline void set_configPath_9(String_t* value)
	{
		___configPath_9 = value;
		Il2CppCodeGenWriteBarrier(&___configPath_9, value);
	}

	inline static int32_t get_offset_of_locationConfigPath_10() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___locationConfigPath_10)); }
	inline String_t* get_locationConfigPath_10() const { return ___locationConfigPath_10; }
	inline String_t** get_address_of_locationConfigPath_10() { return &___locationConfigPath_10; }
	inline void set_locationConfigPath_10(String_t* value)
	{
		___locationConfigPath_10 = value;
		Il2CppCodeGenWriteBarrier(&___locationConfigPath_10, value);
	}

	inline static int32_t get_offset_of_locationSubPath_11() { return static_cast<int32_t>(offsetof(Configuration_t3335372970, ___locationSubPath_11)); }
	inline String_t* get_locationSubPath_11() const { return ___locationSubPath_11; }
	inline String_t** get_address_of_locationSubPath_11() { return &___locationSubPath_11; }
	inline void set_locationSubPath_11(String_t* value)
	{
		___locationSubPath_11 = value;
		Il2CppCodeGenWriteBarrier(&___locationSubPath_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
