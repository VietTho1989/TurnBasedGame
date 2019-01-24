#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"

// System.Reflection.Assembly
struct Assembly_t4268412390;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.AssemblyLoadEventArgs
struct  AssemblyLoadEventArgs_t4233815743  : public EventArgs_t3289624707
{
public:
	// System.Reflection.Assembly System.AssemblyLoadEventArgs::m_loadedAssembly
	Assembly_t4268412390 * ___m_loadedAssembly_1;

public:
	inline static int32_t get_offset_of_m_loadedAssembly_1() { return static_cast<int32_t>(offsetof(AssemblyLoadEventArgs_t4233815743, ___m_loadedAssembly_1)); }
	inline Assembly_t4268412390 * get_m_loadedAssembly_1() const { return ___m_loadedAssembly_1; }
	inline Assembly_t4268412390 ** get_address_of_m_loadedAssembly_1() { return &___m_loadedAssembly_1; }
	inline void set_m_loadedAssembly_1(Assembly_t4268412390 * value)
	{
		___m_loadedAssembly_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_loadedAssembly_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
