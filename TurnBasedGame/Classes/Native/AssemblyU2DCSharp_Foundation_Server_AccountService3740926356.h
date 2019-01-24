#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Facebook.Unity.AccessToken
struct AccessToken_t2518141643;
// Foundation.Server.AccountService
struct AccountService_t2263607108;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.AccountService/<FacebookConnect>c__AnonStorey6
struct  U3CFacebookConnectU3Ec__AnonStorey6_t3740926356  : public Il2CppObject
{
public:
	// Facebook.Unity.AccessToken Foundation.Server.AccountService/<FacebookConnect>c__AnonStorey6::token
	AccessToken_t2518141643 * ___token_0;
	// Foundation.Server.AccountService Foundation.Server.AccountService/<FacebookConnect>c__AnonStorey6::$this
	AccountService_t2263607108 * ___U24this_1;

public:
	inline static int32_t get_offset_of_token_0() { return static_cast<int32_t>(offsetof(U3CFacebookConnectU3Ec__AnonStorey6_t3740926356, ___token_0)); }
	inline AccessToken_t2518141643 * get_token_0() const { return ___token_0; }
	inline AccessToken_t2518141643 ** get_address_of_token_0() { return &___token_0; }
	inline void set_token_0(AccessToken_t2518141643 * value)
	{
		___token_0 = value;
		Il2CppCodeGenWriteBarrier(&___token_0, value);
	}

	inline static int32_t get_offset_of_U24this_1() { return static_cast<int32_t>(offsetof(U3CFacebookConnectU3Ec__AnonStorey6_t3740926356, ___U24this_1)); }
	inline AccountService_t2263607108 * get_U24this_1() const { return ___U24this_1; }
	inline AccountService_t2263607108 ** get_address_of_U24this_1() { return &___U24this_1; }
	inline void set_U24this_1(AccountService_t2263607108 * value)
	{
		___U24this_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
