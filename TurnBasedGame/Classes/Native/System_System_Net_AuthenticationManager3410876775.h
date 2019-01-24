#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Object
struct Il2CppObject;
// System.Net.ICredentialPolicy
struct ICredentialPolicy_t1503602930;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.AuthenticationManager
struct  AuthenticationManager_t3410876775  : public Il2CppObject
{
public:

public:
};

struct AuthenticationManager_t3410876775_StaticFields
{
public:
	// System.Collections.ArrayList System.Net.AuthenticationManager::modules
	ArrayList_t4252133567 * ___modules_0;
	// System.Object System.Net.AuthenticationManager::locker
	Il2CppObject * ___locker_1;
	// System.Net.ICredentialPolicy System.Net.AuthenticationManager::credential_policy
	Il2CppObject * ___credential_policy_2;

public:
	inline static int32_t get_offset_of_modules_0() { return static_cast<int32_t>(offsetof(AuthenticationManager_t3410876775_StaticFields, ___modules_0)); }
	inline ArrayList_t4252133567 * get_modules_0() const { return ___modules_0; }
	inline ArrayList_t4252133567 ** get_address_of_modules_0() { return &___modules_0; }
	inline void set_modules_0(ArrayList_t4252133567 * value)
	{
		___modules_0 = value;
		Il2CppCodeGenWriteBarrier(&___modules_0, value);
	}

	inline static int32_t get_offset_of_locker_1() { return static_cast<int32_t>(offsetof(AuthenticationManager_t3410876775_StaticFields, ___locker_1)); }
	inline Il2CppObject * get_locker_1() const { return ___locker_1; }
	inline Il2CppObject ** get_address_of_locker_1() { return &___locker_1; }
	inline void set_locker_1(Il2CppObject * value)
	{
		___locker_1 = value;
		Il2CppCodeGenWriteBarrier(&___locker_1, value);
	}

	inline static int32_t get_offset_of_credential_policy_2() { return static_cast<int32_t>(offsetof(AuthenticationManager_t3410876775_StaticFields, ___credential_policy_2)); }
	inline Il2CppObject * get_credential_policy_2() const { return ___credential_policy_2; }
	inline Il2CppObject ** get_address_of_credential_policy_2() { return &___credential_policy_2; }
	inline void set_credential_policy_2(Il2CppObject * value)
	{
		___credential_policy_2 = value;
		Il2CppCodeGenWriteBarrier(&___credential_policy_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
