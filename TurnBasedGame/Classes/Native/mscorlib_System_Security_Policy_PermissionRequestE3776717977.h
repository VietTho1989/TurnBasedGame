#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Security.PermissionSet
struct PermissionSet_t1941658161;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Policy.PermissionRequestEvidence
struct  PermissionRequestEvidence_t3776717977  : public Il2CppObject
{
public:
	// System.Security.PermissionSet System.Security.Policy.PermissionRequestEvidence::requested
	PermissionSet_t1941658161 * ___requested_0;
	// System.Security.PermissionSet System.Security.Policy.PermissionRequestEvidence::optional
	PermissionSet_t1941658161 * ___optional_1;
	// System.Security.PermissionSet System.Security.Policy.PermissionRequestEvidence::denied
	PermissionSet_t1941658161 * ___denied_2;

public:
	inline static int32_t get_offset_of_requested_0() { return static_cast<int32_t>(offsetof(PermissionRequestEvidence_t3776717977, ___requested_0)); }
	inline PermissionSet_t1941658161 * get_requested_0() const { return ___requested_0; }
	inline PermissionSet_t1941658161 ** get_address_of_requested_0() { return &___requested_0; }
	inline void set_requested_0(PermissionSet_t1941658161 * value)
	{
		___requested_0 = value;
		Il2CppCodeGenWriteBarrier(&___requested_0, value);
	}

	inline static int32_t get_offset_of_optional_1() { return static_cast<int32_t>(offsetof(PermissionRequestEvidence_t3776717977, ___optional_1)); }
	inline PermissionSet_t1941658161 * get_optional_1() const { return ___optional_1; }
	inline PermissionSet_t1941658161 ** get_address_of_optional_1() { return &___optional_1; }
	inline void set_optional_1(PermissionSet_t1941658161 * value)
	{
		___optional_1 = value;
		Il2CppCodeGenWriteBarrier(&___optional_1, value);
	}

	inline static int32_t get_offset_of_denied_2() { return static_cast<int32_t>(offsetof(PermissionRequestEvidence_t3776717977, ___denied_2)); }
	inline PermissionSet_t1941658161 * get_denied_2() const { return ___denied_2; }
	inline PermissionSet_t1941658161 ** get_address_of_denied_2() { return &___denied_2; }
	inline void set_denied_2(PermissionSet_t1941658161 * value)
	{
		___denied_2 = value;
		Il2CppCodeGenWriteBarrier(&___denied_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
