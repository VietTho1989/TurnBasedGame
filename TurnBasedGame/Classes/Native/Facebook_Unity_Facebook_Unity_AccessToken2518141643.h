#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"
#include "mscorlib_System_Nullable_1_gen3251239280.h"

// Facebook.Unity.AccessToken
struct AccessToken_t2518141643;
// System.String
struct String_t;
// System.Collections.Generic.IEnumerable`1<System.String>
struct IEnumerable_1_t2321347278;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.AccessToken
struct  AccessToken_t2518141643  : public Il2CppObject
{
public:
	// System.String Facebook.Unity.AccessToken::<TokenString>k__BackingField
	String_t* ___U3CTokenStringU3Ek__BackingField_1;
	// System.DateTime Facebook.Unity.AccessToken::<ExpirationTime>k__BackingField
	DateTime_t693205669  ___U3CExpirationTimeU3Ek__BackingField_2;
	// System.Collections.Generic.IEnumerable`1<System.String> Facebook.Unity.AccessToken::<Permissions>k__BackingField
	Il2CppObject* ___U3CPermissionsU3Ek__BackingField_3;
	// System.String Facebook.Unity.AccessToken::<UserId>k__BackingField
	String_t* ___U3CUserIdU3Ek__BackingField_4;
	// System.Nullable`1<System.DateTime> Facebook.Unity.AccessToken::<LastRefresh>k__BackingField
	Nullable_1_t3251239280  ___U3CLastRefreshU3Ek__BackingField_5;

public:
	inline static int32_t get_offset_of_U3CTokenStringU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643, ___U3CTokenStringU3Ek__BackingField_1)); }
	inline String_t* get_U3CTokenStringU3Ek__BackingField_1() const { return ___U3CTokenStringU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CTokenStringU3Ek__BackingField_1() { return &___U3CTokenStringU3Ek__BackingField_1; }
	inline void set_U3CTokenStringU3Ek__BackingField_1(String_t* value)
	{
		___U3CTokenStringU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CTokenStringU3Ek__BackingField_1, value);
	}

	inline static int32_t get_offset_of_U3CExpirationTimeU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643, ___U3CExpirationTimeU3Ek__BackingField_2)); }
	inline DateTime_t693205669  get_U3CExpirationTimeU3Ek__BackingField_2() const { return ___U3CExpirationTimeU3Ek__BackingField_2; }
	inline DateTime_t693205669 * get_address_of_U3CExpirationTimeU3Ek__BackingField_2() { return &___U3CExpirationTimeU3Ek__BackingField_2; }
	inline void set_U3CExpirationTimeU3Ek__BackingField_2(DateTime_t693205669  value)
	{
		___U3CExpirationTimeU3Ek__BackingField_2 = value;
	}

	inline static int32_t get_offset_of_U3CPermissionsU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643, ___U3CPermissionsU3Ek__BackingField_3)); }
	inline Il2CppObject* get_U3CPermissionsU3Ek__BackingField_3() const { return ___U3CPermissionsU3Ek__BackingField_3; }
	inline Il2CppObject** get_address_of_U3CPermissionsU3Ek__BackingField_3() { return &___U3CPermissionsU3Ek__BackingField_3; }
	inline void set_U3CPermissionsU3Ek__BackingField_3(Il2CppObject* value)
	{
		___U3CPermissionsU3Ek__BackingField_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CPermissionsU3Ek__BackingField_3, value);
	}

	inline static int32_t get_offset_of_U3CUserIdU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643, ___U3CUserIdU3Ek__BackingField_4)); }
	inline String_t* get_U3CUserIdU3Ek__BackingField_4() const { return ___U3CUserIdU3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CUserIdU3Ek__BackingField_4() { return &___U3CUserIdU3Ek__BackingField_4; }
	inline void set_U3CUserIdU3Ek__BackingField_4(String_t* value)
	{
		___U3CUserIdU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUserIdU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3CLastRefreshU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643, ___U3CLastRefreshU3Ek__BackingField_5)); }
	inline Nullable_1_t3251239280  get_U3CLastRefreshU3Ek__BackingField_5() const { return ___U3CLastRefreshU3Ek__BackingField_5; }
	inline Nullable_1_t3251239280 * get_address_of_U3CLastRefreshU3Ek__BackingField_5() { return &___U3CLastRefreshU3Ek__BackingField_5; }
	inline void set_U3CLastRefreshU3Ek__BackingField_5(Nullable_1_t3251239280  value)
	{
		___U3CLastRefreshU3Ek__BackingField_5 = value;
	}
};

struct AccessToken_t2518141643_StaticFields
{
public:
	// Facebook.Unity.AccessToken Facebook.Unity.AccessToken::<CurrentAccessToken>k__BackingField
	AccessToken_t2518141643 * ___U3CCurrentAccessTokenU3Ek__BackingField_0;

public:
	inline static int32_t get_offset_of_U3CCurrentAccessTokenU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(AccessToken_t2518141643_StaticFields, ___U3CCurrentAccessTokenU3Ek__BackingField_0)); }
	inline AccessToken_t2518141643 * get_U3CCurrentAccessTokenU3Ek__BackingField_0() const { return ___U3CCurrentAccessTokenU3Ek__BackingField_0; }
	inline AccessToken_t2518141643 ** get_address_of_U3CCurrentAccessTokenU3Ek__BackingField_0() { return &___U3CCurrentAccessTokenU3Ek__BackingField_0; }
	inline void set_U3CCurrentAccessTokenU3Ek__BackingField_0(AccessToken_t2518141643 * value)
	{
		___U3CCurrentAccessTokenU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CCurrentAccessTokenU3Ek__BackingField_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
