#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Server_ServiceClientB1118826591.h"

// Foundation.Server.AccountService
struct AccountService_t2263607108;
// System.String
struct String_t;
// Foundation.Server.Api.AccountDetails
struct AccountDetails_t2379170077;
// Facebook.Unity.AccessToken
struct AccessToken_t2518141643;
// System.Action`1<System.Boolean>
struct Action_1_t3627374100;
// Facebook.Unity.InitDelegate
struct InitDelegate_t3410465555;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.AccountService
struct  AccountService_t2263607108  : public ServiceClientBase_t1118826591
{
public:
	// Foundation.Server.Api.AccountDetails Foundation.Server.AccountService::<Account>k__BackingField
	AccountDetails_t2379170077 * ___U3CAccountU3Ek__BackingField_6;
	// Facebook.Unity.AccessToken Foundation.Server.AccountService::<FBToken>k__BackingField
	AccessToken_t2518141643 * ___U3CFBTokenU3Ek__BackingField_7;
	// System.Boolean Foundation.Server.AccountService::<FBHideState>k__BackingField
	bool ___U3CFBHideStateU3Ek__BackingField_8;
	// System.Action`1<System.Boolean> Foundation.Server.AccountService::OnFBHideState
	Action_1_t3627374100 * ___OnFBHideState_9;

public:
	inline static int32_t get_offset_of_U3CAccountU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(AccountService_t2263607108, ___U3CAccountU3Ek__BackingField_6)); }
	inline AccountDetails_t2379170077 * get_U3CAccountU3Ek__BackingField_6() const { return ___U3CAccountU3Ek__BackingField_6; }
	inline AccountDetails_t2379170077 ** get_address_of_U3CAccountU3Ek__BackingField_6() { return &___U3CAccountU3Ek__BackingField_6; }
	inline void set_U3CAccountU3Ek__BackingField_6(AccountDetails_t2379170077 * value)
	{
		___U3CAccountU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAccountU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CFBTokenU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(AccountService_t2263607108, ___U3CFBTokenU3Ek__BackingField_7)); }
	inline AccessToken_t2518141643 * get_U3CFBTokenU3Ek__BackingField_7() const { return ___U3CFBTokenU3Ek__BackingField_7; }
	inline AccessToken_t2518141643 ** get_address_of_U3CFBTokenU3Ek__BackingField_7() { return &___U3CFBTokenU3Ek__BackingField_7; }
	inline void set_U3CFBTokenU3Ek__BackingField_7(AccessToken_t2518141643 * value)
	{
		___U3CFBTokenU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CFBTokenU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CFBHideStateU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(AccountService_t2263607108, ___U3CFBHideStateU3Ek__BackingField_8)); }
	inline bool get_U3CFBHideStateU3Ek__BackingField_8() const { return ___U3CFBHideStateU3Ek__BackingField_8; }
	inline bool* get_address_of_U3CFBHideStateU3Ek__BackingField_8() { return &___U3CFBHideStateU3Ek__BackingField_8; }
	inline void set_U3CFBHideStateU3Ek__BackingField_8(bool value)
	{
		___U3CFBHideStateU3Ek__BackingField_8 = value;
	}

	inline static int32_t get_offset_of_OnFBHideState_9() { return static_cast<int32_t>(offsetof(AccountService_t2263607108, ___OnFBHideState_9)); }
	inline Action_1_t3627374100 * get_OnFBHideState_9() const { return ___OnFBHideState_9; }
	inline Action_1_t3627374100 ** get_address_of_OnFBHideState_9() { return &___OnFBHideState_9; }
	inline void set_OnFBHideState_9(Action_1_t3627374100 * value)
	{
		___OnFBHideState_9 = value;
		Il2CppCodeGenWriteBarrier(&___OnFBHideState_9, value);
	}
};

struct AccountService_t2263607108_StaticFields
{
public:
	// Foundation.Server.AccountService Foundation.Server.AccountService::Instance
	AccountService_t2263607108 * ___Instance_3;
	// System.Action`1<System.Boolean> Foundation.Server.AccountService::<>f__am$cache0
	Action_1_t3627374100 * ___U3CU3Ef__amU24cache0_10;
	// Facebook.Unity.InitDelegate Foundation.Server.AccountService::<>f__am$cache1
	InitDelegate_t3410465555 * ___U3CU3Ef__amU24cache1_11;

public:
	inline static int32_t get_offset_of_Instance_3() { return static_cast<int32_t>(offsetof(AccountService_t2263607108_StaticFields, ___Instance_3)); }
	inline AccountService_t2263607108 * get_Instance_3() const { return ___Instance_3; }
	inline AccountService_t2263607108 ** get_address_of_Instance_3() { return &___Instance_3; }
	inline void set_Instance_3(AccountService_t2263607108 * value)
	{
		___Instance_3 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_3, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_10() { return static_cast<int32_t>(offsetof(AccountService_t2263607108_StaticFields, ___U3CU3Ef__amU24cache0_10)); }
	inline Action_1_t3627374100 * get_U3CU3Ef__amU24cache0_10() const { return ___U3CU3Ef__amU24cache0_10; }
	inline Action_1_t3627374100 ** get_address_of_U3CU3Ef__amU24cache0_10() { return &___U3CU3Ef__amU24cache0_10; }
	inline void set_U3CU3Ef__amU24cache0_10(Action_1_t3627374100 * value)
	{
		___U3CU3Ef__amU24cache0_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_10, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_11() { return static_cast<int32_t>(offsetof(AccountService_t2263607108_StaticFields, ___U3CU3Ef__amU24cache1_11)); }
	inline InitDelegate_t3410465555 * get_U3CU3Ef__amU24cache1_11() const { return ___U3CU3Ef__amU24cache1_11; }
	inline InitDelegate_t3410465555 ** get_address_of_U3CU3Ef__amU24cache1_11() { return &___U3CU3Ef__amU24cache1_11; }
	inline void set_U3CU3Ef__amU24cache1_11(InitDelegate_t3410465555 * value)
	{
		___U3CU3Ef__amU24cache1_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
