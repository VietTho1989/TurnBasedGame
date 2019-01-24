#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_ConfigInf546730838.h"
#include "System_Configuration_System_Configuration_Configur3250313246.h"
#include "System_Configuration_System_Configuration_Configur3860111898.h"

// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.SectionInfo
struct  SectionInfo_t1739019515  : public ConfigInfo_t546730838
{
public:
	// System.Boolean System.Configuration.SectionInfo::allowLocation
	bool ___allowLocation_6;
	// System.Boolean System.Configuration.SectionInfo::requirePermission
	bool ___requirePermission_7;
	// System.Boolean System.Configuration.SectionInfo::restartOnExternalChanges
	bool ___restartOnExternalChanges_8;
	// System.Configuration.ConfigurationAllowDefinition System.Configuration.SectionInfo::allowDefinition
	int32_t ___allowDefinition_9;
	// System.Configuration.ConfigurationAllowExeDefinition System.Configuration.SectionInfo::allowExeDefinition
	int32_t ___allowExeDefinition_10;

public:
	inline static int32_t get_offset_of_allowLocation_6() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515, ___allowLocation_6)); }
	inline bool get_allowLocation_6() const { return ___allowLocation_6; }
	inline bool* get_address_of_allowLocation_6() { return &___allowLocation_6; }
	inline void set_allowLocation_6(bool value)
	{
		___allowLocation_6 = value;
	}

	inline static int32_t get_offset_of_requirePermission_7() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515, ___requirePermission_7)); }
	inline bool get_requirePermission_7() const { return ___requirePermission_7; }
	inline bool* get_address_of_requirePermission_7() { return &___requirePermission_7; }
	inline void set_requirePermission_7(bool value)
	{
		___requirePermission_7 = value;
	}

	inline static int32_t get_offset_of_restartOnExternalChanges_8() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515, ___restartOnExternalChanges_8)); }
	inline bool get_restartOnExternalChanges_8() const { return ___restartOnExternalChanges_8; }
	inline bool* get_address_of_restartOnExternalChanges_8() { return &___restartOnExternalChanges_8; }
	inline void set_restartOnExternalChanges_8(bool value)
	{
		___restartOnExternalChanges_8 = value;
	}

	inline static int32_t get_offset_of_allowDefinition_9() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515, ___allowDefinition_9)); }
	inline int32_t get_allowDefinition_9() const { return ___allowDefinition_9; }
	inline int32_t* get_address_of_allowDefinition_9() { return &___allowDefinition_9; }
	inline void set_allowDefinition_9(int32_t value)
	{
		___allowDefinition_9 = value;
	}

	inline static int32_t get_offset_of_allowExeDefinition_10() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515, ___allowExeDefinition_10)); }
	inline int32_t get_allowExeDefinition_10() const { return ___allowExeDefinition_10; }
	inline int32_t* get_address_of_allowExeDefinition_10() { return &___allowExeDefinition_10; }
	inline void set_allowExeDefinition_10(int32_t value)
	{
		___allowExeDefinition_10 = value;
	}
};

struct SectionInfo_t1739019515_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Configuration.SectionInfo::<>f__switch$map1
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map1_11;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map1_11() { return static_cast<int32_t>(offsetof(SectionInfo_t1739019515_StaticFields, ___U3CU3Ef__switchU24map1_11)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map1_11() const { return ___U3CU3Ef__switchU24map1_11; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map1_11() { return &___U3CU3Ef__switchU24map1_11; }
	inline void set_U3CU3Ef__switchU24map1_11(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map1_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map1_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
