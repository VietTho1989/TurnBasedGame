#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_UnityEngine_Networking_Types_SourceID1840552406.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.Match.Request
struct  Request_t1834273339  : public Il2CppObject
{
public:
	// UnityEngine.Networking.Types.SourceID UnityEngine.Networking.Match.Request::<sourceId>k__BackingField
	uint64_t ___U3CsourceIdU3Ek__BackingField_1;
	// System.String UnityEngine.Networking.Match.Request::<projectId>k__BackingField
	String_t* ___U3CprojectIdU3Ek__BackingField_2;
	// System.String UnityEngine.Networking.Match.Request::<accessTokenString>k__BackingField
	String_t* ___U3CaccessTokenStringU3Ek__BackingField_3;
	// System.Int32 UnityEngine.Networking.Match.Request::<domain>k__BackingField
	int32_t ___U3CdomainU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_U3CsourceIdU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Request_t1834273339, ___U3CsourceIdU3Ek__BackingField_1)); }
	inline uint64_t get_U3CsourceIdU3Ek__BackingField_1() const { return ___U3CsourceIdU3Ek__BackingField_1; }
	inline uint64_t* get_address_of_U3CsourceIdU3Ek__BackingField_1() { return &___U3CsourceIdU3Ek__BackingField_1; }
	inline void set_U3CsourceIdU3Ek__BackingField_1(uint64_t value)
	{
		___U3CsourceIdU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CprojectIdU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Request_t1834273339, ___U3CprojectIdU3Ek__BackingField_2)); }
	inline String_t* get_U3CprojectIdU3Ek__BackingField_2() const { return ___U3CprojectIdU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CprojectIdU3Ek__BackingField_2() { return &___U3CprojectIdU3Ek__BackingField_2; }
	inline void set_U3CprojectIdU3Ek__BackingField_2(String_t* value)
	{
		___U3CprojectIdU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CprojectIdU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CaccessTokenStringU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Request_t1834273339, ___U3CaccessTokenStringU3Ek__BackingField_3)); }
	inline String_t* get_U3CaccessTokenStringU3Ek__BackingField_3() const { return ___U3CaccessTokenStringU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CaccessTokenStringU3Ek__BackingField_3() { return &___U3CaccessTokenStringU3Ek__BackingField_3; }
	inline void set_U3CaccessTokenStringU3Ek__BackingField_3(String_t* value)
	{
		___U3CaccessTokenStringU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CaccessTokenStringU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CdomainU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Request_t1834273339, ___U3CdomainU3Ek__BackingField_4)); }
	inline int32_t get_U3CdomainU3Ek__BackingField_4() const { return ___U3CdomainU3Ek__BackingField_4; }
	inline int32_t* get_address_of_U3CdomainU3Ek__BackingField_4() { return &___U3CdomainU3Ek__BackingField_4; }
	inline void set_U3CdomainU3Ek__BackingField_4(int32_t value)
	{
		___U3CdomainU3Ek__BackingField_4 = value;
	}
};

struct Request_t1834273339_StaticFields
{
public:
	// System.Int32 UnityEngine.Networking.Match.Request::currentVersion
	int32_t ___currentVersion_0;

public:
	inline static int32_t get_offset_of_currentVersion_0() { return static_cast<int32_t>(offsetof(Request_t1834273339_StaticFields, ___currentVersion_0)); }
	inline int32_t get_currentVersion_0() const { return ___currentVersion_0; }
	inline int32_t* get_address_of_currentVersion_0() { return &___currentVersion_0; }
	inline void set_currentVersion_0(int32_t value)
	{
		___currentVersion_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
