#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_CodeAccessPermission3468021764.h"
#include "mscorlib_System_Security_Permissions_UIPermissionW3535816307.h"
#include "mscorlib_System_Security_Permissions_UIPermissionC1473065281.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Permissions.UIPermission
struct  UIPermission_t2463628927  : public CodeAccessPermission_t3468021764
{
public:
	// System.Security.Permissions.UIPermissionWindow System.Security.Permissions.UIPermission::_window
	int32_t ____window_0;
	// System.Security.Permissions.UIPermissionClipboard System.Security.Permissions.UIPermission::_clipboard
	int32_t ____clipboard_1;

public:
	inline static int32_t get_offset_of__window_0() { return static_cast<int32_t>(offsetof(UIPermission_t2463628927, ____window_0)); }
	inline int32_t get__window_0() const { return ____window_0; }
	inline int32_t* get_address_of__window_0() { return &____window_0; }
	inline void set__window_0(int32_t value)
	{
		____window_0 = value;
	}

	inline static int32_t get_offset_of__clipboard_1() { return static_cast<int32_t>(offsetof(UIPermission_t2463628927, ____clipboard_1)); }
	inline int32_t get__clipboard_1() const { return ____clipboard_1; }
	inline int32_t* get_address_of__clipboard_1() { return &____clipboard_1; }
	inline void set__clipboard_1(int32_t value)
	{
		____clipboard_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
