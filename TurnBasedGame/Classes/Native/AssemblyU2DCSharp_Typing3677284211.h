#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<System.Single>
struct VP_1_t2454786938;
// LP`1<TypingPlayer>
struct LP_1_t1871581314;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Typing
struct  Typing_t3677284211  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> Typing::isEnable
	VP_1_t4203851724 * ___isEnable_5;
	// VP`1<System.Single> Typing::nextReceiveTime
	VP_1_t2454786938 * ___nextReceiveTime_6;
	// VP`1<System.Single> Typing::stopDuration
	VP_1_t2454786938 * ___stopDuration_7;
	// LP`1<TypingPlayer> Typing::typingPlayers
	LP_1_t1871581314 * ___typingPlayers_8;

public:
	inline static int32_t get_offset_of_isEnable_5() { return static_cast<int32_t>(offsetof(Typing_t3677284211, ___isEnable_5)); }
	inline VP_1_t4203851724 * get_isEnable_5() const { return ___isEnable_5; }
	inline VP_1_t4203851724 ** get_address_of_isEnable_5() { return &___isEnable_5; }
	inline void set_isEnable_5(VP_1_t4203851724 * value)
	{
		___isEnable_5 = value;
		Il2CppCodeGenWriteBarrier(&___isEnable_5, value);
	}

	inline static int32_t get_offset_of_nextReceiveTime_6() { return static_cast<int32_t>(offsetof(Typing_t3677284211, ___nextReceiveTime_6)); }
	inline VP_1_t2454786938 * get_nextReceiveTime_6() const { return ___nextReceiveTime_6; }
	inline VP_1_t2454786938 ** get_address_of_nextReceiveTime_6() { return &___nextReceiveTime_6; }
	inline void set_nextReceiveTime_6(VP_1_t2454786938 * value)
	{
		___nextReceiveTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___nextReceiveTime_6, value);
	}

	inline static int32_t get_offset_of_stopDuration_7() { return static_cast<int32_t>(offsetof(Typing_t3677284211, ___stopDuration_7)); }
	inline VP_1_t2454786938 * get_stopDuration_7() const { return ___stopDuration_7; }
	inline VP_1_t2454786938 ** get_address_of_stopDuration_7() { return &___stopDuration_7; }
	inline void set_stopDuration_7(VP_1_t2454786938 * value)
	{
		___stopDuration_7 = value;
		Il2CppCodeGenWriteBarrier(&___stopDuration_7, value);
	}

	inline static int32_t get_offset_of_typingPlayers_8() { return static_cast<int32_t>(offsetof(Typing_t3677284211, ___typingPlayers_8)); }
	inline LP_1_t1871581314 * get_typingPlayers_8() const { return ___typingPlayers_8; }
	inline LP_1_t1871581314 ** get_address_of_typingPlayers_8() { return &___typingPlayers_8; }
	inline void set_typingPlayers_8(LP_1_t1871581314 * value)
	{
		___typingPlayers_8 = value;
		Il2CppCodeGenWriteBarrier(&___typingPlayers_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
