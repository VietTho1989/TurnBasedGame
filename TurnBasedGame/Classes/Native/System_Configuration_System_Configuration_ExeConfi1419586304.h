#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_Configur2625210096.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ExeConfigurationFileMap
struct  ExeConfigurationFileMap_t1419586304  : public ConfigurationFileMap_t2625210096
{
public:
	// System.String System.Configuration.ExeConfigurationFileMap::exeConfigFilename
	String_t* ___exeConfigFilename_1;
	// System.String System.Configuration.ExeConfigurationFileMap::localUserConfigFilename
	String_t* ___localUserConfigFilename_2;
	// System.String System.Configuration.ExeConfigurationFileMap::roamingUserConfigFilename
	String_t* ___roamingUserConfigFilename_3;

public:
	inline static int32_t get_offset_of_exeConfigFilename_1() { return static_cast<int32_t>(offsetof(ExeConfigurationFileMap_t1419586304, ___exeConfigFilename_1)); }
	inline String_t* get_exeConfigFilename_1() const { return ___exeConfigFilename_1; }
	inline String_t** get_address_of_exeConfigFilename_1() { return &___exeConfigFilename_1; }
	inline void set_exeConfigFilename_1(String_t* value)
	{
		___exeConfigFilename_1 = value;
		Il2CppCodeGenWriteBarrier(&___exeConfigFilename_1, value);
	}

	inline static int32_t get_offset_of_localUserConfigFilename_2() { return static_cast<int32_t>(offsetof(ExeConfigurationFileMap_t1419586304, ___localUserConfigFilename_2)); }
	inline String_t* get_localUserConfigFilename_2() const { return ___localUserConfigFilename_2; }
	inline String_t** get_address_of_localUserConfigFilename_2() { return &___localUserConfigFilename_2; }
	inline void set_localUserConfigFilename_2(String_t* value)
	{
		___localUserConfigFilename_2 = value;
		Il2CppCodeGenWriteBarrier(&___localUserConfigFilename_2, value);
	}

	inline static int32_t get_offset_of_roamingUserConfigFilename_3() { return static_cast<int32_t>(offsetof(ExeConfigurationFileMap_t1419586304, ___roamingUserConfigFilename_3)); }
	inline String_t* get_roamingUserConfigFilename_3() const { return ___roamingUserConfigFilename_3; }
	inline String_t** get_address_of_roamingUserConfigFilename_3() { return &___roamingUserConfigFilename_3; }
	inline void set_roamingUserConfigFilename_3(String_t* value)
	{
		___roamingUserConfigFilename_3 = value;
		Il2CppCodeGenWriteBarrier(&___roamingUserConfigFilename_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
