#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_Play_Sub1773278100.h"

// VP`1<Human>
struct VP_1_t1534365499;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUnPause
struct  PlayUnPause_t1931384329  : public Sub_t1773278100
{
public:
	// VP`1<Human> GameState.PlayUnPause::human
	VP_1_t1534365499 * ___human_5;
	// VP`1<System.Single> GameState.PlayUnPause::time
	VP_1_t2454786938 * ___time_6;
	// VP`1<System.Single> GameState.PlayUnPause::duration
	VP_1_t2454786938 * ___duration_7;

public:
	inline static int32_t get_offset_of_human_5() { return static_cast<int32_t>(offsetof(PlayUnPause_t1931384329, ___human_5)); }
	inline VP_1_t1534365499 * get_human_5() const { return ___human_5; }
	inline VP_1_t1534365499 ** get_address_of_human_5() { return &___human_5; }
	inline void set_human_5(VP_1_t1534365499 * value)
	{
		___human_5 = value;
		Il2CppCodeGenWriteBarrier(&___human_5, value);
	}

	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(PlayUnPause_t1931384329, ___time_6)); }
	inline VP_1_t2454786938 * get_time_6() const { return ___time_6; }
	inline VP_1_t2454786938 ** get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(VP_1_t2454786938 * value)
	{
		___time_6 = value;
		Il2CppCodeGenWriteBarrier(&___time_6, value);
	}

	inline static int32_t get_offset_of_duration_7() { return static_cast<int32_t>(offsetof(PlayUnPause_t1931384329, ___duration_7)); }
	inline VP_1_t2454786938 * get_duration_7() const { return ___duration_7; }
	inline VP_1_t2454786938 ** get_address_of_duration_7() { return &___duration_7; }
	inline void set_duration_7(VP_1_t2454786938 * value)
	{
		___duration_7 = value;
		Il2CppCodeGenWriteBarrier(&___duration_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
