#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3984661726.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUpdate`1<System.Int64>
struct  RequestChangeUpdate_1_t3691912779  : public UpdateBehavior_1_t3984661726
{
public:
	// AdvancedCoroutines.Routine RequestChangeUpdate`1::waitToResend
	Routine_t2502590640 * ___waitToResend_4;

public:
	inline static int32_t get_offset_of_waitToResend_4() { return static_cast<int32_t>(offsetof(RequestChangeUpdate_1_t3691912779, ___waitToResend_4)); }
	inline Routine_t2502590640 * get_waitToResend_4() const { return ___waitToResend_4; }
	inline Routine_t2502590640 ** get_address_of_waitToResend_4() { return &___waitToResend_4; }
	inline void set_waitToResend_4(Routine_t2502590640 * value)
	{
		___waitToResend_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitToResend_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
