#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "mscorlib_System_Security_Permissions_SecurityAction446643378.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.RefEmitPermissionSet
struct  RefEmitPermissionSet_t2708608433 
{
public:
	// System.Security.Permissions.SecurityAction System.Reflection.Emit.RefEmitPermissionSet::action
	int32_t ___action_0;
	// System.String System.Reflection.Emit.RefEmitPermissionSet::pset
	String_t* ___pset_1;

public:
	inline static int32_t get_offset_of_action_0() { return static_cast<int32_t>(offsetof(RefEmitPermissionSet_t2708608433, ___action_0)); }
	inline int32_t get_action_0() const { return ___action_0; }
	inline int32_t* get_address_of_action_0() { return &___action_0; }
	inline void set_action_0(int32_t value)
	{
		___action_0 = value;
	}

	inline static int32_t get_offset_of_pset_1() { return static_cast<int32_t>(offsetof(RefEmitPermissionSet_t2708608433, ___pset_1)); }
	inline String_t* get_pset_1() const { return ___pset_1; }
	inline String_t** get_address_of_pset_1() { return &___pset_1; }
	inline void set_pset_1(String_t* value)
	{
		___pset_1 = value;
		Il2CppCodeGenWriteBarrier(&___pset_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Reflection.Emit.RefEmitPermissionSet
struct RefEmitPermissionSet_t2708608433_marshaled_pinvoke
{
	int32_t ___action_0;
	char* ___pset_1;
};
// Native definition for COM marshalling of System.Reflection.Emit.RefEmitPermissionSet
struct RefEmitPermissionSet_t2708608433_marshaled_com
{
	int32_t ___action_0;
	Il2CppChar* ___pset_1;
};
