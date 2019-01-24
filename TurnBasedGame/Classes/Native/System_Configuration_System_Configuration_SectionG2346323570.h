#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_ConfigInf546730838.h"

// System.Configuration.ConfigInfoCollection
struct ConfigInfoCollection_t3264723080;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.SectionGroupInfo
struct  SectionGroupInfo_t2346323570  : public ConfigInfo_t546730838
{
public:
	// System.Configuration.ConfigInfoCollection System.Configuration.SectionGroupInfo::sections
	ConfigInfoCollection_t3264723080 * ___sections_6;
	// System.Configuration.ConfigInfoCollection System.Configuration.SectionGroupInfo::groups
	ConfigInfoCollection_t3264723080 * ___groups_7;

public:
	inline static int32_t get_offset_of_sections_6() { return static_cast<int32_t>(offsetof(SectionGroupInfo_t2346323570, ___sections_6)); }
	inline ConfigInfoCollection_t3264723080 * get_sections_6() const { return ___sections_6; }
	inline ConfigInfoCollection_t3264723080 ** get_address_of_sections_6() { return &___sections_6; }
	inline void set_sections_6(ConfigInfoCollection_t3264723080 * value)
	{
		___sections_6 = value;
		Il2CppCodeGenWriteBarrier(&___sections_6, value);
	}

	inline static int32_t get_offset_of_groups_7() { return static_cast<int32_t>(offsetof(SectionGroupInfo_t2346323570, ___groups_7)); }
	inline ConfigInfoCollection_t3264723080 * get_groups_7() const { return ___groups_7; }
	inline ConfigInfoCollection_t3264723080 ** get_address_of_groups_7() { return &___groups_7; }
	inline void set_groups_7(ConfigInfoCollection_t3264723080 * value)
	{
		___groups_7 = value;
		Il2CppCodeGenWriteBarrier(&___groups_7, value);
	}
};

struct SectionGroupInfo_t2346323570_StaticFields
{
public:
	// System.Configuration.ConfigInfoCollection System.Configuration.SectionGroupInfo::emptyList
	ConfigInfoCollection_t3264723080 * ___emptyList_8;

public:
	inline static int32_t get_offset_of_emptyList_8() { return static_cast<int32_t>(offsetof(SectionGroupInfo_t2346323570_StaticFields, ___emptyList_8)); }
	inline ConfigInfoCollection_t3264723080 * get_emptyList_8() const { return ___emptyList_8; }
	inline ConfigInfoCollection_t3264723080 ** get_address_of_emptyList_8() { return &___emptyList_8; }
	inline void set_emptyList_8(ConfigInfoCollection_t3264723080 * value)
	{
		___emptyList_8 = value;
		Il2CppCodeGenWriteBarrier(&___emptyList_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
