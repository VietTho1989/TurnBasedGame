#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<UnityEngine.WWW,System.Action`1<Foundation.Tasks.Response`1<System.String>>>
struct Dictionary_2_t3661422880;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.HttpService
struct  HttpService_t1528482479  : public Il2CppObject
{
public:
	// System.String Foundation.Server.HttpService::ContentType
	String_t* ___ContentType_0;
	// System.String Foundation.Server.HttpService::Accept
	String_t* ___Accept_1;
	// System.Int32 Foundation.Server.HttpService::Timeout
	int32_t ___Timeout_2;
	// System.Collections.Generic.Dictionary`2<UnityEngine.WWW,System.Action`1<Foundation.Tasks.Response`1<System.String>>> Foundation.Server.HttpService::_pendingCalls
	Dictionary_2_t3661422880 * ____pendingCalls_5;

public:
	inline static int32_t get_offset_of_ContentType_0() { return static_cast<int32_t>(offsetof(HttpService_t1528482479, ___ContentType_0)); }
	inline String_t* get_ContentType_0() const { return ___ContentType_0; }
	inline String_t** get_address_of_ContentType_0() { return &___ContentType_0; }
	inline void set_ContentType_0(String_t* value)
	{
		___ContentType_0 = value;
		Il2CppCodeGenWriteBarrier(&___ContentType_0, value);
	}

	inline static int32_t get_offset_of_Accept_1() { return static_cast<int32_t>(offsetof(HttpService_t1528482479, ___Accept_1)); }
	inline String_t* get_Accept_1() const { return ___Accept_1; }
	inline String_t** get_address_of_Accept_1() { return &___Accept_1; }
	inline void set_Accept_1(String_t* value)
	{
		___Accept_1 = value;
		Il2CppCodeGenWriteBarrier(&___Accept_1, value);
	}

	inline static int32_t get_offset_of_Timeout_2() { return static_cast<int32_t>(offsetof(HttpService_t1528482479, ___Timeout_2)); }
	inline int32_t get_Timeout_2() const { return ___Timeout_2; }
	inline int32_t* get_address_of_Timeout_2() { return &___Timeout_2; }
	inline void set_Timeout_2(int32_t value)
	{
		___Timeout_2 = value;
	}

	inline static int32_t get_offset_of__pendingCalls_5() { return static_cast<int32_t>(offsetof(HttpService_t1528482479, ____pendingCalls_5)); }
	inline Dictionary_2_t3661422880 * get__pendingCalls_5() const { return ____pendingCalls_5; }
	inline Dictionary_2_t3661422880 ** get_address_of__pendingCalls_5() { return &____pendingCalls_5; }
	inline void set__pendingCalls_5(Dictionary_2_t3661422880 * value)
	{
		____pendingCalls_5 = value;
		Il2CppCodeGenWriteBarrier(&____pendingCalls_5, value);
	}
};

struct HttpService_t1528482479_StaticFields
{
public:
	// System.String Foundation.Server.HttpService::<SessionToken>k__BackingField
	String_t* ___U3CSessionTokenU3Ek__BackingField_3;
	// System.String Foundation.Server.HttpService::<AuthorizationToken>k__BackingField
	String_t* ___U3CAuthorizationTokenU3Ek__BackingField_4;

public:
	inline static int32_t get_offset_of_U3CSessionTokenU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(HttpService_t1528482479_StaticFields, ___U3CSessionTokenU3Ek__BackingField_3)); }
	inline String_t* get_U3CSessionTokenU3Ek__BackingField_3() const { return ___U3CSessionTokenU3Ek__BackingField_3; }
	inline String_t** get_address_of_U3CSessionTokenU3Ek__BackingField_3() { return &___U3CSessionTokenU3Ek__BackingField_3; }
	inline void set_U3CSessionTokenU3Ek__BackingField_3(String_t* value)
	{
		___U3CSessionTokenU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CSessionTokenU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CAuthorizationTokenU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(HttpService_t1528482479_StaticFields, ___U3CAuthorizationTokenU3Ek__BackingField_4)); }
	inline String_t* get_U3CAuthorizationTokenU3Ek__BackingField_4() const { return ___U3CAuthorizationTokenU3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CAuthorizationTokenU3Ek__BackingField_4() { return &___U3CAuthorizationTokenU3Ek__BackingField_4; }
	inline void set_U3CAuthorizationTokenU3Ek__BackingField_4(String_t* value)
	{
		___U3CAuthorizationTokenU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAuthorizationTokenU3Ek__BackingField_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
