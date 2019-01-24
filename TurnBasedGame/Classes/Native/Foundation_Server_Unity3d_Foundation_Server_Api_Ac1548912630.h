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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Server.Api.AccountEmailUpdate
struct  AccountEmailUpdate_t1548912630  : public Il2CppObject
{
public:
	// System.String Foundation.Server.Api.AccountEmailUpdate::<NewEmail>k__BackingField
	String_t* ___U3CNewEmailU3Ek__BackingField_0;
	// System.String Foundation.Server.Api.AccountEmailUpdate::<NewPassword>k__BackingField
	String_t* ___U3CNewPasswordU3Ek__BackingField_1;

public:
	inline static int32_t get_offset_of_U3CNewEmailU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(AccountEmailUpdate_t1548912630, ___U3CNewEmailU3Ek__BackingField_0)); }
	inline String_t* get_U3CNewEmailU3Ek__BackingField_0() const { return ___U3CNewEmailU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CNewEmailU3Ek__BackingField_0() { return &___U3CNewEmailU3Ek__BackingField_0; }
	inline void set_U3CNewEmailU3Ek__BackingField_0(String_t* value)
	{
		___U3CNewEmailU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNewEmailU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CNewPasswordU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(AccountEmailUpdate_t1548912630, ___U3CNewPasswordU3Ek__BackingField_1)); }
	inline String_t* get_U3CNewPasswordU3Ek__BackingField_1() const { return ___U3CNewPasswordU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CNewPasswordU3Ek__BackingField_1() { return &___U3CNewPasswordU3Ek__BackingField_1; }
	inline void set_U3CNewPasswordU3Ek__BackingField_1(String_t* value)
	{
		___U3CNewPasswordU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNewPasswordU3Ek__BackingField_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
