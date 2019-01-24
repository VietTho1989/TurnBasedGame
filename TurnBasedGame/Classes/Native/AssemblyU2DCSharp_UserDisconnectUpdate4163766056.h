#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen1235551152.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UserDisconnectUpdate
struct  UserDisconnectUpdate_t4163766056  : public UpdateBehavior_1_t1235551152
{
public:
	// AdvancedCoroutines.Routine UserDisconnectUpdate::wait
	Routine_t2502590640 * ___wait_4;

public:
	inline static int32_t get_offset_of_wait_4() { return static_cast<int32_t>(offsetof(UserDisconnectUpdate_t4163766056, ___wait_4)); }
	inline Routine_t2502590640 * get_wait_4() const { return ___wait_4; }
	inline Routine_t2502590640 ** get_address_of_wait_4() { return &___wait_4; }
	inline void set_wait_4(Routine_t2502590640 * value)
	{
		___wait_4 = value;
		Il2CppCodeGenWriteBarrier(&___wait_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
