#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Security_Policy_PolicyStatementAtt2506836895.h"

// System.Security.PermissionSet
struct PermissionSet_t1941658161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.PolicyStatement
struct  PolicyStatement_t1594053347  : public Il2CppObject
{
public:
	// System.Security.PermissionSet System.Security.Policy.PolicyStatement::perms
	PermissionSet_t1941658161 * ___perms_0;
	// System.Security.Policy.PolicyStatementAttribute System.Security.Policy.PolicyStatement::attrs
	int32_t ___attrs_1;

public:
	inline static int32_t get_offset_of_perms_0() { return static_cast<int32_t>(offsetof(PolicyStatement_t1594053347, ___perms_0)); }
	inline PermissionSet_t1941658161 * get_perms_0() const { return ___perms_0; }
	inline PermissionSet_t1941658161 ** get_address_of_perms_0() { return &___perms_0; }
	inline void set_perms_0(PermissionSet_t1941658161 * value)
	{
		___perms_0 = value;
		Il2CppCodeGenWriteBarrier(&___perms_0, value);
	}

	inline static int32_t get_offset_of_attrs_1() { return static_cast<int32_t>(offsetof(PolicyStatement_t1594053347, ___attrs_1)); }
	inline int32_t get_attrs_1() const { return ___attrs_1; }
	inline int32_t* get_address_of_attrs_1() { return &___attrs_1; }
	inline void set_attrs_1(int32_t value)
	{
		___attrs_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
