#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_User_Role2071605436.h"

// System.String
struct String_t;
// NetData`1<User>
struct NetData_1_t966273984;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserIdentity
struct  UserIdentity_t3654216825  : public DataIdentity_t543951486
{
public:
	// User/Role UserIdentity::role
	int32_t ___role_17;
	// System.String UserIdentity::token
	String_t* ___token_18;
	// System.Int64 UserIdentity::registerTime
	int64_t ___registerTime_19;
	// NetData`1<User> UserIdentity::netData
	NetData_1_t966273984 * ___netData_20;

public:
	inline static int32_t get_offset_of_role_17() { return static_cast<int32_t>(offsetof(UserIdentity_t3654216825, ___role_17)); }
	inline int32_t get_role_17() const { return ___role_17; }
	inline int32_t* get_address_of_role_17() { return &___role_17; }
	inline void set_role_17(int32_t value)
	{
		___role_17 = value;
	}

	inline static int32_t get_offset_of_token_18() { return static_cast<int32_t>(offsetof(UserIdentity_t3654216825, ___token_18)); }
	inline String_t* get_token_18() const { return ___token_18; }
	inline String_t** get_address_of_token_18() { return &___token_18; }
	inline void set_token_18(String_t* value)
	{
		___token_18 = value;
		Il2CppCodeGenWriteBarrier(&___token_18, value);
	}

	inline static int32_t get_offset_of_registerTime_19() { return static_cast<int32_t>(offsetof(UserIdentity_t3654216825, ___registerTime_19)); }
	inline int64_t get_registerTime_19() const { return ___registerTime_19; }
	inline int64_t* get_address_of_registerTime_19() { return &___registerTime_19; }
	inline void set_registerTime_19(int64_t value)
	{
		___registerTime_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(UserIdentity_t3654216825, ___netData_20)); }
	inline NetData_1_t966273984 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t966273984 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t966273984 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
