#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "Facebook_Unity_Facebook_Unity_ResultBase864677574.h"

// System.String
struct String_t;
// Facebook.Unity.AccessToken
struct AccessToken_t2518141643;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.LoginResult
struct  LoginResult_t2244791044  : public ResultBase_t864677574
{
public:
	// Facebook.Unity.AccessToken Facebook.Unity.LoginResult::<AccessToken>k__BackingField
	AccessToken_t2518141643 * ___U3CAccessTokenU3Ek__BackingField_10;

public:
	inline static int32_t get_offset_of_U3CAccessTokenU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(LoginResult_t2244791044, ___U3CAccessTokenU3Ek__BackingField_10)); }
	inline AccessToken_t2518141643 * get_U3CAccessTokenU3Ek__BackingField_10() const { return ___U3CAccessTokenU3Ek__BackingField_10; }
	inline AccessToken_t2518141643 ** get_address_of_U3CAccessTokenU3Ek__BackingField_10() { return &___U3CAccessTokenU3Ek__BackingField_10; }
	inline void set_U3CAccessTokenU3Ek__BackingField_10(AccessToken_t2518141643 * value)
	{
		___U3CAccessTokenU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAccessTokenU3Ek__BackingField_10, value);
	}
};

struct LoginResult_t2244791044_StaticFields
{
public:
	// System.String Facebook.Unity.LoginResult::UserIdKey
	String_t* ___UserIdKey_6;
	// System.String Facebook.Unity.LoginResult::ExpirationTimestampKey
	String_t* ___ExpirationTimestampKey_7;
	// System.String Facebook.Unity.LoginResult::PermissionsKey
	String_t* ___PermissionsKey_8;
	// System.String Facebook.Unity.LoginResult::AccessTokenKey
	String_t* ___AccessTokenKey_9;

public:
	inline static int32_t get_offset_of_UserIdKey_6() { return static_cast<int32_t>(offsetof(LoginResult_t2244791044_StaticFields, ___UserIdKey_6)); }
	inline String_t* get_UserIdKey_6() const { return ___UserIdKey_6; }
	inline String_t** get_address_of_UserIdKey_6() { return &___UserIdKey_6; }
	inline void set_UserIdKey_6(String_t* value)
	{
		___UserIdKey_6 = value;
		Il2CppCodeGenWriteBarrier(&___UserIdKey_6, value);
	}

	inline static int32_t get_offset_of_ExpirationTimestampKey_7() { return static_cast<int32_t>(offsetof(LoginResult_t2244791044_StaticFields, ___ExpirationTimestampKey_7)); }
	inline String_t* get_ExpirationTimestampKey_7() const { return ___ExpirationTimestampKey_7; }
	inline String_t** get_address_of_ExpirationTimestampKey_7() { return &___ExpirationTimestampKey_7; }
	inline void set_ExpirationTimestampKey_7(String_t* value)
	{
		___ExpirationTimestampKey_7 = value;
		Il2CppCodeGenWriteBarrier(&___ExpirationTimestampKey_7, value);
	}

	inline static int32_t get_offset_of_PermissionsKey_8() { return static_cast<int32_t>(offsetof(LoginResult_t2244791044_StaticFields, ___PermissionsKey_8)); }
	inline String_t* get_PermissionsKey_8() const { return ___PermissionsKey_8; }
	inline String_t** get_address_of_PermissionsKey_8() { return &___PermissionsKey_8; }
	inline void set_PermissionsKey_8(String_t* value)
	{
		___PermissionsKey_8 = value;
		Il2CppCodeGenWriteBarrier(&___PermissionsKey_8, value);
	}

	inline static int32_t get_offset_of_AccessTokenKey_9() { return static_cast<int32_t>(offsetof(LoginResult_t2244791044_StaticFields, ___AccessTokenKey_9)); }
	inline String_t* get_AccessTokenKey_9() const { return ___AccessTokenKey_9; }
	inline String_t** get_address_of_AccessTokenKey_9() { return &___AccessTokenKey_9; }
	inline void set_AccessTokenKey_9(String_t* value)
	{
		___AccessTokenKey_9 = value;
		Il2CppCodeGenWriteBarrier(&___AccessTokenKey_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
