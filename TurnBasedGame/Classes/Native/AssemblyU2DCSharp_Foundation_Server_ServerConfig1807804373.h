#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// System.String
struct String_t;
// Foundation.Server.ServerConfig
struct ServerConfig_t1807804373;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.ServerConfig
struct  ServerConfig_t1807804373  : public ScriptableObject_t1975622470
{
public:
	// System.String Foundation.Server.ServerConfig::Path
	String_t* ___Path_2;
	// System.String Foundation.Server.ServerConfig::Key
	String_t* ___Key_3;

public:
	inline static int32_t get_offset_of_Path_2() { return static_cast<int32_t>(offsetof(ServerConfig_t1807804373, ___Path_2)); }
	inline String_t* get_Path_2() const { return ___Path_2; }
	inline String_t** get_address_of_Path_2() { return &___Path_2; }
	inline void set_Path_2(String_t* value)
	{
		___Path_2 = value;
		Il2CppCodeGenWriteBarrier(&___Path_2, value);
	}

	inline static int32_t get_offset_of_Key_3() { return static_cast<int32_t>(offsetof(ServerConfig_t1807804373, ___Key_3)); }
	inline String_t* get_Key_3() const { return ___Key_3; }
	inline String_t** get_address_of_Key_3() { return &___Key_3; }
	inline void set_Key_3(String_t* value)
	{
		___Key_3 = value;
		Il2CppCodeGenWriteBarrier(&___Key_3, value);
	}
};

struct ServerConfig_t1807804373_StaticFields
{
public:
	// Foundation.Server.ServerConfig Foundation.Server.ServerConfig::_instance
	ServerConfig_t1807804373 * ____instance_4;

public:
	inline static int32_t get_offset_of__instance_4() { return static_cast<int32_t>(offsetof(ServerConfig_t1807804373_StaticFields, ____instance_4)); }
	inline ServerConfig_t1807804373 * get__instance_4() const { return ____instance_4; }
	inline ServerConfig_t1807804373 ** get_address_of__instance_4() { return &____instance_4; }
	inline void set__instance_4(ServerConfig_t1807804373 * value)
	{
		____instance_4 = value;
		Il2CppCodeGenWriteBarrier(&____instance_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
