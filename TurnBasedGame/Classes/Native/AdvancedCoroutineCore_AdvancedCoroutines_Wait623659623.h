#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"
#include "AdvancedCoroutineCore_AdvancedCoroutines_Wait_Wait3940534787.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AdvancedCoroutines.Wait
struct  Wait_t623659623 
{
public:
	// System.Single AdvancedCoroutines.Wait::Seconds
	float ___Seconds_0;
	// AdvancedCoroutines.Wait/WaitTypeInternal AdvancedCoroutines.Wait::waitTypeInternal
	int32_t ___waitTypeInternal_1;

public:
	inline static int32_t get_offset_of_Seconds_0() { return static_cast<int32_t>(offsetof(Wait_t623659623, ___Seconds_0)); }
	inline float get_Seconds_0() const { return ___Seconds_0; }
	inline float* get_address_of_Seconds_0() { return &___Seconds_0; }
	inline void set_Seconds_0(float value)
	{
		___Seconds_0 = value;
	}

	inline static int32_t get_offset_of_waitTypeInternal_1() { return static_cast<int32_t>(offsetof(Wait_t623659623, ___waitTypeInternal_1)); }
	inline int32_t get_waitTypeInternal_1() const { return ___waitTypeInternal_1; }
	inline int32_t* get_address_of_waitTypeInternal_1() { return &___waitTypeInternal_1; }
	inline void set_waitTypeInternal_1(int32_t value)
	{
		___waitTypeInternal_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
