#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Reflection.Emit.DynamicMethod
struct DynamicMethod_t3307743052;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Reflection.Emit.DynamicMethodTokenGenerator
struct  DynamicMethodTokenGenerator_t435001088  : public Il2CppObject
{
public:
	// System.Reflection.Emit.DynamicMethod System.Reflection.Emit.DynamicMethodTokenGenerator::m
	DynamicMethod_t3307743052 * ___m_0;

public:
	inline static int32_t get_offset_of_m_0() { return static_cast<int32_t>(offsetof(DynamicMethodTokenGenerator_t435001088, ___m_0)); }
	inline DynamicMethod_t3307743052 * get_m_0() const { return ___m_0; }
	inline DynamicMethod_t3307743052 ** get_address_of_m_0() { return &___m_0; }
	inline void set_m_0(DynamicMethod_t3307743052 * value)
	{
		___m_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
