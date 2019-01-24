#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3541823733.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingSendUpdate
struct  TypingSendUpdate_t2532589604  : public UpdateBehavior_1_t3541823733
{
public:
	// AdvancedCoroutines.Routine TypingSendUpdate::waitToSend
	Routine_t2502590640 * ___waitToSend_4;
	// AdvancedCoroutines.Routine TypingSendUpdate::waitSend
	Routine_t2502590640 * ___waitSend_5;

public:
	inline static int32_t get_offset_of_waitToSend_4() { return static_cast<int32_t>(offsetof(TypingSendUpdate_t2532589604, ___waitToSend_4)); }
	inline Routine_t2502590640 * get_waitToSend_4() const { return ___waitToSend_4; }
	inline Routine_t2502590640 ** get_address_of_waitToSend_4() { return &___waitToSend_4; }
	inline void set_waitToSend_4(Routine_t2502590640 * value)
	{
		___waitToSend_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitToSend_4, value);
	}

	inline static int32_t get_offset_of_waitSend_5() { return static_cast<int32_t>(offsetof(TypingSendUpdate_t2532589604, ___waitSend_5)); }
	inline Routine_t2502590640 * get_waitSend_5() const { return ___waitSend_5; }
	inline Routine_t2502590640 ** get_address_of_waitSend_5() { return &___waitSend_5; }
	inline void set_waitSend_5(Routine_t2502590640 * value)
	{
		___waitSend_5 = value;
		Il2CppCodeGenWriteBarrier(&___waitSend_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
