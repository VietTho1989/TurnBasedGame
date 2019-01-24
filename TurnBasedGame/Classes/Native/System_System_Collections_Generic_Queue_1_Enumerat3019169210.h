#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Collections.Generic.Queue`1<System.Object>
struct Queue_1_t2509106130;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Queue`1/Enumerator<System.Object>
struct  Enumerator_t3019169210 
{
public:
	// System.Collections.Generic.Queue`1<T> System.Collections.Generic.Queue`1/Enumerator::q
	Queue_1_t2509106130 * ___q_0;
	// System.Int32 System.Collections.Generic.Queue`1/Enumerator::idx
	int32_t ___idx_1;
	// System.Int32 System.Collections.Generic.Queue`1/Enumerator::ver
	int32_t ___ver_2;

public:
	inline static int32_t get_offset_of_q_0() { return static_cast<int32_t>(offsetof(Enumerator_t3019169210, ___q_0)); }
	inline Queue_1_t2509106130 * get_q_0() const { return ___q_0; }
	inline Queue_1_t2509106130 ** get_address_of_q_0() { return &___q_0; }
	inline void set_q_0(Queue_1_t2509106130 * value)
	{
		___q_0 = value;
		Il2CppCodeGenWriteBarrier(&___q_0, value);
	}

	inline static int32_t get_offset_of_idx_1() { return static_cast<int32_t>(offsetof(Enumerator_t3019169210, ___idx_1)); }
	inline int32_t get_idx_1() const { return ___idx_1; }
	inline int32_t* get_address_of_idx_1() { return &___idx_1; }
	inline void set_idx_1(int32_t value)
	{
		___idx_1 = value;
	}

	inline static int32_t get_offset_of_ver_2() { return static_cast<int32_t>(offsetof(Enumerator_t3019169210, ___ver_2)); }
	inline int32_t get_ver_2() const { return ___ver_2; }
	inline int32_t* get_address_of_ver_2() { return &___ver_2; }
	inline void set_ver_2(int32_t value)
	{
		___ver_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
