#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_CodeAccessPermission3468021764.h"
#include "mscorlib_System_Security_Permissions_FileDialogPer4165817673.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Permissions.FileDialogPermission
struct  FileDialogPermission_t3088110531  : public CodeAccessPermission_t3468021764
{
public:
	// System.Security.Permissions.FileDialogPermissionAccess System.Security.Permissions.FileDialogPermission::_access
	int32_t ____access_0;

public:
	inline static int32_t get_offset_of__access_0() { return static_cast<int32_t>(offsetof(FileDialogPermission_t3088110531, ____access_0)); }
	inline int32_t get__access_0() const { return ____access_0; }
	inline int32_t* get_address_of__access_0() { return &____access_0; }
	inline void set__access_0(int32_t value)
	{
		____access_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
