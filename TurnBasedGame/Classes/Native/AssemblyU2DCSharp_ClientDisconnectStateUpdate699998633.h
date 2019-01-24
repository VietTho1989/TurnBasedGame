#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3907768633.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientDisconnectStateUpdate
struct  ClientDisconnectStateUpdate_t699998633  : public UpdateBehavior_1_t3907768633
{
public:
	// AdvancedCoroutines.Routine ClientDisconnectStateUpdate::disconnectTime
	Routine_t2502590640 * ___disconnectTime_4;

public:
	inline static int32_t get_offset_of_disconnectTime_4() { return static_cast<int32_t>(offsetof(ClientDisconnectStateUpdate_t699998633, ___disconnectTime_4)); }
	inline Routine_t2502590640 * get_disconnectTime_4() const { return ___disconnectTime_4; }
	inline Routine_t2502590640 ** get_address_of_disconnectTime_4() { return &___disconnectTime_4; }
	inline void set_disconnectTime_4(Routine_t2502590640 * value)
	{
		___disconnectTime_4 = value;
		Il2CppCodeGenWriteBarrier(&___disconnectTime_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
