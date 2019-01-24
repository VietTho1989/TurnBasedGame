#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RemoteConfig/State>
struct VP_1_t1026313564;
// VP`1<System.Int64>
struct VP_1_t1287355043;
// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// RemoteConfig
struct RemoteConfig_t2968288168;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RemoteConfig
struct  RemoteConfig_t2968288168  : public Data_t3569509720
{
public:
	// VP`1<RemoteConfig/State> RemoteConfig::state
	VP_1_t1026313564 * ___state_5;
	// VP`1<System.Int64> RemoteConfig::time
	VP_1_t1287355043 * ___time_6;
	// VP`1<System.String> RemoteConfig::serverAddress
	VP_1_t2407497239 * ___serverAddress_7;
	// VP`1<System.Int32> RemoteConfig::serverPort
	VP_1_t2450154454 * ___serverPort_8;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RemoteConfig_t2968288168, ___state_5)); }
	inline VP_1_t1026313564 * get_state_5() const { return ___state_5; }
	inline VP_1_t1026313564 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1026313564 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(RemoteConfig_t2968288168, ___time_6)); }
	inline VP_1_t1287355043 * get_time_6() const { return ___time_6; }
	inline VP_1_t1287355043 ** get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(VP_1_t1287355043 * value)
	{
		___time_6 = value;
		Il2CppCodeGenWriteBarrier(&___time_6, value);
	}

	inline static int32_t get_offset_of_serverAddress_7() { return static_cast<int32_t>(offsetof(RemoteConfig_t2968288168, ___serverAddress_7)); }
	inline VP_1_t2407497239 * get_serverAddress_7() const { return ___serverAddress_7; }
	inline VP_1_t2407497239 ** get_address_of_serverAddress_7() { return &___serverAddress_7; }
	inline void set_serverAddress_7(VP_1_t2407497239 * value)
	{
		___serverAddress_7 = value;
		Il2CppCodeGenWriteBarrier(&___serverAddress_7, value);
	}

	inline static int32_t get_offset_of_serverPort_8() { return static_cast<int32_t>(offsetof(RemoteConfig_t2968288168, ___serverPort_8)); }
	inline VP_1_t2450154454 * get_serverPort_8() const { return ___serverPort_8; }
	inline VP_1_t2450154454 ** get_address_of_serverPort_8() { return &___serverPort_8; }
	inline void set_serverPort_8(VP_1_t2450154454 * value)
	{
		___serverPort_8 = value;
		Il2CppCodeGenWriteBarrier(&___serverPort_8, value);
	}
};

struct RemoteConfig_t2968288168_StaticFields
{
public:
	// RemoteConfig RemoteConfig::instance
	RemoteConfig_t2968288168 * ___instance_9;

public:
	inline static int32_t get_offset_of_instance_9() { return static_cast<int32_t>(offsetof(RemoteConfig_t2968288168_StaticFields, ___instance_9)); }
	inline RemoteConfig_t2968288168 * get_instance_9() const { return ___instance_9; }
	inline RemoteConfig_t2968288168 ** get_address_of_instance_9() { return &___instance_9; }
	inline void set_instance_9(RemoteConfig_t2968288168 * value)
	{
		___instance_9 = value;
		Il2CppCodeGenWriteBarrier(&___instance_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
