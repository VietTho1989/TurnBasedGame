#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Foundation.Server.HttpService
struct HttpService_t1528482479;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.ServiceClientBase
struct  ServiceClientBase_t1118826591  : public Il2CppObject
{
public:
	// Foundation.Server.HttpService Foundation.Server.ServiceClientBase::_client
	HttpService_t1528482479 * ____client_0;
	// System.String Foundation.Server.ServiceClientBase::<ControllerName>k__BackingField
	String_t* ___U3CControllerNameU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of__client_0() { return static_cast<int32_t>(offsetof(ServiceClientBase_t1118826591, ____client_0)); }
	inline HttpService_t1528482479 * get__client_0() const { return ____client_0; }
	inline HttpService_t1528482479 ** get_address_of__client_0() { return &____client_0; }
	inline void set__client_0(HttpService_t1528482479 * value)
	{
		____client_0 = value;
		Il2CppCodeGenWriteBarrier(&____client_0, value);
	}

	inline static int32_t get_offset_of_U3CControllerNameU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(ServiceClientBase_t1118826591, ___U3CControllerNameU3Ek__BackingField_1)); }
	inline String_t* get_U3CControllerNameU3Ek__BackingField_1() const { return ___U3CControllerNameU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CControllerNameU3Ek__BackingField_1() { return &___U3CControllerNameU3Ek__BackingField_1; }
	inline void set_U3CControllerNameU3Ek__BackingField_1(String_t* value)
	{
		___U3CControllerNameU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CControllerNameU3Ek__BackingField_1, value);
	}
};

struct ServiceClientBase_t1118826591_StaticFields
{
public:
	// System.String Foundation.Server.ServiceClientBase::ClientId
	String_t* ___ClientId_2;

public:
	inline static int32_t get_offset_of_ClientId_2() { return static_cast<int32_t>(offsetof(ServiceClientBase_t1118826591_StaticFields, ___ClientId_2)); }
	inline String_t* get_ClientId_2() const { return ___ClientId_2; }
	inline String_t** get_address_of_ClientId_2() { return &___ClientId_2; }
	inline void set_ClientId_2(String_t* value)
	{
		___ClientId_2 = value;
		Il2CppCodeGenWriteBarrier(&___ClientId_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
