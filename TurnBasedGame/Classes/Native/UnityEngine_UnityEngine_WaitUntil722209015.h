#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_CustomYieldInstruction1786092740.h"

// System.Func`1<System.Boolean>
struct Func_1_t1485000104;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.WaitUntil
struct  WaitUntil_t722209015  : public CustomYieldInstruction_t1786092740
{
public:
	// System.Func`1<System.Boolean> UnityEngine.WaitUntil::m_Predicate
	Func_1_t1485000104 * ___m_Predicate_0;

public:
	inline static int32_t get_offset_of_m_Predicate_0() { return static_cast<int32_t>(offsetof(WaitUntil_t722209015, ___m_Predicate_0)); }
	inline Func_1_t1485000104 * get_m_Predicate_0() const { return ___m_Predicate_0; }
	inline Func_1_t1485000104 ** get_address_of_m_Predicate_0() { return &___m_Predicate_0; }
	inline void set_m_Predicate_0(Func_1_t1485000104 * value)
	{
		___m_Predicate_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Predicate_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
