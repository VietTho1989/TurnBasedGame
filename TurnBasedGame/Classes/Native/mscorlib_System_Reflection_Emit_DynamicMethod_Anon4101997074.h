#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Reflection.Module
struct Module_t4282841206;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.DynamicMethod/AnonHostModuleHolder
struct  AnonHostModuleHolder_t4101997074  : public Il2CppObject
{
public:

public:
};

struct AnonHostModuleHolder_t4101997074_StaticFields
{
public:
	// System.Reflection.Module System.Reflection.Emit.DynamicMethod/AnonHostModuleHolder::anon_host_module
	Module_t4282841206 * ___anon_host_module_0;

public:
	inline static int32_t get_offset_of_anon_host_module_0() { return static_cast<int32_t>(offsetof(AnonHostModuleHolder_t4101997074_StaticFields, ___anon_host_module_0)); }
	inline Module_t4282841206 * get_anon_host_module_0() const { return ___anon_host_module_0; }
	inline Module_t4282841206 ** get_address_of_anon_host_module_0() { return &___anon_host_module_0; }
	inline void set_anon_host_module_0(Module_t4282841206 * value)
	{
		___anon_host_module_0 = value;
		Il2CppCodeGenWriteBarrier(&___anon_host_module_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
