#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen3649463051.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingPlayerUpdate
struct  TypingPlayerUpdate_t773476365  : public UpdateBehavior_1_t3649463051
{
public:
	// AdvancedCoroutines.Routine TypingPlayerUpdate::waitNextReceive
	Routine_t2502590640 * ___waitNextReceive_4;
	// AdvancedCoroutines.Routine TypingPlayerUpdate::endTyping
	Routine_t2502590640 * ___endTyping_5;

public:
	inline static int32_t get_offset_of_waitNextReceive_4() { return static_cast<int32_t>(offsetof(TypingPlayerUpdate_t773476365, ___waitNextReceive_4)); }
	inline Routine_t2502590640 * get_waitNextReceive_4() const { return ___waitNextReceive_4; }
	inline Routine_t2502590640 ** get_address_of_waitNextReceive_4() { return &___waitNextReceive_4; }
	inline void set_waitNextReceive_4(Routine_t2502590640 * value)
	{
		___waitNextReceive_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitNextReceive_4, value);
	}

	inline static int32_t get_offset_of_endTyping_5() { return static_cast<int32_t>(offsetof(TypingPlayerUpdate_t773476365, ___endTyping_5)); }
	inline Routine_t2502590640 * get_endTyping_5() const { return ___endTyping_5; }
	inline Routine_t2502590640 ** get_address_of_endTyping_5() { return &___endTyping_5; }
	inline void set_endTyping_5(Routine_t2502590640 * value)
	{
		___endTyping_5 = value;
		Il2CppCodeGenWriteBarrier(&___endTyping_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
