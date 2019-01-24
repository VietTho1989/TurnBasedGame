#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.PlayerTotalTime
struct  PlayerTotalTime_t3025311306  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> TimeControl.Normal.PlayerTotalTime::playerIndex
	VP_1_t2450154454 * ___playerIndex_5;
	// VP`1<System.Single> TimeControl.Normal.PlayerTotalTime::serverTime
	VP_1_t2454786938 * ___serverTime_6;
	// VP`1<System.Single> TimeControl.Normal.PlayerTotalTime::clientTime
	VP_1_t2454786938 * ___clientTime_7;

public:
	inline static int32_t get_offset_of_playerIndex_5() { return static_cast<int32_t>(offsetof(PlayerTotalTime_t3025311306, ___playerIndex_5)); }
	inline VP_1_t2450154454 * get_playerIndex_5() const { return ___playerIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_playerIndex_5() { return &___playerIndex_5; }
	inline void set_playerIndex_5(VP_1_t2450154454 * value)
	{
		___playerIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerIndex_5, value);
	}

	inline static int32_t get_offset_of_serverTime_6() { return static_cast<int32_t>(offsetof(PlayerTotalTime_t3025311306, ___serverTime_6)); }
	inline VP_1_t2454786938 * get_serverTime_6() const { return ___serverTime_6; }
	inline VP_1_t2454786938 ** get_address_of_serverTime_6() { return &___serverTime_6; }
	inline void set_serverTime_6(VP_1_t2454786938 * value)
	{
		___serverTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___serverTime_6, value);
	}

	inline static int32_t get_offset_of_clientTime_7() { return static_cast<int32_t>(offsetof(PlayerTotalTime_t3025311306, ___clientTime_7)); }
	inline VP_1_t2454786938 * get_clientTime_7() const { return ___clientTime_7; }
	inline VP_1_t2454786938 ** get_address_of_clientTime_7() { return &___clientTime_7; }
	inline void set_clientTime_7(VP_1_t2454786938 * value)
	{
		___clientTime_7 = value;
		Il2CppCodeGenWriteBarrier(&___clientTime_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
