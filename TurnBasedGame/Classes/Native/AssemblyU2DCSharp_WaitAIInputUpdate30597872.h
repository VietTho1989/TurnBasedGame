#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen986848392.h"

// WaitInputAction
struct WaitInputAction_t1882979057;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// WaitAIInputUpdate
struct  WaitAIInputUpdate_t30597872  : public UpdateBehavior_1_t986848392
{
public:
	// WaitInputAction WaitAIInputUpdate::waitInputAction
	WaitInputAction_t1882979057 * ___waitInputAction_4;

public:
	inline static int32_t get_offset_of_waitInputAction_4() { return static_cast<int32_t>(offsetof(WaitAIInputUpdate_t30597872, ___waitInputAction_4)); }
	inline WaitInputAction_t1882979057 * get_waitInputAction_4() const { return ___waitInputAction_4; }
	inline WaitInputAction_t1882979057 ** get_address_of_waitInputAction_4() { return &___waitInputAction_4; }
	inline void set_waitInputAction_4(WaitInputAction_t1882979057 * value)
	{
		___waitInputAction_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitInputAction_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
