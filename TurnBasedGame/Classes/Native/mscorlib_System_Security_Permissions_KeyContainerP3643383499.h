#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_CodeAccessPermission3468021764.h"
#include "mscorlib_System_Security_Permissions_KeyContainerP3003512226.h"

// System.Security.Permissions.KeyContainerPermissionAccessEntryCollection
struct KeyContainerPermissionAccessEntryCollection_t592240881;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Permissions.KeyContainerPermission
struct  KeyContainerPermission_t3643383499  : public CodeAccessPermission_t3468021764
{
public:
	// System.Security.Permissions.KeyContainerPermissionAccessEntryCollection System.Security.Permissions.KeyContainerPermission::_accessEntries
	KeyContainerPermissionAccessEntryCollection_t592240881 * ____accessEntries_0;
	// System.Security.Permissions.KeyContainerPermissionFlags System.Security.Permissions.KeyContainerPermission::_flags
	int32_t ____flags_1;

public:
	inline static int32_t get_offset_of__accessEntries_0() { return static_cast<int32_t>(offsetof(KeyContainerPermission_t3643383499, ____accessEntries_0)); }
	inline KeyContainerPermissionAccessEntryCollection_t592240881 * get__accessEntries_0() const { return ____accessEntries_0; }
	inline KeyContainerPermissionAccessEntryCollection_t592240881 ** get_address_of__accessEntries_0() { return &____accessEntries_0; }
	inline void set__accessEntries_0(KeyContainerPermissionAccessEntryCollection_t592240881 * value)
	{
		____accessEntries_0 = value;
		Il2CppCodeGenWriteBarrier(&____accessEntries_0, value);
	}

	inline static int32_t get_offset_of__flags_1() { return static_cast<int32_t>(offsetof(KeyContainerPermission_t3643383499, ____flags_1)); }
	inline int32_t get__flags_1() const { return ____flags_1; }
	inline int32_t* get_address_of__flags_1() { return &____flags_1; }
	inline void set__flags_1(int32_t value)
	{
		____flags_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
